using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace WindowsInstalledUpdates.Helpers
{
    internal class MSCatalogHelper
    {
        public enum MethodVerbs { GET, PUT, PATCH, DELETE, POST };

        internal string SearchMSCatalogue(string id)
        {
            WebRequest request = WebRequest.Create($"http://www.catalog.update.microsoft.com/Search.aspx?q={id}");
            request.Timeout = System.Threading.Timeout.Infinite;
            WebResponse response = request.GetResponse();
            string responseBuffer = null;
            

            if (((HttpWebResponse)response).StatusCode == HttpStatusCode.OK)
            {
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                responseBuffer = reader.ReadToEnd();

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(responseBuffer);
                
                var node = htmlDoc.DocumentNode.SelectSingleNode($"//a[@id='{id}_link']");
                if (null != node)
                    return Regex.Replace(node.InnerText, @"[ \r\n]{2,}", "", RegexOptions.Multiline);                
            }

            return "Not found";
        }
    }
}
