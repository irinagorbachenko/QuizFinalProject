using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using QuizFinalProject.DataBase.DataAccessLayer;
using QuizFinalProject.DataBase.Repositories.Classes;
using QuizFinalProject.DataBase.Repositories.Interfaces;

namespace QuizFinalProject.Controllers
{
    public class HomeController : Controller
    {
        ITestRepository repo;
        public HomeController(ITestRepository r)
        {
            repo = r;
        }

        //public HomeController()
        //{
        //    IKernel ninjectKernel = new StandardKernel();
        //    ninjectKernel.Bind<ITestRepository>().To<TestRepository>();
        //    repo = ninjectKernel.Get<ITestRepository>();
        //}
        public ActionResult Index()
        {
            ApplicationDbContext dbContext=new ApplicationDbContext();
            dbContext.Answers.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}