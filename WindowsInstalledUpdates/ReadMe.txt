Publish URL

http://www.primetss.com.au/softwaredeploy/windowsupdateintelamtdetector/publish.htm


Bitly to ZIP file


Using Microsofts Intel AMT API’s that are part of the AMT software development kit intel released to ‘talk’ to AMT through ME
Basically what it does is
               Checks if AMT is visible (This is done without any Authentication to AMT)
               If AMT detected, checks its current state (need to pass -user and -pass command line switches, as need to authenticate with AMT)
               Checks to see if the Intel Local Management Service (ME services) has been installed? And if so reports the services current running state.
               If installed checks if any services are listening on the ME ports
               Checks to see if other variants of LMS are installed like MicroLMS has been installed? And if so reports the services current running state.
               If installed checks if any services are listening on the ME ports

DotNet Dependenacy

https://msdn.microsoft.com/en-us/library/jj152935(v=vs.110).aspx

Run as Administrator

