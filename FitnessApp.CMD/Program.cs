using FitnessApp.BL.Controller;
using System;

namespace FitnessApp.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение FitnessApp");

            Console.Write("Введите имя пользователя: ");
            string name = Console.ReadLine();

            Console.Write("Введите пол: ");
            string gender = Console.ReadLine();

            Console.Write("Введите дату рождения: ");
            DateTime birthday = DateTime.Parse(Console.ReadLine()); // TODO: переписать

            Console.Write("Введите вес: ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("Введите рост: ");
            double height = double.Parse(Console.ReadLine());

            UserController userController = new UserController(name, gender, birthday, weight, height);
            userController.Save();
        }
    }
}
