namespace Academic.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_all_obsolete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoleCapability", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleCapability", "CapabilityId", "dbo.Capability");
            DropForeignKey("dbo.UserDivision", "UsersId", "dbo.Users");
            DropForeignKey("dbo.UserDivision", "DivisionId", "dbo.Division");
            DropForeignKey("dbo.Division", "SchoolId", "dbo.School");
            DropForeignKey("dbo.Division", "ParentDivisionId", "dbo.Division");
            DropForeignKey("dbo.Study", "StudentGroupId", "dbo.StudentGroup");
            DropForeignKey("dbo.Study", "YearId", "dbo.Year");
            DropForeignKey("dbo.Study", "SectionId", "dbo.SubYear");
            DropForeignKey("dbo.Study", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.Study", "SessionId", "dbo.Session");
            DropForeignKey("dbo.StudentClass", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentClass", "StudentGroupId", "dbo.StudentGroup");
            DropForeignKey("dbo.StudentClass", "RunningClassId", "dbo.RunningClass");
            DropForeignKey("dbo.ExamStudent", "StudentClass_Id", "dbo.StudentClass");
            DropForeignKey("dbo.ExamSubjectExaminer", "TeacherClass_Id", "dbo.TeacherClass");
            DropForeignKey("dbo.SubjectSubscription", "StudentClassId", "dbo.StudentClass");
            DropForeignKey("dbo.StudentsOpinionAboutSubject", "SubjectSubscriptionId", "dbo.SubjectSubscription");
            DropForeignKey("dbo.TeacherClass", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Teacher", "TeacherJobTitleId", "dbo.TeacherJobTitle");
            DropForeignKey("dbo.Teach", "AcademicYearId", "dbo.AcademicYear");
            DropForeignKey("dbo.Teach", "SessionId", "dbo.Session");
            DropForeignKey("dbo.Teach", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Teach", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.Attendance", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Attendance", "PresenceStatusId", "dbo.PresenceStatus");
            DropForeignKey("dbo.Attendance", "AttendanceDayId", "dbo.AttendanceDay");
            DropForeignKey("dbo.AttendanceDay", "TeachId", "dbo.Teach");
            DropForeignKey("dbo.Fee", "Scholarship_Id", "dbo.Scholarship");
            DropForeignKey("dbo.Fee", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentNotification", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentPreviousStudies", "StudentId", "dbo.Student");
            DropForeignKey("dbo.SubjectGroup", "ProgramId", "dbo.Program");
            DropForeignKey("dbo.SubjectGroup", "YearId", "dbo.Year");
            DropForeignKey("dbo.SubjectGroup", "SubYearId", "dbo.SubYear");
            DropForeignKey("dbo.SubjectGroupSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.SubjectGroupSubject", "SubjectGroupId", "dbo.SubjectGroup");
            DropForeignKey("dbo.RegularSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.RegularSubject", "YearId", "dbo.Year");
            DropForeignKey("dbo.RegularSubject", "SubYearId", "dbo.SubYear");
            DropForeignKey("dbo.Appointment", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.TeacherNotification", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.RelationShip", "RelationId", "dbo.Relation");
            DropForeignKey("dbo.UserTransfer", "ApprovedById", "dbo.Users");
            DropForeignKey("dbo.UserTransfer", "FromSchoolId", "dbo.School");
            DropForeignKey("dbo.UserTransfer", "ToSchoolId", "dbo.School");
            DropForeignKey("dbo.UserType", "SchoolId", "dbo.School");
            DropForeignKey("dbo.ModuleAccess", "ModuleAccessPermissionId", "dbo.ModuleAccessPermission");
            DropForeignKey("dbo.ModuleModuleAccess", "Module_Id", "dbo.Module");
            DropForeignKey("dbo.ModuleModuleAccess", "ModuleAccess_Id", "dbo.ModuleAccess");
            DropIndex("dbo.RoleCapability", new[] { "RoleId" });
            DropIndex("dbo.RoleCapability", new[] { "CapabilityId" });
            DropIndex("dbo.UserDivision", new[] { "UsersId" });
            DropIndex("dbo.UserDivision", new[] { "DivisionId" });
            DropIndex("dbo.Division", new[] { "SchoolId" });
            DropIndex("dbo.Division", new[] { "ParentDivisionId" });
            DropIndex("dbo.Study", new[] { "StudentGroupId" });
            DropIndex("dbo.Study", new[] { "YearId" });
            DropIndex("dbo.Study", new[] { "SectionId" });
            DropIndex("dbo.Study", new[] { "AcademicYearId" });
            DropIndex("dbo.Study", new[] { "SessionId" });
            DropIndex("dbo.StudentClass", new[] { "StudentId" });
            DropIndex("dbo.StudentClass", new[] { "StudentGroupId" });
            DropIndex("dbo.StudentClass", new[] { "RunningClassId" });
            DropIndex("dbo.ExamStudent", new[] { "StudentClass_Id" });
            DropIndex("dbo.ExamSubjectExaminer", new[] { "TeacherClass_Id" });
            DropIndex("dbo.SubjectSubscription", new[] { "StudentClassId" });
            DropIndex("dbo.StudentsOpinionAboutSubject", new[] { "SubjectSubscriptionId" });
            DropIndex("dbo.TeacherClass", new[] { "TeacherId" });
            DropIndex("dbo.Teacher", new[] { "TeacherJobTitleId" });
            DropIndex("dbo.Teach", new[] { "AcademicYearId" });
            DropIndex("dbo.Teach", new[] { "SessionId" });
            DropIndex("dbo.Teach", new[] { "TeacherId" });
            DropIndex("dbo.Teach", new[] { "SubjectId" });
            DropIndex("dbo.Attendance", new[] { "StudentId" });
            DropIndex("dbo.Attendance", new[] { "PresenceStatusId" });
            DropIndex("dbo.Attendance", new[] { "AttendanceDayId" });
            DropIndex("dbo.AttendanceDay", new[] { "TeachId" });
            DropIndex("dbo.Fee", new[] { "Scholarship_Id" });
            DropIndex("dbo.Fee", new[] { "StudentId" });
            DropIndex("dbo.StudentNotification", new[] { "StudentId" });
            DropIndex("dbo.StudentPreviousStudies", new[] { "StudentId" });
            DropIndex("dbo.SubjectGroup", new[] { "ProgramId" });
            DropIndex("dbo.SubjectGroup", new[] { "YearId" });
            DropIndex("dbo.SubjectGroup", new[] { "SubYearId" });
            DropIndex("dbo.SubjectGroupSubject", new[] { "SubjectId" });
            DropIndex("dbo.SubjectGroupSubject", new[] { "SubjectGroupId" });
            DropIndex("dbo.RegularSubject", new[] { "SubjectId" });
            DropIndex("dbo.RegularSubject", new[] { "YearId" });
            DropIndex("dbo.RegularSubject", new[] { "SubYearId" });
            DropIndex("dbo.Appointment", new[] { "TeacherId" });
            DropIndex("dbo.TeacherNotification", new[] { "TeacherId" });
            DropIndex("dbo.RelationShip", new[] { "RelationId" });
            DropIndex("dbo.UserTransfer", new[] { "ApprovedById" });
            DropIndex("dbo.UserTransfer", new[] { "FromSchoolId" });
            DropIndex("dbo.UserTransfer", new[] { "ToSchoolId" });
            DropIndex("dbo.UserType", new[] { "SchoolId" });
            DropIndex("dbo.ModuleAccess", new[] { "ModuleAccessPermissionId" });
            DropIndex("dbo.ModuleModuleAccess", new[] { "Module_Id" });
            DropIndex("dbo.ModuleModuleAccess", new[] { "ModuleAccess_Id" });
            DropColumn("dbo.ExamStudent", "StudentClass_Id");
            DropColumn("dbo.ExamSubjectExaminer", "TeacherClass_Id");
            DropTable("dbo.RoleCapability");
            DropTable("dbo.Capability");
            DropTable("dbo.UserDivision");
            DropTable("dbo.Division");
            DropTable("dbo.Study");
            DropTable("dbo.StudentClass");
            DropTable("dbo.SubjectSubscription");
            DropTable("dbo.StudentsOpinionAboutSubject");
            DropTable("dbo.TeacherClass");
            DropTable("dbo.Teach");
            DropTable("dbo.TeacherJobTitle");
            DropTable("dbo.Attendance");
            DropTable("dbo.PresenceStatus");
            DropTable("dbo.AttendanceDay");
            DropTable("dbo.Admission");
            DropTable("dbo.Fee");
            DropTable("dbo.Scholarship");
            DropTable("dbo.StudentNotification");
            DropTable("dbo.StudentPreviousStudies");
            DropTable("dbo.StudentTransfer");
            DropTable("dbo.StudentTransferType");
            DropTable("dbo.SubjectGroup");
            DropTable("dbo.SubjectGroupSubject");
            DropTable("dbo.RegularSubject");
            DropTable("dbo.StudentSubject");
            DropTable("dbo.Appointment");
            DropTable("dbo.TeacherExperience");
            DropTable("dbo.TeacherNotification");
            DropTable("dbo.Relation");
            DropTable("dbo.RelationShip");
            DropTable("dbo.UserTransfer");
            DropTable("dbo.UserType");
            DropTable("dbo.ModuleAccessPermission");
            DropTable("dbo.ModuleAccess");
            DropTable("dbo.Module");
            DropTable("dbo.ModuleModuleAccess");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ModuleModuleAccess",
                c => new
                    {
                        Module_Id = c.Int(nullable: false),
                        ModuleAccess_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Module_Id, t.ModuleAccess_Id });
            
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
                "dbo.ModuleAccess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ModuleAccessPermissionId = c.Int(nullable: false),
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
                "dbo.UserType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SchoolId = c.Int(),
                        Void = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Appointment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        AppointedDate = c.DateTime(nullable: false),
                        SchoolId = c.Int(nullable: false),
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                "dbo.AttendanceDay",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TeachId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Attendance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        PresenceStatusId = c.Int(nullable: false),
                        AttendanceDayId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentsOpinionAboutSubject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectSubscriptionId = c.Int(nullable: false),
                        Rating = c.Byte(),
                        Opinion = c.String(),
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ExamSubjectExaminer", "TeacherClass_Id", c => c.Int());
            AddColumn("dbo.ExamStudent", "StudentClass_Id", c => c.Int());
            CreateIndex("dbo.ModuleModuleAccess", "ModuleAccess_Id");
            CreateIndex("dbo.ModuleModuleAccess", "Module_Id");
            CreateIndex("dbo.ModuleAccess", "ModuleAccessPermissionId");
            CreateIndex("dbo.UserType", "SchoolId");
            CreateIndex("dbo.UserTransfer", "ToSchoolId");
            CreateIndex("dbo.UserTransfer", "FromSchoolId");
            CreateIndex("dbo.UserTransfer", "ApprovedById");
            CreateIndex("dbo.RelationShip", "RelationId");
            CreateIndex("dbo.TeacherNotification", "TeacherId");
            CreateIndex("dbo.Appointment", "TeacherId");
            CreateIndex("dbo.RegularSubject", "SubYearId");
            CreateIndex("dbo.RegularSubject", "YearId");
            CreateIndex("dbo.RegularSubject", "SubjectId");
            CreateIndex("dbo.SubjectGroupSubject", "SubjectGroupId");
            CreateIndex("dbo.SubjectGroupSubject", "SubjectId");
            CreateIndex("dbo.SubjectGroup", "SubYearId");
            CreateIndex("dbo.SubjectGroup", "YearId");
            CreateIndex("dbo.SubjectGroup", "ProgramId");
            CreateIndex("dbo.StudentPreviousStudies", "StudentId");
            CreateIndex("dbo.StudentNotification", "StudentId");
            CreateIndex("dbo.Fee", "StudentId");
            CreateIndex("dbo.Fee", "Scholarship_Id");
            CreateIndex("dbo.AttendanceDay", "TeachId");
            CreateIndex("dbo.Attendance", "AttendanceDayId");
            CreateIndex("dbo.Attendance", "PresenceStatusId");
            CreateIndex("dbo.Attendance", "StudentId");
            CreateIndex("dbo.Teach", "SubjectId");
            CreateIndex("dbo.Teach", "TeacherId");
            CreateIndex("dbo.Teach", "SessionId");
            CreateIndex("dbo.Teach", "AcademicYearId");
            CreateIndex("dbo.Teacher", "TeacherJobTitleId");
            CreateIndex("dbo.TeacherClass", "TeacherId");
            CreateIndex("dbo.StudentsOpinionAboutSubject", "SubjectSubscriptionId");
            CreateIndex("dbo.SubjectSubscription", "StudentClassId");
            CreateIndex("dbo.ExamSubjectExaminer", "TeacherClass_Id");
            CreateIndex("dbo.ExamStudent", "StudentClass_Id");
            CreateIndex("dbo.StudentClass", "RunningClassId");
            CreateIndex("dbo.StudentClass", "StudentGroupId");
            CreateIndex("dbo.StudentClass", "StudentId");
            CreateIndex("dbo.Study", "SessionId");
            CreateIndex("dbo.Study", "AcademicYearId");
            CreateIndex("dbo.Study", "SectionId");
            CreateIndex("dbo.Study", "YearId");
            CreateIndex("dbo.Study", "StudentGroupId");
            CreateIndex("dbo.Division", "ParentDivisionId");
            CreateIndex("dbo.Division", "SchoolId");
            CreateIndex("dbo.UserDivision", "DivisionId");
            CreateIndex("dbo.UserDivision", "UsersId");
            CreateIndex("dbo.RoleCapability", "CapabilityId");
            CreateIndex("dbo.RoleCapability", "RoleId");
            AddForeignKey("dbo.ModuleModuleAccess", "ModuleAccess_Id", "dbo.ModuleAccess", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ModuleModuleAccess", "Module_Id", "dbo.Module", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ModuleAccess", "ModuleAccessPermissionId", "dbo.ModuleAccessPermission", "Id");
            AddForeignKey("dbo.UserType", "SchoolId", "dbo.School", "Id");
            AddForeignKey("dbo.UserTransfer", "ToSchoolId", "dbo.School", "Id");
            AddForeignKey("dbo.UserTransfer", "FromSchoolId", "dbo.School", "Id");
            AddForeignKey("dbo.UserTransfer", "ApprovedById", "dbo.Users", "Id");
            AddForeignKey("dbo.RelationShip", "RelationId", "dbo.Relation", "Id");
            AddForeignKey("dbo.TeacherNotification", "TeacherId", "dbo.Teacher", "Id");
            AddForeignKey("dbo.Appointment", "TeacherId", "dbo.Teacher", "Id");
            AddForeignKey("dbo.RegularSubject", "SubYearId", "dbo.SubYear", "Id");
            AddForeignKey("dbo.RegularSubject", "YearId", "dbo.Year", "Id");
            AddForeignKey("dbo.RegularSubject", "SubjectId", "dbo.Subject", "Id");
            AddForeignKey("dbo.SubjectGroupSubject", "SubjectGroupId", "dbo.SubjectGroup", "Id");
            AddForeignKey("dbo.SubjectGroupSubject", "SubjectId", "dbo.Subject", "Id");
            AddForeignKey("dbo.SubjectGroup", "SubYearId", "dbo.SubYear", "Id");
            AddForeignKey("dbo.SubjectGroup", "YearId", "dbo.Year", "Id");
            AddForeignKey("dbo.SubjectGroup", "ProgramId", "dbo.Program", "Id");
            AddForeignKey("dbo.StudentPreviousStudies", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.StudentNotification", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.Fee", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.Fee", "Scholarship_Id", "dbo.Scholarship", "Id");
            AddForeignKey("dbo.AttendanceDay", "TeachId", "dbo.Teach", "Id");
            AddForeignKey("dbo.Attendance", "AttendanceDayId", "dbo.AttendanceDay", "Id");
            AddForeignKey("dbo.Attendance", "PresenceStatusId", "dbo.PresenceStatus", "Id");
            AddForeignKey("dbo.Attendance", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.Teach", "SubjectId", "dbo.Subject", "Id");
            AddForeignKey("dbo.Teach", "TeacherId", "dbo.Teacher", "Id");
            AddForeignKey("dbo.Teach", "SessionId", "dbo.Session", "Id");
            AddForeignKey("dbo.Teach", "AcademicYearId", "dbo.AcademicYear", "Id");
            AddForeignKey("dbo.Teacher", "TeacherJobTitleId", "dbo.TeacherJobTitle", "Id");
            AddForeignKey("dbo.TeacherClass", "TeacherId", "dbo.Teacher", "Id");
            AddForeignKey("dbo.StudentsOpinionAboutSubject", "SubjectSubscriptionId", "dbo.SubjectSubscription", "Id");
            AddForeignKey("dbo.SubjectSubscription", "StudentClassId", "dbo.StudentClass", "Id");
            AddForeignKey("dbo.ExamSubjectExaminer", "TeacherClass_Id", "dbo.TeacherClass", "Id");
            AddForeignKey("dbo.ExamStudent", "StudentClass_Id", "dbo.StudentClass", "Id");
            AddForeignKey("dbo.StudentClass", "RunningClassId", "dbo.RunningClass", "Id");
            AddForeignKey("dbo.StudentClass", "StudentGroupId", "dbo.StudentGroup", "Id");
            AddForeignKey("dbo.StudentClass", "StudentId", "dbo.Student", "Id");
            AddForeignKey("dbo.Study", "SessionId", "dbo.Session", "Id");
            AddForeignKey("dbo.Study", "AcademicYearId", "dbo.AcademicYear", "Id");
            AddForeignKey("dbo.Study", "SectionId", "dbo.SubYear", "Id");
            AddForeignKey("dbo.Study", "YearId", "dbo.Year", "Id");
            AddForeignKey("dbo.Study", "StudentGroupId", "dbo.StudentGroup", "Id");
            AddForeignKey("dbo.Division", "ParentDivisionId", "dbo.Division", "Id");
            AddForeignKey("dbo.Division", "SchoolId", "dbo.School", "Id");
            AddForeignKey("dbo.UserDivision", "DivisionId", "dbo.Division", "Id");
            AddForeignKey("dbo.UserDivision", "UsersId", "dbo.Users", "Id");
            AddForeignKey("dbo.RoleCapability", "CapabilityId", "dbo.Capability", "Id");
            AddForeignKey("dbo.RoleCapability", "RoleId", "dbo.Role", "Id");
        }
    }
}
