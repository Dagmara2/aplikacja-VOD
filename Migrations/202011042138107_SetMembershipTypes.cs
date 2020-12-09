namespace VOD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipName = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Annual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
