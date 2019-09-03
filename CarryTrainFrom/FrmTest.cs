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
            string check = orderBll.SubmitOrderRequest();
            txt.Text = check;
        }
        #endregion


        #region 登陆接口
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            LoginBll train = new LoginBll();
            var code = train.GetValidateCode();
        }
        #endregion

    }
}
