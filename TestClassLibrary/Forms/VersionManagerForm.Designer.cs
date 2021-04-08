
namespace VerManagerLibrary
{
    partial class VersionManagerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TabPage tabPage_InSession;
            this.tabInSessionDocs1 = new VerManagerLibrary.TabInSessionDocs();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Library = new System.Windows.Forms.TabPage();
            this.tabStoredLibrary1 = new VerManagerLibrary.TabStoredLibrary();
            this.tabPage_Errors = new System.Windows.Forms.TabPage();
            this.tabErrorList1 = new VerManagerLibrary.TabErrorList();
            tabPage_InSession = new System.Windows.Forms.TabPage();
            tabPage_InSession.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Library.SuspendLayout();
            this.tabPage_Errors.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage_InSession
            // 
            tabPage_InSession.Controls.Add(this.tabInSessionDocs1);
            tabPage_InSession.Location = new System.Drawing.Point(4, 22);
            tabPage_InSession.Name = "tabPage_InSession";
            tabPage_InSession.Padding = new System.Windows.Forms.Padding(3);
            tabPage_InSession.Size = new System.Drawing.Size(1507, 759);
            tabPage_InSession.TabIndex = 0;
            tabPage_InSession.Text = "InSessionDocuments";
            tabPage_InSession.UseVisualStyleBackColor = true;
            // 
            // tabInSessionDocs1
            // 
            this.tabInSessionDocs1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabInSessionDocs1.Location = new System.Drawing.Point(3, 3);
            this.tabInSessionDocs1.Name = "tabInSessionDocs1";
            this.tabInSessionDocs1.Size = new System.Drawing.Size(1501, 756);
            this.tabInSessionDocs1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(tabPage_InSession);
            this.tabControl1.Controls.Add(this.tabPage_Library);
            this.tabControl1.Controls.Add(this.tabPage_Errors);
            this.tabControl1.Location = new System.Drawing.Point(18, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1515, 785);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage_Library
            // 
            this.tabPage_Library.Controls.Add(this.tabStoredLibrary1);
            this.tabPage_Library.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Library.Name = "tabPage_Library";
            this.tabPage_Library.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Library.Size = new System.Drawing.Size(1507, 759);
            this.tabPage_Library.TabIndex = 1;
            this.tabPage_Library.Text = "LibraryDocuments";
            this.tabPage_Library.UseVisualStyleBackColor = true;
            // 
            // tabStoredLibrary1
            // 
            this.tabStoredLibrary1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabStoredLibrary1.Location = new System.Drawing.Point(6, 6);
            this.tabStoredLibrary1.Name = "tabStoredLibrary1";
            this.tabStoredLibrary1.Size = new System.Drawing.Size(1495, 757);
            this.tabStoredLibrary1.TabIndex = 0;
            // 
            // tabPage_Errors
            // 
            this.tabPage_Errors.Controls.Add(this.tabErrorList1);
            this.tabPage_Errors.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Errors.Name = "tabPage_Errors";
            this.tabPage_Errors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Errors.Size = new System.Drawing.Size(1507, 759);
            this.tabPage_Errors.TabIndex = 2;
            this.tabPage_Errors.Text = "Errors";
            this.tabPage_Errors.UseVisualStyleBackColor = true;
            // 
            // tabErrorList1
            // 
            this.tabErrorList1.Location = new System.Drawing.Point(3, 3);
            this.tabErrorList1.Name = "tabErrorList1";
            this.tabErrorList1.Size = new System.Drawing.Size(1501, 753);
            this.tabErrorList1.TabIndex = 0;
            // 
            // VersionManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1545, 810);
            this.Controls.Add(this.tabControl1);
            this.Name = "VersionManagerForm";
            this.Text = "VersionManager";
            tabPage_InSession.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Library.ResumeLayout(false);
            this.tabPage_Errors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Library;
        private System.Windows.Forms.TabPage tabPage_Errors;
        private TabErrorList tabErrorList1;
        private TabInSessionDocs tabInSessionDocs1;
        private TabStoredLibrary tabStoredLibrary1;
    }
}