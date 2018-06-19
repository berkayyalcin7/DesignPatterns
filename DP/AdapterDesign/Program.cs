using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dışardaki Bi servisi projemize enjekte etmek için
            ProductManager pdManager=new ProductManager(new Log4NetAdapter());
            ProductManager pdManager1 = new ProductManager(new ByLogger());
            
            pdManager.Save();
            pdManager1.Save();

            Console.ReadLine();
        }
    }

    class ProductManager
    {


        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }

    }

    interface ILogger
    {
        void Log(string message);
    }

    class ByLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged , {0}",message);
        }
    }
    //Nugetten indirdiğimizi varsayalım ... Classa dokunamadığımızı düşünelim
    //Bunu Nasıl dahil edeceğiz -> ADAPTER Design devreye giriyor
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with log4net , {0}", message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4net=new Log4Net();
            log4net.LogMessage(message);
        }
    }
}
