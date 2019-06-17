using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizFinalProject.DataBase.Models;
using QuizFinalProject.DataBase.Models.ViewModels;

namespace QuizFinalProject.DataBase.Repositories.Interfaces
{// Service   for a test repository
   public interface ITestRepository
    {
        void Save(Test t);
        void Save();
        IEnumerable<Test> List();       
        Test Get(int id);
        Test GetById(int? id);
        void Insert(Test testToInsert);
        void Delete(object id);
        void Delete(Test testToDelete);
        void Update(Test testToUpdate);
        void Update(AddQuestionViewModel questionToUpdate);
        void Dispose(bool disposing);
        void Dispose();



    }
}
