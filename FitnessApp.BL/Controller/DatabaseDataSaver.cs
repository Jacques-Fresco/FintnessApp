﻿using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (FitnessContext db = new FitnessContext())
            {
                return db.Set<T>().Where(t => true).ToList();
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (FitnessContext db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
