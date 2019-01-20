using CarryTrainFrom.Soce;
using Common;
using Model;
using Model.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainBLL;

namespace CarryTrainFrom
{
    public partial class FrmCode : Form
    {
        #region 全局变量
        private const string RES_PATH = "Images.Loading.{0}.png";
        private int _res_index = 1;
        /// <summary>
        /// 获取坐标点上的坐标
        /// </summary>
        private List<Point> points { get; set; }

        public string userNmae { get; set; }
        #endregion


        public FrmCode()
        {
            InitializeComponent();
            LoadEvents();
        }

        /// <summary>
        /// 加载事件
        /// </summary>
        private void LoadEvents()
        {
            GetValidateCode();
            this.timer.Tick += new EventHandler(timer_Tick);
        }



        /// <summary>
        /// 加载验证码
        /// </summary>
        /// <returns></returns>
        private void GetValidateCode()
        {
            try
            {
                this.TimerStart();
                ThreadPool.QueueUserWorkItem(x =>
                {
                    LoginBll train = new LoginBll();
                    var code = train.GetValidateCode();
                    using (var picCode = code.Item3)
                        this.Invoke(new Action(() => ShowValidateCode(picCode)));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "系统提示");
            }
        }

        /// <summary>
        /// 启动计时器
        /// </summary>
        private void TimerStart()
        {
            if (!this.timer.Enabled)
            {
                this._res_index = 1;
                this.timer.Start();
            }
        }

        /// <summary>
        /// 显示验证码
        /// </summary>
        private void ShowValidateCode(Stream stream)
        {
            try
            {
                if (stream == null)
                    this.picCode.Image = FrmSource.login_1;
                if (this.timer.Enabled)
                    this.timer.Stop();
                this.picCode.Image = Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 加载登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        private ResultModel Login()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.UserName = ((FrmLogin)Owner).LoginNameText;
            userInfo.UserPwd = ((FrmLogin)Owner).LoginPwdText;
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
                    UserName = x.passenger_name,
                    CardNo = x.passenger_id_no
                }).ToList();
                FrmMain frmMain = new FrmMain();
                

                //保存用户数据
            } while (false);
            return result;
        }

        /// <summary>
        /// 清除picCode画布,并重新加载验证码
        /// </summary>
        public void ClearCodeImg()
        {
            var pic = picCode.Controls.Cast<Control>().ToArray();
            foreach (var item in pic)
            {
                picCode.Controls.Remove(item);
            }
            points.Clear();
            this.GetValidateCode();
        }

        /// <summary>
        /// 提交验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCode_Click(object sender, EventArgs e)
        {
            if (points == null || points.Count <= 0)
            {
                MessageBox.Show("请选中验证码");
                return;
            }
            var train = new LoginBll();
            string jsonResult;
            var check = train.PostCaptchaCheck(CodePoint(), out jsonResult);
            if (check.result_code == 4)
            {
                var result = this.Login();
            }
            else
            {
                MessageBox.Show(check.result_message);
                ClearCodeImg();
            }

        }

        /// <summary>
        /// 获取选中坐标
        /// </summary>
        /// <returns></returns>
        private string CodePoint()
        {
            string point = string.Empty;
            foreach (var item in points)
            {
                point += item.X + "," + item.Y + ",";
            }
            return point.TrimEnd(',');
        }


        /// <summary>
        /// 选中坐标加上图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picCode_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //添加mark
                var point = e.Location + new Size(0, 0);
                if (point.X == 0 || point.Y == 0) return; //非法坐标
                if (point.Y < 41 || point.Y > 179) return;
                if (point.X < 5 || point.X > 288) return;
                (points ?? (points = new List<Point>())).Add(point);
                //添加marker
                var marker = new PictureBox()
                {
                    Location = e.Location + new Size(-16, -16),
                    Image = FrmSource.check,
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    BackColor = Color.Transparent,
                    Tag = point
                };
                picCode.Controls.Add(marker);
                marker.BringToFront();

                //添加marker移除事件
                marker.Click += (x, y) =>
                {
                    points.Remove((Point)(x as PictureBox).Tag);
                    picCode.Controls.Remove(x as PictureBox);
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void FrmCode_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 切换验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!this.timer.Enabled)
            {
                this.ClearCodeImg();
            }
        }

        /// <summary>
        /// 显示加载图片
        /// </summary>
        void timer_Tick(object sender, EventArgs e)
        {

            Image image = AppResource.GetImage(string.Format(RES_PATH, _res_index));
            if (_res_index == 8)
                _res_index = 1;
            else
                _res_index++;
            this.picCode.Image = image;
        }
    }
}
