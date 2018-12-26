using Common;
using Common.Help;
using Model.Data;
using Newtonsoft.Json;
using System.Collections;
using System.Text;
using Model;

namespace CarryTrainWeb.Models
{
    public class UserInfo
    {
        private PassengerDetail[] _passengers = null;
        /// <summary>
        /// 登陆账号
        /// </summary>
        public string loginName { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string loginPwd { get; set; }

        /// <summary>
        /// 乘客信息
        /// </summary>
        public PassengerDetail[] Passengers
        {
            get
            {
                if (this._passengers == null)
                {
                    RequestPackage request = new RequestPackage();
                    request.RequestURL = "/otn/confirmPassenger/getPassengerDTOs";
                    request.RefererURL = "/otn/confirmPassenger/initDc";
                    request.Method = "post";
                    request.Params.Add("_json_att", string.Empty);
                    ArrayList list = TrainHttpContext.Send(request);
                    if (list.Count == 2)
                    {
                        string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
                        ResponsePassenger response = JsonConvert.DeserializeObject<ResponsePassenger>(jsonResult);
                        if (response.status)
                        {
                            this._passengers = response.Data.Normal_Passengers;
                        }
                    }
                    else
                    {
                        Log.Write(LogLevel.Info, list.ToString());
                    }
                }
                return this._passengers;
            }
        }



    }
}
