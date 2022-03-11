using Microsoft.EntityFrameworkCore;
using RenovationWorkDatabaseImplement.Models;

namespace RenovationWorkDatabaseImplement.Implements
{
    public class RenovationWorkDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3GH1PMV\SQLEXPRESS;Initial Catalog=RenovationWorkDatabaseComplicated;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Repair> Repairs { set; get; }
        public virtual DbSet<Warehouse> Warehouses { set; get; }
        public virtual DbSet<RepairComponent> RepairComponents { set; get; }
        public virtual DbSet<WarehouseComponent> WarehouseComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}
