using System;
using System.Collections.Generic;

#nullable disable

namespace COMP2001API.Models
{
    public partial class SessionsTable
    {
        public DateTime DateOfSession { get; set; }
        public TimeSpan TimeOfSession { get; set; }
        public int UserIdNum { get; set; }

        public virtual UsersTable UserIdNumNavigation { get; set; }
    }
}
