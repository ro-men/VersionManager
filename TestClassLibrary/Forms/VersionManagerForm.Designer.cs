
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
            System.Windows.Forms.TabPage tabPage_Documents;
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_Revisions = new System.Windows.Forms.TabPage();
            this.tabDocuments1 = new VerManagerLibrary_ClassLib.TabDocumentsLibrary();
            this.tabRevisionList1 = new VerManagerLibrary_ClassLib.TabRevisionLibrary();
            tabPage_Documents = new System.Windows.Forms.TabPage();
            tabPage_Documents.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_Revisions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage_Documents
            // 
            tabPage_Documents.Controls.Add(this.tabDocuments1);
            tabPage_Documents.Location = new System.Drawing.Point(4, 25);
            tabPage_Documents.Name = "tabPage_Documents";
            tabPage_Documents.Padding = new System.Windows.Forms.Padding(3);
            tabPage_Documents.Size = new System.Drawing.Size(1507, 756);
            tabPage_Documents.TabIndex = 0;
            tabPage_Documents.Text = "Documents";
            tabPage_Documents.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Main.Controls.Add(tabPage_Documents);
            this.tabControl_Main.Controls.Add(this.tabPage_Revisions);
            this.tabControl_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl_Main.Location = new System.Drawing.Point(18, 13);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(1515, 785);
            this.tabControl_Main.TabIndex = 1;
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
            // tabDocuments1
            // 
            this.tabDocuments1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDocuments1.Location = new System.Drawing.Point(3, 3);
            this.tabDocuments1.Name = "tabDocuments1";
            this.tabDocuments1.Size = new System.Drawing.Size(1501, 753);
            this.tabDocuments1.TabIndex = 0;
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
            // VersionManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1545, 810);
            this.Controls.Add(this.tabControl_Main);
            this.Name = "VersionManagerForm";
            this.Text = "VersionManager";
            tabPage_Documents.ResumeLayout(false);
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_Revisions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_Revisions;
        private TabRevisionLibrary tabRevisionList1;
        private TabDocumentsLibrary tabDocuments1;
    }
}