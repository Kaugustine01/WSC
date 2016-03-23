using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAL
{
    public class UserAccount
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    
        public UserRole UserType { get; set; }

        public enum UserRole
        {
            OperationManager,
            Sales,
            Customer
        }
      
        public UserAccount(int nUserId, string sUserName, string sPassword, UserRole eUserRole)
        {
            UserId = nUserId;
            UserName = sUserName;
            Password = sPassword;
            UserType = eUserRole;
        }
    }
}
