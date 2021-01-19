using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; } 
        /// <summary>
        /// Калории за 100 гр. продукта
        /// </summary>
        public double Calories { get; }

        /*private double ProteonsOneGramm { get { return Proteins / 100.0; } }
        private double FatsOneGramm { get { return Fats / 100.0; } }
        private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }
        private double CalloriesOneGram { get { return Calories / 100.0; } }*/

        public Food(string name) : this(name, 0, 0, 0, 0) { }
        public Food(string name, 
                    double callories, 
                    double proteins, 
                    double fats, 
                    double carbohydates)
        {
            Name = name;
            Calories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydates / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
