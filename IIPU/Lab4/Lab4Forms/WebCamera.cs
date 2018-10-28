using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Gma.System.MouseKeyHook;

namespace Lab4
{
    public class WebCamera : Form
    {
        public WebCamera(string fileName)
        {
            Name = fileName;
            WindowState = FormWindowState.Minimized;

            base.SetVisibleCore(false);
            Visible = false;
            ShowInTaskbar = false;
            
            Hide();

            Hook.GlobalEvents().KeyDown += WebCameraEvent;
        }

        public string Name { get; set; }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // WebCamera
            // 
            this.ResumeLayout(false);
        }

        private void WebCameraEvent(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.C:
                {                  
                    using (var capture = new VideoCapture())
                    {
                        var frameNum = 0;

                        var width = Convert.ToInt32(capture.GetCaptureProperty(CapProp.FrameWidth));
                        var height = Convert.ToInt32(capture.GetCaptureProperty(CapProp.FrameHeight));

                        string newNameMp4 = Name + ".mp4";
                        Size size = new Size(width, height);

                        var videoWriter = new VideoWriter(newNameMp4, 10, size, true);

                        var mat = new Mat();//working with pictures
                        while (frameNum < 100)
                        {
                            capture.Read(mat);
                            videoWriter.Write(mat);
                            frameNum++;
                        }

                        if (videoWriter.IsOpened)
                            videoWriter.Dispose();
                        //Close();
                    }

                    break;
                }
                case Keys.P:
                {
                    var capture = new VideoCapture();
                    string newNameJpg = Name + ".jpg";

                    capture.QueryFrame().Bitmap.Save(newNameJpg);
                    Close();

                    break;
                }

                case Keys.Escape:
                {
                    Close();

                    break;
                }

            }
        }

       

        /*private void Worker_Load(object sender, EventArgs e)
        {

        }*/
    }
}