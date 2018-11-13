using System;
using System.Data.Entity;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QuizFinalProject.DataBase.Models;

namespace QuizFinalProject.DataBase.DataAccessLayer
{

    public class QuizInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {

            IdentityRole admin = new IdentityRole() { Id = "1", Name = "admin" };
            IdentityRole user = new IdentityRole() { Id = "2", Name = "user" };
            IdentityUserRole Admin = new IdentityUserRole() { RoleId = "1", UserId = "1" };
            IdentityUserRole User = new IdentityUserRole() { RoleId = "1", UserId = "2" };

            context.Roles.Add(admin);
            context.Roles.Add(user);
            ApplicationUser user1 = new ApplicationUser() { UserName = "Ivan Ivanov", Email = "Ivanov@gmail.com", EmailConfirmed = true, PasswordHash = "Qwerty12", Id = "1" };
            ApplicationUser user2 = new ApplicationUser() { UserName = "Petr Petrov", Email = "Petrov@gmail.com", EmailConfirmed = true, PasswordHash = "Qwerty11", Id = "2" };
            context.Users.Add(user1);
            context.Users.Add(user2);
           



            //Test test1= new Test { Category= new Category {CategoryName="Development" }, Questions= new List<Question> { new Question() { } }
            Question question = new Question { QuestionText = "Test question 1", };
            Answer answer1 = new Answer { AnswerText = "Yes", IsRight = true };
            Answer answer2= new Answer { AnswerText = "No", IsRight = false };
            Answer answer3 = new Answer { AnswerText = "I dont know", IsRight = false };
            Answer answer4 = new Answer { AnswerText = " leave me alone", IsRight = true };
            question.Answers.Add(answer1);
            question.Answers.Add(answer2);
            question.Answers.Add(answer3);
            question.Answers.Add(answer4);

            


            Test test = new Test { TestName = "QA Basic",Complexity = 3,DurationTime = new TimeSpan(0, 25, 15), Description = "his article demonstrates how to create ASP.NET MVC 5 applications using Entity Framework 6 and Visual Studio. This tutorial uses the Code First workflow. For information about how to choose between Code First, Database First, and Model First, " };
            Test test1 = new Test { TestName = "C# Basic", Complexity = 2, DurationTime = new TimeSpan(0, 60, 0), Description = "his article demonstrates how to create ASP.NET MVC 5 applications using Entity Framework 6 and Visual Studio. This tutorial uses the Code First workflow. For information about how to choose between Code First, Database First, and Model First, " };
            Test test2 = new Test { TestName = "WinForms Basic", Complexity = 1, DurationTime = new TimeSpan(0, 90, 0), Description = "his article demonstrates how to create ASP.NET MVC 5 applications using Entity Framework 6 and Visual Studio. This tutorial uses the Code First workflow. For information about how to choose between Code First, Database First, and Model First, " };
            test.Questions.Add(question);
           
            question = new Question { QuestionText = "Test question 2", };
            answer1 = new Answer { AnswerText = " Maybe", IsRight = true };
            answer2 = new Answer { AnswerText = "Probably", IsRight = false };
            answer3 = new Answer { AnswerText = "Perhaps", IsRight = false };
            answer4 = new Answer { AnswerText = " Its up to you", IsRight = false };
            question.Answers.Add(answer1);
            question.Answers.Add(answer2);
            question.Answers.Add(answer3);
            question.Answers.Add(answer4);
            test.Questions.Add(question);
          
            //context.Tests.Add(test);
            Category category = new Category {CategoryName = "Development"};
            Category category1 = new Category { CategoryName = "QA" };
            Category category2 = new Category { CategoryName = "Desktop Development" };

            category.Tests.Add(test);
            category1.Tests.Add(test1);
            category2.Tests.Add(test2);


            context.Categories.Add(category);
            context.Categories.Add(category1);
            context.Categories.Add(category2);




            base.Seed(context);
            context.SaveChanges();
            


        }
    }
    
}