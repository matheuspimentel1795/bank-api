using ApiUserBank.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUserBank.Seeders
{
    public class Seederss : BaseSeed<UserBank>
    {
        public Seederss()
        {

        }
        public Seederss(ModelBuilder modelBuilder)  : base(modelBuilder)
        {
        }
        internal override Faker<UserBank> GetFaker()
        {
            return new Faker<UserBank>()
                .RuleFor(p => p.Id, f => f.Random.Int(10000, 99999))
                .RuleFor(p => p.AccountNumber, f => f.Random.Int(10000, 99999))
                .RuleFor(p => p.AccountValue, f => f.Random.Int(10000, 99999));
               
        }
        internal override void Seed()
        {

        }
    }
}
