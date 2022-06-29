using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        
        public IEnumerable<ProductObject> GetProducts() {
            return ProductDAO.Instance.GetProductList();
        }
        public ProductObject GetProductByID(int productID) {
            return ProductDAO.Instance.GetProductByID(productID);
        }
        public void InsertProduct(ProductObject product) {
            ProductDAO.Instance.Insert(product);
        }
        public void RemoveProduct(int productID) {
            ProductDAO.Instance.Remove(productID);
        }
        public void UpdateProduct(ProductObject product) {
            ProductDAO.Instance.Update(product);
        }
    }
}