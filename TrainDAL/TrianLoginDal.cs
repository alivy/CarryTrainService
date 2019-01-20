using Common;
using Common.Help;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainDAL
{
    public class TrianLoginDal
    {

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
            request.Params.Add("username", loginName);
            request.Params.Add("password", loginPwd);
            request.Params.Add("appid", "otn");
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
    }
}
