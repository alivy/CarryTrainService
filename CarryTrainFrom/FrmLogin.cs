using Model;
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
    public partial class FrmLogin : Form
    {
        #region 全局变量信息
        public string LoginNameText { get { return txtLoginName.Text; } }
        public string LoginPwdText { get { return txtLoginPwd.Text; } }
        #endregion
        public FrmLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 点击登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtLoginName.Text;
            string userPwd = txtLoginPwd.Text;
            var train = new LoginBll();

            var check = UserCheck(userName, userPwd);

            if (check.Item1 != 0)
                MessageBox.Show(check.Item2);
            this.FrmCode();
        }

        private DialogResult FrmCode()
        {
            DialogResult result = DialogResult.Cancel;
            using (FrmCode frmCode = new FrmCode())
            {
                frmCode.Owner = this;
                if ((result = frmCode.ShowDialog()) == DialogResult.OK)
                {


                }
            }
            return result;
        }





        /// <summary>
        /// 验证账号密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private Tuple<int, string> UserCheck(string userName, string userPwd)
        {
            int status = 0;
            string msg = string.Empty;

            if (string.IsNullOrEmpty(userName))
            {
                status = 888;
                msg = "用户名不为空";
            }
            if (string.IsNullOrEmpty(userPwd))
            {
                status = 888;
                msg = "密码不为空";
            }
            return new Tuple<int, string>(status, msg);
        }
    }
}
