using System.Collections.Generic;

namespace QuizFinalProject.DataBase.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public List<Answer> Answers { get; set; }
        public Test Test { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
        
    }
}