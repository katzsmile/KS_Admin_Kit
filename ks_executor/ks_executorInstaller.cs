using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace ks_executor
{
    [RunInstaller(true)]
    public class ks_executorInstaller : Installer
    {
        /// <summary>
        /// Public Constructor for WindowsServiceInstaller.
        /// - Put all of your Initialization code here.
        /// </summary>
        public ks_executorInstaller()
        {
            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();

            //# Service Account Information
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceProcessInstaller.Username = null;
            serviceProcessInstaller.Password = null;

            //# Service Information
            serviceInstaller.DisplayName = "KS Executor Service";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            // This must be identical to the ks_executor.ServiceBase name
            // set in the constructor of ks_executor.cs
            serviceInstaller.ServiceName = "KS Executor";
            serviceInstaller.Description = "KS Executor is a helper service for KS Admin Kit";

            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);
        }
    }
}
