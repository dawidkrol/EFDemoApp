using Autofac;
using System;

namespace DITraining
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = DIBuilder.Configure();

            using(var scope = app.BeginLifetimeScope())
            {
                scope.Resolve<IApplication>().OnStart();
            }
        }
    }
}
