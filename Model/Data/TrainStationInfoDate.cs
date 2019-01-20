using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    /// <summary>
    /// 火车站点信息
    /// </summary>
    public class TrainStationInfoDate
    {
        /// <summary>
        /// 车次
        /// </summary>
        public string TrainNo { get; set; }

        /// <summary>
        /// 出发站点简写
        /// </summary>
        public string TrafromStationTelecodeinNo { get; set; }

        /// <summary>
        /// 目的站点简写
        /// </summary>
        public string ToStationTelecode { get; set; }


        /// <summary>
        /// 日期
        /// </summary>
        public string DepartDate { get; set; }


    }
}
