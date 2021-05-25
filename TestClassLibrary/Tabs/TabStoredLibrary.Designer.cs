
namespace VerManagerLibrary
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
            this.treeListView_Stablo = new BrightIdeasSoftware.TreeListView();
            this.clmn_PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_FullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.button_UpdateLibrary = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView_Stablo)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListView_Stablo
            // 
            this.treeListView_Stablo.AllColumns.Add(this.clmn_PartName);
            this.treeListView_Stablo.AllColumns.Add(this.clmn_FullName);
            this.treeListView_Stablo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView_Stablo.CellEditUseWholeCell = false;
            this.treeListView_Stablo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmn_PartName,
            this.clmn_FullName});
            this.treeListView_Stablo.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListView_Stablo.GridLines = true;
            this.treeListView_Stablo.HideSelection = false;
            this.treeListView_Stablo.Location = new System.Drawing.Point(3, 3);
            this.treeListView_Stablo.Name = "treeListView_Stablo";
            this.treeListView_Stablo.ShowGroups = false;
            this.treeListView_Stablo.Size = new System.Drawing.Size(1533, 658);
            this.treeListView_Stablo.TabIndex = 0;
            this.treeListView_Stablo.UseCompatibleStateImageBehavior = false;
            this.treeListView_Stablo.View = System.Windows.Forms.View.Details;
            this.treeListView_Stablo.VirtualMode = true;
            // 
            // clmn_PartName
            // 
            this.clmn_PartName.AspectName = "PartName";
            this.clmn_PartName.Text = "PartName";
            this.clmn_PartName.Width = 200;
            // 
            // clmn_FullName
            // 
            this.clmn_FullName.AspectName = "FullName";
            this.clmn_FullName.Text = "FullName";
            this.clmn_FullName.Width = 200;
            // 
            // button_UpdateLibrary
            // 
            this.button_UpdateLibrary.Location = new System.Drawing.Point(9, 694);
            this.button_UpdateLibrary.Name = "button_UpdateLibrary";
            this.button_UpdateLibrary.Size = new System.Drawing.Size(139, 44);
            this.button_UpdateLibrary.TabIndex = 1;
            this.button_UpdateLibrary.Text = "UpdateLibrary";
            this.button_UpdateLibrary.UseVisualStyleBackColor = true;
            this.button_UpdateLibrary.Click += new System.EventHandler(this.button_UpdateLibrary_Click);
            // 
            // TabStoredLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_UpdateLibrary);
            this.Controls.Add(this.treeListView_Stablo);
            this.Name = "TabStoredLibrary";
            this.Size = new System.Drawing.Size(1539, 768);
            this.Load += new System.EventHandler(this.TabStoredLibrary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView_Stablo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.TreeListView treeListView_Stablo;
        private BrightIdeasSoftware.OLVColumn clmn_PartName;
        private BrightIdeasSoftware.OLVColumn clmn_FullName;
        private System.Windows.Forms.Button button_UpdateLibrary;
    }
}
