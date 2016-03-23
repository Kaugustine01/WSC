using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAL
{
    public class Order
    {
        public int OrderId { get; set; }

        public bool IsPaymentOnDelivery { get; set; }

        public decimal DepositAmt { get; set; }

        public int StatusId { get; set; }

        public List<OrderItems> OrderItems { get; set; }

        public Order(int nOrderId, bool bIsPaymentOnDelivery, decimal dDepositAmt, int nStatusId)
        {
            OrderId = nOrderId;
            IsPaymentOnDelivery = bIsPaymentOnDelivery;
            DepositAmt = dDepositAmt;
            StatusId = nStatusId;
            OrderItems = new List<OrderItems>();
        }

    }

    public class OrderItems
    {
        public int OrderItemId { get; set; }     

        public int CatalogItemId { get; set; }

        public int Qty { get; set; }

        public decimal Price { get; set; }

        public ContentType ItemContentType { get; set; }

        public enum ContentType
        {
            Printed,
            Engraved
        }

        public string Content { get; set; }

        public OrderItems(int nOrderItemId, int nCatalogItemId, int nQty, decimal dPrice, ContentType eItemContentType, string sContent)
        {
            OrderItemId = nOrderItemId;
            CatalogItemId = nCatalogItemId;
            Qty = nQty;
            Price = dPrice;
            ItemContentType = eItemContentType;
        }
    }
}
