namespace VOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@" INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'da5a8aa3-81c6-43cd-9ce9-f49a9ee11b08', N'Administrator1@vod.pl', 0, N'AAd4Sj9xYnXAfvjfrsIUeDguUR4xFYOSgo1qj1Ov73wkawycCp1zYKcwGV+BVRpnww==', N'2131723f-b1c8-403e-94d2-3fe6e56fd1de', NULL, 0, 0, NULL, 1, 0, N'Administrator1')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'da5a8aa3-81c6-43cd-9ce9-f49a9ee11b08', N'2c116d25-d7ba-4fc6-a353-41862c90c3dd')

 ");
        }
        
        public override void Down()
        {
        }
    }
}
