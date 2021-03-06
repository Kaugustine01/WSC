﻿/*
    Programmer: Kenneth Augustine
    Date:       03/23/2016
    Purpose:    Customer object
    Details:    Customer Object
 */

namespace BAL
{
    public class Customer 
    {
        public int CustomerId { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNo { get; set; }

        public enum SearchFilter
        {
            LastName,
            CustomerID,
            UserId
        }

        public Customer() { }

        public Customer(int nCustomerId, int nUserId, string sFirstName, string sLastName, string sAddress, string sAddress2,
            string sCity, string sState, string sZipCode, string sPhoneNo)
        {            
            CustomerId = nCustomerId;
            UserId = nUserId;
            FirstName = sFirstName;
            LastName = sLastName;
            Address = sAddress;
            Address2 = sAddress2;
            City = sCity;
            State = sState;
            ZipCode = sZipCode;
            PhoneNo = sPhoneNo;
            UserId = nUserId;        
        }
    }
}
