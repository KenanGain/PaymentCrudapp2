namespace PaymentCrudapp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "UserId");
            AddForeignKey("dbo.Payments", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "UserId", "dbo.Users");
            DropIndex("dbo.Payments", new[] { "UserId" });
            DropColumn("dbo.Payments", "UserId");
        }
    }
}
