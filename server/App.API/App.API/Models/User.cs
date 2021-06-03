using System;
using System.Collections.Generic;

namespace App.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public Office Office { get; set; }
        public List<UserRole> Roles { get; set; }
    }
}
