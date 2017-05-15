WindowsInstalledUpdates

What is it:

To assist with #WannaCrypt exploit mitigation by sys admins.
Now MS has moved to a monthly rollup model, trying to find out if the updates installed on a system actually supersede previous can be frustrating.
This tool searches the local Windows Update store and if an update is flagged as superceding a previous update, it will go out and search the Windows Update Catalog and extract the KB artical info for the previous update and list it.
It also displays information on Update Bundeling, Security Bulletin's and (Cve's) Common Vulnerabilities & Exposures links.

Example:

Searching for installed updates...
The following updates are installed

Title: [2017-05 Security Monthly Quality Rollup for Windows Server 2012 R2 for x64-based Systems (KB4019215)], Installed: [True]
  KB 4019215
    SupersededUpdateID: [dd2d22ce-79d3-4e63-9e08-6c0a794cfd99] (Doing MSCatalog search...)      Supersedes: April, 2017 Security Monthly Quality Rollup for Windows Server 2012 R2 (KB4015550)
    SupersededUpdateID: [22f94849-f5ca-45f2-b56b-77a12edaafbe] (Doing MSCatalog search...)      Supersedes: April, 2017 Preview of Monthly Quality Rollup for Windows Server 2012 R2 (KB4015553)
    SupersededUpdateID: [bc58fb60-026c-403d-b7d9-b79da671b2c7] (Doing MSCatalog search...)      Supersedes: Update for Windows Server 2012 R2 (KB3118401)
    SupersededUpdateID: [3ac2f5b1-1e53-4f69-a350-73776806cc24] (Doing MSCatalog search...)      Supersedes: Update for Windows Server 2012 R2 (KB3139649)
    SupersededUpdateID: [4c2bbbad-30b5-4e8d-affb-da0751ab5530] (Doing MSCatalog search...)      Supersedes: Update for Windows Server 2012 R2 (KB3133681)
    SupersededUpdateID: [d2c24328-79b3-4a57-9e6d-45d096d2a88b] (Doing MSCatalog search...)      Supersedes: Update for Windows Server 2012 R2 (KB3029803)
    SupersededUpdateID: [c31a022f-eb21-454b-a08b-99e5d33070f4] (Doing MSCatalog search...)      Supersedes: Update for Windows Server 2012 R2 (KB3052480)
    SupersededUpdateID: [8fa86350-86de-4723-9754-9b9b8856cfcd] (Doing MSCatalog search...)      Supersedes: Security Update for Windows Server 2012 R2 (KB3156019)
    SupersededUpdateID: [841c88e0-9247-4028-8f88-a9b4e3dd9ca6] (Doing MSCatalog search...)      Supersedes: Update for Windows Server 2012 R2 (KB3105115)
    SupersededUpdateID: [64d172a0-0906-4f98-8707-47326969fb7d] (Doing MSCatalog search...)      Supersedes: Update for Windows Server 2012 R2 (KB3141074)
    SupersededUpdateID: [201ac256-dde3-4765-a85f-445598f98af1] (Doing MSCatalog search...)      Supersedes: Update for Windows Server 2012 R2 (KB3140786)
    SupersededUpdateID: [d6c864d6-b283-4404-bd46-9fe434fb8356] (Doing MSCatalog search...)      Supersedes: Security Update for Windows Server 2012 R2 (KB2965161) without KB2919355
    SupersededUpdateID: [c3075a2f-2e99-41d8-98bb-838e36fa814d] (Doing MSCatalog search...)      Supersedes: Update for Windows Server 2012 R2 (KB3130944)
    SupersededUpdateID: [262d5248-8027-4abd-a280-3dc591efe77c] (Doing MSCatalog search...)      Supersedes: Update for Windows Server 2012 R2 (KB3068708)
    SupersededUpdateID: [2be0f6a9-7c4a-4b46-93d3-f044f94b589c] (Doing MSCatalog search...)      Supersedes: Security Update for Windows Server 2012 R2 (KB3108347)
    SupersededUpdateID: [1e495e58-8a3b-404a-9502-cf6dbd7e27a5] (Doing MSCatalog search...)      Supersedes: Security Update for Windows Server 2012 R2 (KB3080446)
    SupersededUpdateID: [8af479f4-849c-454c-82d4-932cd24237b1] (Doing MSCatalog search...)      Supersedes: Update for Windows Server 2012 R2 (KB3037313)
    SupersededUpdateID: [e6861348-6470-4b5f-8d07-97645f195f98] (Doing MSCatalog search...)      Supersedes: Security Update for Windows Server 2012 R2 (KB3033889)


It was designed as a command line tool, single .exe, to be light weight and requires no install in its .exe form (there is a Click-Once version that can be deployed via a webserver if you want it to be self-updating, (installs as a MS Click-Once App that can be uninstalled).
Its dependant on .DOT NET 4, but looking at targeting lower frameworks. It comes bundled with HtmlAgilityPak DLL's (1.4.9.5) from their NuGet package page, which is only used when querying the MS Updates Catalog for superseded updates, these are embedded in the .exe as embedded resource dll’s so as not to be required externally for simpler deployment.
It does have a dependency on the Microsoft DotNet Framework, but the compiled version targets Framework v4. However, from the source code you can re-compile and target any framework v3.5-v4.5.


	Credits: 
	https://www.thurrott.com/windows/116018/microsoft-ransomware-targets-date-pcs

	GitHub Repo
	https://github.com/PRIMETSS/WindowsInstalledUpdates.git


What it's not:


It’s still being developed as suggestions come in, but I will put the code up in a public repo on GITHUB shortly. I'm sharing it early because the potential of this issue could be serious and I hope it may useful to others. If you have any suggestions or comments, please contact me direct.



Legal:
	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
	https://opensource.org/licenses/MIT

Thanks

Paul Farrand
paul.farrand@primetss.com.au
PrimeTSS

Version 
1.0.0.0	Initial
1.1.0.0 Fixed issue with System.IOException when piping '>updates.txt' to text file, cursor control



