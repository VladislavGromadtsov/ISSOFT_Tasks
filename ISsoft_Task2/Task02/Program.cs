using System;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Lecture lecture1 = new Lecture() {Description = "Smth1", Theme = "Theme1"};
            Lecture lecture2 = new Lecture() { Description = "Smth2", Theme = "Theme2" };

            PracticalLesson practicalLesson1 = new PracticalLesson()
                {Description = "SmthP1", SolutionLink = "Solut1", TaskLink = "Task1"};
            PracticalLesson practicalLesson2 = new PracticalLesson()
                {Description = "SmthP2", SolutionLink = "Solut2", TaskLink = "Task2" };

            Training training = new Training() {Description = "Train"};

            Console.WriteLine($"Training is practical: {training.IsPractical()}");

            training.Add(practicalLesson1);
            training.Add(practicalLesson2);
            Console.WriteLine($"Training is practical: {training.IsPractical()}");


            training.Add(lecture1);
            Console.WriteLine($"Training is practical: {training.IsPractical()}");
            training.Add(lecture2);
            Console.WriteLine($"Training is practical: {training.IsPractical()}");
        }
    }
}
