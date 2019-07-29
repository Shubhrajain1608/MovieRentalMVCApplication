namespace MovieRentalMVCApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyTry : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'869c8e96-dc86-42c6-8bd9-d28e86649213', N'CanCreateCustomer'", +
             "   INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'35fd1463-cec0-4bf0-86c5-cc95ee9f0446', N'shubhi@gmail.com', 0, N'ALJmUr+T9i2dipxazkHuVYjYjFix84PA3COfUqtbVEyPnRM809Yu826B7NQbP28gfg==', N'20933dbe-9583-4b83-ac63-3660af88da6a', NULL, 0, 0, NULL, 1, 0, N'shubhi@gmail.com'" +
             "INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'35fd1463-cec0-4bf0-86c5-cc95ee9f0446', N'869c8e96-dc86-42c6-8bd9-d28e86649213'");


        }
        
        public override void Down()
        {
        }
    }
}
