namespace PaymentCrudapp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Paymenttransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "TransactionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "TransactionId");
            AddForeignKey("dbo.Payments", "TransactionId", "dbo.Transactions", "TransactionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "TransactionId", "dbo.Transactions");
            DropIndex("dbo.Payments", new[] { "TransactionId" });
            DropColumn("dbo.Payments", "TransactionId");
        }
    }
}
