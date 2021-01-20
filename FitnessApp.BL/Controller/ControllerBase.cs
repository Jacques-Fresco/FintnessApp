using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller
{
    public abstract class ControllerBase
    {
        protected IDataSaver saver = new DatabaseDataSaver();

        protected void Save(string fileName, object item)
        {
            saver.Save(fileName, item);
        }
        protected T Load<T>(string fileName) where T : class
        {
            return saver.Load<T>(fileName);
        }
    }
}
