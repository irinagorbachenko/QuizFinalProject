using System.ComponentModel.DataAnnotations;

namespace QuizFinalProject.DataBase.Models
{   //// Represent a Answer entity
    public class Answer
    {
        public int AnswerId { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage = "String is out of range")]
        public string AnswerText { get; set; }
  
        public bool IsRight { get; set; }
        public Question Question { get; set; }

    }
}