//如果是winform或console等c/s程序，需要设置一下。
//具体步骤：右键log4net.config文件-属性-复制到输出目录：始终复制。目的是为了每次启动时能够找到这个config文件
using log4net;
using System;
using System.Configuration;
using System.Reflection;
[assembly: log4net.Config.XmlConfigurator(Watch = true, ConfigFile = "Config\\log.config")]
namespace Common
{
    /// <summary>
    /// 日志记录类
    /// </summary>
    public class Log
    {
        private static readonly bool IsThrowException =  false;
        private static readonly ILog loginfo = LogManager.GetLogger("loginfo");
        private static readonly ILog logdebug = LogManager.GetLogger("logdebug");
        private static readonly ILog logerror = LogManager.GetLogger("logerror");
        private static readonly ILog logfatal = LogManager.GetLogger("logfatal");
        private static readonly ILog logwarn = LogManager.GetLogger("logwarn");
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region 记录日志
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="legLevel">日志级别</param>
        /// <param name="msg">日志内容</param>
        private static void LoggerMsg(LogLevel legLevel, string msg)
        {
            log4net.ILog log = GetLogger();
            switch (legLevel)
            {
                case LogLevel.Debug: logdebug.Debug(msg); break;//Debug
                case LogLevel.Error: logerror.Error(msg); break;//Error
                case LogLevel.Fatal: logfatal.Fatal(msg); break;//Fatal
                case LogLevel.Info: loginfo.Info(msg); break;//Info
                case LogLevel.Warn: log.Warn(msg); break;//Warn
                default: break;
            }
        }
        #endregion

        #region 获得一个日志记录对象
        /// <summary>
        /// 获得一个日志记录对象
        /// </summary>
        /// <returns>日志记录对象</returns>
        private static ILog GetLogger()
        {
            //MethodBase.GetCurrentMethod().DeclaringType 返回：命名空间名+类名
            return LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        #endregion


        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="LogLevel">日志类型</param>
        public static void Write(LogLevel LogLevel, string message)
        {
            Write(LogLevel, message, null);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">日志消息</param>
        /// <param name="LogLevel">日志类型</param>
        /// <param name="ex">异常</param>
        public static void Write(LogLevel LogLevel, string message, Exception ex)
        {
            switch (LogLevel)
            {
                case LogLevel.Debug: if (log.IsDebugEnabled) { logdebug.Debug(message, ex); } break;
                case LogLevel.Info: if (log.IsInfoEnabled) { loginfo.Info(message, ex); } break;
                case LogLevel.Warn: if (log.IsWarnEnabled) { logwarn.Warn(message, ex); } break;
                case LogLevel.Error:
                    if (log.IsErrorEnabled)
                    {
                        logerror.Error(message, ex);
                        if (IsThrowException)
                        {
                            throw ex;
                        }
                    }
                    break;
                case LogLevel.Fatal:
                    if (log.IsFatalEnabled)
                    {
                        logfatal.Fatal(message, ex);
                        if (IsThrowException)
                        {
                            throw ex;
                        }
                    }
                    break;
            }
        }

    }




    /// <summary>
    /// 日志记录级别
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// 调试
        /// </summary>
        Debug,
        /// <summary>
        /// 信息
        /// </summary>
        Info,
        /// <summary>
        /// 警告
        /// </summary>
        Warn,
        /// <summary>
        /// 错误
        /// </summary>
        Error,
        /// <summary>
        /// 致命错误
        /// </summary>
        Fatal
    }
}