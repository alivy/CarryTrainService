
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReqSubmitOrder
    {
        /// <summary>
        /// 出行日期
        /// </summary>
        public string fromDate { get; set; }

        /// <summary>
        /// 出发站点简写
        /// </summary>
        public string fromStationShort { get; set; }

        /// <summary>
        /// 到达站点简写
        /// </summary>
        public string toStationShort { get; set; }

        /// <summary>
        /// 下单日期
        /// </summary>
        public string toDate { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

        /// <summary>
        /// dc表示单程车票 wc 往返车票
        /// </summary>
        public string wfdc_flag { get; set; }

        /// <summary>
        /// 出发站点名称
        /// </summary>
        public string fromStationName { get; set; }

        /// <summary>
        /// 到达站点名称
        /// </summary>
        public string toStationName { get; set; }

        /// <summary>
        /// 车次密钥
        /// </summary>
        public string secretStr { get; set; }

        /// <summary>
        /// 乘客类型 ADULT代表成人
        /// </summary>
        public string purpose_codes { get; set; } = "ADULT";

    }
}
