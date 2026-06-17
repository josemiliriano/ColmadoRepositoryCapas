using Domain.Entities;
using Infraestructure.Categoria.DTOs;
using Infraestructure.Data;
using Infraestructure.Product.DTOs;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly GeneralRepository<CDProduct> _repository;
        private readonly MyDataContext _context;
        public ProductAppService(GeneralRepository<CDProduct> repository, MyDataContext context)
        {
            _repository = repository;
            _context = context;
        }
        public CDProduct AddProduct(ProducDto product)
        {
            var exist = _repository.Exists(p => p.ProductName.ToLower() == product.ProductName.ToLower());
            if (exist)
            {
                throw new Exception("el producto ya existe en la base da datos.");
            }
            var newProduct = new CDProduct
            {
                ProductName = product.ProductName,
                Price = product.Price,
                SalePrice = product.SalePrice,
                Stock = product.Stock,
                CategoryId = product.CategoryId

            };
            return newProduct;
        }           

        public void DeleteProduct(int id)
        {
            var product = _repository.GetById(id);
            if (product != null)
            {
                _repository.Delete(product);
            }
        }

        public List<CDProduct> GetAllProducts()
        {
            return _repository.GetAll();
        }

        public List<ProductCompleteDto> GetAllProductWihtCategory()
        {
            var listProducts = _context.Products.Include(p => p.Category).Select(p => new ProductCompleteDto
        {
            ProductName = p.ProductName,
            Price = p.Price,
            SalePrice = p.SalePrice,
            Stock = p.Stock,
            CategoryName = p.Category.CategoryName
        }).ToList();
            return listProducts;
        }      

        public List<CDProduct> GetAllProductWihtCondition()
        {
            return _repository.GetAll().Where(c => c.IsDelete == '0').ToList();            
        }
        public CDProduct GetById(int id)
        {
            return _repository.GetById(id);
        }
        public bool SoftDelete(int id)
        {
            var SDProdudct = _repository.GetById(id);
            if (SDProdudct != null)
            {
                SDProdudct.IsDelete = '1';
            }
            return true;
        }

        public CDProduct UpdateProduct(int id, ProducDto product)
        {
            var UpdateProduct = _repository.GetById(id);
            if (UpdateProduct != null)
            {
                UpdateProduct.ProductName = product.ProductName;
                UpdateProduct.Price = product.Price;
                UpdateProduct.SalePrice = product.SalePrice;
                UpdateProduct.Stock = product.Stock;
                UpdateProduct.CategoryId = product.CategoryId;
            }
            return _repository.Update(UpdateProduct);
        }
    }
}
