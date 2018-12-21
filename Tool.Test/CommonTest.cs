using System;
using Common;
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
    }
}
