using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            // Çok sık karşımıza çıkmaz ...
            // Bir nesne değişikliğe uğradıktan sonra istendikten sonra 
            // Eski haline dönüşünün sağlanması .............(Değişiklerin geri alınması)
            Book book = new Book
            {
                Isbn = "1234",
                Title = "Sefiller",
                Author = "Victor Hugo"
            };
            book.ShowBook();

            //Kullanıcı ekranda değişiklikler yaptı

            CareTaker history=new CareTaker();
            //Yedeği oluşturduk
            history.memento = book.CreateUndo();

            book.Isbn = "54235641";
            book.Title = "VICTOR HUGO";

            book.ShowBook();

            book.RestoreFromUndo(history.memento);

            book.ShowBook();
            Console.ReadLine();

        }
    }


    class Book
    {
        //Encapsulation uyguladık ...........
        private string _isbn;
        private string _author;
        private string _title;
        private DateTime _lastEdited;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                SetLastEdited();
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                SetLastEdited();
            }
        }

        public string Isbn
        {
            get => _isbn;
            set
            {
                _isbn = value;
                SetLastEdited();
            }
        }

        //Değiştirilme tarihini tutuyoruz
        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        //Geriye döndürme
        public Memento CreateUndo()
        {
            return new Memento(_isbn,_title,_author,_lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0} , {1} , {2} edited : {3}",Isbn,Title,Author,_lastEdited);
        }
    }

    //Mementoya göre

    class Memento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn,string title,string author,DateTime lastedit)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastedit;
        }
    }

    //Yukardaki hafızanın kendisini döndürür
    class CareTaker
    {
        public Memento memento { get; set; }
    }
}
