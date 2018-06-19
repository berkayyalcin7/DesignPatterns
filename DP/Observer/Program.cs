using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kendisine abone olan sistemlerin bir işlem olduğunda Devreye girmesi
            // Örn : Alışveriş sisteminde ürün fiyatı düştüğünde müşterinin haberdar edilmesi..
            ProductManager pdManager=new ProductManager();

            //Çalışanlar Attach ile seçtiğimiz observer ile bilgilendirildi..
            pdManager.Attach(new EmployeeObserver());
            pdManager.UpdatePrice();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        List<Observer> _observers=new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price Changed !");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }


    }

    //Observer nesnesi
    abstract class Observer
    {
        public abstract void Update();
    }

    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer : Product price changed !");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee : Product price changed !");
        }
    }

}
