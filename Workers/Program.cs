using System;
using System.Collections.Generic;
using System.Linq;

namespace Workers
{
    class Program
    {
        static void Main(string[] args)
        {
            var menNames = new List<string> { "Иван", "Алексей", "Игорь", "Андрей" };
            var menMiddleNames = new List<string> { "Иванович", "Алексеевич", "Петрович" };
            var womenNames = new List<string> { "Анна", "Инна", "Ольга", "Ирина" };
            var womenMiddleNames = new List<string> { "Ивановна", "Алексеевна", "Петровна" };
            var professions = new List<string> { "Мастер по укладке труб", "Бухгалтер", "Ученик мастера по укладке труб" };
            var workers = new List<Worker>();
            var rnd = new Random(31);
            for (int i = 0; i < 28; i++)
            {
                var isMen = (rnd.Next(2) == 0);
                var names = isMen ? menNames : womenNames;
                var middleNames = isMen ? menMiddleNames : womenMiddleNames;
                workers.Add(new Worker()
                {
                    // TODO: extension с рандомом
                    FirstName = names[rnd.Next(names.Count)],
                    MiddleName = middleNames[rnd.Next(middleNames.Count)],
                    Profession = professions[rnd.Next(professions.Count)],
                    Salary = rnd.Next(15000, 28000),
                    Score = (decimal)rnd.NextDouble() * 10
                });
            }
            foreach (var worker in workers)
                Console.WriteLine(worker.ToString());
            Console.WriteLine();
            var avgSalary = Math.Round(workers.Select(x => x.Salary).Average(), 2);
            var stringAvgSalary = String.Format("{0:0.00}", avgSalary.ToString());
            Console.WriteLine($"Работников: {workers.Count}, Средняя зарплата: {avgSalary} руб.");
            var bestScore = workers.Select(x => x.Score).Max();
            var best = workers.Where(x => bestScore == x.Score);
            if (best.Count() == 1)
                Console.Write("Лучший работник: ");
            else
                Console.WriteLine("Лучшие работники: ");
            foreach (var worker in best)
            {
                Console.WriteLine($"{worker.FirstName} {worker.MiddleName}, {worker.Profession}");
            }
        }
    }
}
