using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    /// <summary>
    /// 提交订单的Referer参数
    /// </summary>
    public class SubmitOrderReferer
    {
        /// <summary>
        /// 车票类型
        /// </summary>
        public string linktypeid { get; set; }

        /// <summary>
        /// 出发信息
        /// </summary>
        public string fs { get; set; }

        /// <summary>
        /// 到达信息
        /// </summary>
        public string ts { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string flag { get; set; }

    }


}
