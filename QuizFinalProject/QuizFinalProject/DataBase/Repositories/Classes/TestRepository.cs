using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuizFinalProject.DataBase.Repositories.Interfaces;
using System.Data.Entity;
using QuizFinalProject.DataBase.DataAccessLayer;
using QuizFinalProject.DataBase.Models;

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

        return _dbContext.Tests.Include(test => test.Category).Include(test => test.Questions);
    }

    //public Test Get(int id)
    //{
    //    return _dbContext.Tests.Include(test => test.Category).FirstOrDefault(test => test.Id == id);
    //}

    public virtual Test GetById(int? id)
    {

        return _dbContext.Tests.Include(test => test.Questions.Select(y => y.Answers))
            .FirstOrDefault(test => test.Id == id);
    }

    protected void Dispose(bool disposing)
    {

        if (!disposing) return;
        if (_dbContext == null) return;
        _dbContext.Dispose();
        _dbContext = null;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    }
}