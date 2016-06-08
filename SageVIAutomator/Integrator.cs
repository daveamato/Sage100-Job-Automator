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

        public Integrator(string uncPath, string username, string password, string company, string jobName)
        {
            this.uncPath = uncPath;
            this.username = username;
            this.password = password;
            this.company = company;
            this.jobName = jobName;

            this.fullPath = uncPath + @"\" + PROGRAM_FILE;
        }

        public void runJob()
        {
            var processInfo = new ProcessStartInfo(fullPath);
            processInfo.WorkingDirectory = uncPath;
            processInfo.Arguments = string.Format("..launcher sota.ini ..SOA Startup.M4P -ARG DIRECT UION {0} {1} {2} {3} AUTO", username, password, company, jobName);

            Process.Start(processInfo);
        }
    }
}
