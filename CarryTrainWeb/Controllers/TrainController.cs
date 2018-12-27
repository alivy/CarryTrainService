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
using TrainBLL;

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
            LoginBll train = new LoginBll();

            string url = Server.MapPath(@"..\Material\Img\code");
            Log.Write(LogLevel.Info, "文件保存路径" + url);
            var code = train.GetValidateCode(url);
            var obj = new
            {
                status = code.Item1,
                path = @"Material/Img/code/" + code.Item2
            };
            return Json(obj);
        }


        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckCode(string point)
        {
            var train = new LoginBll();
            var check = train.PostCaptchaCheck(point);
            if (check.result_code == 4)
            {
                UserInfo user = new UserInfo();
                user.loginName = "17620372030";
                user.loginPwd = "yanhaomiao123";
                var result = new LoginBll().PostLogin(user.loginName, user.loginPwd);
            }
            var obj = new
            {
                status = check.result_code,
                message = check.result_message
            };
            return Json(obj);
        }






        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckCodePiece(int[] xy)
        {
            var train = new LoginBll();
            string point = train.getPoint(xy);
            var check = train.PostCaptchaCheck(point);
            var obj = new
            {
                status = check.result_code,
                path = check.result_message
            };
            return Json(obj);
        }

        /// <summary>
        /// 登陆信息
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public ResponseLogin PostLogin(UserInfo user)
        {

            ResponseLogin package = null;
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
                package = JsonConvert.DeserializeObject<ResponseLogin>(jsonResult);
                Log.Write(LogLevel.Info, list.ToString());
                //刷新验证码
                //string url = Server.MapPath(@"..\Material\Img\code");
                //new LoginBll().GetValidateCode(url);
            }
            return package;
        }


       
    }
}