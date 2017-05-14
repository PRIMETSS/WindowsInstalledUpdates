using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WUApiLib;//this is required to use the Interfaces given by microsoft. 
using WindowsInstalledUpdates.Helpers;
using System.Reflection;

namespace MSHWindowsUpdateAgent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"PrimeTSS WindowsInstalledUpdates Version [{typeof(Program).Assembly.GetName().Version}]");

            EnableUpdateServices();

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            Console.WriteLine("\nSearching for installed updates...");
            InstalledUpdates();

            Console.WriteLine("\nFinished");
            Console.Read();
        }

        public static void InstalledUpdates()
        {
            UpdateSession UpdateSession = new UpdateSession();
            IUpdateSearcher UpdateSearchResult = UpdateSession.CreateUpdateSearcher();
            UpdateSearchResult.Online = true;//checks for updates online
            ISearchResult SearchResults = UpdateSearchResult.Search("IsInstalled=1 AND IsHidden=0");
            
            
            Console.WriteLine("The following updates are installed");

            List<IUpdate5> resultIUpdateList = new List<IUpdate5>();
            foreach (IUpdate5 x in SearchResults.Updates)
                resultIUpdateList.Add(x);


            foreach (IUpdate5 x in resultIUpdateList.OrderByDescending(o => o.LastDeploymentChangeTime))
            {
                Console.WriteLine($"\nTitle: [{x.Title}], Installed: [{x.IsInstalled}]");
                if (0 != x.KBArticleIDs.Count)
                {
                    foreach (var kbids in x.KBArticleIDs)
                        Console.WriteLine($"  KB {kbids}");
                }
                // Superceeds
                if (0 != x.SupersededUpdateIDs.Count)
                {
                    MSCatalogHelper MSCatalog = new MSCatalogHelper();

                    foreach (var ssids in x.SupersededUpdateIDs)
                    {
                        
                        Console.Write($"    SupersededUpdateID: [{ssids}] (Doing MSCatalog search...)\r");
                        string result = MSCatalog.SearchMSCatalogue(ssids.ToString());
                        ClearCurrentConsoleLine();
                        Console.WriteLine($"      Supersedes: {result}");
                    }
                }

                // Cve
                if (0 != x.CveIDs.Count)
                {
                    foreach (var cveid in x.CveIDs)
                    {
                        Console.WriteLine($"    CveID: [{cveid}]");
                    }
                }

                // Cve
                if (0 != x.SecurityBulletinIDs.Count)
                {
                    foreach (var sbids in x.SecurityBulletinIDs)
                    {
                        Console.WriteLine($"    Security BulletinsID: [{sbids}]");
                    }
                }

                // Bundled
                if (x.BundledUpdates.Count > 0)
                {
                    foreach (IUpdate bu in x.BundledUpdates)
                    {
                        Console.WriteLine($"    BundledUpdate: Title: [{bu.Title}], Installed: [{bu.IsInstalled}]");
                        foreach (var kbids in bu.KBArticleIDs)
                            Console.WriteLine($"      KB {kbids}");
                    }
                }
            }
        }

        public static void EnableUpdateServices()
        {
            Console.WriteLine("Checking Windows Update Service is running");

            IAutomaticUpdates updates = new AutomaticUpdates();
            if (!updates.ServiceEnabled)
            {
                Console.WriteLine("Windows update service was not enabled. Enabling Now" + updates.ServiceEnabled);
                updates.EnableService();
                Console.WriteLine("Service enabled");
            }
            else
                Console.WriteLine("Running");


        }

        public static string ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);

            return null;
        }

        /// <summary>
        /// Bring in external Intel DLL's as assembly resources and embed them into the .EXE for easier deployment & cmd line use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(',') ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");

            dllName = dllName.Replace(".", "_");

            if (dllName.EndsWith("_resources")) return null;

            System.Resources.ResourceManager rm = new System.Resources.ResourceManager("WindowsInstalledUpdates" + ".Properties.Resources", Assembly.GetExecutingAssembly());

            byte[] bytes = (byte[])rm.GetObject(dllName);

            return System.Reflection.Assembly.Load(bytes);
        }
    }
}
