using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuizFinalProject.DataBase.Models;
using QuizFinalProject.DataBase.Repositories.Interfaces;

namespace QuizFinalProject.Controllers
{
    public class TestPageController : Controller
    {
        private ITestRepository _testRepository;

        public TestPageController(ITestRepository r)
        {
            _testRepository = r;
        }
        // GET: TestPage
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TestPage(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = _testRepository.GetById(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }
    }
}