
namespace VerManagerLibrary_ClassLib
{
    partial class TabStoredLibrary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabStoredLibrary));
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.button_UpdateLibrary = new System.Windows.Forms.Button();
            this.checkBox_DisplayAsList = new System.Windows.Forms.CheckBox();
            this.panel_DataOutput = new System.Windows.Forms.Panel();
            this.treeListView_Stablo = new BrightIdeasSoftware.TreeListView();
            this.clmn_PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_FullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Status = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FOLV_LibraryLista = new BrightIdeasSoftware.FastObjectListView();
            this.clmn_Lista_PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Lista_FullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Lista_Nomenclature = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_Lista_Status = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip_MissingServerFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openAndContinueInSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.continueInSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFromVMLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_MissingDataBaseInput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Register_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_DataOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView_Stablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FOLV_LibraryLista)).BeginInit();
            this.contextMenuStrip_MissingServerFile.SuspendLayout();
            this.contextMenuStrip_MissingDataBaseInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "OK.png");
            this.imageListSmall.Images.SetKeyName(1, "FALSE.png");
            this.imageListSmall.Images.SetKeyName(2, "Warning.png");
            // 
            // button_UpdateLibrary
            // 
            this.button_UpdateLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_UpdateLibrary.Location = new System.Drawing.Point(9, 694);
            this.button_UpdateLibrary.Name = "button_UpdateLibrary";
            this.button_UpdateLibrary.Size = new System.Drawing.Size(139, 44);
            this.button_UpdateLibrary.TabIndex = 1;
            this.button_UpdateLibrary.Text = "UpdateLibrary";
            this.button_UpdateLibrary.UseVisualStyleBackColor = true;
            // 
            // checkBox_DisplayAsList
            // 
            this.checkBox_DisplayAsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_DisplayAsList.AutoSize = true;
            this.checkBox_DisplayAsList.Location = new System.Drawing.Point(3, 667);
            this.checkBox_DisplayAsList.Name = "checkBox_DisplayAsList";
            this.checkBox_DisplayAsList.Size = new System.Drawing.Size(89, 17);
            this.checkBox_DisplayAsList.TabIndex = 12;
            this.checkBox_DisplayAsList.Text = "Display as list";
            this.checkBox_DisplayAsList.UseVisualStyleBackColor = true;
            this.checkBox_DisplayAsList.CheckedChanged += new System.EventHandler(this.checkBox_DisplayAsList_CheckedChanged);
            // 
            // panel_DataOutput
            // 
            this.panel_DataOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_DataOutput.Controls.Add(this.treeListView_Stablo);
            this.panel_DataOutput.Controls.Add(this.FOLV_LibraryLista);
            this.panel_DataOutput.Location = new System.Drawing.Point(3, 3);
            this.panel_DataOutput.Name = "panel_DataOutput";
            this.panel_DataOutput.Size = new System.Drawing.Size(1533, 640);
            this.panel_DataOutput.TabIndex = 13;
            // 
            // treeListView_Stablo
            // 
            this.treeListView_Stablo.AllColumns.Add(this.clmn_PartName);
            this.treeListView_Stablo.AllColumns.Add(this.clmn_FullName);
            this.treeListView_Stablo.AllColumns.Add(this.clmn_Status);
            this.treeListView_Stablo.AlternateRowBackColor = System.Drawing.Color.FloralWhite;
            this.treeListView_Stablo.CellEditUseWholeCell = false;
            this.treeListView_Stablo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmn_PartName,
            this.clmn_FullName,
            this.clmn_Status});
            this.treeListView_Stablo.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListView_Stablo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView_Stablo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.treeListView_Stablo.FullRowSelect = true;
            this.treeListView_Stablo.GridLines = true;
            this.treeListView_Stablo.HideSelection = false;
            this.treeListView_Stablo.Location = new System.Drawing.Point(0, 0);
            this.treeListView_Stablo.Name = "treeListView_Stablo";
            this.treeListView_Stablo.ShowGroups = false;
            this.treeListView_Stablo.Size = new System.Drawing.Size(1533, 640);
            this.treeListView_Stablo.SmallImageList = this.imageListSmall;
            this.treeListView_Stablo.TabIndex = 1;
            this.treeListView_Stablo.UseAlternatingBackColors = true;
            this.treeListView_Stablo.UseCompatibleStateImageBehavior = false;
            this.treeListView_Stablo.View = System.Windows.Forms.View.Details;
            this.treeListView_Stablo.VirtualMode = true;
            this.treeListView_Stablo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Library_MouseClick);
            // 
            // clmn_PartName
            // 
            this.clmn_PartName.AspectName = "PartName";
            this.clmn_PartName.Text = "PartName";
            this.clmn_PartName.Width = 200;
            // 
            // clmn_FullName
            // 
            this.clmn_FullName.AspectName = "Key";
            this.clmn_FullName.Text = "FullName";
            this.clmn_FullName.Width = 200;
            // 
            // clmn_Status
            // 
            this.clmn_Status.AspectName = "Status";
            this.clmn_Status.Text = "Status";
            this.clmn_Status.ToolTipText = "Right click on StatusType for available options";
            this.clmn_Status.Width = 120;
            // 
            // FOLV_LibraryLista
            // 
            this.FOLV_LibraryLista.AllColumns.Add(this.clmn_Lista_PartName);
            this.FOLV_LibraryLista.AllColumns.Add(this.clmn_Lista_FullName);
            this.FOLV_LibraryLista.AllColumns.Add(this.clmn_Lista_Nomenclature);
            this.FOLV_LibraryLista.AllColumns.Add(this.clmn_Lista_Status);
            this.FOLV_LibraryLista.CellEditUseWholeCell = false;
            this.FOLV_LibraryLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmn_Lista_PartName,
            this.clmn_Lista_FullName,
            this.clmn_Lista_Nomenclature,
            this.clmn_Lista_Status});
            this.FOLV_LibraryLista.Cursor = System.Windows.Forms.Cursors.Default;
            this.FOLV_LibraryLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FOLV_LibraryLista.FullRowSelect = true;
            this.FOLV_LibraryLista.HideSelection = false;
            this.FOLV_LibraryLista.Location = new System.Drawing.Point(0, 0);
            this.FOLV_LibraryLista.Name = "FOLV_LibraryLista";
            this.FOLV_LibraryLista.ShowGroups = false;
            this.FOLV_LibraryLista.Size = new System.Drawing.Size(1533, 640);
            this.FOLV_LibraryLista.TabIndex = 4;
            this.FOLV_LibraryLista.UseCompatibleStateImageBehavior = false;
            this.FOLV_LibraryLista.View = System.Windows.Forms.View.Details;
            this.FOLV_LibraryLista.VirtualMode = true;
            this.FOLV_LibraryLista.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Library_MouseClick);
            // 
            // clmn_Lista_PartName
            // 
            this.clmn_Lista_PartName.AspectName = "PartName";
            this.clmn_Lista_PartName.Text = "PartName";
            this.clmn_Lista_PartName.Width = 200;
            // 
            // clmn_Lista_FullName
            // 
            this.clmn_Lista_FullName.AspectName = "Key";
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
            this.clmn_Lista_Status.Text = "Lista_Status";
            this.clmn_Lista_Status.Width = 150;
            // 
            // contextMenuStrip_MissingServerFile
            // 
            this.contextMenuStrip_MissingServerFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAndContinueInSessionToolStripMenuItem,
            this.continueInSessionToolStripMenuItem,
            this.deleteFromVMLibraryToolStripMenuItem});
            this.contextMenuStrip_MissingServerFile.Name = "contextMenuStrip1";
            this.contextMenuStrip_MissingServerFile.Size = new System.Drawing.Size(279, 70);
            // 
            // openAndContinueInSessionToolStripMenuItem
            // 
            this.openAndContinueInSessionToolStripMenuItem.Name = "openAndContinueInSessionToolStripMenuItem";
            this.openAndContinueInSessionToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.openAndContinueInSessionToolStripMenuItem.Text = "Open and continue upload \"InSession\"";
            this.openAndContinueInSessionToolStripMenuItem.Click += new System.EventHandler(this.openAndContinueInSessionToolStripMenuItem_Click);
            // 
            // continueInSessionToolStripMenuItem
            // 
            this.continueInSessionToolStripMenuItem.Name = "continueInSessionToolStripMenuItem";
            this.continueInSessionToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.continueInSessionToolStripMenuItem.Text = "Continue upload \"InSession\"";
            this.continueInSessionToolStripMenuItem.Click += new System.EventHandler(this.continueInSessionToolStripMenuItem_Click);
            // 
            // deleteFromVMLibraryToolStripMenuItem
            // 
            this.deleteFromVMLibraryToolStripMenuItem.Name = "deleteFromVMLibraryToolStripMenuItem";
            this.deleteFromVMLibraryToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.deleteFromVMLibraryToolStripMenuItem.Text = "Delete from VM_Library";
            this.deleteFromVMLibraryToolStripMenuItem.Click += new System.EventHandler(this.deleteFromVMLibraryToolStripMenuItem_Click);
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
            this.Register_ToolStripMenuItem.Click += new System.EventHandler(this.Register_ToolStripMenuItem_Click);
            // 
            // Delete_ToolStripMenuItem
            // 
            this.Delete_ToolStripMenuItem.Name = "Delete_ToolStripMenuItem";
            this.Delete_ToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.Delete_ToolStripMenuItem.Text = "Delete from server";
            // 
            // TabStoredLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_DataOutput);
            this.Controls.Add(this.checkBox_DisplayAsList);
            this.Controls.Add(this.button_UpdateLibrary);
            this.Name = "TabStoredLibrary";
            this.Size = new System.Drawing.Size(1539, 768);
            this.Load += new System.EventHandler(this.TabStoredLibrary_Load);
            this.Enter += new System.EventHandler(this.TabStoredLibrary_Enter);
            this.panel_DataOutput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView_Stablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FOLV_LibraryLista)).EndInit();
            this.contextMenuStrip_MissingServerFile.ResumeLayout(false);
            this.contextMenuStrip_MissingDataBaseInput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_UpdateLibrary;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.CheckBox checkBox_DisplayAsList;
        private System.Windows.Forms.Panel panel_DataOutput;
        private BrightIdeasSoftware.TreeListView treeListView_Stablo;
        private BrightIdeasSoftware.OLVColumn clmn_PartName;
        private BrightIdeasSoftware.OLVColumn clmn_FullName;
        private BrightIdeasSoftware.OLVColumn clmn_Status;
        private BrightIdeasSoftware.FastObjectListView FOLV_LibraryLista;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_PartName;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_FullName;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_Nomenclature;
        private BrightIdeasSoftware.OLVColumn clmn_Lista_Status;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_MissingServerFile;
        private System.Windows.Forms.ToolStripMenuItem openAndContinueInSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem continueInSessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFromVMLibraryToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_MissingDataBaseInput;
        private System.Windows.Forms.ToolStripMenuItem Register_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Delete_ToolStripMenuItem;
    }
}
