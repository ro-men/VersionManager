
namespace VerManagerLibrary_ClassLib
{
    partial class TabRevisionLibrary
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
            this.FDLV_RevisionsList = new BrightIdeasSoftware.FastDataListView();
            this.FDLV_Revision_ID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Revision_SolvedStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DLV_ItemsList = new BrightIdeasSoftware.DataListView();
            this.DLV_Items_PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DLV_Items_RevisionSolved = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DLV_Items_Level = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenu_RightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.FDLV_RevisionsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLV_ItemsList)).BeginInit();
            this.contextMenu_RightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // FDLV_RevisionsList
            // 
            this.FDLV_RevisionsList.AllColumns.Add(this.FDLV_Revision_ID);
            this.FDLV_RevisionsList.AllColumns.Add(this.FDLV_Revision_SolvedStatus);
            this.FDLV_RevisionsList.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FDLV_RevisionsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FDLV_RevisionsList.CellEditUseWholeCell = false;
            this.FDLV_RevisionsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FDLV_Revision_ID,
            this.FDLV_Revision_SolvedStatus});
            this.FDLV_RevisionsList.Cursor = System.Windows.Forms.Cursors.Default;
            this.FDLV_RevisionsList.DataSource = null;
            this.FDLV_RevisionsList.HideSelection = false;
            this.FDLV_RevisionsList.Location = new System.Drawing.Point(6, 6);
            this.FDLV_RevisionsList.MultiSelect = false;
            this.FDLV_RevisionsList.Name = "FDLV_RevisionsList";
            this.FDLV_RevisionsList.ShowGroups = false;
            this.FDLV_RevisionsList.Size = new System.Drawing.Size(975, 318);
            this.FDLV_RevisionsList.TabIndex = 0;
            this.FDLV_RevisionsList.UseAlternatingBackColors = true;
            this.FDLV_RevisionsList.UseCompatibleStateImageBehavior = false;
            this.FDLV_RevisionsList.View = System.Windows.Forms.View.Details;
            this.FDLV_RevisionsList.VirtualMode = true;
            this.FDLV_RevisionsList.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.FDLV_RevisionsList_CellRightClick);
            this.FDLV_RevisionsList.SelectionChanged += new System.EventHandler(this.FDLV_RevisionsList_SelectionChanged);
            this.FDLV_RevisionsList.DoubleClick += new System.EventHandler(this.StartRevisionEdit);
            // 
            // FDLV_Revision_ID
            // 
            this.FDLV_Revision_ID.AspectName = "RevisionID";
            this.FDLV_Revision_ID.Text = "ID";
            this.FDLV_Revision_ID.Width = 200;
            // 
            // FDLV_Revision_SolvedStatus
            // 
            this.FDLV_Revision_SolvedStatus.AspectName = "SolvedStatus";
            this.FDLV_Revision_SolvedStatus.Width = 120;
            // 
            // DLV_ItemsList
            // 
            this.DLV_ItemsList.AllColumns.Add(this.DLV_Items_PartName);
            this.DLV_ItemsList.AllColumns.Add(this.DLV_Items_RevisionSolved);
            this.DLV_ItemsList.AllColumns.Add(this.DLV_Items_Level);
            this.DLV_ItemsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DLV_ItemsList.CellEditUseWholeCell = false;
            this.DLV_ItemsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DLV_Items_PartName,
            this.DLV_Items_RevisionSolved,
            this.DLV_Items_Level});
            this.DLV_ItemsList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DLV_ItemsList.DataSource = null;
            this.DLV_ItemsList.HideSelection = false;
            this.DLV_ItemsList.Location = new System.Drawing.Point(6, 334);
            this.DLV_ItemsList.Name = "DLV_ItemsList";
            this.DLV_ItemsList.Size = new System.Drawing.Size(978, 244);
            this.DLV_ItemsList.TabIndex = 1;
            this.DLV_ItemsList.UseCompatibleStateImageBehavior = false;
            this.DLV_ItemsList.View = System.Windows.Forms.View.Details;
            // 
            // DLV_Items_PartName
            // 
            this.DLV_Items_PartName.AspectName = "Key";
            this.DLV_Items_PartName.Sortable = false;
            this.DLV_Items_PartName.Text = "PartName";
            this.DLV_Items_PartName.Width = 500;
            // 
            // DLV_Items_RevisionSolved
            // 
            this.DLV_Items_RevisionSolved.AspectName = "";
            this.DLV_Items_RevisionSolved.Text = "RevisionSolved";
            this.DLV_Items_RevisionSolved.Width = 120;
            // 
            // DLV_Items_Level
            // 
            this.DLV_Items_Level.Text = "Level";
            this.DLV_Items_Level.Width = 120;
            // 
            // contextMenu_RightClick
            // 
            this.contextMenu_RightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Edit,
            this.toolStripMenuItem_Delete});
            this.contextMenu_RightClick.Name = "contextMenuStrip1";
            this.contextMenu_RightClick.Size = new System.Drawing.Size(108, 48);
            // 
            // toolStripMenuItem_Edit
            // 
            this.toolStripMenuItem_Edit.Name = "toolStripMenuItem_Edit";
            this.toolStripMenuItem_Edit.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem_Edit.Text = "Edit";
            this.toolStripMenuItem_Edit.Click += new System.EventHandler(this.StartRevisionEdit);
            // 
            // toolStripMenuItem_Delete
            // 
            this.toolStripMenuItem_Delete.Name = "toolStripMenuItem_Delete";
            this.toolStripMenuItem_Delete.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem_Delete.Text = "Delete";
            this.toolStripMenuItem_Delete.Click += new System.EventHandler(this.DeleteRevision);
            // 
            // TabRevisionLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DLV_ItemsList);
            this.Controls.Add(this.FDLV_RevisionsList);
            this.Name = "TabRevisionLibrary";
            this.Size = new System.Drawing.Size(988, 609);
            this.Load += new System.EventHandler(this.TabRevisionLibrary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FDLV_RevisionsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLV_ItemsList)).EndInit();
            this.contextMenu_RightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastDataListView FDLV_RevisionsList;
        private BrightIdeasSoftware.OLVColumn FDLV_Revision_ID;
        private BrightIdeasSoftware.DataListView DLV_ItemsList;
        private BrightIdeasSoftware.OLVColumn DLV_Items_PartName;
        private BrightIdeasSoftware.OLVColumn DLV_Items_RevisionSolved;
        private BrightIdeasSoftware.OLVColumn DLV_Items_Level;
        private BrightIdeasSoftware.OLVColumn FDLV_Revision_SolvedStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenu_RightClick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Delete;
    }
}
