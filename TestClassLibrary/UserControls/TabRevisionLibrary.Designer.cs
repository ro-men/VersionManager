
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
            this.contextMenu_RightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.splitContainer_Upper = new System.Windows.Forms.SplitContainer();
            this.FDLV_RevisionsList = new BrightIdeasSoftware.FastDataListView();
            this.FDLV_Revision_ID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Importance_level = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Revision_SolvedStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.textBoxComent = new System.Windows.Forms.TextBox();
            this.DLV_ItemsList = new BrightIdeasSoftware.DataListView();
            this.DLV_Items_PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DLV_Items_RevisionSolved = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.DLV_Items_Level = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenu_RightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Upper)).BeginInit();
            this.splitContainer_Upper.Panel1.SuspendLayout();
            this.splitContainer_Upper.Panel2.SuspendLayout();
            this.splitContainer_Upper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FDLV_RevisionsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLV_ItemsList)).BeginInit();
            this.SuspendLayout();
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
            // splitContainer_Main
            // 
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Main.Name = "splitContainer_Main";
            this.splitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.splitContainer_Upper);
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.Controls.Add(this.DLV_ItemsList);
            this.splitContainer_Main.Size = new System.Drawing.Size(1540, 818);
            this.splitContainer_Main.SplitterDistance = 429;
            this.splitContainer_Main.TabIndex = 15;
            // 
            // splitContainer_Upper
            // 
            this.splitContainer_Upper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Upper.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Upper.Name = "splitContainer_Upper";
            // 
            // splitContainer_Upper.Panel1
            // 
            this.splitContainer_Upper.Panel1.Controls.Add(this.FDLV_RevisionsList);
            // 
            // splitContainer_Upper.Panel2
            // 
            this.splitContainer_Upper.Panel2.Controls.Add(this.textBoxComent);
            this.splitContainer_Upper.Size = new System.Drawing.Size(1540, 429);
            this.splitContainer_Upper.SplitterDistance = 1000;
            this.splitContainer_Upper.TabIndex = 0;
            // 
            // FDLV_RevisionsList
            // 
            this.FDLV_RevisionsList.AllColumns.Add(this.FDLV_Revision_ID);
            this.FDLV_RevisionsList.AllColumns.Add(this.FDLV_Importance_level);
            this.FDLV_RevisionsList.AllColumns.Add(this.FDLV_Revision_SolvedStatus);
            this.FDLV_RevisionsList.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FDLV_RevisionsList.BackColor = System.Drawing.Color.AntiqueWhite;
            this.FDLV_RevisionsList.CellEditUseWholeCell = false;
            this.FDLV_RevisionsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FDLV_Revision_ID,
            this.FDLV_Importance_level,
            this.FDLV_Revision_SolvedStatus});
            this.FDLV_RevisionsList.Cursor = System.Windows.Forms.Cursors.Default;
            this.FDLV_RevisionsList.DataSource = null;
            this.FDLV_RevisionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FDLV_RevisionsList.FullRowSelect = true;
            this.FDLV_RevisionsList.HideSelection = false;
            this.FDLV_RevisionsList.Location = new System.Drawing.Point(0, 0);
            this.FDLV_RevisionsList.MultiSelect = false;
            this.FDLV_RevisionsList.Name = "FDLV_RevisionsList";
            this.FDLV_RevisionsList.ShowGroups = false;
            this.FDLV_RevisionsList.Size = new System.Drawing.Size(1000, 429);
            this.FDLV_RevisionsList.TabIndex = 1;
            this.FDLV_RevisionsList.UseAlternatingBackColors = true;
            this.FDLV_RevisionsList.UseCompatibleStateImageBehavior = false;
            this.FDLV_RevisionsList.View = System.Windows.Forms.View.Details;
            this.FDLV_RevisionsList.VirtualMode = true;
            this.FDLV_RevisionsList.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.FDLV_RevisionsList_CellRightClick);
            this.FDLV_RevisionsList.SelectedIndexChanged += new System.EventHandler(this.FDLV_RevisionsList_SelectionChanged);
            this.FDLV_RevisionsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.StartRevisionEdit);
            // 
            // FDLV_Revision_ID
            // 
            this.FDLV_Revision_ID.AspectName = "RevisionID";
            this.FDLV_Revision_ID.Text = "ID";
            this.FDLV_Revision_ID.Width = 200;
            // 
            // FDLV_Importance_level
            // 
            this.FDLV_Importance_level.Text = "Importance level";
            this.FDLV_Importance_level.Width = 125;
            // 
            // FDLV_Revision_SolvedStatus
            // 
            this.FDLV_Revision_SolvedStatus.AspectName = "SolvedStatus";
            this.FDLV_Revision_SolvedStatus.FillsFreeSpace = true;
            this.FDLV_Revision_SolvedStatus.Text = "Solved";
            this.FDLV_Revision_SolvedStatus.Width = 120;
            // 
            // textBoxComent
            // 
            this.textBoxComent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxComent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxComent.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxComent.Location = new System.Drawing.Point(0, 0);
            this.textBoxComent.Multiline = true;
            this.textBoxComent.Name = "textBoxComent";
            this.textBoxComent.ReadOnly = true;
            this.textBoxComent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxComent.Size = new System.Drawing.Size(536, 429);
            this.textBoxComent.TabIndex = 15;
            // 
            // DLV_ItemsList
            // 
            this.DLV_ItemsList.AllColumns.Add(this.DLV_Items_PartName);
            this.DLV_ItemsList.AllColumns.Add(this.DLV_Items_RevisionSolved);
            this.DLV_ItemsList.AllColumns.Add(this.DLV_Items_Level);
            this.DLV_ItemsList.BackColor = System.Drawing.Color.AntiqueWhite;
            this.DLV_ItemsList.CellEditUseWholeCell = false;
            this.DLV_ItemsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DLV_Items_PartName,
            this.DLV_Items_RevisionSolved,
            this.DLV_Items_Level});
            this.DLV_ItemsList.Cursor = System.Windows.Forms.Cursors.Default;
            this.DLV_ItemsList.DataSource = null;
            this.DLV_ItemsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DLV_ItemsList.FullRowSelect = true;
            this.DLV_ItemsList.HideSelection = false;
            this.DLV_ItemsList.Location = new System.Drawing.Point(0, 0);
            this.DLV_ItemsList.Name = "DLV_ItemsList";
            this.DLV_ItemsList.Size = new System.Drawing.Size(1540, 385);
            this.DLV_ItemsList.TabIndex = 2;
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
            this.DLV_Items_Level.FillsFreeSpace = true;
            this.DLV_Items_Level.Text = "Level";
            this.DLV_Items_Level.Width = 120;
            // 
            // TabRevisionLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer_Main);
            this.Name = "TabRevisionLibrary";
            this.Size = new System.Drawing.Size(1540, 818);
            this.Load += new System.EventHandler(this.TabRevisionLibrary_Load);
            this.contextMenu_RightClick.ResumeLayout(false);
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            this.splitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
            this.splitContainer_Main.ResumeLayout(false);
            this.splitContainer_Upper.Panel1.ResumeLayout(false);
            this.splitContainer_Upper.Panel2.ResumeLayout(false);
            this.splitContainer_Upper.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Upper)).EndInit();
            this.splitContainer_Upper.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FDLV_RevisionsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DLV_ItemsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenu_RightClick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Delete;
        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.SplitContainer splitContainer_Upper;
        private BrightIdeasSoftware.FastDataListView FDLV_RevisionsList;
        private BrightIdeasSoftware.OLVColumn FDLV_Revision_ID;
        private BrightIdeasSoftware.OLVColumn FDLV_Importance_level;
        private BrightIdeasSoftware.OLVColumn FDLV_Revision_SolvedStatus;
        private System.Windows.Forms.TextBox textBoxComent;
        private BrightIdeasSoftware.DataListView DLV_ItemsList;
        private BrightIdeasSoftware.OLVColumn DLV_Items_PartName;
        private BrightIdeasSoftware.OLVColumn DLV_Items_RevisionSolved;
        private BrightIdeasSoftware.OLVColumn DLV_Items_Level;
    }
}
