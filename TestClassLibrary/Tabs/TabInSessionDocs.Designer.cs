
namespace VerManagerLibrary_ClassLib
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabInSessionDocs));
            this.button_NewRevision = new System.Windows.Forms.Button();
            this.treeListView_Stablo = new BrightIdeasSoftware.TreeListView();
            this.clmn_Stablo_PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Stablo_FullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Stablo_Nomenclature = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Stablo_Status = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Stablo_Modified = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.checkBox_DisplayAsList = new System.Windows.Forms.CheckBox();
            this.OLV_InSessionLista = new BrightIdeasSoftware.ObjectListView();
            this.clmn_Lista_PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Lista_FullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Lista_Nomenclature = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Lista_Status = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Lista_Modified = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList_group = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip_MissingDataBaseInput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Register_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_New = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StoreInVML_Library = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPartNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clmn_RevisionID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmn_Comment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_Comment = new System.Windows.Forms.ListView();
            this.clmn_ImportanceLevel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.treeListView_Stablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OLV_InSessionLista)).BeginInit();
            this.contextMenuStrip_MissingDataBaseInput.SuspendLayout();
            this.contextMenuStrip_New.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_NewRevision
            // 
            this.button_NewRevision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_NewRevision.Location = new System.Drawing.Point(7, 654);
            this.button_NewRevision.Name = "button_NewRevision";
            this.button_NewRevision.Size = new System.Drawing.Size(131, 42);
            this.button_NewRevision.TabIndex = 6;
            this.button_NewRevision.Text = "NewRevision";
            this.button_NewRevision.UseVisualStyleBackColor = true;
            this.button_NewRevision.Click += new System.EventHandler(this.button_NewRevision_Click);
            // 
            // treeListView_Stablo
            // 
            this.treeListView_Stablo.AllColumns.Add(this.clmn_Stablo_PartName);
            this.treeListView_Stablo.AllColumns.Add(this.clmn_Stablo_FullName);
            this.treeListView_Stablo.AllColumns.Add(this.clmn_Stablo_Nomenclature);
            this.treeListView_Stablo.AllColumns.Add(this.clmn_Stablo_Status);
            this.treeListView_Stablo.AllColumns.Add(this.clmn_Stablo_Modified);
            this.treeListView_Stablo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView_Stablo.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.treeListView_Stablo.CellEditUseWholeCell = false;
            this.treeListView_Stablo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmn_Stablo_PartName,
            this.clmn_Stablo_FullName,
            this.clmn_Stablo_Nomenclature,
            this.clmn_Stablo_Status,
            this.clmn_Stablo_Modified});
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
            this.treeListView_Stablo.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.List_CellEditStarting);
            this.treeListView_Stablo.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.treeListView_Stablo_FormatRow);
            this.treeListView_Stablo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.InSession_MouseClick);
            // 
            // clmn_Stablo_PartName
            // 
            this.clmn_Stablo_PartName.AspectName = "PartName";
            this.clmn_Stablo_PartName.IsEditable = false;
            this.clmn_Stablo_PartName.Text = "PartName";
            this.clmn_Stablo_PartName.Width = 200;
            // 
            // clmn_Stablo_FullName
            // 
            this.clmn_Stablo_FullName.AspectName = "Key";
            this.clmn_Stablo_FullName.IsEditable = false;
            this.clmn_Stablo_FullName.Text = "FullName";
            this.clmn_Stablo_FullName.Width = 200;
            // 
            // clmn_Stablo_Nomenclature
            // 
            this.clmn_Stablo_Nomenclature.AspectName = "NewNomenclature";
            this.clmn_Stablo_Nomenclature.Text = "Nomenclature";
            this.clmn_Stablo_Nomenclature.Width = 150;
            // 
            // clmn_Stablo_Status
            // 
            this.clmn_Stablo_Status.AspectName = "Status";
            this.clmn_Stablo_Status.IsEditable = false;
            this.clmn_Stablo_Status.Text = "Status";
            this.clmn_Stablo_Status.Width = 150;
            // 
            // clmn_Stablo_Modified
            // 
            this.clmn_Stablo_Modified.Text = "Modified";
            this.clmn_Stablo_Modified.Width = 120;
            // 
            // checkBox_DisplayAsList
            // 
            this.checkBox_DisplayAsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_DisplayAsList.AutoSize = true;
            this.checkBox_DisplayAsList.Location = new System.Drawing.Point(7, 517);
            this.checkBox_DisplayAsList.Name = "checkBox_DisplayAsList";
            this.checkBox_DisplayAsList.Size = new System.Drawing.Size(89, 17);
            this.checkBox_DisplayAsList.TabIndex = 11;
            this.checkBox_DisplayAsList.Text = "Display as list";
            this.checkBox_DisplayAsList.UseVisualStyleBackColor = true;
            this.checkBox_DisplayAsList.CheckedChanged += new System.EventHandler(this.checkBox_DisplayAsList_CheckedChanged);
            // 
            // OLV_InSessionLista
            // 
            this.OLV_InSessionLista.AllColumns.Add(this.clmn_Lista_PartName);
            this.OLV_InSessionLista.AllColumns.Add(this.clmn_Lista_FullName);
            this.OLV_InSessionLista.AllColumns.Add(this.clmn_Lista_Nomenclature);
            this.OLV_InSessionLista.AllColumns.Add(this.clmn_Lista_Status);
            this.OLV_InSessionLista.AllColumns.Add(this.clmn_Lista_Modified);
            this.OLV_InSessionLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OLV_InSessionLista.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.OLV_InSessionLista.CellEditUseWholeCell = false;
            this.OLV_InSessionLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmn_Lista_PartName,
            this.clmn_Lista_FullName,
            this.clmn_Lista_Nomenclature,
            this.clmn_Lista_Status,
            this.clmn_Lista_Modified});
            this.OLV_InSessionLista.Cursor = System.Windows.Forms.Cursors.Default;
            this.OLV_InSessionLista.FullRowSelect = true;
            this.OLV_InSessionLista.GridLines = true;
            this.OLV_InSessionLista.GroupImageList = this.imageList_group;
            this.OLV_InSessionLista.HideSelection = false;
            this.OLV_InSessionLista.Location = new System.Drawing.Point(3, 3);
            this.OLV_InSessionLista.Name = "OLV_InSessionLista";
            this.OLV_InSessionLista.Size = new System.Drawing.Size(1291, 503);
            this.OLV_InSessionLista.TabIndex = 12;
            this.OLV_InSessionLista.UseCompatibleStateImageBehavior = false;
            this.OLV_InSessionLista.View = System.Windows.Forms.View.Details;
            this.OLV_InSessionLista.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.List_CellEditStarting);
            this.OLV_InSessionLista.MouseClick += new System.Windows.Forms.MouseEventHandler(this.InSession_MouseClick);
            // 
            // clmn_Lista_PartName
            // 
            this.clmn_Lista_PartName.AspectName = "PartName";
            this.clmn_Lista_PartName.Groupable = false;
            this.clmn_Lista_PartName.IsEditable = false;
            this.clmn_Lista_PartName.Text = "PartName";
            this.clmn_Lista_PartName.Width = 200;
            // 
            // clmn_Lista_FullName
            // 
            this.clmn_Lista_FullName.AspectName = "Key";
            this.clmn_Lista_FullName.Groupable = false;
            this.clmn_Lista_FullName.IsEditable = false;
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
            this.clmn_Lista_Status.IsEditable = false;
            this.clmn_Lista_Status.Text = "Status";
            this.clmn_Lista_Status.Width = 150;
            // 
            // clmn_Lista_Modified
            // 
            this.clmn_Lista_Modified.AspectName = "";
            this.clmn_Lista_Modified.Text = "Modified";
            this.clmn_Lista_Modified.Width = 120;
            // 
            // imageList_group
            // 
            this.imageList_group.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_group.ImageStream")));
            this.imageList_group.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_group.Images.SetKeyName(0, "OK_32x32.png");
            this.imageList_group.Images.SetKeyName(1, "NO_32x32.png");
            this.imageList_group.Images.SetKeyName(2, "Obsolete_50x50.png");
            this.imageList_group.Images.SetKeyName(3, "Warning_32x32.png");
            this.imageList_group.Images.SetKeyName(4, "Group_00.png");
            // 
            // contextMenuStrip_MissingDataBaseInput
            // 
            this.contextMenuStrip_MissingDataBaseInput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Register_ToolStripMenuItem,
            this.Delete_ToolStripMenuItem});
            this.contextMenuStrip_MissingDataBaseInput.Name = "contextMenuStrip_MissingDataBaseInput";
            this.contextMenuStrip_MissingDataBaseInput.Size = new System.Drawing.Size(230, 48);
            // 
            // Register_ToolStripMenuItem
            // 
            this.Register_ToolStripMenuItem.Name = "Register_ToolStripMenuItem";
            this.Register_ToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.Register_ToolStripMenuItem.Text = "Register and upload selection";
            this.Register_ToolStripMenuItem.Click += new System.EventHandler(this.StoreLastVersionToolStripMenuItem_Click);
            // 
            // Delete_ToolStripMenuItem
            // 
            this.Delete_ToolStripMenuItem.Name = "Delete_ToolStripMenuItem";
            this.Delete_ToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.Delete_ToolStripMenuItem.Text = "Delete from server";
            this.Delete_ToolStripMenuItem.Click += new System.EventHandler(this.DeleteFromServerToolStripMenuItem_Click);
            // 
            // contextMenuStrip_New
            // 
            this.contextMenuStrip_New.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StoreInVML_Library,
            this.copyPartNameToolStripMenuItem});
            this.contextMenuStrip_New.Name = "contextMenuStrip_MissingDataBaseInput";
            this.contextMenuStrip_New.Size = new System.Drawing.Size(256, 48);
            // 
            // StoreInVML_Library
            // 
            this.StoreInVML_Library.Name = "StoreInVML_Library";
            this.StoreInVML_Library.Size = new System.Drawing.Size(255, 22);
            this.StoreInVML_Library.Text = "Store in \"VML_Library\" and upload";
            this.StoreInVML_Library.Click += new System.EventHandler(this.StoreInVML_Library_Click);
            // 
            // copyPartNameToolStripMenuItem
            // 
            this.copyPartNameToolStripMenuItem.Name = "copyPartNameToolStripMenuItem";
            this.copyPartNameToolStripMenuItem.Size = new System.Drawing.Size(255, 22);
            this.copyPartNameToolStripMenuItem.Text = "Copy PartName";
            this.copyPartNameToolStripMenuItem.Click += new System.EventHandler(this.copyPartNameToolStripMenuItem_Click);
            // 
            // clmn_RevisionID
            // 
            this.clmn_RevisionID.Text = "RevisionID";
            this.clmn_RevisionID.Width = 120;
            // 
            // clmn_Comment
            // 
            this.clmn_Comment.Text = "Comment";
            this.clmn_Comment.Width = 400;
            // 
            // listView_Comment
            // 
            this.listView_Comment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Comment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmn_RevisionID,
            this.clmn_ImportanceLevel,
            this.clmn_Comment});
            this.listView_Comment.HideSelection = false;
            this.listView_Comment.Location = new System.Drawing.Point(164, 512);
            this.listView_Comment.Name = "listView_Comment";
            this.listView_Comment.Size = new System.Drawing.Size(1130, 184);
            this.listView_Comment.TabIndex = 7;
            this.listView_Comment.UseCompatibleStateImageBehavior = false;
            this.listView_Comment.View = System.Windows.Forms.View.Details;
            // 
            // clmn_ImportanceLevel
            // 
            this.clmn_ImportanceLevel.Text = "Importance level";
            this.clmn_ImportanceLevel.Width = 150;
            // 
            // TabInSessionDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_DisplayAsList);
            this.Controls.Add(this.listView_Comment);
            this.Controls.Add(this.button_NewRevision);
            this.Controls.Add(this.OLV_InSessionLista);
            this.Controls.Add(this.treeListView_Stablo);
            this.Name = "TabInSessionDocs";
            this.Size = new System.Drawing.Size(1297, 699);
            this.Load += new System.EventHandler(this.TabInSessionDocs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView_Stablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OLV_InSessionLista)).EndInit();
            this.contextMenuStrip_MissingDataBaseInput.ResumeLayout(false);
            this.contextMenuStrip_New.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.TreeListView treeListView_Stablo;
        private BrightIdeasSoftware.OLVColumn clmn_Stablo_PartName;
        private BrightIdeasSoftware.OLVColumn clmn_Stablo_FullName;
        private System.Windows.Forms.Button button_NewRevision;
        private BrightIdeasSoftware.OLVColumn clmn_Stablo_Nomenclature;
        private BrightIdeasSoftware.OLVColumn clmn_Stablo_Status;
        private System.Windows.Forms.CheckBox checkBox_DisplayAsList;
        private BrightIdeasSoftware.ObjectListView OLV_InSessionLista;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_PartName;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_FullName;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_Nomenclature;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_Status;
        private System.Windows.Forms.ImageList imageList_group;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_MissingDataBaseInput;
        private System.Windows.Forms.ToolStripMenuItem Delete_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Register_ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_New;
        private System.Windows.Forms.ToolStripMenuItem StoreInVML_Library;
        private System.Windows.Forms.ToolStripMenuItem copyPartNameToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn clmn_Stablo_Modified;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_Modified;
        private System.Windows.Forms.ColumnHeader clmn_RevisionID;
        private System.Windows.Forms.ColumnHeader clmn_Comment;
        private System.Windows.Forms.ListView listView_Comment;
        private System.Windows.Forms.ColumnHeader clmn_ImportanceLevel;
    }
}
