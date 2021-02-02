using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001API.Models
{
    public partial class UsersTable
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserPassword { get; set; }
    }
}
