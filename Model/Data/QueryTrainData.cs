using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Model.Data
{
    [Serializable]
    public class QueryTrainData
    {
        //"data":[{"queryLeftNewDTO":{"train_no":"640000K26808","station_train_code":"K268","start_station_telecode":"HHQ","start_station_name":"怀化","end_station_telecode":"BJP","end_station_name":"北京","from_station_telecode":"JIQ","from_station_name":"吉首","to_station_telecode":"BJP","to_station_name":"北京","start_time":"10:51","arrive_time":"12:12","day_difference":"1","train_class_name":"","lishi":"25:21","canWebBuy":"N","lishiValue":"1521","yp_info":"1020603000405820000010206000003036500000","control_train_day":"20991231","start_train_date":"20141006","seat_feature":"W3431333","yp_ex":"10401030","train_seat_feature":"3","seat_types":"1413","location_code":"Q7","from_station_no":"03","to_station_no":"22","control_day":19,"sale_time":"1800","is_support_card":"0","gg_num":"--","gr_num":"--","qt_num":"--","rw_num":"*","rz_num":"--","tz_num":"--","wz_num":"*","yb_num":"--","yw_num":"*","yz_num":"*","ze_num":"--","zy_num":"--","swz_num":"--"},"secretStr":"","buttonTextInfo":"18点起售"}],
        public object queryLeftNewDTO { get; set; }
        public string secretStr { get; set; }
        public string buttonTextInfo { get; set; }

        public DetailData QueryLeftNewDTO
        {
            get
            {
                DetailData data = null;
                if (this.queryLeftNewDTO != null && this.queryLeftNewDTO.ToString() != string.Empty)
                {
                    data = JsonConvert.DeserializeObject<DetailData>(this.queryLeftNewDTO.ToString());
                }
                return data;
            }
        }

        [Serializable]
        public class DetailData
        {
            /// <summary>
            /// 车次编号id
            /// </summary>
            public string trainId { get; set; }

            /// <summary>
            /// 操作描述
            /// 如 ：预定
            /// </summary>
            public string operat_remark { get; set; }

            /// <summary>
            /// 完整车次编号
            /// </summary>
            public string complete_train_no { get; set; }

            /// <summary>
            /// 车次编号
            /// </summary>
            public string train_no { get; set; }
            /// <summary>
            /// 车次起始站点编号
            /// </summary>
            public string start_station_telecode { get; set; }
            public string start_station_name { get; set; }
            /// <summary>
            /// 车次终点站点编号
            /// </summary>
            public string end_station_telecode { get; set; }
            public string end_station_name { get; set; }
            /// <summary>
            /// 购票出发站编号
            /// </summary>
            public string from_station_telecode { get; set; }
            /// <summary>
            /// 购票出发站点名称
            /// </summary>
            public string from_station_name { get; set; }
            /// <summary>
            ///  购票目的站点编号
            /// </summary>
            public string to_station_telecode { get; set; }
            /// <summary>
            /// 购票目的站点名称
            /// </summary>
            public string to_station_name { get; set; }
            /// <summary>
            /// 出发时间
            /// </summary>
            public string start_time { get; set; }
            /// <summary>
            /// 到达时间
            /// </summary>
            public string arrive_time { get; set; }
            /// <summary>
            /// 经历时间
            /// </summary>
            public string lishi { get; set; }
            /// <summary>
            /// 是否跨天
            /// "Y" 是 "N" 否 
            /// </summary>
            public string cross_days { get; set; }

            /// <summary>
            /// 跨天描述
            /// 其实我也不知道干啥的
            /// </summary>
            public string cross_days_reamrk { get; set; }

            /// <summary>
            /// 出发日期
            /// </summary>
            public string departure_date { get; set; }

            public DateTime StartTrainDate
            {
                get
                {
                    DateTime train_date = DateTime.Now;
                    if (!string.IsNullOrEmpty(this.start_time) && this.start_time.Length == 8)
                    {
                        int year = int.Parse(this.start_time.Substring(0, 4));
                        int month = int.Parse(this.start_time.Substring(4, 2));
                        int day = int.Parse(this.start_time.Substring(6, 2));
                        train_date = new DateTime(year, month, day);
                    }
                    return train_date;
                }
            }

            /// <summary>
            /// 高级软卧
            /// </summary>
            public string gr_num { get; set; }
            /// <summary>
            /// 其它
            /// </summary>
            public string qt_num { get; set; }
            /// <summary>
            /// 软卧
            /// </summary>
            public string rw_num { get; set; }
            /// <summary>
            /// 软座
            /// </summary>
            public string rz_num { get; set; }        
            /// <summary>
            /// 无座
            /// </summary>
            public string wz_num { get; set; }
            /// <summary>
            /// 动卧
            /// </summary>
            public string dw_num { get; set; }
            /// <summary>
            /// 硬卧
            /// </summary>
            public string yw_num { get; set; }
            /// <summary>
            /// 硬座
            /// </summary>
            public string yz_num { get; set; }
            /// <summary>
            /// 二等座
            /// </summary>
            public string ze_num { get; set; }
            /// <summary>
            /// 一等座
            /// </summary>
            public string zy_num { get; set; }
            /// <summary>
            /// 商务座
            /// </summary>
            public string swz_num { get; set; }

            #region 测试使用
            ///// <summary>
            ///// 测试21
            ///// </summary>
            //public string test_num21 { get; set; }
            ///// <summary>
            ///// 测试22
            ///// </summary>
            //public string test_num22 { get; set; }
            ///// <summary>
            ///// 测试23
            ///// </summary>
            //public string test_num23 { get; set; }
            ///// <summary>
            ///// 测试24
            ///// </summary>
            //public string test_num24 { get; set; }
            ///// <summary>
            ///// 测试25
            ///// </summary>
            //public string test_num25 { get; set; }
            ///// <summary>
            ///// 测试26
            ///// </summary>
            //public string test_num26 { get; set; }
            ///// <summary>
            ///// 测试27
            ///// </summary>
            //public string test_num27 { get; set; }
            ///// <summary>
            ///// 测试28
            ///// </summary>
            //public string test_num28 { get; set; }
            ///// <summary>
            ///// 测试29
            ///// </summary>
            //public string test_num29 { get; set; }
            ///// <summary>
            ///// 测试30
            ///// </summary>
            //public string test_num30 { get; set; }
            ///// <summary>
            ///// 测试31
            ///// </summary>
            //public string test_num31 { get; set; }
            ///// <summary>
            ///// 测试32
            ///// </summary>
            //public string test_num32 { get; set; }
            ///// <summary>
            ///// 测试33
            ///// </summary>
            //public string test_num33 { get; set; }
            ///// <summary>
            ///// 测试34
            ///// </summary>
            //public string test_num34 { get; set; }
            #endregion
        }

        /// <summary>
        /// 用户展示数据
        /// </summary>
        public class DetailDataAction
        {
            /// <summary>
            /// 车次编号id
            /// </summary>
            public string TrainId { get; set; }

            /// <summary>
            /// 操作描述
            /// 如 ：预定
            /// </summary>
            public string OperatRemark { get; set; }

            /// <summary>
            /// 车次编号
            /// </summary>
            public string TrainNo { get; set; }
            /// <summary>
            /// 车次起始站点编号
            /// </summary>
            public string StartStationTelecode { get; set; }
            ///// <summary>
            ///// 车次起始站点名称
            ///// </summary>
            //public string StartStationName { get; set; }
            /// <summary>
            /// 车次终点站点编号
            /// </summary>
            public string EndStationTelecode { get; set; }
            ///// <summary>
            ///// 车次终点站点名称
            ///// </summary>
            //public string EndStationName { get; set; }
            /// <summary>
            /// 购票出发站编号
            /// </summary>
            public string FromStationTelecode { get; set; }
            /// <summary>
            ///  购票目的站点编号
            /// </summary>
            public string ToStationTelecode { get; set; }
            /// <summary>
            /// 出发站到达站
            /// </summary>
            public string FromArrivalsStationName { get; set; }
            /// <summary>
            /// 出发时间-到达时间
            /// </summary>
            public string StartArriveTime { get; set; }
            /// <summary>
            /// 经历时间
            /// </summary>
            public string lishi { get; set; }
            /// <summary>
            /// 是否跨天
            /// "Y" 是 "N" 否 
            /// </summary>
            public string CrossDays { get; set; }

            /// <summary>
            /// 出发日期
            /// </summary>
            public string DepartureDate { get; set; }

            /// <summary>
            /// 高级软卧
            /// </summary>
            public string gr_num { get; set; }
            /// <summary>
            /// 其它
            /// </summary>
            public string qt_num { get; set; }
            /// <summary>
            /// 软卧
            /// </summary>
            public string rw_num { get; set; }
            /// <summary>
            /// 软座
            /// </summary>
            public string rz_num { get; set; }
            /// <summary>
            /// 无座
            /// </summary>
            public string wz_num { get; set; }
            /// <summary>
            /// 动卧
            /// </summary>
            public string dw_num { get; set; }
            /// <summary>
            /// 硬卧
            /// </summary>
            public string yw_num { get; set; }
            /// <summary>
            /// 硬座
            /// </summary>
            public string yz_num { get; set; }
            /// <summary>
            /// 二等座
            /// </summary>
            public string ze_num { get; set; }
            /// <summary>
            /// 一等座
            /// </summary>
            public string zy_num { get; set; }
            /// <summary>
            /// 商务座
            /// </summary>
            public string swz_num { get; set; }
        }
    }
}
