using Autofac;
using EFDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITraining
{
    public static class DIBuilder
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PeopleContext>();
            builder.RegisterType<Application>().As<IApplication>();

            return builder.Build();
        }
    }
}
