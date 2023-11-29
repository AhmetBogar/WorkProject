using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        List<Product> GetProductsWithCategory();
        List<Product> GetProductWithCategoryID(int id);
        Product GetProductById(int id);
    }
}
