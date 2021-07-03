using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

            //foreach (var item in _people.WorkDone.AsEnumerable().GroupBy((x) => x.NameOfWork))
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var person in _people.Employees.AsEnumerable().Where(x => x.WorkDones.Exists(x => x.NameOfWork == item.Key)))
            //    {
            //        Console.WriteLine($"-{person.FirstName}");
            //    }
            //}

            //var takeExample = _people.People.Select(x => x.FirstName).Take(10);
            //var skipExample = _people.People.Select(x => x.FirstName).Skip(90);
            //var TakeAndSkipExample = _people.People.Select(x => x.FirstName).Skip(10).Take(10);
            //foreach (var item in TakeAndSkipExample)
            //{
            //    Console.WriteLine(item);
            //}

            //IMPORTANT V1
            //var doubleDis = from n in _people.Employees.Where(x => x.WorkDones.Count > 0)
            //                select new
            //                {
            //                    works = from w in n.WorkDones
            //                            select w,
            //                    n.FirstName,
            //                    n.LastName

            //                };

            //IMPORTANT V2
            //var doubleDis = _people.Employees.Where(x => x.WorkDones.Count > 0)
            //    .Select(x => new
            //    {
            //        x.FirstName,
            //        x.LastName,
            //        x.WorkDones
            //    });

            //IMPORTANT V3 - bad
            //var doubleDis = _people.Employees.Where(x => x.WorkDones.Count > 0).Include("WorkDones").AsEnumerable()
            //    .Select(x => (x.FirstName,x.LastName,x.WorkDones));

            //foreach (var item in doubleDis)
            //{
            //    Console.WriteLine($"{item.FirstName} {item.LastName}");
            //    foreach (var works in item.WorkDones)
            //    {
            //        Console.WriteLine($"-{works.NameOfWork}");
            //    }
            //}

            //IMPORTANT Distinct()
            //var query = _people.WorkDone.Select(x => x.NameOfWork).Distinct();
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}

            //string[] names = { "Dawid Wojciech Król", "Jan Kazimierz Kowalski" };

            //var q = from fullname in names
            //       // where fullname.FirstName.Split().Length > 1
            //        from name in fullname.Split()
            //        select name + " from " + fullname;
            //foreach (var item in q)
            //{
            //    Console.WriteLine(item);
            //}

            //var w = from p in _people.Employees
            //        from work in p.WorkDones
            //        select $"{p.FirstName} {p.LastName} zrobił: {work.NameOfWork}";

            //foreach (var item in w)
            //{
            //    Console.WriteLine(item);
            //}
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

        public static IQueryable<Employee> CustomFilter(IQueryable<PersonBase> people)
        {
            //people.Where((x) => x.Age >= 16 && x.Age <= 20).OrderByDescending((x) => x.Age);
            return people.Where((x) => x is Employee).Select((x) => x as Employee).OrderBy(x => x.Age);
            
        }
    }
}
