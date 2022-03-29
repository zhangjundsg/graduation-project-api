using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sys.Common
{
    public class NLogHelp
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();
        public static void ErrorLog(string throwMsg, Exception ex)
        {
            string errorMsg = string.Format("\r\n【异常信息】：{0} \r\n【异常类型】：{1} \r\n【堆栈调用】：\r\n{2}",
                new object[] { throwMsg, ex.GetType().Name, ex.StackTrace });
            logger.Error(errorMsg);
        }
    }
}
