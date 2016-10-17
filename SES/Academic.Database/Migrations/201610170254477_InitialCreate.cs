namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicYear",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RemindWhenEndDate = c.Boolean(),
                        IsActive = c.Boolean(nullable: false),
                        Completed = c.Boolean(),
                        SchoolId = c.Int(nullable: false),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.Int(nullable: false),
                        ParentId = c.Int(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Completed = c.Boolean(),
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
                "dbo.Exam",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamTypeId = c.Int(),
                        Name = c.String(),
                        NoticeContent = c.String(),
                        IsPercent = c.Boolean(),
                        Weight = c.Single(),
                        StartDate = c.DateTime(),
                        UpdatedDate = c.DateTime(),
                        ResultDate = c.DateTime(),
                        Void = c.Boolean(),
                        SchoolId = c.Int(nullable: false),
                        AcademicYearId = c.Int(nullable: false),
                        SessionId = c.Int(),
                        ExamCoordinatorId = c.Int(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        PublishNoticeToNoticeBoard = c.Boolean(),
                        NoticeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamType", t => t.ExamTypeId)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .ForeignKey("dbo.AcademicYear", t => t.AcademicYearId)
                .ForeignKey("dbo.Session", t => t.SessionId)
                .ForeignKey("dbo.Users", t => t.ExamCoordinatorId)
                .ForeignKey("dbo.Notice", t => t.NoticeId)
                .Index(t => t.ExamTypeId)
                .Index(t => t.SchoolId)
                .Index(t => t.AcademicYearId)
                .Index(t => t.SessionId)
                .Index(t => t.ExamCoordinatorId)
                .Index(t => t.NoticeId);
            
            CreateTable(
                "dbo.ExamType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsPercent = c.Boolean(nullable: false),
                        Weight = c.Single(),
                        FullMarks = c.Int(),
                        PassMarks = c.Int(),
                        Void = c.Boolean(),
                        SchoolId = c.Int(nullable: false),
                        Notice = c.String(),
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
                        ImageId = c.Int(nullable: false),
                        SchoolTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserFile", t => t.ImageId)
                .ForeignKey("dbo.SchoolType", t => t.SchoolTypeId)
                .Index(t => t.ImageId)
                .Index(t => t.SchoolTypeId);
            
            CreateTable(
                "dbo.UserFile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(),
                        FileName = c.String(),
                        FileDirectory = c.String(),
                        FileSizeInBytes = c.Long(nullable: false),
                        FileType = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(),
                        Void = c.Boolean(),
                        IconPath = c.String(),
                        SubjectId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
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
                        NoOfSubjects = c.Int(nullable: false),
                        Desctiption = c.String(),
                        ProgramId = c.Int(),
                        YearId = c.Int(),
                        SubYearId = c.Int(),
                        Void = c.Boolean(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Year", t => t.YearId)
                .ForeignKey("dbo.Program", t => t.ProgramId)
                .ForeignKey("dbo.SubYear", t => t.SubYearId)
                .Index(t => t.YearId)
                .Index(t => t.ProgramId)
                .Index(t => t.SubYearId);
            
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
                "dbo.ProgramBatch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        CurrentYearId = c.Int(),
                        CurrentSubYearId = c.Int(),
                        StartedStudying = c.Boolean(),
                        StudyCompleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batch", t => t.BatchId)
                .ForeignKey("dbo.Program", t => t.ProgramId)
                .ForeignKey("dbo.Year", t => t.CurrentYearId)
                .ForeignKey("dbo.SubYear", t => t.CurrentSubYearId)
                .Index(t => t.BatchId)
                .Index(t => t.ProgramId)
                .Index(t => t.CurrentYearId)
                .Index(t => t.CurrentSubYearId);
            
            CreateTable(
                "dbo.Batch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ClassCommenceDate = c.DateTime(),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
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
                        SchoolId = c.Int(),
                        UserImageId = c.Int(),
                        CreatedDate = c.DateTime(),
                        LastOnline = c.DateTime(),
                        SecurityQuestion = c.String(),
                        SecurityAnswer = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gender", t => t.GenderId)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .ForeignKey("dbo.UserFile", t => t.UserImageId)
                .Index(t => t.GenderId)
                .Index(t => t.SchoolId)
                .Index(t => t.UserImageId);
            
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
                        DisplayName = c.String(nullable: false),
                        RoleName = c.String(nullable: false),
                        SchoolId = c.Int(),
                        Description = c.String(),
                        Void = c.Boolean(),
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
                "dbo.UserClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectClassId = c.Int(nullable: false),
                        UserId = c.Int(),
                        RoleId = c.Int(),
                        Void = c.Boolean(),
                        CreatedDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        EnrollmentDuration = c.Int(nullable: false),
                        Suspended = c.Boolean(),
                        SubjectUserGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .ForeignKey("dbo.SubjectUserGroup", t => t.SubjectUserGroupId)
                .Index(t => t.SubjectClassId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.SubjectUserGroupId);
            
            CreateTable(
                "dbo.SubjectClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsRegular = c.Boolean(nullable: false),
                        RunningClassId = c.Int(),
                        SubjectStructureId = c.Int(),
                        SubjectId = c.Int(),
                        Name = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        HasGrouping = c.Boolean(nullable: false),
                        UseDefaultGrouping = c.Boolean(),
                        Void = c.Boolean(),
                        VoidBy = c.Int(),
                        VoidDate = c.DateTime(),
                        SessionComplete = c.Boolean(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedTime = c.String(),
                        CreatedBy = c.Int(),
                        CompletionMarkedDate = c.DateTime(),
                        CompleteMarkedByUserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RunningClass", t => t.RunningClassId)
                .ForeignKey("dbo.SubjectStructure", t => t.SubjectStructureId)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.RunningClassId)
                .Index(t => t.SubjectStructureId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.RunningClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcademicYearId = c.Int(nullable: false),
                        SessionId = c.Int(),
                        YearId = c.Int(nullable: false),
                        SubYearId = c.Int(),
                        ProgramBatchId = c.Int(),
                        Void = c.Boolean(),
                        IsActive = c.Boolean(),
                        Completed = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicYear", t => t.AcademicYearId)
                .ForeignKey("dbo.Session", t => t.SessionId)
                .ForeignKey("dbo.Year", t => t.YearId)
                .ForeignKey("dbo.SubYear", t => t.SubYearId)
                .ForeignKey("dbo.ProgramBatch", t => t.ProgramBatchId)
                .Index(t => t.AcademicYearId)
                .Index(t => t.SessionId)
                .Index(t => t.YearId)
                .Index(t => t.SubYearId)
                .Index(t => t.ProgramBatchId);
            
            CreateTable(
                "dbo.SubjectStructure",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YearId = c.Int(nullable: false),
                        SubYearId = c.Int(),
                        SubjectId = c.Int(nullable: false),
                        Obsolete = c.Boolean(),
                        Void = c.Boolean(),
                        CreatedBy = c.Int(nullable: false),
                        VoidBy = c.Int(),
                        UpdatedBy = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        VoidDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        RemovedInAcademicYearId = c.Int(),
                        LastActiveInAcademicYearId = c.Int(),
                        WillNotBeActiveFromAcademicYearId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Year", t => t.YearId)
                .ForeignKey("dbo.SubYear", t => t.SubYearId)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.AcademicYear", t => t.RemovedInAcademicYearId)
                .ForeignKey("dbo.AcademicYear", t => t.LastActiveInAcademicYearId)
                .ForeignKey("dbo.AcademicYear", t => t.WillNotBeActiveFromAcademicYearId)
                .Index(t => t.YearId)
                .Index(t => t.SubYearId)
                .Index(t => t.SubjectId)
                .Index(t => t.RemovedInAcademicYearId)
                .Index(t => t.LastActiveInAcademicYearId)
                .Index(t => t.WillNotBeActiveFromAcademicYearId);
            
            CreateTable(
                "dbo.SubjectUserGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.TeacherJobTitle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        InstitutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectSection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Summary = c.String(),
                        ShowSummary = c.Boolean(),
                        Position = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.SchoolType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExamOfClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        RunningClassId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exam", t => t.ExamId)
                .ForeignKey("dbo.RunningClass", t => t.RunningClassId)
                .Index(t => t.ExamId)
                .Index(t => t.RunningClassId);
            
            CreateTable(
                "dbo.Notice",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        UpdatedBy = c.Int(),
                        UpdatedDate = c.DateTime(),
                        NoticePublishTo = c.Boolean(),
                        Void = c.Boolean(),
                        PublishNoticeToNoticeBoard = c.Boolean(nullable: false),
                        PublishedDate = c.DateTime(),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Event",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Location = c.String(),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(),
                        Latitude = c.Single(),
                        Longitude = c.Single(),
                        Description = c.String(),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GradeType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Type = c.String(),
                        GradeValueIsInPercentOrPostition = c.Boolean(),
                        TotalMaxValue = c.Single(),
                        TotalMinValue = c.Single(),
                        MinimumPassValue = c.Single(),
                        SchoolId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.GradeValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        IsFailGrade = c.Boolean(),
                        GradeTypeId = c.Int(nullable: false),
                        EquivalentPercentOrPostition = c.Single(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GradeType", t => t.GradeTypeId)
                .Index(t => t.GradeTypeId);
            
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
                        BatchAssigned = c.Boolean(),
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
                        StartedStudying = c.Boolean(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsFromBatch = c.Boolean(),
                        ProgramBatchId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentGroup", t => t.ParentId)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .ForeignKey("dbo.ProgramBatch", t => t.ProgramBatchId)
                .Index(t => t.ParentId)
                .Index(t => t.SchoolId)
                .Index(t => t.ProgramBatchId);
            
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
                "dbo.ExamStudent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamSubjectId = c.Int(nullable: false),
                        UserClassId = c.Int(nullable: false),
                        IsGrade = c.Boolean(),
                        ObtainedGradeId = c.Int(),
                        IsPercent = c.Boolean(),
                        ObtainedMarks = c.Single(),
                        PostedDate = c.DateTime(),
                        PostedById = c.Int(),
                        Void = c.Boolean(),
                        StudentClass_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamSubject", t => t.ExamSubjectId)
                .ForeignKey("dbo.UserClass", t => t.UserClassId)
                .ForeignKey("dbo.Grade", t => t.ObtainedGradeId)
                .ForeignKey("dbo.Users", t => t.PostedById)
                .ForeignKey("dbo.StudentClass", t => t.StudentClass_Id)
                .Index(t => t.ExamSubjectId)
                .Index(t => t.UserClassId)
                .Index(t => t.ObtainedGradeId)
                .Index(t => t.PostedById)
                .Index(t => t.StudentClass_Id);
            
            CreateTable(
                "dbo.ExamSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectClassId = c.Int(nullable: false),
                        ExamOfClassId = c.Int(nullable: false),
                        SettingsUsedFromExam = c.Boolean(nullable: false),
                        IsPercent = c.Boolean(),
                        Weight = c.Single(),
                        FullMarks = c.Int(),
                        PassMarks = c.Int(),
                        SubjectExamDate = c.DateTime(),
                        Time = c.String(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .ForeignKey("dbo.ExamOfClass", t => t.ExamOfClassId)
                .Index(t => t.SubjectClassId)
                .Index(t => t.ExamOfClassId);
            
            CreateTable(
                "dbo.ExamSubjectExaminer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamSubjectId = c.Int(nullable: false),
                        ExaminerId = c.Int(nullable: false),
                        TeacherClass_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamSubject", t => t.ExamSubjectId)
                .ForeignKey("dbo.Users", t => t.ExaminerId)
                .ForeignKey("dbo.TeacherClass", t => t.TeacherClass_Id)
                .Index(t => t.ExamSubjectId)
                .Index(t => t.ExaminerId)
                .Index(t => t.TeacherClass_Id);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        EquivalentPercent = c.Single(),
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
                .Index(t => t.StudentClassId);
            
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
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.DateRestriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestrictionId = c.Int(nullable: false),
                        Constraint = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.Restriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        MatchMust = c.Boolean(nullable: false),
                        MatchAllAny = c.Boolean(nullable: false),
                        Visibility = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.GradeRestriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestrictionId = c.Int(nullable: false),
                        ActivityResourceId = c.Int(nullable: false),
                        MustBeGreaterThanOrEqualTo = c.Boolean(nullable: false),
                        GreaterThanOrEqualToValue = c.Single(),
                        MustBeLessThan = c.Boolean(nullable: false),
                        LessThanValue = c.Single(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .ForeignKey("dbo.ActivityResource", t => t.ActivityResourceId)
                .Index(t => t.RestrictionId)
                .Index(t => t.ActivityResourceId);
            
            CreateTable(
                "dbo.ActivityResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityOrResource = c.Boolean(nullable: false),
                        ActivityResourceType = c.Byte(nullable: false),
                        ActivityResourceId = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                        SubjectSectionId = c.Int(nullable: false),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectSection", t => t.SubjectSectionId)
                .Index(t => t.SubjectSectionId);
            
            CreateTable(
                "dbo.GroupRestriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassOrGroup = c.Boolean(nullable: false),
                        SubjectClassId = c.Int(),
                        GroupId = c.Int(),
                        RestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.SubjectClassId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.UserProfileRestriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FieldName = c.String(),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChoiceActivity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DisplayDescriptionOnCoursePage = c.Boolean(nullable: false),
                        DisplayModeForOptions = c.Boolean(nullable: false),
                        AllowChoiceTobeUpdated = c.Boolean(nullable: false),
                        AllowMoreThanOneChoiceToBeSelected = c.Boolean(nullable: false),
                        LimitTheNumberOfResponsesAllowed = c.Boolean(nullable: false),
                        RestrictTimePeriod = c.Boolean(nullable: false),
                        OpenDate = c.DateTime(),
                        UntilDate = c.DateTime(),
                        ShowPreview = c.Boolean(nullable: false),
                        PublishResults = c.Byte(nullable: false),
                        PrivacyOfResults = c.Boolean(nullable: false),
                        ShowColumnForUnAnswered = c.Boolean(nullable: false),
                        IncludeResponsesFromInactiveUsers = c.Boolean(nullable: false),
                        RestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.ChoiceOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Option = c.String(),
                        Limit = c.Long(),
                        Position = c.Int(nullable: false),
                        ChoiceActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChoiceActivity", t => t.ChoiceActivityId)
                .Index(t => t.ChoiceActivityId);
            
            CreateTable(
                "dbo.ChoiceUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChoiceActivityId = c.Int(nullable: false),
                        ChoiceOptionsId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChoiceActivity", t => t.ChoiceActivityId)
                .ForeignKey("dbo.ChoiceOptions", t => t.ChoiceOptionsId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.ChoiceActivityId)
                .Index(t => t.ChoiceOptionsId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DispalyDescriptionOnPage = c.Boolean(),
                        SubmissionFrom = c.DateTime(),
                        DueDate = c.DateTime(),
                        CutOffDate = c.DateTime(),
                        FileSubmission = c.Boolean(nullable: false),
                        MaximumNoOfUploadedFiles = c.Int(),
                        MaximumSubmissionSize = c.Int(),
                        OnlineText = c.Boolean(nullable: false),
                        WordLimit = c.Int(),
                        GradeTypeId = c.Int(nullable: false),
                        MaximumGrade = c.String(),
                        GradeToPass = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.Int(nullable: false),
                        ModifiedBy = c.Int(nullable: false),
                        RestrictionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GradeType", t => t.GradeTypeId)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.GradeTypeId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.ForumActivity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DisplayDescriptionOnCoursePage = c.Boolean(nullable: false),
                        ForumType = c.Byte(nullable: false),
                        MaximumAttachmentSize = c.Int(nullable: false),
                        MaximumNoOfAttachments = c.Int(nullable: false),
                        DisplayWordCount = c.Boolean(nullable: false),
                        SubscriptionMode = c.Byte(nullable: false),
                        ReadTracking = c.Boolean(nullable: false),
                        TimePeriodForBlocking = c.Byte(nullable: false),
                        PostThresholdForBlocking = c.Int(nullable: false),
                        PostThresholdForWarning = c.Int(nullable: false),
                        RestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.ForumDiscussion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Message = c.String(),
                        ParentDiscussionId = c.Int(),
                        ForumActivityId = c.Int(nullable: false),
                        LastPostById = c.Int(nullable: false),
                        PostedById = c.Int(nullable: false),
                        PostedDate = c.DateTime(nullable: false),
                        Closed = c.Boolean(),
                        LastUpdateDate = c.DateTime(),
                        UpdatedBy = c.Int(),
                        LastPostDate = c.DateTime(nullable: false),
                        Pinned = c.Boolean(nullable: false),
                        SubscribeToDiscussion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForumDiscussion", t => t.ParentDiscussionId)
                .ForeignKey("dbo.ForumActivity", t => t.ForumActivityId)
                .ForeignKey("dbo.Users", t => t.LastPostById)
                .ForeignKey("dbo.Users", t => t.PostedById)
                .Index(t => t.ParentDiscussionId)
                .Index(t => t.ForumActivityId)
                .Index(t => t.LastPostById)
                .Index(t => t.PostedById);
            
            CreateTable(
                "dbo.BookResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DisplayDescriptionOnCourePage = c.Boolean(nullable: false),
                        ChapterFormatting = c.Byte(nullable: false),
                        StyleOfNavigation = c.Byte(nullable: false),
                        CustomTitles = c.Boolean(nullable: false),
                        RestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.BookChapter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Position = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        ParentChapterId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookResource", t => t.BookId)
                .ForeignKey("dbo.BookChapter", t => t.ParentChapterId)
                .Index(t => t.BookId)
                .Index(t => t.ParentChapterId);
            
            CreateTable(
                "dbo.UrlResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Description = c.String(),
                        DisplayDescriptionOnPage = c.Boolean(nullable: false),
                        RestrictionId = c.Int(nullable: false),
                        Display = c.Byte(nullable: false),
                        PopupWidthInPixel = c.Int(nullable: false),
                        PopupHeightInPixel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.FileResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ShowDescriptionOnCoursePage = c.Boolean(nullable: false),
                        Display = c.Byte(nullable: false),
                        ShowSize = c.Boolean(nullable: false),
                        ShowType = c.Boolean(nullable: false),
                        ShowUploadModifiedDate = c.Boolean(nullable: false),
                        RestrictionId = c.Int(nullable: false),
                        MainFileId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.FileResourceFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileResourceId = c.Int(nullable: false),
                        SubFileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FileResource", t => t.FileResourceId)
                .ForeignKey("dbo.UserFile", t => t.SubFileId)
                .Index(t => t.FileResourceId)
                .Index(t => t.SubFileId);
            
            CreateTable(
                "dbo.PageResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PageContent = c.String(),
                        Description = c.String(),
                        DisplayDescriptionOnPage = c.Boolean(nullable: false),
                        RestrictionId = c.Int(nullable: false),
                        DisplayPageName = c.Boolean(nullable: false),
                        DisplayPageDescription = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.LabelResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        RestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
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
                "dbo.StudentBatch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProgramBatchId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        InActive = c.Boolean(),
                        Void = c.Boolean(),
                        AddedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProgramBatch", t => t.ProgramBatchId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.ProgramBatchId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.RegularSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        YearId = c.Int(nullable: false),
                        SubYearId = c.Int(),
                        AssignedDate = c.DateTime(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.Year", t => t.YearId)
                .ForeignKey("dbo.SubYear", t => t.SubYearId)
                .Index(t => t.SubjectId)
                .Index(t => t.YearId)
                .Index(t => t.SubYearId);
            
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
                        SchoolId = c.Int(nullable: false),
                        By = c.String(),
                        To = c.String(),
                        For = c.String(),
                        ReceivedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
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
                "dbo.UserType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SchoolId = c.Int(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
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
                "dbo.NoticeNotification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoticeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Viewed = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notice", t => t.NoticeId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.NoticeId)
                .Index(t => t.UserId);
            
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
            DropIndex("dbo.NoticeNotification", new[] { "UserId" });
            DropIndex("dbo.NoticeNotification", new[] { "NoticeId" });
            DropIndex("dbo.ModuleAccess", new[] { "ModuleAccessPermissionId" });
            DropIndex("dbo.UserLastLogin", new[] { "UserId" });
            DropIndex("dbo.UserType", new[] { "SchoolId" });
            DropIndex("dbo.UserTransfer", new[] { "ToSchoolId" });
            DropIndex("dbo.UserTransfer", new[] { "FromSchoolId" });
            DropIndex("dbo.UserTransfer", new[] { "ApprovedById" });
            DropIndex("dbo.RelationShip", new[] { "RelationId" });
            DropIndex("dbo.Award", new[] { "SchoolId" });
            DropIndex("dbo.TeacherQualification", new[] { "TeacherId" });
            DropIndex("dbo.TeacherNotification", new[] { "TeacherId" });
            DropIndex("dbo.Appointment", new[] { "TeacherId" });
            DropIndex("dbo.RegularSubject", new[] { "SubYearId" });
            DropIndex("dbo.RegularSubject", new[] { "YearId" });
            DropIndex("dbo.RegularSubject", new[] { "SubjectId" });
            DropIndex("dbo.StudentBatch", new[] { "StudentId" });
            DropIndex("dbo.StudentBatch", new[] { "ProgramBatchId" });
            DropIndex("dbo.StudentPreviousStudies", new[] { "StudentId" });
            DropIndex("dbo.StudentNotification", new[] { "StudentId" });
            DropIndex("dbo.Fee", new[] { "StudentId" });
            DropIndex("dbo.Fee", new[] { "Scholarship_Id" });
            DropIndex("dbo.ExamMarks", new[] { "StudentId" });
            DropIndex("dbo.ExamMarks", new[] { "SubjectExamId" });
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
            DropIndex("dbo.LabelResource", new[] { "RestrictionId" });
            DropIndex("dbo.PageResource", new[] { "RestrictionId" });
            DropIndex("dbo.FileResourceFiles", new[] { "SubFileId" });
            DropIndex("dbo.FileResourceFiles", new[] { "FileResourceId" });
            DropIndex("dbo.FileResource", new[] { "RestrictionId" });
            DropIndex("dbo.UrlResource", new[] { "RestrictionId" });
            DropIndex("dbo.BookChapter", new[] { "ParentChapterId" });
            DropIndex("dbo.BookChapter", new[] { "BookId" });
            DropIndex("dbo.BookResource", new[] { "RestrictionId" });
            DropIndex("dbo.ForumDiscussion", new[] { "PostedById" });
            DropIndex("dbo.ForumDiscussion", new[] { "LastPostById" });
            DropIndex("dbo.ForumDiscussion", new[] { "ForumActivityId" });
            DropIndex("dbo.ForumDiscussion", new[] { "ParentDiscussionId" });
            DropIndex("dbo.ForumActivity", new[] { "RestrictionId" });
            DropIndex("dbo.Assignment", new[] { "RestrictionId" });
            DropIndex("dbo.Assignment", new[] { "GradeTypeId" });
            DropIndex("dbo.ChoiceUser", new[] { "UserId" });
            DropIndex("dbo.ChoiceUser", new[] { "ChoiceOptionsId" });
            DropIndex("dbo.ChoiceUser", new[] { "ChoiceActivityId" });
            DropIndex("dbo.ChoiceOptions", new[] { "ChoiceActivityId" });
            DropIndex("dbo.ChoiceActivity", new[] { "RestrictionId" });
            DropIndex("dbo.GroupRestriction", new[] { "RestrictionId" });
            DropIndex("dbo.GroupRestriction", new[] { "SubjectClassId" });
            DropIndex("dbo.ActivityResource", new[] { "SubjectSectionId" });
            DropIndex("dbo.GradeRestriction", new[] { "ActivityResourceId" });
            DropIndex("dbo.GradeRestriction", new[] { "RestrictionId" });
            DropIndex("dbo.Restriction", new[] { "ParentId" });
            DropIndex("dbo.DateRestriction", new[] { "RestrictionId" });
            DropIndex("dbo.TeacherClass", new[] { "TeacherId" });
            DropIndex("dbo.StudentsOpinionAboutSubject", new[] { "SubjectSubscriptionId" });
            DropIndex("dbo.SubjectSubscription", new[] { "StudentClassId" });
            DropIndex("dbo.ExamSubjectExaminer", new[] { "TeacherClass_Id" });
            DropIndex("dbo.ExamSubjectExaminer", new[] { "ExaminerId" });
            DropIndex("dbo.ExamSubjectExaminer", new[] { "ExamSubjectId" });
            DropIndex("dbo.ExamSubject", new[] { "ExamOfClassId" });
            DropIndex("dbo.ExamSubject", new[] { "SubjectClassId" });
            DropIndex("dbo.ExamStudent", new[] { "StudentClass_Id" });
            DropIndex("dbo.ExamStudent", new[] { "PostedById" });
            DropIndex("dbo.ExamStudent", new[] { "ObtainedGradeId" });
            DropIndex("dbo.ExamStudent", new[] { "UserClassId" });
            DropIndex("dbo.ExamStudent", new[] { "ExamSubjectId" });
            DropIndex("dbo.Study", new[] { "SessionId" });
            DropIndex("dbo.Study", new[] { "AcademicYearId" });
            DropIndex("dbo.Study", new[] { "SectionId" });
            DropIndex("dbo.Study", new[] { "YearId" });
            DropIndex("dbo.Study", new[] { "StudentGroupId" });
            DropIndex("dbo.StudentGroup", new[] { "ProgramBatchId" });
            DropIndex("dbo.StudentGroup", new[] { "SchoolId" });
            DropIndex("dbo.StudentGroup", new[] { "ParentId" });
            DropIndex("dbo.StudentGroupStudent", new[] { "StudentGroupId" });
            DropIndex("dbo.StudentGroupStudent", new[] { "StudentId" });
            DropIndex("dbo.Student", new[] { "UserId" });
            DropIndex("dbo.StudentClass", new[] { "RunningClassId" });
            DropIndex("dbo.StudentClass", new[] { "StudentGroupId" });
            DropIndex("dbo.StudentClass", new[] { "StudentId" });
            DropIndex("dbo.GradeValues", new[] { "GradeTypeId" });
            DropIndex("dbo.GradeType", new[] { "SchoolId" });
            DropIndex("dbo.SessionAdmins", new[] { "SessionId" });
            DropIndex("dbo.SessionAdmins", new[] { "TitleId" });
            DropIndex("dbo.OtherAdmins", new[] { "AdminsId" });
            DropIndex("dbo.Admins", new[] { "AcademicYearId" });
            DropIndex("dbo.ExamOfClass", new[] { "RunningClassId" });
            DropIndex("dbo.ExamOfClass", new[] { "ExamId" });
            DropIndex("dbo.SubjectSection", new[] { "SubjectId" });
            DropIndex("dbo.SubjectUserGroup", new[] { "SubjectId" });
            DropIndex("dbo.SubjectStructure", new[] { "WillNotBeActiveFromAcademicYearId" });
            DropIndex("dbo.SubjectStructure", new[] { "LastActiveInAcademicYearId" });
            DropIndex("dbo.SubjectStructure", new[] { "RemovedInAcademicYearId" });
            DropIndex("dbo.SubjectStructure", new[] { "SubjectId" });
            DropIndex("dbo.SubjectStructure", new[] { "SubYearId" });
            DropIndex("dbo.SubjectStructure", new[] { "YearId" });
            DropIndex("dbo.RunningClass", new[] { "ProgramBatchId" });
            DropIndex("dbo.RunningClass", new[] { "SubYearId" });
            DropIndex("dbo.RunningClass", new[] { "YearId" });
            DropIndex("dbo.RunningClass", new[] { "SessionId" });
            DropIndex("dbo.RunningClass", new[] { "AcademicYearId" });
            DropIndex("dbo.SubjectClass", new[] { "SubjectId" });
            DropIndex("dbo.SubjectClass", new[] { "SubjectStructureId" });
            DropIndex("dbo.SubjectClass", new[] { "RunningClassId" });
            DropIndex("dbo.UserClass", new[] { "SubjectUserGroupId" });
            DropIndex("dbo.UserClass", new[] { "RoleId" });
            DropIndex("dbo.UserClass", new[] { "UserId" });
            DropIndex("dbo.UserClass", new[] { "SubjectClassId" });
            DropIndex("dbo.RoleCapability", new[] { "CapabilityId" });
            DropIndex("dbo.RoleCapability", new[] { "RoleId" });
            DropIndex("dbo.Role", new[] { "SchoolId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Division", new[] { "ParentDivisionId" });
            DropIndex("dbo.Division", new[] { "SchoolId" });
            DropIndex("dbo.UserDivision", new[] { "DivisionId" });
            DropIndex("dbo.UserDivision", new[] { "UsersId" });
            DropIndex("dbo.Users", new[] { "UserImageId" });
            DropIndex("dbo.Users", new[] { "SchoolId" });
            DropIndex("dbo.Users", new[] { "GenderId" });
            DropIndex("dbo.Teacher", new[] { "TeacherJobTitleId" });
            DropIndex("dbo.Teacher", new[] { "UserId" });
            DropIndex("dbo.Teach", new[] { "SubjectId" });
            DropIndex("dbo.Teach", new[] { "TeacherId" });
            DropIndex("dbo.Teach", new[] { "SessionId" });
            DropIndex("dbo.Teach", new[] { "AcademicYearId" });
            DropIndex("dbo.Batch", new[] { "SchoolId" });
            DropIndex("dbo.ProgramBatch", new[] { "CurrentSubYearId" });
            DropIndex("dbo.ProgramBatch", new[] { "CurrentYearId" });
            DropIndex("dbo.ProgramBatch", new[] { "ProgramId" });
            DropIndex("dbo.ProgramBatch", new[] { "BatchId" });
            DropIndex("dbo.SubYear", new[] { "YearId" });
            DropIndex("dbo.SubYear", new[] { "ParentId" });
            DropIndex("dbo.Year", new[] { "ProgramId" });
            DropIndex("dbo.Level", new[] { "SchoolId" });
            DropIndex("dbo.Faculty", new[] { "LevelId" });
            DropIndex("dbo.Program", new[] { "FacultyId" });
            DropIndex("dbo.SubjectGroup", new[] { "SubYearId" });
            DropIndex("dbo.SubjectGroup", new[] { "ProgramId" });
            DropIndex("dbo.SubjectGroup", new[] { "YearId" });
            DropIndex("dbo.SubjectGroupSubject", new[] { "SubjectGroupId" });
            DropIndex("dbo.SubjectGroupSubject", new[] { "SubjectId" });
            DropIndex("dbo.SubjectCategory", new[] { "SchoolId" });
            DropIndex("dbo.Subject", new[] { "SubjectCategoryId" });
            DropIndex("dbo.UserFile", new[] { "SubjectId" });
            DropIndex("dbo.School", new[] { "SchoolTypeId" });
            DropIndex("dbo.School", new[] { "ImageId" });
            DropIndex("dbo.ExamType", new[] { "SchoolId" });
            DropIndex("dbo.Exam", new[] { "NoticeId" });
            DropIndex("dbo.Exam", new[] { "ExamCoordinatorId" });
            DropIndex("dbo.Exam", new[] { "SessionId" });
            DropIndex("dbo.Exam", new[] { "AcademicYearId" });
            DropIndex("dbo.Exam", new[] { "SchoolId" });
            DropIndex("dbo.Exam", new[] { "ExamTypeId" });
            DropIndex("dbo.Session", new[] { "AcademicYearId" });
            DropIndex("dbo.Session", new[] { "ParentId" });
            DropForeignKey("dbo.ModuleModuleAccess", "ModuleAccess_Id", "dbo.ModuleAccess");
            DropForeignKey("dbo.ModuleModuleAccess", "Module_Id", "dbo.Module");
            DropForeignKey("dbo.NoticeNotification", "UserId", "dbo.Users");
            DropForeignKey("dbo.NoticeNotification", "NoticeId", "dbo.Notice");
            DropForeignKey("dbo.ModuleAccess", "ModuleAccessPermissionId", "dbo.ModuleAccessPermission");
            DropForeignKey("dbo.UserLastLogin", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserType", "SchoolId", "dbo.School");
            DropForeignKey("dbo.UserTransfer", "ToSchoolId", "dbo.School");
            DropForeignKey("dbo.UserTransfer", "FromSchoolId", "dbo.School");
            DropForeignKey("dbo.UserTransfer", "ApprovedById", "dbo.Users");
            DropForeignKey("dbo.RelationShip", "RelationId", "dbo.Relation");
            DropForeignKey("dbo.Award", "SchoolId", "dbo.School");
            DropForeignKey("dbo.TeacherQualification", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.TeacherNotification", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Appointment", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.RegularSubject", "SubYearId", "dbo.SubYear");
            DropForeignKey("dbo.RegularSubject", "YearId", "dbo.Year");
            DropForeignKey("dbo.RegularSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.StudentBatch", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentBatch", "ProgramBatchId", "dbo.ProgramBatch");
            DropForeignKey("dbo.StudentPreviousStudies", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentNotification", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Fee", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Fee", "Scholarship_Id", "dbo.Scholarship");
            DropForeignKey("dbo.ExamMarks", "StudentId", "dbo.Student");
            DropForeignKey("dbo.ExamMarks", "SubjectExamId", "dbo.ExamSubject");
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
            DropForeignKey("dbo.LabelResource", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.PageResource", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.FileResourceFiles", "SubFileId", "dbo.UserFile");
            DropForeignKey("dbo.FileResourceFiles", "FileResourceId", "dbo.FileResource");
            DropForeignKey("dbo.FileResource", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.UrlResource", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.BookChapter", "ParentChapterId", "dbo.BookChapter");
            DropForeignKey("dbo.BookChapter", "BookId", "dbo.BookResource");
            DropForeignKey("dbo.BookResource", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.ForumDiscussion", "PostedById", "dbo.Users");
            DropForeignKey("dbo.ForumDiscussion", "LastPostById", "dbo.Users");
            DropForeignKey("dbo.ForumDiscussion", "ForumActivityId", "dbo.ForumActivity");
            DropForeignKey("dbo.ForumDiscussion", "ParentDiscussionId", "dbo.ForumDiscussion");
            DropForeignKey("dbo.ForumActivity", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.Assignment", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.Assignment", "GradeTypeId", "dbo.GradeType");
            DropForeignKey("dbo.ChoiceUser", "UserId", "dbo.Users");
            DropForeignKey("dbo.ChoiceUser", "ChoiceOptionsId", "dbo.ChoiceOptions");
            DropForeignKey("dbo.ChoiceUser", "ChoiceActivityId", "dbo.ChoiceActivity");
            DropForeignKey("dbo.ChoiceOptions", "ChoiceActivityId", "dbo.ChoiceActivity");
            DropForeignKey("dbo.ChoiceActivity", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.GroupRestriction", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.GroupRestriction", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.ActivityResource", "SubjectSectionId", "dbo.SubjectSection");
            DropForeignKey("dbo.GradeRestriction", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.GradeRestriction", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.Restriction", "ParentId", "dbo.Restriction");
            DropForeignKey("dbo.DateRestriction", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.TeacherClass", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.StudentsOpinionAboutSubject", "SubjectSubscriptionId", "dbo.SubjectSubscription");
            DropForeignKey("dbo.SubjectSubscription", "StudentClassId", "dbo.StudentClass");
            DropForeignKey("dbo.ExamSubjectExaminer", "TeacherClass_Id", "dbo.TeacherClass");
            DropForeignKey("dbo.ExamSubjectExaminer", "ExaminerId", "dbo.Users");
            DropForeignKey("dbo.ExamSubjectExaminer", "ExamSubjectId", "dbo.ExamSubject");
            DropForeignKey("dbo.ExamSubject", "ExamOfClassId", "dbo.ExamOfClass");
            DropForeignKey("dbo.ExamSubject", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.ExamStudent", "StudentClass_Id", "dbo.StudentClass");
            DropForeignKey("dbo.ExamStudent", "PostedById", "dbo.Users");
            DropForeignKey("dbo.ExamStudent", "ObtainedGradeId", "dbo.Grade");
            DropForeignKey("dbo.ExamStudent", "UserClassId", "dbo.UserClass");
            DropForeignKey("dbo.ExamStudent", "ExamSubjectId", "dbo.ExamSubject");
            DropForeignKey("dbo.Study", "SessionId", "dbo.Session");
            DropForeignKey("dbo.Study", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.Study", "SectionId", "dbo.SubYear");
            DropForeignKey("dbo.Study", "YearId", "dbo.Year");
            DropForeignKey("dbo.Study", "StudentGroupId", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentGroup", "ProgramBatchId", "dbo.ProgramBatch");
            DropForeignKey("dbo.StudentGroup", "SchoolId", "dbo.School");
            DropForeignKey("dbo.StudentGroup", "ParentId", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentGroupStudent", "StudentGroupId", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentGroupStudent", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "UserId", "dbo.Users");
            DropForeignKey("dbo.StudentClass", "RunningClassId", "dbo.RunningClass");
            DropForeignKey("dbo.StudentClass", "StudentGroupId", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentClass", "StudentId", "dbo.Student");
            DropForeignKey("dbo.GradeValues", "GradeTypeId", "dbo.GradeType");
            DropForeignKey("dbo.GradeType", "SchoolId", "dbo.School");
            DropForeignKey("dbo.SessionAdmins", "SessionId", "dbo.Session");
            DropForeignKey("dbo.SessionAdmins", "TitleId", "dbo.AdminTitle");
            DropForeignKey("dbo.OtherAdmins", "AdminsId", "dbo.Admins");
            DropForeignKey("dbo.Admins", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.ExamOfClass", "RunningClassId", "dbo.RunningClass");
            DropForeignKey("dbo.ExamOfClass", "ExamId", "dbo.Exam");
            DropForeignKey("dbo.SubjectSection", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectUserGroup", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectStructure", "WillNotBeActiveFromAcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.SubjectStructure", "LastActiveInAcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.SubjectStructure", "RemovedInAcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.SubjectStructure", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectStructure", "SubYearId", "dbo.SubYear");
            DropForeignKey("dbo.SubjectStructure", "YearId", "dbo.Year");
            DropForeignKey("dbo.RunningClass", "ProgramBatchId", "dbo.ProgramBatch");
            DropForeignKey("dbo.RunningClass", "SubYearId", "dbo.SubYear");
            DropForeignKey("dbo.RunningClass", "YearId", "dbo.Year");
            DropForeignKey("dbo.RunningClass", "SessionId", "dbo.Session");
            DropForeignKey("dbo.RunningClass", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.SubjectClass", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectClass", "SubjectStructureId", "dbo.SubjectStructure");
            DropForeignKey("dbo.SubjectClass", "RunningClassId", "dbo.RunningClass");
            DropForeignKey("dbo.UserClass", "SubjectUserGroupId", "dbo.SubjectUserGroup");
            DropForeignKey("dbo.UserClass", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserClass", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClass", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.RoleCapability", "CapabilityId", "dbo.Capability");
            DropForeignKey("dbo.RoleCapability", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Role", "SchoolId", "dbo.School");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.Users");
            DropForeignKey("dbo.Division", "ParentDivisionId", "dbo.Division");
            DropForeignKey("dbo.Division", "SchoolId", "dbo.School");
            DropForeignKey("dbo.UserDivision", "DivisionId", "dbo.Division");
            DropForeignKey("dbo.UserDivision", "UsersId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserImageId", "dbo.UserFile");
            DropForeignKey("dbo.Users", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Users", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.Teacher", "TeacherJobTitleId", "dbo.TeacherJobTitle");
            DropForeignKey("dbo.Teacher", "UserId", "dbo.Users");
            DropForeignKey("dbo.Teach", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Teach", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Teach", "SessionId", "dbo.Session");
            DropForeignKey("dbo.Teach", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.Batch", "SchoolId", "dbo.School");
            DropForeignKey("dbo.ProgramBatch", "CurrentSubYearId", "dbo.SubYear");
            DropForeignKey("dbo.ProgramBatch", "CurrentYearId", "dbo.Year");
            DropForeignKey("dbo.ProgramBatch", "ProgramId", "dbo.Program");
            DropForeignKey("dbo.ProgramBatch", "BatchId", "dbo.Batch");
            DropForeignKey("dbo.SubYear", "YearId", "dbo.Year");
            DropForeignKey("dbo.SubYear", "ParentId", "dbo.SubYear");
            DropForeignKey("dbo.Year", "ProgramId", "dbo.Program");
            DropForeignKey("dbo.Level", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Faculty", "LevelId", "dbo.Level");
            DropForeignKey("dbo.Program", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.SubjectGroup", "SubYearId", "dbo.SubYear");
            DropForeignKey("dbo.SubjectGroup", "ProgramId", "dbo.Program");
            DropForeignKey("dbo.SubjectGroup", "YearId", "dbo.Year");
            DropForeignKey("dbo.SubjectGroupSubject", "SubjectGroupId", "dbo.SubjectGroup");
            DropForeignKey("dbo.SubjectGroupSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectCategory", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Subject", "SubjectCategoryId", "dbo.SubjectCategory");
            DropForeignKey("dbo.UserFile", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.School", "SchoolTypeId", "dbo.SchoolType");
            DropForeignKey("dbo.School", "ImageId", "dbo.UserFile");
            DropForeignKey("dbo.ExamType", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Exam", "NoticeId", "dbo.Notice");
            DropForeignKey("dbo.Exam", "ExamCoordinatorId", "dbo.Users");
            DropForeignKey("dbo.Exam", "SessionId", "dbo.Session");
            DropForeignKey("dbo.Exam", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.Exam", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Exam", "ExamTypeId", "dbo.ExamType");
            DropForeignKey("dbo.Session", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.Session", "ParentId", "dbo.Session");
            DropTable("dbo.ModuleModuleAccess");
            DropTable("dbo.NoticeNotification");
            DropTable("dbo.UserImage");
            DropTable("dbo.Module");
            DropTable("dbo.ModuleAccess");
            DropTable("dbo.ModuleAccessPermission");
            DropTable("dbo.Nation");
            DropTable("dbo.UserLastLogin");
            DropTable("dbo.UserType");
            DropTable("dbo.UserTransfer");
            DropTable("dbo.RelationShip");
            DropTable("dbo.Relation");
            DropTable("dbo.Award");
            DropTable("dbo.TeacherQualification");
            DropTable("dbo.TeacherNotification");
            DropTable("dbo.TeacherExperience");
            DropTable("dbo.Appointment");
            DropTable("dbo.StudentSubject");
            DropTable("dbo.RegularSubject");
            DropTable("dbo.StudentBatch");
            DropTable("dbo.StudentTransferType");
            DropTable("dbo.StudentTransfer");
            DropTable("dbo.StudentPreviousStudies");
            DropTable("dbo.StudentNotification");
            DropTable("dbo.Scholarship");
            DropTable("dbo.Fee");
            DropTable("dbo.Admission");
            DropTable("dbo.AccessPermission");
            DropTable("dbo.ExamMarks");
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
            DropTable("dbo.LabelResource");
            DropTable("dbo.PageResource");
            DropTable("dbo.FileResourceFiles");
            DropTable("dbo.FileResource");
            DropTable("dbo.UrlResource");
            DropTable("dbo.BookChapter");
            DropTable("dbo.BookResource");
            DropTable("dbo.ForumDiscussion");
            DropTable("dbo.ForumActivity");
            DropTable("dbo.Assignment");
            DropTable("dbo.ChoiceUser");
            DropTable("dbo.ChoiceOptions");
            DropTable("dbo.ChoiceActivity");
            DropTable("dbo.UserProfileRestriction");
            DropTable("dbo.GroupRestriction");
            DropTable("dbo.ActivityResource");
            DropTable("dbo.GradeRestriction");
            DropTable("dbo.Restriction");
            DropTable("dbo.DateRestriction");
            DropTable("dbo.TeacherClass");
            DropTable("dbo.StudentsOpinionAboutSubject");
            DropTable("dbo.SubjectSubscription");
            DropTable("dbo.Grade");
            DropTable("dbo.ExamSubjectExaminer");
            DropTable("dbo.ExamSubject");
            DropTable("dbo.ExamStudent");
            DropTable("dbo.Study");
            DropTable("dbo.StudentGroup");
            DropTable("dbo.StudentGroupStudent");
            DropTable("dbo.Student");
            DropTable("dbo.StudentClass");
            DropTable("dbo.GradeValues");
            DropTable("dbo.GradeType");
            DropTable("dbo.Event");
            DropTable("dbo.FileCategory");
            DropTable("dbo.SessionAdmins");
            DropTable("dbo.OtherAdmins");
            DropTable("dbo.AdminTitle");
            DropTable("dbo.Admins");
            DropTable("dbo.Notice");
            DropTable("dbo.ExamOfClass");
            DropTable("dbo.SchoolType");
            DropTable("dbo.SubjectSection");
            DropTable("dbo.TeacherJobTitle");
            DropTable("dbo.SubjectUserGroup");
            DropTable("dbo.SubjectStructure");
            DropTable("dbo.RunningClass");
            DropTable("dbo.SubjectClass");
            DropTable("dbo.UserClass");
            DropTable("dbo.Capability");
            DropTable("dbo.RoleCapability");
            DropTable("dbo.Role");
            DropTable("dbo.UserRole");
            DropTable("dbo.Division");
            DropTable("dbo.UserDivision");
            DropTable("dbo.Gender");
            DropTable("dbo.Users");
            DropTable("dbo.Teacher");
            DropTable("dbo.Teach");
            DropTable("dbo.Batch");
            DropTable("dbo.ProgramBatch");
            DropTable("dbo.SubYear");
            DropTable("dbo.Year");
            DropTable("dbo.Level");
            DropTable("dbo.Faculty");
            DropTable("dbo.Program");
            DropTable("dbo.SubjectGroup");
            DropTable("dbo.SubjectGroupSubject");
            DropTable("dbo.SubjectCategory");
            DropTable("dbo.Subject");
            DropTable("dbo.UserFile");
            DropTable("dbo.School");
            DropTable("dbo.ExamType");
            DropTable("dbo.Exam");
            DropTable("dbo.Session");
            DropTable("dbo.AcademicYear");
        }
    }
}
