using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using QuizFinalProject.DataBase.Repositories.Classes;
using QuizFinalProject.DataBase.Repositories.Interfaces;

namespace QuizFinalProject.Util
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<ITestRepository>().To<TestRepository>();
        }
    }
}