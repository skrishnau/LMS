--(schoolId,description,void,displayName,RoleName)


--====================== ROLES =================================--
insert into role (Void,Description, SchoolId, DisplayName,RoleName)  values(null,'',null,'Manager','manager')
insert into role (Void,Description, SchoolId, DisplayName,RoleName)  values(null,'',null,'Teacher','teacher')
insert into role (Void,Description, SchoolId, DisplayName,RoleName)  values(null,'',null,'Student','student')
insert into role (Void,Description, SchoolId, DisplayName,RoleName)  values(null,'',null,'Admin','admin')
insert into role (Void,Description, SchoolId, DisplayName,RoleName)  values(null,'',null,'Course Editor','course-editor')
insert into role (Void,Description, SchoolId, DisplayName,RoleName)  values(null,'',null,'Guest','guest')
insert into role (Void,Description, SchoolId, DisplayName,RoleName)  values(null,'',null,'Parent','parent')
insert into role (Void,Description, SchoolId, DisplayName,RoleName)  values(null,'',null,'Notifier','notifier')
insert into role (Void,Description, SchoolId, DisplayName,RoleName)  values(null,'',null,'Organizer','organizer')
insert into role (Void,Description, SchoolId, DisplayName,RoleName)  values(null,'Admitter is one who (can) admits users. Admitter is responsible to insert new students/teachers in the system.',null,'Admitter','admitter')


--====================== School Types =================================--
insert into schooltype(Name) values('Graduate')
insert into schooltype(Name) values('Undergraduate')
insert into schooltype(Name) values('Higher secondary')
insert into schooltype(Name) values('Secondary')


--====================== Grad type =================================--
--please note the depensency of Grade and GradeValues

GO
SET IDENTITY_INSERT [dbo].[Grade] ON 

GO
INSERT [dbo].[Grade] ([Id], [Name], [Description], [GradeValueIsInPercentOrPostition], [TotalMaxValue], [TotalMinValue], [MinimumPassValue], [SchoolId]
	, [RangeOrValue], [Void]) VALUES (1, N'Range', N'', NULL, 100, 0, 40, NULL, 0, NULL)
GO
INSERT [dbo].[Grade] ([Id], [Name], [Description], [GradeValueIsInPercentOrPostition], [TotalMaxValue], [TotalMinValue], [MinimumPassValue], [SchoolId]
	, [RangeOrValue], [Void]) VALUES (2, N'Letter Grading', N'', 0, 100, 0, 40, NULL, 1, NULL)
GO
SET IDENTITY_INSERT [dbo].[Grade] OFF
GO
SET IDENTITY_INSERT [dbo].[GradeValue] ON 
go
INSERT [dbo].[GradeValue] ([Id], [Value], [IsFailGrade], [EquivalentPercentOrPostition], [GradeId], [Void]) VALUES (6, N'F', 0, 0, 2, NULL)
GO
INSERT [dbo].[GradeValue] ([Id], [Value], [IsFailGrade], [EquivalentPercentOrPostition], [GradeId], [Void]) VALUES (7, N'C-', 0, 4, 2, NULL)
GO
INSERT [dbo].[GradeValue] ([Id], [Value], [IsFailGrade], [EquivalentPercentOrPostition], [GradeId], [Void]) VALUES (8, N'C', 0, 5, 2, NULL)
GO
INSERT [dbo].[GradeValue] ([Id], [Value], [IsFailGrade], [EquivalentPercentOrPostition], [GradeId], [Void]) VALUES (9, N'C+', 0, 6, 2, NULL)
GO
INSERT [dbo].[GradeValue] ([Id], [Value], [IsFailGrade], [EquivalentPercentOrPostition], [GradeId], [Void]) VALUES (10, N'B-', 0, 7, 2, NULL)
GO
INSERT [dbo].[GradeValue] ([Id], [Value], [IsFailGrade], [EquivalentPercentOrPostition], [GradeId], [Void]) VALUES (11, N'B', 0, 8, 2, NULL)
GO
INSERT [dbo].[GradeValue] ([Id], [Value], [IsFailGrade], [EquivalentPercentOrPostition], [GradeId], [Void]) VALUES (12, N'B+', 0, 9, 2, NULL)
GO
INSERT [dbo].[GradeValue] ([Id], [Value], [IsFailGrade], [EquivalentPercentOrPostition], [GradeId], [Void]) VALUES (13, N'A-', 0, 10, 2, NULL)
GO
INSERT [dbo].[GradeValue] ([Id], [Value], [IsFailGrade], [EquivalentPercentOrPostition], [GradeId], [Void]) VALUES (14, N'A', 0, 11, 2, NULL)
GO
INSERT [dbo].[GradeValue] ([Id], [Value], [IsFailGrade], [EquivalentPercentOrPostition], [GradeId], [Void]) VALUES (15, N'A+', 0, 12, 2, NULL)
GO

SET IDENTITY_INSERT [dbo].[GradeValue] OFF
GO



--====================== Default Folders =================================--

--add user photo folder
INSERT INTO [dbo].[UserFile] ([DisplayName],[FileName],[FileDirectory],[FileSizeInBytes],[FileType],[CreatedDate],[ModifiedDate],[CreatedBy],[ModifiedBy],[Void],[IconPath],[SubjectId],[Discriminator],[IsServerFile],[IsFolder],[FolderId],[IsConstantAndNotEditable]) VALUES('User Photos',null,null,0,'Folder',GETDATE(),null,null,null,null,null,null,'UserFile',1,1,null,1)




--====================== ROLES =================================--




--====================== ROLES =================================--




--====================== ROLES =================================--




--====================== ROLES =================================--




--====================== ROLES =================================--


