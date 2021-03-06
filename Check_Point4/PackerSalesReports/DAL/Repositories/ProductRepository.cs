﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProductRepository:IModelRepository<Product>
    {
        private readonly Model.SaleContainer context;
        public ProductRepository(Model.SaleContainer context)
        {
            this.context = context;
        }
        private Model.Product ToEntity(Product source)
        {
            return new Model.Product() { ProductId = source.ProductId, Description = source.Description };
        }
        public static Product ToObject(Model.Product source)
        {
            return new Product() { ProductId = source.ProductId, Description = source.Description };
        }
        public void Add(Product item)
        {
            var e = this.ToEntity(item);
            context.ProductSet.Add(e);
        }
        public void Remove(Product item)
        {
            var tempProduct = context.ProductSet.FirstOrDefault(x => x.Description == item.Description);
            if (tempProduct != null)
            {
                context.ProductSet.Remove(tempProduct);
            }
        }
        public void Update(Product item)
        {
            var tempProduct = context.ProductSet.FirstOrDefault(x => x.Description == item.Description);
            if (tempProduct == null)
            {
                Add(item);
                SaveChanges();
            }
        }
        public IEnumerable<Product> Items
        {
            get
            {
                List<Product> templist = new List<Product>();
                foreach (var u in this.context.ProductSet)
                {
                    templist.Add(ToObject(u));
                }
                return templist;
            }
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}
