
namespace VerManagerLibrary
{
    partial class FormAddNewError
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxErrorID = new System.Windows.Forms.TextBox();
            this.textBoxSelectedItem = new System.Windows.Forms.TextBox();
            this.labelSelectedItem = new System.Windows.Forms.Label();
            this.groupBoxParentsNSiblings = new System.Windows.Forms.GroupBox();
            this.fastDataListView1 = new BrightIdeasSoftware.FastDataListView();
            this.PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBoxSiblings = new System.Windows.Forms.GroupBox();
            this.fastDataListView2 = new BrightIdeasSoftware.FastDataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBoxLibrary = new System.Windows.Forms.GroupBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.fastDataListView3 = new BrightIdeasSoftware.FastDataListView();
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupBoxParentsNSiblings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView1)).BeginInit();
            this.groupBoxSiblings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView2)).BeginInit();
            this.groupBoxLibrary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ErrorID:";
            // 
            // textBoxErrorID
            // 
            this.textBoxErrorID.CausesValidation = false;
            this.textBoxErrorID.Enabled = false;
            this.textBoxErrorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxErrorID.Location = new System.Drawing.Point(112, 9);
            this.textBoxErrorID.Name = "textBoxErrorID";
            this.textBoxErrorID.Size = new System.Drawing.Size(258, 21);
            this.textBoxErrorID.TabIndex = 1;
            // 
            // textBoxSelectedItem
            // 
            this.textBoxSelectedItem.CausesValidation = false;
            this.textBoxSelectedItem.Enabled = false;
            this.textBoxSelectedItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxSelectedItem.Location = new System.Drawing.Point(112, 40);
            this.textBoxSelectedItem.Name = "textBoxSelectedItem";
            this.textBoxSelectedItem.Size = new System.Drawing.Size(1140, 21);
            this.textBoxSelectedItem.TabIndex = 3;
            // 
            // labelSelectedItem
            // 
            this.labelSelectedItem.AutoSize = true;
            this.labelSelectedItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelectedItem.Location = new System.Drawing.Point(15, 44);
            this.labelSelectedItem.Name = "labelSelectedItem";
            this.labelSelectedItem.Size = new System.Drawing.Size(90, 16);
            this.labelSelectedItem.TabIndex = 2;
            this.labelSelectedItem.Text = "SelectedItem:";
            // 
            // groupBoxParentsNSiblings
            // 
            this.groupBoxParentsNSiblings.Controls.Add(this.fastDataListView1);
            this.groupBoxParentsNSiblings.Location = new System.Drawing.Point(18, 74);
            this.groupBoxParentsNSiblings.Name = "groupBoxParentsNSiblings";
            this.groupBoxParentsNSiblings.Size = new System.Drawing.Size(1237, 275);
            this.groupBoxParentsNSiblings.TabIndex = 5;
            this.groupBoxParentsNSiblings.TabStop = false;
            this.groupBoxParentsNSiblings.Text = "Parents and Siblings";
            // 
            // fastDataListView1
            // 
            this.fastDataListView1.AllColumns.Add(this.PartName);
            this.fastDataListView1.AllColumns.Add(this.FullName);
            this.fastDataListView1.CellEditUseWholeCell = false;
            this.fastDataListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PartName,
            this.FullName});
            this.fastDataListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastDataListView1.DataSource = null;
            this.fastDataListView1.HideSelection = false;
            this.fastDataListView1.Location = new System.Drawing.Point(6, 37);
            this.fastDataListView1.Name = "fastDataListView1";
            this.fastDataListView1.ShowGroups = false;
            this.fastDataListView1.Size = new System.Drawing.Size(1155, 201);
            this.fastDataListView1.TabIndex = 5;
            this.fastDataListView1.UseCompatibleStateImageBehavior = false;
            this.fastDataListView1.View = System.Windows.Forms.View.Details;
            this.fastDataListView1.VirtualMode = true;
            // 
            // PartName
            // 
            this.PartName.Text = "PartName";
            this.PartName.Width = 200;
            // 
            // FullName
            // 
            this.FullName.Text = "FullName";
            this.FullName.Width = 400;
            // 
            // groupBoxSiblings
            // 
            this.groupBoxSiblings.Controls.Add(this.fastDataListView2);
            this.groupBoxSiblings.Location = new System.Drawing.Point(15, 370);
            this.groupBoxSiblings.Name = "groupBoxSiblings";
            this.groupBoxSiblings.Size = new System.Drawing.Size(1237, 275);
            this.groupBoxSiblings.TabIndex = 6;
            this.groupBoxSiblings.TabStop = false;
            this.groupBoxSiblings.Text = "Siblings";
            // 
            // fastDataListView2
            // 
            this.fastDataListView2.AllColumns.Add(this.olvColumn1);
            this.fastDataListView2.AllColumns.Add(this.olvColumn2);
            this.fastDataListView2.CellEditUseWholeCell = false;
            this.fastDataListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2});
            this.fastDataListView2.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastDataListView2.DataSource = null;
            this.fastDataListView2.HideSelection = false;
            this.fastDataListView2.Location = new System.Drawing.Point(6, 37);
            this.fastDataListView2.Name = "fastDataListView2";
            this.fastDataListView2.ShowGroups = false;
            this.fastDataListView2.Size = new System.Drawing.Size(1155, 201);
            this.fastDataListView2.TabIndex = 5;
            this.fastDataListView2.UseCompatibleStateImageBehavior = false;
            this.fastDataListView2.View = System.Windows.Forms.View.Details;
            this.fastDataListView2.VirtualMode = true;
            // 
            // olvColumn1
            // 
            this.olvColumn1.Text = "PartName";
            this.olvColumn1.Width = 200;
            // 
            // olvColumn2
            // 
            this.olvColumn2.Text = "FullName";
            this.olvColumn2.Width = 400;
            // 
            // groupBoxLibrary
            // 
            this.groupBoxLibrary.Controls.Add(this.textBoxFilter);
            this.groupBoxLibrary.Controls.Add(this.labelFilter);
            this.groupBoxLibrary.Controls.Add(this.fastDataListView3);
            this.groupBoxLibrary.Location = new System.Drawing.Point(18, 675);
            this.groupBoxLibrary.Name = "groupBoxLibrary";
            this.groupBoxLibrary.Size = new System.Drawing.Size(1237, 275);
            this.groupBoxLibrary.TabIndex = 7;
            this.groupBoxLibrary.TabStop = false;
            this.groupBoxLibrary.Text = "Library";
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.CausesValidation = false;
            this.textBoxFilter.Enabled = false;
            this.textBoxFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxFilter.Location = new System.Drawing.Point(67, 32);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(185, 21);
            this.textBoxFilter.TabIndex = 7;
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFilter.Location = new System.Drawing.Point(8, 36);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(40, 16);
            this.labelFilter.TabIndex = 6;
            this.labelFilter.Text = "Filter:";
            // 
            // fastDataListView3
            // 
            this.fastDataListView3.AllColumns.Add(this.olvColumn3);
            this.fastDataListView3.AllColumns.Add(this.olvColumn4);
            this.fastDataListView3.CellEditUseWholeCell = false;
            this.fastDataListView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn3,
            this.olvColumn4});
            this.fastDataListView3.Cursor = System.Windows.Forms.Cursors.Default;
            this.fastDataListView3.DataSource = null;
            this.fastDataListView3.HideSelection = false;
            this.fastDataListView3.Location = new System.Drawing.Point(3, 59);
            this.fastDataListView3.Name = "fastDataListView3";
            this.fastDataListView3.ShowGroups = false;
            this.fastDataListView3.Size = new System.Drawing.Size(1155, 201);
            this.fastDataListView3.TabIndex = 5;
            this.fastDataListView3.UseCompatibleStateImageBehavior = false;
            this.fastDataListView3.View = System.Windows.Forms.View.Details;
            this.fastDataListView3.VirtualMode = true;
            // 
            // olvColumn3
            // 
            this.olvColumn3.Text = "PartName";
            this.olvColumn3.Width = 200;
            // 
            // olvColumn4
            // 
            this.olvColumn4.Text = "FullName";
            this.olvColumn4.Width = 400;
            // 
            // FormAddNewError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 1015);
            this.Controls.Add(this.groupBoxLibrary);
            this.Controls.Add(this.groupBoxSiblings);
            this.Controls.Add(this.groupBoxParentsNSiblings);
            this.Controls.Add(this.textBoxSelectedItem);
            this.Controls.Add(this.labelSelectedItem);
            this.Controls.Add(this.textBoxErrorID);
            this.Controls.Add(this.label1);
            this.Name = "FormAddNewError";
            this.Text = "AddNewError";
            this.Load += new System.EventHandler(this.FormAddNewError_Load);
            this.groupBoxParentsNSiblings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView1)).EndInit();
            this.groupBoxSiblings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView2)).EndInit();
            this.groupBoxLibrary.ResumeLayout(false);
            this.groupBoxLibrary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxErrorID;
        private System.Windows.Forms.TextBox textBoxSelectedItem;
        private System.Windows.Forms.Label labelSelectedItem;
        private System.Windows.Forms.GroupBox groupBoxParentsNSiblings;
        private BrightIdeasSoftware.FastDataListView fastDataListView1;
        private BrightIdeasSoftware.OLVColumn PartName;
        private BrightIdeasSoftware.OLVColumn FullName;
        private System.Windows.Forms.GroupBox groupBoxSiblings;
        private BrightIdeasSoftware.FastDataListView fastDataListView2;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private System.Windows.Forms.GroupBox groupBoxLibrary;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label labelFilter;
        private BrightIdeasSoftware.FastDataListView fastDataListView3;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
    }
}