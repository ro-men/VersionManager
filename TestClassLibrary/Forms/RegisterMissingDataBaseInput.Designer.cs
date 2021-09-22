
namespace VerManagerLibrary_ClassLib
{
    partial class RegisterMissingDataBaseInput
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.OLV_SelectedDocuments = new BrightIdeasSoftware.ObjectListView();
            this.clmn_Lista_PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Lista_FullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Lista_Nomenclature = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Lista_Status = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button_DownloadNewer = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.button_Read = new System.Windows.Forms.Button();
            this.button_Register = new System.Windows.Forms.Button();
            this.clmn_Lista_Dirty = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OLV_SelectedDocuments)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.OLV_SelectedDocuments);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(968, 610);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 0;
            // 
            // OLV_SelectedDocuments
            // 
            this.OLV_SelectedDocuments.AllColumns.Add(this.clmn_Lista_PartName);
            this.OLV_SelectedDocuments.AllColumns.Add(this.clmn_Lista_FullName);
            this.OLV_SelectedDocuments.AllColumns.Add(this.clmn_Lista_Nomenclature);
            this.OLV_SelectedDocuments.AllColumns.Add(this.clmn_Lista_Status);
            this.OLV_SelectedDocuments.AllColumns.Add(this.clmn_Lista_Dirty);
            this.OLV_SelectedDocuments.CellEditUseWholeCell = false;
            this.OLV_SelectedDocuments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmn_Lista_PartName,
            this.clmn_Lista_FullName,
            this.clmn_Lista_Nomenclature,
            this.clmn_Lista_Status,
            this.clmn_Lista_Dirty});
            this.OLV_SelectedDocuments.Cursor = System.Windows.Forms.Cursors.Default;
            this.OLV_SelectedDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OLV_SelectedDocuments.FullRowSelect = true;
            this.OLV_SelectedDocuments.GridLines = true;
            this.OLV_SelectedDocuments.HideSelection = false;
            this.OLV_SelectedDocuments.Location = new System.Drawing.Point(0, 0);
            this.OLV_SelectedDocuments.Name = "OLV_SelectedDocuments";
            this.OLV_SelectedDocuments.Size = new System.Drawing.Size(968, 486);
            this.OLV_SelectedDocuments.TabIndex = 13;
            this.OLV_SelectedDocuments.UseCompatibleStateImageBehavior = false;
            this.OLV_SelectedDocuments.View = System.Windows.Forms.View.Details;
            // 
            // clmn_Lista_PartName
            // 
            this.clmn_Lista_PartName.AspectName = "PartName";
            this.clmn_Lista_PartName.Groupable = false;
            this.clmn_Lista_PartName.Text = "PartName";
            this.clmn_Lista_PartName.Width = 200;
            // 
            // clmn_Lista_FullName
            // 
            this.clmn_Lista_FullName.AspectName = "Key";
            this.clmn_Lista_FullName.Groupable = false;
            this.clmn_Lista_FullName.Text = "FullName";
            this.clmn_Lista_FullName.Width = 200;
            // 
            // clmn_Lista_Nomenclature
            // 
            this.clmn_Lista_Nomenclature.AspectName = "NewNomenclature";
            this.clmn_Lista_Nomenclature.Text = "Nomenclature";
            this.clmn_Lista_Nomenclature.Width = 150;
            // 
            // clmn_Lista_Status
            // 
            this.clmn_Lista_Status.AspectName = "Status";
            this.clmn_Lista_Status.Text = "Status";
            this.clmn_Lista_Status.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(968, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 16);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button_DownloadNewer);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(962, 101);
            this.splitContainer2.SplitterDistance = 320;
            this.splitContainer2.TabIndex = 3;
            // 
            // button_DownloadNewer
            // 
            this.button_DownloadNewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_DownloadNewer.Location = new System.Drawing.Point(0, 0);
            this.button_DownloadNewer.Name = "button_DownloadNewer";
            this.button_DownloadNewer.Size = new System.Drawing.Size(320, 101);
            this.button_DownloadNewer.TabIndex = 1;
            this.button_DownloadNewer.Text = "Download newer";
            this.button_DownloadNewer.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.button_Read);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.button_Register);
            this.splitContainer3.Size = new System.Drawing.Size(638, 101);
            this.splitContainer3.SplitterDistance = 308;
            this.splitContainer3.TabIndex = 0;
            // 
            // button_Read
            // 
            this.button_Read.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Read.Location = new System.Drawing.Point(0, 0);
            this.button_Read.Name = "button_Read";
            this.button_Read.Size = new System.Drawing.Size(308, 101);
            this.button_Read.TabIndex = 2;
            this.button_Read.Text = "Read into Catia and lock";
            this.button_Read.UseVisualStyleBackColor = true;
            this.button_Read.Click += new System.EventHandler(this.button_Read_Click);
            // 
            // button_Register
            // 
            this.button_Register.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Register.Location = new System.Drawing.Point(0, 0);
            this.button_Register.Name = "button_Register";
            this.button_Register.Size = new System.Drawing.Size(326, 101);
            this.button_Register.TabIndex = 3;
            this.button_Register.Text = "Register and upload";
            this.button_Register.UseVisualStyleBackColor = true;
            this.button_Register.Click += new System.EventHandler(this.button_Register_Click);
            // 
            // clmn_Lista_Dirty
            // 
            this.clmn_Lista_Dirty.AspectName = "Modified";
            this.clmn_Lista_Dirty.Text = "Modified";
            // 
            // RegisterMissingDataBaseInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 610);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RegisterMissingDataBaseInput";
            this.Text = "RegisterMissingDataBaseInput";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OLV_SelectedDocuments)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private BrightIdeasSoftware.ObjectListView OLV_SelectedDocuments;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_PartName;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_FullName;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_Nomenclature;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_Status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button_DownloadNewer;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button button_Read;
        private System.Windows.Forms.Button button_Register;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_Dirty;
    }
}