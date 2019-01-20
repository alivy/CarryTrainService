using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.TrainResponse
{
    /// <summary>
    /// 公共返回字段
    /// </summary>
    public class TrainResBase<T>
    {
        /// <summary>
        /// 状态码 0：成功
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// json数据
        /// </summary>
        public T Data { get; set; }
    }
}
