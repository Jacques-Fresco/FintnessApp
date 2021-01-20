using FitnessApp.BL.Model;
using System;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    class DatabaseDataSaver : IDataSaver
    {
        public T Load<T>(string fileName) where T : class
        {
            using (FitnessContex db = new FitnessContex())
            {
                return db.Set<T>().FirstOrDefault();
            }
        }

        public void Save(string fileName, object item)
        {
            using (FitnessContex db = new FitnessContex())
            {
                Type type = item.GetType();

                if (type == typeof(User))
                {
                    db.Users.Add(item as User);
                }
                else if(type == typeof(Gender))
                {
                    db.Genders.Add(item as Gender);
                }
                else if (type == typeof(Food))
                {
                    db.Foods.Add(item as Food);
                }
                else if (type == typeof(Exercise))
                {
                    db.Exercises.Add(item as Exercise);
                }
                else if (type == typeof(Eating))
                {
                    db.Eatings.Add(item as Eating);
                }
                else if (type == typeof(Activity))
                {
                    db.Activities.Add(item as Activity);
                }

                db.SaveChanges();
            }
        }
    }
}
