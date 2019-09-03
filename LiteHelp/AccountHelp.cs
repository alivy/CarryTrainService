using LiteHelp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteHelp
{
    /// <summary>
    /// 账户帮助类
    /// </summary>
    public class AccountHelp
    {

        /// <summary>
        /// 测试账号
        /// </summary>
        public static Dictionary<string, UserInfo> UserDictionary = new Dictionary<string, UserInfo>()
        {
             { "test",new UserInfo{UserName ="GLC1972092732",UserPwd="GLC969395" }},
             { "严浩淼",new UserInfo{UserName ="17620372030",UserPwd="yanhaomiao123" }},
             { "李惟",new UserInfo{UserName ="lbwei520",UserPwd="lw423108" }},
             { "孙柯",new UserInfo{UserName ="18871512430",UserPwd="sk323577" }},
             { "严柱权",new UserInfo{UserName ="17683988920",UserPwd="Yan0920.." }}
        };
    }
}
