namespace DokumanTakip.Dal.Entity_Framework
{
    using DokumanTakip.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class DokumanTakipContext : DbContext
    {
        // Your context has been configured to use a 'DokumanTakipContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DokumanTakip.Dal.Entity_Framework.DokumanTakipContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DokumanTakipContext' 
        // connection string in the application configuration file.
        public DokumanTakipContext()
            : base("name=DokumanTakipContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DokumanTakipContext>(new CreateDatabaseIfNotExists<DokumanTakipContext>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Is> Isler { get; set; }
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Rol> Roller { get; set; }
        public virtual DbSet<Surec> Surecler { get; set; }
    }
}