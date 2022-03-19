using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace screenshort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bmp;
        Graphics gr;
        private void button1_Click(object sender, EventArgs e)
        {
            CaptureMyScreen();
        }
        private void CaptureMyScreen()
        {

            try
            {
                Bitmap captureBitmap = bmp;
                
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                captureBitmap.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures).ToString() + @"\capture"+ GenerateFileName("_zahid_949551_")+ ".jpg", ImageFormat.Jpeg);
                MessageBox.Show("Screen Captured");


                //MessageBox.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public string GenerateFileName(string context)
        {
            return context + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" ;
            //+ Guid.NewGuid().ToString("N")
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            bmp = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width,
                             Screen.PrimaryScreen.WorkingArea.Height);
            gr = Graphics.FromImage(bmp);
            gr.CopyFromScreen(0, 0, 0, 0, new Size(bmp.Width, bmp.Height));
            pictureBox1.Image = bmp;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void keypress(object sender, KeyPressEventArgs e)
        {

        }

        private void keydown(object sender, KeyEventArgs e)
        {
        }

        private void capture_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PrintScreen)
            {
                CaptureMyScreen();
            }
            if (e.KeyCode == Keys.A)
            {
                CaptureMyScreen();
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
