namespace MovieRentalMVCApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieupd : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Movies", new[] { "genereId" });
            AlterColumn("dbo.Movies", "MovieName", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Movies", "GenereId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "GenereId" });
            AlterColumn("dbo.Movies", "MovieName", c => c.String());
            CreateIndex("dbo.Movies", "genereId");
        }
    }
}
