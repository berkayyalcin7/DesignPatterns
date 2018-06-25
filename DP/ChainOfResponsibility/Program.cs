using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nesneler Arası Hiyerarşik yapı ..
            // Örn : Şirkette harcamaların 100 Tl altındaysa Müdür yetki verebiliyor
            // Fiyat arttıkça bi üst kişi yetkilendirir

            Manager manager=new Manager();
            VicePresident vicePresident=new VicePresident();
            President president=new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expense expense=new Expense{Detail = "Training" , Amount = 918};
            manager.HandleExpense(expense);

            Console.ReadLine();


        }
    }

    public class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        //Harcamayı Handle Edecek kişi
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpense(Expense expence);

        public void SetSuccessor(ExpenseHandlerBase succesor)
        {
            Successor = succesor;
        }
    }

    class Manager : ExpenseHandlerBase
    {
       

        public override void HandleExpense(Expense expence)
        {
            if (expence.Amount <= 100)
            {
                Console.WriteLine("Manager handled the expense !");
            }
            else if (Successor!=null)
            {
                //Successor bunu handle etsin
                Successor.HandleExpense(expence);
            }
            
        }
    }

    class VicePresident : ExpenseHandlerBase
    {
        

        public override void HandleExpense(Expense expence)
        {
            if (expence.Amount >= 100 && expence.Amount <=1000)
            {
                Console.WriteLine("Vice President handled the expense !");
            }
            else if (Successor != null)
            {
                //Successor bunu handle etsin
                Successor.HandleExpense(expence);
            }
        }
    }

    class President : ExpenseHandlerBase
    {

        public override void HandleExpense(Expense expence)
        {
            if (expence.Amount >= 1000)
            {
                Console.WriteLine("President handled the expense !");
            }

            //else if (Successor != null)
            //{
            //    //Successor bunu handle etsin
            //    Successor.HandleExpense(expence);
            //}
        }
    }
}
