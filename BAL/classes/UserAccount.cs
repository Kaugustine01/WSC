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

        public UserAccount() { }

        public UserAccount(int nUserId, string sUserName, string sPassword, UserRole eUserRole)
        {
            UserId = nUserId;
            UserName = sUserName;
            Password = sPassword;
            UserType = eUserRole;
        }
    }
}
