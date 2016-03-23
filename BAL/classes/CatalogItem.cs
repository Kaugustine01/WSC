using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAL
{
    public class CatalogItem
    {
        public int CatalogItemId { get; set; }

        public string CatalogItemName { get; set; }

        public string CatalogItemDescr { get; set; }

        public decimal Price { get; set; }

        public string CatalogImagePath { get; set; }

        public CatalogItem(int nCatalogItemId, string sCatalogItemName, string sCatalogItemDescr, decimal dPrice, string sCatalogImagePath)
        {
            CatalogItemId = nCatalogItemId;
            CatalogItemName = sCatalogItemName;
            CatalogItemDescr = sCatalogItemDescr;
            Price = dPrice;
            CatalogImagePath = sCatalogImagePath;
        }
    }
}
