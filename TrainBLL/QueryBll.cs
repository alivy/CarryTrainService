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
        public  ResponseTicketQuery TicketQuery(string fromStation, string toStation, string date, out string jsonString)
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
            if (list.Count == 2)
            {
                jsonString = Encoding.UTF8.GetString(list[1] as byte[]);
               
                reulst = JsonHelper.Deserialize<ResponseTicketQuery>(jsonString);
                if (reulst.status)
                {
                    var data = reulst.data;
                }
                else if (reulst.messages != null && reulst.messages.Length > 0)
                {
                    Log.Write(LogLevel.Info, reulst.messages);
                }
            }
            else
            {
                Log.Write(LogLevel.Error, list.ToString());
            }
            return reulst;
        }


    }
}
