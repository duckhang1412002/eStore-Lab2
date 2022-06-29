using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        IEnumerable<ProductObject> GetProducts();
        ProductObject GetProductByID(int productID);
        void InsertProduct(ProductObject product);
        void RemoveProduct(int productID);
        void UpdateProduct(ProductObject product);
    }
}