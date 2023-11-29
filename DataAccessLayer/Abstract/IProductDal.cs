using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        public List<Product> GetProductsWithCategory();
        public List<Product> GetProductsWithCategoryID(int id);
        public Product GetProductWithId(int id);
    }
}
