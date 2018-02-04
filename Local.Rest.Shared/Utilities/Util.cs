using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Local.Rest.Shared.Utilities
{
    public static class Util
    {
        public static void TracertToJson(string ProcessName, params object[] args)
        {
            try
            {
                string AppStartupPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "LOGS");
                DirectoryInfo dirLog = new DirectoryInfo(AppStartupPath);
                if (!dirLog.Exists) dirLog.Create();

                string logWriterFilePath = string.Format("{1}\\LOG_{0:yyyyMMdd}_{2}.txt"
                    , DateTime.Now
                    , AppStartupPath
                    , ProcessName);

                StreamWriter errorWriter = new System.IO.StreamWriter(logWriterFilePath, true, Encoding.UTF8);
                errorWriter.AutoFlush = true;

                string _message = string.Empty;
                var jsonSerialiser = new JavaScriptSerializer();
                var _jsonResult = jsonSerialiser.Serialize(args);
                errorWriter.WriteLine(string.Format("[{0}]\t >> Message: {1}", DateTime.Now.ToString("HH:mm:ss"), _jsonResult));
                errorWriter.Dispose();
            }
            catch (Exception)
            {

            }
        }
        public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }
    }
}
