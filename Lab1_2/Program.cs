
using System.Text;
using Newtonsoft.Json;
//Написати програму згідно виданого завдання використовуючи словники Dictionary в C#.
//Якщо результатом виконання програми є словник, зберегти цей результат у JSON файл

//Вивести елементи словника строка за строкою.
//Записати результат у файл.
//Перетворити вміст файлу назад у словник.
//Результат записати в JSON форматі



namespace Lab1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Anna\\Desktop\\Навчання КПІ\\Програмування\\Лаба 1.1\\Текстовый документ.txt";
            Dictionary<int, string> countries = new Dictionary<int, string>()
            {
                {1, "КНР"},
                {2, "Iндiя"},
                {3, "США"},
                {4, "Iндонезiя"},
                {5, "Пакистан"},
                {6, "Бразилiя"},
                {7, "Нiгерiя"},
                {8, "Бангладеш"},
                {9, "Росiя"},
                {10, "Мексика"},
            };

            Console.WriteLine("Рейтинг країн за чисельнiстю населення\n");
            Write(countries);

            StreamWriter(countries, path);//запис у файл
            countries.Clear();

            Console.ReadKey();
            Console.Clear();

            StreamReader(countries, path);//запис у словник
            Console.WriteLine("Рейтинг країн за чисельнiстю населення(зчитано з файлу)\n");
            Write(countries);

            Console.ReadKey();
            Console.Clear();

            string json = JsonConvert.SerializeObject(countries);
            Console.WriteLine(json);
            Console.ReadKey();
        }
        static void StreamWriter(Dictionary<int, string> countries, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                foreach (KeyValuePair<int, string> county in countries)
                {
                    sw.WriteLine($" {county.Key} \n{county.Value} ");
                }
            }
        }
        static void StreamReader(Dictionary<int, string> countries, string path)
        {

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                int index;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (int.TryParse(line, out index))
                    {
                        line = sr.ReadLine();
                        countries.Add(index, line);
                    }
                }
            }
        }
        static void Write(Dictionary<int, string> dict)
        {
            foreach (KeyValuePair<int, string> d in dict)
            {
                Console.WriteLine($" {d.Key} - {d.Value} ");
            }
        }
    }
}
