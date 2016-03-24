using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BAL
{
    public class BusinessLayer
    {
        DataAccessLayer objDAL = new DataAccessLayer();

        public BusinessLayer()
        {

        }

        #region User Account

        /// <summary>
        /// Return UserAccount Object by Username and Password
        /// </summary>
        /// <param name="sUserName">Username</param>
        /// <param name="sPassword">Password</param>
        /// <returns>UserSAccount Object</returns>
        public UserAccount GetUserAccount(string sUserName, string sPassword)
        {
            DataTable dtUser = null;
            UserAccount objUA = new UserAccount();
            string sUserType = string.Empty;

            dtUser = objDAL.GetUserAccount(sUserName, sPassword);

            if (dtUser != null)
            {
                if (dtUser.Rows.Count > 0)
                {
                    objUA.UserId = int.Parse(dtUser.Rows[0]["UserID"].ToString());
                    objUA.UserName = dtUser.Rows[0]["UserName"].ToString();
                    objUA.Password = dtUser.Rows[0]["Password"].ToString();
                    sUserType = dtUser.Rows[0]["Role"].ToString();

                    switch (sUserType)
                    {
                        case "C":
                            objUA.UserType = UserAccount.UserRole.Customer;
                            break;
                        case "M":
                            objUA.UserType = UserAccount.UserRole.OperationManager;
                            break;
                        case "S":
                            objUA.UserType = UserAccount.UserRole.Sales;
                            break;
                    }
                }
            }

            return objUA;
        }

        #endregion
    }
}
