using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizFinalProject.DataBase.Models;

namespace QuizFinalProject.DataBase.Repositories.Interfaces
{
   public interface ITestRepository
    {
        void Save(Test t);
        IEnumerable<Test> List();      
        Test GetById(int? id);
    }
}
