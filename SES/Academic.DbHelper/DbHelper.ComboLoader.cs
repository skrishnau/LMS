using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Academic.DbEntities.Office;
using Academic.DbEntities.Structure;
using Academic.DbEntities.User;
using Academic.ViewModel;

namespace Academic.DbHelper
{
    public partial class DbHelper
    {
        public static class ComboLoader
        {

            #region School and SchoolType Loading functions

            public static void LoadSchool(ref DropDownList cmbSchool, int instId)
            {
                cmbSchool.DataTextField = "Name";
                cmbSchool.DataValueField = "Id";
                using (var helper = new DbHelper.Office())
                {
                    var schools = helper.GetSchoolForCombo(instId);
                    if (schools.Count > 0)
                        schools.Insert(0, new IdAndName() { Id = 0, Name = "--Select One--" });
                    cmbSchool.DataSource = schools;
                    cmbSchool.DataBind();
                }
            }
            public static void LoadSchool(ref DropDownList cmbSchool, int instId, bool DefaultSelectionEmpty)
            {
                cmbSchool.DataTextField = "Name";
                cmbSchool.DataValueField = "Id";
                using (var helper = new DbHelper.Office())
                {
                    var schools = helper.GetSchoolForCombo(instId);
                    if (schools.Count > 0)
                        schools.Insert(0, new IdAndName() { Id = 0, Name = (DefaultSelectionEmpty) ? "" : "--Select One--" });

                    cmbSchool.DataSource = schools;
                    cmbSchool.DataBind();
                    if (DefaultSelectionEmpty)
                        cmbSchool.Text = "";
                }
            }

            public static List<SchoolType> LoadSchoolType(ref DropDownList cmbSchoolType,
              int selectedValue = 0, bool createNewField = false)
            {
                //int instId,
                cmbSchoolType.DataTextField = "Name";
                cmbSchoolType.DataValueField = "Id";
                using (var helper = new DbHelper.Office())
                {
                    var schooltype = helper.GetSchoolTypes().ToList();
                    //if (schooltype.Count > 0)
                    //{
                    //    schooltype.Insert(0,
                    //        new DbEntities.Office.SchoolType() { Id = 0, Name = "--Select One--" });
                    //}

                    //if (createNewField)
                    //{
                    //    schooltype.Add(new
                    //        DbEntities.Office.SchoolType()
                    //    {
                    //        Id = -1,
                    //        Name = "--Create New--"
                    //    });
                    //}
                    cmbSchoolType.DataSource = schooltype;
                    cmbSchoolType.DataBind();
                    if (selectedValue != 0)
                    {
                        var index = schooltype.IndexOf(schooltype.First(x => x.Id == selectedValue));
                        if (index > 0)
                        {
                            cmbSchoolType.SelectedIndex = index;
                        }
                    }
                    return schooltype.ToList();
                }
            }



            #endregion


            #region Level Loading functions

            //public static void LoadLevel(ref DropDownList cmbLevel, int SchoolId)
            //{
            //    cmbLevel.DataTextField = "Name";
            //    cmbLevel.DataValueField = "Id";
            //    using (var helper = new DbHelper.Structure())
            //    {
            //        var lev = helper.GetLevels(SchoolId);
            //        //if (emptyField)
            //        //{
            //        //    lev.Insert(0, new IdAndName() { Id = 0, Name = "" });
            //        //}
            //        if (lev.Count > 0)
            //        {

            //            lev.Insert(0, new IdAndName() { Id = 0, Name = "--All--" });
            //        }


            //        cmbLevel.DataSource = lev;
            //        cmbLevel.DataBind();
            //        //if (selectedValue != 0)
            //        //{
            //        //    var index = lev.IndexOf(lev.First(x => x.Id == selectedValue));
            //        //    cmbLevel.SelectedIndex = (index);
            //        //}
            //    }
            //}

            //public static void LoadLevel(ref DropDownList cmbLevel, int SchoolId
            //    , bool emptyField, int selectedValue = 0)
            //{
            //    cmbLevel.DataTextField = "Name";
            //    cmbLevel.DataValueField = "Id";
            //    using (var helper = new DbHelper.Structure())
            //    {
            //        var lev = helper.GetLevels(SchoolId);
            //        if (emptyField)
            //        {
            //            lev.Insert(0, new IdAndName() { Id = 0, Name = "" });
            //        }
            //        //else if (lev.Count > 0)
            //        //{

            //        //        lev.Insert(0, new IdAndName() { Id = 0, Name = "--All--" });
            //        //}


            //        cmbLevel.DataSource = lev;
            //        cmbLevel.DataBind();
            //        if (selectedValue != 0)
            //        {
            //            var index = lev.IndexOf(lev.First(x => x.Id == selectedValue));
            //            cmbLevel.SelectedIndex = (index);
            //        }
            //    }
            //}

            //public static void LoadLevel(ref DropDownList cmbLevel, int SchoolId
            //    , int selectedValue, bool allField)
            //{
            //    cmbLevel.DataTextField = "Name";
            //    cmbLevel.DataValueField = "Id";
            //    using (var helper = new DbHelper.Structure())
            //    {
            //        var lev = helper.GetLevels(SchoolId);

            //        if (lev.Count > 0)
            //        {
            //            if (allField)
            //                lev.Insert(0, new IdAndName() { Id = 0, Name = "All" });
            //        }


            //        cmbLevel.DataSource = lev;
            //        cmbLevel.DataBind();
            //        if (selectedValue != 0)
            //        {
            //            var index = lev.IndexOf(lev.First(x => x.Id == selectedValue));
            //            cmbLevel.SelectedIndex = (index);
            //        }
            //    }
            //}

            //public static void LoadLevelWithFirstElementSelected(ref DropDownList cmbLevel, int schoolId, int selectedValue = 0)
            //{
            //    cmbLevel.DataTextField = "Name";
            //    cmbLevel.DataValueField = "Id";
            //    using (var helper = new DbHelper.Structure())
            //    {
            //        var lev = helper.GetLevels(schoolId);

            //        if (lev.Count > 1 || lev.Count == 0)
            //        {
            //            lev.Insert(0, new IdAndName() { Id = 0, Name = "" });
            //        }
            //        cmbLevel.DataSource = lev;
            //        cmbLevel.DataBind();
            //        if (selectedValue > 0)
            //        {
            //            var index = lev.IndexOf(lev.First(x => x.Id == selectedValue));
            //            if (index >= 0)
            //            {
            //                cmbLevel.SelectedIndex = index;
            //            }
            //        }
            //    }
            //}
            #endregion Level Loading functions

            #region Faculty Load Functions

            //public static void LoadFaculty(ref DropDownList cmbFaculty, int levelId, bool emptySelection = false)
            //{
            //    cmbFaculty.DataTextField = "Name";
            //    cmbFaculty.DataValueField = "Id";
            //    //int levelId = Convert.ToInt32((
            //    //    cmbLevel.SelectedValue.ToString() == "") ? "0" : cmbLevel.SelectedValue.ToString());
            //    using (var helper = new DbHelper.Structure())
            //    {
            //        var fac = helper.GetFaculties(levelId);
            //        if (emptySelection)
            //        {
            //            fac.Insert(0, new IdAndName() { Id = 0, Name = "" });
            //        }
            //        else if (fac.Count > 0)
            //            fac.Insert(0, new IdAndName() { Id = 0, Name = "All" });
            //        cmbFaculty.DataSource = fac;
            //        cmbFaculty.DataBind();
            //    }
            //}

            //public static void LoadFacultyWithFirstElementSelected(ref DropDownList cmbFaculty, int levelId, int selectedValue = 0)
            //{
            //    cmbFaculty.DataTextField = "Name";
            //    cmbFaculty.DataValueField = "Id";
            //    //int levelId = Convert.ToInt32((
            //    //    cmbLevel.SelectedValue.ToString() == "") ? "0" : cmbLevel.SelectedValue.ToString());
            //    using (var helper = new DbHelper.Structure())
            //    {
            //        var fac = helper.GetFaculties(levelId);
            //        if (fac.Count > 1 || fac.Count == 0)
            //        {
            //            fac.Insert(0, new IdAndName() { Id = 0, Name = "" });
            //        }
            //        cmbFaculty.DataSource = fac;
            //        cmbFaculty.DataBind();

            //        if (selectedValue > 0)
            //        {
            //            var index = fac.IndexOf(fac.First(x => x.Id == selectedValue));
            //            if (index >= 0)
            //            {
            //                cmbFaculty.SelectedIndex = index;
            //            }
            //        }
            //    }
            //}

            #endregion

            #region Program Load Functions

            public static void LoadProgram(ref DropDownList cmbProgram, int facultyId, bool emptySelection = false)
            {
                cmbProgram.DataTextField = "Name";
                cmbProgram.DataValueField = "Id";
                //int facId = Convert.ToInt32((
                //    cmbFaculty.SelectedValue.ToString() == "") ? "0" : cmbFaculty.SelectedValue.ToString());
                using (var helper = new DbHelper.Structure())
                {
                    var fac = helper.GetPrograms(facultyId);
                    if (emptySelection)
                    {
                        fac.Insert(0, new IdAndName() { Id = 0, Name = "" });
                    }
                    else if (fac.Count > 0)
                        fac.Insert(0, new IdAndName() { Id = 0, Name = "All" });
                    cmbProgram.DataSource = fac;
                    cmbProgram.DataBind();
                }
            }

            public static void LoadProgramWithEmptyAsFirstElement(ref DropDownList cmbProgram, int facultyId, int selectedValue = 0)
            {
                cmbProgram.DataTextField = "Name";
                cmbProgram.DataValueField = "Id";
                //int facId = Convert.ToInt32((
                //    cmbFaculty.SelectedValue.ToString() == "") ? "0" : cmbFaculty.SelectedValue.ToString());
                using (var helper = new DbHelper.Structure())
                {
                    var prog = helper.GetPrograms(facultyId);
                    if (prog.Count > 1 || prog.Count == 0)
                        prog.Insert(0, new IdAndName() { Id = 0, Name = "" });

                    cmbProgram.DataSource = prog;
                    cmbProgram.DataBind();

                    if (selectedValue > 0)
                    {
                        var index = prog.IndexOf(prog.First(x => x.Id == selectedValue));
                        if (index >= 0)
                        {
                            cmbProgram.SelectedIndex = index;
                        }
                    }
                }
            }

            #endregion


            public static void LoadYear(ref DropDownList cmbYear, int programId, bool emptySelection = false)
            {
                cmbYear.DataTextField = "Name";
                cmbYear.DataValueField = "Id";
                //int proId = Convert.ToInt32((
                //    cmbProgram.SelectedValue.ToString() == "") ? "0" : cmbProgram.SelectedValue.ToString());
                using (var helper = new DbHelper.Structure())
                {
                    var yea = helper.GetYears(programId);
                    if (emptySelection)
                        yea.Insert(0, new Year() { Id = 0, Name = "" });
                    else if (yea.Count > 0)
                        yea.Insert(0, new Year() { Id = 0, Name = "All" });
                    cmbYear.DataSource = yea;
                    cmbYear.DataBind();
                }
            }

            public static void LoadGender(ref DropDownList cmbGender)
            {
                cmbGender.DataTextField = "Name";
                cmbGender.DataValueField = "Id";

                using (var helper = new DbHelper.User())
                {
                    var yea = helper.GetGender();
                    //if (yea.Count > 0)
                    yea.Insert(0, new Gender() { Id = 0, Name = "" });
                    cmbGender.DataSource = yea;
                    cmbGender.DataBind();
                }
            }

            //public static void LoadUserType(ref DropDownList cmbUserType, int schoolId, string defaultSEelected = "")
            //{
            //    cmbUserType.DataTextField = "Name";
            //    cmbUserType.DataValueField = "Id";

            //    using (var helper = new DbHelper.User())
            //    {
            //        var type = helper.GetUserTypes(schoolId);
            //        type.Insert(0, new UserType() { Id = 0, Name = "" });
            //        cmbUserType.DataSource = type;
            //        cmbUserType.DataBind();

            //        var item = type.FirstOrDefault(x => x.Name == defaultSEelected);
            //        if (item != null)
            //        {
            //            var selected = type.IndexOf(item);
            //            cmbUserType.Text = defaultSEelected;
            //            cmbUserType.SelectedIndex = selected;
            //        }

            //    }
            //}


            #region Role Loading functions

            //Used after github..
            public static void LoadRole(ref DropDownList cmbRole, int schoolId, string defaultSelectedName = "")
            {
                cmbRole.DataTextField = "DisplayName";
                cmbRole.DataValueField = "Id";

                using (var helper = new DbHelper.User())
                {
                    var type = helper.GetRole(schoolId);
                    type.Insert(0, new Role() { Id = 0, DisplayName = "" });
                    cmbRole.DataSource = type;
                    cmbRole.DataBind();

                    var index = type.IndexOf(type.First(x => x.DisplayName == defaultSelectedName));
                    if (index >= 0)
                        cmbRole.SelectedIndex = index;
                }
            }

            public static void LoadRoleForUserEnroll(ref DropDownList cmbRole, int schoolId, string defaultSelectedName, bool showNone=true)
            {
                cmbRole.DataTextField = "DisplayName";
                cmbRole.DataValueField = "Id";

                using (var helper = new DbHelper.User())
                {
                    var type = helper.GetRolesForUserEnrollOption(schoolId);
                    if (type.Count > 0 && showNone)
                        type.Insert(0, new Role() { Id = 0, DisplayName = "None" });
                    cmbRole.DataSource = type;
                    cmbRole.DataBind();

                    var index = type.IndexOf(type.First(x => x.RoleName == defaultSelectedName));
                    if (index >= 0)
                        cmbRole.SelectedIndex = index;
                }
            }

            public static void LoadRole(ref DropDownList cmbRole, int schoolId, int defaultSelectedValue = 0)
            {
                cmbRole.DataTextField = "Name";
                cmbRole.DataValueField = "Id";

                using (var helper = new DbHelper.User())
                {
                    var type = helper.GetRole(schoolId);
                    if (type.Count > 0)
                        type.Insert(0, new Role() { Id = 0, RoleName = "" });
                    cmbRole.DataSource = type;
                    cmbRole.DataBind();

                    var index = type.IndexOf(type.First(x => x.Id == defaultSelectedValue));
                    if (index >= 0)
                        cmbRole.SelectedIndex = index;
                }
            }


            #endregion


            #region AcademicYear and Session Loading functions

            public static List<DbEntities.AcademicYear> LoadAcademicYear(
                           ref DropDownList cmbAcademicYear, int schoolId
                           , int selectedValue = 0)
            {
                cmbAcademicYear.DataTextField = "Name";
                cmbAcademicYear.DataValueField = "Id";
                using (var helper = new DbHelper.AcademicYear())
                {
                    var acaYear = helper.ListAcademicYears(schoolId);
                    if (acaYear.Count > 0)
                        acaYear.Insert(0, new DbEntities.AcademicYear() { Id = 0, Name = "  Select  " });
                    cmbAcademicYear.DataSource = acaYear;
                    cmbAcademicYear.DataBind();
                    if (selectedValue > 0)
                    {
                        var index = acaYear.IndexOf(acaYear.First(x => x.Id == selectedValue));
                        if (index >= 0)
                            cmbAcademicYear.SelectedIndex = index;
                    }
                    else
                    {
                        try
                        {
                            var index = acaYear.IndexOf(acaYear.First(x => x.IsActive));
                            if (index >= 0)
                                cmbAcademicYear.SelectedIndex = index;
                        }
                        catch { }

                    }
                    return acaYear.ToList();
                }
            }

            public static List<DbEntities.Session> LoadSession(ref DropDownList cmbSession, int academicYearId
              , bool includeAllField = false, bool includeNoneField = false)
            {
                cmbSession.DataTextField = "Name";
                cmbSession.DataValueField = "Id";
                using (var helper = new DbHelper.AcademicYear())
                {
                    var cats = helper.GetTopSessionListForAcademicYear(academicYearId);
                    if (includeNoneField)
                        cats.Insert(0, new DbEntities.Session() { Id = 0, Name = "None" });
                    else if (cats.Count > 0)
                        if (includeAllField)
                        {

                            cats.Insert(0, new DbEntities.Session()
                            {
                                Id = 0,
                                Name = "All"
                            });
                        }
                        else
                        //if (includeEmptyField)
                        {
                            cats.Insert(0, new DbEntities.Session()
                            {
                                Id = 0,
                                Name = ""
                            });
                        }

                    cmbSession.DataSource = cats;
                    cmbSession.DataBind();

                    //if (selectedValue >= 0)
                    //{
                    //    var index = cats.IndexOf(cats.First(x => x.Id == selectedValue));
                    //    if (index >= 0)
                    //    {
                    //        cmbSession.SelectedIndex = index;
                    //    }
                    //}
                    return cats.ToList();
                }
            }

            public static List<DbEntities.Session> LoadSession(ref DropDownList cmbSession, int academicYearId, int selectedValue
               , bool includeAllField = false, bool includeNoneField = false, bool includeEmptyField = false, bool selectActiveSession = false)
            {
                cmbSession.DataTextField = "Name";
                cmbSession.DataValueField = "Id";
                using (var helper = new DbHelper.AcademicYear())
                {
                    var cats = helper.GetTopSessionListForAcademicYear(academicYearId);
                    if (includeNoneField)
                        cats.Insert(0, new DbEntities.Session() { Id = 0, Name = "None" });
                    if (cats.Count > 0)
                        if (includeAllField)
                        {

                            cats.Add(new DbEntities.Session()
                            {
                                Id = 0,
                                Name = "All"
                            });
                        }
                        else
                            if (includeEmptyField)
                            {
                                cats.Insert(0, new DbEntities.Session()
                                {
                                    Id = 0,
                                    Name = ""
                                });
                            }

                    cmbSession.DataSource = cats;
                    cmbSession.DataBind();

                    if (selectedValue >= 0)
                    {
                        var index = cats.IndexOf(cats.First(x => x.Id == selectedValue));
                        if (index >= 0)
                        {
                            cmbSession.SelectedIndex = index;
                        }
                    }
                    else if (selectActiveSession)
                    {
                        var index = cats.IndexOf(cats.First(x => x.IsActive));
                        if (index >= 0)
                        {
                            cmbSession.SelectedIndex = index;
                        }
                    }
                    return cats.ToList();
                }
            }


            #endregion


            #region SubYear Loading functions

            public static void LoadSubYear(ref DropDownList cmbSubYear, int yearId
                , bool emptySelection = false
                , bool topAsInitial = false
                , bool onlyTopLevelLoad = false
                , bool allField = false)
            {
                cmbSubYear.DataTextField = "Name";
                cmbSubYear.DataValueField = "Id";
                //int proId = Convert.ToInt32((
                //    cmbProgram.SelectedValue.ToString() == "") ? "0" : cmbProgram.SelectedValue.ToString());
                using (var helper = new DbHelper.Structure())
                {
                    var yea = helper.GetSubYears(yearId, onlyTopLevelLoad);
                    if (allField)
                    {
                        if (yea.Count < 0)
                            yea.Insert(0, new SubYear() { Id = 0, Name = "None" });
                        else yea.Insert(0, new SubYear() { Id = 0, Name = "All" });
                    }
                    else if (topAsInitial)
                    {
                        yea.Insert(0, new SubYear() { Id = 0, Name = "Top" });
                    }
                    else if (emptySelection)
                    {
                        yea.Insert(0, new SubYear() { Id = 0, Name = "" });
                    }
                    else if (yea.Count > 0)
                        yea.Insert(0, new SubYear() { Id = 0, Name = "---Select One---" });
                    cmbSubYear.DataSource = yea;
                    cmbSubYear.DataBind();
                }
            }

            public static void LoadSubYear(ref DropDownList cmbSubYear, int yearId
              , int selected)
            {
                cmbSubYear.DataTextField = "Name";
                cmbSubYear.DataValueField = "Id";
                //int proId = Convert.ToInt32((
                //    cmbProgram.SelectedValue.ToString() == "") ? "0" : cmbProgram.SelectedValue.ToString());
                using (var helper = new DbHelper.Structure())
                {
                    var yea = helper.GetSubYears(yearId);
                    if (yea.Count <= 0)
                        yea.Insert(0, new SubYear() { Id = 0, Name = "None" });

                    cmbSubYear.DataSource = yea;
                    cmbSubYear.DataBind();
                    //if (selected != 0)
                    //{

                    //}
                }
            }

            public static void LoadPhase(ref DropDownList cmbSubYear, int SubYearId, bool emptySelection = false)
            {
                cmbSubYear.DataTextField = "Name";
                cmbSubYear.DataValueField = "Id";
                //int proId = Convert.ToInt32((
                //    cmbProgram.SelectedValue.ToString() == "") ? "0" : cmbProgram.SelectedValue.ToString());
                using (var helper = new DbHelper.Structure())
                {
                    var yea = helper.GetPhase(SubYearId);
                    //if (topAsInitial)
                    //{
                    //    yea.Insert(0, new IdAndName() { Id = 0, Name = "Top" });
                    //}
                    //else
                    if (emptySelection)
                    {
                        yea.Insert(0, new IdAndName() { Id = 0, Name = "" });
                    }
                    else if (yea.Count > 0)
                        yea.Insert(0, new IdAndName() { Id = 0, Name = "---Select One---" });
                    cmbSubYear.DataSource = yea;
                    cmbSubYear.DataBind();
                }
            }

            #endregion


            #region Subject and SubjectCategory Loading functions

            public static List<DbEntities.Subjects.Subject> LoadSubject(ref DropDownList cmbSubject, int schoolId)
            {
                cmbSubject.DataTextField = "Name";
                cmbSubject.DataValueField = "Id";
                using (var helper = new DbHelper.Subject())
                {
                    var cats = helper.GetSubjectList(schoolId);

                    //if (includeEmptyField)
                    {
                        cats.Insert(0, new DbEntities.Subjects.Subject()
                        {
                            Id = 0,
                            FullName = ""
                        });
                    }

                    cmbSubject.DataSource = cats;
                    cmbSubject.DataBind();

                    return cats.ToList();
                }
            }

            public static List<DbEntities.Subjects.SubjectCategory> LoadSubjectCategory(ref DropDownList cmbCategory,
              int schoolId, bool includeTopAlso = false, bool includeEmptyField = false, int selectedValue = 0)
            {
                cmbCategory.DataTextField = "Name";
                cmbCategory.DataValueField = "Id";
                using (var helper = new DbHelper.Subject())
                {
                    var cats = helper.GetCategories(schoolId);
                    if (includeTopAlso)
                    {
                        cats.Insert(0, new DbEntities.Subjects.SubjectCategory()
                        {
                            Id = 0,
                            Name = " Top "
                        });
                    }
                    if (includeEmptyField)
                    {
                        cats.Insert(0, new DbEntities.Subjects.SubjectCategory()
                        {
                            Id = -1,
                            Name = ""
                        });
                    }
                    cmbCategory.DataSource = cats;
                    cmbCategory.DataBind();

                    if (selectedValue > 0)
                    {
                        var index = cats.IndexOf(cats.First(x => x.Id == selectedValue));
                        if (index >= 0)
                        {
                            cmbCategory.SelectedIndex = index;
                        }
                    }
                    return cats.ToList();
                }
            }


            #endregion



            /*
                        public static void LoadInstitution(ref DropDownList cmbInstitution, int selectedId = 0)
                        {
                            cmbInstitution.DataTextField = "Name";
                            cmbInstitution.DataValueField = "Id";
                            using (var helper = new DbHelper.Office())
                            {
                                if (selectedId != 0)
                                {
                                    List<Institution> list = new List<Institution>();
                                    var inst = helper.GetInstitution(selectedId);
                                    list.Add(inst);
                                    cmbInstitution.DataSource = list;
                                    cmbInstitution.DataBind();
                                }
                                else
                                {
                                    //for admin
                                    var instList = helper.GetAllInstitution().ToList();
                                    if (instList.Count >= 0)
                                    {
                                        instList.Insert(0, new DbEntities.Office.Institution()
                                        {
                                            Id = 0,
                                            Name = ""
                                        });
                                    }
                                    cmbInstitution.DataSource = instList;
                                    cmbInstitution.DataBind();

                                }
                            }
                        }
                        */


            public static List<Academic.DbEntities.Students.StudentGroup> LoadStudentGroup(
                ref DropDownList cmbGroup, int schoolId, bool includeEmptyField = false
                , int selectedValue = 0)
            {
                cmbGroup.DataTextField = "Name";
                cmbGroup.DataValueField = "Id";
                using (var helper = new DbHelper.Student())
                {
                    var cats = helper.GetStudentGroupList(schoolId);

                    if (includeEmptyField)
                    {
                        cats.Insert(0, new DbEntities.Students.StudentGroup()
                        {
                            Id = 0,
                            Name = ""
                        });
                    }

                    cmbGroup.DataSource = cats;
                    cmbGroup.DataBind();

                    if (selectedValue >= 0)
                    {
                        var index = cats.IndexOf(cats.First(x => x.Id == selectedValue));
                        if (index >= 0)
                        {
                            cmbGroup.SelectedIndex = index;
                        }
                    }
                    return cats.ToList();
                }
            }



            public static List<DbEntities.Teachers.Teacher> LoadTeacher(ref DropDownList cmbTeacher, int schoolId)
            {
                cmbTeacher.DataTextField = "Name";
                cmbTeacher.DataValueField = "Id";
                using (var helper = new DbHelper.Teacher())
                {
                    var cats = helper.GetTeacherList(schoolId);

                    //if (includeEmptyField)
                    {
                        cats.Insert(0, new DbEntities.Teachers.Teacher()
                        {
                            Id = 0,
                            Name = ""
                        });
                    }

                    cmbTeacher.DataSource = cats;
                    cmbTeacher.DataBind();

                    //if (selectedValue >= 0)
                    //{
                    //    var index = cats.IndexOf(cats.First(x => x.Id == selectedValue));
                    //    if (index >= 0)
                    //    {
                    //        cmbSession.SelectedIndex = index;
                    //    }
                    //}
                    return cats.ToList();
                }
            }


            //public static void LoadCoordinator(ref DropDownList cmbCoordinator, int schoolId, int selectedValue = 0)
            //{
            //    cmbCoordinator.DataTextField = "FullName";
            //    cmbCoordinator.DataValueField = "Id";
            //    using (var helper = new DbHelper.Staff())
            //    {
            //        var co = helper.GetEmployeesOfExamDivisionForCombo(schoolId);
            //        if (co.Count > 0)
            //            co.Insert(0, new Users() { Id = 0, FirstName = "" });
            //        cmbCoordinator.DataSource = co;
            //        cmbCoordinator.DataBind();

            //        if (selectedValue >= 0)
            //        {
            //            var index = co.IndexOf(co.First(x => x.Id == selectedValue));
            //            if (index >= 0)
            //            {
            //                cmbCoordinator.SelectedIndex = index;
            //            }
            //        }
            //    }
            //}

            public static void LoadExamType(ref DropDownList cmbExamType, int schoolId, int selectedValue = 0)
            {
                cmbExamType.DataTextField = "Name";
                cmbExamType.DataValueField = "Id";
                using (var helper = new DbHelper.Exam())
                {
                    var ex = helper.GetExamTypeForCombo(schoolId);
                    ex.Insert(0, new DbEntities.Exams.ExamType() { Id = 0, Name = "    Select One" });
                    cmbExamType.DataSource = ex;
                    cmbExamType.DataBind();


                    if (selectedValue >= 0)
                    {
                        var index = ex.IndexOf(ex.First(x => x.Id == selectedValue));
                        if (index >= 0)
                        {
                            cmbExamType.SelectedIndex = index;
                        }
                    }
                }
            }
        }
    }
}
