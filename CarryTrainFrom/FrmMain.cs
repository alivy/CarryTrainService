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

namespace CarryTrainFrom
{
    public partial class FrmMain : Form
    {
        private List<UserInfo> userInfos;
        public FrmMain()
        {
            InitializeComponent();
            userInfos = new List<UserInfo>();
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
    }
}
