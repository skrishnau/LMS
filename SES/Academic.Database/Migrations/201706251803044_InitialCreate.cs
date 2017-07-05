namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        SentDate = c.DateTime(nullable: false),
                        Viewed = c.Boolean(nullable: false),
                        ViewedDate = c.DateTime(),
                        VoidBySender = c.Boolean(),
                        VoidByReceiver = c.Boolean(),
                        RepliedToId = c.Int(),
                        SenderId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Message", t => t.RepliedToId)
                .ForeignKey("dbo.Users", t => t.SenderId)
                .ForeignKey("dbo.Users", t => t.ReceiverId)
                .Index(t => t.RepliedToId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
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
                .ForeignKey("dbo.SchoolType", t => t.SchoolTypeId)
                .Index(t => t.SchoolTypeId);
            
            CreateTable(
                "dbo.SchoolType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        CreatedBy = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                        Void = c.Boolean(),
                        IconPath = c.String(),
                        IsServerFile = c.Boolean(nullable: false),
                        IsFolder = c.Boolean(nullable: false),
                        FolderId = c.Int(),
                        IsConstantAndNotEditable = c.Boolean(),
                        SchoolId = c.Int(),
                        SubjectId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserFile", t => t.FolderId)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.FolderId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        ShortName = c.String(),
                        Summary = c.String(),
                        Credit = c.Int(nullable: false),
                        Code = c.String(),
                        SubjectCategoryId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
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
                        RestrictionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.SubjectId)
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
                        Name = c.String(),
                        WeightInGradeSheet = c.Single(),
                        Position = c.Int(nullable: false),
                        SubjectSectionId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        RestrictionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectSection", t => t.SubjectSectionId)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.SubjectSectionId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.ActivityCompletion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ActivityResourceId = c.Int(nullable: false),
                        CompletionMarkedDate = c.DateTime(nullable: false),
                        CompletionMarkedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.ActivityResource", t => t.ActivityResourceId)
                .ForeignKey("dbo.Users", t => t.CompletionMarkedById)
                .Index(t => t.UserId)
                .Index(t => t.ActivityResourceId)
                .Index(t => t.CompletionMarkedById);
            
            CreateTable(
                "dbo.ActivityGrading",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Remarks = c.String(),
                        UserClassId = c.Int(nullable: false),
                        ActivityResourceId = c.Int(nullable: false),
                        GradedDate = c.DateTime(nullable: false),
                        GradedById = c.Int(nullable: false),
                        ModifiedDate = c.DateTime(),
                        ModifiedById = c.Int(),
                        ObtainedGradeId = c.Int(),
                        ObtainedGradeMarks = c.Single(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserClass", t => t.UserClassId)
                .ForeignKey("dbo.ActivityResource", t => t.ActivityResourceId)
                .ForeignKey("dbo.Users", t => t.GradedById)
                .ForeignKey("dbo.Users", t => t.ModifiedById)
                .ForeignKey("dbo.GradeValue", t => t.ObtainedGradeId)
                .Index(t => t.UserClassId)
                .Index(t => t.ActivityResourceId)
                .Index(t => t.GradedById)
                .Index(t => t.ModifiedById)
                .Index(t => t.ObtainedGradeId);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.SubjectClassId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                        Void = c.Boolean(),
                        VoidBy = c.Int(),
                        VoidDate = c.DateTime(),
                        SessionComplete = c.Boolean(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Int(),
                        CompletionMarkedDate = c.DateTime(),
                        CompleteMarkedByUserId = c.Int(),
                        EnrollmentMethod = c.Byte(nullable: false),
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
                .ForeignKey("dbo.SubYear", t => t.SubYearId)
                .ForeignKey("dbo.Year", t => t.YearId)
                .ForeignKey("dbo.ProgramBatch", t => t.ProgramBatchId)
                .ForeignKey("dbo.Session", t => t.SessionId)
                .ForeignKey("dbo.AcademicYear", t => t.AcademicYearId)
                .Index(t => t.SubYearId)
                .Index(t => t.YearId)
                .Index(t => t.ProgramBatchId)
                .Index(t => t.SessionId)
                .Index(t => t.AcademicYearId);
            
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
                        ActiveMarkedDate = c.DateTime(),
                        ActiveMarkedById = c.Int(),
                        Completed = c.Boolean(),
                        CompleteMarkedDate = c.DateTime(),
                        CompleteMarkedById = c.Int(),
                        SchoolId = c.Int(nullable: false),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Batch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        AcademicYearId = c.Int(nullable: false),
                        SchoolId = c.Int(nullable: false),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcademicYear", t => t.AcademicYearId)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.AcademicYearId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.ProgramBatch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        Void = c.Boolean(),
                        PassOut = c.Boolean(),
                        StartedStudying = c.Boolean(),
                        StudyCompleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batch", t => t.BatchId)
                .ForeignKey("dbo.Program", t => t.ProgramId)
                .Index(t => t.BatchId)
                .Index(t => t.ProgramId);
            
            CreateTable(
                "dbo.Program",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        SchoolId = c.Int(nullable: false),
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
                        Void = c.Boolean(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubYear", t => t.ParentId)
                .ForeignKey("dbo.Year", t => t.YearId)
                .Index(t => t.ParentId)
                .Index(t => t.YearId);
            
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
                        IsElective = c.Boolean(nullable: false),
                        Credit = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        VoidBy = c.Int(),
                        UpdatedBy = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        VoidDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Year", t => t.YearId)
                .ForeignKey("dbo.SubYear", t => t.SubYearId)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.YearId)
                .Index(t => t.SubYearId)
                .Index(t => t.SubjectId);
            
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
                        CompleteMarkedDate = c.DateTime(),
                        CompleteMarkedById = c.Int(),
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
                "dbo.ActivityClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityResourceId = c.Int(nullable: false),
                        SubjectClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityResource", t => t.ActivityResourceId)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .Index(t => t.ActivityResourceId)
                .Index(t => t.SubjectClassId);
            
            CreateTable(
                "dbo.ActivityResourceView",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserClassId = c.Int(nullable: false),
                        ActivityClassId = c.Int(nullable: false),
                        ViewedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserClass", t => t.UserClassId)
                .ForeignKey("dbo.ActivityClass", t => t.ActivityClassId)
                .Index(t => t.UserClassId)
                .Index(t => t.ActivityClassId);
            
            CreateTable(
                "dbo.SubjectClassGrouping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectClassId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectClass", t => t.SubjectClassId)
                .Index(t => t.SubjectClassId);
            
            CreateTable(
                "dbo.UserClassGrouping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserClassId = c.Int(nullable: false),
                        GroupingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserClass", t => t.UserClassId)
                .ForeignKey("dbo.SubjectClassGrouping", t => t.GroupingId)
                .Index(t => t.UserClassId)
                .Index(t => t.GroupingId);
            
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
                "dbo.AssignmentSubmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubmissionText = c.String(),
                        SubmittedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        UserClassId = c.Int(nullable: false),
                        AssignmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserClass", t => t.UserClassId)
                .ForeignKey("dbo.Assignment", t => t.AssignmentId)
                .Index(t => t.UserClassId)
                .Index(t => t.AssignmentId);
            
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
                        ShowGradeToStudents = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grade", t => t.GradeTypeId)
                .Index(t => t.GradeTypeId);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        RangeOrValue = c.Boolean(nullable: false),
                        GradeValueIsInPercentOrPostition = c.Boolean(),
                        TotalMaxValue = c.Single(),
                        TotalMinValue = c.Single(),
                        MinimumPassValue = c.Single(),
                        Void = c.Boolean(),
                        SchoolId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.School", t => t.SchoolId)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.GradeValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        IsFailGrade = c.Boolean(),
                        GradeId = c.Int(nullable: false),
                        EquivalentPercentOrPostition = c.Single(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grade", t => t.GradeId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.AssignmentSubmissionFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignmentSubmissionsId = c.Int(nullable: false),
                        UserFileId = c.Int(nullable: false),
                        FileSubmittedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssignmentSubmissions", t => t.AssignmentSubmissionsId)
                .ForeignKey("dbo.UserFile", t => t.UserFileId)
                .Index(t => t.AssignmentSubmissionsId)
                .Index(t => t.UserFileId);
            
            CreateTable(
                "dbo.GroupRestriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        Constraint = c.Byte(nullable: false),
                        Value = c.String(),
                        RestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.RestrictionId);
            
            CreateTable(
                "dbo.SessionDefault",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        PostedById = c.Int(nullable: false),
                        PostToPublic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.PostedById)
                .Index(t => t.PostedById);
            
            CreateTable(
                "dbo.ActivityCompletionRestriction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityId = c.Int(nullable: false),
                        Constraint = c.String(),
                        RestrictionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ActivityResource", t => t.ActivityId)
                .ForeignKey("dbo.Restriction", t => t.RestrictionId)
                .Index(t => t.ActivityId)
                .Index(t => t.RestrictionId);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Display = c.Byte(nullable: false),
                        PopupWidthInPixel = c.Int(nullable: false),
                        PopupHeightInPixel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        MainFileId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        DisplayPageName = c.Boolean(nullable: false),
                        DisplayPageDescription = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LabelResource",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        ExamSubjectExaminerId = c.Int(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamSubject", t => t.ExamSubjectId)
                .ForeignKey("dbo.UserClass", t => t.UserClassId)
                .ForeignKey("dbo.GradeValue", t => t.ObtainedGradeId)
                .ForeignKey("dbo.ExamSubjectExaminer", t => t.ExamSubjectExaminerId)
                .Index(t => t.ExamSubjectId)
                .Index(t => t.UserClassId)
                .Index(t => t.ObtainedGradeId)
                .Index(t => t.ExamSubjectExaminerId);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamSubject", t => t.ExamSubjectId)
                .ForeignKey("dbo.Users", t => t.ExaminerId)
                .Index(t => t.ExamSubjectId)
                .Index(t => t.ExaminerId);
            
            CreateTable(
                "dbo.TextBook",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Publication = c.String(),
                        ISBN = c.String(),
                        BookCode = c.String(),
                        Edition = c.String(),
                        Price = c.Single(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
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
                .ForeignKey("dbo.TextBook", t => t.BookId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.BatchGrouping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batch", t => t.BatchId)
                .Index(t => t.BatchId);
            
            CreateTable(
                "dbo.SubjectGrouping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subject", t => t.SubjectId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointedDate = c.DateTime(),
                        ResearchInterest = c.String(),
                        Hobbies = c.String(),
                        UserId = c.Int(nullable: false),
                        TeacherJobTitleId = c.Int(),
                        JobTitle = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
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
                "dbo.Module",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                        ModuleDirectory = c.String(),
                        ParentModuleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Module", t => t.ParentModuleId)
                .Index(t => t.ParentModuleId);
            
            CreateTable(
                "dbo.ModuleAccess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolId = c.Int(nullable: false),
                        PermissionType = c.Byte(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Module", t => t.ModuleId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.ModuleId)
                .Index(t => t.RoleId);
            
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
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.NoticeNotification", new[] { "UserId" });
            DropIndex("dbo.NoticeNotification", new[] { "NoticeId" });
            DropIndex("dbo.ModuleAccess", new[] { "RoleId" });
            DropIndex("dbo.ModuleAccess", new[] { "ModuleId" });
            DropIndex("dbo.Module", new[] { "ParentModuleId" });
            DropIndex("dbo.UserLastLogin", new[] { "UserId" });
            DropIndex("dbo.TeacherQualification", new[] { "TeacherId" });
            DropIndex("dbo.Teacher", new[] { "UserId" });
            DropIndex("dbo.SubjectGrouping", new[] { "SubjectId" });
            DropIndex("dbo.BatchGrouping", new[] { "BatchId" });
            DropIndex("dbo.BookAuthor", new[] { "BookId" });
            DropIndex("dbo.TextBook", new[] { "SubjectId" });
            DropIndex("dbo.ExamSubjectExaminer", new[] { "ExaminerId" });
            DropIndex("dbo.ExamSubjectExaminer", new[] { "ExamSubjectId" });
            DropIndex("dbo.ExamSubject", new[] { "ExamOfClassId" });
            DropIndex("dbo.ExamSubject", new[] { "SubjectClassId" });
            DropIndex("dbo.ExamStudent", new[] { "ExamSubjectExaminerId" });
            DropIndex("dbo.ExamStudent", new[] { "ObtainedGradeId" });
            DropIndex("dbo.ExamStudent", new[] { "UserClassId" });
            DropIndex("dbo.ExamStudent", new[] { "ExamSubjectId" });
            DropIndex("dbo.FileResourceFiles", new[] { "SubFileId" });
            DropIndex("dbo.FileResourceFiles", new[] { "FileResourceId" });
            DropIndex("dbo.BookChapter", new[] { "ParentChapterId" });
            DropIndex("dbo.BookChapter", new[] { "BookId" });
            DropIndex("dbo.ForumDiscussion", new[] { "PostedById" });
            DropIndex("dbo.ForumDiscussion", new[] { "LastPostById" });
            DropIndex("dbo.ForumDiscussion", new[] { "ForumActivityId" });
            DropIndex("dbo.ForumDiscussion", new[] { "ParentDiscussionId" });
            DropIndex("dbo.ChoiceUser", new[] { "UserId" });
            DropIndex("dbo.ChoiceUser", new[] { "ChoiceOptionsId" });
            DropIndex("dbo.ChoiceUser", new[] { "ChoiceActivityId" });
            DropIndex("dbo.ChoiceOptions", new[] { "ChoiceActivityId" });
            DropIndex("dbo.ActivityCompletionRestriction", new[] { "RestrictionId" });
            DropIndex("dbo.ActivityCompletionRestriction", new[] { "ActivityId" });
            DropIndex("dbo.Event", new[] { "PostedById" });
            DropIndex("dbo.UserProfileRestriction", new[] { "RestrictionId" });
            DropIndex("dbo.GroupRestriction", new[] { "RestrictionId" });
            DropIndex("dbo.GroupRestriction", new[] { "SubjectClassId" });
            DropIndex("dbo.AssignmentSubmissionFiles", new[] { "UserFileId" });
            DropIndex("dbo.AssignmentSubmissionFiles", new[] { "AssignmentSubmissionsId" });
            DropIndex("dbo.GradeValue", new[] { "GradeId" });
            DropIndex("dbo.Grade", new[] { "SchoolId" });
            DropIndex("dbo.Assignment", new[] { "GradeTypeId" });
            DropIndex("dbo.AssignmentSubmissions", new[] { "AssignmentId" });
            DropIndex("dbo.AssignmentSubmissions", new[] { "UserClassId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Role", new[] { "SchoolId" });
            DropIndex("dbo.UserClassGrouping", new[] { "GroupingId" });
            DropIndex("dbo.UserClassGrouping", new[] { "UserClassId" });
            DropIndex("dbo.SubjectClassGrouping", new[] { "SubjectClassId" });
            DropIndex("dbo.ActivityResourceView", new[] { "ActivityClassId" });
            DropIndex("dbo.ActivityResourceView", new[] { "UserClassId" });
            DropIndex("dbo.ActivityClass", new[] { "SubjectClassId" });
            DropIndex("dbo.ActivityClass", new[] { "ActivityResourceId" });
            DropIndex("dbo.ExamOfClass", new[] { "RunningClassId" });
            DropIndex("dbo.ExamOfClass", new[] { "ExamId" });
            DropIndex("dbo.ExamType", new[] { "SchoolId" });
            DropIndex("dbo.Exam", new[] { "NoticeId" });
            DropIndex("dbo.Exam", new[] { "ExamCoordinatorId" });
            DropIndex("dbo.Exam", new[] { "SessionId" });
            DropIndex("dbo.Exam", new[] { "AcademicYearId" });
            DropIndex("dbo.Exam", new[] { "SchoolId" });
            DropIndex("dbo.Exam", new[] { "ExamTypeId" });
            DropIndex("dbo.Session", new[] { "AcademicYearId" });
            DropIndex("dbo.Session", new[] { "ParentId" });
            DropIndex("dbo.StudentGroup", new[] { "ProgramBatchId" });
            DropIndex("dbo.StudentGroup", new[] { "SchoolId" });
            DropIndex("dbo.StudentGroup", new[] { "ParentId" });
            DropIndex("dbo.StudentGroupStudent", new[] { "StudentGroupId" });
            DropIndex("dbo.StudentGroupStudent", new[] { "StudentId" });
            DropIndex("dbo.Student", new[] { "UserId" });
            DropIndex("dbo.StudentBatch", new[] { "StudentId" });
            DropIndex("dbo.StudentBatch", new[] { "ProgramBatchId" });
            DropIndex("dbo.SubjectStructure", new[] { "SubjectId" });
            DropIndex("dbo.SubjectStructure", new[] { "SubYearId" });
            DropIndex("dbo.SubjectStructure", new[] { "YearId" });
            DropIndex("dbo.SubYear", new[] { "YearId" });
            DropIndex("dbo.SubYear", new[] { "ParentId" });
            DropIndex("dbo.Year", new[] { "ProgramId" });
            DropIndex("dbo.Program", new[] { "SchoolId" });
            DropIndex("dbo.ProgramBatch", new[] { "ProgramId" });
            DropIndex("dbo.ProgramBatch", new[] { "BatchId" });
            DropIndex("dbo.Batch", new[] { "SchoolId" });
            DropIndex("dbo.Batch", new[] { "AcademicYearId" });
            DropIndex("dbo.RunningClass", new[] { "AcademicYearId" });
            DropIndex("dbo.RunningClass", new[] { "SessionId" });
            DropIndex("dbo.RunningClass", new[] { "ProgramBatchId" });
            DropIndex("dbo.RunningClass", new[] { "YearId" });
            DropIndex("dbo.RunningClass", new[] { "SubYearId" });
            DropIndex("dbo.SubjectClass", new[] { "SubjectId" });
            DropIndex("dbo.SubjectClass", new[] { "SubjectStructureId" });
            DropIndex("dbo.SubjectClass", new[] { "RunningClassId" });
            DropIndex("dbo.UserClass", new[] { "RoleId" });
            DropIndex("dbo.UserClass", new[] { "UserId" });
            DropIndex("dbo.UserClass", new[] { "SubjectClassId" });
            DropIndex("dbo.ActivityGrading", new[] { "ObtainedGradeId" });
            DropIndex("dbo.ActivityGrading", new[] { "ModifiedById" });
            DropIndex("dbo.ActivityGrading", new[] { "GradedById" });
            DropIndex("dbo.ActivityGrading", new[] { "ActivityResourceId" });
            DropIndex("dbo.ActivityGrading", new[] { "UserClassId" });
            DropIndex("dbo.ActivityCompletion", new[] { "CompletionMarkedById" });
            DropIndex("dbo.ActivityCompletion", new[] { "ActivityResourceId" });
            DropIndex("dbo.ActivityCompletion", new[] { "UserId" });
            DropIndex("dbo.ActivityResource", new[] { "RestrictionId" });
            DropIndex("dbo.ActivityResource", new[] { "SubjectSectionId" });
            DropIndex("dbo.GradeRestriction", new[] { "ActivityResourceId" });
            DropIndex("dbo.GradeRestriction", new[] { "RestrictionId" });
            DropIndex("dbo.DateRestriction", new[] { "RestrictionId" });
            DropIndex("dbo.Restriction", new[] { "ParentId" });
            DropIndex("dbo.SubjectSection", new[] { "RestrictionId" });
            DropIndex("dbo.SubjectSection", new[] { "SubjectId" });
            DropIndex("dbo.SubjectCategory", new[] { "SchoolId" });
            DropIndex("dbo.Subject", new[] { "SubjectCategoryId" });
            DropIndex("dbo.UserFile", new[] { "SubjectId" });
            DropIndex("dbo.UserFile", new[] { "FolderId" });
            DropIndex("dbo.School", new[] { "SchoolTypeId" });
            DropIndex("dbo.Users", new[] { "UserImageId" });
            DropIndex("dbo.Users", new[] { "SchoolId" });
            DropIndex("dbo.Users", new[] { "GenderId" });
            DropIndex("dbo.Message", new[] { "ReceiverId" });
            DropIndex("dbo.Message", new[] { "SenderId" });
            DropIndex("dbo.Message", new[] { "RepliedToId" });
            DropForeignKey("dbo.NoticeNotification", "UserId", "dbo.Users");
            DropForeignKey("dbo.NoticeNotification", "NoticeId", "dbo.Notice");
            DropForeignKey("dbo.ModuleAccess", "RoleId", "dbo.Role");
            DropForeignKey("dbo.ModuleAccess", "ModuleId", "dbo.Module");
            DropForeignKey("dbo.Module", "ParentModuleId", "dbo.Module");
            DropForeignKey("dbo.UserLastLogin", "UserId", "dbo.Users");
            DropForeignKey("dbo.TeacherQualification", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Teacher", "UserId", "dbo.Users");
            DropForeignKey("dbo.SubjectGrouping", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.BatchGrouping", "BatchId", "dbo.Batch");
            DropForeignKey("dbo.BookAuthor", "BookId", "dbo.TextBook");
            DropForeignKey("dbo.TextBook", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.ExamSubjectExaminer", "ExaminerId", "dbo.Users");
            DropForeignKey("dbo.ExamSubjectExaminer", "ExamSubjectId", "dbo.ExamSubject");
            DropForeignKey("dbo.ExamSubject", "ExamOfClassId", "dbo.ExamOfClass");
            DropForeignKey("dbo.ExamSubject", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.ExamStudent", "ExamSubjectExaminerId", "dbo.ExamSubjectExaminer");
            DropForeignKey("dbo.ExamStudent", "ObtainedGradeId", "dbo.GradeValue");
            DropForeignKey("dbo.ExamStudent", "UserClassId", "dbo.UserClass");
            DropForeignKey("dbo.ExamStudent", "ExamSubjectId", "dbo.ExamSubject");
            DropForeignKey("dbo.FileResourceFiles", "SubFileId", "dbo.UserFile");
            DropForeignKey("dbo.FileResourceFiles", "FileResourceId", "dbo.FileResource");
            DropForeignKey("dbo.BookChapter", "ParentChapterId", "dbo.BookChapter");
            DropForeignKey("dbo.BookChapter", "BookId", "dbo.BookResource");
            DropForeignKey("dbo.ForumDiscussion", "PostedById", "dbo.Users");
            DropForeignKey("dbo.ForumDiscussion", "LastPostById", "dbo.Users");
            DropForeignKey("dbo.ForumDiscussion", "ForumActivityId", "dbo.ForumActivity");
            DropForeignKey("dbo.ForumDiscussion", "ParentDiscussionId", "dbo.ForumDiscussion");
            DropForeignKey("dbo.ChoiceUser", "UserId", "dbo.Users");
            DropForeignKey("dbo.ChoiceUser", "ChoiceOptionsId", "dbo.ChoiceOptions");
            DropForeignKey("dbo.ChoiceUser", "ChoiceActivityId", "dbo.ChoiceActivity");
            DropForeignKey("dbo.ChoiceOptions", "ChoiceActivityId", "dbo.ChoiceActivity");
            DropForeignKey("dbo.ActivityCompletionRestriction", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.ActivityCompletionRestriction", "ActivityId", "dbo.ActivityResource");
            DropForeignKey("dbo.Event", "PostedById", "dbo.Users");
            DropForeignKey("dbo.UserProfileRestriction", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.GroupRestriction", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.GroupRestriction", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.AssignmentSubmissionFiles", "UserFileId", "dbo.UserFile");
            DropForeignKey("dbo.AssignmentSubmissionFiles", "AssignmentSubmissionsId", "dbo.AssignmentSubmissions");
            DropForeignKey("dbo.GradeValue", "GradeId", "dbo.Grade");
            DropForeignKey("dbo.Grade", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Assignment", "GradeTypeId", "dbo.Grade");
            DropForeignKey("dbo.AssignmentSubmissions", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.AssignmentSubmissions", "UserClassId", "dbo.UserClass");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.Users");
            DropForeignKey("dbo.Role", "SchoolId", "dbo.School");
            DropForeignKey("dbo.UserClassGrouping", "GroupingId", "dbo.SubjectClassGrouping");
            DropForeignKey("dbo.UserClassGrouping", "UserClassId", "dbo.UserClass");
            DropForeignKey("dbo.SubjectClassGrouping", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.ActivityResourceView", "ActivityClassId", "dbo.ActivityClass");
            DropForeignKey("dbo.ActivityResourceView", "UserClassId", "dbo.UserClass");
            DropForeignKey("dbo.ActivityClass", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.ActivityClass", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.ExamOfClass", "RunningClassId", "dbo.RunningClass");
            DropForeignKey("dbo.ExamOfClass", "ExamId", "dbo.Exam");
            DropForeignKey("dbo.ExamType", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Exam", "NoticeId", "dbo.Notice");
            DropForeignKey("dbo.Exam", "ExamCoordinatorId", "dbo.Users");
            DropForeignKey("dbo.Exam", "SessionId", "dbo.Session");
            DropForeignKey("dbo.Exam", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.Exam", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Exam", "ExamTypeId", "dbo.ExamType");
            DropForeignKey("dbo.Session", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.Session", "ParentId", "dbo.Session");
            DropForeignKey("dbo.StudentGroup", "ProgramBatchId", "dbo.ProgramBatch");
            DropForeignKey("dbo.StudentGroup", "SchoolId", "dbo.School");
            DropForeignKey("dbo.StudentGroup", "ParentId", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentGroupStudent", "StudentGroupId", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentGroupStudent", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Student", "UserId", "dbo.Users");
            DropForeignKey("dbo.StudentBatch", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentBatch", "ProgramBatchId", "dbo.ProgramBatch");
            DropForeignKey("dbo.SubjectStructure", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectStructure", "SubYearId", "dbo.SubYear");
            DropForeignKey("dbo.SubjectStructure", "YearId", "dbo.Year");
            DropForeignKey("dbo.SubYear", "YearId", "dbo.Year");
            DropForeignKey("dbo.SubYear", "ParentId", "dbo.SubYear");
            DropForeignKey("dbo.Year", "ProgramId", "dbo.Program");
            DropForeignKey("dbo.Program", "SchoolId", "dbo.School");
            DropForeignKey("dbo.ProgramBatch", "ProgramId", "dbo.Program");
            DropForeignKey("dbo.ProgramBatch", "BatchId", "dbo.Batch");
            DropForeignKey("dbo.Batch", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Batch", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.RunningClass", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.RunningClass", "SessionId", "dbo.Session");
            DropForeignKey("dbo.RunningClass", "ProgramBatchId", "dbo.ProgramBatch");
            DropForeignKey("dbo.RunningClass", "YearId", "dbo.Year");
            DropForeignKey("dbo.RunningClass", "SubYearId", "dbo.SubYear");
            DropForeignKey("dbo.SubjectClass", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectClass", "SubjectStructureId", "dbo.SubjectStructure");
            DropForeignKey("dbo.SubjectClass", "RunningClassId", "dbo.RunningClass");
            DropForeignKey("dbo.UserClass", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserClass", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClass", "SubjectClassId", "dbo.SubjectClass");
            DropForeignKey("dbo.ActivityGrading", "ObtainedGradeId", "dbo.GradeValue");
            DropForeignKey("dbo.ActivityGrading", "ModifiedById", "dbo.Users");
            DropForeignKey("dbo.ActivityGrading", "GradedById", "dbo.Users");
            DropForeignKey("dbo.ActivityGrading", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.ActivityGrading", "UserClassId", "dbo.UserClass");
            DropForeignKey("dbo.ActivityCompletion", "CompletionMarkedById", "dbo.Users");
            DropForeignKey("dbo.ActivityCompletion", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.ActivityCompletion", "UserId", "dbo.Users");
            DropForeignKey("dbo.ActivityResource", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.ActivityResource", "SubjectSectionId", "dbo.SubjectSection");
            DropForeignKey("dbo.GradeRestriction", "ActivityResourceId", "dbo.ActivityResource");
            DropForeignKey("dbo.GradeRestriction", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.DateRestriction", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.Restriction", "ParentId", "dbo.Restriction");
            DropForeignKey("dbo.SubjectSection", "RestrictionId", "dbo.Restriction");
            DropForeignKey("dbo.SubjectSection", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectCategory", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Subject", "SubjectCategoryId", "dbo.SubjectCategory");
            DropForeignKey("dbo.UserFile", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.UserFile", "FolderId", "dbo.UserFile");
            DropForeignKey("dbo.School", "SchoolTypeId", "dbo.SchoolType");
            DropForeignKey("dbo.Users", "UserImageId", "dbo.UserFile");
            DropForeignKey("dbo.Users", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Users", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.Message", "ReceiverId", "dbo.Users");
            DropForeignKey("dbo.Message", "SenderId", "dbo.Users");
            DropForeignKey("dbo.Message", "RepliedToId", "dbo.Message");
            DropTable("dbo.NoticeNotification");
            DropTable("dbo.ModuleAccess");
            DropTable("dbo.Module");
            DropTable("dbo.Nation");
            DropTable("dbo.UserLastLogin");
            DropTable("dbo.TeacherQualification");
            DropTable("dbo.Teacher");
            DropTable("dbo.SubjectGrouping");
            DropTable("dbo.BatchGrouping");
            DropTable("dbo.BookAuthor");
            DropTable("dbo.TextBook");
            DropTable("dbo.ExamSubjectExaminer");
            DropTable("dbo.ExamSubject");
            DropTable("dbo.ExamStudent");
            DropTable("dbo.LabelResource");
            DropTable("dbo.PageResource");
            DropTable("dbo.FileResourceFiles");
            DropTable("dbo.FileResource");
            DropTable("dbo.UrlResource");
            DropTable("dbo.BookChapter");
            DropTable("dbo.BookResource");
            DropTable("dbo.ForumDiscussion");
            DropTable("dbo.ForumActivity");
            DropTable("dbo.ChoiceUser");
            DropTable("dbo.ChoiceOptions");
            DropTable("dbo.ChoiceActivity");
            DropTable("dbo.ActivityCompletionRestriction");
            DropTable("dbo.Event");
            DropTable("dbo.FileCategory");
            DropTable("dbo.SessionDefault");
            DropTable("dbo.UserProfileRestriction");
            DropTable("dbo.GroupRestriction");
            DropTable("dbo.AssignmentSubmissionFiles");
            DropTable("dbo.GradeValue");
            DropTable("dbo.Grade");
            DropTable("dbo.Assignment");
            DropTable("dbo.AssignmentSubmissions");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.UserClassGrouping");
            DropTable("dbo.SubjectClassGrouping");
            DropTable("dbo.ActivityResourceView");
            DropTable("dbo.ActivityClass");
            DropTable("dbo.Notice");
            DropTable("dbo.ExamOfClass");
            DropTable("dbo.ExamType");
            DropTable("dbo.Exam");
            DropTable("dbo.Session");
            DropTable("dbo.StudentGroup");
            DropTable("dbo.StudentGroupStudent");
            DropTable("dbo.Student");
            DropTable("dbo.StudentBatch");
            DropTable("dbo.SubjectStructure");
            DropTable("dbo.SubYear");
            DropTable("dbo.Year");
            DropTable("dbo.Program");
            DropTable("dbo.ProgramBatch");
            DropTable("dbo.Batch");
            DropTable("dbo.AcademicYear");
            DropTable("dbo.RunningClass");
            DropTable("dbo.SubjectClass");
            DropTable("dbo.UserClass");
            DropTable("dbo.ActivityGrading");
            DropTable("dbo.ActivityCompletion");
            DropTable("dbo.ActivityResource");
            DropTable("dbo.GradeRestriction");
            DropTable("dbo.DateRestriction");
            DropTable("dbo.Restriction");
            DropTable("dbo.SubjectSection");
            DropTable("dbo.SubjectCategory");
            DropTable("dbo.Subject");
            DropTable("dbo.UserFile");
            DropTable("dbo.SchoolType");
            DropTable("dbo.School");
            DropTable("dbo.Gender");
            DropTable("dbo.Users");
            DropTable("dbo.Message");
        }
    }
}
