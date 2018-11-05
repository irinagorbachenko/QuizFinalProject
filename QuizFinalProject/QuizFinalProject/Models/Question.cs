﻿using System.Collections.Generic;

namespace QuizFinalProject.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public Test Test { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
        
    }
}