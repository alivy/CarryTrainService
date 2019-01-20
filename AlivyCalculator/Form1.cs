using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlivyCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string num = txtInput.Text;
            string to_num = txtOutput.Text;
            string unit = boxUnit.Text;
            int in_num = ValidateNum(num);
            txtOutput.Text = Calculation(in_num, unit).ToString();
        }

        /// <summary>
        /// 验证输入值
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int ValidateNum(string num)
        {
            if (string.IsNullOrEmpty(num))
            {
                MessageBox.Show("输入值不能为空");
            }
            if (int.TryParse(num, out int in_num))
            {
                MessageBox.Show("请输入数字");
            }
            return in_num;

        }

        /// <summary>
        /// 开始计算
        /// </summary>
        /// <param name="in_num"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        private int Calculation(int in_num, string unit)
        {
            int unit_num = 0;
            if (unit == "亿")
                unit_num = 100000000;
            if(unit == "万")
                unit_num = 10000;
            if (unit == "千")
                unit_num = 1000;
            if (unit == "百")
                unit_num = 100;
            if (unit == "十")
                unit_num = 10;
            return in_num * unit_num;
        }
    }
}
