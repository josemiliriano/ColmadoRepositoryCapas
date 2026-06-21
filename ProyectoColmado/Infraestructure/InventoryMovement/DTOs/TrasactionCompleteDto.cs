using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.InventoryMovement.DTOs
{
    public class TrasactionCompleteDto
    {
        public string ProductName { get; set; }              
        public int Quantity { get; set; }          
        public string ProviderName { get; set; }
        public string DescriptionMovement { get; set; }
       
    }
}
