using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ResBase
    {
        /// <summary>
        /// 返回消息
        /// </summary>
        public string result_message { get; set; }

        /// <summary>
        /// 返回码
        /// </summary>
        public int result_code { get; set; }


        /// <summary>
        /// 状态码 200表示成功
        /// </summary>
        public int status_code { get; set; }
    }
}
