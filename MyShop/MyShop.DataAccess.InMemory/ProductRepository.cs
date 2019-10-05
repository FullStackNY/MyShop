using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            products = cache["Products"] as List<Product>;
            if (products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["Products"] = products;
        }

        public void Insert(Product product)
        {
            products.Add(product);
        }

        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);
            if (productToUpdate == null)
            {
                throw new Exception("Product Not Found");
            }
            else
            {
                productToUpdate = product;
            }
        }

        public Product Find(String Id) 
        {
            Product product = products.Find(p => p.Id == Id);
            if (product == null)
            {
                throw new Exception("Product Not Found");
            }
            else
            {
                return product;
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(String Id)
        {
            Product productToDelete = products.Find(p => p.Id == Id);
            if (productToDelete == null)
            {
                throw new Exception("Product Not Found");
            }
            else
            {
                products.Remove(productToDelete);
            }
        }
    }
}
