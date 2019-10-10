using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class Repository<T> where T : BaseClass
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        public string className;

        public Repository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if (items == null)
            {
                items = new List<T>();
            }
        }

        public void Commit()
        {
            cache[className] = items;
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t)
        {
            T tToUpdate = items.Find(p => p.Id == t.Id);
            if (tToUpdate == null)
                {
                    throw new Exception(className + " not found");
                }
            else
                {
                    tToUpdate = t;
                }         
        }

        public T Find(string Id)
        {
            T tToFind = items.Find(p => p.Id == Id);
                if (tToFind == null)
                {
                    throw new Exception(className + " not found");
                }
                else
                {
                    return tToFind;
                }
        }

        public void Delete(string Id)
        {
            T tToDelete = items.Find(p => p.Id == Id);
            if (tToDelete == null)
            {
                throw new Exception(className + " not found");
            }
            else
            {
                items.Remove(tToDelete);
            }
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }
      
    }
}
