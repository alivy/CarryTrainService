using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CarryTrainService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ICarryOrderQuerry”。
    [ServiceContract]
    public interface ICarryOrderQuerry
    {
        /// <summary>
        /// 余票查询
        /// </summary>
        [OperationContract]
        void SurplusTicketQuery();

        /// <summary>
        /// 购票
        /// </summary>
        [OperationContract]
        void TicketPurchase();
    }
}
