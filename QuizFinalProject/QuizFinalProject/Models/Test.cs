using System;
using System.Collections;
using System.Collections.Generic;

namespace QuizFinalProject.Models
{
    public class Test : IEnumerable
    {

        public int Id { get; set; }
        public string TestName { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public ICollection<Question> Questions { get; set; }
        public TimeSpan DurationTime { get; set; }
        public int Complexity { get; set; }

        public Test()
        {
           
            Questions = new List<Question>();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}