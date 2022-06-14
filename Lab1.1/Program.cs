
using  Lab1;
//У файлі збережено адреси. Побудувати список C1, елементи якого містять назву вулиці та індекси даних адрес,
//причому елементи списку повинні бути впорядковані за зростанням індексів.
//Потім "стиснути" список C1, видаляючи дублюючі назви об'єктів

    internal class Program
{
    public static int CompareStreets(Street street1, Street street2)
    {
        return street1.Index.CompareTo(street2.Index);
    }
    static void Main(string[] args)
    {
        List<Street> streets = new List<Street>();
        string path = "C:\\Users\\Anna\\Desktop\\Навчання КПІ\\Програмування\\Лаба 1.1\\streets.txt";
        
        using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
        {
            int index;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (int.TryParse(line, out index))
                {
                    line = sr.ReadLine();
                    streets.Add(new Street() { Name = line, Index = index });
                }
            }
        }

        streets.Sort(CompareStreets);

        foreach (Street street in streets)
        {
            Console.WriteLine($"Index - {street.Index} --> street - {street.Name}");
        }
       
        Console.WriteLine("-----------------");

        for (int i = 0; i < streets.Count; i++)
        {
            for (int j = 0; j < streets.Count; j++)
            {
                if (streets[i].Name == streets[j].Name && streets[i].Index != streets[j].Index)
                {
                    streets.RemoveAt(j);
                }
            }
        }


        foreach (Street street in streets)
        {
            Console.WriteLine($"Index - {street.Index} --> street {street.Name}");
        }
        Console.ReadKey();
    }


}
  
