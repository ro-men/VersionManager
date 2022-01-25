
namespace VerManagerLibrary_ClassLib
{
    partial class KWUserControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox_Language = new System.Windows.Forms.GroupBox();
            this.radioButton_VB = new System.Windows.Forms.RadioButton();
            this.radioButton_KW = new System.Windows.Forms.RadioButton();
            this.button_Save = new System.Windows.Forms.Button();
            this.label_Value = new System.Windows.Forms.Label();
            this.label_Input_1 = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_Type = new System.Windows.Forms.Label();
            this.textBox_Value = new System.Windows.Forms.TextBox();
            this.textBox_Input_1 = new System.Windows.Forms.TextBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.comboBox_Type = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox_Language.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_Language);
            this.splitContainer1.Panel1.Controls.Add(this.button_Save);
            this.splitContainer1.Panel1.Controls.Add(this.label_Value);
            this.splitContainer1.Panel1.Controls.Add(this.label_Input_1);
            this.splitContainer1.Panel1.Controls.Add(this.label_Name);
            this.splitContainer1.Panel1.Controls.Add(this.label_Type);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox_Value);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_Input_1);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_Name);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox_Type);
            this.splitContainer1.Size = new System.Drawing.Size(830, 300);
            this.splitContainer1.SplitterDistance = 100;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox_Language
            // 
            this.groupBox_Language.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Language.Controls.Add(this.radioButton_VB);
            this.groupBox_Language.Controls.Add(this.radioButton_KW);
            this.groupBox_Language.Location = new System.Drawing.Point(9, 107);
            this.groupBox_Language.Name = "groupBox_Language";
            this.groupBox_Language.Size = new System.Drawing.Size(83, 71);
            this.groupBox_Language.TabIndex = 7;
            this.groupBox_Language.TabStop = false;
            this.groupBox_Language.Text = "Language";
            // 
            // radioButton_VB
            // 
            this.radioButton_VB.AutoSize = true;
            this.radioButton_VB.Location = new System.Drawing.Point(3, 44);
            this.radioButton_VB.Name = "radioButton_VB";
            this.radioButton_VB.Size = new System.Drawing.Size(39, 17);
            this.radioButton_VB.TabIndex = 1;
            this.radioButton_VB.Text = "VB";
            this.radioButton_VB.UseVisualStyleBackColor = true;
            // 
            // radioButton_KW
            // 
            this.radioButton_KW.AutoSize = true;
            this.radioButton_KW.Checked = true;
            this.radioButton_KW.Location = new System.Drawing.Point(3, 21);
            this.radioButton_KW.Name = "radioButton_KW";
            this.radioButton_KW.Size = new System.Drawing.Size(43, 17);
            this.radioButton_KW.TabIndex = 0;
            this.radioButton_KW.TabStop = true;
            this.radioButton_KW.Text = "KW";
            this.radioButton_KW.UseVisualStyleBackColor = true;
            this.radioButton_KW.CheckedChanged += new System.EventHandler(this.RadioButton_KW_CheckedChanged);
            // 
            // button_Save
            // 
            this.button_Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Save.Location = new System.Drawing.Point(11, 259);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(80, 27);
            this.button_Save.TabIndex = 6;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // label_Value
            // 
            this.label_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(6, 78);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(34, 13);
            this.label_Value.TabIndex = 5;
            this.label_Value.Text = "Value";
            // 
            // label_Input_1
            // 
            this.label_Input_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Input_1.AutoSize = true;
            this.label_Input_1.Location = new System.Drawing.Point(6, 53);
            this.label_Input_1.Name = "label_Input_1";
            this.label_Input_1.Size = new System.Drawing.Size(0, 13);
            this.label_Input_1.TabIndex = 4;
            // 
            // label_Name
            // 
            this.label_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(6, 28);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(35, 13);
            this.label_Name.TabIndex = 3;
            this.label_Name.Text = "Name";
            // 
            // label_Type
            // 
            this.label_Type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Type.AutoSize = true;
            this.label_Type.Location = new System.Drawing.Point(6, 3);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(31, 13);
            this.label_Type.TabIndex = 2;
            this.label_Type.Text = "Type";
            // 
            // textBox_Value
            // 
            this.textBox_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Value.Location = new System.Drawing.Point(3, 78);
            this.textBox_Value.Multiline = true;
            this.textBox_Value.Name = "textBox_Value";
            this.textBox_Value.Size = new System.Drawing.Size(717, 219);
            this.textBox_Value.TabIndex = 4;
            // 
            // textBox_Input_1
            // 
            this.textBox_Input_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Input_1.Enabled = false;
            this.textBox_Input_1.Location = new System.Drawing.Point(3, 53);
            this.textBox_Input_1.Name = "textBox_Input_1";
            this.textBox_Input_1.Size = new System.Drawing.Size(717, 20);
            this.textBox_Input_1.TabIndex = 3;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Name.Location = new System.Drawing.Point(3, 28);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(717, 20);
            this.textBox_Name.TabIndex = 2;
            // 
            // comboBox_Type
            // 
            this.comboBox_Type.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Type.FormattingEnabled = true;
            this.comboBox_Type.Items.AddRange(new object[] {
            "Rule",
            "Check",
            "Reaction",
            "Formula",
            "Macros with arguments",
            "Action"});
            this.comboBox_Type.Location = new System.Drawing.Point(3, 3);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(717, 21);
            this.comboBox_Type.TabIndex = 1;
            this.comboBox_Type.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Type_SelectedIndexChanged);
            // 
            // KWForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "KWForm";
            this.Size = new System.Drawing.Size(830, 300);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox_Language.ResumeLayout(false);
            this.groupBox_Language.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox_Language;
        private System.Windows.Forms.RadioButton radioButton_VB;
        private System.Windows.Forms.RadioButton radioButton_KW;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.Label label_Input_1;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_Type;
        private System.Windows.Forms.TextBox textBox_Value;
        private System.Windows.Forms.TextBox textBox_Input_1;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.ComboBox comboBox_Type;
    }
}
