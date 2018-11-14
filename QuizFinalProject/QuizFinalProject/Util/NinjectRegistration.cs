using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Ninject.Modules;
using QuizFinalProject.DataBase.Repositories.Classes;
using QuizFinalProject.DataBase.Repositories.Interfaces;

namespace QuizFinalProject.Util
{

    // Global registration of relations beetween interfaces and their 
    // implementations
    public class NinjectRegistration : NinjectModule
    {

       
        public override void Load()
        {
            Bind<ITestRepository>().To<TestRepository>();
        }
    }
}