using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainBLL;

namespace CarryTrainFrom
{
    public partial class FrmTest : Form
    {
        public OrderBll orderBll;
        public FrmTest()
        {
            orderBll = new OrderBll();
            InitializeComponent();
        }


        #region 订单接口


        private void CheckOrderBtn_Click(object sender, EventArgs e)
        {
            string check = orderBll.CheckOrderInfo();
            txt.Text = check;
        }

        private void GetQueuebtn_Click(object sender, EventArgs e)
        {
            string check = orderBll.GetQueueCount();
            txt.Text = check;
        }

        private void ConfirmGoForQueueBtn_Click(object sender, EventArgs e)
        {
            string check = orderBll.ConfirmGoForQueue();
            txt.Text = check;
        }

        private void QueryOrderWaitTimeBtn_Click(object sender, EventArgs e)
        {
            string check = orderBll.QueryOrderWaitTime();
            txt.Text = check;
        }

        private void ResultOrderForWcQueueBtn_Click(object sender, EventArgs e)
        {
            string check = orderBll.ResultOrderForWcQueue();
            txt.Text = check;

        }

        private void SubmitOrderRequest_Click(object sender, EventArgs e)
        {
            //string check = orderBll.SubmitOrderRequest();
            //txt.Text = check;
        }
        #endregion


        #region 订单流程测试接口

        /*
       订单接口流程
       1./otn/login/checkUser 检查登陆
       2./otn/leftTicket/submitOrderRequest 提交订单请求 cookie参数有tk
       3./otn/confirmPassenger/getPassengerDTOs 乘车人信息
       4./otn/confirmPassenger/checkOrderInfo 
       5./otn/confirmPassenger/getQueueCount 
       6./otn/confirmPassenger/confirmSingleForQueue
       7./otn/confirmPassenger/queryOrderWaitTime
       8./otn/confirmPassenger/resultOrderForDcQueue
       */

        /// <summary>
        /// 订单流程接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OrderBll order = new OrderBll();
            LoginBll login = new LoginBll();
            QueryBll query = new QueryBll();
            var checkUser = login.PostCheckUser201909(out string json);
            if (!checkUser.result_code.Equals(0))
            {
                Log.Write(LogLevel.Error, json);
                return;
            }
            //var submitOrderRequest = order.SubmitOrderRequest();
            var getPassenger = query.GetPassenger();
            var checkOrderInfo = order.CheckOrderInfo();
            var getQueueCount = order.GetQueueCount();
            var confirmSingleForQueue = order.ConfirmGoForQueue();
            order.QueryOrderWaitTime201909();
            order.ResultOrderForWcQueue();
        }
        #endregion

    }
}
