using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.TrainRequest
{
    public class TrainReqLogin : TrainReqBase
    {
        /// <summary>
        /// 登陆账号
        /// </summary>
        public string loginName { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string loginPwd { get; set; }

    }
}
