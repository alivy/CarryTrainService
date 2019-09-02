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
    public partial class FrmMain : Form
    {
        private List<UserInfo> userInfos;
        public UserInfoBll userInfoBll;
        public OrderBll orderBll;
        public FrmMain()
        {
            userInfoBll = new UserInfoBll();
            orderBll = new OrderBll();
            userInfos = new List<UserInfo>();
            InitializeComponent();

        }
        /// <summary>
        /// 添加账号到缓存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.Login();
        }
        /// <summary>
        /// 给用户添加数据
        /// </summary>
        /// <returns></returns>
        public void AddUserView(UserInfo user)
        {
            var userdata = userInfos.FirstOrDefault(x => x.UserName == user.UserName);
            if (userdata != null)
                return;
            userInfos.Add(user);
            var userInfo = userInfos.FirstOrDefault(x => x.State == 1);
            var contact = userInfo == null ? new List<ContactInfo>() : userInfo.ContactInfo;
            var excutUser = userInfoBll.UserInfoInsert(new DBUserInfo
            {
                userName = userInfo.UserName,
                userPwd = userInfo.UserPwd,
                Starts = userInfo.State
            });
            ShowUserDataView(userInfos, contact);
        }

        /// <summary>
        /// 给用户图表绑定值
        /// </summary>
        /// <param name="users"></param>
        /// <param name="contacts"></param>
        public void ShowUserDataView(List<UserInfo> users, List<ContactInfo> contacts)
        {
            dataUserInfoView.AutoGenerateColumns = false;
            dataUserInfoView.DataSource = users;
            dataUserInfoView.Refresh();
            dataContactInfoView.AutoGenerateColumns = false;
            dataContactInfoView.DataSource = contacts;
            dataContactInfoView.Refresh();
        }




        private DialogResult Login()
        {
            DialogResult result = DialogResult.Cancel;
            using (FrmLogin frmLogin = new FrmLogin())
            {
                if ((result = frmLogin.ShowDialog()) == DialogResult.OK)
                {
                    AddUserView(frmLogin.user);
                }
            }
            return result;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 查询未完成订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            orderBll.NoCompleteOrderQuery();
            orderBll.CompleteOrderQuery();
        }

        private void FrmTestBtn_Click(object sender, EventArgs e)
        {
            FrmTest frmTest = new FrmTest();
            frmTest.Show();

        }
    }
}
