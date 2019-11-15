using System;
using System.Collections.Generic;
using System.Linq;
using MyStore.Domain.Exceptions;

namespace MyStore.Domain.Nomenclatures
{
    public class Store : NomenclatureEntity, IStore
    {
        private class ItemInStock
        {
            public string ItemCode { get; set; }
            public int Qtty { get; set; }
        }

        private readonly List<ItemInStock> itemsInStocks;

        private readonly string storeCode;

        public Store(string storeCode)
        {
            this.storeCode = storeCode;

            itemsInStocks = new List<ItemInStock>();
        }

        public string Address { get; set; }
        public string Phone { get; set; }     

        public int CheckAvailability(string itemCode)
        {
            var item = itemsInStocks.Where(x => x.ItemCode == itemCode).FirstOrDefault();

            if (item is null)
            {
                return 0;
            }

            return item.Qtty;
        }

        public void AddToWarehouse(string itemCode, int qtty)
        {
            itemsInStocks.Add(new ItemInStock() { ItemCode = itemCode, Qtty = qtty  });
        }        

        public void TakeOutOfWarehouse(string itemCode, int qtty)
        {
            var inStock = itemsInStocks.Where(x => x.ItemCode == itemCode).First();

            if(inStock.Qtty < qtty)
            {            
                throw new OutOfStockException(string.Format("Not sufficient quantity for Item with code {0}", inStock.ItemCode));
            }

            inStock.Qtty -= qtty;
        }        
    }
}