using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
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

            //var p = _people.Employees.Where(x => x.Age == 30).ToList();
            //foreach (var item in p)
            //{
            //    Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age}");
            //}

            //_people.Add(new Employee()
            //{
            //    FirstName = "Gerard",
            //    LastName = "Gacek",
            //    Age = 20,
            //    WorkDones = new List<WorkDone>()
            //    {
            //        new WorkDone()
            //        {
            //            NameOfWork = "Planning app",
            //            TimeOfWork = DateTime.FromBinary(1000)
            //        },
            //        new WorkDone()
            //        {
            //            NameOfWork = "Start producing app",
            //            TimeOfWork = DateTime.FromBinary(30000)
            //        }
            //    },
            //    Position = "CEO"

            //});
            //_people.SaveChanges();

            //_people.Employees.Where((x) => x.FirstName == "Gerard").Include("WorkDones").First().WorkDones.First().TimeOfWork = TimeSpan.FromMinutes(220);
            //_people.SaveChanges();

            //IMPORTANT INCLUDE()
            //var e = _people.Employees.Include("WorkDones");
            //foreach (var item in e)
            //{
            //    Console.WriteLine($"{item.FirstName} {item.LastName}: ");
            //    foreach (var works in item.WorkDones)
            //    {
            //        Console.WriteLine($"-{works.NameOfWork} {works.TimeOfWork}");
            //    }
            //}

            //ForPeople(_people.People.Include("WorkDones"));
            //Console.WriteLine();
            //var localQuery = _people.Employees.Include("WorkDones").ToArray();
            //ForPeople(localQuery.AsQueryable());
        }

        //IMPORTANT IQueryable<> is very powerfull tool
        private void ForPeople(IQueryable<PersonBase> pb)
        {
            foreach (var item in CustomFilter(pb))
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}: ");
                if (item.WorkDones.Count > 0)
                {
                    int i = 1;
                    foreach (var work in item.WorkDones)
                    {
                        Console.WriteLine($"{i++}. {work.NameOfWork} {work.TimeOfWork}");
                    }
                }
                else
                    Console.WriteLine("Brak");
                Console.WriteLine();
            }
        }

        public static IEnumerable<Employee> CustomFilter(IQueryable<PersonBase> people)
        {
            //people.Where((x) => x.Age >= 16 && x.Age <= 20).OrderByDescending((x) => x.Age);
            return people.Where((x) => x is Employee).Select((x) => x as Employee).OrderBy(x => x.Age);
            
        }
    }
}
