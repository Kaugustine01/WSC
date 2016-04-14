using System.Collections.Generic;
using DAL;
using System.Data;
using System;

/*
    Programmer: Kenneth Augustine
    Date:       03/27/2016
    Purpose:    PaymentType Object
    Details:    Payment Types lookup 
 */

namespace BAL
{
    public class PaymentTypes
    {
        public List<PaymentType> lOrderPaymentTypes { get; }

        public PaymentTypes()
        {
            DataTable dtPaymentTypes = null;
            DataAccessLayer objDal = null;
            lOrderPaymentTypes = new List<PaymentType>();

            try
            {
                //New Data Table of Payment Types
                dtPaymentTypes = new DataTable();

                //New Datalayer
                objDal = new DataAccessLayer();

                //Get Payment Types from the datalayer
                dtPaymentTypes = objDal.GetPaymentTypes();

                //Check to make sure the datatable has rows and is not null
                if (dtPaymentTypes != null)
                {
                    if (dtPaymentTypes.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtPaymentTypes.Rows)
                        {
                            //New PaymentType
                            PaymentType objPaymentType = new PaymentType();

                            //Hydrate Object from datatable
                            objPaymentType.PaymentId = int.Parse(row["PaymentID"].ToString());
                            objPaymentType.OrderPaymentType = row["PaymentType"].ToString();

                            //Add Payment Type to the List of Payment Types
                            lOrderPaymentTypes.Add(objPaymentType);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public class PaymentType
        {
            public int PaymentId { get; set; }

            public string OrderPaymentType { get; set; }

            public PaymentType() { }
        }
    }


}
