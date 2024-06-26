﻿using System;
using System.Collections.Generic;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; } // Коллекция всех упражнений (свойством управляет Entity Framework)
        // сразу будут присоединены все песни которые относятся к конкретной активности
        public double CaloriesPerMinute { get; set; }
        public Activity() { }
        public Activity(string name, double caloriesPerMinute)
        {
            // Проверка

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
