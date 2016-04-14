/*
    Programmer: Kenneth Augustine
    Date:       03/23/2016
    Purpose:    User Account Object
    Details:    User Account Object, Login info and Role
 */

namespace BAL
{
    public class UserAccount
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole UserType { get; set; }

        public enum UserRole
        {
            OperationManager,
            Sales,
            Customer
        }

        public UserAccount() { }

        public UserAccount(int nUserId, string sUserName, string sPassword, UserRole eUserRole, string sEmail)
        {
            UserId = nUserId;
            UserName = sUserName;
            Password = sPassword;
            UserType = eUserRole;
            Email = sEmail;
        }
    }
}
