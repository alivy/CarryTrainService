using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarryTrainService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CarryLogin”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 CarryLogin.svc 或 CarryLogin.svc.cs，然后开始调试。
    /// <summary>
    /// 登录服务接口逻辑
    /// </summary>
    public class CarryLogin : ICarryLogin
    {
        public void DoWork()
        {

        }

        /// <summary>
        /// 验证码
        /// </summary>
        public void VerificationCode()
        {


        }

        /// <summary>
        /// 登录
        /// </summary>
        public void LogIn()
        {
        }
    }
}
