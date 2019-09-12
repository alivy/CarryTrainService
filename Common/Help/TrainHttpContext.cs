using Model;
using Model.Data;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Common.Help
{

    public static class TrainHttpContext
    {
        #region 变量
        private const char PARAM_SIGN = '&';
        public static string HOST_URL = "https://kyfw.12306.cn";
        public static string callback = string.Empty;
        public static CookieContainer Cookie = new CookieContainer();
        #endregion

        #region 方法
        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="package">数据包</param>
        /// <returns></returns>
        public static ArrayList GetHtmlData(RequestPackage package)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            ArrayList list = new ArrayList();
            string url = HOST_URL + package.RequestURL;
            if (package.Params.Count > 0)
                url = string.Format("{0}?{1}", url, JoinParams(package.Params));
            request = WebRequest.Create(url) as HttpWebRequest;
            //属性配置
            request.AllowWriteStreamBuffering = true;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.MaximumResponseHeadersLength = -1;
            request.Accept = "image/png, image/svg+xml, image/*;q=0.8, */*;q=0.5";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; MALCJS; rv:11.0) like Gecko";
            request.Method = EHttpMethod.Get.ToString();
            request.Headers.Add("Accept-Language", "zh-Hans-CN,zh-Hans;q=0.5");
            //request.Headers.Add("Accept-Encoding", "gzip,deflate");//此处添加后需要解码接收数据
            request.KeepAlive = true;
            request.CookieContainer = Cookie;
            try
            {
                //获取服务器返回的资源
                using (response = (HttpWebResponse)request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    if (response.Cookies.Count > 0)
                    {
                        Cookie.Add(response.Cookies);
                    }
                    //Cookie.Add(response.Cookies);
                    //保存Cookies
                    list.Add(Cookie);
                    list.Add(reader.ReadToEnd());
                    list.Add(Guid.NewGuid().ToString());//图片名
                }
            }
            catch (WebException ex)
            {
                list.Clear();
                list.Add("发生异常/n/r");
                WebResponse wr = ex.Response;
                using (Stream st = wr.GetResponseStream())
                using (StreamReader sr = new StreamReader(st, Encoding.Default))
                {
                    list.Add(sr.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                list.Clear();
                list.Add("5");
                list.Add("发生异常：" + ex.Message);
            }
            return list;
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        public static Stream DownloadCode(RequestPackage package)
        {
            Stream stream = null;
            string url = HOST_URL + package.RequestURL;
            if (package.Params.Count > 0)
                url = string.Format("{0}?{1}", url, JoinParams(package.Params));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //属性配置
            request.AllowWriteStreamBuffering = true;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.MaximumResponseHeadersLength = -1;
            request.Accept = "image/png, image/svg+xml, image/*;q=0.8, */*;q=0.5";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; MALCJS; rv:11.0) like Gecko";
            request.Method = EHttpMethod.Get.ToString();
            request.Headers.Add("Accept-Language", "zh-Hans-CN,zh-Hans;q=0.5");
            request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.KeepAlive = true;
            request.CookieContainer = Cookie;
            try
            {
                //获取服务器返回的资源
                using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream st = webResponse.GetResponseStream())
                    {
                        if (webResponse.Cookies.Count > 0)
                        {
                            Cookie.Add(webResponse.Cookies);
                        }
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
            catch (WebException)
            {
                stream = null;
            }
            catch (Exception)
            {
                stream = null;
            }
            return stream;
        }


        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        public static ArrayList Send(RequestPackage package)
        {
           
            ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
            ArrayList list = new ArrayList();
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            string url = HOST_URL + package.RequestURL;
            string method = package.Method.ToString().ToLower();
            if (package.Method.ToLower() == EHttpMethod.Get.ToString().ToLower())
            {

                if (package.Params.Count > 0)
                    url = string.Format("{0}?{1}", url, JoinParams(package.Params));
                request = WebRequest.Create(url) as HttpWebRequest;
                request.Accept = package.Accept;
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; MALCJS; rv:11.0) like Gecko";
                request.CookieContainer = Cookie;
                request.Referer = HOST_URL + package.RefererURL;
                request.Method = method;
                request.Host = "kyfw.12306.cn";

            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                string data = JoinParams(package.Params);
                byte[] b = package.Encoding.GetBytes(data);
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Accept = package.Accept;
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; MALCJS; rv:11.0) like Gecko";
                request.CookieContainer = Cookie;
                request.Referer = HOST_URL + package.RefererURL;
                request.Method = method;
                request.ContentLength = b.Length;
                request.KeepAlive = true;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(b, 0, b.Length);
                }
            }
            try
            {
                //获取服务器返回的资源
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        if (response.Cookies.Count > 0)
                        {
                            Cookie.Add(response.Cookies);
                        }
                        list.Add(Cookie);
                        var cookie = GetAllCookies(Cookie);
                        List<byte> dataList = new List<byte>();
                        while (true)
                        {
                            int data = stream.ReadByte();
                            if (data == -1)
                                break;
                            dataList.Add((byte)data);
                        }
                        list.Add(dataList.ToArray());
                    }
                }
            }
            catch (WebException wex)
            {
                WebResponse wr = wex.Response;
                using (Stream st = wr.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(st, System.Text.Encoding.UTF8))
                    {
                        list.Add(sr.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                list.Add("发生异常/n/r" + ex.Message);
            }
            return list;
        }


        public static List<Cookie> GetAllCookies(CookieContainer cookie)
        {
            List<Cookie> lstCookies = new List<Cookie>();
            Hashtable table = (Hashtable)cookie.GetType().InvokeMember("m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                System.Reflection.BindingFlags.Instance, null, cookie, new object[] { });

            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                    | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies)
                        lstCookies.Add(c);
            }
            return lstCookies;
        }
        #endregion

        #region Private Methods
        private static string JoinParams(Dictionary<string, string> param)
        {
            StringBuilder data = new StringBuilder();
            if (param != null && param.Count > 0)
            {
                string lastKey = param.Keys.Last();
                foreach (string key in param.Keys)
                {
                    string value = param[key];
                    string str = string.IsNullOrWhiteSpace(value) ? $"{key}" : $"{key}={value}";
                    data.AppendFormat(str);
                    if (key.Equals("callback"))
                        callback = value;
                    if (key != lastKey)
                        data.Append(PARAM_SIGN);
                }
            }
            return data.ToString();
        }
        #endregion


    }



    public class TrainHttp
    {

        static CookieContainer cookie = new CookieContainer();
        //回调验证证书问题
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            // 总是接受    
            return true;
        }

        /// <summary>
        /// get请求（有证书验证）
        /// </summary>
        /// <param name="Url">URL</param>
        /// <returns></returns>
        public static string GetValidhtmlByGet(string Url)
        {
            HttpWebRequest webRequest;
            HttpWebResponse webResponse;
            try
            {
                //这一句一定要写在创建连接的前面。使用回调的方法进行证书验证。
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                ServicePointManager.CheckCertificateRevocationList = true;

                webRequest = (HttpWebRequest)WebRequest.Create(Url);
                webRequest.Method = "GET";
                webRequest.Accept = "*/*";

                // 获取对应HTTP请求的响应
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                // 获取响应流
                Stream responseStream = webResponse.GetResponseStream();
                // 对接响应流(以"utf-8"字符集)
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string result = reader.ReadToEnd();
                reader.Close();
                return result;

            }
            catch (Exception ex)
            {
                return "";
            }


        }

        /// <summary>
        /// 获取文件流
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static Stream GetStreamByGet(string Url)
        {
            HttpWebRequest webRequest;
            HttpWebResponse webResponse;
            cookie = new CookieContainer();
            try
            {
                //这一句一定要写在创建连接的前面。使用回调的方法进行证书验证。
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                ServicePointManager.CheckCertificateRevocationList = true;

                webRequest = (HttpWebRequest)WebRequest.Create(Url);
                webRequest.Method = "GET";
                webRequest.Accept = "*/*";
                webRequest.CookieContainer = cookie;
                // 获取对应HTTP请求的响应
                webResponse = (HttpWebResponse)webRequest.GetResponse();

                // 获取响应流
                Stream responseStream = webResponse.GetResponseStream();
                return responseStream;


            }
            catch (Exception ex)
            {
                return null;
            }


        }

        ///<summary>
        ///post请求（有证书验证）
        ///</summary>
        ///<param name="URL">url地址</param>
        ///<param name="strPostdata">发送的数据</param>
        ///<returns></returns>
        public static string GetValidhtmlByPost(string url, string strPostData)
        {
            HttpWebRequest webRequest;
            HttpWebResponse webResponse;
            try
            {
                // 这一句一定要写在创建连接的前面。使用回调的方法进行证书验证。
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                ServicePointManager.CheckCertificateRevocationList = true;

                webRequest = (HttpWebRequest)HttpWebRequest.Create(url);

                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.KeepAlive = true;
                webRequest.CookieContainer = cookie;


                byte[] buffer = Encoding.UTF8.GetBytes(strPostData);
                webRequest.ContentLength = buffer.Length;
                webRequest.GetRequestStream().Write(buffer, 0, buffer.Length);

                webResponse = (HttpWebResponse)webRequest.GetResponse();
                StreamReader reader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8);
                string result = reader.ReadToEnd();
                return result;
            }
            catch (Exception ex)
            {

                return ex.Message;

            }
        }

        public static bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }


    [Flags]
    public enum EHttpMethod : uint
    {
        Post = 0,
        Get = 1,
    }
}

