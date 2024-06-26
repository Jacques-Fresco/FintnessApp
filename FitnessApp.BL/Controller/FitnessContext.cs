﻿using System;
using System.Data.Entity;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller
{
    public class FitnessContext : DbContext
    {
        public FitnessContext() : base("DBConnetion") { }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
