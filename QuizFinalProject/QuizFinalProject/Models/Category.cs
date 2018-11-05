using System.Collections.Generic;

namespace QuizFinalProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Test> Tests { get; set; }

        public Category()
        {
            Tests = new List<Test>();
        }
    }
}