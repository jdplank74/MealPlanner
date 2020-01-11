using NLog;
using NLog.Extensions.Logging;
using Msft = Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System;


namespace Utilities.Logging
{
    public class LoggerFactory
    {
        //private static LoggerFactory _factoryInstance;
        private static object _monitor = new object();
        private static Msft.ILoggerFactory _factory;

        //private LoggerFactory()
        //{
        //    // 
        //    _factory = new Msft.LoggerFactory().AddNLog();
        //}

        //public Msft.ILogger CreateLoggerOld<T>()
        //{
        //    string category = typeof(T).FullName;
        //    return _factory.CreateLogger(category);
        //}

        public static Msft.ILogger CreateLogger<T>()
        {
            lock (_monitor)
            {
                if (_factory == null)
                {
                    _factory = new Msft.LoggerFactory().AddNLog();
                }
            }

            string category = typeof(T).FullName;
            return _factory.CreateLogger(category);
        }

        //public static LoggerFactory Instance
        //{
        //    get
        //    {
        //        lock (_monitor)
        //        {
        //            if (_factoryInstance == null)
        //            {
        //                _factoryInstance = new LoggerFactory();
        //            }
        //        }
        //        return _factoryInstance;
        //    }
        //}
    }
}
