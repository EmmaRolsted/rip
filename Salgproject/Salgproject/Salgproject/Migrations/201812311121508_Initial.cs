namespace Salgproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vares",
                c => new
                    {
                        ItemNumber = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        ItemCount = c.Int(nullable: false),
                        IsNotifying = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ItemNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vares");
        }
    }
}
