namespace DokumanTakip.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v30 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Isses", newName: "Is");
            RenameTable(name: "dbo.Kullanicis", newName: "Kullanici");
            RenameTable(name: "dbo.Rols", newName: "Rol");
            RenameTable(name: "dbo.Surecs", newName: "Surec");
            RenameTable(name: "dbo.RolKullanicis", newName: "RolKullanici");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RolKullanici", newName: "RolKullanicis");
            RenameTable(name: "dbo.Surec", newName: "Surecs");
            RenameTable(name: "dbo.Rol", newName: "Rols");
            RenameTable(name: "dbo.Kullanici", newName: "Kullanicis");
            RenameTable(name: "dbo.Is", newName: "Isses");
        }
    }
}
