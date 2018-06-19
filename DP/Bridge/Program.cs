using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bridge : Nesne içinde soyutlanabilir , değiştirilebilir kısımlar varsa
            //Gerçekleştirip kullanırız .. 

            CustomerManager cm=new CustomerManager();
            cm.MessageSenderBase=new MailSender();
            //MessageSenderBase objesinin referansı atanmadığı için sadece bu kod hata verir
            cm.UpdateCustomer();

            Console.ReadLine();
        }
    }

    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Saved.");
        }

        public abstract void Send(Body body);
     
    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class MailSender : MessageSenderBase
    {
        

        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via MailSender",body.Title);
        }
    }

    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender", body.Title);
        }
    }

    //..

    class CustomerManager
    {
        //Bridge oluşturma
        public MessageSenderBase MessageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body{Title = "About the course"});
            Console.WriteLine("Customer Updated.");
        }

    }
}
