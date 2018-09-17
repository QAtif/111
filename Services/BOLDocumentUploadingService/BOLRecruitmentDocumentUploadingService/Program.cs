using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace BOLRecruitmentDocumentUploadingService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            try
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			{ 
				new BOLRecruitmentDocumentUploadingService() 
               
			};
                ServiceBase.Run(ServicesToRun);
            }
            catch (Exception ex) { }
        }
    }
}
