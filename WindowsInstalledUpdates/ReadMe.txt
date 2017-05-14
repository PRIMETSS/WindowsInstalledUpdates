WindowsInstalledUpdates

What is it:

To assist with #WannaCrypt exploit mitigation by sys admins

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



