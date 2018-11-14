using System.Collections.Generic;

namespace QuizFinalProject.DataBase.Models
{  //// Represent a Question entity
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
        public Test Test { get; set; }
        public  int? RightAnswerId { get; set; }
        public Question()
        {
            Answers = new List<Answer>();
        }
        
    }
}