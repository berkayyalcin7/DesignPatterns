using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Farklı sistemleri birbiriyle etkileşimini sağlar
            //Örn : Canlı Online Eğitimde Her Öğrencinin Sorularını Yanıtlaması için Sistem
            //Mediator Görevi Gören Sistemdir -> Kule noktası gibi düşünülebilir .....

            Mediator mediator=new Mediator();
            

            //İletişim kurulan kişi mediator
            Teacher teacher=new Teacher(mediator);
            teacher.Name = "Berkay";

            //Mediator'a Öğretmeni tanımladık
            mediator.Teacher = teacher;


            Student misra=new Student(mediator);
            misra.Name = "Mısra";
            
           
            Student ahmet = new Student(mediator);
            ahmet.Name = "Ahmet";

            //Mediator'a Öğrenci Ekledik
            mediator.Students=new List<Student>{misra,ahmet};

            teacher.SendNewImageUrl("slide1.jpg");
            teacher.RecieveQuestion("Is it True",misra);
            Console.ReadLine();



        }
    }

    abstract class CourseMember
    {
        //Protected ' da değer büyük yazılır.
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        //Teacher'a gönderdiğimiz
        public Teacher(Mediator mediator) : base(mediator)
        {

        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved  a question from {0}, {1}",student.Name,question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}",url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question {0},{1}",student.Name,answer);
        }

        public string Name { get; set; }
        
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }

        public void ReciveImage(string url)
        {
            Console.WriteLine("{1} received image : {0}",url,Name);
        }

        public void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student recieved answer : {0}",answer);
        }

        public string Name { get; set; }
    }

    //Sistemin Kendisi : Ne yapılacağına karar verir
    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        //Bütün Öğrencilere Image Gönderme
        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReciveImage(url);
            }
        }

        public void SendQuestion(string question,Student student)
        {
            Teacher.RecieveQuestion(question,student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
