using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nesne üretim maliyeti'ni minimize etmektir ....
            //Sadece ihtiyaçlar dahilinde kullanılmalı
            //Nesneyi Klonluyoruz ....

            Customer customer=new Customer
            {
                Name = "Berkay" , City = "Tekirdag",id = 5
            };
            //Console.WriteLine(customer.Name);

            //klon oluşturma
            var customer2 =(Customer)customer.Clone();
            customer2.Name = "Salih";

            Console.WriteLine(customer.Name);
            Console.WriteLine(customer2.Name);

            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();

        public int id { get; set; }
        public string Name { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person) MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
