using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizFinalProject.DataBase.Models
{
    //// Represent a Category entity
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public ICollection<Test> Tests { get; set; }

        public Category()
        {
            Tests = new List<Test>();
        }
    }
}