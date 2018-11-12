using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ninject;
using QuizFinalProject.DataBase.DataAccessLayer;
using QuizFinalProject.DataBase.Models;
using QuizFinalProject.DataBase.Repositories.Classes;
using QuizFinalProject.DataBase.Repositories.Interfaces;

namespace QuizFinalProject.Controllers
{
    public class HomeController : Controller
    {
        ITestRepository _testRepository;
        public HomeController(ITestRepository r)
        {
            _testRepository = r;
        }

        //public HomeController()
        //{
        //    IKernel ninjectKernel = new StandardKernel();
        //    ninjectKernel.Bind<ITestRepository>().To<TestRepository>();
        //    _testRepository = ninjectKernel.Get<ITestRepository>();
        //}
        public ActionResult Index()
        {
            ApplicationDbContext dbContext=new ApplicationDbContext();
            dbContext.Answers.ToList();
         //var z=dbContext.Users.ToList();
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

        public ActionResult Tests()
        {

            var a = _testRepository.List().ToList();


            return View(_testRepository.List());
        }

       
    }
}