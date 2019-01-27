using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Model;
using TrainBLL;

namespace Tool.Test
{



    [TestClass]
    public class UserInfoTest
    {
        /// <summary>
        /// 用户插入测试
        /// </summary>
        [TestMethod]
        public void TestInset()
        {
            var userInfoBll = new UserInfoBll();
            var excutUser = userInfoBll.UserInfoInsert(new DBUserInfo
            {
                userName = "17620372030",
                userPwd = "test1",
                Starts =1
            });
        }
    }
}
