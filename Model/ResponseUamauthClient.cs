using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ResponseUamauthClient : ResBase
    {
        /// <summary>
        /// newapptk
        /// </summary>
        public string apptk { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
    }
}
