namespace netmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_userid_income : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Incomes", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Incomes", "UserId");
        }
    }
}
