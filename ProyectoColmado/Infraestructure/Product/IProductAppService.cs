using Domain.Entities;
using Infraestructure.Categoria.DTOs;
using Infraestructure.Product.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Product
{
    public interface IProductAppService
    {
        public CDProduct AddProduct(ProducDto product);
        public List<CDProduct> GetAllProducts();
        public CDProduct GetById(int id);
        public CDProduct UpdateProduct(int id, ProducDto product);
        public void DeleteProduct(int id);
        public bool SoftDelete(int id);
        public List<CDProduct> GetAllProductWihtCondition();
        public List<ProductCompleteDto> GetAllProductWihtCategory();

    }
}
