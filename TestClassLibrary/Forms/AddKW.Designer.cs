
namespace VerManagerLibrary_ClassLib
{
    partial class AddKW
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
            this.kwForm1 = new VerManagerLibrary_ClassLib.KWForm();
            this.SuspendLayout();
            // 
            // kwForm1
            // 
            this.kwForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwForm1.Location = new System.Drawing.Point(0, 0);
            this.kwForm1.MinimumSize = new System.Drawing.Size(840, 470);
            this.kwForm1.Name = "kwForm1";
            this.kwForm1.Size = new System.Drawing.Size(861, 493);
            this.kwForm1.TabIndex = 0;
            // 
            // AddKW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 493);
            this.Controls.Add(this.kwForm1);
            this.MinimumSize = new System.Drawing.Size(870, 530);
            this.Name = "AddKW";
            this.Text = "Add Knowledgeware";
            this.ResumeLayout(false);

        }

        #endregion

        private KWForm kwForm1;
    }
}