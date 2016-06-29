namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newAll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicYear",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RemindWhenEndDate = c.Boolean(),
                        IsActive = c.Boolean(nullable: false),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Notice = c.String(),
                        WeightPercent = c.Single(),
                        ExamTypeId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        ResultDate = c.DateTime(),
                        SchoolId = c.Int(nullable: false),
                        AcademicYearId = c.Int(nullable: false),
                        SessionId = c.Int(),
                        ExamCoordinatorId = c.Int(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamType", t => t.ExamTypeId)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .ForeignKey("dbo.AcademicYear", t => t.AcademicYearId)
                .ForeignKey("dbo.Users", t => t.ExamCoordinatorId)
                .Index(t => t.ExamTypeId)
                .Index(t => t.SchoolId)
                .Index(t => t.AcademicYearId)
                .Index(t => t.ExamCoordinatorId);
            
            CreateTable(
                "dbo.ExamType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SchoolId = c.Int(nullable: false),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.School",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(),
                        IsDeleted = c.Boolean(),
                        SchoolTypeId = c.Int(nullable: false),
                        Code = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        Phone = c.String(),
                        RegNo = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        CreatedDate = c.DateTime(),
                        UserId = c.Int(),
                        Image = c.Binary(),
                        ImageType = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SchoolType", t => t.SchoolTypeId)
                .Index(t => t.SchoolTypeId);
            
            CreateTable(
                "dbo.SchoolType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InstitutionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        EmailDisplay = c.String(),
                        Phone = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Description = c.String(),
                        DOB = c.DateTime(),
                        IsActive = c.Boolean(),
                        IsDeleted = c.Boolean(),
                        GenderId = c.Int(),
                        SchoolId = c.Int(nullable: false),
                        Image = c.Binary(),
                        ImageType = c.String(),
                        CreatedDate = c.DateTime(),
                        LastOnline = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gender", t => t.GenderId)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.GenderId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserDivision",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsersId = c.Int(nullable: false),
                        DivisionId = c.Int(nullable: false),
                        AssignDate = c.DateTime(nullable: false),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UsersId)
                .ForeignKey("dbo.Division", t => t.DivisionId)
                .Index(t => t.UsersId)
                .Index(t => t.DivisionId);
            
            CreateTable(
                "dbo.Division",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentDivisionId = c.Int(),
                        SchoolId = c.Int(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .ForeignKey("dbo.Division", t => t.ParentDivisionId)
                .Index(t => t.SchoolId)
                .Index(t => t.ParentDivisionId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SchoolId = c.Int(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.RoleCapability",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        CapabilityId = c.Int(nullable: false),
                        AssignedDate = c.DateTime(),
                        DroppedDate = c.DateTime(),
                        Void = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .ForeignKey("dbo.Capability", t => t.CapabilityId)
                .Index(t => t.RoleId)
                .Index(t => t.CapabilityId);
            
            CreateTable(
                "dbo.Capability",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExamSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectClassId = c.Int(nullable: false),
                        ExamId = c.Int(nullable: false),
                        ExamSubTypeId = c.Int(),
                        FullMarks = c.Int(nullable: false),
                        PassMarks = c.Int(nullable: false),
                        SubjectExamDate = c.DateTime(),
                        StartTime = c.Time(nullable: false),
                        Hours = c.Byte(nullable: false),
                        Minutes = c.Byte(),
                        WeightPercent = c.Single(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .ForeignKey("dbo.Exam", t => t.ExamId)
                .ForeignKey("dbo.ExamSubType", t => t.ExamSubTypeId)
                .Index(t => t.SubjectClassId)
                .Index(t => t.ExamId)
                .Index(t => t.ExamSubTypeId);
            
            CreateTable(
                "dbo.SubjectClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        SubjectGroupId = c.Int(),
                        RunningClassId = c.Int(nullable: false),
                        NotSubscribale = c.Boolean(),
                        SubscriptionPermissionRequired = c.Boolean(),
                        SubscriptionOptional = c.Boolean(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.SubjectGroup", t => t.SubjectGroupId)
                .ForeignKey("dbo.RunningClass", t => t.RunningClassId)
                .Index(t => t.SubjectId)
                .Index(t => t.SubjectGroupId)
                .Index(t => t.RunningClassId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Summary = c.String(),
                        Code = c.String(),
                        Credit = c.Byte(),
                        SubjectCategoryId = c.Int(nullable: false),
                        CompletionHours = c.Short(),
                        FullMarks = c.Int(),
                        PassPercentage = c.Byte(),
                        IsActive = c.Boolean(),
                        Void = c.Boolean(),
                        HasLab = c.Boolean(),
                        HasTheory = c.Boolean(),
                        HasProject = c.Boolean(),
                        HasTutorial = c.Boolean(),
                        IsElective = c.Boolean(),
                        IsOutOfSyllabus = c.Boolean(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectCategory", t => t.SubjectCategoryId)
                .Index(t => t.SubjectCategoryId);
            
            CreateTable(
                "dbo.SubjectCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Code = c.String(),
                        ParentId = c.Int(),
                        Description = c.String(),
                        SchoolId = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                        IsVoid = c.Boolean(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.SubjectGroupSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        SubjectGroupId = c.Int(nullable: false),
                        AssignedDate = c.DateTime(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.SubjectGroup", t => t.SubjectGroupId)
                .Index(t => t.SubjectId)
                .Index(t => t.SubjectGroupId);
            
            CreateTable(
                "dbo.SubjectGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Desctiption = c.String(),
                        LevelId = c.Int(),
                        FacultyId = c.Int(),
                        ProgramId = c.Int(),
                        YearId = c.Int(),
                        SchoolId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        IsActive = c.Boolean(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Year", t => t.YearId)
                .ForeignKey("dbo.Level", t => t.LevelId)
                .ForeignKey("dbo.Faculty", t => t.FacultyId)
                .ForeignKey("dbo.Program", t => t.ProgramId)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.YearId)
                .Index(t => t.LevelId)
                .Index(t => t.FacultyId)
                .Index(t => t.ProgramId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Level",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SchoolId = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                        Void = c.Boolean(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LevelId = c.Int(nullable: false),
                        Description = c.String(),
                        Void = c.Boolean(),
                        IsActive = c.Boolean(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Level", t => t.LevelId)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Program",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FacultyId = c.Int(nullable: false),
                        Description = c.String(),
                        IsActive = c.Boolean(),
                        Void = c.Boolean(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Faculty", t => t.FacultyId)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Year",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.Int(nullable: false),
                        Description = c.String(),
                        ProgramId = c.Int(nullable: false),
                        IsActive = c.Boolean(),
                        Void = c.Boolean(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Program", t => t.ProgramId)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.SubYear",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Position = c.Int(nullable: false),
                        ParentId = c.Int(),
                        YearId = c.Int(),
                        IsActive = c.Boolean(),
                        Void = c.Boolean(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubYear", t => t.ParentId)
                .ForeignKey("dbo.Year", t => t.YearId)
                .Index(t => t.ParentId)
                .Index(t => t.YearId);
            
            CreateTable(
                "dbo.Teach",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcademicYearId = c.Int(nullable: false),
                        SessionId = c.Int(),
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EstimatedCompletionHours = c.Int(),
                        Void = c.Boolean(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicYear", t => t.AcademicYearId)
                .ForeignKey("dbo.Session", t => t.SessionId)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.AcademicYearId)
                .Index(t => t.SessionId)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SessionType = c.String(),
                        ParentId = c.Int(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Void = c.Boolean(),
                        RemindWhenEndDate = c.Boolean(),
                        AcademicYearId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Session", t => t.ParentId)
                .ForeignKey("dbo.AcademicYear", t => t.AcademicYearId)
                .Index(t => t.ParentId)
                .Index(t => t.AcademicYearId);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AppointedDate = c.DateTime(),
                        ResearchInterest = c.String(),
                        Hobbies = c.String(),
                        TeacherJobTitleId = c.Int(),
                        JobTitle = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.TeacherJobTitle", t => t.TeacherJobTitleId)
                .Index(t => t.UserId)
                .Index(t => t.TeacherJobTitleId);
            
            CreateTable(
                "dbo.TeacherJobTitle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InstitutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Institution", t => t.InstitutionId)
                .Index(t => t.InstitutionId);
            
            CreateTable(
                "dbo.Institution",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        PostalCode = c.String(),
                        PanNo = c.String(),
                        Website = c.String(),
                        Email = c.String(),
                        Moto = c.String(),
                        Category = c.String(),
                        Logo = c.Binary(),
                        LogoImageType = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SubjectSection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Summary = c.String(),
                        ShowSummary = c.Boolean(),
                        SubjectId = c.Int(nullable: false),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Restriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        TypeId = c.Int(nullable: false),
                        CheckParameter1 = c.String(),
                        CheckParameter2 = c.String(),
                        StringValue1 = c.String(),
                        StringValue2 = c.String(),
                        IntValue1 = c.Int(nullable: false),
                        IntValue2 = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        SubjectSection_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.SubjectSection", t => t.SubjectSection_Id)
                .Index(t => t.SubjectId)
                .Index(t => t.SubjectSection_Id);
            
            CreateTable(
                "dbo.SubjectActivityAndResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ShowDesctiptionOnPage = c.Boolean(nullable: false),
                        Void = c.Boolean(),
                        Type = c.String(),
                        SubjectSectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectSection", t => t.SubjectSectionId)
                .Index(t => t.SubjectSectionId);
            
            CreateTable(
                "dbo.RunningClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcademicYearId = c.Int(nullable: false),
                        SessionId = c.Int(),
                        YearId = c.Int(nullable: false),
                        SubYearId = c.Int(),
                        Void = c.Boolean(),
                        IsActive = c.Boolean(),
                        Completed = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicYear", t => t.AcademicYearId)
                .ForeignKey("dbo.Session", t => t.SessionId)
                .ForeignKey("dbo.Year", t => t.YearId)
                .ForeignKey("dbo.SubYear", t => t.SubYearId)
                .Index(t => t.AcademicYearId)
                .Index(t => t.SessionId)
                .Index(t => t.YearId)
                .Index(t => t.SubYearId);
            
            CreateTable(
                "dbo.ExamSubType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SchoolId = c.Int(nullable: false),
                        Description = c.String(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.ExamStudent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamSubjectId = c.Int(nullable: false),
                        StudentClassId = c.Int(nullable: false),
                        ObtainedMarksInPercent = c.Single(nullable: false),
                        ObtainedMarksInGrade = c.String(),
                        PostedDate = c.DateTime(),
                        PostedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamSubject", t => t.ExamSubjectId)
                .ForeignKey("dbo.StudentClass", t => t.StudentClassId)
                .ForeignKey("dbo.Users", t => t.PostedById)
                .Index(t => t.ExamSubjectId)
                .Index(t => t.StudentClassId)
                .Index(t => t.PostedById);
            
            CreateTable(
                "dbo.StudentClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        StudentGroupId = c.Int(),
                        RunningClassId = c.Int(nullable: false),
                        Suspended = c.Boolean(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.StudentGroup", t => t.StudentGroupId)
                .ForeignKey("dbo.RunningClass", t => t.RunningClassId)
                .Index(t => t.StudentId)
                .Index(t => t.StudentGroupId)
                .Index(t => t.RunningClassId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CRN = c.String(),
                        ExamRollNoGlobal = c.String(),
                        UserId = c.Int(nullable: false),
                        GuardianName = c.String(),
                        GuardianEmail = c.String(),
                        GuardianContactNo = c.String(),
                        Void = c.Boolean(),
                        AssignedDate = c.DateTime(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.StudentGroupStudent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignedDate = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                        StudentGroupId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        AssignedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.StudentGroup", t => t.StudentGroupId)
                .Index(t => t.StudentId)
                .Index(t => t.StudentGroupId);
            
            CreateTable(
                "dbo.StudentGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SchoolId = c.Int(),
                        ParentId = c.Int(),
                        IsActive = c.Boolean(),
                        Void = c.Boolean(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentGroup", t => t.ParentId)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.ParentId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Study",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentGroupId = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                        SectionId = c.Int(),
                        AcademicYearId = c.Int(nullable: false),
                        SessionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentGroup", t => t.StudentGroupId)
                .ForeignKey("dbo.Year", t => t.YearId)
                .ForeignKey("dbo.SubYear", t => t.SectionId)
                .ForeignKey("dbo.AcademicYear", t => t.AcademicYearId)
                .ForeignKey("dbo.Session", t => t.SessionId)
                .Index(t => t.StudentGroupId)
                .Index(t => t.YearId)
                .Index(t => t.SectionId)
                .Index(t => t.AcademicYearId)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.ExamSubjectTeacher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamSubjectId = c.Int(nullable: false),
                        TeacherClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamSubject", t => t.ExamSubjectId)
                .ForeignKey("dbo.TeacherClass", t => t.TeacherClassId)
                .Index(t => t.ExamSubjectId)
                .Index(t => t.TeacherClassId);
            
            CreateTable(
                "dbo.TeacherClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        SubjectClassId = c.Int(nullable: false),
                        PostingFor = c.String(),
                        Void = c.Boolean(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectClassId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcademicYearId = c.Int(nullable: false),
                        ChoosenDate = c.DateTime(nullable: false),
                        EstimatedEndTime = c.Byte(nullable: false),
                        CEOId = c.Int(nullable: false),
                        PrincipalId = c.Int(nullable: false),
                        AdministratorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicYear", t => t.AcademicYearId)
                .Index(t => t.AcademicYearId);
            
            CreateTable(
                "dbo.AdminTitle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OtherAdmins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminsId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Position = c.String(),
                        Task = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminsId)
                .Index(t => t.AdminsId);
            
            CreateTable(
                "dbo.SessionAdmins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        TitleId = c.Int(nullable: false),
                        Task = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminTitle", t => t.TitleId)
                .ForeignKey("dbo.Session", t => t.SessionId)
                .Index(t => t.TitleId)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.FileCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectSubscription",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentClassId = c.Int(nullable: false),
                        SubjectClassId = c.Int(nullable: false),
                        Permitted = c.Boolean(),
                        Suspended = c.Boolean(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentClass", t => t.StudentClassId)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .Index(t => t.StudentClassId)
                .Index(t => t.SubjectClassId);
            
            CreateTable(
                "dbo.StudentsOpinionAboutSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectSubscriptionId = c.Int(nullable: false),
                        Rating = c.Byte(),
                        Opinion = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectSubscription", t => t.SubjectSubscriptionId)
                .Index(t => t.SubjectSubscriptionId);
            
            CreateTable(
                "dbo.AssignedTask",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeachId = c.Int(nullable: false),
                        AssignmentId = c.Int(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        DueDate = c.String(),
                        Remarks = c.String(),
                        SessionId = c.Int(nullable: false),
                        CarriesMarks = c.Boolean(nullable: false),
                        TotalMarks = c.Short(),
                        PassMarks = c.Short(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teach", t => t.TeachId)
                .ForeignKey("dbo.Assignment", t => t.AssignmentId)
                .ForeignKey("dbo.Session", t => t.SessionId)
                .Index(t => t.TeachId)
                .Index(t => t.AssignmentId)
                .Index(t => t.SessionId);
            
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Remarks = c.String(),
                        SubjectId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Resource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        AccessPermissionId = c.Int(nullable: false),
                        Category = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        Note = c.String(),
                        StudentFile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentFile", t => t.StudentFile_Id)
                .Index(t => t.StudentFile_Id);
            
            CreateTable(
                "dbo.ResourceFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(),
                        OwnerId = c.Int(nullable: false),
                        DisplayName = c.String(),
                        FileName = c.String(),
                        FileDirectory = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teacher", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Remarks = c.String(),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resource", t => t.ResourceId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.AssignmentAnswer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignmentId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Answer = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assignment", t => t.AssignmentId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.AssignmentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.AssignmentAnswerFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignmentAnswerId = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssignmentAnswer", t => t.AssignmentAnswerId)
                .Index(t => t.AssignmentAnswerId);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Question = c.String(),
                        Hint = c.String(),
                        Solution = c.String(),
                        AssignmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assignment", t => t.AssignmentId)
                .Index(t => t.AssignmentId);
            
            CreateTable(
                "dbo.Attendance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        PresenceStatusId = c.Int(nullable: false),
                        AttendanceDayId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.PresenceStatus", t => t.PresenceStatusId)
                .ForeignKey("dbo.AttendanceDay", t => t.AttendanceDayId)
                .Index(t => t.StudentId)
                .Index(t => t.PresenceStatusId)
                .Index(t => t.AttendanceDayId);
            
            CreateTable(
                "dbo.PresenceStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AttendanceDay",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TeachId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teach", t => t.TeachId)
                .Index(t => t.TeachId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Publication = c.String(),
                        ISBN = c.String(),
                        IsTextBook = c.String(),
                        SubjectId = c.Int(nullable: false),
                        LibraryId = c.Int(nullable: false),
                        CustomSerialNumber = c.String(),
                        Edition = c.String(),
                        BookCategoryId = c.Int(nullable: false),
                        BookReturnCategoryId = c.Int(nullable: false),
                        CategoryOfUsefulness = c.String(),
                        Price = c.Single(nullable: false),
                        Void = c.Boolean(nullable: false),
                        BookCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.BookCategory", t => t.BookCategory_Id)
                .ForeignKey("dbo.BookCategory", t => t.BookCategoryId)
                .ForeignKey("dbo.BookReturnCategory", t => t.BookReturnCategoryId)
                .ForeignKey("dbo.Library", t => t.LibraryId)
                .Index(t => t.SubjectId)
                .Index(t => t.BookCategory_Id)
                .Index(t => t.BookCategoryId)
                .Index(t => t.BookReturnCategoryId)
                .Index(t => t.LibraryId);
            
            CreateTable(
                "dbo.BookCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        LibraryId = c.Int(nullable: false),
                        Book_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Library", t => t.LibraryId)
                .ForeignKey("dbo.Book", t => t.Book_Id)
                .Index(t => t.LibraryId)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Library",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolId = c.Int(nullable: false),
                        Name = c.String(),
                        Location = c.String(),
                        Telephone = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ChiefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookReturnCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LibraryId = c.Int(nullable: false),
                        ReturnYears = c.Byte(nullable: false),
                        ReturnMonths = c.Byte(nullable: false),
                        ReturnDays = c.Short(nullable: false),
                        FinePerMonth = c.Single(nullable: false),
                        FinePerWeek = c.Single(nullable: false),
                        FinePerDay = c.Single(nullable: false),
                        FinePerHour = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Library", t => t.LibraryId)
                .Index(t => t.LibraryId);
            
            CreateTable(
                "dbo.BookAuthor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        AssociatedUniversity = c.String(),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.BookId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Issue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        ReturnDueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.BookId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.BookId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.MemberShip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LibraryId = c.Int(nullable: false),
                        UserTypeId = c.Byte(nullable: false),
                        UserId = c.Int(nullable: false),
                        MembershipDate = c.DateTime(nullable: false),
                        ValidUpto = c.DateTime(nullable: false),
                        MembershipCharge = c.Single(nullable: false),
                        Void = c.Boolean(nullable: false),
                        MembershipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipType", t => t.MembershipTypeId)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.MembershipType",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        LibraryId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Return",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        issueId = c.Int(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        IsFine = c.Boolean(nullable: false),
                        Amount = c.Single(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Issue", t => t.issueId)
                .Index(t => t.issueId);
            
            CreateTable(
                "dbo.UsefulnessCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssignmentMarks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignedTaskId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Marks = c.Single(nullable: false),
                        IsGradeSystem = c.Boolean(nullable: false),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssignedTask", t => t.AssignedTaskId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.Grade", t => t.GradeId)
                .Index(t => t.AssignedTaskId)
                .Index(t => t.StudentId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExamMarks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectExamId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Marks = c.Single(),
                        IsGradeSystem = c.Boolean(nullable: false),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamSubject", t => t.SubjectExamId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.SubjectExamId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.AccessPermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Read = c.Boolean(nullable: false),
                        ReadWrite = c.Boolean(nullable: false),
                        Write = c.Boolean(nullable: false),
                        Append = c.Boolean(nullable: false),
                        IsGlobal = c.Boolean(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        IsPrivate = c.Boolean(nullable: false),
                        IsAssignable = c.Boolean(nullable: false),
                        IsSearchable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        FileName = c.String(),
                        FileDirectory = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentGroupResourceShare",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        Remarks = c.String(),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                        SendDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teacher", t => t.SenderId)
                .ForeignKey("dbo.StudentGroup", t => t.ReceiverId)
                .ForeignKey("dbo.Resource", t => t.ResourceId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.StudentResourceShare",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        Remarks = c.String(),
                        SenderType = c.Byte(nullable: false),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                        SendDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.ReceiverId)
                .ForeignKey("dbo.Resource", t => t.ResourceId)
                .Index(t => t.ReceiverId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.TeacherResourceShare",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        Remarks = c.String(),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                        SendDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teacher", t => t.SenderId)
                .ForeignKey("dbo.Teacher", t => t.ReceiverId)
                .ForeignKey("dbo.Resource", t => t.ResourceId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.Admission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                        FacultyId = c.Int(),
                        ProgramId = c.Int(),
                        AdmissionDate = c.DateTime(nullable: false),
                        GuardianInvolved = c.String(),
                        Relation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        IsScholarshipProvided = c.Boolean(nullable: false),
                        TotalAmountAfterScholarship = c.Double(),
                        AcademicYearId = c.Int(nullable: false),
                        SessionId = c.Int(),
                        MonthId = c.Byte(),
                        BilledDate = c.DateTime(nullable: false),
                        IsReceived = c.Boolean(nullable: false),
                        ReceivedDate = c.DateTime(nullable: false),
                        Scholarship_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Scholarship", t => t.Scholarship_Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.Scholarship_Id)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Scholarship",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        ScholarshipPercent = c.Single(nullable: false),
                        ProvidedDate = c.DateTime(nullable: false),
                        EndingDate = c.DateTime(),
                        AcademicYearId = c.Int(nullable: false),
                        SessionId = c.Int(),
                        InitialFee = c.Double(nullable: false),
                        FinalFee = c.Double(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        RequiresPassword = c.Boolean(nullable: false),
                        Password = c.String(),
                        DisplayName = c.String(),
                        FileName = c.String(),
                        FileDirectory = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentGroupResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentGroupId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                        SenderId = c.Int(nullable: false),
                        SentDate = c.DateTime(nullable: false),
                        Topic = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentGroup", t => t.StudentGroupId)
                .ForeignKey("dbo.Resource", t => t.ResourceId)
                .ForeignKey("dbo.Teacher", t => t.SenderId)
                .Index(t => t.StudentGroupId)
                .Index(t => t.ResourceId)
                .Index(t => t.SenderId);
            
            CreateTable(
                "dbo.StudentNotification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        NotificationType = c.Byte(nullable: false),
                        IsGroupNotification = c.Boolean(nullable: false),
                        NotificationId = c.Int(nullable: false),
                        Seen = c.Boolean(nullable: false),
                        SeenDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentPreviousStudies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        InstitutionName = c.String(),
                        InstitutionAddress = c.String(),
                        University = c.String(),
                        Qualificaiton = c.String(),
                        IsGradingSystem = c.Boolean(nullable: false),
                        Percent = c.Single(),
                        CertificateIssueYear = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentTransfer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        TransferTypeId = c.Byte(nullable: false),
                        TransferReason = c.String(),
                        TransferredTo = c.String(),
                        TransferredFrom = c.String(),
                        TransferAuthenticatedBy = c.Int(nullable: false),
                        GuardianName = c.String(),
                        GuardianMobileNo = c.String(),
                        Relation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentTransferType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FromInsideType = c.String(),
                        ToInsideType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        AssignedDate = c.DateTime(nullable: false),
                        AcademicYearId = c.Int(nullable: false),
                        SessionId = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        AppointedDate = c.DateTime(nullable: false),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.TeacherExperience",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        ExperienceYears = c.Byte(nullable: false),
                        ExperienceMonths = c.Byte(nullable: false),
                        ExperienceCompanyName = c.String(),
                        ExperienceCompanyAddress = c.String(),
                        ExperienceCompanyEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherNotification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        NotificationType = c.Byte(nullable: false),
                        NotificationId = c.Int(nullable: false),
                        Seen = c.Boolean(nullable: false),
                        SeenDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.TeacherQualification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        Degree = c.String(),
                        FieldOfStudy = c.String(),
                        UniversityName = c.String(),
                        Country = c.String(),
                        CompletionYear = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Award",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstitutionId = c.Int(nullable: false),
                        By = c.String(),
                        To = c.String(),
                        For = c.String(),
                        ReceivedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Institution", t => t.InstitutionId)
                .Index(t => t.InstitutionId);
            
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        PostalCode = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        InstitutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Institution", t => t.InstitutionId)
                .Index(t => t.InstitutionId);
            
            CreateTable(
                "dbo.Relation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsGuardian = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RelationShip",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RelationId = c.Int(nullable: false),
                        User1 = c.Int(nullable: false),
                        User2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Relation", t => t.RelationId)
                .Index(t => t.RelationId);
            
            CreateTable(
                "dbo.UserTransfer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransferDate = c.DateTime(nullable: false),
                        TransferReason = c.String(),
                        MyProperty = c.String(),
                        ApprovedById = c.Int(nullable: false),
                        FromSchoolId = c.Int(nullable: false),
                        ToSchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ApprovedById)
                .ForeignKey("dbo.School", t => t.FromSchoolId)
                .ForeignKey("dbo.School", t => t.ToSchoolId)
                .Index(t => t.ApprovedById)
                .Index(t => t.FromSchoolId)
                .Index(t => t.ToSchoolId);
            
            CreateTable(
                "dbo.UserAssociation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        InstitutionId = c.Int(nullable: false),
                        BranchId = c.Int(),
                        SchoolId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Institution", t => t.InstitutionId)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.UserId)
                .Index(t => t.InstitutionId)
                .Index(t => t.BranchId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.UserType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        InstitutionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLastLogin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AccessedFrom = c.String(),
                        LastLoginDate = c.DateTime(nullable: false),
                        LastLogoutTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Nation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Nationality = c.String(),
                        NationShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModuleAccessPermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Read = c.Boolean(nullable: false),
                        ReadWrite = c.Boolean(nullable: false),
                        Write = c.Boolean(nullable: false),
                        Append = c.Boolean(nullable: false),
                        IsGlobal = c.Boolean(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        IsPrivate = c.Boolean(nullable: false),
                        IsAssignable = c.Boolean(nullable: false),
                        IsSearchable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModuleAccess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ModuleAccessPermissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModuleAccessPermission", t => t.ModuleAccessPermissionId)
                .Index(t => t.ModuleAccessPermissionId);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                        Priority = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bytes = c.Binary(),
                        Extension = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResourceFileResource",
                c => new
                    {
                        ResourceFile_Id = c.Int(nullable: false),
                        Resource_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResourceFile_Id, t.Resource_Id })
                .ForeignKey("dbo.ResourceFile", t => t.ResourceFile_Id, cascadeDelete: true)
                .ForeignKey("dbo.Resource", t => t.Resource_Id, cascadeDelete: true)
                .Index(t => t.ResourceFile_Id)
                .Index(t => t.Resource_Id);
            
            CreateTable(
                "dbo.ResourceAssignment",
                c => new
                    {
                        Resource_Id = c.Int(nullable: false),
                        Assignment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Resource_Id, t.Assignment_Id })
                .ForeignKey("dbo.Resource", t => t.Resource_Id, cascadeDelete: true)
                .ForeignKey("dbo.Assignment", t => t.Assignment_Id, cascadeDelete: true)
                .Index(t => t.Resource_Id)
                .Index(t => t.Assignment_Id);
            
            CreateTable(
                "dbo.ModuleModuleAccess",
                c => new
                    {
                        Module_Id = c.Int(nullable: false),
                        ModuleAccess_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Module_Id, t.ModuleAccess_Id })
                .ForeignKey("dbo.Module", t => t.Module_Id, cascadeDelete: true)
                .ForeignKey("dbo.ModuleAccess", t => t.ModuleAccess_Id, cascadeDelete: true)
                .Index(t => t.Module_Id)
                .Index(t => t.ModuleAccess_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ModuleModuleAccess", new[] { "ModuleAccess_Id" });
            DropIndex("dbo.ModuleModuleAccess", new[] { "Module_Id" });
            DropIndex("dbo.ResourceAssignment", new[] { "Assignment_Id" });
            DropIndex("dbo.ResourceAssignment", new[] { "Resource_Id" });
            DropIndex("dbo.ResourceFileResource", new[] { "Resource_Id" });
            DropIndex("dbo.ResourceFileResource", new[] { "ResourceFile_Id" });
            DropIndex("dbo.ModuleAccess", new[] { "ModuleAccessPermissionId" });
            DropIndex("dbo.UserLastLogin", new[] { "UserId" });
            DropIndex("dbo.UserAssociation", new[] { "SchoolId" });
            DropIndex("dbo.UserAssociation", new[] { "BranchId" });
            DropIndex("dbo.UserAssociation", new[] { "InstitutionId" });
            DropIndex("dbo.UserAssociation", new[] { "UserId" });
            DropIndex("dbo.UserTransfer", new[] { "ToSchoolId" });
            DropIndex("dbo.UserTransfer", new[] { "FromSchoolId" });
            DropIndex("dbo.UserTransfer", new[] { "ApprovedById" });
            DropIndex("dbo.RelationShip", new[] { "RelationId" });
            DropIndex("dbo.Branch", new[] { "InstitutionId" });
            DropIndex("dbo.Award", new[] { "InstitutionId" });
            DropIndex("dbo.TeacherQualification", new[] { "TeacherId" });
            DropIndex("dbo.TeacherNotification", new[] { "TeacherId" });
            DropIndex("dbo.Appointment", new[] { "TeacherId" });
            DropIndex("dbo.StudentPreviousStudies", new[] { "StudentId" });
            DropIndex("dbo.StudentNotification", new[] { "StudentId" });
            DropIndex("dbo.StudentGroupResource", new[] { "SenderId" });
            DropIndex("dbo.StudentGroupResource", new[] { "ResourceId" });
            DropIndex("dbo.StudentGroupResource", new[] { "StudentGroupId" });
            DropIndex("dbo.StudentFile", new[] { "StudentId" });
            DropIndex("dbo.Fee", new[] { "StudentId" });
            DropIndex("dbo.Fee", new[] { "Scholarship_Id" });
            DropIndex("dbo.TeacherResourceShare", new[] { "ResourceId" });
            DropIndex("dbo.TeacherResourceShare", new[] { "ReceiverId" });
            DropIndex("dbo.TeacherResourceShare", new[] { "SenderId" });
            DropIndex("dbo.StudentResourceShare", new[] { "ResourceId" });
            DropIndex("dbo.StudentResourceShare", new[] { "ReceiverId" });
            DropIndex("dbo.StudentGroupResourceShare", new[] { "ResourceId" });
            DropIndex("dbo.StudentGroupResourceShare", new[] { "ReceiverId" });
            DropIndex("dbo.StudentGroupResourceShare", new[] { "SenderId" });
            DropIndex("dbo.ExamMarks", new[] { "StudentId" });
            DropIndex("dbo.ExamMarks", new[] { "SubjectExamId" });
            DropIndex("dbo.AssignmentMarks", new[] { "GradeId" });
            DropIndex("dbo.AssignmentMarks", new[] { "StudentId" });
            DropIndex("dbo.AssignmentMarks", new[] { "AssignedTaskId" });
            DropIndex("dbo.Return", new[] { "issueId" });
            DropIndex("dbo.MemberShip", new[] { "MembershipTypeId" });
            DropIndex("dbo.Issue", new[] { "StudentId" });
            DropIndex("dbo.Issue", new[] { "BookId" });
            DropIndex("dbo.BookAuthor", new[] { "BookId" });
            DropIndex("dbo.BookReturnCategory", new[] { "LibraryId" });
            DropIndex("dbo.BookCategory", new[] { "Book_Id" });
            DropIndex("dbo.BookCategory", new[] { "LibraryId" });
            DropIndex("dbo.Book", new[] { "LibraryId" });
            DropIndex("dbo.Book", new[] { "BookReturnCategoryId" });
            DropIndex("dbo.Book", new[] { "BookCategoryId" });
            DropIndex("dbo.Book", new[] { "BookCategory_Id" });
            DropIndex("dbo.Book", new[] { "SubjectId" });
            DropIndex("dbo.AttendanceDay", new[] { "TeachId" });
            DropIndex("dbo.Attendance", new[] { "AttendanceDayId" });
            DropIndex("dbo.Attendance", new[] { "PresenceStatusId" });
            DropIndex("dbo.Attendance", new[] { "StudentId" });
            DropIndex("dbo.Task", new[] { "AssignmentId" });
            DropIndex("dbo.AssignmentAnswerFile", new[] { "AssignmentAnswerId" });
            DropIndex("dbo.AssignmentAnswer", new[] { "StudentId" });
            DropIndex("dbo.AssignmentAnswer", new[] { "AssignmentId" });
            DropIndex("dbo.Links", new[] { "ResourceId" });
            DropIndex("dbo.ResourceFile", new[] { "OwnerId" });
            DropIndex("dbo.Resource", new[] { "StudentFile_Id" });
            DropIndex("dbo.Assignment", new[] { "SubjectId" });
            DropIndex("dbo.AssignedTask", new[] { "SessionId" });
            DropIndex("dbo.AssignedTask", new[] { "AssignmentId" });
            DropIndex("dbo.AssignedTask", new[] { "TeachId" });
            DropIndex("dbo.StudentsOpinionAboutSubject", new[] { "SubjectSubscriptionId" });
            DropIndex("dbo.SubjectSubscription", new[] { "SubjectClassId" });
            DropIndex("dbo.SubjectSubscription", new[] { "StudentClassId" });
            DropIndex("dbo.SessionAdmins", new[] { "SessionId" });
            DropIndex("dbo.SessionAdmins", new[] { "TitleId" });
            DropIndex("dbo.OtherAdmins", new[] { "AdminsId" });
            DropIndex("dbo.Admins", new[] { "AcademicYearId" });
            DropIndex("dbo.TeacherClass", new[] { "SubjectClassId" });
            DropIndex("dbo.TeacherClass", new[] { "TeacherId" });
            DropIndex("dbo.ExamSubjectTeacher", new[] { "TeacherClassId" });
            DropIndex("dbo.ExamSubjectTeacher", new[] { "ExamSubjectId" });
            DropIndex("dbo.Study", new[] { "SessionId" });
            DropIndex("dbo.Study", new[] { "AcademicYearId" });
            DropIndex("dbo.Study", new[] { "SectionId" });
            DropIndex("dbo.Study", new[] { "YearId" });
            DropIndex("dbo.Study", new[] { "StudentGroupId" });
            DropIndex("dbo.StudentGroup", new[] { "SchoolId" });
            DropIndex("dbo.StudentGroup", new[] { "ParentId" });
            DropIndex("dbo.StudentGroupStudent", new[] { "StudentGroupId" });
            DropIndex("dbo.StudentGroupStudent", new[] { "StudentId" });
            DropIndex("dbo.Student", new[] { "UserId" });
            DropIndex("dbo.StudentClass", new[] { "RunningClassId" });
            DropIndex("dbo.StudentClass", new[] { "StudentGroupId" });
            DropIndex("dbo.StudentClass", new[] { "StudentId" });
            DropIndex("dbo.ExamStudent", new[] { "PostedById" });
            DropIndex("dbo.ExamStudent", new[] { "StudentClassId" });
            DropIndex("dbo.ExamStudent", new[] { "ExamSubjectId" });
            DropIndex("dbo.ExamSubType", new[] { "SchoolId" });
            DropIndex("dbo.RunningClass", new[] { "SubYearId" });
            DropIndex("dbo.RunningClass", new[] { "YearId" });
            DropIndex("dbo.RunningClass", new[] { "SessionId" });
            DropIndex("dbo.RunningClass", new[] { "AcademicYearId" });
            DropIndex("dbo.SubjectActivityAndResource", new[] { "SubjectSectionId" });
            DropIndex("dbo.Restriction", new[] { "SubjectSection_Id" });
            DropIndex("dbo.Restriction", new[] { "SubjectId" });
            DropIndex("dbo.SubjectSection", new[] { "SubjectId" });
            DropIndex("dbo.Institution", new[] { "UserId" });
            DropIndex("dbo.TeacherJobTitle", new[] { "InstitutionId" });
            DropIndex("dbo.Teacher", new[] { "TeacherJobTitleId" });
            DropIndex("dbo.Teacher", new[] { "UserId" });
            DropIndex("dbo.Session", new[] { "AcademicYearId" });
            DropIndex("dbo.Session", new[] { "ParentId" });
            DropIndex("dbo.Teach", new[] { "SubjectId" });
            DropIndex("dbo.Teach", new[] { "TeacherId" });
            DropIndex("dbo.Teach", new[] { "SessionId" });
            DropIndex("dbo.Teach", new[] { "AcademicYearId" });
            DropIndex("dbo.SubYear", new[] { "YearId" });
            DropIndex("dbo.SubYear", new[] { "ParentId" });
            DropIndex("dbo.Year", new[] { "ProgramId" });
            DropIndex("dbo.Program", new[] { "FacultyId" });
            DropIndex("dbo.Faculty", new[] { "LevelId" });
            DropIndex("dbo.Level", new[] { "SchoolId" });
            DropIndex("dbo.SubjectGroup", new[] { "SchoolId" });
            DropIndex("dbo.SubjectGroup", new[] { "ProgramId" });
            DropIndex("dbo.SubjectGroup", new[] { "FacultyId" });
            DropIndex("dbo.SubjectGroup", new[] { "LevelId" });
            DropIndex("dbo.SubjectGroup", new[] { "YearId" });
            DropIndex("dbo.SubjectGroupSubject", new[] { "SubjectGroupId" });
            DropIndex("dbo.SubjectGroupSubject", new[] { "SubjectId" });
            DropIndex("dbo.SubjectCategory", new[] { "SchoolId" });
            DropIndex("dbo.Subject", new[] { "SubjectCategoryId" });
            DropIndex("dbo.SubjectClass", new[] { "RunningClassId" });
            DropIndex("dbo.SubjectClass", new[] { "SubjectGroupId" });
            DropIndex("dbo.SubjectClass", new[] { "SubjectId" });
            DropIndex("dbo.ExamSubject", new[] { "ExamSubTypeId" });
            DropIndex("dbo.ExamSubject", new[] { "ExamId" });
            DropIndex("dbo.ExamSubject", new[] { "SubjectClassId" });
            DropIndex("dbo.RoleCapability", new[] { "CapabilityId" });
            DropIndex("dbo.RoleCapability", new[] { "RoleId" });
            DropIndex("dbo.Role", new[] { "SchoolId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Division", new[] { "ParentDivisionId" });
            DropIndex("dbo.Division", new[] { "SchoolId" });
            DropIndex("dbo.UserDivision", new[] { "DivisionId" });
            DropIndex("dbo.UserDivision", new[] { "UsersId" });
            DropIndex("dbo.Users", new[] { "SchoolId" });
            DropIndex("dbo.Users", new[] { "GenderId" });
            DropIndex("dbo.School", new[] { "SchoolTypeId" });
            DropIndex("dbo.ExamType", new[] { "SchoolId" });
            DropIndex("dbo.Exam", new[] { "ExamCoordinatorId" });
            DropIndex("dbo.Exam", new[] { "AcademicYearId" });
            DropIndex("dbo.Exam", new[] { "SchoolId" });
            DropIndex("dbo.Exam", new[] { "ExamTypeId" });
            DropForeignKey("dbo.ModuleModuleAccess", "ModuleAccess_Id", "dbo.ModuleAccess");
            DropForeignKey("dbo.ModuleModuleAccess", "Module_Id", "dbo.Module");
            DropForeignKey("dbo.ResourceAssignment", "Assignment_Id", "dbo.Assignment");
            DropForeignKey("dbo.ResourceAssignment", "Resource_Id", "dbo.Resource");
            DropForeignKey("dbo.ResourceFileResource", "Resource_Id", "dbo.Resource");
            DropForeignKey("dbo.ResourceFileResource", "ResourceFile_Id", "dbo.ResourceFile");
            DropForeignKey("dbo.ModuleAccess", "ModuleAccessPermissionId", "dbo.ModuleAccessPermission");
            DropForeignKey("dbo.UserLastLogin", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAssociation", "SchoolId", "dbo.School");
            DropForeignKey("dbo.UserAssociation", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.UserAssociation", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.UserAssociation", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserTransfer", "ToSchoolId", "dbo.School");
            DropForeignKey("dbo.UserTransfer", "FromSchoolId", "dbo.School");
            DropForeignKey("dbo.UserTransfer", "ApprovedById", "dbo.Users");
            DropForeignKey("dbo.RelationShip", "RelationId", "dbo.Relation");
            DropForeignKey("dbo.Branch", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.Award", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.TeacherQualification", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.TeacherNotification", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Appointment", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.StudentPreviousStudies", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentNotification", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentGroupResource", "SenderId", "dbo.Teacher");
            DropForeignKey("dbo.StudentGroupResource", "ResourceId", "dbo.Resource");
            DropForeignKey("dbo.StudentGroupResource", "StudentGroupId", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentFile", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Fee", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Fee", "Scholarship_Id", "dbo.Scholarship");
            DropForeignKey("dbo.TeacherResourceShare", "ResourceId", "dbo.Resource");
            DropForeignKey("dbo.TeacherResourceShare", "ReceiverId", "dbo.Teacher");
            DropForeignKey("dbo.TeacherResourceShare", "SenderId", "dbo.Teacher");
            DropForeignKey("dbo.StudentResourceShare", "ResourceId", "dbo.Resource");
            DropForeignKey("dbo.StudentResourceShare", "ReceiverId", "dbo.Student");
            DropForeignKey("dbo.StudentGroupResourceShare", "ResourceId", "dbo.Resource");
            DropForeignKey("dbo.StudentGroupResourceShare", "ReceiverId", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentGroupResourceShare", "SenderId", "dbo.Teacher");
            DropForeignKey("dbo.ExamMarks", "StudentId", "dbo.Student");
            DropForeignKey("dbo.ExamMarks", "SubjectExamId", "dbo.ExamSubject");
            DropForeignKey("dbo.AssignmentMarks", "GradeId", "dbo.Grade");
            DropForeignKey("dbo.AssignmentMarks", "StudentId", "dbo.Student");
            DropForeignKey("dbo.AssignmentMarks", "AssignedTaskId", "dbo.AssignedTask");
            DropForeignKey("dbo.Return", "issueId", "dbo.Issue");
            DropForeignKey("dbo.MemberShip", "MembershipTypeId", "dbo.MembershipType");
            DropForeignKey("dbo.Issue", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Issue", "BookId", "dbo.Book");
            DropForeignKey("dbo.BookAuthor", "BookId", "dbo.Book");
            DropForeignKey("dbo.BookReturnCategory", "LibraryId", "dbo.Library");
            DropForeignKey("dbo.BookCategory", "Book_Id", "dbo.Book");
            DropForeignKey("dbo.BookCategory", "LibraryId", "dbo.Library");
            DropForeignKey("dbo.Book", "LibraryId", "dbo.Library");
            DropForeignKey("dbo.Book", "BookReturnCategoryId", "dbo.BookReturnCategory");
            DropForeignKey("dbo.Book", "BookCategoryId", "dbo.BookCategory");
            DropForeignKey("dbo.Book", "BookCategory_Id", "dbo.BookCategory");
            DropForeignKey("dbo.Book", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.AttendanceDay", "TeachId", "dbo.Teach");
            DropForeignKey("dbo.Attendance", "AttendanceDayId", "dbo.AttendanceDay");
            DropForeignKey("dbo.Attendance", "PresenceStatusId", "dbo.PresenceStatus");
            DropForeignKey("dbo.Attendance", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Task", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.AssignmentAnswerFile", "AssignmentAnswerId", "dbo.AssignmentAnswer");
            DropForeignKey("dbo.AssignmentAnswer", "StudentId", "dbo.Student");
            DropForeignKey("dbo.AssignmentAnswer", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.Links", "ResourceId", "dbo.Resource");
            DropForeignKey("dbo.ResourceFile", "OwnerId", "dbo.Teacher");
            DropForeignKey("dbo.Resource", "StudentFile_Id", "dbo.StudentFile");
            DropForeignKey("dbo.Assignment", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.AssignedTask", "SessionId", "dbo.Session");
            DropForeignKey("dbo.AssignedTask", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.AssignedTask", "TeachId", "dbo.Teach");
            DropForeignKey("dbo.StudentsOpinionAboutSubject", "SubjectSubscriptionId", "dbo.SubjectSubscription");
            DropForeignKey("dbo.SubjectSubscription", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.SubjectSubscription", "StudentClassId", "dbo.StudentClass");
            DropForeignKey("dbo.SessionAdmins", "SessionId", "dbo.Session");
            DropForeignKey("dbo.SessionAdmins", "TitleId", "dbo.AdminTitle");
            DropForeignKey("dbo.OtherAdmins", "AdminsId", "dbo.Admins");
            DropForeignKey("dbo.Admins", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.TeacherClass", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.TeacherClass", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.ExamSubjectTeacher", "TeacherClassId", "dbo.TeacherClass");
            DropForeignKey("dbo.ExamSubjectTeacher", "ExamSubjectId", "dbo.ExamSubject");
            DropForeignKey("dbo.Study", "SessionId", "dbo.Session");
            DropForeignKey("dbo.Study", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.Study", "SectionId", "dbo.SubYear");
            DropForeignKey("dbo.Study", "YearId", "dbo.Year");
            DropForeignKey("dbo.Study", "StudentGroupId", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentGroup", "SchoolId", "dbo.School");
            DropForeignKey("dbo.StudentGroup", "ParentId", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentGroupStudent", "StudentGroupId", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentGroupStudent", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "UserId", "dbo.Users");
            DropForeignKey("dbo.StudentClass", "RunningClassId", "dbo.RunningClass");
            DropForeignKey("dbo.StudentClass", "StudentGroupId", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentClass", "StudentId", "dbo.Student");
            DropForeignKey("dbo.ExamStudent", "PostedById", "dbo.Users");
            DropForeignKey("dbo.ExamStudent", "StudentClassId", "dbo.StudentClass");
            DropForeignKey("dbo.ExamStudent", "ExamSubjectId", "dbo.ExamSubject");
            DropForeignKey("dbo.ExamSubType", "SchoolId", "dbo.School");
            DropForeignKey("dbo.RunningClass", "SubYearId", "dbo.SubYear");
            DropForeignKey("dbo.RunningClass", "YearId", "dbo.Year");
            DropForeignKey("dbo.RunningClass", "SessionId", "dbo.Session");
            DropForeignKey("dbo.RunningClass", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.SubjectActivityAndResource", "SubjectSectionId", "dbo.SubjectSection");
            DropForeignKey("dbo.Restriction", "SubjectSection_Id", "dbo.SubjectSection");
            DropForeignKey("dbo.Restriction", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectSection", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Institution", "UserId", "dbo.Users");
            DropForeignKey("dbo.TeacherJobTitle", "InstitutionId", "dbo.Institution");
            DropForeignKey("dbo.Teacher", "TeacherJobTitleId", "dbo.TeacherJobTitle");
            DropForeignKey("dbo.Teacher", "UserId", "dbo.Users");
            DropForeignKey("dbo.Session", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.Session", "ParentId", "dbo.Session");
            DropForeignKey("dbo.Teach", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Teach", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Teach", "SessionId", "dbo.Session");
            DropForeignKey("dbo.Teach", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.SubYear", "YearId", "dbo.Year");
            DropForeignKey("dbo.SubYear", "ParentId", "dbo.SubYear");
            DropForeignKey("dbo.Year", "ProgramId", "dbo.Program");
            DropForeignKey("dbo.Program", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.Faculty", "LevelId", "dbo.Level");
            DropForeignKey("dbo.Level", "SchoolId", "dbo.School");
            DropForeignKey("dbo.SubjectGroup", "SchoolId", "dbo.School");
            DropForeignKey("dbo.SubjectGroup", "ProgramId", "dbo.Program");
            DropForeignKey("dbo.SubjectGroup", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.SubjectGroup", "LevelId", "dbo.Level");
            DropForeignKey("dbo.SubjectGroup", "YearId", "dbo.Year");
            DropForeignKey("dbo.SubjectGroupSubject", "SubjectGroupId", "dbo.SubjectGroup");
            DropForeignKey("dbo.SubjectGroupSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectCategory", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Subject", "SubjectCategoryId", "dbo.SubjectCategory");
            DropForeignKey("dbo.SubjectClass", "RunningClassId", "dbo.RunningClass");
            DropForeignKey("dbo.SubjectClass", "SubjectGroupId", "dbo.SubjectGroup");
            DropForeignKey("dbo.SubjectClass", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.ExamSubject", "ExamSubTypeId", "dbo.ExamSubType");
            DropForeignKey("dbo.ExamSubject", "ExamId", "dbo.Exam");
            DropForeignKey("dbo.ExamSubject", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.RoleCapability", "CapabilityId", "dbo.Capability");
            DropForeignKey("dbo.RoleCapability", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Role", "SchoolId", "dbo.School");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.Users");
            DropForeignKey("dbo.Division", "ParentDivisionId", "dbo.Division");
            DropForeignKey("dbo.Division", "SchoolId", "dbo.School");
            DropForeignKey("dbo.UserDivision", "DivisionId", "dbo.Division");
            DropForeignKey("dbo.UserDivision", "UsersId", "dbo.Users");
            DropForeignKey("dbo.Users", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Users", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.School", "SchoolTypeId", "dbo.SchoolType");
            DropForeignKey("dbo.ExamType", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Exam", "ExamCoordinatorId", "dbo.Users");
            DropForeignKey("dbo.Exam", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.Exam", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Exam", "ExamTypeId", "dbo.ExamType");
            DropTable("dbo.ModuleModuleAccess");
            DropTable("dbo.ResourceAssignment");
            DropTable("dbo.ResourceFileResource");
            DropTable("dbo.UserImage");
            DropTable("dbo.Module");
            DropTable("dbo.ModuleAccess");
            DropTable("dbo.ModuleAccessPermission");
            DropTable("dbo.Nation");
            DropTable("dbo.UserLastLogin");
            DropTable("dbo.UserType");
            DropTable("dbo.UserAssociation");
            DropTable("dbo.UserTransfer");
            DropTable("dbo.RelationShip");
            DropTable("dbo.Relation");
            DropTable("dbo.Branch");
            DropTable("dbo.Award");
            DropTable("dbo.TeacherQualification");
            DropTable("dbo.TeacherNotification");
            DropTable("dbo.TeacherExperience");
            DropTable("dbo.Appointment");
            DropTable("dbo.StudentSubject");
            DropTable("dbo.StudentTransferType");
            DropTable("dbo.StudentTransfer");
            DropTable("dbo.StudentPreviousStudies");
            DropTable("dbo.StudentNotification");
            DropTable("dbo.StudentGroupResource");
            DropTable("dbo.StudentFile");
            DropTable("dbo.Scholarship");
            DropTable("dbo.Fee");
            DropTable("dbo.Admission");
            DropTable("dbo.TeacherResourceShare");
            DropTable("dbo.StudentResourceShare");
            DropTable("dbo.StudentGroupResourceShare");
            DropTable("dbo.Photo");
            DropTable("dbo.AccessPermission");
            DropTable("dbo.ExamMarks");
            DropTable("dbo.Grade");
            DropTable("dbo.AssignmentMarks");
            DropTable("dbo.UsefulnessCategory");
            DropTable("dbo.Return");
            DropTable("dbo.MembershipType");
            DropTable("dbo.MemberShip");
            DropTable("dbo.Issue");
            DropTable("dbo.BookAuthor");
            DropTable("dbo.BookReturnCategory");
            DropTable("dbo.Library");
            DropTable("dbo.BookCategory");
            DropTable("dbo.Book");
            DropTable("dbo.AttendanceDay");
            DropTable("dbo.PresenceStatus");
            DropTable("dbo.Attendance");
            DropTable("dbo.Task");
            DropTable("dbo.AssignmentAnswerFile");
            DropTable("dbo.AssignmentAnswer");
            DropTable("dbo.Links");
            DropTable("dbo.ResourceFile");
            DropTable("dbo.Resource");
            DropTable("dbo.Assignment");
            DropTable("dbo.AssignedTask");
            DropTable("dbo.StudentsOpinionAboutSubject");
            DropTable("dbo.SubjectSubscription");
            DropTable("dbo.FileCategory");
            DropTable("dbo.SessionAdmins");
            DropTable("dbo.OtherAdmins");
            DropTable("dbo.AdminTitle");
            DropTable("dbo.Admins");
            DropTable("dbo.TeacherClass");
            DropTable("dbo.ExamSubjectTeacher");
            DropTable("dbo.Study");
            DropTable("dbo.StudentGroup");
            DropTable("dbo.StudentGroupStudent");
            DropTable("dbo.Student");
            DropTable("dbo.StudentClass");
            DropTable("dbo.ExamStudent");
            DropTable("dbo.ExamSubType");
            DropTable("dbo.RunningClass");
            DropTable("dbo.SubjectActivityAndResource");
            DropTable("dbo.Restriction");
            DropTable("dbo.SubjectSection");
            DropTable("dbo.Institution");
            DropTable("dbo.TeacherJobTitle");
            DropTable("dbo.Teacher");
            DropTable("dbo.Session");
            DropTable("dbo.Teach");
            DropTable("dbo.SubYear");
            DropTable("dbo.Year");
            DropTable("dbo.Program");
            DropTable("dbo.Faculty");
            DropTable("dbo.Level");
            DropTable("dbo.SubjectGroup");
            DropTable("dbo.SubjectGroupSubject");
            DropTable("dbo.SubjectCategory");
            DropTable("dbo.Subject");
            DropTable("dbo.SubjectClass");
            DropTable("dbo.ExamSubject");
            DropTable("dbo.Capability");
            DropTable("dbo.RoleCapability");
            DropTable("dbo.Role");
            DropTable("dbo.UserRole");
            DropTable("dbo.Division");
            DropTable("dbo.UserDivision");
            DropTable("dbo.Gender");
            DropTable("dbo.Users");
            DropTable("dbo.SchoolType");
            DropTable("dbo.School");
            DropTable("dbo.ExamType");
            DropTable("dbo.Exam");
            DropTable("dbo.AcademicYear");
        }
    }
}
