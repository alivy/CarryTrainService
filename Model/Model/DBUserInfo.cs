using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class DBUserInfo
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string  userId { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string userPwd { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public int Starts { get; set; }
    }
}
