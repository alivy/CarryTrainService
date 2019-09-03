using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.Help
{
  public  class Base64ToImgHelp
    {
        /// <summary>
        /// 将Base64String转为图片并保存
        /// </summary>
        public static string CetFromStringBase64(string fileDir)
        {
            string userPhoto = string.Empty;
            //读图片转为Base64String
            Bitmap bmp1 = new System.Drawing.Bitmap(Path.Combine(fileDir, "default.jpg"));
            using (MemoryStream ms1 = new MemoryStream())
            {
                bmp1.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr1 = new byte[ms1.Length];
                ms1.Position = 0;
                ms1.Read(arr1, 0, (int)ms1.Length);
                ms1.Close();
                userPhoto = Convert.ToBase64String(arr1);
            }
            return userPhoto;
        }

        /// <summary>
        /// 将Base64String转为图片并保存
        /// </summary>
        /// <param name="base64String"></param>
        public static void CetFromBase64String(string base64String, string path)
        {
            byte[] arr2 = Convert.FromBase64String(base64String);
            using (MemoryStream ms2 = new MemoryStream(arr2))
            {
                Bitmap bmp2 = new Bitmap(ms2);
                bmp2.Save(path, ImageFormat.Jpeg);
            }
        }

        /// <summary>
        /// 将Base64String转为图片并保存
        /// </summary>
        /// <param name="base64String"></param>
        public static Image CetFromBase64String(string base64String)
        {
            byte[] arr2 = Convert.FromBase64String(base64String);
            using (MemoryStream ms2 = new MemoryStream(arr2))
            {
                Bitmap bmp2 = new Bitmap(ms2);
                return bmp2;
            }
        }
    }
}
