﻿using System;
using System.Collections.Generic;

/*
    Programmer: Kenneth Augustine
    Date:       03/23/2016
    Purpose:    Order Object
    Details:    Order Object includes OrderItems
 */

namespace BAL
{
    public class Order
    {
        public int OrderId { get; set; }        

        public bool IsPaymentOnDelivery { get; set; }

        public decimal DepositAmt { get; set; }

        public int StatusId { get; set; }

        public int PaymentId { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public Order() {
            OrderItems = new List<OrderItem>();
        }

        public Order(int nOrderId, bool bIsPaymentOnDelivery, decimal dDepositAmt, int nPaymentId, int nStatusId, DateTime dtOrderDate)
        {
            OrderId = nOrderId;            
            IsPaymentOnDelivery = bIsPaymentOnDelivery;
            DepositAmt = dDepositAmt;
            PaymentId = nPaymentId;
            StatusId = nStatusId;
            OrderDate = dtOrderDate;
            OrderItems = new List<OrderItem>();
        }
    }

    public class OrderItem : CatalogItem
    {
        public int OrderItemId { get; set; }      

        public int Qty { get; set; }

        public decimal ItemPrice { get; set; }

        public ContentType ItemContentType { get; set; }

        public enum ContentType
        {
            Printed,
            Engraved
        }

        public string Content { get; set; }

        public OrderItem() { }

        public OrderItem(int nOrderItemId, int nCatalogItemId, int nQty, decimal dPrice, ContentType eItemContentType, string sContent)
        {
            OrderItemId = nOrderItemId;
            CatalogItemId = nCatalogItemId;
            Qty = nQty;
            ItemPrice = dPrice;
            ItemContentType = eItemContentType;
            Content = sContent;
        }
    }
}
