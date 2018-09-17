// Decompiled with JetBrains decompiler
// Type: PLCRMStatusMarkingService.ProjectInstaller
// Assembly: XRecCRMService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 7FEAB8C4-2C93-4EF2-ADFC-4B29F705460E
// Assembly location: E:\Services\XCRMServices\XRecCRMService.exe

using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.ServiceProcess;


namespace PLCRMStatusMarkingService
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {

        private IContainer components = (IContainer)null;
        private ServiceProcessInstaller serviceProcessInstaller1;
        private ServiceInstaller serviceInstaller1;

        public ProjectInstaller()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }
      
        private void InitializeComponent()
        {
            this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller1
            // 
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller1.Password = null;
            this.serviceProcessInstaller1.Username = null;
            // 
            // serviceInstaller1
            // 
            this.serviceInstaller1.Description = "BRecCRMService";
            this.serviceInstaller1.DisplayName = "BRecCRMService";
            this.serviceInstaller1.ServiceName = "BRecCRMService";
            this.serviceInstaller1.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.serviceInstaller1});

        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
