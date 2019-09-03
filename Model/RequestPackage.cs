using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Model
{
    [Serializable]
    public class RequestPackage
    {

        #region 变量
        private Dictionary<string, string> _params = null;
        #endregion

        #region 构造函数

        public RequestPackage()
        { }
        public RequestPackage(string requestUrl)
        {
            this.RequestURL = requestUrl;
        }
        #endregion

        #region 属性

        public string RequestURL { get; set; } = string.Empty;
        public string RefererURL { get; set; } = string.Empty;
        public Dictionary<string, string> Params
        {
            get
            {
                if (this._params == null)
                    this._params = new Dictionary<string, string>();
                return this._params;
            }
        }
        /// <summary>
        /// 请求方式
        /// </summary>
        public string Method { get; set; } = "post";

        public string Accept { get; set; } = "*/*";
        public Encoding Encoding { get; set; } = Encoding.ASCII;
        #endregion
    }
}
