using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyObj myObj = new MyObj();
            myObj.Run();

            //关于枚举的序列化与反序列化

            Console.ReadLine();
        }
    }

    public class MyObj : AbstractObj
    {
        protected override void ExceuteBody()
        {
            Console.WriteLine("ExceuteBody");
        }

        protected override void Exceuted()
        {
            Console.WriteLine("MyObj:Exceuted");
        }
    }

    public abstract class AbstractObj
    {
        public void Run()
        {
            ExceuteBody();
            Exceuted();
        }

        protected abstract void ExceuteBody();

        protected virtual void Exceuted()
        {
            Console.WriteLine("Exceuted");
        }
    }
}
