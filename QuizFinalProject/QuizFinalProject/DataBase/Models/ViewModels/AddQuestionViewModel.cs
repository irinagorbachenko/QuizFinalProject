using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizFinalProject.DataBase.Models.ViewModels
{
    public class AddQuestionViewModel
    {
        public int TestId { get; set; }
        public Question Question { get; set; }
    }
}