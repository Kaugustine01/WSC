using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class BusinessLayer
    {
        DataAccessLayer objDAL = new DataAccessLayer();

        public BusinessLayer()
        {
           
        }         
        
        public int GetUserId(string sUserName, string sPassword)
        {
            int nUserId = 0;
            nUserId = objDAL.GetUserId(sUserName, sPassword);

            return nUserId;

        }        

    }
}
