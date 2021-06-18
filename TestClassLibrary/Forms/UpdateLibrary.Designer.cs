
namespace VerManagerLibrary
{
    partial class UpdateLibrary
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
            this.button_AutoUpdate = new System.Windows.Forms.Button();
            this.button_ManualUpdate = new System.Windows.Forms.Button();
            this.listView_DeletedDoc = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fastDataListView_new = new BrightIdeasSoftware.FastDataListView();
            this.clmnFileName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmnDirectory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmnDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.fastDataListView_modified = new BrightIdeasSoftware.FastDataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView_new)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView_modified)).BeginInit();
            this.SuspendLayout();
            // 
            // button_AutoUpdate
            // 
            this.button_AutoUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_AutoUpdate.Location = new System.Drawing.Point(171, 900);
            this.button_AutoUpdate.Name = "button_AutoUpdate";
            this.button_AutoUpdate.Size = new System.Drawing.Size(168, 38);
            this.button_AutoUpdate.TabIndex = 1;
            this.button_AutoUpdate.Text = "AutoUpdate";
            this.button_AutoUpdate.UseVisualStyleBackColor = true;
            // 
            // button_ManualUpdate
            // 
            this.button_ManualUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_ManualUpdate.Location = new System.Drawing.Point(424, 900);
            this.button_ManualUpdate.Name = "button_ManualUpdate";
            this.button_ManualUpdate.Size = new System.Drawing.Size(168, 38);
            this.button_ManualUpdate.TabIndex = 2;
            this.button_ManualUpdate.Text = "ManualUpdate";
            this.button_ManualUpdate.UseVisualStyleBackColor = true;
            // 
            // listView_DeletedDoc
            // 
            this.listView_DeletedDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_DeletedDoc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listView_DeletedDoc.HideSelection = false;
            this.listView_DeletedDoc.Location = new System.Drawing.Point(37, 670);
            this.listView_DeletedDoc.Name = "listView_DeletedDoc";
            this.listView_DeletedDoc.Size = new System.Drawing.Size(1335, 188);
            this.listView_DeletedDoc.TabIndex = 4;
            this.listView_DeletedDoc.UseCompatibleStateImageBehavior = false;
            this.listView_DeletedDoc.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "FileName";
            this.columnHeader3.Width = 300;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Date";
            this.columnHeader4.Width = 354;
            // 
            // fastDataListView_new
            // 
            this.fastDataListView_new.AllColumns.Add(this.clmnFileName);
            this.fastDataListView_new.AllColumns.Add(this.clmnDirectory);
            this.fastDataListView_new.AllColumns.Add(this.clmnDate);
            this.fastDataListView_new.CellEditUseWholeCell = false;
            this.fastDataListView_new.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnFileName,
            this.clmnDirectory,
            this.clmnDate});
            this.fastDataListView_new.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastDataListView_new.DataSource = null;
            this.fastDataListView_new.HideSelection = false;
            this.fastDataListView_new.Location = new System.Drawing.Point(38, 347);
            this.fastDataListView_new.Name = "fastDataListView_new";
            this.fastDataListView_new.ShowGroups = false;
            this.fastDataListView_new.Size = new System.Drawing.Size(1333, 301);
            this.fastDataListView_new.TabIndex = 5;
            this.fastDataListView_new.UseCompatibleStateImageBehavior = false;
            this.fastDataListView_new.View = System.Windows.Forms.View.Details;
            this.fastDataListView_new.VirtualMode = true;
            // 
            // clmnFileName
            // 
            this.clmnFileName.AspectName = "Name";
            this.clmnFileName.Tag = "";
            this.clmnFileName.Text = "FileName";
            this.clmnFileName.Width = 200;
            // 
            // clmnDirectory
            // 
            this.clmnDirectory.AspectName = "Directory";
            this.clmnDirectory.Text = "Directory";
            this.clmnDirectory.Width = 400;
            // 
            // clmnDate
            // 
            this.clmnDate.Text = "Date";
            this.clmnDate.Width = 200;
            // 
            // fastDataListView_modified
            // 
            this.fastDataListView_modified.AllColumns.Add(this.olvColumn1);
            this.fastDataListView_modified.AllColumns.Add(this.olvColumn2);
            this.fastDataListView_modified.AllColumns.Add(this.olvColumn3);
            this.fastDataListView_modified.CellEditUseWholeCell = false;
            this.fastDataListView_modified.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3});
            this.fastDataListView_modified.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastDataListView_modified.DataSource = null;
            this.fastDataListView_modified.HideSelection = false;
            this.fastDataListView_modified.Location = new System.Drawing.Point(37, 22);
            this.fastDataListView_modified.Name = "fastDataListView_modified";
            this.fastDataListView_modified.ShowGroups = false;
            this.fastDataListView_modified.Size = new System.Drawing.Size(1333, 301);
            this.fastDataListView_modified.TabIndex = 6;
            this.fastDataListView_modified.UseCompatibleStateImageBehavior = false;
            this.fastDataListView_modified.View = System.Windows.Forms.View.Details;
            this.fastDataListView_modified.VirtualMode = true;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "PartName";
            this.olvColumn1.Tag = "";
            this.olvColumn1.Text = "FileName";
            this.olvColumn1.Width = 200;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Directory";
            this.olvColumn2.Text = "Directory";
            this.olvColumn2.Width = 400;
            // 
            // olvColumn3
            // 
            this.olvColumn3.Text = "Date";
            this.olvColumn3.Width = 200;
            // 
            // UpdateLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 970);
            this.Controls.Add(this.fastDataListView_modified);
            this.Controls.Add(this.fastDataListView_new);
            this.Controls.Add(this.listView_DeletedDoc);
            this.Controls.Add(this.button_ManualUpdate);
            this.Controls.Add(this.button_AutoUpdate);
            this.Name = "UpdateLibrary";
            this.Text = "UpdateLibrary";
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView_new)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView_modified)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_AutoUpdate;
        private System.Windows.Forms.Button button_ManualUpdate;
        private System.Windows.Forms.ListView listView_DeletedDoc;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private BrightIdeasSoftware.FastDataListView fastDataListView_new;
        private BrightIdeasSoftware.OLVColumn clmnFileName;
        private BrightIdeasSoftware.OLVColumn clmnDirectory;
        private BrightIdeasSoftware.OLVColumn clmnDate;
        private BrightIdeasSoftware.FastDataListView fastDataListView_modified;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
    }
}