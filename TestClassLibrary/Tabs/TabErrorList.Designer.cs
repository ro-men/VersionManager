
namespace VerManagerLibrary
{
    partial class TabErrorList
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
            this.treeListView2 = new BrightIdeasSoftware.TreeListView();
            this.clmn_ErrorID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clmn_apointedTO = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.treeListView2)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListView2
            // 
            this.treeListView2.AllColumns.Add(this.clmn_ErrorID);
            this.treeListView2.AllColumns.Add(this.clmn_apointedTO);
            this.treeListView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView2.CellEditUseWholeCell = false;
            this.treeListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmn_ErrorID,
            this.clmn_apointedTO});
            this.treeListView2.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListView2.GridLines = true;
            this.treeListView2.HideSelection = false;
            this.treeListView2.Location = new System.Drawing.Point(3, 3);
            this.treeListView2.Name = "treeListView2";
            this.treeListView2.ShowGroups = false;
            this.treeListView2.Size = new System.Drawing.Size(979, 487);
            this.treeListView2.TabIndex = 2;
            this.treeListView2.UseCompatibleStateImageBehavior = false;
            this.treeListView2.View = System.Windows.Forms.View.Details;
            this.treeListView2.VirtualMode = true;
            // 
            // clmn_ErrorID
            // 
            this.clmn_ErrorID.Text = "ErrorID";
            this.clmn_ErrorID.Width = 100;
            // 
            // clmn_apointedTO
            // 
            this.clmn_apointedTO.Text = "ApointedTO";
            this.clmn_apointedTO.Width = 400;
            // 
            // TabErrorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListView2);
            this.Name = "TabErrorList";
            this.Size = new System.Drawing.Size(985, 596);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.TreeListView treeListView2;
        private BrightIdeasSoftware.OLVColumn clmn_ErrorID;
        private BrightIdeasSoftware.OLVColumn clmn_apointedTO;
    }
}
