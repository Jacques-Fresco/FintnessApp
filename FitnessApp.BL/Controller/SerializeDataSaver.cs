using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace FitnessApp.BL.Controller
{
    class SerializeDataSaver : IDataSaver
    {
        public T Load<T>(string fileName) where T: class
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public void Save(string fileName, object item)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
