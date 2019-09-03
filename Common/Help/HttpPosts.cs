using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Common
{
    public class HttpPosts
    {
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }
        /// <summary>
        /// HTTP GET方式请求数据.
        /// </summary>
        /// <param name="url">URL.</param>
        /// <returns></returns>
        public static Stream HttpGet(string url, Hashtable headht = null)
        {
            HttpWebRequest request;
            Stream stream = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 15000;
            request.AllowAutoRedirect = false;
            WebResponse response = null;
            //string responseStr = null;
            if (headht != null)
            {
                foreach (DictionaryEntry item in headht)
                {
                    request.Headers.Add(item.Key.ToString(), item.Value.ToString());
                }
            }

            try
            {
                response = request.GetResponse();
                if (response != null)
                {
                    //StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    //responseStr = reader.ReadToEnd();
                    //reader.Close();
                    using (Stream st = response.GetResponseStream())
                    {
                        stream = new MemoryStream();
                        while (true)
                        {
                            int data = st.ReadByte();
                            if (data == -1)
                                break;
                            stream.WriteByte((byte)data);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return stream;
        }


        public static string HttpGet(string url, Encoding encodeing, Hashtable headht = null)
        {
            HttpWebRequest request;

            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.Timeout = 15000;
            request.AllowAutoRedirect = false;
            WebResponse response = null;
            string responseStr = null;
            if (headht != null)
            {
                foreach (DictionaryEntry item in headht)
                {
                    request.Headers.Add(item.Key.ToString(), item.Value.ToString());
                }
            }

            try
            {
                response = request.GetResponse();

                if (response != null)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream(), encodeing);
                    responseStr = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return responseStr;
        }

        /// <summary>
        /// http的post请求
        /// </summary>
        /// <param name="sUrl">请求的地址</param>
        /// <param name="sBody">请求的参数</param>
        /// <param name="sHead">请求头</param>
        /// <param name="postType">请求类型，0：application/x-www-form-urlencoded，1：application/json，2：text/xml</param>
        /// <returns></returns>
        public static string Post(string sUrl, string sBody,Dictionary<string, string> sHead=null, int? postType = 0)
        {
            string result = string.Empty;
            result = HttpPosts.RawPost(sUrl, sBody, sHead, postType,30);

            StringBuilder res = new StringBuilder();
            res.AppendLine("*****************************");
            res.AppendLine("风控发送钱富通json ：" + sBody);
            res.AppendLine("*****************************");
            res.AppendLine("执行结果 ：" + result);
            res.AppendLine("*****************************");
            Logger.WirteMessageLog(res.ToString());
            return result;
        }
        /// <summary>
        /// http的post请求
        /// </summary>
        /// <param name="sUrl">请求的地址</param>
        /// <param name="json">请求的参数</param>
        /// <param name="sHead">请求头</param>
        /// <param name="postType">请求类型，0：application/x-www-form-urlencoded，1：application/json，2：text/xml</param>
        public static string RawPost(string sUrl, string sBody, Dictionary<string, string> sHead = null, int? postType = 0, int iTimeoutSeconds=30)
        {

            string sResult = string.Empty;
            string sError = string.Empty;
            string sResponseStatusCode = string.Empty;
            string sResponseStatusDescription = string.Empty;

            HttpWebResponse oHttpWebResponse = null;
            HttpWebRequest oHttpWebRequest = null;
            Stream oStream = null;
            StreamReader oStreamReader = null;

            byte[] bytes = Encoding.UTF8.GetBytes(sBody);


            try
            {
                oHttpWebRequest = (HttpWebRequest)WebRequest.Create(sUrl);
                oHttpWebRequest.KeepAlive = false;
                oHttpWebRequest.Method = "POST";
                switch(postType)
                {
                    case 0:
                        oHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
                        break;
                    case 1:
                        oHttpWebRequest.ContentType = "application/json";
                        break;
                    case 2:
                        oHttpWebRequest.ContentType = "text/xml";
                        break;
                    default:
                        oHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
                        break;
                }
                
                oHttpWebRequest.ContentLength = bytes.Length;

                //添加请求头
                if (sHead != null && sHead.Count>0)
                {
                    foreach (var item in sHead)
                    {
                        oHttpWebRequest.Headers.Add(item.Key, item.Value);
                    }
                }

                oHttpWebRequest.Timeout = 1000 * iTimeoutSeconds;

                oStream = oHttpWebRequest.GetRequestStream();
                oStream.Write(bytes, 0, bytes.Length);
                oStream.Close();

                oHttpWebResponse = (HttpWebResponse)oHttpWebRequest.GetResponse();

                oStreamReader = new StreamReader(oHttpWebResponse.GetResponseStream());
                sResponseStatusCode = oHttpWebResponse.StatusCode.ToString();
                sResponseStatusDescription = oHttpWebResponse.StatusDescription;


                sResult = oStreamReader.ReadToEnd();

            }
            catch (Exception ex)
            {
                sError += "!!Error: " + ex.Message + "\r\n";
                sError += "    Message: " + ex.Message + "\r\n";
                sError += "    InnerException: " + ex.InnerException + "\r\n";
                sError += "\r\n";
                sError += "    StackTrace: " + ex.StackTrace + "\r\n";

                Console.WriteLine(sError);
            }
            finally
            {
                oStream = null;
                if (oStream != null)
                {
                    oStream.Close();
                }
                if (oHttpWebRequest != null)
                {
                    oHttpWebRequest.Abort();
                }
                if (oHttpWebResponse != null)
                {
                    oHttpWebResponse.Close();
                }
                if (oStreamReader != null)
                {
                    oStreamReader.Close();
                }
            }
            StringBuilder strLog = new StringBuilder();
            strLog.AppendLine("************************日志 begin*************************");
            strLog.AppendLine("sUrl:" + sUrl);
            strLog.AppendLine("sBody:" + sBody);
            strLog.AppendLine("sResult:" + sResult);
            strLog.AppendLine("sError:" + sError);
            strLog.AppendLine("************************日志 end**************************");

            Logger.WirteMessageLog(strLog.ToString());

            Console.WriteLine(sError);
            return sResult;

        }

    }
}
