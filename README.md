## LMS (Learning Management System)

Online e-learning platform with *Program and Batch Management*, *Course and Material Management*, *Users and Role Management*, *Academic Year and Session Management*

Specs:
- ASP.NET Web App
- .NET Framework 4.5, 
- SQL Server 

---
Running the application:
1. Clone this repository 
2. Open the project in Visual Studio 2017 or later
3. Right click on solution and click "Restore NuGet packages"
4. Make project "One" as default project
5. Update connection string in One > Web.config file 
6. Go to "Package Manager Console" and choose Academic.Database as  default project and execute below command :
	*`update-database -verbose`*
7. Finally, run the project.
---
Developed by *Shree Krishna Upadhyaya* as final year project for completion of Bachelor of Computer Engineering, July 2017, Nepal Engineering College, Pokhara University, Nepal.

Designed as per the structure applied in Nepal Engineering College for Academic Year, Semesters, Programs and Batches.

Similar in concept to <a href="https://moodle.org/">moodle</a>, <a href="https://school.moodledemo.net/">moodle demo</a>.

