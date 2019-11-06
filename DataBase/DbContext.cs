namespace DataBase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DataBase.EntityModels;
    public partial class DbContext : System.Data.Entity.DbContext
    {
        public DbContext()
            : base("ServiceCenter")
        {
        }

        public virtual DbSet<DevicesEntityModel> Devices { get; set; }
        public virtual DbSet<OrdersEntityModel> Orders { get; set; }
        public virtual DbSet<ReportOrdersEntityModel> ReportOrders { get; set; }
        public virtual DbSet<RollesEntityModel> Rolles { get; set; }
        public virtual DbSet<ServicesEntityModel> Services { get; set; }
        public virtual DbSet<StagesEntityModel> Stages { get; set; }
        public virtual DbSet<sysdiagramsEntityModel> sysdiagrams { get; set; }
        public virtual DbSet<UsersEntityModel> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DevicesEntityModel>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Devices)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RollesEntityModel>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Rolles)
                .HasForeignKey(e => e.Rolle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServicesEntityModel>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Services)
                .HasForeignKey(e => e.SelectedService)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StagesEntityModel>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Stages)
                .HasForeignKey(e => e.StageOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsersEntityModel>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsersEntityModel>()
                .HasMany(e => e.Orders1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.IdMaster);

        }
    }
}
