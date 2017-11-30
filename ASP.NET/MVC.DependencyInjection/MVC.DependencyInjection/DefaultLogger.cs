using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.DependencyInjection
{
    public interface ILogger
    {
        void Log(string LogData);
    }

    public class DefaultLogger : ILogger
    {
        public void Log(string logData)
        {
            System.Diagnostics.Debug.WriteLine(logData, "default");
        }
    }
}