using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Common
{
    public class LogHelper
    {
        /// <summary>
        /// 记录基本日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="s">格式化参数</param>
        public static void Info(string msg, params object[] s)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("rootLogger");
            log.Info(string.Format(msg,s));
        }

        /// <summary>
        /// 记录告警，数据错误或业务逻辑错误
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="s">格式化参数</param>
        public static void Warn(string msg, params object[] s)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("rootLogger");
            log.Warn(string.Format(msg, s));
        }

        /// <summary>
        /// 记录系统异常报错
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="s">格式化参数</param>
        public static void Error(string msg, params object[] s)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("rootLogger");
            log.Error(string.Format(msg, s));
        }
    }
}
