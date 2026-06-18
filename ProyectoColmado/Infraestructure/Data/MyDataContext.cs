using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data
{
    public class MyDataContext:DbContext
    {
        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CDProduct> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<MovementType> MovementTypes { get; set; }
        public DbSet<InventoryMovement>InventoryMovements { get; set; }        
    }
}
