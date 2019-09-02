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
using static Model.Data.QueryTrainData;

namespace CarryTrainFrom
{
    public partial class FrmCreatTask : Form
    {

        public static QueryBll queryBll;
        public static List<ResponseStation> responses;

        public FrmCreatTask()
        {
            InitializeComponent();
            queryBll = new QueryBll();
            responses = queryBll.LoadStation();
            var stationList = responses.Select(x => x.StationName).ToList();
            Station(stationList, departureStation);
            Station(stationList, arrivalsStation);
            InitializeDataTrain();
        }

        #region 界面初始化


        /// <summary>
        /// 查询列表初始化
        /// </summary>
        private void InitializeDataTrain()
        {
            dataTrain.AutoGenerateColumns = false;
            this.dataTrain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        #endregion

        /// <summary>
        /// 给TextBox设置下拉搜索
        /// </summary>
        /// <param name="list"></param>
        /// <param name="text"></param>
        public void Station(List<string> list, TextBox text)
        {

            //重点代码
            text.AutoCompleteCustomSource.Clear();
            text.AutoCompleteCustomSource.AddRange(list.ToArray());
            text.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            text.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }


        /// <summary>
        /// 提交查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {

            var departure = departureStation.Text;
            var arrivals = arrivalsStation.Text;
            var date = departureDate.Text;

            var departureMsg = responses.FirstOrDefault(x => x.StationName == departure);
            var arrivalsMsg = responses.FirstOrDefault(x => x.StationName == arrivals);
            if (departureMsg == null || arrivalsMsg == null)
                MessageBox.Show("粗发站或到达站输入错误");
            if (departureMsg != null && arrivalsMsg != null)
            {
                var ticketQuery = queryBll.TicketQuery(departureMsg.StationShort, arrivalsMsg.StationShort, date, out string jsonstring);
                if (ticketQuery == null) return;
                var ticketList = TicketQueryAction(ticketQuery);
                ticketList = TicketQueryFilter(ticketList, departureMsg);
                dataTrain.DataSource = null;
                dataTrain.DataSource = CreatAction(ticketList);
                SetAllRowChecked();
            }
        }

        /// <summary>
        /// 交换站点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExchangeStation_Click(object sender, EventArgs e)
        {
            var departure = departureStation.Text;
            var arrivals = arrivalsStation.Text;
            departureStation.Text = arrivals;
            arrivalsStation.Text = departure;
        }

        /// <summary>
        /// 解析对应站点数据
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<DetailData> TicketQueryAction(ResponseTicketQuery query)
        {
            var details = new List<DetailData>();
            string[] data = query.data.result;
            foreach (var item in data)
            {
                var r_list = item.Split(new char[] { '|' });
                DetailData detail = new DetailData
                {
                    trainId = r_list[0],
                    operat_remark = r_list[1],
                    complete_train_no = r_list[2],
                    train_no = r_list[3],
                    start_station_telecode = r_list[4],
                    end_station_telecode = r_list[5],
                    from_station_telecode = r_list[6],
                    to_station_telecode = r_list[7],
                    start_time = r_list[8],
                    arrive_time = r_list[9],
                    lishi = r_list[10],
                    cross_days = r_list[11],
                    cross_days_reamrk = r_list[12],
                    departure_date = r_list[13],
                    gr_num = r_list[21],
                    qt_num = r_list[22],
                    rw_num = r_list[23],
                    rz_num = r_list[24],
                    dw_num = r_list[25],
                    wz_num = r_list[26],
                    yw_num = r_list[28],
                    yz_num = r_list[29],
                    ze_num = r_list[30],
                    zy_num = r_list[31],
                    swz_num = r_list[32],

                };
                details.Add(detail);
            }
            return details;
        }

        /// <summary>
        /// 查询过滤条件
        /// </summary>
        /// <returns></returns>
        public List<DetailData> TicketQueryFilter(List<DetailData> detailDatas, ResponseStation departureMsg)
        {
            var ticketList = new List<DetailData>();
            if (multiStation.Checked)
                ticketList = detailDatas.Where(x => x.from_station_telecode == departureMsg.StationShort).ToList();
            ticketList = detailDatas.Where(x =>
            multiStation.Checked ? x.from_station_telecode == departureMsg.StationShort : x == x &&
            GCar.Checked ? x.train_no.Contains("G") : x == x &&
            DCar.Checked ? x.train_no.Contains("D") : x == x &&
            TCar.Checked ? x.train_no.Contains("T") : x == x &&
            ZCar.Checked ? x.train_no.Contains("Z") : x == x &&
            KCar.Checked ? x.train_no.Contains("K") : x == x
            ).ToList();
            return ticketList;
        }

        /// <summary>
        /// 用户界面数据
        /// </summary>
        /// <param name="detailDatas"></param>
        /// <returns></returns>
        public List<DetailDataAction> CreatAction(List<DetailData> detailDatas)
        {
            return detailDatas.Select(x => new DetailDataAction
            {
                TrainId = x.trainId,
                TrainNo = x.train_no,
                StartStationTelecode = x.start_station_telecode,
                EndStationTelecode = x.end_station_telecode,
                FromStationTelecode = x.from_station_telecode,
                ToStationTelecode = x.to_station_telecode,
                FromArrivalsStationName = FromArrivalsStationNameGetByCode(x.from_station_telecode, x.to_station_telecode),
                StartArriveTime = string.Format("{0}-{1}", x.start_time, x.arrive_time),
                lishi = x.lishi,
                CrossDays = x.cross_days == "Y" ? "是" : "否",
                OperatRemark = x.operat_remark,
                DepartureDate = x.departure_date,
                gr_num = x.gr_num == "" ? "--" : x.gr_num,
                qt_num = x.qt_num == "" ? "--" : x.qt_num,
                rw_num = x.rw_num == "" ? "--" : x.rw_num,
                rz_num = x.rz_num == "" ? "--" : x.rz_num,
                wz_num = x.wz_num == "" ? "--" : x.wz_num,
                dw_num = x.dw_num == "" ? "--" : x.dw_num,
                yw_num = x.yw_num == "" ? "--" : x.yw_num,
                yz_num = x.yz_num == "" ? "--" : x.yz_num,
                ze_num = x.ze_num == "" ? "--" : x.ze_num,
                zy_num = x.zy_num == "" ? "--" : x.zy_num,
                swz_num = x.swz_num == "" ? "--" : x.swz_num
            }).ToList();
        }

        /// <summary>
        /// 根据code获取出发到达站
        /// </summary>
        /// <returns></returns>
        private string FromArrivalsStationNameGetByCode(string fromStationTelecode, string toStationTelecode)
        {
            try
            {
                var fromStationName = responses.FirstOrDefault(x => x.StationShort == fromStationTelecode).StationName;
                var ToStationName = responses.FirstOrDefault(x => x.StationShort == toStationTelecode).StationName;
                return string.Format("{0}-{1}", fromStationName, ToStationName);
            }
            catch (Exception)
            {
                return string.Format("{0}-{1}", fromStationTelecode, toStationTelecode);
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allCarCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (allCarCheck.Checked)
                CarStatus(true);
            else
                CarStatus(false);
        }

        /// <summary>
        /// 修改所有车型状态
        /// </summary>
        /// <param name="status"></param>
        private void CarStatus(bool status)
        {
            GCar.Checked = status;
            DCar.Checked = status;
            TCar.Checked = status;
            ZCar.Checked = status;
            KCar.Checked = status;
            NCar.Checked = status;
        }


        /// <summary>
        ///  表格单元点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataTrain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
       
                //获取cb_check的值
                var checkCell = (DataGridViewCheckBoxCell)dataTrain.Rows[e.RowIndex].Cells["cb_check"];
                var trainNoCell = (DataGridViewTextBoxCell)dataTrain.Rows[e.RowIndex].Cells["TrainNo"];
                //var flag = Convert.ToBoolean(checkCell.Value);
                if (checkCell.Selected)
                {
                    //rows.Cells["cb_check"].Value = false;
                    //checkCell.Value = false;
                    if (!TrainNumber.Items.Contains(trainNoCell.Value))
                        TrainNumber.Items.Add(trainNoCell.Value);
                }
                else
                {
                    //rows.Cells["cb_check"].Value = true;
                    //checkCell.Value = true;
                    if (TrainNumber.Items.Contains(trainNoCell.Value))
                        TrainNumber.Items.Remove(trainNoCell.Value);
                }
            }
        }
        /// <summary>
        /// 设置dataTrain所有列赋值
        /// </summary>
        private void SetAllRowChecked()
        {
            int count = Convert.ToInt16(this.dataTrain.Rows.Count.ToString());
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataTrain.Rows[i].Cells["cb_check"];
                var flag = Convert.ToBoolean(checkCell.Value);
                if (flag) //查找被选择的数据行
                {
                    checkCell.Value = false;
                }
                continue;
            }
        }

        /// <summary>
        /// 双击获取数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataTrain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //判断双击的是否为标题
            if (e.RowIndex >= 0)
            {
                List<DetailDataAction> table = (List<DetailDataAction>)dataTrain.DataSource;//数据源
                string trainNo = table[e.RowIndex].TrainNo;
                //var checkCell = (DataGridViewCheckBoxCell)dataTrain.Rows[e.RowIndex].Cells["cb_check"];
                //var flag = Convert.ToBoolean(checkCell.Value);
                //if (flag) //查找被选择的数据行
                //{
                //    checkCell.Value = false;
                //    if (TrainNumber.Items.Contains(trainNo))
                //        TrainNumber.Items.Remove(trainNo);
                //}
                //else
                //{
                //    checkCell.Value = true;
                //    if (!TrainNumber.Items.Contains(trainNo))
                //        TrainNumber.Items.Add(trainNo);
                //}
            }
        }




        /// <summary>
        /// 设置日期选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void departureDate_ValueChanged(object sender, EventArgs e)
        {
            var departure = departureDate.Value;
            if (DateTime.Now.AddDays(-1) > departure || departure > DateTime.Now.AddDays(30))
            {
                MessageBox.Show("请选择正确日期");
                departureDate.Value = DateTime.Now;
            }
        }
    }
}
