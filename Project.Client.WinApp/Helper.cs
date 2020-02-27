using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Client.WinApp
{
    public static class Helper
    {
        public static string UploadedUrl(string ImageName)
        {
            if (String.IsNullOrEmpty(ImageName)) return null;
               return Environment.CurrentDirectory + @"\Upload\" + ImageName;
        }

        public static object GetDataValue(object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }

            return value;
        }

        public static void SaveImage(string FileName)
        {
            if (!Directory.Exists(Environment.CurrentDirectory + @"\Upload")) Directory.CreateDirectory(Environment.CurrentDirectory + @"\Upload");

            FileStream inStream = File.OpenRead(FileName);

            FileStream outStream = File.OpenWrite(Environment.CurrentDirectory + @"\Upload\" + Path.GetFileName(FileName));
            MemoryStream storeStream = new MemoryStream();

            storeStream.SetLength(inStream.Length);
            inStream.Read(storeStream.GetBuffer(), 0, (int)inStream.Length);

            storeStream.Flush();
            inStream.Close();

            storeStream.WriteTo(outStream);
            outStream.Flush();
            outStream.Close();
            storeStream.Close();
        }

    }
}
