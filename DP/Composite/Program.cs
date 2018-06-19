using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ağaç yapısı : Örn : Kurumlardaki Organizasyon Şeması İçin Kullanılır
            //Bir kurumdaki çalışanlar ve hiyerarşisi

            Employee berkay = new Employee {Name = "Berkay Yalçın"};

            Employee misra = new Employee { Name = "Mısra Güney" };

            //Alt çalışan ekledik 
            berkay.AddSubordinate(misra);

            Employee ahmet = new Employee {Name = "Ahmet Keser"};

            misra.AddSubordinate(ahmet);

            Contractor ali = new Contractor {Name = "Ali Duru"};

            ahmet.AddSubordinate(ali);


            
            Console.WriteLine(berkay.Name);
            //Olaya hangi hiyerarşiden başlayacağımız temsil edelim
            //Iterator diyince akla foreach döngüsü gelir
            foreach (Employee manager in berkay)
            {
                Console.WriteLine("\t"+manager.Name);
                foreach (Employee employee in manager)
                {
                    Console.WriteLine("\t\t" + employee.Name);
                    foreach (IPerson contractor in employee)
                    {
                        Console.WriteLine("\t\t\t" + contractor.Name);
                    }
                    
                }

            }


            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }   
    }

    class Contractor : IPerson
    {
        public string Name { get ; set ; }
    }

    //Gezebilecek Enumerable Bi yapıyla Implemente ettik
    class Employee : IPerson, IEnumerable<IPerson>
    {
        //Hiyerarşik Yapıyı yazıyoruz
        List<IPerson> _subordinates=new List<IPerson>();

        //alt nesneleri belirliyoruz..
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        //Nesneye erişebilecek
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
       

        public string Name { get; set; }

        //Enumerator Hazır bi Yapı
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var sbordinate in _subordinates)
            {
                //Enumerable dönmesi için Yield
                yield return sbordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


}
