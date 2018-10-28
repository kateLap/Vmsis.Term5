using System;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace Lab4
{
    internal class Program
    {
        [STAThread]
        private static void Main()
        {
            using (var capture = new VideoCapture())
            {
                Console.WriteLine("Информация об устройстве вебкамера:");
                Console.WriteLine("************************************");

                var width = Convert.ToInt32(capture.GetCaptureProperty(CapProp.FrameWidth));
                Console.WriteLine(
                    $@"Число пикселей (ширина) : {width}");
                var height = Convert.ToInt32(capture.GetCaptureProperty(CapProp.FrameHeight));
                Console.WriteLine(
                    $@"Число пикселей (высота) : {height}");
                Console.WriteLine("************************************");
            }

            using (var objectSearch = new ManagementObjectSearcher("SELECT * From Win32_PnPEntity"))
            {
                var webCamera = objectSearch.Get().Cast<ManagementBaseObject>().Select(c => new
                {
                    Caption = Convert.ToString(c["Caption"]),
                    Manufacturer = Convert.ToString(c["Manufacturer"]),
                    DeviceId = Convert.ToString(c["DeviceId"]),
                    Name = Convert.ToString(c["Name"])
                }).FirstOrDefault(w => w.Caption.Contains("WebCam"));

                Console.WriteLine("************************************");
                Console.WriteLine($"Название устройства : {webCamera.Name}");
                Console.WriteLine($"Заголовок : {webCamera.Caption}");
                Console.WriteLine($"Идентификатор устройства : {webCamera.DeviceId}");
                Console.WriteLine($"Производитель : {webCamera.Manufacturer}");
                Console.WriteLine("************************************");
            }

            const string filename = "Запись";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WebCamera(filename));
        }
    }
}