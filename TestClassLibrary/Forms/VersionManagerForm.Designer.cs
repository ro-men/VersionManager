
namespace VerManagerLibrary_ClassLib
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
            this.tabInSessionDocs1 = new VerManagerLibrary_ClassLib.TabInSessionDocs();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage_Library = new System.Windows.Forms.TabPage();
            this.tabStoredLibrary1 = new VerManagerLibrary_ClassLib.TabStoredLibrary();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabRevisionList1 = new VerManagerLibrary_ClassLib.TabRevisionLibrary();
            this.tabPage_Revisions = new System.Windows.Forms.TabPage();
            tabPage_InSession = new System.Windows.Forms.TabPage();
            tabPage_InSession.SuspendLayout();
            this.tabPage_Library.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_Revisions.SuspendLayout();
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
            // tabControl_Main
            // 
            this.tabControl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Main.Controls.Add(tabPage_InSession);
            this.tabControl_Main.Controls.Add(this.tabPage_Library);
            this.tabControl_Main.Controls.Add(this.tabPage_Revisions);
            this.tabControl_Main.Location = new System.Drawing.Point(18, 13);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(1515, 785);
            this.tabControl_Main.TabIndex = 1;
            // 
            // tabRevisionList1
            // 
            this.tabRevisionList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabRevisionList1.Location = new System.Drawing.Point(3, 3);
            this.tabRevisionList1.Name = "tabRevisionList1";
            this.tabRevisionList1.Size = new System.Drawing.Size(1501, 753);
            this.tabRevisionList1.TabIndex = 0;
            // 
            // tabPage_Revisions
            // 
            this.tabPage_Revisions.Controls.Add(this.tabRevisionList1);
            this.tabPage_Revisions.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Revisions.Name = "tabPage_Revisions";
            this.tabPage_Revisions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Revisions.Size = new System.Drawing.Size(1507, 759);
            this.tabPage_Revisions.TabIndex = 2;
            this.tabPage_Revisions.Text = "Revisions";
            this.tabPage_Revisions.UseVisualStyleBackColor = true;
            // 
            // VersionManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1545, 810);
            this.Controls.Add(this.tabControl_Main);
            this.Name = "VersionManagerForm";
            this.Text = "VersionManager";
            tabPage_InSession.ResumeLayout(false);
            this.tabPage_Library.ResumeLayout(false);
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_Revisions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPage_Library;
        private TabStoredLibrary tabStoredLibrary1;
        private TabInSessionDocs tabInSessionDocs1;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_Revisions;
        private TabRevisionLibrary tabRevisionList1;
    }
}