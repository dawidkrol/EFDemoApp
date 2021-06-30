using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITraining
{
    public class Application : IApplication
    {
        private readonly PeopleContext _people;

        public Application(PeopleContext people)
        {
            this._people = people;
        }
        public void OnStart()
        {
            IQueryable<Person> peopleData;

            //V1
            //var p = _people.People
            //    .Where((x) => x.Age <= 20)
            //    .OrderBy((x) => x.FirstName)
            //    .ToHashSet()
            //    //.Select((x, y) => $"{y} = {x.FirstName} {x.LastName}");
            //    .Select((x, y) => (ID: y, x.FirstName, x.LastName));

            //V2
            //var p =
            //    from x in _people.People
            //    where x.Age <= 20
            //    orderby x.FirstName
            //    select x
            //    into n
            //    select $"{n.FirstName} {n.LastName}";

            //foreach (var item in p)
            //{
            //    //Console.WriteLine($"item");
            //    Console.WriteLine($"{item.ID} = {item.FirstName} {item.LastName}");
            //}

            //_people.Add(new Employee()
            //{
            //    FirstName = "Jan",
            //    LastName = "Kowalski",
            //    Age = 30,
            //    Position = "CEO",
            //    EmailAdressess = new List<Email> { new Email() { EmailAddress = "Jankowalsky@gmail.com" } },
            //});
            //_people.SaveChanges();

            var p = _people.Employees.Where(x => x.Age == 30).ToList();
            foreach (var item in p)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age}");
            }
        }
    }
}
