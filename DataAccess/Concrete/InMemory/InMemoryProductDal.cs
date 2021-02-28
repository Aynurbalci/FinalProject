using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product{CategoryId=1,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitInStock=15},
            new Product{CategoryId=1,ProductId=2,ProductName="Kamera",UnitPrice=150,UnitInStock=3},
            new Product{CategoryId=2,ProductId=3,ProductName="telefon",UnitPrice=1500,UnitInStock=15},
            new Product{CategoryId=2,ProductId=4,ProductName="klavye",UnitPrice=14,UnitInStock=15},
            new Product{CategoryId=2,ProductId=5,ProductName="fare",UnitPrice=18,UnitInStock=15},

            };

        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            //LINQ language ıntegrated query
            // Product productToDelete = null;
            //foreach(var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToDUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToDUpdate.ProductName = product.ProductName;
            productToDUpdate.CategoryId = product.CategoryId;
            productToDUpdate.UnitPrice = product.UnitPrice;
            productToDUpdate.UnitInStock = product.UnitInStock;

        }
    }
}
