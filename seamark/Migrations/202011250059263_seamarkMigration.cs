namespace seamark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seamarkMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(),
                        AccountisDeleted = c.Boolean(nullable: false),
                        Authority = c.String(),
                        Name = c.String(),
                        From = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Solveflag = c.Boolean(nullable: false),
                        Name = c.String(),
                        Deleteflag = c.Boolean(nullable: false),
                        Text = c.String(),
                        Highlightflag = c.Boolean(nullable: false),
                        Account_Id = c.Int(),
                        Vote_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.Account_Id)
                .ForeignKey("dbo.Votes", t => t.Vote_Id)
                .Index(t => t.Account_Id)
                .Index(t => t.Vote_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Text = c.String(),
                        Deleteflag = c.Boolean(nullable: false),
                        Article_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.articles", t => t.Article_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Agree = c.Int(nullable: false),
                        Disagree = c.Int(nullable: false),
                        TotalVotes = c.Int(nullable: false),
                        Name = c.String(),
                        Text = c.String(),
                        Deadline = c.DateTime(nullable: false),
                        Posted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.highlights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(),
                        Text = c.String(),
                        Deleteflag = c.Boolean(nullable: false),
                        Color = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VoteAccounts",
                c => new
                    {
                        Vote_Id = c.Int(nullable: false),
                        Account_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vote_Id, t.Account_Id })
                .ForeignKey("dbo.Votes", t => t.Vote_Id, cascadeDelete: true)
                .ForeignKey("dbo.Accounts", t => t.Account_Id, cascadeDelete: true)
                .Index(t => t.Vote_Id)
                .Index(t => t.Account_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.articles", "Vote_Id", "dbo.Votes");
            DropForeignKey("dbo.VoteAccounts", "Account_Id", "dbo.Accounts");
            DropForeignKey("dbo.VoteAccounts", "Vote_Id", "dbo.Votes");
            DropForeignKey("dbo.Comments", "Article_Id", "dbo.articles");
            DropForeignKey("dbo.articles", "Account_Id", "dbo.Accounts");
            DropIndex("dbo.VoteAccounts", new[] { "Account_Id" });
            DropIndex("dbo.VoteAccounts", new[] { "Vote_Id" });
            DropIndex("dbo.Comments", new[] { "Article_Id" });
            DropIndex("dbo.articles", new[] { "Vote_Id" });
            DropIndex("dbo.articles", new[] { "Account_Id" });
            DropTable("dbo.VoteAccounts");
            DropTable("dbo.highlights");
            DropTable("dbo.Votes");
            DropTable("dbo.Comments");
            DropTable("dbo.articles");
            DropTable("dbo.Accounts");
        }
    }
}
