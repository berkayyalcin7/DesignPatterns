using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nesneyi 1 kere ürettiğimizden emin olmuş oluyoruz
            var customer = CustomerManager.CreateAsSingleton();
            customer.Save();

            

        }
    }

    class CustomerManager
    {
        //Field
        //Nesne oluşturulmuşsa bunu döndür..
        //IoC containerlar kullandığımız zaman alttaki kodları yazmamıza gerek yok
        private static CustomerManager _customerManager;

        //ThreadSafe Singleton
        static object _lockObject=new object();
        

        //Dış Erişime Engelleme : Singletona uyma
        private CustomerManager()
        {

        }

        //Metodun içinde CustomerManager Nesnesinden Daha öncesi varsa
        //oluşturulmuşu vericez yoksa oluşturup vericeğiz
        public static CustomerManager CreateAsSingleton()
        {
            //if(_customerManager==null)
            //{
            //    //Eğer alan Boş ise Yeni nesne oluştur
            //    _customerManager = new CustomerManager();
            //} veya

            // _customerManager eğer Null ise yeni nesne oluştur.

            //2 tane aynı nesneyi üretmeyi engellemek için
            //Lock ile bir kişi nesne üretme aşamasında nesneyi
            //kitler
            lock (_lockObject)
            {
                if (_customerManager==null)
                {
                    _customerManager=new CustomerManager();
                }
            }

            return _customerManager;
        }

        public void  Save()
        {
            Console.WriteLine("Saved !");
        }
    }
}
