//Дана цифра D (ціле однозначне число) і послідовність цілих чисел A.
//Витягти з A всі різні додатні числа, що закінчуються цифрою D (в вихідному порядку).
//При наявності повторюваних елементів видаляти всі їх входження, крім останніх.
//Порада: Послідовно застосувати методи Reverse, Distinct, Reverse. (2)

namespace Lab1_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> A = new List<int> { 2, 45, 35, 32, -5, -23, 45, 5, 15, 25, 75, 65, 5, 75, 492, 123, 15 };

            Console.WriteLine("Введіть число");
            string D = Console.ReadLine();

            Console.Clear();

            var sortedA = (from a in A where a.ToString().EndsWith(D) && !a.ToString().StartsWith("-") select a).Reverse().Distinct().Reverse().ToList();

            for (int i = 0; i < sortedA.Count; i++) Console.WriteLine(sortedA[i]);

            Console.ReadKey();
        }
    }
}