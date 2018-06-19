using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            //Amaç
            //Her bir sınıfa tek tek ulaşmaktansa bir cepheye toplayıp ordan ulaşmak
            CustomerManager cm=new CustomerManager();
            cm.Save();

            Console.Read();
        }
    }

    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged..");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Caching...");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("Checkedd..");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class CustomerManager
    {
        //private ILogging _logging;
        //private ICaching _caching;
        //private IAuthorize _authorize;

        private CrossCuttingConcernsFacade _concerns;

        public CustomerManager()
        /*ILogging logging, ICaching caching, IAuthorize authorize*/
        {
            _concerns=new CrossCuttingConcernsFacade();
            //_logging = logging;
            //_caching = caching;
            //_authorize = authorize;
        }

        public void Save()
        {
            //_logging.Log();
            //_caching.Cache();
            //_authorize.CheckUser();
            _concerns.Logging.Log();
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            Console.WriteLine("Saved......");
        }
    }


    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttingConcernsFacade()
        {
            Logging=new Logging();
            Caching=new Caching();
            Authorize=new Authorize();
        }

    }
}
