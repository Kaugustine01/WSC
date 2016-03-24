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
        
        public UserAccount GetUserId(string sUserName, string sPassword)
        {
            DataTable dtUser = null;
            UserAccount objUA = new UserAccount();
            string sUserType = string.Empty;

            dtUser = objDAL.GetUserId(sUserName, sPassword);

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

    }
}
