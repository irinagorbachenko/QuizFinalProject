using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizFinalProject.DataBase.Models.ViewModels
{
    public class TestsViewModel
    {
        public Test Id { get; set; }
        public List<Question> CheckBoxQuestion { get; set; }
        public List<RadioButtonQuestion> RadioButtonQuestion { get; set; }

        public TestsViewModel()
        {
              CheckBoxQuestion=new List<Question>();  
            RadioButtonQuestion=new List<RadioButtonQuestion>();
        }
    }

   
            
   
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsRight { get; set; }
        public Question Question { get; set; }

    }

    public class RadioButtonQuestion:Question
    {
     
        public int RightAnswerId { get; set; }

        public RadioButtonQuestion() : base()
        {
                
        }
    }
}
