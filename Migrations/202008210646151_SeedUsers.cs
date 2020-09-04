namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'54056488-0676-40cf-b817-d1eadf2fc6b5', N'admin@vildy.com', 0, N'AGp0kvTjEoOYYmNBZEPM+R6f53RwKCjRx0Od2sR8Yy/n7pXS9t7xx12ISEVJU4T/kw==', N'd346d55f-17aa-475d-98ac-7ac3640b2b1e', NULL, 0, 0, NULL, 1, 0, N'admin@vildy.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7c6e40c3-0cac-40fe-b9de-0e7e43ba6479', N'guest@domain.com', 0, N'ANDUOWdWwyUsvMcpNifYei1klFAausaYgsJ64mxdeG3nVJNal/OUr0SJN0sSjhXkvw==', N'c25afc7b-f417-4a86-85a6-5bb85e761450', NULL, 0, 0, NULL, 1, 0, N'guest@domain.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4c610e07-87f2-4fbf-9787-6981077fd71d', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'54056488-0676-40cf-b817-d1eadf2fc6b5', N'4c610e07-87f2-4fbf-9787-6981077fd71d')

");
        }
        
        public override void Down()
        {
        }
    }
}
