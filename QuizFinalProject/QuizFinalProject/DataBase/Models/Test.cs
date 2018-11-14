using System;
using System.Collections;
using System.Collections.Generic;

namespace QuizFinalProject.DataBase.Models
{  //// Represent a Test entity and enum for sorting
    public class Test : IEnumerable
    {

        public int TestId { get; set; }
        public string TestName { get; set; }
        public virtual Category Category { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
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

        public enum SortState
        {
            NameAsc,    
            NameDesc,   
            ComplexityAsc, 
            ComplexityDesc,   
            CategoryAsc, 
            CategoryDesc 
        }
    }
}