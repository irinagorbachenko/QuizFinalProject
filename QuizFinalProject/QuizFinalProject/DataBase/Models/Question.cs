using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizFinalProject.DataBase.Models
{  //// Represent a Question entity
   ///
   /// new class
    public class Question
    {
        public int QuestionId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "String is out of range")]
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