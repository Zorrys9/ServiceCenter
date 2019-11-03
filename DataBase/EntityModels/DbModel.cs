namespace DataBase.EntityModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("DbConnection")
        {        }

        public virtual DbSet<Devices> Devices { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<ReportOrders> ReportOrders { get; set; }
        public virtual DbSet<Rolles> Rolles { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Stages> Stages { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Devices>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Devices)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rolles>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Rolles)
                .HasForeignKey(e => e.Rolle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Services>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Services)
                .HasForeignKey(e => e.SelectedService)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stages>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Stages)
                .HasForeignKey(e => e.StageOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Orders1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.IdMaster);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.ReportOrders)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.IdClient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.ReportOrders1)
                .WithRequired(e => e.Users1)
                .HasForeignKey(e => e.IdMaster)
                .WillCascadeOnDelete(false);
        }
    }
}
