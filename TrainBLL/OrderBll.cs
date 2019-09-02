using Common.Help;
using Model;
using System;
using System.Collections;
using System.Text;
namespace TrainBLL
{
    /// <summary>
    /// 订单查询
    /// </summary>
    public class OrderBll
    {
        /// <summary>
        /// 未完成订单查询
        /// </summary      
        public void NoCompleteOrderQuery()
        {
            RequestPackage request = new RequestPackage();
            request.Method = EHttpMethod.Get.ToString();
            request.RefererURL = "/otn/leftTicket/init";
            request.RequestURL = "/otn/queryOrder/queryMyOrderNoComplete";
            request.Params.Add("_json_att=", "");
            ArrayList list = TrainHttpContext.Send(request);
            string jsonString = Encoding.UTF8.GetString(list[1] as byte[]);
            // reulst = JsonHelper.Deserialize<ResponseTicketQuery>(jsonString);
        }

        /// <summary>
        /// 完成订单（未出行）
        /// </summary>
        public void CompleteOrderQuery()
        {
            var data = new DateTime();
            RequestPackage request = new RequestPackage();
            request.Method = EHttpMethod.Get.ToString();
            request.RefererURL = "/otn/leftTicket/init";
            request.RequestURL = "/otn/queryOrder/queryMyOrderNoComplete";
            request.Params.Add("come_from_flag", "my_order");
            request.Params.Add("pageIndex", "0");
            request.Params.Add("pageSize", "8");
            request.Params.Add("query_where", "G");
            request.Params.Add("queryStartDate", DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd"));
            request.Params.Add("queryEndDate", DateTime.Now.ToString("yyyy-MM-dd"));
            request.Params.Add("queryType", "1");
            request.Params.Add("sequeue_train_name", "");
            ArrayList list = TrainHttpContext.Send(request);
            string jsonString = Encoding.UTF8.GetString(list[1] as byte[]);
            // reulst = JsonHelper.Deserialize<ResponseTicketQuery>(jsonString);
        }


        /// <summary>
        /// 下单
        /// </summary>
        public string SubmitOrderRequest()
        {
            RequestPackage request = new RequestPackage();
            request.Method = EHttpMethod.Post.ToString();
            request.RefererURL = "/otn/leftTicket/init";
            request.RequestURL = "/otn/leftTicket/SubmitOrderRequest";
            request.Params.Add("secretStr", @"Qu5jx9JXBEwjz51/MfaCQ/jlpWaXktWs5BQfckDfOC+Q7XLFrmGHZN7+WNFBsJsJciX8bzFpYCRl
            NBeRuWKJn2eYCiV71DRtKBgBmCE4xG0 + 8H5MsZVqfsHNEDJzSySCTjR66gPelEF2JZQJABxSf4BB
            2wXomxWjybsCvl1rYexUKRhK3bn75w3dg5cAPk8Hu8rzhaaQo61clIKUr / utahCInaenh3VHTQo0
            8pMoqOTMHOBd / jlLFeX0NPhlOL5e45jU4uDRXgHNzFixysl / MNeFJ0zUguL42U5iemiRl4o=");
            request.Params.Add("train_date", "2019-03-01");
            request.Params.Add("back_train_date", "2019-03-01");
            request.Params.Add("tour_flag", "wc");
            request.Params.Add("purpose_codes", "ADULT");
            request.Params.Add("query_from_station_name", "武汉");
            request.Params.Add("query_to_station_name", "深圳");
            request.Params.Add("undefined", "");
            ArrayList list = TrainHttpContext.Send(request);
            if (list.Count == 1)
            {
                return Encoding.UTF8.GetString(list[0] as byte[]);
            }
            return Encoding.UTF8.GetString(list[1] as byte[]);
        }

        /// <summary>
        /// 订单验证
        /// </summary>
        public string CheckOrderInfo()
        {
            RequestPackage request = new RequestPackage();
            request.Method = EHttpMethod.Post.ToString();
            request.RefererURL = "/otn/confirmPassenger/initWc";
            request.RequestURL = "/otn/confirmPassenger/checkOrderInfo";
            request.Params.Add("cancel_flag", "2");
            request.Params.Add("bed_level_order_num", "000000000000000000000000000000");
            request.Params.Add("passengerTicketStr", "O,0,1,金曼城,1,360426199801130058,,N");
            request.Params.Add("tour_flag", "wc");
            request.Params.Add("randCode", "2");
            request.Params.Add("whatsSelect", "1");
            request.Params.Add("_json_att", "");
            request.Params.Add("REPEAT_SUBMIT_TOKEN", "6a935f7b30fc20539538d245e07f9f3e");
            ArrayList list = TrainHttpContext.Send(request);
            return Encoding.UTF8.GetString(list[1] as byte[]);
        }


        /// <summary>
        /// 获取队列
        /// </summary>
        public string GetQueueCount()
        {
            RequestPackage request = new RequestPackage();
            request.Method = EHttpMethod.Post.ToString();
            request.RefererURL = "/otn/confirmPassenger/initWc";
            request.RequestURL = "/otn/confirmPassenger/getQueueCount";
            request.Params.Add("train_date", "2019-2-21 00:00:00");
            request.Params.Add("train_no", "4e000G10010C");
            request.Params.Add("stationTrainCode", "G1001");
            request.Params.Add("fromStationTelecode", "WHN");
            request.Params.Add("toStationTelecode", "IOQ");
            request.Params.Add("leftTicket", "onitNgro93bMM2EJQjC%2BzlVcTmI60RkiUCToolBjkTo5AEK6");
            request.Params.Add("purpose_codes", "00");
            request.Params.Add("train_location", "N2");
            request.Params.Add("_json_att", "");
            request.Params.Add("REPEAT_SUBMIT_TOKEN", "6a935f7b30fc20539538d245e07f9f3e");
            ArrayList list = TrainHttpContext.Send(request);
            return Encoding.UTF8.GetString(list[1] as byte[]);
        }


        /// <summary>
        /// 确认提交队列
        /// </summary>
        public string ConfirmGoForQueue()
        {
            RequestPackage request = new RequestPackage();
            request.Method = EHttpMethod.Post.ToString();
            request.RefererURL = "/otn/confirmPassenger/initWc";
            request.RequestURL = "/otn/confirmPassenger/confirmGoForQueue";
            request.Params.Add("train_date", "Thu Feb 21 2019 00:00:00 GMT+0800 (中国标准时间)");
            request.Params.Add("train_no", "4e000G10010C");
            request.Params.Add("stationTrainCode", "G1001");
            request.Params.Add("fromStationTelecode", "WHN");
            request.Params.Add("toStationTelecode", "IOQ");
            request.Params.Add("leftTicket", "onitNgro93bMM2EJQjC%2BzlVcTmI60RkiUCToolBjkTo5AEK6");
            request.Params.Add("purpose_codes", "00");
            request.Params.Add("train_location", "N2");
            request.Params.Add("_json_att", "");
            request.Params.Add("REPEAT_SUBMIT_TOKEN", "6a935f7b30fc20539538d245e07f9f3e");
            ArrayList list = TrainHttpContext.Send(request);
            return Encoding.UTF8.GetString(list[1] as byte[]);
        }


        /// <summary>
        /// 查询订单消息
        /// </summary>
        public string QueryOrderWaitTime()
        {
            RequestPackage request = new RequestPackage();
            request.Method = EHttpMethod.Get.ToString();
            request.RefererURL = "/otn/confirmPassenger/initWc";
            request.RequestURL = "/otn/confirmPassenger/queryOrderWaitTime";
            request.Params.Add("random", "1550542267648");
            request.Params.Add("tourFlag", "wc");
            request.Params.Add("_json_att", "");
            request.Params.Add("REPEAT_SUBMIT_TOKEN", "6a935f7b30fc20539538d245e07f9f3e");
            ArrayList list = TrainHttpContext.Send(request);
            return Encoding.UTF8.GetString(list[1] as byte[]);
        }

        /// <summary>
        /// 返回订单队列
        /// </summary>
        public string ResultOrderForWcQueue()
        {
            RequestPackage request = new RequestPackage();
            request.Method = EHttpMethod.Post.ToString();
            request.RefererURL = "/otn/confirmPassenger/initWc";
            request.RequestURL = "/otn/confirmPassenger/resultOrderForWcQueue";
            request.Params.Add("orderSequence_no", "EK17818578");
            request.Params.Add("_json_att", "");
            request.Params.Add("REPEAT_SUBMIT_TOKEN", "6a935f7b30fc20539538d245e07f9f3e");
            ArrayList list = TrainHttpContext.Send(request);
            return Encoding.UTF8.GetString(list[1] as byte[]);
        }


        /// <summary>
        /// 取消订单
        /// </summary>
        public void OrderCancel()
        {
            string parOrder = "{\"sequence_no\":\"EK17818578\", \"order_date\":\"2019-02-19 00:00:00\", \"ticket_totalnum\":1, \"ticket_price_all\":53800.0, \"epayFlag\":\"Y\", \"orders\":[{\"sequence_no\":\"EK17818578\", \"order_date\":\"2019-02-19 00:00:00\", \"ticket_totalnum\":1, \"ticket_price_all\":53800.0, \"tickets\":[{\"stationTrainDTO\":{\"station_train_code\":\"G1001\", \"from_station_telecode\":\"WHN\", \"from_station_name\":\"武汉\", \"start_time\":\"1970-01-01 07:25:00\", \"to_station_telecode\":\"IOQ\", \"to_station_name\":\"深圳北\", \"arrive_time\":\"1970-01-01 12:09:00\", \"distance\":\"1171\"},\"passengerDTO\":{\"passenger_name\":\"金曼城\",\"passenger_id_type_code\":\"1\",\"passenger_id_type_name\":\"中国居民身份证\",\"passenger_id_no\":\"360426199801130058\",\"mobile_no\":\"\",\"total_times\":\"98\",\"gat_born_date\":\"\",\"gat_valid_date_start\":\"\",\"gat_valid_date_end\":\"\",\"gat_version\":\"\"},\"ticket_no\":\"EK17818578106003A\",\"sequence_no\":\"EK17818578\",\"batch_no\":\"1\",\"train_date\":\"2019-02-21 00:00:00\",\"coach_no\":\"06\",\"coach_name\":\"06\",\"seat_no\":\"003A\",\"seat_name\":\"03A号\",\"seat_flag\":\"0\",\"seat_type_code\":\"O\",\"seat_type_name\":\"二等座\",\"ticket_type_code\":\"1\",\"ticket_type_name\":\"成人票\",\"reserve_time\":\"2019-02-19 00:00:00\",\"limit_time\":\"2019-02-19 10:11:10\",\"lose_time\":\"2019-02-19 10:41:10\",\"pay_limit_time\":\"2019-02-19 10:41:10\",\"realize_time_char\":\"2019-02-19 10:11:10\",\"ticket_price\":53800.0,\"old_ticket_price\":0.0,\"return_total\":53800.0,\"return_cost\":0.0,\"eticket_flag\":\"Y\",\"pay_mode_code\":\"Y\",\"payOrderString\":\"2019-02-19 10:11:10\",\"payOrderId\":\"1EK17818578001001101110593\",\"amount\":\"53800\",\"amount_char\":1,\"start_train_date_page\":\"2019-02-21 07:25\",\"str_ticket_price_page\":\"538.0\",\"come_go_traveller_ticket_page\":\"N\",\"return_rate\":\"0\",\"return_deliver_flag\":\"N\",\"deliver_fee_char\":\"\",\"is_need_alert_flag\":false,\"is_deliver\":\"00\",\"dynamicProp\":\"\",\"return_fact\":0.0,\"fee_char\":\"\",\"sepcial_flags\":\"\",\"column_nine_msg\":\"\",\"integral_pay_flag\":\"N\",\"trms_price_rate\":\"\",\"trms_price_number\":\"\",\"trms_service_code\":\"\",\"if_cash\":\"0\"}],\"isNeedSendMailAndMsg\":\"N\",\"ticket_total_price_page\":\"538.0\",\"come_go_traveller_order_page\":\"N\",\"canOffLinePay\":\"N\",\"if_deliver\":\"N\"}]}";

            string orderRequest = "{ \"train_location\":\"N2\",\"train_date\":\"2019-02-21 00:00:00\",\"train_no\":\"4e000G10010C\",\"station_train_code\":\"G1001\",\"from_station_telecode\":\"WHN\",\"to_station_telecode\":\"IOQ\",\"from_station_name\":\"武汉\",\"to_station_name\":\"深圳北\",\"seat_type_code\":\"O\",\"seat_detail_type_code\":\"0\",\"start_time\":\"1970-01-01 07:25:00\",\"end_time\":\"1970-01-01 12:09:00\",\"adult_num\":0,\"child_num\":0,\"student_num\":0,\"disability_num\":0,\"ticket_num\":0,\"id_mode\":\"Y\",\"reserve_flag\":\"A\",\"tour_flag\":\"wc\",\"reqIpAddress\":\"218.17.204.22\",\"reqTimeLeftStr\":\"00WHNIOQ武汉深圳北4e000G10010C2019-02-21G1001\",\"choose_seat\":\"1A\",\"isShowPassCode\":\"N&2&default\",\"passengerFlag\":\"1\",\"exchange_train_flag\":\"0\",\"channel\":\"E\"}";

            RequestPackage request = new RequestPackage();
            request.Method = EHttpMethod.Get.ToString();
            request.RefererURL = "/otn/payOrder/init?random=1550542271832";
            request.RequestURL = "/otn/payOrder/cancel";
            request.Params.Add("sequence_no", "EK17818578");
            request.Params.Add("parOrderDTOJson", parOrder);
            request.Params.Add("orderRequestDTOJson", orderRequest);
            request.Params.Add("REPEAT_SUBMIT_TOKEN", "6a935f7b30fc20539538d245e07f9f3e");
            ArrayList list = TrainHttpContext.Send(request);
            string jsonString = Encoding.UTF8.GetString(list[1] as byte[]);
        }
    }
}
