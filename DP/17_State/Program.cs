using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_State
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bir olayın mevcut Durumunu kontrol etmek için kullanılan DesignP
            //Nesne Sürecini Yönetebilmek için Bi Context'e ihtiyacımız var

            Context context=new Context();

            ModifiedState modifiedState=new ModifiedState();

            modifiedState.DoAction(context);


            //En Son Nerde Kaldıysa o dönecek
            Console.WriteLine(context.GetState());
            Console.ReadLine();

        }
    }

    interface IState
    {
        void DoAction(Context context);

    }

    class Context
    {
        private IState _state;
        //Gönderilen State 'i kullanarak yukardaki state ' ini set etmiş olacağız
        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }

    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Modified");
            //Context'i Set ettik ...
            context.SetState(this);
        }
    }

    class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Deleted");
            //Context'i Set ettik ...
            context.SetState(this);
        }
    }

}
