using System;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int ActivityId { get; set; } // к какой конкретной активности принадлежит это упражнение
        public virtual Activity Activity { get; set; } // обращение через упражнение к активности
        public int UserId { get; set; } // кому конкретно принадлежит это упражнение
        public virtual User User { get; set; } // обращение через упражнение к пользователю
        public Exercise() { }
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            // Проверка

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
