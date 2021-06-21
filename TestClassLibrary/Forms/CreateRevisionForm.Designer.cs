
namespace VerManagerLibrary_ClassLib
{
    partial class FormCreateRevision
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateRevision));
            this.label_RevisionID = new System.Windows.Forms.Label();
            this.textBoxRevisionID = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxSiblings = new System.Windows.Forms.GroupBox();
            this.FDLV_SelectedList = new BrightIdeasSoftware.FastDataListView();
            this.FDLV_Selected_PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Selected_FullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Selected_Nomenclature = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Selected_Resolve = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Selected_CurrentRevisionStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxLibrary = new System.Windows.Forms.GroupBox();
            this.comboBoxFilterColumn = new System.Windows.Forms.ComboBox();
            this.textBoxFilterPartName = new System.Windows.Forms.TextBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.FDLV_LibraryList = new BrightIdeasSoftware.FastDataListView();
            this.FDLV_Library_PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Library_FullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Library_Nomenclature = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Library_Resolve = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Library_CurrentRevisionStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.button_CreateRevision = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxSiblings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FDLV_SelectedList)).BeginInit();
            this.groupBoxLibrary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FDLV_LibraryList)).BeginInit();
            this.SuspendLayout();
            // 
            // label_RevisionID
            // 
            this.label_RevisionID.AutoSize = true;
            this.label_RevisionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_RevisionID.Location = new System.Drawing.Point(15, 12);
            this.label_RevisionID.Name = "label_RevisionID";
            this.label_RevisionID.Size = new System.Drawing.Size(77, 16);
            this.label_RevisionID.TabIndex = 0;
            this.label_RevisionID.Text = "RevisionID:";
            // 
            // textBoxRevisionID
            // 
            this.textBoxRevisionID.CausesValidation = false;
            this.textBoxRevisionID.Enabled = false;
            this.textBoxRevisionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxRevisionID.Location = new System.Drawing.Point(112, 9);
            this.textBoxRevisionID.Name = "textBoxRevisionID";
            this.textBoxRevisionID.Size = new System.Drawing.Size(258, 21);
            this.textBoxRevisionID.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(18, 132);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxSiblings);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxLibrary);
            this.splitContainer1.Size = new System.Drawing.Size(1121, 871);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 8;
            // 
            // groupBoxSiblings
            // 
            this.groupBoxSiblings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSiblings.Controls.Add(this.FDLV_SelectedList);
            this.groupBoxSiblings.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSiblings.Name = "groupBoxSiblings";
            this.groupBoxSiblings.Size = new System.Drawing.Size(1115, 278);
            this.groupBoxSiblings.TabIndex = 7;
            this.groupBoxSiblings.TabStop = false;
            this.groupBoxSiblings.Text = "SelectedItems";
            // 
            // FDLV_SelectedList
            // 
            this.FDLV_SelectedList.AllColumns.Add(this.FDLV_Selected_PartName);
            this.FDLV_SelectedList.AllColumns.Add(this.FDLV_Selected_FullName);
            this.FDLV_SelectedList.AllColumns.Add(this.FDLV_Selected_Nomenclature);
            this.FDLV_SelectedList.AllColumns.Add(this.FDLV_Selected_Resolve);
            this.FDLV_SelectedList.AllColumns.Add(this.FDLV_Selected_CurrentRevisionStatus);
            this.FDLV_SelectedList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FDLV_SelectedList.CellEditUseWholeCell = false;
            this.FDLV_SelectedList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FDLV_Selected_PartName,
            this.FDLV_Selected_FullName,
            this.FDLV_Selected_Nomenclature,
            this.FDLV_Selected_Resolve,
            this.FDLV_Selected_CurrentRevisionStatus});
            this.FDLV_SelectedList.Cursor = System.Windows.Forms.Cursors.Default;
            this.FDLV_SelectedList.DataSource = null;
            this.FDLV_SelectedList.HideSelection = false;
            this.FDLV_SelectedList.Location = new System.Drawing.Point(6, 37);
            this.FDLV_SelectedList.Name = "FDLV_SelectedList";
            this.FDLV_SelectedList.ShowGroups = false;
            this.FDLV_SelectedList.Size = new System.Drawing.Size(1109, 188);
            this.FDLV_SelectedList.SmallImageList = this.imageListSmall;
            this.FDLV_SelectedList.TabIndex = 5;
            this.FDLV_SelectedList.UseCompatibleStateImageBehavior = false;
            this.FDLV_SelectedList.View = System.Windows.Forms.View.Details;
            this.FDLV_SelectedList.VirtualMode = true;
            // 
            // FDLV_Selected_PartName
            // 
            this.FDLV_Selected_PartName.AspectName = "PartName";
            this.FDLV_Selected_PartName.Text = "PartName";
            this.FDLV_Selected_PartName.Width = 200;
            // 
            // FDLV_Selected_FullName
            // 
            this.FDLV_Selected_FullName.AspectName = "Key";
            this.FDLV_Selected_FullName.Text = "FullName";
            this.FDLV_Selected_FullName.Width = 400;
            // 
            // FDLV_Selected_Nomenclature
            // 
            this.FDLV_Selected_Nomenclature.Text = "Nomenclature";
            // 
            // FDLV_Selected_Resolve
            // 
            this.FDLV_Selected_Resolve.CheckBoxes = true;
            this.FDLV_Selected_Resolve.Text = "Resolve";
            // 
            // FDLV_Selected_CurrentRevisionStatus
            // 
            this.FDLV_Selected_CurrentRevisionStatus.Text = "CurrentResolveStatus";
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "solved");
            this.imageListSmall.Images.SetKeyName(1, "unsolved");
            // 
            // groupBoxLibrary
            // 
            this.groupBoxLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLibrary.Controls.Add(this.comboBoxFilterColumn);
            this.groupBoxLibrary.Controls.Add(this.textBoxFilterPartName);
            this.groupBoxLibrary.Controls.Add(this.labelFilter);
            this.groupBoxLibrary.Controls.Add(this.FDLV_LibraryList);
            this.groupBoxLibrary.Location = new System.Drawing.Point(3, 3);
            this.groupBoxLibrary.Name = "groupBoxLibrary";
            this.groupBoxLibrary.Size = new System.Drawing.Size(1115, 577);
            this.groupBoxLibrary.TabIndex = 8;
            this.groupBoxLibrary.TabStop = false;
            this.groupBoxLibrary.Text = "Library";
            // 
            // comboBoxFilterColumn
            // 
            this.comboBoxFilterColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterColumn.FormattingEnabled = true;
            this.comboBoxFilterColumn.Location = new System.Drawing.Point(11, 33);
            this.comboBoxFilterColumn.Name = "comboBoxFilterColumn";
            this.comboBoxFilterColumn.Size = new System.Drawing.Size(111, 21);
            this.comboBoxFilterColumn.TabIndex = 8;
            this.comboBoxFilterColumn.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilterColumn_SelectedIndexChanged);
            // 
            // textBoxFilterPartName
            // 
            this.textBoxFilterPartName.CausesValidation = false;
            this.textBoxFilterPartName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxFilterPartName.Location = new System.Drawing.Point(131, 34);
            this.textBoxFilterPartName.Name = "textBoxFilterPartName";
            this.textBoxFilterPartName.Size = new System.Drawing.Size(273, 21);
            this.textBoxFilterPartName.TabIndex = 7;
            this.textBoxFilterPartName.TextChanged += new System.EventHandler(this.textBoxFilterPartName_TextChanged);
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFilter.Location = new System.Drawing.Point(8, 16);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(40, 16);
            this.labelFilter.TabIndex = 6;
            this.labelFilter.Text = "Filter:";
            // 
            // FDLV_LibraryList
            // 
            this.FDLV_LibraryList.AllColumns.Add(this.FDLV_Library_PartName);
            this.FDLV_LibraryList.AllColumns.Add(this.FDLV_Library_FullName);
            this.FDLV_LibraryList.AllColumns.Add(this.FDLV_Library_Nomenclature);
            this.FDLV_LibraryList.AllColumns.Add(this.FDLV_Library_Resolve);
            this.FDLV_LibraryList.AllColumns.Add(this.FDLV_Library_CurrentRevisionStatus);
            this.FDLV_LibraryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FDLV_LibraryList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.FDLV_LibraryList.CellEditEnterChangesRows = true;
            this.FDLV_LibraryList.CellEditTabChangesRows = true;
            this.FDLV_LibraryList.CellEditUseWholeCell = false;
            this.FDLV_LibraryList.CheckBoxes = true;
            this.FDLV_LibraryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FDLV_Library_PartName,
            this.FDLV_Library_FullName,
            this.FDLV_Library_Nomenclature,
            this.FDLV_Library_Resolve,
            this.FDLV_Library_CurrentRevisionStatus});
            this.FDLV_LibraryList.Cursor = System.Windows.Forms.Cursors.Default;
            this.FDLV_LibraryList.DataSource = null;
            this.FDLV_LibraryList.FullRowSelect = true;
            this.FDLV_LibraryList.HideSelection = false;
            this.FDLV_LibraryList.Location = new System.Drawing.Point(3, 59);
            this.FDLV_LibraryList.Name = "FDLV_LibraryList";
            this.FDLV_LibraryList.ShowGroups = false;
            this.FDLV_LibraryList.ShowImagesOnSubItems = true;
            this.FDLV_LibraryList.Size = new System.Drawing.Size(1112, 459);
            this.FDLV_LibraryList.SmallImageList = this.imageListSmall;
            this.FDLV_LibraryList.StateImageList = this.imageListSmall;
            this.FDLV_LibraryList.TabIndex = 5;
            this.FDLV_LibraryList.UseAlternatingBackColors = true;
            this.FDLV_LibraryList.UseCompatibleStateImageBehavior = false;
            this.FDLV_LibraryList.UseFiltering = true;
            this.FDLV_LibraryList.UseSubItemCheckBoxes = true;
            this.FDLV_LibraryList.View = System.Windows.Forms.View.Details;
            this.FDLV_LibraryList.VirtualMode = true;
            this.FDLV_LibraryList.Resize += new System.EventHandler(this.fastDataListView_Library_Resize);
            // 
            // FDLV_Library_PartName
            // 
            this.FDLV_Library_PartName.AspectName = "PartName";
            this.FDLV_Library_PartName.Searchable = false;
            this.FDLV_Library_PartName.Text = "PartName";
            this.FDLV_Library_PartName.UseInitialLetterForGroup = true;
            this.FDLV_Library_PartName.Width = 272;
            // 
            // FDLV_Library_FullName
            // 
            this.FDLV_Library_FullName.AspectName = "Key";
            this.FDLV_Library_FullName.Searchable = false;
            this.FDLV_Library_FullName.Text = "FullName";
            this.FDLV_Library_FullName.Width = 334;
            // 
            // FDLV_Library_Nomenclature
            // 
            this.FDLV_Library_Nomenclature.AspectName = "NewNomenclature";
            this.FDLV_Library_Nomenclature.Text = "Nomenclature";
            this.FDLV_Library_Nomenclature.Width = 201;
            // 
            // FDLV_Library_Resolve
            // 
            this.FDLV_Library_Resolve.AspectName = "";
            this.FDLV_Library_Resolve.ButtonPadding = new System.Drawing.Size(10, 10);
            this.FDLV_Library_Resolve.CheckBoxes = true;
            this.FDLV_Library_Resolve.Text = "Resolve";
            this.FDLV_Library_Resolve.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FDLV_Library_Resolve.Width = 58;
            // 
            // FDLV_Library_CurrentRevisionStatus
            // 
            this.FDLV_Library_CurrentRevisionStatus.Text = "CurrentRevisionStatus";
            this.FDLV_Library_CurrentRevisionStatus.Width = 138;
            // 
            // button_CreateRevision
            // 
            this.button_CreateRevision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_CreateRevision.Location = new System.Drawing.Point(1156, 914);
            this.button_CreateRevision.Name = "button_CreateRevision";
            this.button_CreateRevision.Size = new System.Drawing.Size(124, 26);
            this.button_CreateRevision.TabIndex = 9;
            this.button_CreateRevision.Text = "CreateRevision";
            this.button_CreateRevision.UseVisualStyleBackColor = true;
            this.button_CreateRevision.Click += new System.EventHandler(this.button_CreateRevision_Click);
            // 
            // FormCreateRevision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 1015);
            this.Controls.Add(this.button_CreateRevision);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.textBoxRevisionID);
            this.Controls.Add(this.label_RevisionID);
            this.Name = "FormCreateRevision";
            this.Text = "CreateRevision";
            this.Load += new System.EventHandler(this.FormAddNewRevision_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxSiblings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FDLV_SelectedList)).EndInit();
            this.groupBoxLibrary.ResumeLayout(false);
            this.groupBoxLibrary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FDLV_LibraryList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_RevisionID;
        private System.Windows.Forms.TextBox textBoxRevisionID;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxSiblings;
        private BrightIdeasSoftware.FastDataListView FDLV_SelectedList;
        private BrightIdeasSoftware.OLVColumn FDLV_Selected_PartName;
        private BrightIdeasSoftware.OLVColumn FDLV_Selected_FullName;
        private System.Windows.Forms.GroupBox groupBoxLibrary;
        private System.Windows.Forms.TextBox textBoxFilterPartName;
        private BrightIdeasSoftware.FastDataListView FDLV_LibraryList;
        private BrightIdeasSoftware.OLVColumn FDLV_Library_PartName;
        private BrightIdeasSoftware.OLVColumn FDLV_Library_FullName;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.ComboBox comboBoxFilterColumn;
        private BrightIdeasSoftware.OLVColumn FDLV_Library_Nomenclature;
        private System.Windows.Forms.Button button_CreateRevision;
        private BrightIdeasSoftware.OLVColumn FDLV_Library_Resolve;
        private BrightIdeasSoftware.OLVColumn FDLV_Library_CurrentRevisionStatus;
        private System.Windows.Forms.ImageList imageListSmall;
        private BrightIdeasSoftware.OLVColumn FDLV_Selected_Nomenclature;
        private BrightIdeasSoftware.OLVColumn FDLV_Selected_Resolve;
        private BrightIdeasSoftware.OLVColumn FDLV_Selected_CurrentRevisionStatus;
    }
}