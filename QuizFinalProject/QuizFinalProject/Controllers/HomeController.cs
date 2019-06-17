using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ninject;
using QuizFinalProject.DataBase.DataAccessLayer;
using QuizFinalProject.DataBase.Models;
using QuizFinalProject.DataBase.Repositories.Classes;
using QuizFinalProject.DataBase.Repositories.Interfaces;
using static QuizFinalProject.DataBase.Models.Test;

namespace QuizFinalProject.Controllers
{
    //Controller for a showing list of tests on home page
//All references to the database context are replaced by references to the appropriate repository,
    public class HomeController : Controller
    {
        ITestRepository _testRepositoryService;

        public HomeController(ITestRepository r)
        {
            _testRepositoryService = r;
        }

        
        public ActionResult Index()
        {
            
        
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

        
     
      //Sorting a tests using ViewData object to get a value from Enum SortState

        public ActionResult  Tests(SortState sortOrder = SortState.NameAsc)
        {
            IEnumerable<Test> tests = _testRepositoryService.List();

          

            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["ComplexitySort"] = sortOrder == SortState.ComplexityAsc ? SortState.ComplexityDesc : SortState.ComplexityAsc;
            ViewData["Category"] = sortOrder == SortState.CategoryAsc ? SortState.CategoryDesc : SortState.CategoryAsc;

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    tests = tests.OrderByDescending(s => s.TestName);
                    break;
                case SortState.CategoryAsc:
                    tests = tests.OrderBy(s => s.Category.CategoryName);
                    break;
                case SortState.CategoryDesc:
                    tests = tests.OrderByDescending(s => s.Category.CategoryName);
                    break;
                case SortState.ComplexityAsc:
                    tests = tests.OrderBy(s => s.Complexity);
                    break;
                case SortState.ComplexityDesc:
                    tests = tests.OrderByDescending(s => s.Complexity);
                    break;
                default:
                    tests = tests.OrderBy(s => s.TestName);
                    break;
            }
            return View( tests.ToList());
        }

    }
}

