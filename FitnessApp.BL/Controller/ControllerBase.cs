using System.Collections.Generic;

namespace FitnessApp.BL.Controller
{
    public abstract class ControllerBase
    {
        // поле - экземпляр интерфейса для того, чтобы в нашего менеджера можно было подставить любой экземпляр класс, реализующий данный интерфейс 
        private readonly IDataSaver manager = new DatabaseDataSaver();
        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }
        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}
