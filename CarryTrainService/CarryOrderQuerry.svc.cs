﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarryTrainService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“CarryOrderQuerry”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 CarryOrderQuerry.svc 或 CarryOrderQuerry.svc.cs，然后开始调试。
    public class CarryOrderQuerry : ICarryOrderQuerry
    {
        public void DoWork()
        {
        }


        /// <summary>
        /// 余票查询
        /// </summary>
        public void SurplusTicketQuery()
        {

        }

        /// <summary>
        /// 购票
        /// </summary>
        public void TicketPurchase()
        {

        }
    }
}
