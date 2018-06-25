using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Multiton
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singletonın geliştirilmiş versiyonudur .. 
            //Singletonda 1 nesneden 1 kere üretildiği garanti edilirdi ..(100 istekte aynı referans)
            //Multitonda belli şarta uyan aynı instance örneklerine gidiyoruz(100 instance için örnek 10 ref üretilir)

            Camera camera1 = Camera.GetCamera("NIKON");
            Camera camera2 = Camera.GetCamera("CANON");
            Camera camera3 = Camera.GetCamera("NIKON");
            Camera camera4 = Camera.GetCamera("NIKON");
            Camera camera5 = Camera.GetCamera("CANON");

            Console.WriteLine(camera1.Id);
            Console.WriteLine(camera2.Id);
            Console.WriteLine(camera3.Id);
            Console.WriteLine(camera4.Id);
            Console.WriteLine(camera5.Id);

            Console.ReadLine();

        }
    }

    class Camera
    {
        //Örnek : Marka olarak ayrı ayrı instance vermek
        //için 
        static Dictionary<string,Camera> cameras =new Dictionary<string, Camera>();

        //Multithread ortamlar için lock nesnesi
        static object _lock=new object();
        //Uniq Identifier
        public Guid Id { get; set; }
        

        private Camera()
        {
            //Bize bir key vericek
            Id = Guid.NewGuid();
        }

        public static Camera GetCamera(string brand)
        {
            lock (_lock)
            {
                if (!cameras.ContainsKey(brand))
                {
                    cameras.Add(brand,new Camera());
                }
            }

            return cameras[brand];
        }
    }
}
