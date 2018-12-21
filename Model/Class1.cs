using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 火车票验证码
    /// </summary>
    public class TrainVerificationCode
    {
       /// <summary>
       /// 
       /// </summary>
        public string login_site { get; set; }

        /// <summary>
        /// 模块 、登录
        /// 示例：module: login
        /// </summary>
        public string module { get; set; }

        /// <summary>
        /// 随机数
        /// 示例：rand: sjrand
        /// </summary>
        public string rand { get; set; }

    }




}
