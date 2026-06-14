using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class InventoryMovement
    {
        [Key]
        public int IdInventoryMovement { get; set; }
        [ForeignKey("IdProduct")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("IdMovementType")]
        public int MovementTypeiD { get; set; }
        public MovementType MovementType { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        [ForeignKey("IdProvider")]
        public int? ProviderId { get; set; }
        public Provider Provider { get; set; }
        public char IsDelete { get; set; } = '0';
    }
}
