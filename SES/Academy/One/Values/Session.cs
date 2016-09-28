using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using Academic.DbHelper;

namespace One.Values
{
    public class Session
    {
        public static Dictionary<string, int> CustomSession = new Dictionary<string, int>()
        {
           {"InstitutionId",4}
           ,{"SchoolId",15}
           ,{"UserId",5}
           ,{"AcademicYearId",1}
           ,{"SessionId",2}
        };

        public static int InstitutionId
        {
            get { return CustomSession["InstitutionId"]; }
            set { CustomSession["InstitutionId"] = value; }
        }

        public static int SchoolId
        {
            get { return CustomSession["SchoolId"]; }
            set { CustomSession["SchoolId"] = value; }
        }
        public static int UserId
        {
            get { return CustomSession["UserId"]; }
            set { CustomSession["UserId"] = value; }
        }
        public static int AcademicYearId
        {
            get { return CustomSession["AcademicYearId"]; }
            set { CustomSession["AcademicYearId"] = value; }
        }
        public static int SessionId
        {
            get { return CustomSession["SessionId"]; }
            set { CustomSession["SessionId"] = value; }
        }

        public static int GetSchool(HttpSessionState session)
        {
            
            int sch = (int)
                            (session["SchoolId"] ?? 1);
            return sch;
        }

        public static void SetSchool( HttpSessionState session, int value)
        {
            session["SchoolId"] = value;
        }

        public static int GetUser( HttpSessionState session)
        {
            
            int sch = (int)
                            (session["UserId"] ?? 5);//1
            return sch;
        }
        public static void SetUser(ref HttpSessionState session, int value)
        {
            session["UserId"] = value;
        }

        public static int GetAcademicYear( HttpSessionState session)
        {
            return (int) (session["AcademicYearId"]??1);//8 is "This is fourth" academci year
        }

        public static void SetAcademicYear(ref HttpSessionState session, int value)
        {
            session["AcademicYearId"] = value;
        }

        public static int GetSession( HttpSessionState session)
        {
            return (int)(session["SessionId"] ?? 1);
        }

        public static void SetSession( HttpSessionState session, int value)
        {
            session["SessionId"] = value;
        }




        public static List<string> GetUserCapability(HttpSessionState session)
        {
            return (List<string>)(session["UserCapability"]??new List<string>(){""});
        }

        public static void SetUserCapability(HttpSessionState session, List<string> capabilities)
        {
            session["UserCapability"] = capabilities;
        }

        public static int GetStudent(ref HttpSessionState session)
        {
            return (int)(session["StudentId"] ?? 5);
        }

        public static void SetStudent(ref HttpSessionState session, int value)
        {
            session["StudentId"] = value;
        }





        //======================Left DashSideBar==========================//
        public static List<TextAndLink> GetTeacherSideBarItemsAndLinks()
        {
            
            var list = new List<TextAndLink>()
            {
                
            };
            return list;
        }

        public static List<TextAndLink> GetAdminSideBarItemsAndLinks()
        {
            var list = new List<TextAndLink>()
            {
                new TextAndLink(){Link = "~/Views/User/Create.aspx", Text = "Create User"},
                //new TextAndLink(){Link = "~/Views/Exam/Create.aspx", Text = "Create Exam"},
                //new TextAndLink(){Link = "~/Views/Academy/AcademicYear/Create.aspx", Text = "Create Academic Year"},
                //new TextAndLink(){Link = "~/Views/Academy/Session/Create.aspx", Text = "Create Session"},
                //new TextAndLink(){Link = "~/Views/Office/School/Create.aspx", Text = "Create School"},
                //new TextAndLink(){Link = "~/Views/Structure/Faculty/Create.aspx", Text = "Create Faculty"},
            };
            return list;
        }

        public static List<TreeNode> GetAdminTreeNodes(ref TreeNode owner)
        {
            //TreeNode owner = new TreeNode("Administration");
            owner.Expanded = true;
            var profile = new TreeNode("Profile");

            //===========School Structure =======//
            var school = new TreeNode("School", "~/Views/Office/School/Dashboard.aspx", "", "", "");
            school.Expanded = false;
            var level = new TreeNode("Level", "~/Views/Structure/Level/Create.aspx", "", "", "");
            var faculty = new TreeNode("Faculty", "~/Views/Structure/Faculty/Create.aspx", "", "", "");
            var program = new TreeNode("Program", "~/Views/Structure/Program/Create.aspx", "", "", "");
            var year = new TreeNode("Year", "~/Views/Structure/Year/Create.aspx", "", "", "");
            var section = new TreeNode("Section", "~/Views/Structure/Section/Create.aspx", "", "", "");
            
            school.ChildNodes.Add(level);
            school.ChildNodes.Add(faculty);
            school.ChildNodes.Add(program);
            school.ChildNodes.Add(year);
            school.ChildNodes.Add(section);


            //=====================academic structture ==============//
            var strc = new TreeNode("Academic Structure", "", "", "", "");
            var ayear = new TreeNode("Academic Year", "~/Views/Academy/List.aspx", "", "","");
            var ayearCrate = new TreeNode("Create","","","~/Views/Academy/AcademicYear/Create.aspx","");

            ayear.ChildNodes.Add(ayearCrate);

            var asession = new TreeNode("Academic Session", "~/Views/Academy/List.aspx", "", "", "");
            var asesCreate = new TreeNode("Create", "~/Views/Academy/Session/Create.aspx","", "", "");
            asession.ChildNodes.Add(asesCreate);

            strc.Expanded = false;
            strc.ChildNodes.Add(ayear);
            strc.ChildNodes.Add(asession);

            //=====================Running Sessions================//
            
            var currentClasses = new TreeNode("Currently Running Classes", "~/Views/Academy/CurrentAcademicYear/ListDisplay/DisplayList.aspx","","","");
            var addClass = new TreeNode("Add Classes", "~/Views/Academy/CurrentAcademicYear/AddClassesToAcademicSession.aspx","","","");
            var structureList = new TreeNode("List", "~/Views/Academy/CurrentAcademicYear/StructureList.aspx");

            currentClasses.ChildNodes.Add(addClass);
            currentClasses.ChildNodes.Add(structureList);


            //====================user nodes========================//
            TreeNode user = new TreeNode("User","~/View/User/List.aspx","","","");
            user.Expanded = false;
            //var userList = new TreeNode("User List", "", "", "~/Views/User/List.aspx", "");
            var userCreate = new TreeNode("Create User", "~/Views/User/Create.aspx","", "",  "");
            var userRoles = new TreeNode("Assign Roles", "~/Views/Role/Assign.aspx", "", "", "");
            //user.ChildNodes.Add(userList);
            user.ChildNodes.Add(userCreate);
            user.ChildNodes.Add(userRoles);

            //=====================structure =============================
            var struc = new TreeNode("Structure","#");
            var strucCreate = new TreeNode("Create Structure", "~/Views/Structure/All/Create.aspx");
            struc.ChildNodes.Add(strucCreate);

            //========================roles=========================//
            var role = new TreeNode("Roles", "~/Views/Role/Dashboard.aspx", "","", "");
            role.Expanded = false;
            var roleAdd = new TreeNode("New Role", "~/Views/Role/Create.aspx", "", "", "");
            var roleUsers = new TreeNode("Define Roles", "~/Views/Role/Assign.aspx", "", "", "");
            role.ChildNodes.Add(roleAdd);
            role.ChildNodes.Add(roleUsers);
            ///Views/Structure/All/Create.aspx

            var course = new TreeNode("Courses", "~/Views/Course/List.aspx", "", "", "");
            course.Expanded = false;
            //var courseList = new TreeNode("List Courses", "", "", "~/Views/Office/School/Dashboard.aspx", "");
            var courseAdd = new TreeNode("New Course", "~/Views/Course/CourseEntryForm.aspx", "", "", "");
            var courseCategories = new TreeNode("Course Categories", "~/Views/Course/Category/List.aspx", "", "", "");
            //course.ChildNodes.Add(courseList);
            course.ChildNodes.Add(courseAdd);
            course.ChildNodes.Add(courseCategories);


            //all add to owner node
            owner.ChildNodes.Add(school);
            owner.ChildNodes.Add(strc);
            owner.ChildNodes.Add(user);
            owner.ChildNodes.Add(role);
            owner.ChildNodes.Add(course);
            owner.ChildNodes.Add(currentClasses);
            owner.ChildNodes.Add(struc);
            
            var listNodes = new List<TreeNode>()
            {
                school,strc,user,role,course,currentClasses,struc
            };
            return listNodes;
        } 
        //===============================================================//
    }
}