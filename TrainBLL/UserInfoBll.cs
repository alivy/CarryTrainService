using Model.Model;
using System;
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
