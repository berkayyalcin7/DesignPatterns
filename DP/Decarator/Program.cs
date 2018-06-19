using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decarator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nesneye farklı anlamlar yüklemek için kullanılan pattern
            //Örn : e ticaret sistemindeki ürünü farklı zamanda farklı şekilde sunma
            var personelCar=new PersonalCar{Make = "BMW",Model = "3.20",HirePrice = 25000};

            SpecialOffer specialOffer=new SpecialOffer(personelCar);
            specialOffer.DiscountPercentages = 10;
            Console.WriteLine("Concrete : {0}", personelCar.HirePrice);

            Console.WriteLine("Special Offer : {0}",specialOffer.HirePrice);

            

            Console.ReadLine();

        }


    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get ; set ; }
        public override decimal HirePrice { get ; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase:CarBase
    {
        private CarBase _carbase;

        protected CarDecoratorBase(CarBase carbase)
        {
            _carbase = carbase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentages { get; set; }
        private readonly CarBase _carBase;
        public SpecialOffer(CarBase carbase) : base(carbase)
        {
            _carBase = carbase;
        }
        public override string Make { get; set; }
        public override string Model { get; set; }

        public override decimal HirePrice
        {
            get { return _carBase.HirePrice-_carBase.HirePrice * DiscountPercentages/100; }
            set { }
        }
    }

}


