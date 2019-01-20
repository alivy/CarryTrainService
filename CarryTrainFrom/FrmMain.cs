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
        public FrmMain()
        {
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


        private DialogResult Login()
        {
            DialogResult result = DialogResult.Cancel;
            using (FrmLogin frmLogin = new FrmLogin())
            {
                if ((result = frmLogin.ShowDialog()) == DialogResult.OK)
                { 
                   
                }
            }
            return result;
        }
    }
}
