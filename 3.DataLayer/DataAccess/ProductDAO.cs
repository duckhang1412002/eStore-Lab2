using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance {
            get {
                lock (instanceLock) {
                    if (instance == null) {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<ProductObject> GetProductList() {
            var products = new List<ProductObject>();
            try {
                using var context = new eStoreContext();
                products = context.Products.ToList();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            //System.Console.WriteLine(products.Count);
            return products;
        }

        public ProductObject GetProductByID(int proId) {
            ProductObject product = null;
            try {
                using var context = new eStoreContext();
                product = context.Products.SingleOrDefault(p => p.ProductId == proId);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public void Insert(ProductObject product) {
            try {
                ProductObject _product = GetProductByID(product.ProductId);
                //ID not collapse
                if (_product == null) {
                    using var context = new eStoreContext();
                    context.Products.Add(product); 
                    context.SaveChanges();
                } else {
                    throw new Exception("The product is already exist.");
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void Update(ProductObject product) {
            try {
                ProductObject _product = GetProductByID(product.ProductId);
                if (_product != null) {
                    using var context = new eStoreContext();
                    context.Products.Update(product);
                    context.SaveChanges();
                } else {
                    throw new Exception("The product does not not exist.");
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int proId) {
            try {
                ProductObject _product = GetProductByID(proId);
                if (_product != null) {
                    using var context = new eStoreContext();
                    context.Products.Remove(_product);
                    context.SaveChanges();
                } else {
                    throw new Exception("The product does not not exist.");
                }
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}