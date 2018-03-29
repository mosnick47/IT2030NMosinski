namespace IT2030_Lab09_Mosinski_EnrollmentAp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lab6_Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseTitle", c => c.String(nullable: false));
            AlterColumn("dbo.Enrollments", "AssignedCampus", c => c.String(nullable: false));
            AlterColumn("dbo.Enrollments", "EnrollmentSemester", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "FirstName", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Enrollments", "EnrollmentSemester", c => c.String());
            AlterColumn("dbo.Enrollments", "AssignedCampus", c => c.String());
            AlterColumn("dbo.Courses", "CourseTitle", c => c.String());
        }
    }
}
