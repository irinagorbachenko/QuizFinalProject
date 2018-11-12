using QuizFinalProject.DataBase.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuizFinalProject.DataBase.Models;
using QuizFinalProject.DataBase.Models.ViewModels;

namespace QuizFinalProject.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly ITestRepository _testRepositoryService;

        public AdminPageController(ITestRepository r)
        {
            _testRepositoryService = r;
        }

        public ActionResult Index()
        {
            var testList = _testRepositoryService.List();

            return View(testList);
        }



        public ActionResult AddQuestion(AddQuestionViewModel newQuestion)
        {
            if (newQuestion.Question != null)
            {


                if (ModelState.IsValid)
                {
                    var currentTest = _testRepositoryService.GetById(newQuestion.TestId);
                    currentTest.Questions.Add(newQuestion.Question);
                    _testRepositoryService.Save();
                    return RedirectToAction("Index", new AddQuestionViewModel() { TestId = newQuestion.TestId });
                }
            }
            return View(newQuestion);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Test p)
        {
            if (ModelState.IsValid)
            {


                _testRepositoryService.Insert(p);
                _testRepositoryService.GetById(p.TestId);
                _testRepositoryService.Save();
                return RedirectToAction("AddQuestion", new AddQuestionViewModel() { TestId = p.TestId });
            }

            return View(p);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = _testRepositoryService.GetById(id);
            if (test == null)
            {
                return HttpNotFound();
            }

            return View(test);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = _testRepositoryService.GetById(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Test test = _testRepositoryService.GetById(id);
            _testRepositoryService.Delete(test);
            _testRepositoryService.Save();


            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Test test = _testRepositoryService.GetById(id);
            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Test p)
        {
            if (ModelState.IsValid)
            {

                _testRepositoryService.Update(p);
                _testRepositoryService.Save();
                var a = p.Questions.FirstOrDefault(question => question.Test.TestId == p.TestId);

                return RedirectToAction("EditQuestions",
                    new AddQuestionViewModel()
                    {
                        TestId = p.TestId,
                        Question = p.Questions.FirstOrDefault(question => question.Test.TestId == p.TestId)
                    });

                //return View(p);
            }

            return View(p);

        }

        public ActionResult EditQuestions(AddQuestionViewModel editQuestion)
        {

            if (editQuestion.Question != null)
            {
                var currentTest = _testRepositoryService.GetById(editQuestion.TestId);
                Test test = _testRepositoryService.GetById(editQuestion.TestId);
                test.Questions.Add(editQuestion.Question);
                //  _testRepositoryService.Update(editQuestion);                  
                _testRepositoryService.Save();

            }
            return View(editQuestion);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _testRepositoryService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}


