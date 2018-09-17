namespace BOLRecruitmentDocumentUploadingService
{
    partial class BOLRecruitmentDocumentUploadingService
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tmrExecutor = new System.Timers.Timer();
            this.tmrExecutorError = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.tmrExecutor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmrExecutorError)).BeginInit();
            // 
            // tmrExecutor
            // 
            this.tmrExecutor.Enabled = true;
            this.tmrExecutor.Interval = 30000D;
            this.tmrExecutor.Elapsed += new System.Timers.ElapsedEventHandler(this.tmrExecutor_Elapsed);
            // 
            // tmrExecutorError
            // 
            this.tmrExecutorError.Enabled = true;
            this.tmrExecutorError.Interval = 30000D;
            this.tmrExecutorError.Elapsed += new System.Timers.ElapsedEventHandler(this.tmrExecutorError_Elapsed);
            // 
            // XRecruitmentDocumentUploadingService
            // 
            this.ServiceName = "Service1";
            ((System.ComponentModel.ISupportInitialize)(this.tmrExecutor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmrExecutorError)).EndInit();

        }

        #endregion

        private System.Timers.Timer tmrExecutor;
        private System.Timers.Timer tmrExecutorError;
    }
}
