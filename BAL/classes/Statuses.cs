using System.Collections.Generic;
using DAL;
using System.Data;
using System;

/*
    Programmer: Kenneth Augustine
    Date:       03/27/2016
    Purpose:    Status Object
    Details:    Status lookup 
 */

namespace BAL
{
    public class Statuses
    {
        public List<Status> lOrderStatuses { get; }
        
        public Statuses()
        {
            DataTable dtStatus = null;
            DataAccessLayer objDal = null;
            lOrderStatuses = new List<Status>();

            try
            {
                //New Data Table of Statuses
                dtStatus = new DataTable();

                //New Datalayer
                objDal = new DataAccessLayer();

                //Get Statuses from the datalayer
                dtStatus = objDal.GetStatuses();

                //Check to make sure the datatable has rows and is not null
                if (dtStatus != null)
                {
                    if (dtStatus.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtStatus.Rows)
                        {
                            //New status
                            Status objStatus = new Status();

                            //Hydrate Object from datatable
                            objStatus.StatusId = int.Parse(row["StatusID"].ToString());
                            objStatus.OrderStatus = row["Status"].ToString();

                            //Add Status to the List of Statuses
                            lOrderStatuses.Add(objStatus);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public class Status
        {
            public int StatusId { get; set; }

            public string OrderStatus { get; set; }

            public Status() { }
        }
    }


}
