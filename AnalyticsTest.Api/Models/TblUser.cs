using System;
using System.Collections.Generic;

namespace AnalyticsTest.Api.Models
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string UserMobile { get; set; }
        public string UserName { get; set; }
        public string UserFamily { get; set; }
        public string UserPasswordHash { get; set; }
        public string UserPasswordSalt { get; set; }
        public DateTime UserCreateDate { get; set; }
        public DateTime UserModifyDate { get; set; }
        public bool UserIsDelete { get; set; }

        public virtual TblRole UserRole { get; set; }
    }
}
