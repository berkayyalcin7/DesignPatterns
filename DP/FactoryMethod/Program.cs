using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //Yazılımda değişimi Kontrol altında tutmakdır
            //FactoryMethod En çok kullanılan desenlerden biri.
            CustomerManager cm = new CustomerManager(new LoggerFactory());
            cm.Save();

            Console.ReadLine();
        }
    }


    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new ParrotLogger();
        }


    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new ByLogger();
        }


    }

    public interface ILogger
    {
        void Log();
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public class ByLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with ByLogger");
        }
    }

    public class ParrotLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with ParrotLogger");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved.");
            //New yaparken o nesneye bağımlılığımızı belirtir
            //ILogger logger=new ByLogger();
            ILogger logger = new LoggerFactory().CreateLogger();
            logger.Log();
        }
    }
}
