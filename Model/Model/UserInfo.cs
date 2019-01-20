using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    /// <summary>
    /// 登录用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户登录名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户登录密码
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        ///  登录用户联系人信息
        /// </summary>
        public List<ContactInfo> ContactInfo { get; set; }
    }

    /// <summary>
    /// 登录用户联系人信息
    /// </summary>
    public class ContactInfo
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string CardNo { get; set; }
    }
}
