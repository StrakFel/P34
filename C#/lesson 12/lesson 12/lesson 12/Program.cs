﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             
             1. Збирання сміття("Garbage Collection" GC) - це процес автоматичного управляння пам'яттю.
              - крована пам'ять (meneged memeory) (GC працює)
              - некерована пам'ять (unmeneged memeory) (GC не працює)

             2. Як працию збирання сміття?
                 3 етапи:
                     1й Маркування (визначає об'єкти, до яких є доступ)
                     2й Стиснення (переміщення об'єктів для дефрагментації пам'яті)
                     3й Звільнення пам'яті (видалення непотрібних об'єктів)

             3.Покоління в збирання сміття (в 3 покоління)
                Покоління 0: новостворенні об'єкти. GC спочатку перевіряє це покоління
                Покоління 1: об'єкти середньою "довговічності"
                Покоління 2: об'єкти, які живуть найдовше.

             4. Виклик збирання сміття вручну
                  GC.Collect();

             5. Некерована пам'ять і метод Dispose
                  - Інтерфейс IDidposrblr і Dispose
                  - Блок using, який автоматично викликає Dispose

                       using (var file = new StramWrite("example.txt")){
                           file.WriteLine("Hello World");
                       }

             6. Події збирання сміття 
                 GC може ініціювати подію:
                      GCNotofocationStatus - дозволяє підписуватись на події завершення GC.

             7. Оптимізація роботи з пам'яттю:
                 - Уникайте надмірного використання статичнихї об'єктів
                 - Мінімізуйте використання великих об'єктів
                 - Використовуйте пул об'єктів для об'єктів, які використовуютсья часто

             */
        }
    }
}
