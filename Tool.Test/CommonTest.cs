using System;
using System.Text.RegularExpressions;
using Common;
using Common.Help;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tool.Test
{
    [TestClass]
    public class CommonTest
    {
        /// <summary>
        /// 日志测试
        /// </summary>
        [TestMethod]
        public void TestLog()
        {
            Log.Write(LogLevel.Info, "Info 日志写入");
            Log.Write(LogLevel.Error, "Error 日志写入");
            Log.Write(LogLevel.Warn, "Warn 日志写入");
            Log.Write(LogLevel.Debug, "Debug 日志写入");
            Log.Write(LogLevel.Fatal, "Fatal 日志写入");
        }

        /// <summary>
        /// 时间戳测试
        /// </summary>
        [TestMethod]
        public void TimeStampTest()
        {
            var time = TimeHelp.ConvertStringToDateTime("1567901654217");
        }
        /// <summary>
        /// NewGuid测试
        /// </summary>
        [TestMethod]
        public void NewGuidTest()
        {
            string myString = "1- 123- 222";
            var ss = Regex.Replace(myString, @"\s", "").Replace("-","");
            var tt = Guid.NewGuid();
            ///fbe5fa6f4d104bc28ab3331d8db97b7f
            ///b5a05749242999dc0483196134d0358c
            ///
            //_gntkuCysgErh6EKvQme937ygL53VC_0rkekbexNyHkqrG1G0
            //wdkKxwzJR1CBA5DpInfFp8rt8SIZh9U75Dek_V61tPQdqG1G0
        }
        
    }
}
