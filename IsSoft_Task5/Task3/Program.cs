using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Vacation vacation = new Vacation("Vlad", DateTime.Today.AddDays(-7), DateTime.Today);
            Vacation vacation2 = new Vacation("Vlad", DateTime.Today.AddDays(-4), DateTime.Today);
            Vacation vacation3 = new Vacation("Vlad", DateTime.Today.AddMonths(-6), DateTime.Today);
            Vacation vacation4 = new Vacation("Dima", DateTime.Today.AddDays(-10), DateTime.Today);
            Vacation vacation5 = new Vacation("Dima", DateTime.Today.AddDays(-6), DateTime.Today);

            VacationDiary diary = new VacationDiary();
            diary.AddVocation(vacation);
            diary.AddVocation(vacation2);
            diary.AddVocation(vacation3);
            diary.AddVocation(vacation4);
            diary.AddVocation(vacation5);

            Console.WriteLine(diary.GetAverageVacationTime());

            Console.WriteLine("Average vacation days for every person: \n");
            var a = diary.GetAverageVacationForPersons();
            foreach (var i in a)
            {
                Console.WriteLine(i.Item1 + " - " + i.Item2);
            }


            Console.Write("Non Vacation days of 2021: \n");
            var b = diary.GetNonVacationDates();
            foreach (var i in b)
            {
                Console.WriteLine(i);
            }

            Console.Write("Count of people in vocation by month:\n");
            var c = diary.GetVacationByMonth();
            foreach (var i in c)
            {
                Console.WriteLine(i.Item1 + " - " + i.Item2);
            }

            Console.Write("Is this diary correct: " + diary.CheckVacationsIntersection());
        }
    }
}
