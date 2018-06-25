using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ziyaretçi Tasarım Deseni
            //Örn : Şirketteki bütün hiyerarşiye bi ödeme yapılması (maaş artışı)
            //Yöneticiye %20 zam , Çalışana %10 gibi

            Manager manager=new Manager{Name = "Berkay",Salary = 4000};
            Manager manager2 = new Manager {Name = "Mehmet", Salary = 3500};

            Worker worker = new Worker {Name = "Ahmet", Salary = 2000};
            Worker worker2 = new Worker { Name = "Ali", Salary = 2300 };

            manager.Subordinates.Add(manager2);
            manager2.Subordinates.Add(worker);
            manager2.Subordinates.Add(worker2);

            OrganizationalStructure organizationalStructure=new OrganizationalStructure(manager);

            PayrollVisitor payrollVisitor=new PayrollVisitor();
            PayRaiseVisitor payRaiseVisitor=new PayRaiseVisitor();

            //Organizasyon Yapımıza Visitor'ımızı ekliyoruz
            organizationalStructure.Accept(payrollVisitor);
            organizationalStructure.Accept(payRaiseVisitor);

            Console.ReadLine();



        }
    }

    class OrganizationalStructure
    {
        public EmployeeBase  Employee;

        //Ödeme sistemine başlayacağımız hiyerarşideki yer (En üst düzeydeki kişiyi vereceğiz)
        public OrganizationalStructure(EmployeeBase firstEmployee)
        {
            Employee= firstEmployee;
        }

        //Ziyaret işlemlerini yapıcak nesnenin kendisi
        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }

    //Bütün Personel İçin Zam Artışı , Maaş Ödeme Gibi işlemleri canlandırır
    abstract class VisitorBase
    {
        //Visit operasyonlarına Ya Çalışan Ya da Menajer geçmemiz gerek
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);


    }

    //Çalışanları oluşturuyoruz
    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates=new List<EmployeeBase>();
        }
        //Yönetici altında çalışanlar olabileceği için EmployeeBase verdik
        public List<EmployeeBase> Subordinates { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            //this : kendisini geçiyoruz
            visitor.Visit(this);
            //Bütün Subordinate leri geziyoruz
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    //Ödeme Sistemi
    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} Paid : {1}",worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} Paid : {1}", manager.Name, manager.Salary);
        }
    }

    class PayRaiseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} Salary increased to: {1}", worker.Name, worker.Salary*(decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} Salary increased to: {1}", manager.Name, manager.Salary * (decimal)1.2);
        }
    }

}
