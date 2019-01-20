using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.TrainRequest
{
    public class TrainReqBase
    {
        /// <summary>
        /// 接入平台标识
        /// </summary>
        public string platform { get; set; }

        /// <summary>
        /// 请求时间戳
        /// </summary>
        public long timestamp { get; set; }


        /// <summary>
        /// 验证字符串
        /// </summary>
        public int verifyStr { get; set; }

        /// <summary>
        /// 接口名称
        /// </summary>
        public int serviceName { get; set; }
    }
}
