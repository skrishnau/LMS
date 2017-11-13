--delete for only academic session related
--select * from runningclass
delete from ActivityResourceView

delete from AssignmentSubmissions

delete from ActivityGrading
delete from AssignmentSubmissionFiles
delete from ActivityClass
delete from Report
delete from userclass 

delete from subjectclass where isregular=1
delete from runningclass
delete from StudentBatch
delete from ProgramBatch
delete from batch
delete from Session
delete from academicyear


--delete of all
select * from school

delete from userclass
delete from ExamSubject
delete from subjectClass
delete from ExamOfClass
delete from RunningClass
delete from SubjectStructure
delete from subyear
delete from year
delete from StudentBatch
delete from ProgramBatch
delete from program
delete from faculty
delete from level
delete from Batch
delete from GradeValue
delete from Grade
delete from exam
delete from ExamType
delete from NoticeNotification
delete from event
delete from UserRole
delete from student
delete from users
delete from SubjectSection
delete from Subject
delete from SubjectCategory
delete from school

