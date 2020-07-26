namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Int32Update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Title", "Wrestler_WrestlerId", "dbo.Wrestler");
            DropForeignKey("dbo.Title", "Title_TitleId", "dbo.Title");
            DropForeignKey("dbo.Wrestler", "Title_TitleId", "dbo.Title");
            DropForeignKey("dbo.Wrestler", "TitleId", "dbo.Title");
            DropIndex("dbo.Title", new[] { "WrestlerId" });
            DropIndex("dbo.Title", new[] { "Wrestler_WrestlerId" });
            DropColumn("dbo.Title", "Wrestler_WrestlerId");
            RenameColumn(table: "dbo.Title", name: "Title_Id", newName: "Title_TitleId");
            RenameColumn(table: "dbo.Title", name: "WrestlerId", newName: "Wrestler_WrestlerId");
            RenameColumn(table: "dbo.Wrestler", name: "Title_Id", newName: "Title_TitleId");
            RenameIndex(table: "dbo.Wrestler", name: "IX_Title_Id", newName: "IX_Title_TitleId");
            RenameIndex(table: "dbo.Title", name: "IX_Title_Id", newName: "IX_Title_TitleId");
            DropPrimaryKey("dbo.Title");
            AddColumn("dbo.Title", "TitleId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Title", "Wrestler_WrestlerId1", c => c.Int());
            AlterColumn("dbo.Title", "Wrestler_WrestlerId", c => c.Int());
            AddPrimaryKey("dbo.Title", "TitleId");
            CreateIndex("dbo.Title", "Wrestler_WrestlerId");
            CreateIndex("dbo.Title", "Wrestler_WrestlerId1");
            AddForeignKey("dbo.Title", "Wrestler_WrestlerId1", "dbo.Wrestler", "WrestlerId");
            AddForeignKey("dbo.Title", "Title_TitleId", "dbo.Title", "TitleId");
            AddForeignKey("dbo.Wrestler", "Title_TitleId", "dbo.Title", "TitleId");
            AddForeignKey("dbo.Wrestler", "TitleId", "dbo.Title", "TitleId");
            DropColumn("dbo.Title", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Title", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Wrestler", "TitleId", "dbo.Title");
            DropForeignKey("dbo.Wrestler", "Title_TitleId", "dbo.Title");
            DropForeignKey("dbo.Title", "Title_TitleId", "dbo.Title");
            DropForeignKey("dbo.Title", "Wrestler_WrestlerId1", "dbo.Wrestler");
            DropIndex("dbo.Title", new[] { "Wrestler_WrestlerId1" });
            DropIndex("dbo.Title", new[] { "Wrestler_WrestlerId" });
            DropPrimaryKey("dbo.Title");
            AlterColumn("dbo.Title", "Wrestler_WrestlerId", c => c.Int(nullable: false));
            DropColumn("dbo.Title", "Wrestler_WrestlerId1");
            DropColumn("dbo.Title", "TitleId");
            AddPrimaryKey("dbo.Title", "Id");
            RenameIndex(table: "dbo.Title", name: "IX_Title_TitleId", newName: "IX_Title_Id");
            RenameIndex(table: "dbo.Wrestler", name: "IX_Title_TitleId", newName: "IX_Title_Id");
            RenameColumn(table: "dbo.Wrestler", name: "Title_TitleId", newName: "Title_Id");
            RenameColumn(table: "dbo.Title", name: "Wrestler_WrestlerId", newName: "WrestlerId");
            RenameColumn(table: "dbo.Title", name: "Title_TitleId", newName: "Title_Id");
            AddColumn("dbo.Title", "Wrestler_WrestlerId", c => c.Int());
            CreateIndex("dbo.Title", "Wrestler_WrestlerId");
            CreateIndex("dbo.Title", "WrestlerId");
            AddForeignKey("dbo.Wrestler", "TitleId", "dbo.Title", "TitleId");
            AddForeignKey("dbo.Wrestler", "Title_TitleId", "dbo.Title", "TitleId");
            AddForeignKey("dbo.Title", "Title_TitleId", "dbo.Title", "TitleId");
            AddForeignKey("dbo.Title", "Wrestler_WrestlerId", "dbo.Wrestler", "WrestlerId");
        }
    }
}
