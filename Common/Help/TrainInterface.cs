using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Help
{
    public class TrainInterface
    {
        /// <summary>
        /// 获取验证码 get请求
        /// https://kyfw.12306.cn/passport/captcha/captcha-image?login_site=E&module=login&rand=sjrand&0.21660476430599007
        /// </summary>
        public const string ObtainVerificationCode = "https://kyfw.12306.cn/passport/captcha/captcha-image?login_site=E&module=login&rand=sjrand&0.21660476430599007";
       
        /// <summary>
        /// 验证验证码 post请求
        /// </summary>
        public const string CheckVerificationCode = "https://kyfw.12306.cn/passport/captcha/captcha-check";

       /// <summary>
       /// 用户登录
       /// </summary>
        public const string UserLogin = "https://kyfw.12306.cn/otn/login/userLogin";
    }
}
