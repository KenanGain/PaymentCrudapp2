namespace PaymentCrudapp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transcation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TransactionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transactions");
        }
    }
}
