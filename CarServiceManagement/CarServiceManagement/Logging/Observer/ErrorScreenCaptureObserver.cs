using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace CarServiceManagement.Logging.Observer
{
    public class ErrorScreenCaptureObserver : ILogObserver
    {
        private readonly string screenshotName = "img";
        private readonly string imageFormat = ".jpeg";

        private int counter = 0;
        private readonly string fileName;

        public ErrorScreenCaptureObserver(string outputPath)
        {
            fileName = Path.Combine(outputPath, screenshotName + "{0}" + imageFormat);
        }

        public void Log(Status status, string message, DateTime timeStamp, string callerName, string sourceFile, int sourceLineNumber)
        {
            if (status == Status.Error)
            {
                Thread.Sleep(100);
                CaptureScreenToFile(string.Format(fileName, counter++));
            }
        }

        private void CaptureScreenToFile(string fileName)
        {
            int screenLeft = SystemInformation.VirtualScreen.Left;
            int screenTop = SystemInformation.VirtualScreen.Top;
            int screenWidth = SystemInformation.VirtualScreen.Width;
            int screenHeight = SystemInformation.VirtualScreen.Height;

            using (Bitmap bitmap = new Bitmap(screenWidth, screenHeight))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(screenLeft, screenTop, 0, 0, bitmap.Size);
                }
                bitmap.Save(fileName, ImageFormat.Jpeg);
            }
        }
    }
}
