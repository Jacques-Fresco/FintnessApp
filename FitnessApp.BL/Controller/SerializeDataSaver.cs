using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

namespace FitnessApp.BL.Controller
{
    class SerializeDataSaver : IDataSaver
    {   
        public List<T> Load<T>() where T : class
        {
            BinaryFormatter formatter = new BinaryFormatter();

            var fileName = typeof(T).Name; // определяем тип файла, и приводим наименование к тексту

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            BinaryFormatter formatter = new BinaryFormatter();

            var fileName = typeof(T).Name;

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
