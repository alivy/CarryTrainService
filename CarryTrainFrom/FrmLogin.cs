using Common;
using Model;
using Model.Model;
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

        public UserInfo user;
        #endregion
        public FrmLogin()
        {
            InitializeComponent();
            user = new UserInfo();
        }
        /// <summary>
        /// 点击登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //string userName = txtLoginName.Text;
            //string userPwd = txtLoginPwd.Text;
            string userName = "17620372030";
            string userPwd = "yanhaomiao123";
            var train = new LoginBll();

            var check = UserCheck(userName, userPwd);

            if (check.Item1 != 0)
                MessageBox.Show(check.Item2);
            this.FrmCode(userName, userPwd);
        }

        private DialogResult FrmCode(string userName, string userPwd)
        {
            DialogResult result = DialogResult.Cancel;
            using (FrmCode frmCode = new FrmCode())
            {
                frmCode.Owner = this;
                if ((result = frmCode.ShowDialog()) == DialogResult.OK)
                {
                    UserInfo userInfo = new UserInfo();
                    userInfo.UserName = userName;
                    userInfo.UserPwd = userPwd;
                    this.Login(userInfo);
                    this.Close();
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


        /// <summary>
        /// 加载登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        private void Login(UserInfo userInfo)
        {
            ;
            string data = string.Empty;
            var result = new ResultModel();
            var train = new LoginBll();
            do
            {
                var login = train.PostLogin(userInfo.UserName, userInfo.UserPwd, out data);
                if (login.result_code != 0)
                {
                    MessageBox.Show(login.result_message);
                    Log.Write(LogLevel.Info, data);
                    break;
                }

                var tk = train.PostUamtk(out data);
                if (tk.result_code != 0)
                {
                    MessageBox.Show(tk.result_message);
                    Log.Write(LogLevel.Info, data);
                    break;
                }

                var apptk = train.PostUamauthClient(tk.newapptk, out data);

                if (apptk.result_code != 0)
                {
                    MessageBox.Show(apptk.result_message);
                    Log.Write(LogLevel.Info, data);
                    break;
                }
                train.PostConf();
                train.PostInitMy12306();

                userInfo.RealName = apptk.username;
                var passenger = new QueryBll().GetPassenger();
                //获取联系人
                var passengers = passenger.Data.Normal_Passengers;
                userInfo.ContactInfo = passengers.Select(x => new ContactInfo
                {
                    ContactName = x.passenger_name,
                    CardNo = x.passenger_id_no
                }).ToList();
                userInfo.State = 1;
                user = userInfo;
                this.DialogResult = DialogResult.OK;
            } while (false);
        }

        private void txtLoginName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
