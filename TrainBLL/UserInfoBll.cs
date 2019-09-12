using Common;
using Common.Help;
using Model;
using Model.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainDAL;

namespace TrainBLL
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public class UserInfoBll
    {
        public UserInfoDAl dal;
        public UserInfoBll()
        {
            dal = new UserInfoDAl();
        }
        /*
        请求顺序说明：
        1.请求/otn/login/conf
        2.请求/otn/modifyUser/initQueryUserInfoApi
        3.请求/otn/userCommon/allCitys  
        4.请求/otn/userCommon/schoolNames
        */



        /// <summary>
        /// 获取账号人用户信息
        /// </summary>
        /// <returns></returns>
        public void GetUserInfo()
        {
            var response = new ResponsePassenger();
            try
            {
                RequestPackage request = new RequestPackage();
                request.RequestURL = "/otn/modifyUser/initQueryUserInfoApi";
                request.RefererURL = "/otn/view/information.html";
                request.Method = "post";
                request.Params.Add("_json_att", string.Empty);
                ArrayList list = TrainHttpContext.Send(request);
                string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
                response = JsonConvert.DeserializeObject<ResponsePassenger>(jsonResult);
            }
            catch (Exception ex)
            {
                Log.Write(LogLevel.Error, ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取账号人用户信息
        /// </summary>
        /// <returns></returns>
        public void QueryUserInfo()
        {
            var response = new ResponsePassenger();
            try
            {
                RequestPackage request = new RequestPackage();
                request.RequestURL = "/otn/modifyUser/initQueryUserInfoApi";
                request.RefererURL = "/otn/view/information.html";
                request.Method = "post";
                request.Params.Add("_json_att", string.Empty);
                ArrayList list = TrainHttpContext.Send(request);
                string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
                response = JsonConvert.DeserializeObject<ResponsePassenger>(jsonResult);
            }
            catch (Exception ex)
            {
                Log.Write(LogLevel.Error, ex.Message, ex);
            }
        }



        /// <summary>
        /// 获取账号城市对应车站区号信息
        /// </summary>
        /// <returns></returns>
        public void GetAllCitys()
        {
            var response = new ResponsePassenger();
            try
            {
                RequestPackage request = new RequestPackage();
                request.RequestURL = "/otn/modifyUser/initQueryUserInfoApi";
                request.RefererURL = "/otn/view/information.html";
                request.Method = "post";
                request.Params.Add("_json_att", string.Empty);
                ArrayList list = TrainHttpContext.Send(request);
                string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
                //response = JsonConvert.DeserializeObject<ResponsePassenger>(jsonResult);
            }
            catch (Exception ex)
            {
                Log.Write(LogLevel.Error, ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取学校对应车站区号信息
        /// </summary>
        /// <returns></returns>
        public void GetSchoolNames()
        {
            var response = new ResponsePassenger();
            try
            {
                RequestPackage request = new RequestPackage();
                request.RequestURL = "/otn/userCommon/schoolNames";
                request.RefererURL = "/otn/view/information.html";
                request.Method = "post";
                request.Params.Add("_json_att", string.Empty);
                ArrayList list = TrainHttpContext.Send(request);
                string jsonResult = Encoding.UTF8.GetString(list[1] as byte[]);
                //response = JsonConvert.DeserializeObject<ResponsePassenger>(jsonResult);
            }
            catch (Exception ex)
            {
                Log.Write(LogLevel.Error, ex.Message, ex);
            }
        }


        /// <summary>
        /// 添加修改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UserInfoInsert(DBUserInfo user)
        {
            return dal.UserInfoInsert(user);
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<DBUserInfo> UserInfoQuery(string where = "")
        {
            return dal.UserInfoQuery(where);
        }
    }
}
