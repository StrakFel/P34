using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Person person_1 = new Person { name = "Serhii", age = 15 };
            //person_1.Say_Hello();
            Person person_2 = new Person ("Vladislav",19);
            person_2.Say_Hello();
            person_2.age = 1;
            person_2.Say_Hello();

            List<Person> persons = new List<Person>();
            persons.Add(new Person());


            int num = 0;
            try
            {
                Console.WriteLine("Enter the number");
                //int num = Convert.ToInt32(Console.ReadLine());
                num = int.Parse(Console.ReadLine());
                int a = 20, b = 0;
                Console.WriteLine(a / b);
            }
            catch (FormatException ex) //Тип ошибки, название
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("На ноль делить нельзя");
            }
            finally
            {
                Console.WriteLine($"Your number is {num}");
            }

            //try - код, который нужно проверить
            //catch - обработка исключения
            //finally - выполняет код в независимости от того была ли ошибка
            //throw - используется для генерации исключений
        }
    }
}
