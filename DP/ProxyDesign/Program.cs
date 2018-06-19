using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProxyDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bir Hesap Yaptığımızı Düşünüyoruz ..

            //CreditManager manager=new CreditManager();

            //Proxy deseni kullanmadığımız için İkinci İşlemi hesaplarken 5 saniye daha bekleyecek
            //Console.WriteLine(manager.Calculate());
            //Console.WriteLine(manager.Calculate());


            //Proxy sayesinde 2. değeri direk return edecek ve bekleme yapmayacak
            CreditBase manager=new CreditManagerProxy();
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());


            Console.ReadLine();

        }

        
    }

    abstract class CreditBase
    {
        public abstract int Calculate();

    }

    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            return result;
        }
        
    }

    //Olayı burdan sürdüreceğiz
    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Calculate()
        {
            if (_creditManager==null)
            {
                _creditManager=new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }

            return _cachedValue;
        }
    }

}
