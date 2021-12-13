
namespace VerManagerLibrary_ClassLib
{
    partial class AddPicture
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Crop = new System.Windows.Forms.Button();
            this.button_Screenshot = new System.Windows.Forms.Button();
            this.button_FromFile = new System.Windows.Forms.Button();
            this.pictureBox_Screenshot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Screenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button_Save);
            this.splitContainer1.Panel1.Controls.Add(this.button_Crop);
            this.splitContainer1.Panel1.Controls.Add(this.button_Screenshot);
            this.splitContainer1.Panel1.Controls.Add(this.button_FromFile);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox_Screenshot);
            this.splitContainer1.Size = new System.Drawing.Size(281, 319);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 3;
            // 
            // button_Save
            // 
            this.button_Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Save.Location = new System.Drawing.Point(12, 187);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(180, 50);
            this.button_Save.TabIndex = 5;
            this.button_Save.Text = "Save image";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Crop
            // 
            this.button_Crop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Crop.Location = new System.Drawing.Point(13, 130);
            this.button_Crop.Name = "button_Crop";
            this.button_Crop.Size = new System.Drawing.Size(180, 50);
            this.button_Crop.TabIndex = 4;
            this.button_Crop.Text = "Crop";
            this.button_Crop.UseVisualStyleBackColor = true;
            this.button_Crop.Click += new System.EventHandler(this.button_Crop_Click);
            // 
            // button_Screenshot
            // 
            this.button_Screenshot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Screenshot.Location = new System.Drawing.Point(13, 72);
            this.button_Screenshot.Name = "button_Screenshot";
            this.button_Screenshot.Size = new System.Drawing.Size(180, 50);
            this.button_Screenshot.TabIndex = 3;
            this.button_Screenshot.Text = "Capture screenshot";
            this.button_Screenshot.UseVisualStyleBackColor = true;
            this.button_Screenshot.Click += new System.EventHandler(this.button_Screenshot_Click);
            // 
            // button_FromFile
            // 
            this.button_FromFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_FromFile.Location = new System.Drawing.Point(14, 15);
            this.button_FromFile.Name = "button_FromFile";
            this.button_FromFile.Size = new System.Drawing.Size(180, 50);
            this.button_FromFile.TabIndex = 2;
            this.button_FromFile.Text = "From file";
            this.button_FromFile.UseVisualStyleBackColor = true;
            this.button_FromFile.Click += new System.EventHandler(this.button_FromFile_Click);
            // 
            // pictureBox_Screenshot
            // 
            this.pictureBox_Screenshot.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Screenshot.Name = "pictureBox_Screenshot";
            this.pictureBox_Screenshot.Size = new System.Drawing.Size(50, 200);
            this.pictureBox_Screenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_Screenshot.TabIndex = 4;
            this.pictureBox_Screenshot.TabStop = false;
            this.pictureBox_Screenshot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Screenshot_MouseDown);
            this.pictureBox_Screenshot.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Screenshot_MouseMove);
            // 
            // AddPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 319);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(240, 300);
            this.Name = "AddPicture";
            this.Text = "AddPicture";
            this.TopMost = true;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Screenshot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_Screenshot;
        private System.Windows.Forms.Button button_FromFile;
        private System.Windows.Forms.PictureBox pictureBox_Screenshot;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Crop;
    }
}