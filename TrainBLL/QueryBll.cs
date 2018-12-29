using Common;
using Common.Help;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Data.QueryTrainData;

namespace TrainBLL
{
    public class QueryBll
    {
        /// <summary>
        /// 火车票查询
        /// </summary>
        /// <param name="fromStation">出发站</param>
        /// <param name="toStation">到达站</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public ResponseTicketQuery TicketQuery(string fromStation, string toStation, string date, out string jsonString)
        {
            jsonString = string.Empty;
            ResponseTicketQuery reulst = null;
            RequestPackage request = new RequestPackage();
            request.Method = EHttpMethod.Get.ToString();
            request.RefererURL = "/otn/leftTicket/init";
            request.RequestURL = "/otn/leftTicket/queryA";
            request.Params.Add("leftTicketDTO.train_date", date);
            request.Params.Add("leftTicketDTO.from_station", fromStation);
            request.Params.Add("leftTicketDTO.to_station", toStation);
            request.Params.Add("purpose_codes", "ADULT");
            ArrayList list = TrainHttpContext.Send(request);
            jsonString = Encoding.UTF8.GetString(list[1] as byte[]);
            reulst = JsonHelper.Deserialize<ResponseTicketQuery>(jsonString);
            string[] data = null;
            if (reulst.status)
            {
                data = reulst.data.result;

            }
            else if (reulst.messages != null && reulst.messages.Length > 0)
            {
                request.RequestURL = reulst.c_url;
                list = TrainHttpContext.Send(request);
                if (list.Count == 2)
                {
                    data = reulst.data.result;
                }
                Log.Write(LogLevel.Info, reulst.messages);
            }
            foreach (var item in data)
            {
                var r_list = item.Split(new char[] { '|' });
                DetailData detail = new DetailData
                {
                    station_train_code = r_list[3],
                    train_no = r_list[2],
                    start_time = r_list[8],
                    end_time = r_list[9],
                    arrive_time = r_list[10],
                    from_station_name = r_list[6],
                    to_station_name = r_list[7],
                    lishi = r_list[13],
                    //business_seat = r_list[-5],
                    //first_seat = r_list[-6],
                    //second_seat = r_list[-7],
                    gr_num = r_list[-8],
                    rw_num = r_list[-9],
                    //dw = r_list[-10],
                    yw_num = r_list[-11],
                    rz_num = r_list[-12],
                    yz_num = r_list[-13],
                    wz_num = r_list[-14],
                    qt_num = r_list[-15],
                    //remark = r_list[1],
                    seat_types = r_list[-2],
                    from_station_no = r_list[16],
                    to_station_no = r_list[17]
                };
            }
            return reulst;
        }


    }
}
