using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerManagerLibrary_ClassLib
{
    public partial class AddPicture : Form
    {
        public AddPicture()
        {
            InitializeComponent();
        }
        private RevisionClass ORevision;
        private string sLocation = VMLCoordinator.attachmentsFolder + @"\";
        public void SetRevision(RevisionClass oRevision) {
            ORevision = oRevision;
        }
        private void button_FromFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select pictures you want to attach...";
            ofd.Multiselect = true;
            ofd.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK) {
                string[] files = ofd.FileNames;
                foreach(string file in files)
                {
                    int index = ORevision.Attachments.Count() + 1;
                    string newName = "IMG_" + ORevision.RevisionID + "_" + index.ToString() + Path.GetExtension(file);
                    while (File.Exists(sLocation + newName))
                    {
                        index++;
                        newName = "IMG_" + ORevision.RevisionID + "_" + index.ToString() + Path.GetExtension(file);
                    }
                    File.Copy(file, sLocation + newName);
                    if (!ORevision.Attachments.Contains(sLocation + newName))
                    {
                        ORevision.Attachments.Add(sLocation + newName);
                    }
                }
            this.Close();
            }
        }

        private void button_Screenshot_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1500, 800);
            Rectangle bounds = new Rectangle(new Point(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top),new Size(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height)) ;
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = InterpolationMode.High;
                g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            }
            if (pictureBox_Screenshot.Image != null) pictureBox_Screenshot.Image.Dispose();
            pictureBox_Screenshot.Image = bitmap;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (pictureBox_Screenshot.Image != null)
            {
                int index = ORevision.Attachments.Count() + 1;
                string newName = "IMG_" + ORevision.RevisionID + "_" + index.ToString() + ".jpg";
                System.IO.Directory.CreateDirectory(sLocation);
                pictureBox_Screenshot.Image.Save(sLocation + newName, ImageFormat.Jpeg);
                if (!ORevision.Attachments.Contains(sLocation + newName))
                {
                    ORevision.Attachments.Add(sLocation + newName);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show(this,"You must take a screenshot to save it.","No screenshot...",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        int cropX;
        int cropY;
        int cropWidth;
        int cropHeight;

        public Pen cropPen;
        public DashStyle cropDashStyle = DashStyle.DashDot;

        private void button_Crop_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            if (cropWidth < 1)
            {
                return;
            }
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            //First we define a rectangle with the help of already calculated points  
            Bitmap OriginalImage = new Bitmap(pictureBox_Screenshot.Image, pictureBox_Screenshot.Width, pictureBox_Screenshot.Height);
            //Original image  
            Bitmap _img = new Bitmap(cropWidth, cropHeight);
            // for cropinf image  
            Graphics g = Graphics.FromImage(_img);
            // create graphics  
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //set image attributes  
            g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);
            pictureBox_Screenshot.Image = _img;
            pictureBox_Screenshot.Width = _img.Width;
            pictureBox_Screenshot.Height = _img.Height;
            this.Width = _img.Width + 230;
            this.Height = _img.Height + 40  ;
        }

        private void pictureBox_Screenshot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Cursor = Cursors.Cross;
                cropX = e.X;
                cropY = e.Y;
                cropPen = new Pen(Color.Black, 1);
                cropPen.DashStyle = DashStyle.DashDotDot;
            }
            pictureBox_Screenshot.Refresh();
        }

        private void pictureBox_Screenshot_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox_Screenshot.Image == null)
                return;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBox_Screenshot.Refresh();
                cropWidth = e.X - cropX;
                cropHeight = e.Y - cropY;
                pictureBox_Screenshot.CreateGraphics().DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight);
            }
        }
    }
}
