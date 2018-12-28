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
            var result = new
            {
                code = code.Item1,
                msg = (code.Item1 == 0) ? "获取图片成功" : "获取图片失败",
                //真实数据+ http://www.ihavedream.top/
                url = @"Material/Img/code/"+code.Item2
            };
            return Json(result);
        }


        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckCode(string point)
        {
            var train = new LoginBll();
            string jsonResult;
            var check = train.PostCaptchaCheck(point, out jsonResult);
            var result = new ResultModel()
            {
                code = check.result_code == 4 ? 0 : check.result_code,
                msg = check.result_message,
                data = jsonResult
            };
            return Json(result);
        }






        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckCodePiece(int[] xy)
        {
            var result = new ResultModel();
            var train = new LoginBll();
            string point = train.getPoint(xy);
            string jsonResult;
            var check = train.PostCaptchaCheck(point, out jsonResult);
            result.code = check.result_code == 4 ? 0 : check.result_code;
            result.msg = check.result_message;
            result.data = jsonResult;
            return Json(result);
        }

        /// <summary>
        /// 登陆信息
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public ActionResult PostLogin(UserInfo user)
        {
            string data = string.Empty;
            var result = new ResultModel();
            var train = new LoginBll();
            do
            {
                var check = UserCheck(user);
                if (check.Item1 != 0)
                {
                    result.code = check.Item1;
                    result.msg = check.Item2;
                    break;
                }

                var login = train.PostLogin(user.loginName, user.loginPwd, out data);
                if (login.result_code != 0)
                {
                    result.code = login.result_code;
                    result.msg = login.result_message;
                    result.data = data;
                    break;
                }

                var tk = train.PostUamtk(out data);
                if (tk.result_code != 0)
                {
                    result.code = tk.result_code;
                    result.msg = tk.result_message;
                    result.data = data;
                    break;
                }

                var apptk = train.PostUamauthClient(tk.newapptk, out data);
                result.code = apptk.result_code;
                result.msg = apptk.result_message;
                result.data = data;
                if (apptk.result_code == 0)
                {
                    var obj = new
                    {
                        apptkdata = data,
                        confdata = train.PostConf(),
                        InitMydata = train.PostInitMy12306()
                    };
                    result.data = JsonHelper.Serialize(obj);
                }
            } while (false);
            return Json(result);
        }

        /// <summary>
        /// 验证账号密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private Tuple<int, string> UserCheck(UserInfo user)
        {
            int status = 0;
            string msg = string.Empty;

            if (string.IsNullOrEmpty(user.loginName))
            {
                status = 888;
                msg = "用户名不为空";
            }
            if (string.IsNullOrEmpty(user.loginPwd))
            {
                status = 888;
                msg = "密码不为空";
            }
            return new Tuple<int, string>(status, msg);
        }


    }
}