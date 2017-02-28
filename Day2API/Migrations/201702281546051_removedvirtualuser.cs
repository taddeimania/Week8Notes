namespace Day2API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedvirtualuser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Transactions", new[] { "UserId" });
            AlterColumn("dbo.Transactions", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Transactions", "UserId");
            AddForeignKey("dbo.Transactions", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
