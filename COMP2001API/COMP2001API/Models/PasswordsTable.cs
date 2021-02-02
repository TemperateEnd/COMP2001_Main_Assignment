using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001API.Models
{
    public partial class PasswordsTable
    {
        public string PreviousPassword { get; set; }
        public string NewPassword { get; set; }
        public int UserIdNum { get; set; }
        public DateTime DateOfChange { get; set; }

        public virtual UsersTable UserIdNumNavigation { get; set; }
    }
}
