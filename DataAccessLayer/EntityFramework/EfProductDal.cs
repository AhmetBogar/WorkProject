using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Product> GetProductsWithCategory()
        {
            var c = new Context();
            return c.Products.Include(p => p.Category).ToList();
        }

        public List<Product> GetProductsWithCategoryID(int id)
        {
            var c=new Context();
            return c.Products.Include(p=>p.CategoryId==id).ToList();
        }

        public Product GetProductWithId(int id)
        {
            var c=new Context();
            return c.Products.Include(p => p.Category).Where(p => p.ProductId == id).FirstOrDefault();
        }
    }
}
