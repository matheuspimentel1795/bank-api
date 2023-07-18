using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUserBank.Seeders
{
    
        public abstract class BaseSeed<T> where T : class
        {
            internal ModelBuilder _modelBuilder;
            public List<T> Data = new();
            protected BaseSeed() { }
            protected BaseSeed(ModelBuilder modelBuilder)
            {
                _modelBuilder = modelBuilder;
                Run();
            }

            internal void Run()
            {
                try
                {
                    Seed();
                }
                catch (Exception ex)
                {
                    Console.Write($"Catch on Seed {ex.Message}");
                    Console.Write($"Catch on Seed {ex.StackTrace}");
                }
                if (_modelBuilder != null && Data.Count > 0) _modelBuilder.Entity<T>().HasData(Data);
            }
            public List<T> FakeMany(int quantity)
            {
                return GetFaker().Generate(quantity);
            }

            public T FakeOne()
            {
                return GetFaker().Generate(1).First<T>();
            }
            internal abstract Faker<T> GetFaker();
            internal abstract void Seed();
        }
    }

