/*
    Programmer: Kenneth Augustine
    Date:       03/23/2016
    Purpose:    Catalog Items Object
    Details:    Catalog Item object
 */

namespace BAL
{
    public class CatalogItem
    {
        public int CatalogItemId { get; set; }

        public string CatalogItemName { get; set; }

        public string CatalogItemDescr { get; set; }

        public decimal Price { get; set; }

        public string CatalogImagePath { get; set; }

        public bool Active { get; set; }

        public CatalogItem() { }

        public CatalogItem(int nCatalogItemId, string sCatalogItemName, string sCatalogItemDescr, decimal dPrice, string sCatalogImagePath, bool bActive)
        {
            CatalogItemId = nCatalogItemId;
            CatalogItemName = sCatalogItemName;
            CatalogItemDescr = sCatalogItemDescr;
            Price = dPrice;
            CatalogImagePath = sCatalogImagePath;
            Active = bActive;
        }
    }
}
