
namespace VerManagerLibrary
{
    partial class TabInSessionDocs
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
            this.components = new System.ComponentModel.Container();
            this.treeListView_Stablo = new BrightIdeasSoftware.TreeListView();
            this.clmn_PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_FullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Comment = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.button_CostumizeColumns = new System.Windows.Forms.Button();
            this.buttonNewError = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView_Stablo)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListView_Stablo
            // 
            this.treeListView_Stablo.AllColumns.Add(this.clmn_PartName);
            this.treeListView_Stablo.AllColumns.Add(this.clmn_FullName);
            this.treeListView_Stablo.AllColumns.Add(this.clmn_Comment);
            this.treeListView_Stablo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView_Stablo.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.treeListView_Stablo.CellEditUseWholeCell = false;
            this.treeListView_Stablo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmn_PartName,
            this.clmn_FullName,
            this.clmn_Comment});
            this.treeListView_Stablo.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListView_Stablo.GridLines = true;
            this.treeListView_Stablo.HideSelection = false;
            this.treeListView_Stablo.Location = new System.Drawing.Point(3, 3);
            this.treeListView_Stablo.Name = "treeListView_Stablo";
            this.treeListView_Stablo.ShowGroups = false;
            this.treeListView_Stablo.Size = new System.Drawing.Size(1291, 503);
            this.treeListView_Stablo.TabIndex = 4;
            this.treeListView_Stablo.UseCompatibleStateImageBehavior = false;
            this.treeListView_Stablo.View = System.Windows.Forms.View.Details;
            this.treeListView_Stablo.VirtualMode = true;
            this.treeListView_Stablo.SelectionChanged += new System.EventHandler(this.treeListView_Stablo_SelectionChanged);
            // 
            // clmn_PartName
            // 
            this.clmn_PartName.AspectName = "PartName";
            this.clmn_PartName.IsEditable = false;
            this.clmn_PartName.Text = "PartName";
            this.clmn_PartName.Width = 200;
            // 
            // clmn_FullName
            // 
            this.clmn_FullName.AspectName = "FullName";
            this.clmn_FullName.IsEditable = false;
            this.clmn_FullName.Text = "FullName";
            this.clmn_FullName.Width = 200;
            // 
            // clmn_Comment
            // 
            this.clmn_Comment.AspectName = "Comment";
            this.clmn_Comment.Text = "Comment";
            this.clmn_Comment.Width = 300;
            // 
            // button_CostumizeColumns
            // 
            this.button_CostumizeColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_CostumizeColumns.Location = new System.Drawing.Point(3, 617);
            this.button_CostumizeColumns.Name = "button_CostumizeColumns";
            this.button_CostumizeColumns.Size = new System.Drawing.Size(117, 28);
            this.button_CostumizeColumns.TabIndex = 5;
            this.button_CostumizeColumns.Text = "CostumizeColumns";
            this.button_CostumizeColumns.UseVisualStyleBackColor = true;
            this.button_CostumizeColumns.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonNewError
            // 
            this.buttonNewError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNewError.Location = new System.Drawing.Point(139, 618);
            this.buttonNewError.Name = "buttonNewError";
            this.buttonNewError.Size = new System.Drawing.Size(122, 27);
            this.buttonNewError.TabIndex = 6;
            this.buttonNewError.Text = "NewError";
            this.buttonNewError.UseVisualStyleBackColor = true;
            this.buttonNewError.Click += new System.EventHandler(this.buttonNewError_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(630, 512);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(664, 184);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ErrorID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Comment";
            this.columnHeader2.Width = 200;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 619);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // TabInSessionDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonNewError);
            this.Controls.Add(this.button_CostumizeColumns);
            this.Controls.Add(this.treeListView_Stablo);
            this.Name = "TabInSessionDocs";
            this.Size = new System.Drawing.Size(1297, 699);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView_Stablo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.TreeListView treeListView_Stablo;
        private BrightIdeasSoftware.OLVColumn clmn_PartName;
        private BrightIdeasSoftware.OLVColumn clmn_FullName;
        private BrightIdeasSoftware.OLVColumn clmn_Comment;
        private System.Windows.Forms.Button button_CostumizeColumns;
        private System.Windows.Forms.Button buttonNewError;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
    }
}
