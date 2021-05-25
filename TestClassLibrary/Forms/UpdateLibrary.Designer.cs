
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
            this.listView_ChangedDoc = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_DeletedDoc = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fastDataListView_new = new BrightIdeasSoftware.FastDataListView();
            this.clmnFileName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmnFullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmnDate = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView_new)).BeginInit();
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
            this.button_AutoUpdate.Click += new System.EventHandler(this.button_AutoUpdate_Click);
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
            // listView_ChangedDoc
            // 
            this.listView_ChangedDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_ChangedDoc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView_ChangedDoc.HideSelection = false;
            this.listView_ChangedDoc.Location = new System.Drawing.Point(37, 25);
            this.listView_ChangedDoc.Name = "listView_ChangedDoc";
            this.listView_ChangedDoc.Size = new System.Drawing.Size(1335, 306);
            this.listView_ChangedDoc.TabIndex = 3;
            this.listView_ChangedDoc.UseCompatibleStateImageBehavior = false;
            this.listView_ChangedDoc.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "FileName";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
            this.columnHeader2.Width = 354;
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
            this.listView_DeletedDoc.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
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
            this.fastDataListView_new.AllColumns.Add(this.clmnFullName);
            this.fastDataListView_new.AllColumns.Add(this.clmnDate);
            this.fastDataListView_new.CellEditUseWholeCell = false;
            this.fastDataListView_new.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnFileName,
            this.clmnFullName,
            this.clmnDate});
            this.fastDataListView_new.DataSource = null;
            this.fastDataListView_new.HideSelection = false;
            this.fastDataListView_new.Location = new System.Drawing.Point(38, 347);
            this.fastDataListView_new.Name = "fastDataListView_new";
            this.fastDataListView_new.ShowGroups = false;
            this.fastDataListView_new.Size = new System.Drawing.Size(1333, 301);
            this.fastDataListView_new.TabIndex = 5;
            this.fastDataListView_new.UseCompatibleStateImageBehavior = false;
            this.fastDataListView_new.View = System.Windows.Forms.View.List;
            this.fastDataListView_new.VirtualMode = true;
            // 
            // clmnFileName
            // 
            this.clmnFileName.Text = "FileName";
            this.clmnFileName.Width = 200;
            // 
            // clmnFullName
            // 
            this.clmnFullName.Text = "FullName";
            this.clmnFullName.Width = 400;
            // 
            // clmnDate
            // 
            this.clmnDate.Text = "Date";
            this.clmnDate.Width = 200;
            // 
            // UpdateLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 970);
            this.Controls.Add(this.fastDataListView_new);
            this.Controls.Add(this.listView_DeletedDoc);
            this.Controls.Add(this.listView_ChangedDoc);
            this.Controls.Add(this.button_ManualUpdate);
            this.Controls.Add(this.button_AutoUpdate);
            this.Name = "UpdateLibrary";
            this.Text = "UpdateLibrary";
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView_new)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_AutoUpdate;
        private System.Windows.Forms.Button button_ManualUpdate;
        private System.Windows.Forms.ListView listView_ChangedDoc;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listView_DeletedDoc;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private BrightIdeasSoftware.FastDataListView fastDataListView_new;
        private BrightIdeasSoftware.OLVColumn clmnFileName;
        private BrightIdeasSoftware.OLVColumn clmnFullName;
        private BrightIdeasSoftware.OLVColumn clmnDate;
    }
}