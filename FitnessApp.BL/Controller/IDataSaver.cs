﻿using System.Collections.Generic;

namespace FitnessApp.BL.Controller
{
    public interface IDataSaver
    {
        void Save<T>(List<T> item) where T : class; // для сохранения коллекции элементов
        List<T> Load<T>() where T : class; // для загрузки коллекции элементов
    }
}
