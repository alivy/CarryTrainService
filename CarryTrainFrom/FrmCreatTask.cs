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
            GridViewAddCheck(dataPassenger);
            queryBll = new QueryBll();
            responses = queryBll.LoadStation();
            var stationList = responses.Select(x => x.StationName).ToList();
            Station(stationList, departureStation);
            Station(stationList, arrivalsStation);
        }

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
            var arrivalsMsg = responses.FirstOrDefault(x => x.StationName == departure);
            if (departureMsg == null || arrivalsMsg == null)
                MessageBox.Show("粗发站或到达站输入错误");
            var ticketQuery = queryBll.TicketQuery(departureMsg.StationShort, arrivalsMsg.StationShort, date, out string jsonstring);
            var ticketList = TicketQueryAction(ticketQuery);
            dataTrain.DataSource = ticketList;
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
            departureStation.Text = departure;
            arrivalsStation.Text = arrivals;
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
                    train_no = r_list[2],
                    complete_train_no = r_list[3],
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
                    wz_num = r_list[26],
                    yw_num = r_list[28],
                    yz_num = r_list[29],
                };
                details.Add(detail);
            }
            return details;
        }

        /// <summary>
        /// 过滤条件
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
        /// 为DataGridView添加check列
        /// </summary>
        /// <param name="dataGridView"></param>
        public  void GridViewAddCheck(DataGridView dataGridView)
        {
            DataGridViewCheckBoxColumn columncb = new DataGridViewCheckBoxColumn();
            columncb.HeaderText = "";
            columncb.Name = "cb_check";
            columncb.TrueValue = true;
            columncb.FalseValue = false;
            //column9.DataPropertyName = "IsScienceNature";
            columncb.DataPropertyName = "IsChecked";
            dataGridView.Columns.Add(columncb);
        }
        
    }
}
