using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    enum Tipi
    {
        Pesin,
        Taksit
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Strategy Design Pattern‘i davranışın tamamen değiştiği durumlarda,
            //Template Method Design Pattern’i ise davranışın bir kısmı değiştiği
            //durumlarda kullanılır : İç işlemleri Soyutlayarak Sınıflarımızı yazıyoruz.
            

            //Hesaplama işlemi : TimeSpan() : Saat,Dakika,Saniye döndürür

            ScoringAlgorithm algorithm;
            Console.WriteLine("Mans ");
            algorithm=new MensScoringAlforithm();
            Console.WriteLine(algorithm.GenerateScore(8,new TimeSpan(0,1,15)));
            Console.WriteLine("Woman ");

            algorithm=new WomanScoringAlforithm();
            Console.WriteLine(algorithm.GenerateScore(15,new TimeSpan(0,2,32)));

            Console.ReadLine();
        }
    }

    abstract class ScoringAlgorithm
    {
        //template metodumuz
        public int GenerateScore(int hits,TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);
        public abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculateBaseScore(int hits);

    }

    class MensScoringAlforithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }

    class WomanScoringAlforithm : ScoringAlgorithm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 150;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int) time.TotalSeconds / 6;
        }
    }


}
