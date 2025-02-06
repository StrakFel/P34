using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_8
{
    //Интерфейсы
    public interface IPrintable
    {
        void Print();
    }
    public interface IScannable
    {
        void Scan();
    }

    public class MyDivacer : IPrintable, IScannable
    {
        public void Print() { Console.WriteLine("Print...."); }
        public void Scan() { Console.WriteLine("Scan...."); }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
