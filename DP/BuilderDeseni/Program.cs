using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDeseni
{
    class Program
    {
        static void Main(string[] args)
        {
             //İş ve arayüz katmanlarında ortaya bi nesnenin çıkarılması için
            ProductDirector director=new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();

            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.Id);
            Console.WriteLine(model.Discount);

            Console.ReadLine();

        }
    }

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public bool DiscountApplied { get; set; }
    }


    public abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();


    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model=new ProductViewModel();

        public override void ApplyDiscount()
        {
            model.Discount = model.UnitPrice*(decimal) 0.90;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverage";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        public override void ApplyDiscount()
        {
            model.Discount = model.UnitPrice * (decimal)0.70;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverage";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
    }

    //Prodcut'ı üretmek
    public class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
