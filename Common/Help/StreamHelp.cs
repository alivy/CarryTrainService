using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Help
{
    /// <summary>
    /// 文件流转换
    /// </summary>
    public class StreamHelp
    {
        // c#中字节数组byte[]、图片image、流stream，字符串string、内存流MemoryStream、文件file，之间的转换

        /*********字节数组byte[]与图片image之间的转化**********/
        //字节数组转换成图片
        public static Image byte2img(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            ms.Position = 0;
            Image img = Image.FromStream(ms);
            ms.Close();
            return img;
        }


        //图片转化为字节数组
        public static byte[] byte2img(Bitmap Bit)
        {
            byte[] back = null;
            MemoryStream ms = new MemoryStream();
            Bit.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            back = ms.GetBuffer();
            return back;
        }


        /**********字节数组byte[]与字符串string之间的编码解码*****/
        //字符串到字节数组的编码
        public static byte[] str2byte(string str)
        {
            byte[] data = Encoding.UTF8.GetBytes(str);
            //byte[] data = Convert.FromBase64String(param);
            //有很多种编码方式，可参考:http://blog.csdn.net/luanpeng825485697/article/details/77622243
            return data;
        }


        //字节数组到字符串的解码
        public static string str2byte(byte[] data)
        {
            string str = System.Text.Encoding.UTF8.GetString(data);
            //str = Convert.ToBase64String(data);
            //有很多种编码方式，可参考:http://blog.csdn.net/luanpeng825485697/article/details/77622243
            return str;
        }

        /****字节数组byte[]与内存流MemoryStream之间的转换****/
        //字节数组转化为输入内存流
        public static MemoryStream byte2Memorystream(byte[] data)
        {
            MemoryStream inputStream = new MemoryStream(data);
            return inputStream;
        }


        //输出内存流转化为字节数组
        public static byte[] byte2stream(MemoryStream outStream)
        {
            return outStream.ToArray();
        }

        /************字节数组byte[]与流stream之间的转换********/
        //将 Stream 转成 byte[]
        public byte[] stream2byte(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }


        //将 byte[] 转成 Stream
        public static Stream byte2stream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        //流Stream 和 文件file之间的转换
        //将 Stream 写入文件
        public void stream2file(Stream stream, string fileName)
        {
            // 把 Stream 转换成 byte[]
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            // 把 byte[] 写入文件
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }


        //从文件读取 Stream
        public Stream file2stream(string fileName)
        {
            // 打开文件
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            // 读取文件的 byte[]
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            // 把 byte[] 转换成 Stream
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
