using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDemoProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _people;

        public IndexModel(ILogger<IndexModel> logger,PeopleContext people)
        {
            _logger = logger;
            this._people = people;
        }

        public void OnGet()
        {
            if (_people.People.Count() == 0)
                AddData();

            //List<Person> data = _people.People.Where((x) => x.FirstName == "Dawid").ToList();
            
            void AddData()
            {
                _people.Add(new Person()
                {
                    FirstName = "Dawid",
                    LastName = "Król",
                    Age = 20,
                });
                _people.SaveChanges();
            }

        }
    }
}
