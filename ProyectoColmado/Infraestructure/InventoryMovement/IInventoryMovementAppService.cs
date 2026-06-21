using Domain.Entities;
using Infraestructure.InventoryMovement.DTOs;
using Infraestructure.Product.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.InventoryMovement
{
    public interface IInventoryMovementAppService
    {
        public CDInventoryMovement AddBuy(InventoryMovementDto Buy);
        public CDInventoryMovement AddSale(InventoryMovementDto Sale);
        public List<CDInventoryMovement> GetAllBuy();
        public List<CDInventoryMovement> GetAllSale();
        public CDInventoryMovement GetById(int id);
        public CDInventoryMovement UpdateInventary(int id, InventoryMovementDto movement);
        public void DeleteTrasaction(int id);
        public bool SoftDelete(int id);
        public List<CDInventoryMovement> GetAllTransactionWihtCondition();
        public List<TrasactionCompleteDto> GetAllTransactionComplete();
    }
}
