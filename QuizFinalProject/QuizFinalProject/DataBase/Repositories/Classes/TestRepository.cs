using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizFinalProject.DataBase.Repositories.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using QuizFinalProject.DataBase.DataAccessLayer;
using QuizFinalProject.DataBase.Models;
using QuizFinalProject.DataBase.Models.ViewModels;

namespace QuizFinalProject.DataBase.Repositories.Classes
{
    public class TestRepository:IDisposable,ITestRepository

    {
    private ApplicationDbContext _dbContext = new ApplicationDbContext();

    public void Save(Test t)
    {
        _dbContext.Tests.Add(t);
        _dbContext.SaveChanges();
    }
        

        public IEnumerable<Test> List()
    {

        return _dbContext.Set<Test>().Include(test => test.Category).Include(test => test.Questions);
    }

        
        public Test Get(int id)
        {
        
            return _dbContext.Set<Test>().Include(test => test.Category).FirstOrDefault(test => test.TestId == id);
        }
        

        public virtual Test GetById(int? id)
    {

        return _dbContext.Set<Test>().Include(test => test.Questions.Select(y => y.Answers))
            .FirstOrDefault(test => test.TestId == id);
    }
        public virtual void Insert(Test testToInsert)
        {
           var a= _dbContext.Set<Test>().Add(testToInsert);
        }

        public virtual void Delete(object id)
        {
            Test testToDelete = _dbContext.Set<Test>().Find(id);
            Delete(testToDelete);
        }

        public virtual void Delete(Test testToDelete)
        {
            if (_dbContext.Entry(testToDelete).State == EntityState.Detached)
            {
                _dbContext.Set<Test>().Attach(testToDelete);
            }
            _dbContext.Set<Test>().Remove(testToDelete);
        }

        public virtual void Update(Test testToUpdate)
        {
            var testInDb=_dbContext.Tests.First(test => test.TestId == testToUpdate.TestId);
            testInDb.Description = testToUpdate.Description;
            testInDb.TestName = testToUpdate.TestName;
            testInDb.Questions = testToUpdate.Questions;
           
        }

        public virtual void Update(AddQuestionViewModel questionToUpdate)
        {
            var questionInDb = _dbContext.Questions.FirstOrDefault(question => question.QuestionId == questionToUpdate.Question.QuestionId);
            if (questionInDb != null)
            {
                questionInDb.QuestionText = questionToUpdate.Question.QuestionText;
                questionInDb.Answers[0].AnswerText = questionToUpdate.Question.Answers[0].AnswerText;
                questionInDb.RightAnswerId = questionToUpdate.Question.RightAnswerId;
            }

           
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}