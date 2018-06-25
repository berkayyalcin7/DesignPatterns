using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Örn HiçBir şey yapmayan bi sahte nesne göndererek -> Perf artışı
            CustomerManager customerManager=new CustomerManager(StubLogger.GetLogger());

            customerManager.Save();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        //Bağımlılığı Sıfırlamak İçin Bi ILogger Türünde değer oluşturuyoruz

        private ILogger _logger;

        public CustomerManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved ... !");
            _logger.Log();
        }
    }

    interface ILogger
    {
        void Log();
    }

    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged With Log 4 Net ...");
        }
    }

    class NLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged With N Logged");
        }
    }

    //Null Object
    class StubLogger : ILogger
    {
        //1-------Burada Singleton Yerleştireceğiz
        private static StubLogger _stubLogger;
        //2---------Thread Safe HAle getiriyoruz
        private static object _lock=new object();
        //3---------Singleton olabilmesi için private bir Ctor'sini oluşturuyoruz
        private StubLogger()
        {
        }

        //4---------- Instance'ını alabilecke bir metod 
        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stubLogger == null)
                {
                    _stubLogger=new StubLogger();
                }
            }

            return _stubLogger;
        }


        public void Log()
        {
            
        }
    }

    //Örneğin Test Kodu Yazacağız
    //Burdaki derdimiz Save Metodunun doğru çalışıp çalışmadığı : 
    //Çalıştırabilmek için mecburen Bi Ilogger Nesnesi isteyecek ! Performans ve Zaman KAybı
    //Hiç bir şey yapmayan bi nesne göndereceğiz NullObject
    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager=new CustomerManager(StubLogger.GetLogger());
        }
    }


}
