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
                //真实数据+ 
                url = @"http://www.ihavedream.top/Material/Img/code/" + code.Item2
            };
            return Json(result);
        }

        /// <summary>
        ///  输入坐标验证码验证
        /// </summary>
        /// <param name="point">坐标值</param>
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
                data = check
            };
            return Json(result);
        }


        /// <summary>
        /// 使用指定位置验证码验证
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
        /// 用户登陆
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
                result.data = apptk;
                if (apptk.result_code == 0)
                {
                    result.data = new
                    {
                        apptkdata = apptk,
                        confdata = train.PostConf(),
                        InitMydata = train.PostInitMy12306()
                    };
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

        /// <summary>
        /// 火车票查询
        /// </summary>
        /// <returns></returns>
        public ActionResult PostQuery(string fromStation, string toStation, string date)
        {
            //fromStation = "SZQ";
            //toStation = "WHN";
            //date = "2019-01-06";
            string jsonstring = string.Empty;
            var query = new QueryBll();
            var ticketQuery = query.TicketQuery(fromStation, toStation, date, out jsonstring);
            var json = JsonHelper.Deserialize<object>(jsonstring);
            var result = new ResultModel
            {
                code = ticketQuery.status ? 0 : 888,
                msg = ticketQuery.messages,
                data = json
            };
            return Json(result);
        }


    }
}