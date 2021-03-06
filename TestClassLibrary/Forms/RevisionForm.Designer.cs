
namespace VerManagerLibrary_ClassLib
{
    partial class RevisionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RevisionForm));
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer_Glavni = new System.Windows.Forms.SplitContainer();
            this.splitContainer_Display = new System.Windows.Forms.SplitContainer();
            this.splitContainer_LeftSide = new System.Windows.Forms.SplitContainer();
            this.splitContainer_ID_Importance_Comment = new System.Windows.Forms.SplitContainer();
            this.splitContainer_ID_and_Importance = new System.Windows.Forms.SplitContainer();
            this.groupBox_ID = new System.Windows.Forms.GroupBox();
            this.label_RevisionID = new System.Windows.Forms.Label();
            this.textBoxRevisionID = new System.Windows.Forms.TextBox();
            this.groupBox_Importance = new System.Windows.Forms.GroupBox();
            this.comboBox_Importance = new System.Windows.Forms.ComboBox();
            this.label_Importance_level = new System.Windows.Forms.Label();
            this.groupBox_Comment = new System.Windows.Forms.GroupBox();
            this.textBoxComent = new System.Windows.Forms.TextBox();
            this.splitContainer_Liste = new System.Windows.Forms.SplitContainer();
            this.groupBoxSelected = new System.Windows.Forms.GroupBox();
            this.FDLV_SelectedList = new BrightIdeasSoftware.FastDataListView();
            this.FDLV_Selected_PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Selected_FullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Selected_Nomenclature = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Selected_Resolved = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Selected_CurrentRevisionStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Selected_SolvedVersion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FDLV_Selected_OldVersion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.FOLV_LibraryList = new BrightIdeasSoftware.FastObjectListView();
            this.FOLV_Library_PartName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FOLV_Library_FullName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FOLV_Library_Nomenclature = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FOLV_Library_Resolved = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FOLV_Library_CurrentRevisionStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FOLV_Library_SolvedVersion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FOLV_Library_OldVersion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer_FilterNQuery = new System.Windows.Forms.SplitContainer();
            this.groupBox_Filter = new System.Windows.Forms.GroupBox();
            this.comboBoxFilterColumn = new System.Windows.Forms.ComboBox();
            this.checkBox_FilterLibrary = new System.Windows.Forms.CheckBox();
            this.textBoxFilterLibraryItems = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_Mod = new System.Windows.Forms.ComboBox();
            this.comboBox_SearchAttribute = new System.Windows.Forms.ComboBox();
            this.comboBox_Operation = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer_ImageContainer = new System.Windows.Forms.SplitContainer();
            this.listView_Attachments = new System.Windows.Forms.ListView();
            this.columnHeader_AttachmentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_AttachmentPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PicturePanel = new System.Windows.Forms.Panel();
            this.pictureBox_ImageDisplay = new System.Windows.Forms.PictureBox();
            this.kwForm_Display = new VerManagerLibrary_ClassLib.KWUserControl();
            this.Button_AddKW = new System.Windows.Forms.Button();
            this.Button_AddPic = new System.Windows.Forms.Button();
            this.button_StoreRevision = new System.Windows.Forms.Button();
            this.contextMenuStrip_Images = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_SelectedItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Remove = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Glavni)).BeginInit();
            this.splitContainer_Glavni.Panel1.SuspendLayout();
            this.splitContainer_Glavni.Panel2.SuspendLayout();
            this.splitContainer_Glavni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Display)).BeginInit();
            this.splitContainer_Display.Panel1.SuspendLayout();
            this.splitContainer_Display.Panel2.SuspendLayout();
            this.splitContainer_Display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_LeftSide)).BeginInit();
            this.splitContainer_LeftSide.Panel1.SuspendLayout();
            this.splitContainer_LeftSide.Panel2.SuspendLayout();
            this.splitContainer_LeftSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_ID_Importance_Comment)).BeginInit();
            this.splitContainer_ID_Importance_Comment.Panel1.SuspendLayout();
            this.splitContainer_ID_Importance_Comment.Panel2.SuspendLayout();
            this.splitContainer_ID_Importance_Comment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_ID_and_Importance)).BeginInit();
            this.splitContainer_ID_and_Importance.Panel1.SuspendLayout();
            this.splitContainer_ID_and_Importance.Panel2.SuspendLayout();
            this.splitContainer_ID_and_Importance.SuspendLayout();
            this.groupBox_ID.SuspendLayout();
            this.groupBox_Importance.SuspendLayout();
            this.groupBox_Comment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Liste)).BeginInit();
            this.splitContainer_Liste.Panel1.SuspendLayout();
            this.splitContainer_Liste.Panel2.SuspendLayout();
            this.splitContainer_Liste.SuspendLayout();
            this.groupBoxSelected.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FDLV_SelectedList)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FOLV_LibraryList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_FilterNQuery)).BeginInit();
            this.splitContainer_FilterNQuery.Panel1.SuspendLayout();
            this.splitContainer_FilterNQuery.Panel2.SuspendLayout();
            this.splitContainer_FilterNQuery.SuspendLayout();
            this.groupBox_Filter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_ImageContainer)).BeginInit();
            this.splitContainer_ImageContainer.Panel1.SuspendLayout();
            this.splitContainer_ImageContainer.Panel2.SuspendLayout();
            this.splitContainer_ImageContainer.SuspendLayout();
            this.PicturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ImageDisplay)).BeginInit();
            this.contextMenuStrip_Images.SuspendLayout();
            this.contextMenuStrip_SelectedItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "solved_16x16.jpg");
            this.imageListSmall.Images.SetKeyName(1, "unsolved_16x16.jpg");
            // 
            // splitContainer_Glavni
            // 
            this.splitContainer_Glavni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Glavni.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer_Glavni.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Glavni.Name = "splitContainer_Glavni";
            this.splitContainer_Glavni.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Glavni.Panel1
            // 
            this.splitContainer_Glavni.Panel1.Controls.Add(this.splitContainer_Display);
            // 
            // splitContainer_Glavni.Panel2
            // 
            this.splitContainer_Glavni.Panel2.Controls.Add(this.Button_AddKW);
            this.splitContainer_Glavni.Panel2.Controls.Add(this.Button_AddPic);
            this.splitContainer_Glavni.Panel2.Controls.Add(this.button_StoreRevision);
            this.splitContainer_Glavni.Size = new System.Drawing.Size(1884, 856);
            this.splitContainer_Glavni.SplitterDistance = 742;
            this.splitContainer_Glavni.TabIndex = 12;
            // 
            // splitContainer_Display
            // 
            this.splitContainer_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Display.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Display.Name = "splitContainer_Display";
            // 
            // splitContainer_Display.Panel1
            // 
            this.splitContainer_Display.Panel1.Controls.Add(this.splitContainer_LeftSide);
            // 
            // splitContainer_Display.Panel2
            // 
            this.splitContainer_Display.Panel2.Controls.Add(this.splitContainer_ImageContainer);
            this.splitContainer_Display.Panel2MinSize = 460;
            this.splitContainer_Display.Size = new System.Drawing.Size(1884, 742);
            this.splitContainer_Display.SplitterDistance = 1291;
            this.splitContainer_Display.TabIndex = 16;
            // 
            // splitContainer_LeftSide
            // 
            this.splitContainer_LeftSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_LeftSide.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_LeftSide.Name = "splitContainer_LeftSide";
            this.splitContainer_LeftSide.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_LeftSide.Panel1
            // 
            this.splitContainer_LeftSide.Panel1.Controls.Add(this.splitContainer_ID_Importance_Comment);
            // 
            // splitContainer_LeftSide.Panel2
            // 
            this.splitContainer_LeftSide.Panel2.Controls.Add(this.splitContainer_Liste);
            this.splitContainer_LeftSide.Size = new System.Drawing.Size(1291, 742);
            this.splitContainer_LeftSide.SplitterDistance = 209;
            this.splitContainer_LeftSide.TabIndex = 18;
            // 
            // splitContainer_ID_Importance_Comment
            // 
            this.splitContainer_ID_Importance_Comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_ID_Importance_Comment.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_ID_Importance_Comment.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_ID_Importance_Comment.Name = "splitContainer_ID_Importance_Comment";
            this.splitContainer_ID_Importance_Comment.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_ID_Importance_Comment.Panel1
            // 
            this.splitContainer_ID_Importance_Comment.Panel1.Controls.Add(this.splitContainer_ID_and_Importance);
            // 
            // splitContainer_ID_Importance_Comment.Panel2
            // 
            this.splitContainer_ID_Importance_Comment.Panel2.Controls.Add(this.groupBox_Comment);
            this.splitContainer_ID_Importance_Comment.Size = new System.Drawing.Size(1291, 209);
            this.splitContainer_ID_Importance_Comment.TabIndex = 23;
            // 
            // splitContainer_ID_and_Importance
            // 
            this.splitContainer_ID_and_Importance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_ID_and_Importance.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer_ID_and_Importance.IsSplitterFixed = true;
            this.splitContainer_ID_and_Importance.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_ID_and_Importance.Name = "splitContainer_ID_and_Importance";
            // 
            // splitContainer_ID_and_Importance.Panel1
            // 
            this.splitContainer_ID_and_Importance.Panel1.Controls.Add(this.groupBox_ID);
            this.splitContainer_ID_and_Importance.Panel1MinSize = 250;
            // 
            // splitContainer_ID_and_Importance.Panel2
            // 
            this.splitContainer_ID_and_Importance.Panel2.Controls.Add(this.groupBox_Importance);
            this.splitContainer_ID_and_Importance.Panel2MinSize = 200;
            this.splitContainer_ID_and_Importance.Size = new System.Drawing.Size(1291, 50);
            this.splitContainer_ID_and_Importance.SplitterDistance = 1059;
            this.splitContainer_ID_and_Importance.SplitterWidth = 1;
            this.splitContainer_ID_and_Importance.TabIndex = 0;
            // 
            // groupBox_ID
            // 
            this.groupBox_ID.Controls.Add(this.label_RevisionID);
            this.groupBox_ID.Controls.Add(this.textBoxRevisionID);
            this.groupBox_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_ID.Location = new System.Drawing.Point(0, 0);
            this.groupBox_ID.Name = "groupBox_ID";
            this.groupBox_ID.Size = new System.Drawing.Size(1059, 50);
            this.groupBox_ID.TabIndex = 26;
            this.groupBox_ID.TabStop = false;
            // 
            // label_RevisionID
            // 
            this.label_RevisionID.AutoSize = true;
            this.label_RevisionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_RevisionID.Location = new System.Drawing.Point(15, 18);
            this.label_RevisionID.Name = "label_RevisionID";
            this.label_RevisionID.Size = new System.Drawing.Size(77, 16);
            this.label_RevisionID.TabIndex = 32;
            this.label_RevisionID.Text = "RevisionID:";
            // 
            // textBoxRevisionID
            // 
            this.textBoxRevisionID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRevisionID.CausesValidation = false;
            this.textBoxRevisionID.Enabled = false;
            this.textBoxRevisionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxRevisionID.Location = new System.Drawing.Point(98, 15);
            this.textBoxRevisionID.Name = "textBoxRevisionID";
            this.textBoxRevisionID.Size = new System.Drawing.Size(924, 21);
            this.textBoxRevisionID.TabIndex = 31;
            // 
            // groupBox_Importance
            // 
            this.groupBox_Importance.Controls.Add(this.comboBox_Importance);
            this.groupBox_Importance.Controls.Add(this.label_Importance_level);
            this.groupBox_Importance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Importance.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Importance.Name = "groupBox_Importance";
            this.groupBox_Importance.Size = new System.Drawing.Size(231, 50);
            this.groupBox_Importance.TabIndex = 27;
            this.groupBox_Importance.TabStop = false;
            // 
            // comboBox_Importance
            // 
            this.comboBox_Importance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Importance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Importance.Items.AddRange(new object[] {
            "High",
            "Medium",
            "Low"});
            this.comboBox_Importance.Location = new System.Drawing.Point(146, 15);
            this.comboBox_Importance.Name = "comboBox_Importance";
            this.comboBox_Importance.Size = new System.Drawing.Size(69, 21);
            this.comboBox_Importance.TabIndex = 34;
            // 
            // label_Importance_level
            // 
            this.label_Importance_level.AutoSize = true;
            this.label_Importance_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_Importance_level.Location = new System.Drawing.Point(10, 18);
            this.label_Importance_level.Name = "label_Importance_level";
            this.label_Importance_level.Size = new System.Drawing.Size(114, 16);
            this.label_Importance_level.TabIndex = 33;
            this.label_Importance_level.Text = "Importance_level:";
            // 
            // groupBox_Comment
            // 
            this.groupBox_Comment.Controls.Add(this.textBoxComent);
            this.groupBox_Comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Comment.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Comment.Name = "groupBox_Comment";
            this.groupBox_Comment.Size = new System.Drawing.Size(1291, 155);
            this.groupBox_Comment.TabIndex = 22;
            this.groupBox_Comment.TabStop = false;
            this.groupBox_Comment.Text = "Comment";
            // 
            // textBoxComent
            // 
            this.textBoxComent.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBoxComent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxComent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Italic);
            this.textBoxComent.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBoxComent.Location = new System.Drawing.Point(3, 16);
            this.textBoxComent.Multiline = true;
            this.textBoxComent.Name = "textBoxComent";
            this.textBoxComent.Size = new System.Drawing.Size(1285, 136);
            this.textBoxComent.TabIndex = 13;
            this.textBoxComent.Text = "Enter comment here...";
            this.textBoxComent.Enter += new System.EventHandler(this.RemoveText);
            this.textBoxComent.Leave += new System.EventHandler(this.AddText);
            // 
            // splitContainer_Liste
            // 
            this.splitContainer_Liste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Liste.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Liste.Name = "splitContainer_Liste";
            this.splitContainer_Liste.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Liste.Panel1
            // 
            this.splitContainer_Liste.Panel1.Controls.Add(this.groupBoxSelected);
            // 
            // splitContainer_Liste.Panel2
            // 
            this.splitContainer_Liste.Panel2.Controls.Add(this.panel2);
            this.splitContainer_Liste.Panel2.Controls.Add(this.splitter1);
            this.splitContainer_Liste.Panel2.Controls.Add(this.panel1);
            this.splitContainer_Liste.Size = new System.Drawing.Size(1291, 529);
            this.splitContainer_Liste.SplitterDistance = 151;
            this.splitContainer_Liste.TabIndex = 18;
            // 
            // groupBoxSelected
            // 
            this.groupBoxSelected.Controls.Add(this.FDLV_SelectedList);
            this.groupBoxSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSelected.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSelected.Name = "groupBoxSelected";
            this.groupBoxSelected.Size = new System.Drawing.Size(1291, 151);
            this.groupBoxSelected.TabIndex = 9;
            this.groupBoxSelected.TabStop = false;
            this.groupBoxSelected.Text = "SelectedItems";
            // 
            // FDLV_SelectedList
            // 
            this.FDLV_SelectedList.AllColumns.Add(this.FDLV_Selected_PartName);
            this.FDLV_SelectedList.AllColumns.Add(this.FDLV_Selected_FullName);
            this.FDLV_SelectedList.AllColumns.Add(this.FDLV_Selected_Nomenclature);
            this.FDLV_SelectedList.AllColumns.Add(this.FDLV_Selected_Resolved);
            this.FDLV_SelectedList.AllColumns.Add(this.FDLV_Selected_CurrentRevisionStatus);
            this.FDLV_SelectedList.AllColumns.Add(this.FDLV_Selected_SolvedVersion);
            this.FDLV_SelectedList.AllColumns.Add(this.FDLV_Selected_OldVersion);
            this.FDLV_SelectedList.BackColor = System.Drawing.Color.AntiqueWhite;
            this.FDLV_SelectedList.CellEditUseWholeCell = false;
            this.FDLV_SelectedList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FDLV_Selected_PartName,
            this.FDLV_Selected_FullName,
            this.FDLV_Selected_Nomenclature,
            this.FDLV_Selected_Resolved,
            this.FDLV_Selected_CurrentRevisionStatus,
            this.FDLV_Selected_SolvedVersion,
            this.FDLV_Selected_OldVersion});
            this.FDLV_SelectedList.Cursor = System.Windows.Forms.Cursors.Default;
            this.FDLV_SelectedList.DataSource = null;
            this.FDLV_SelectedList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FDLV_SelectedList.FullRowSelect = true;
            this.FDLV_SelectedList.HideSelection = false;
            this.FDLV_SelectedList.Location = new System.Drawing.Point(3, 16);
            this.FDLV_SelectedList.Name = "FDLV_SelectedList";
            this.FDLV_SelectedList.ShowGroups = false;
            this.FDLV_SelectedList.Size = new System.Drawing.Size(1285, 132);
            this.FDLV_SelectedList.SmallImageList = this.imageListSmall;
            this.FDLV_SelectedList.TabIndex = 5;
            this.FDLV_SelectedList.UseCompatibleStateImageBehavior = false;
            this.FDLV_SelectedList.View = System.Windows.Forms.View.Details;
            this.FDLV_SelectedList.VirtualMode = true;
            this.FDLV_SelectedList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FDLV_SelectedList_MouseClick);
            // 
            // FDLV_Selected_PartName
            // 
            this.FDLV_Selected_PartName.AspectName = "";
            this.FDLV_Selected_PartName.Text = "PartName";
            this.FDLV_Selected_PartName.Width = 200;
            // 
            // FDLV_Selected_FullName
            // 
            this.FDLV_Selected_FullName.AspectName = "";
            this.FDLV_Selected_FullName.Text = "Path";
            this.FDLV_Selected_FullName.Width = 400;
            // 
            // FDLV_Selected_Nomenclature
            // 
            this.FDLV_Selected_Nomenclature.AspectName = "";
            this.FDLV_Selected_Nomenclature.Text = "Nomenclature";
            this.FDLV_Selected_Nomenclature.Width = 91;
            // 
            // FDLV_Selected_Resolved
            // 
            this.FDLV_Selected_Resolved.CheckBoxes = true;
            this.FDLV_Selected_Resolved.Text = "Resolved";
            this.FDLV_Selected_Resolved.Width = 85;
            // 
            // FDLV_Selected_CurrentRevisionStatus
            // 
            this.FDLV_Selected_CurrentRevisionStatus.Text = "CurrentResolveStatus";
            this.FDLV_Selected_CurrentRevisionStatus.Width = 140;
            // 
            // FDLV_Selected_SolvedVersion
            // 
            this.FDLV_Selected_SolvedVersion.Text = "Solved version";
            this.FDLV_Selected_SolvedVersion.Width = 120;
            // 
            // FDLV_Selected_OldVersion
            // 
            this.FDLV_Selected_OldVersion.FillsFreeSpace = true;
            this.FDLV_Selected_OldVersion.Text = "Old version";
            this.FDLV_Selected_OldVersion.Width = 120;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.FOLV_LibraryList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1291, 306);
            this.panel2.TabIndex = 2;
            // 
            // FOLV_LibraryList
            // 
            this.FOLV_LibraryList.AllColumns.Add(this.FOLV_Library_PartName);
            this.FOLV_LibraryList.AllColumns.Add(this.FOLV_Library_FullName);
            this.FOLV_LibraryList.AllColumns.Add(this.FOLV_Library_Nomenclature);
            this.FOLV_LibraryList.AllColumns.Add(this.FOLV_Library_Resolved);
            this.FOLV_LibraryList.AllColumns.Add(this.FOLV_Library_CurrentRevisionStatus);
            this.FOLV_LibraryList.AllColumns.Add(this.FOLV_Library_SolvedVersion);
            this.FOLV_LibraryList.AllColumns.Add(this.FOLV_Library_OldVersion);
            this.FOLV_LibraryList.BackColor = System.Drawing.Color.AntiqueWhite;
            this.FOLV_LibraryList.CellEditUseWholeCell = false;
            this.FOLV_LibraryList.CheckBoxes = true;
            this.FOLV_LibraryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FOLV_Library_PartName,
            this.FOLV_Library_FullName,
            this.FOLV_Library_Nomenclature,
            this.FOLV_Library_Resolved,
            this.FOLV_Library_CurrentRevisionStatus,
            this.FOLV_Library_SolvedVersion,
            this.FOLV_Library_OldVersion});
            this.FOLV_LibraryList.Cursor = System.Windows.Forms.Cursors.Default;
            this.FOLV_LibraryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FOLV_LibraryList.FullRowSelect = true;
            this.FOLV_LibraryList.HideSelection = false;
            this.FOLV_LibraryList.Location = new System.Drawing.Point(0, 0);
            this.FOLV_LibraryList.Name = "FOLV_LibraryList";
            this.FOLV_LibraryList.ShowGroups = false;
            this.FOLV_LibraryList.ShowImagesOnSubItems = true;
            this.FOLV_LibraryList.Size = new System.Drawing.Size(1291, 306);
            this.FOLV_LibraryList.SmallImageList = this.imageListSmall;
            this.FOLV_LibraryList.StateImageList = this.imageListSmall;
            this.FOLV_LibraryList.TabIndex = 10;
            this.FOLV_LibraryList.UseAlternatingBackColors = true;
            this.FOLV_LibraryList.UseCompatibleStateImageBehavior = false;
            this.FOLV_LibraryList.UseFiltering = true;
            this.FOLV_LibraryList.View = System.Windows.Forms.View.Details;
            this.FOLV_LibraryList.VirtualMode = true;
            // 
            // FOLV_Library_PartName
            // 
            this.FOLV_Library_PartName.AspectName = "";
            this.FOLV_Library_PartName.Text = "PartName";
            this.FOLV_Library_PartName.Width = 280;
            // 
            // FOLV_Library_FullName
            // 
            this.FOLV_Library_FullName.AspectName = "";
            this.FOLV_Library_FullName.Text = "Path";
            this.FOLV_Library_FullName.Width = 340;
            // 
            // FOLV_Library_Nomenclature
            // 
            this.FOLV_Library_Nomenclature.AspectName = "";
            this.FOLV_Library_Nomenclature.Text = "Nomenclature";
            this.FOLV_Library_Nomenclature.Width = 200;
            // 
            // FOLV_Library_Resolved
            // 
            this.FOLV_Library_Resolved.CheckBoxes = true;
            this.FOLV_Library_Resolved.Text = "Resolved";
            // 
            // FOLV_Library_CurrentRevisionStatus
            // 
            this.FOLV_Library_CurrentRevisionStatus.Text = "CurrentRevisionStatus";
            this.FOLV_Library_CurrentRevisionStatus.Width = 140;
            // 
            // FOLV_Library_SolvedVersion
            // 
            this.FOLV_Library_SolvedVersion.AspectName = "";
            this.FOLV_Library_SolvedVersion.Text = "Solved version";
            this.FOLV_Library_SolvedVersion.Width = 120;
            // 
            // FOLV_Library_OldVersion
            // 
            this.FOLV_Library_OldVersion.AspectName = "";
            this.FOLV_Library_OldVersion.FillsFreeSpace = true;
            this.FOLV_Library_OldVersion.Text = "Old version";
            this.FOLV_Library_OldVersion.Width = 120;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 65);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1291, 3);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer_FilterNQuery);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1291, 65);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer_FilterNQuery
            // 
            this.splitContainer_FilterNQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_FilterNQuery.IsSplitterFixed = true;
            this.splitContainer_FilterNQuery.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_FilterNQuery.Name = "splitContainer_FilterNQuery";
            // 
            // splitContainer_FilterNQuery.Panel1
            // 
            this.splitContainer_FilterNQuery.Panel1.Controls.Add(this.groupBox_Filter);
            // 
            // splitContainer_FilterNQuery.Panel2
            // 
            this.splitContainer_FilterNQuery.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer_FilterNQuery.Size = new System.Drawing.Size(1291, 65);
            this.splitContainer_FilterNQuery.SplitterDistance = 644;
            this.splitContainer_FilterNQuery.TabIndex = 11;
            // 
            // groupBox_Filter
            // 
            this.groupBox_Filter.Controls.Add(this.comboBoxFilterColumn);
            this.groupBox_Filter.Controls.Add(this.checkBox_FilterLibrary);
            this.groupBox_Filter.Controls.Add(this.textBoxFilterLibraryItems);
            this.groupBox_Filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_Filter.Location = new System.Drawing.Point(0, 0);
            this.groupBox_Filter.Name = "groupBox_Filter";
            this.groupBox_Filter.Size = new System.Drawing.Size(644, 65);
            this.groupBox_Filter.TabIndex = 11;
            this.groupBox_Filter.TabStop = false;
            this.groupBox_Filter.Text = "Filter";
            // 
            // comboBoxFilterColumn
            // 
            this.comboBoxFilterColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilterColumn.FormattingEnabled = true;
            this.comboBoxFilterColumn.Location = new System.Drawing.Point(12, 23);
            this.comboBoxFilterColumn.Name = "comboBoxFilterColumn";
            this.comboBoxFilterColumn.Size = new System.Drawing.Size(111, 21);
            this.comboBoxFilterColumn.TabIndex = 8;
            this.comboBoxFilterColumn.SelectedIndexChanged += new System.EventHandler(this.ComboBox_FilterColumn_SelectedIndexChanged);
            // 
            // checkBox_FilterLibrary
            // 
            this.checkBox_FilterLibrary.AutoSize = true;
            this.checkBox_FilterLibrary.Location = new System.Drawing.Point(129, 25);
            this.checkBox_FilterLibrary.Name = "checkBox_FilterLibrary";
            this.checkBox_FilterLibrary.Size = new System.Drawing.Size(117, 17);
            this.checkBox_FilterLibrary.TabIndex = 10;
            this.checkBox_FilterLibrary.Text = "ShowOnlyChecked";
            this.checkBox_FilterLibrary.UseVisualStyleBackColor = true;
            this.checkBox_FilterLibrary.CheckedChanged += new System.EventHandler(this.CheckBox_FilterLibrary_CheckedChanged);
            // 
            // textBoxFilterLibraryItems
            // 
            this.textBoxFilterLibraryItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilterLibraryItems.CausesValidation = false;
            this.textBoxFilterLibraryItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxFilterLibraryItems.Location = new System.Drawing.Point(252, 23);
            this.textBoxFilterLibraryItems.Name = "textBoxFilterLibraryItems";
            this.textBoxFilterLibraryItems.Size = new System.Drawing.Size(384, 21);
            this.textBoxFilterLibraryItems.TabIndex = 7;
            this.textBoxFilterLibraryItems.TextChanged += new System.EventHandler(this.TextBox_FilterLibraryItems_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_Mod);
            this.groupBox1.Controls.Add(this.comboBox_SearchAttribute);
            this.groupBox1.Controls.Add(this.comboBox_Operation);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(643, 65);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search library";
            // 
            // comboBox_Mod
            // 
            this.comboBox_Mod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Mod.FormattingEnabled = true;
            this.comboBox_Mod.Location = new System.Drawing.Point(210, 23);
            this.comboBox_Mod.Name = "comboBox_Mod";
            this.comboBox_Mod.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Mod.TabIndex = 10;
            // 
            // comboBox_SearchAttribute
            // 
            this.comboBox_SearchAttribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SearchAttribute.FormattingEnabled = true;
            this.comboBox_SearchAttribute.Location = new System.Drawing.Point(110, 23);
            this.comboBox_SearchAttribute.Name = "comboBox_SearchAttribute";
            this.comboBox_SearchAttribute.Size = new System.Drawing.Size(100, 21);
            this.comboBox_SearchAttribute.TabIndex = 9;
            // 
            // comboBox_Operation
            // 
            this.comboBox_Operation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Operation.FormattingEnabled = true;
            this.comboBox_Operation.Location = new System.Drawing.Point(10, 23);
            this.comboBox_Operation.Name = "comboBox_Operation";
            this.comboBox_Operation.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Operation.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.CausesValidation = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(310, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(323, 21);
            this.textBox1.TabIndex = 7;
            // 
            // splitContainer_ImageContainer
            // 
            this.splitContainer_ImageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_ImageContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_ImageContainer.MinimumSize = new System.Drawing.Size(460, 0);
            this.splitContainer_ImageContainer.Name = "splitContainer_ImageContainer";
            this.splitContainer_ImageContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_ImageContainer.Panel1
            // 
            this.splitContainer_ImageContainer.Panel1.Controls.Add(this.listView_Attachments);
            // 
            // splitContainer_ImageContainer.Panel2
            // 
            this.splitContainer_ImageContainer.Panel2.Controls.Add(this.PicturePanel);
            this.splitContainer_ImageContainer.Panel2MinSize = 460;
            this.splitContainer_ImageContainer.Size = new System.Drawing.Size(589, 742);
            this.splitContainer_ImageContainer.SplitterDistance = 213;
            this.splitContainer_ImageContainer.TabIndex = 2;
            // 
            // listView_Attachments
            // 
            this.listView_Attachments.BackColor = System.Drawing.Color.AntiqueWhite;
            this.listView_Attachments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_AttachmentName,
            this.columnHeader_AttachmentPath});
            this.listView_Attachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Attachments.FullRowSelect = true;
            this.listView_Attachments.HideSelection = false;
            this.listView_Attachments.Location = new System.Drawing.Point(0, 0);
            this.listView_Attachments.Name = "listView_Attachments";
            this.listView_Attachments.Size = new System.Drawing.Size(589, 213);
            this.listView_Attachments.TabIndex = 0;
            this.listView_Attachments.UseCompatibleStateImageBehavior = false;
            this.listView_Attachments.View = System.Windows.Forms.View.Details;
            this.listView_Attachments.SelectedIndexChanged += new System.EventHandler(this.ListView_Attachments_SelectedIndexChanged);
            this.listView_Attachments.DoubleClick += new System.EventHandler(this.ListView_Attachments_DoubleClick);
            this.listView_Attachments.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListView_Images_MouseClick);
            this.listView_Attachments.Resize += new System.EventHandler(this.ListView_Attachments_Resize);
            // 
            // columnHeader_AttachmentName
            // 
            this.columnHeader_AttachmentName.Text = "AttachmentName";
            this.columnHeader_AttachmentName.Width = 200;
            // 
            // columnHeader_AttachmentPath
            // 
            this.columnHeader_AttachmentPath.Text = "AttachmentPath";
            this.columnHeader_AttachmentPath.Width = 336;
            // 
            // PicturePanel
            // 
            this.PicturePanel.AutoScroll = true;
            this.PicturePanel.BackColor = System.Drawing.Color.White;
            this.PicturePanel.Controls.Add(this.pictureBox_ImageDisplay);
            this.PicturePanel.Controls.Add(this.kwForm_Display);
            this.PicturePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicturePanel.Location = new System.Drawing.Point(0, 0);
            this.PicturePanel.Name = "PicturePanel";
            this.PicturePanel.Size = new System.Drawing.Size(589, 525);
            this.PicturePanel.TabIndex = 0;
            // 
            // pictureBox_ImageDisplay
            // 
            this.pictureBox_ImageDisplay.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_ImageDisplay.Name = "pictureBox_ImageDisplay";
            this.pictureBox_ImageDisplay.Size = new System.Drawing.Size(535, 520);
            this.pictureBox_ImageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_ImageDisplay.TabIndex = 0;
            this.pictureBox_ImageDisplay.TabStop = false;
            // 
            // kwForm_Display
            // 
            this.kwForm_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwForm_Display.Location = new System.Drawing.Point(0, 0);
            this.kwForm_Display.MinimumSize = new System.Drawing.Size(400, 400);
            this.kwForm_Display.Name = "kwForm_Display";
            this.kwForm_Display.Size = new System.Drawing.Size(589, 525);
            this.kwForm_Display.TabIndex = 1;
            this.kwForm_Display.Visible = false;
            // 
            // Button_AddKW
            // 
            this.Button_AddKW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_AddKW.Location = new System.Drawing.Point(1650, 10);
            this.Button_AddKW.Name = "Button_AddKW";
            this.Button_AddKW.Size = new System.Drawing.Size(100, 45);
            this.Button_AddKW.TabIndex = 13;
            this.Button_AddKW.Text = "Add knowledgeware";
            this.Button_AddKW.UseVisualStyleBackColor = true;
            this.Button_AddKW.Click += new System.EventHandler(this.Button_AddKW_Click);
            // 
            // Button_AddPic
            // 
            this.Button_AddPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_AddPic.Location = new System.Drawing.Point(1764, 10);
            this.Button_AddPic.Name = "Button_AddPic";
            this.Button_AddPic.Size = new System.Drawing.Size(100, 45);
            this.Button_AddPic.TabIndex = 12;
            this.Button_AddPic.Text = "Add Pictures";
            this.Button_AddPic.UseVisualStyleBackColor = true;
            this.Button_AddPic.Click += new System.EventHandler(this.Button_AddImages_Click);
            // 
            // button_StoreRevision
            // 
            this.button_StoreRevision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_StoreRevision.Location = new System.Drawing.Point(1764, 60);
            this.button_StoreRevision.Name = "button_StoreRevision";
            this.button_StoreRevision.Size = new System.Drawing.Size(100, 45);
            this.button_StoreRevision.TabIndex = 11;
            this.button_StoreRevision.Text = "Save Revision";
            this.button_StoreRevision.UseVisualStyleBackColor = true;
            this.button_StoreRevision.Click += new System.EventHandler(this.Button_StoreRevision_Click);
            // 
            // contextMenuStrip_Images
            // 
            this.contextMenuStrip_Images.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip_Images.Name = "contextMenuStrip_Images";
            this.contextMenuStrip_Images.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteAttachment);
            // 
            // contextMenuStrip_SelectedItems
            // 
            this.contextMenuStrip_SelectedItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Remove});
            this.contextMenuStrip_SelectedItems.Name = "contextMenuStrip_Images";
            this.contextMenuStrip_SelectedItems.Size = new System.Drawing.Size(197, 26);
            // 
            // toolStripMenuItem_Remove
            // 
            this.toolStripMenuItem_Remove.Name = "toolStripMenuItem_Remove";
            this.toolStripMenuItem_Remove.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_Remove.Text = "Remove from selection";
            this.toolStripMenuItem_Remove.Click += new System.EventHandler(this.DeleteSelectedItem);
            // 
            // RevisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 856);
            this.Controls.Add(this.splitContainer_Glavni);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "RevisionForm";
            this.Text = "RevisionForm";
            this.Load += new System.EventHandler(this.RevisionForm_Load);
            this.splitContainer_Glavni.Panel1.ResumeLayout(false);
            this.splitContainer_Glavni.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Glavni)).EndInit();
            this.splitContainer_Glavni.ResumeLayout(false);
            this.splitContainer_Display.Panel1.ResumeLayout(false);
            this.splitContainer_Display.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Display)).EndInit();
            this.splitContainer_Display.ResumeLayout(false);
            this.splitContainer_LeftSide.Panel1.ResumeLayout(false);
            this.splitContainer_LeftSide.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_LeftSide)).EndInit();
            this.splitContainer_LeftSide.ResumeLayout(false);
            this.splitContainer_ID_Importance_Comment.Panel1.ResumeLayout(false);
            this.splitContainer_ID_Importance_Comment.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_ID_Importance_Comment)).EndInit();
            this.splitContainer_ID_Importance_Comment.ResumeLayout(false);
            this.splitContainer_ID_and_Importance.Panel1.ResumeLayout(false);
            this.splitContainer_ID_and_Importance.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_ID_and_Importance)).EndInit();
            this.splitContainer_ID_and_Importance.ResumeLayout(false);
            this.groupBox_ID.ResumeLayout(false);
            this.groupBox_ID.PerformLayout();
            this.groupBox_Importance.ResumeLayout(false);
            this.groupBox_Importance.PerformLayout();
            this.groupBox_Comment.ResumeLayout(false);
            this.groupBox_Comment.PerformLayout();
            this.splitContainer_Liste.Panel1.ResumeLayout(false);
            this.splitContainer_Liste.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Liste)).EndInit();
            this.splitContainer_Liste.ResumeLayout(false);
            this.groupBoxSelected.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FDLV_SelectedList)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FOLV_LibraryList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer_FilterNQuery.Panel1.ResumeLayout(false);
            this.splitContainer_FilterNQuery.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_FilterNQuery)).EndInit();
            this.splitContainer_FilterNQuery.ResumeLayout(false);
            this.groupBox_Filter.ResumeLayout(false);
            this.groupBox_Filter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer_ImageContainer.Panel1.ResumeLayout(false);
            this.splitContainer_ImageContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_ImageContainer)).EndInit();
            this.splitContainer_ImageContainer.ResumeLayout(false);
            this.PicturePanel.ResumeLayout(false);
            this.PicturePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ImageDisplay)).EndInit();
            this.contextMenuStrip_Images.ResumeLayout(false);
            this.contextMenuStrip_SelectedItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.SplitContainer splitContainer_Glavni;
        private System.Windows.Forms.SplitContainer splitContainer_Display;
        private System.Windows.Forms.SplitContainer splitContainer_LeftSide;
        private System.Windows.Forms.SplitContainer splitContainer_Liste;
        private System.Windows.Forms.GroupBox groupBoxSelected;
        private BrightIdeasSoftware.FastDataListView FDLV_SelectedList;
        private BrightIdeasSoftware.OLVColumn FDLV_Selected_PartName;
        private BrightIdeasSoftware.OLVColumn FDLV_Selected_FullName;
        private BrightIdeasSoftware.OLVColumn FDLV_Selected_Nomenclature;
        private BrightIdeasSoftware.OLVColumn FDLV_Selected_Resolved;
        private BrightIdeasSoftware.OLVColumn FDLV_Selected_CurrentRevisionStatus;
        private System.Windows.Forms.Button button_StoreRevision;
        private System.Windows.Forms.Panel panel2;
        private BrightIdeasSoftware.FastObjectListView FOLV_LibraryList;
        private BrightIdeasSoftware.OLVColumn FOLV_Library_PartName;
        private BrightIdeasSoftware.OLVColumn FOLV_Library_FullName;
        private BrightIdeasSoftware.OLVColumn FOLV_Library_Nomenclature;
        private BrightIdeasSoftware.OLVColumn FOLV_Library_Resolved;
        private BrightIdeasSoftware.OLVColumn FOLV_Library_CurrentRevisionStatus;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.CheckBox checkBox_FilterLibrary;
        private System.Windows.Forms.ComboBox comboBoxFilterColumn;
        private System.Windows.Forms.TextBox textBoxFilterLibraryItems;
        private System.Windows.Forms.Button Button_AddPic;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Images;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer_ImageContainer;
        private System.Windows.Forms.ListView listView_Attachments;
        private System.Windows.Forms.ColumnHeader columnHeader_AttachmentName;
        private System.Windows.Forms.ColumnHeader columnHeader_AttachmentPath;
        private System.Windows.Forms.Panel PicturePanel;
        private System.Windows.Forms.PictureBox pictureBox_ImageDisplay;
        private System.Windows.Forms.SplitContainer splitContainer_ID_Importance_Comment;
        private System.Windows.Forms.SplitContainer splitContainer_ID_and_Importance;
        private System.Windows.Forms.GroupBox groupBox_ID;
        private System.Windows.Forms.Label label_RevisionID;
        private System.Windows.Forms.TextBox textBoxRevisionID;
        private System.Windows.Forms.GroupBox groupBox_Importance;
        private System.Windows.Forms.ComboBox comboBox_Importance;
        private System.Windows.Forms.Label label_Importance_level;
        private System.Windows.Forms.GroupBox groupBox_Comment;
        private System.Windows.Forms.TextBox textBoxComent;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_SelectedItems;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Remove;
        private BrightIdeasSoftware.OLVColumn FOLV_Library_OldVersion;
        private BrightIdeasSoftware.OLVColumn FOLV_Library_SolvedVersion;
        private System.Windows.Forms.Button Button_AddKW;
        private KWUserControl kwForm_Display;
        private BrightIdeasSoftware.OLVColumn FDLV_Selected_SolvedVersion;
        private BrightIdeasSoftware.OLVColumn FDLV_Selected_OldVersion;
        private System.Windows.Forms.SplitContainer splitContainer_FilterNQuery;
        private System.Windows.Forms.GroupBox groupBox_Filter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Mod;
        private System.Windows.Forms.ComboBox comboBox_SearchAttribute;
        private System.Windows.Forms.ComboBox comboBox_Operation;
        private System.Windows.Forms.TextBox textBox1;
    }
}