using LiteHelp;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainDAL
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class UserInfoDAl
    {
        /// <summary>
        /// 添加修改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UserInfoInsert(DBUserInfo user)
        {
            string sql = string.Format("SELECT userId,userName,userPwd,Starts FROM UserInfo where userName = '{0}'", user.userName);
            var sqlfrist = DBHelp.ExecuteScalar(sql);
            if (sqlfrist == 0)
            {
                user.userId = Guid.NewGuid().ToString();
                sql = string.Format(@"INSERT INTO UserInfo (userId,userName,userPwd,Starts) VALUES ('{0}','{1}','{2}',{3})", user.userId, user.userName, user.userPwd, user.Starts);
            }
            else
            {
                user.userId = Guid.NewGuid().ToString();
                sql = string.Format(@" update set userPwd = '{0}',Starts='{1}' from UserInfo where  userName = '{2}' ", user.userPwd, user.Starts, user.userName);
            }
            return SqliteHelper.ExecuteNonQuery(sql, null);
        }

        /// <summary>
        /// 查询用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<DBUserInfo> UserInfoQuery(string where = "")
        {
            string sql = "SELECT userId,userName,userPwd,Starts FROM UserInfo ";
            if (!string.IsNullOrEmpty(where))
            {
                sql = sql + (where.ToUpper().Contains(where.ToUpper()) ? "" : " where 1=1 ") + where;
            }
            var userTable = SqliteHelper.GetDataTable(sql, null);
            var list = (from p in userTable.AsEnumerable()  //这个list是查出全部的用户评论  
                        select new DBUserInfo
                        {
                            userId = p.Field<string>("userId"), //p.Filed<int>("Id") 其实就是获取DataRow中ID列。即：row["ID"]  
                            userName = p.Field<string>("userName"),
                            userPwd = p.Field<string>("userPwd"),
                            Starts = p.Field<int>("Starts")
                        }).ToList(); //将这个集合转换成list  
            return list;
        }
    }
}
