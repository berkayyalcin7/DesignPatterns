using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Strateji belirleyip o metodun buna göre çalıştırılması
            //İş katmanında belli bi mevzuata göre hesaplama  : Bankacılık - Kredi 
            CustomerManager cm=new CustomerManager();
            cm.CreditCalculatorBase=new After2010CreditCalculator();
            //Obje referans hatası vereceğiz metodu çağırmadan önce üste
            cm.SaveCredit();

            Console.ReadLine();
        }
    }

    abstract class CreditCalculatorBase
    {
        //normal şartlarda if-else koşullarıyla bir sürü işlem yapılacaktı 
        public abstract void Calculate();
    }

    class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit Calculated using before 2010");
        }
    }

    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit Calculated using after 2010");
        }
    }

    //kullanılacak ortam - İş katmanında
    class CustomerManager
    {
        //Base üzerinden işlemi gerçekleştiriiyor olacağzı
        public CreditCalculatorBase CreditCalculatorBase { get; set; }
        public void SaveCredit()
        {
            Console.WriteLine("CManager Business");
            CreditCalculatorBase.Calculate();
        }
    }

}
