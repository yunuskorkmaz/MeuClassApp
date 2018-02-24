using MeuClass.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuClass.Areas.Admin.Models
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<UserType> UserTypes { get; set; }
    }
}