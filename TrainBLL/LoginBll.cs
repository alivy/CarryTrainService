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
        #region 登陆逻辑
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="loginPwd"></param>
        /// <param name="jsonResult"></param>
        /// <returns></returns>
        public ResponseLogin PostLogin(string loginName, string loginPwd, out string jsonResult)
        {
            jsonResult = string.Empty;
            ResponseLogin package = null;
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
                jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
                package = JsonConvert.DeserializeObject<ResponseLogin>(jsonResult);
                Log.Write(LogLevel.Info, jsonResult);
            }
            else
            {
                Log.Write(LogLevel.Info, list.ToString());
            }
            return package;
        }



        /// <summary>
        /// 检查登陆状态
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="loginPwd"></param>
        /// <param name="jsonResult"></param>
        /// <returns></returns>
        public ResponseLogin PostCheckUser(out string jsonResult)
        {
            jsonResult = string.Empty;
            ResponseLogin package = null;
            RequestPackage request = new RequestPackage();
            request.Params.Add("_json_att", "");
            request.RequestURL = "/otn/login/checkUser";
            request.RefererURL = "/otn/leftTicket/init";
            request.Method = "post";
            ArrayList list = TrainHttpContext.Send(request);
            if (list.Count == 2)
            {
                jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
                package = JsonConvert.DeserializeObject<ResponseLogin>(jsonResult);
                Log.Write(LogLevel.Info, jsonResult);
            }
            else
            {
                Log.Write(LogLevel.Info, list.ToString());
            }
            return package;
        }



        /// <summary>
        /// 获取tk
        /// </summary>
        public ResponseUamtk PostUamtk(out string jsonResult)
        {
            RequestPackage request = new RequestPackage();
            request.Params.Add("appid", System.Web.HttpUtility.UrlEncode("otn"));
            request.RequestURL = "/passport/web/auth/uamtk";
            request.RefererURL = "/otn/passport?redirect=/otn/login/userLogin";
            request.Method = "post";
            ArrayList list = TrainHttpContext.Send(request);
            jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
            ResponseUamtk package = JsonConvert.DeserializeObject<ResponseUamtk>(jsonResult);
            Log.Write(LogLevel.Info, jsonResult);
            return package;
        }


        /// <summary>
        /// 获取apptk
        /// </summary>
        /// <param name="tk"></param>
        public ResponseUamauthClient PostUamauthClient(string tk, out string jsonResult)
        {
            RequestPackage request = new RequestPackage();
            request.Params.Add("tk", System.Web.HttpUtility.UrlEncode(tk));
            request.RequestURL = "/otn/uamauthclient";
            request.RefererURL = "/otn/passport?redirect=/otn/login/userLogin";
            request.Method = "post";
            ArrayList list = TrainHttpContext.Send(request);

            jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
            ResponseUamauthClient package = JsonConvert.DeserializeObject<ResponseUamauthClient>(jsonResult);
            Log.Write(LogLevel.Info, jsonResult);
            return package;
        }

        /// <summary>
        /// 请求conf
        /// </summary>
        /// <returns></returns>
        public string PostConf()
        {
            RequestPackage request = new RequestPackage();
            request.RequestURL = "/otn/login/conf";
            request.RefererURL = "/otn/view/index.html";
            request.Method = "post";
            ArrayList list = TrainHttpContext.Send(request);
            string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
            Log.Write(LogLevel.Info, jsonResult);
            return jsonResult;
        }

        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public string PostInitMy12306()
        {
            RequestPackage request = new RequestPackage();
            request.RequestURL = "/otn/index/initMy12306Api";
            request.RefererURL = "/otn/view/index.html";
            request.Method = "post";
            ArrayList list = TrainHttpContext.Send(request);
            string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
            Log.Write(LogLevel.Info, jsonResult);
            return jsonResult;
        }

        #endregion

        #region 验证码逻辑
        /// <summary>
        /// 验证验证码
        /// </summary>
        public ResponseCaptchaCheck PostCaptchaCheck(string point, out string jsonResult)
        {
            jsonResult = string.Empty;
            ResponseCaptchaCheck package = null;
            RequestPackage request = new RequestPackage();
            try
            {

                request.Params.Add("answer", System.Web.HttpUtility.UrlEncode(point));
                request.Params.Add("login_site", System.Web.HttpUtility.UrlEncode("E"));
                request.Params.Add("rand", System.Web.HttpUtility.UrlEncode("sjrand"));
                request.RequestURL = "/passport/captcha/captcha-check";
                request.RefererURL = "/otn/login/init";
                request.Method = "post";
                ArrayList list = TrainHttpContext.Send(request);
                if (list.Count == 2)
                {
                    jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
                    package = JsonConvert.DeserializeObject<ResponseCaptchaCheck>(jsonResult);
                    Log.Write(LogLevel.Info, jsonResult);
                }
            }
            catch (Exception)
            {
                package.result_message = "验证错误";
                package.status_code = 0000;
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
        public Tuple<int, string, Stream> GetValidateCode()
        {
            var code = 888;
            string imgName = string.Empty;
            Stream stream = null;
            try
            {
                //RequestPackage request = new RequestPackage("/otn/login/init");
                //ArrayList list = TrainHttpContext.GetHtmlData(request);
                //if (list.Count == 3)
                //{
                RequestPackage request = new RequestPackage();
                request.RequestURL = "/passport/captcha/captcha-image";
                request.Params.Add("login_site", "E");
                request.Params.Add("module", "login");
                request.Params.Add("rand", "sjrand");
                request.Params.Add("0.21660476430599007", "");
                imgName = Guid.NewGuid().ToString() + ".png";
                stream = TrainHttpContext.DownloadCode(request);
                string url = @"..\Material\Img\code";
                SaveValidateCode(stream, url);
                //}
                //else
                //{
                //    Log.Write(LogLevel.Info, "请求/otn/login/init失败");
                //}
            }
            catch (Exception ex)
            {
                Log.Write(LogLevel.Error, ex.Message, ex);
            }
            return new Tuple<int, string, Stream>(code, imgName, stream);
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
        #endregion
    }
}
