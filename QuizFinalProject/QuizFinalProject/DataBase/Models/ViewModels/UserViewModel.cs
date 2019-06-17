using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizFinalProject.DataBase.Models.ViewModels
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string Roles { get; set; }
        
        
    }

    public class GroupedUserViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public List<UserViewModel> Admins { get; set; }
    }

}