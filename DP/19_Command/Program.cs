using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_Command
{
    class Program
    {
        static void Main(string[] args)
        {
            //Komut Deseni : Stok Ekranında Arka Arkaya işlem yaptıktan sonra VT ye göndermek
            //Örn : Metin Dosyasının Listede tutulmasında Ctrl + z işlemi
            //Hello World
            //Hello World2

            StockManager stockManager=new StockManager();
            BuyStock buyStock=new BuyStock(stockManager);
            SellStock sellStock=new SellStock(stockManager);

            //Hayata Geçirmek İçin
            StockController stockController=new StockController();
            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            stockController.TakeOrder(buyStock);

            //Place Order's ile bütün komutları Execute edebiliriz.
            stockController.PlaceOrders();

            Console.ReadLine();

        }
    }

    class StockManager
    {
        //field olarak kullandığımız için isimlendirmede ' _ ' kullandık
        private string _name = "Laptop";
        private int _quantity = 10;

        public void Buy()
        {
            Console.WriteLine("Stock : {0}, {1} bought ! ",_name,_quantity);
        }

        public void Sell()
        {
            Console.WriteLine("Stock : {0}, {1} sold ! ", _name, _quantity);
        }
    }

    
    //Komutların Base'i 
    interface IOrder
    {
        void Execute();
    } 
        
    
    //İşlemler İçin Komutları yazıyoruz
    class BuyStock:IOrder
    {
        private StockManager _stockManager;

        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }
        //Parametre olarak komutun yapması gereken 
        public void Execute()
        {
            _stockManager.Buy();
        }
    }

    class SellStock : IOrder
    {
        private StockManager _stockManager;

        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }
        //Parametre olarak komutun yapması gereken 
        public void Execute()
        {
            _stockManager.Sell();
            
        }
    }

    //Komutları Toplayacak Nesnemiz
    //Alma ve Satma işlemini  Controller'dan gerçekleştireceğiz
    class StockController
    {
        //komutun basei
        List<IOrder> _orders=new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void PlaceOrders()
        {
            foreach (var order in _orders)
            {

                order.Execute();
            }

            _orders.Clear();
        }
    }
}
