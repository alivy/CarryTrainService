using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public  class ResponseLoginUser :ResBase
    {
        /// <summary>
        /// 返回消息
        /// </summary>
        public object messages { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool status { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string validateMessages { get; set; }

        /// <summary>
        /// 状态码 200表示成功
        /// </summary>
        public string validateMessagesShowId { get; set; }
        
    }
}
