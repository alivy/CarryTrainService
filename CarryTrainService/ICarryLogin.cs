using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarryTrainService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICarryLogin”。
    [ServiceContract]
    public interface ICarryLogin
    {
        [OperationContract]
        void DoWork();

        /// <summary>
        /// 验证码
        /// </summary>
        [OperationContract]
        void VerificationCode();

        /// <summary>
        /// 登录
        /// </summary>
        [OperationContract]
        void  LogIn();

    }
}
