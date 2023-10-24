namespace netmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class proc_create_post : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("dbo.GetAllPost", p => new 
            {
                Skip = p.Int(),
                Take = p.Int(),
            },body: @"SELECT * FROM [dbo].[Posts] ORDER BY Id  Offset @Skip Rows Fetch Next @Take Rows Only ");
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.GetAllPost");
        }
    }
}
