using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Product.DTOs
{
    public class ProductCompleteDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; }
    }
}
