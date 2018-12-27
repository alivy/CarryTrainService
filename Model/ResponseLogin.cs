using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Data;
using Newtonsoft.Json;

namespace Model
{
    [Serializable]
    public class ResponseLogin : ResponseBase
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
        /// 返回码
        /// </summary>
        public string  uamtk { get; set; }

        /// <summary>
        /// 状态码 200表示成功
        /// </summary>
        public int status_code { get; set; }
        public LoginData Data
        {
            get
            {
                LoginData data = null;
                if (base.data != null && base.data.ToString() != string.Empty)
                {
                    data = JsonConvert.DeserializeObject<LoginData>(base.data.ToString());
                }
                return data;
            }
        }
    }
}
