using System.Collections;
using System.Linq;
using System.Text;
using CarryTrainWeb.Models;
using Common;
using Common.Help;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Service.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserInfo user = new UserInfo();
            user.loginName = "17620372030";
            user.loginPwd = "yanhaomiao123";
            PostLogin(user);
        }


        [TestMethod]
        public void TestPostCaptchaCheck()
        {
            PostCaptchaCheck();
        }



        public void PostLogin(UserInfo user)
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
                if (package.status_code == 200)
                {
                    if (package.result_code != 0)
                    {
                        PostUamtk();
                        Log.Write(LogLevel.Info, package.result_message);
                    }
                }
                Log.Write(LogLevel.Info, jsonResult);

                // GetValidateCode();
            }
            else
            {
                Log.Write(LogLevel.Info, list.ToString());
            }
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
        /// 验证码
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
            if (list.Count == 2)
            {
                string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
                ResponseUamtk package = JsonConvert.DeserializeObject<ResponseUamtk>(jsonResult);
                if (package.status_code == 200)
                {

                }
                Log.Write(LogLevel.Info, jsonResult);
            }
        }

    }
}
