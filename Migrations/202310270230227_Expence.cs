namespace netmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Expence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Imageurl = c.String(),
                        Type = c.Int(nullable: false),
                        UserId = c.String(),
                        Created = c.DateTime(nullable: false),
                        ExpenseType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExpenseTypes", t => t.ExpenseType_Id)
                .Index(t => t.ExpenseType_Id);
            
            CreateTable(
                "dbo.ExpenseTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Min = c.Single(nullable: false),
                        Max = c.Single(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        NetIncome = c.Decimal(nullable: false, precision: 18, scale: 2),
                        start = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "ExpenseType_Id", "dbo.ExpenseTypes");
            DropIndex("dbo.Expenses", new[] { "ExpenseType_Id" });
            DropTable("dbo.Incomes");
            DropTable("dbo.ExpenseTypes");
            DropTable("dbo.Expenses");
        }
    }
}
