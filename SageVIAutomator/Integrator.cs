using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SageVIAutomator
{
    public class Integrator
    {
        private const string PROGRAM_FILE = "Pvxwin32.exe"; 

        private string uncPath;
        private string username;
        private string password;
        private string company;
        private string jobName;
        private string fullPath;
        private string automan;

        public Integrator(string uncPath, string username, string password, string company, string jobName, bool isAuto = true)
        {
            this.uncPath = uncPath;
            this.username = username;
            this.password = password;
            this.company = company;
            this.jobName = jobName;

            this.automan = (isAuto ? "AUTO" : "MANUAL");

            this.fullPath = uncPath + @"\" + PROGRAM_FILE;
        }

        public Process runJob()
        {
            var processInfo = new ProcessStartInfo(fullPath);
            processInfo.WorkingDirectory = uncPath;
            processInfo.Arguments = string.Format("..launcher sota.ini ..SOA Startup.M4P -ARG DIRECT UION {0} {1} {2} {3} {4}", username, password, company, jobName, automan);

            return Process.Start(processInfo);
        }

        public void runJobToCompletion()
        {
            Process p = runJob();

            p.WaitForExit();
        }
    }
}
