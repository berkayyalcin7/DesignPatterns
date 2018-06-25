using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dependency Injection Konfigürasyon Aracı : IoC container kullanılır(Ninject Örn)
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //ProductManager productManager = new ProductManager(new EfProductDal());
            //productManager.Save();

            //IoC Container Kullanımı : 
            IKernel kernel = new StandardKernel();
            //InSingletonScope ciddi bi performans artışı sağlar
            kernel.Bind<IProductDal>().To<EfProductDal>();
            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
            productManager.Save();
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed (For): {stopwatch.Elapsed}");
            Console.ReadLine();
        }
    }


    interface IProductDal
    {
        void Save();
    }



    class EfProductDal:IProductDal
    {

        //Burada Sıkıntı EF ' ye bağımlıyız 
        // Kodu baştan böyle yazmamalıydık ... (Interface Yazılmadan Tek başına kullanılması saçma)
        public void Save()
        {
            Console.WriteLine("Saved with Entity Framework ....");
        }
    }

    class NHibernateProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Nhibernate ....");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Save()
        { 
            // Business Codes : İş Katmanı Kodlarımız  yazıldıktan sonra

            //ProductDal'a new işlemi kullanırsak Bağımlı Kalıyoruz
            
            _productDal.Save();
        }
    }

}
