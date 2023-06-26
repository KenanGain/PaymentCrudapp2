namespace PaymentCrudapp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Payment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Payments");
        }
    }
}
