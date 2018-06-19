using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //FactoryMethoda ek olarak 
            //İŞ katmanında çok yoğun kullanılır (Belli işlemleri farklı yollarla yapmak)

            ProductManager _productManager=new ProductManager(new Factory1());
            _productManager.GetAll();

            Console.ReadLine();

        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Log4Net with logged.");
        }
    }

    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("NLogger with logged.");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Caching with MemCache");
        }
    }

    public class RedisCache: Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Caching with RedisCache");
        }
    }


    //Yeni Fabrikalar üretebiliriz
    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConcernsFactory
    {

        public override Caching CreateCaching()
        {
            return new MemCache();
            
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernsFactory _concernsFactory;

        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernsFactory concernsFactory)
        {
            _concernsFactory = concernsFactory;
            _logging = _concernsFactory.CreateLogger();
            _caching = _concernsFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Cached");
            Console.WriteLine("Products Listed...");
        }
    }
}
