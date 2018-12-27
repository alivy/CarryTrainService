using Common;
using Common.Help;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainBLL
{
    /// <summary>
    /// 登陆逻辑
    /// </summary>
    public class LoginBll
    {

        public ResponseLogin PostLogin(string loginName, string loginPwd)
        {
            RequestPackage request = new RequestPackage();
            request.Params.Add("username", System.Web.HttpUtility.UrlEncode(loginName));
            request.Params.Add("password", System.Web.HttpUtility.UrlEncode(loginPwd));
            request.Params.Add("appid", System.Web.HttpUtility.UrlEncode("otn"));
            request.RequestURL = "/passport/web/login";
            request.RefererURL = "/otn/login/init";
            request.Method = "post";
            ArrayList list = TrainHttpContext.Send(request);
            if (list.Count == 2)
            {
                string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
                ResponseLogin package = JsonConvert.DeserializeObject<ResponseLogin>(jsonResult);
                if (package.status_code == 200)
                {
                    if (package.result_code != 0)
                    {
                        PostUamtk();
                        Log.Write(LogLevel.Info, package.result_message);
                    }
                }
                Log.Write(LogLevel.Info, jsonResult);
                return package;
                // GetValidateCode();
            }
            else
            {
                Log.Write(LogLevel.Info, list.ToString());
            }
            return null;
        }

        public void PostUamtk()
        {
            RequestPackage request = new RequestPackage();
            request.RequestURL = "/passport/web/auth/uamtk";
            request.RefererURL = "/otn/login/init";
            request.Method = "post";
            ArrayList list = TrainHttpContext.Send(request);

            string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
            ResponseUamtk package = JsonConvert.DeserializeObject<ResponseUamtk>(jsonResult);
            if (package.status_code == 200)
            {
                if (package.result_code != 0)
                {
                    PostUamtk();
                    Log.Write(LogLevel.Info, package.result_message);
                }
            }
            Log.Write(LogLevel.Info, jsonResult);
        }

        public void PostUamauthClient()
        {
            RequestPackage request = new RequestPackage();
            request.RequestURL = "/otn/uamauthclient";
            request.RefererURL = "/otn/passport?redirect=/otn/login/userLogin";
            request.Method = "post";
            ArrayList list = TrainHttpContext.Send(request);

            string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
            ResponseUamtk package = JsonConvert.DeserializeObject<ResponseUamtk>(jsonResult);
            if (package.status_code == 200)
            {

            }
            Log.Write(LogLevel.Info, jsonResult);
        }

        public void PostConf()
        {
            RequestPackage request = new RequestPackage();
            request.RequestURL = "/otn/login/conf";
            request.RefererURL = "/otn/view/index.html";
            request.Method = "post";
            ArrayList list = TrainHttpContext.Send(request);
            string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
            Log.Write(LogLevel.Info, jsonResult);

        }


        public void PostInitMy12306()
        {
            RequestPackage request = new RequestPackage();
            request.RequestURL = "/otn/index/initMy12306Api";
            request.RefererURL = "/otn/view/index.html";
            request.Method = "post";
            ArrayList list = TrainHttpContext.Send(request);
            string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
            Log.Write(LogLevel.Info, jsonResult);
        }

        /// <summary>
        /// 验证验证码
        /// </summary>
        public ResponseCaptchaCheck PostCaptchaCheck(string point)
        {
            ResponseCaptchaCheck package = null;
            RequestPackage request = new RequestPackage();
            request.Params.Add("answer", System.Web.HttpUtility.UrlEncode(point));
            request.Params.Add("login_site", System.Web.HttpUtility.UrlEncode("E"));
            request.Params.Add("rand", System.Web.HttpUtility.UrlEncode("sjrand"));
            request.RequestURL = "/passport/captcha/captcha-check";
            request.RefererURL = "/otn/login/init";
            request.Method = "post";
            ArrayList list = TrainHttpContext.Send(request);
            if (list.Count == 2)
            {
                string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
                package = JsonConvert.DeserializeObject<ResponseCaptchaCheck>(jsonResult);
                if (package.status_code == 200)
                {

                }
                Log.Write(LogLevel.Info, jsonResult);

            }
            return package;
        }

        /// <summary>
        /// 验证码坐标点
        /// </summary>
        /// <param name="ss"></param>
        /// <returns></returns>
        public string getPoint(int[] ss)
        {
            string xy = string.Empty;
            foreach (var pic in ss)
            {
                if (pic == 1)
                    xy += "30,40,";
                if (pic == 2)
                    xy += "110,45,";
                if (pic == 3)
                    xy += "190,45,";
                if (pic == 4)
                    xy += "250,42,";
                if (pic == 5)
                    xy += "40,110,";
                if (pic == 6)
                    xy += "112,120,";
                if (pic == 7)
                    xy += "190,120,";
                if (pic == 8)
                    xy += "265,114,";
            }
            xy = xy.TrimEnd(',');
            return xy;
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        public Tuple<bool, string> GetValidateCode(string url)
        {
            var status = false;
            string path = string.Empty;
            try
            {
                RequestPackage request = new RequestPackage("/otn/login/init");
                ArrayList list = TrainHttpContext.GetHtmlData(request);
                if (list.Count == 3)
                {
                    request.RequestURL = "/passport/captcha/captcha-image";
                    request.Params.Add("login_site", "E");
                    request.Params.Add("module", "login");
                    request.Params.Add("rand", "sjrand");
                    request.Params.Add("0.21660476430599007", "");
                    using (Stream stream = TrainHttpContext.DownloadCode(request))
                    {
                        path = list[2] + ".png";
                        status = this.SaveValidateCode(stream, Path.Combine(url, path));
                    }
                }
                else
                {
                    Log.Write(LogLevel.Info, "请求/otn/login/init失败");
                }
            }
            catch (Exception ex)
            {
                Log.Write(LogLevel.Error, ex.Message, ex);
            }
            return new Tuple<bool, string>(status, path);
        }

        /// <summary>
        ///保存验证码
        /// </summary>
        public bool SaveValidateCode(Stream stream, string url)
        {
            var result = false;
            try
            {
                if (stream == null)
                {
                    Log.Write(LogLevel.Info, "获取验证码失败");
                }
                //var mappath = Server.MapPath("../" + url);
                var img = Image.FromStream(stream);
                img.Save(url, ImageFormat.Bmp);
                result = true;
            }
            catch (Exception ex)
            {
                Log.Write(LogLevel.Error, "获取验证码失败", ex);
            }
            return result;
        }
    }
}
