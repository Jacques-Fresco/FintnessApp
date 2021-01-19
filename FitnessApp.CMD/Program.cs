using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
                                 //CurrentCulture; // системная культура пользователя 
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-us"); // выбрать локализацию самостоятельно
            ResourceManager resourceManager = new ResourceManager("FitnessApp.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.Write(resourceManager.GetString("EnterName", culture));
            string name = Console.ReadLine();

            UserController userController = new UserController(name);
            EatingController eatingController = new EatingController(userController.CurrentUser);
            ExerciseController exerciseController = new ExerciseController(userController.CurrentUser);

            if(userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                string gender = Console.ReadLine();
                DateTime bithDate = ParseDateTime("дату рождения");
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetNewUserData(gender, 
                                              bithDate, 
                                              weight, 
                                              height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести прием пищи");
            Console.WriteLine("A - ввести упражнение");
            Console.WriteLine("Q - выход");
            ConsoleKeyInfo key = Console.ReadKey();

            while(true)
            {
                switch(key.Key)
                {
                    case ConsoleKey.E:
                        (Food Food, double Weight) foods = EnterEating(); 
                        eatingController.Add(foods.Food, foods.Weight);
                        
                        foreach(KeyValuePair<FitnessApp.BL.Model.Food, double> item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        (DateTime Begin, DateTime End, Activity Activity) exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach(Exercise item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{item.Activity} с {item.Start.Hour} до {item.Finish.Hour}");
                        }

                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            string name = Console.ReadLine();

            double energy = ParseDouble("расход энергии в минуту");

            DateTime begin = ParseDateTime("начало упражнения");
            DateTime end = ParseDateTime("окончание упражнения ");

            Activity activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {

            Console.Write("\nВведите имя продукта: ");
            string food = Console.ReadLine();

            double calories = ParseDouble("калорийность");
            double prots = ParseDouble("белки");
            double fats = ParseDouble("жиры");
            double carbs = ParseDouble("углеводы");

            double weight = ParseDouble("вес порции");
            Food product = new Food(food, calories, prots, fats, carbs);

            return (product, weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime bithDate;
            while (true)
            {
                Console.Write($"Введите {value} (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out bithDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}. Попробуйте снова.");
                }
            }

            return bithDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}. Попробуйте снова.");
                }
            }
        }
    }
}
