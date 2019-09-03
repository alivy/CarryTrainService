using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data._12036.Response
{
    public class ResBase
    {
        /// <summary>
        /// cookie值
        /// </summary>
        public CookieContainer cookie { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public string result_code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string result_message { get; set; }
    }
}
