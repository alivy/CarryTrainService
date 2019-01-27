﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AppResource
    {
        #region 常量
        /// <summary>
        /// 程序集的名称
        /// </summary>
        private static string CurrentAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        #endregion

        #region 变量
        /// <summary>
        /// 当前程序集
        /// </summary>
        private static Assembly CurrentAssembly = Assembly.GetExecutingAssembly();

        #endregion

        #region 方法
        /// <summary>
        /// 在嵌入的资源文件中查找相应的图片
        /// </summary>
        /// <param name="name">资源图片的文件名称+扩展名</param>
        /// <returns></returns>
        public static Image GetImage(string name)
        {
            Image image = null;
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    StringBuilder sb = new StringBuilder();
                    if (name[0] != '.')
                        sb.Append(AppResource.CurrentAssemblyName + "." + name);
                    else
                        sb.Append(AppResource.CurrentAssemblyName + name);
                    using (Stream stream = CurrentAssembly.GetManifestResourceStream(sb.ToString()))
                    {
                        if (stream == null)
                            throw new Exception("加载资源文件失败");
                        else
                            image = Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AssemblyHelper.GetImage(string)->" + ex.Message);
                throw ex;
            }
            return image;
        }
        public static Stream GetObject(string name)
        {
            Stream stream = null;
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    StringBuilder sb = new StringBuilder();
                    if (name[0] != '.')
                        sb.Append(AppResource.CurrentAssemblyName + "." + name);
                    else
                        sb.Append(AppResource.CurrentAssemblyName + name);
                    stream = CurrentAssembly.GetManifestResourceStream(sb.ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return stream;
        }


        public static string FilePath(string name)
        {
            string path = null;
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    StringBuilder sb = new StringBuilder();
                    if (name[0] != '.')
                        sb.Append(AppResource.CurrentAssemblyName + "." + name);
                    else
                        sb.Append(AppResource.CurrentAssemblyName + name);
                    path = sb.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return path;
        }
        #endregion
    }
}
