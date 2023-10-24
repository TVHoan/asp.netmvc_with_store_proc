namespace netmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CUD_Proc_Post : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Post_Insert",
                p => new
                    {
                        Name = p.String(),
                        Description = p.String(),
                        Author = p.String(),
                        Created = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Posts]([Name], [Description], [Author], [Created])
                      VALUES (@Name, @Description, @Author, @Created)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Posts]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Posts] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Post_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(),
                        Description = p.String(),
                        Author = p.String(),
                        Created = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Posts]
                      SET [Name] = @Name, [Description] = @Description, [Author] = @Author, [Created] = @Created
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Post_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Posts]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Post_Delete");
            DropStoredProcedure("dbo.Post_Update");
            DropStoredProcedure("dbo.Post_Insert");
        }
    }
}
