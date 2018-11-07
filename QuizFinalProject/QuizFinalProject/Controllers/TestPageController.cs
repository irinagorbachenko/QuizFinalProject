using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Serialization;
using QuizFinalProject.DataBase.Models;
using QuizFinalProject.DataBase.Models.ViewModels;
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
            //TestsViewModel testViewModel = new TestsViewModel();

            //List<Question> checkBoxList = test.Questions.Where(IsMultiAnswer).ToList();
                      
            //    testViewModel.CheckBoxQuestion.AddRange(checkBoxList);

            //List<Question>radioButtonList=test.Questions.Where(IsSingleAnswer).ToList();

            //testViewModel.RadioButtonQuestion.AddRange(radioButtonList);


          
            //return View();
            return View(test);
        }

        private bool IsMultiAnswer(Question question)
        {
            var a = question.Answers.Where(answer => answer.IsRight);
            if (a.Count() > 1)
                return true;
          
            else
            {
                return false;
            }
        }

        private bool IsSingleAnswer(Question question)
        {
            var a = question.Answers.Where(answer => answer.IsRight);
            if (a.Count() == 1)
                return true;

            else
            {
                return false;
            }
        }


        [HttpPost]
        public ActionResult TestResult(Test userTest)
        {
            Test currentTest = _testRepository.GetById(userTest.TestId);
            foreach (Question item in userTest.Questions)
            {
               List< Question> a = currentTest.Questions.Where(question =>
                {
                    if(item.QuestionId==question.QuestionId)

                    return true;

                    return false;
                }).ToList();

            }


            return View();
        }

    }
}