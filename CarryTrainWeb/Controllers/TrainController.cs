using CarryTrainWeb.Models;
using Common;
using Common.Help;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace CarryTrainWeb.Controllers
{
    public class TrainController : Controller
    {
        // GET: Train
        public ActionResult Login()
        {

            return View();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult VerificationCode()
        {
            var code = this.GetValidateCode();
            var obj = new
            {
                status = code.Item1,
                path = code.Item2
            };
            return Json(obj);
        }

       

        /// <summary>
        /// 登陆信息
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public  void PostLogin(UserInfo user)
        {
            RequestPackage request = new RequestPackage();
            request.Params.Add("username", System.Web.HttpUtility.UrlEncode(user.loginName));
            request.Params.Add("password", System.Web.HttpUtility.UrlEncode(user.loginPwd));
            request.Params.Add("appid", System.Web.HttpUtility.UrlEncode("otn"));
            request.RequestURL = "/passport/web/login";
            request.RefererURL = "/otn/login/init";
            request.Method = "post";
            ArrayList list = TrainHttpContext.Send(request);
            if (list.Count == 2)
            {
                string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
                ResponseLogin package = JsonConvert.DeserializeObject<ResponseLogin>(jsonResult);
                if (package.Data != null && package.Data.loginCheck == "Y")
                {
                    UserInfo info = new UserInfo()
                    {
                        loginName = user.loginName,
                        loginPwd = user.loginPwd,
                    };
                }
                else
                {
                    GetValidateCode();
                }
            }
            else
            {
                Log.Write(LogLevel.Info, list.ToString());
            }
        }



      
        #region 验证码
        /// <summary>
        /// 获取验证码
        /// </summary>
        private Tuple<bool, string> GetValidateCode()
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
                        path = Path.Combine(@"Material\Img\code", list[2] + ".png");
                        status = this.SaveValidateCode(stream, path);
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
        private bool SaveValidateCode(Stream stream, string url)
        {
            var result = false;
            try
            {
                if (stream == null)
                {
                    Log.Write(LogLevel.Info, "获取验证码失败");
                }
                var mappath = Server.MapPath("../" + url);
                var img = Image.FromStream(stream);
                img.Save(mappath, ImageFormat.Bmp);
                result = true;
            }
            catch (Exception ex)
            {
                Log.Write(LogLevel.Error, "获取验证码失败", ex);
            }
            return result;
        }





        /// <summary>
        /// 验证验证码
        /// </summary>
        public void PostCaptchaCheck()
        {
            RequestPackage request = new RequestPackage();
            request.Params.Add("answer", System.Web.HttpUtility.UrlEncode("0，258,69,58"));
            request.Params.Add("login_site", System.Web.HttpUtility.UrlEncode("E"));
            request.Params.Add("rand", System.Web.HttpUtility.UrlEncode("sjrand"));
            request.RequestURL = "/passport/captcha/captcha-check";
            request.RefererURL = "/otn/login/init";
            request.Method = "post";
            ArrayList list = TrainHttpContext.Send(request);
            string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
            ResponseUamtk package = JsonConvert.DeserializeObject<ResponseUamtk>(jsonResult);
            if (package.status_code == 200)
            {

            }
            Log.Write(LogLevel.Info, jsonResult);
        }



        #endregion

    }
}