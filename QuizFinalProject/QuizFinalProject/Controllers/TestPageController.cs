using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Serialization;
using QuizFinalProject.DataBase.Models;
using QuizFinalProject.DataBase.Models.ViewModels;
using QuizFinalProject.DataBase.Repositories.Interfaces;
using Answer = QuizFinalProject.DataBase.Models.Answer;

namespace QuizFinalProject.Controllers
{
    public class TestPageController : Controller
    {
        public int Results = 0;
        private readonly ITestRepository _testRepository;

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

       
        public static double GetPercent(int rightAnswers, int questionQuantity)
        {
            if (rightAnswers == 0) return 0;
            double result= (double)rightAnswers / questionQuantity * 100;
            return result;
        }

       


        [HttpPost]
        public ActionResult TestResult(Test userTest)
        {
            int rightAnswers = 0;
            Test TestFromDb = _testRepository.GetById(userTest.TestId);
            foreach (Question item in userTest.Questions)
            {

                Question questionDb = TestFromDb.Questions.First(question =>
                {
                    if (item.QuestionId == question.QuestionId)
                    {
                        return true;
                    }

                    return false;

                });

                List<Answer> rightAnswerFromDb = questionDb.Answers.Where(answer => answer.IsRight).ToList();
                List<Answer> rightAnswerFromUser = item.Answers.Where(answer => answer.IsRight).ToList();


                if (rightAnswerFromDb.Count != 1)
                {
                    if (rightAnswerFromDb.Count == rightAnswerFromUser.Count)
                    {
                        int rightAnswerCounter = 0;

                        foreach (var itemDb in rightAnswerFromDb)
                        {
                            foreach (var itemUser in rightAnswerFromUser)
                            {
                                if (itemDb.IsRight == itemUser.IsRight && itemDb.AnswerId == itemUser.AnswerId)
                                {
                                    rightAnswerCounter++;
                                }

                            }

                        }

                        if (rightAnswerCounter == rightAnswerFromDb.Count)
                        {
                            rightAnswers++;
                        }
                    }
                }
                else
                    {
                        if (rightAnswerFromDb[0].AnswerId==item.RightAnswerId)
                        {
                            rightAnswers++;
                        }
                    }
                
               

            }

           
            var questionQuantity = TestFromDb.Questions.Count();
          
            var percentResult= GetPercent(rightAnswers, questionQuantity);
          
            return View(percentResult);
        }

    }
    
}
