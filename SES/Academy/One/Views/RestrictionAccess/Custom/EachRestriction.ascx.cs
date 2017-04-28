using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.AccessPermission;
using Academic.ViewModel;
using One.TestingOnly;
using One.Values.MemberShip;
using One.Views.RestrictionAccess.Main;

namespace One.Views.RestrictionAccess.Custom
{
    public partial class EachRestriction : System.Web.UI.UserControl
    {

        //public event EventHandler<EventArgs> AddRestrictionClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            //btnAddRestriction.Attributes.Add("name", hidRelativeId.Value);// = "btnAddRestriction" + hidId.Value;
            lnkAddActOrRes.Attributes.Add("name", hidRelativeId.Value + "-" + NoOfChildRestrictionSets);
            if (!IsPostBack)
            {

                //dataList.DataSource = lst;
                //dataList.DataBind();
            }
            var lst = new List<IdAndName>()
            {
                //new IdAndName() {Id = 0, Name = "Activity completion"},
                new IdAndName() {Id = 1, Name = "Date"},
                new IdAndName() {Id = 2, Name = "Grade"},
                new IdAndName() {Id = 3, Name = "Class"},
                new IdAndName() {Id = 4, Name = "User profile"},
                new IdAndName() {Id = 5, Name = "Restriction set"},
            };
            dialog.SetValues("Add restriction", lst, "Click");
            dialog.ItemClick += dialog_ItemClick;

            if (IsFirstRestriction)
            {
                var restriction = Session["ControlList_" + hidPageKeyForUniqueSession.Value] as RestrictionIdName;
                if (restriction != null)
                    LoadFromType(restriction.Children);
            }
            else if (Chilren != null)
            {
                LoadFromType(Chilren);
            }
        }

        public int SubjectId
        {
            get { return Convert.ToInt32(hidSubjectId.Value); }
            set
            {
                hidSubjectId.Value = value.ToString();
            }
        }

        public List<RestrictionIdName> Chilren;

        //public void SetData(Restriction res)
        //{
        //    var restrictionId = RelativeId;
        //    RestrictionId = res.Id;
        //    var restriction = Session["ControlList_" + hidPageKeyForUniqueSession.Value] as RestrictionIdName;
        //    //ddlMustMatch.SelectedIndex = res.mu
        //    if (restriction != null)
        //    {
        //        var split = restrictionId.ToString().Split(new char[] { '_' });
        //        var parent = GetParentRestriction(restriction, split);
        //        var list = parent.Children; //[restrictionId.ToString()];
        //        var noOfChildRestrictions = parent.Children.Count;
        //        var thisId = (noOfChildRestrictions + 1);
        //        RestrictionIdName resClass = null;

        //        foreach (var dr in res.DateRestrictions)
        //        {
        //            resClass = GetRestriction(restrictionId.ToString(), "date"
        //                               , thisId.ToString(), restrictionId + "_" + thisId
        //                               , "", new List<RestrictionIdName>());
        //            var dateRestriction = (DateRestrictionUC)
        //                Page.LoadControl("~/Views/RestrictionAccess/DateRestrictionUC.ascx");
        //            dateRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId,
        //                resClass.RelativeId, resClass.Name);
        //            dateRestriction.RestrictionId = dr.Id;
        //            dateRestriction.CloseClicked += RestrictionType_CloseClicked;
        //            dateRestriction.InitialDate = DateTime.Now;
        //            this.AddControl(dateRestriction);
        //            //if (resClass != null)
        //            list.Add(resClass);
        //        }
        //        foreach (var grd in res.GradeRestrictions)
        //        {

        //        }
        //        foreach (var grp in res.GroupRestrictions)
        //        {

        //        }
        //        foreach (var ur in res.UserProfileRestrictions)
        //        {

        //        }
        //        foreach (var r in res.Restrictions)
        //        {

        //        }
        //        //activity completion
        //    }
        //}


        #region Events Callback

        void dialog_ItemClick(object sender, IdAndNameEventArgs e)
        {
            //var restrictionId = Session["CurrentRestrictionId"];
            var relativeId = RelativeId;
            var subjectId = SubjectId;
            var restriction = Session["ControlList_" + hidPageKeyForUniqueSession.Value] as RestrictionIdName;

            var user = Page.User as CustomPrincipal;
            if (user != null)
                if (restriction != null)
                {

                    var split = relativeId.Split(new char[] { '_' });

                    var parent = GetParentRestriction(restriction, split);

                    //if (parent != null && _foundMain != null) //new
                    {
                        var list = parent.Children; //[restrictionId.ToString()];

                        var noOfChildRestrictions = parent.Children.Count;
                        var thisId = (noOfChildRestrictions + 1);
                        RestrictionIdName resClass = null;
                        switch (e.Id)
                        {
                            //case 0:
                            //    resClass = GetRestriction(relativeId, "activity"
                            //        , thisId.ToString(), relativeId + "_" + thisId
                            //        , "", new List<RestrictionIdName>());

                            //    var activityCompleteRestriction = (ActivityCompleteRestrictionUC)
                            //        Page.LoadControl("~/Views/RestrictionAccess/ActivityCompleteRestrictionUC.ascx");
                            //    activityCompleteRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId,
                            //        resClass.RelativeId, resClass.Name);

                            //    activityCompleteRestriction.CloseClicked += RestrictionType_CloseClicked;
                            //    this.AddControl(activityCompleteRestriction);
                            //    break;
                            case 1:
                                resClass = GetRestriction(relativeId.ToString(), "date"
                                    , thisId.ToString(), relativeId + "_" + thisId
                                    , "", new List<RestrictionIdName>());
                                var dateRestriction = (DateRestrictionUC)
                                    Page.LoadControl("~/Views/RestrictionAccess/DateRestrictionUC.ascx");
                                dateRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId,
                                    resClass.RelativeId, resClass.Name);
                                dateRestriction.CloseClicked += RestrictionType_CloseClicked;
                                dateRestriction.InitialDate = DateTime.Now;
                                dateRestriction.ID = resClass.Name + "_" + resClass.ParentId + "_" + resClass.AbsoluteId + "_" +
                                                     resClass.RelativeId;
                                this.AddControl(dateRestriction);
                                break;
                            case 2:
                                resClass = GetRestriction(relativeId.ToString(), "grade"
                                    , thisId.ToString(), relativeId + "_" + thisId
                                    , "", new List<RestrictionIdName>());
                                var gradeRestriction = (GradeRestrictionUC)
                                    Page.LoadControl("~/Views/RestrictionAccess/GradeRestrictionUC.ascx");
                                gradeRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId,
                                    resClass.RelativeId, resClass.Name, subjectId);
                                gradeRestriction.CloseClicked += RestrictionType_CloseClicked;
                                //gradeRestriction.RestrictionId = RestrictionId
                                gradeRestriction.ID = resClass.Name + "_" + resClass.ParentId + "_" + resClass.AbsoluteId + "_" +
                                                     resClass.RelativeId;
                                this.AddControl(gradeRestriction);

                                break;
                            case 3:
                                resClass = GetRestriction(relativeId.ToString(), "class"
                                    , thisId.ToString(), relativeId + "_" + thisId
                                    , "", new List<RestrictionIdName>());
                                var groupRestriction = (GroupRestrictionUC)
                                    Page.LoadControl("~/Views/RestrictionAccess/GroupRestrictionUC.ascx");
                                groupRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId,
                                    resClass.RelativeId, resClass.Name, subjectId);
                                string s = "";
                                user.GetRoles().ForEach(x =>
                                {
                                    s += (x + ",");
                                });
                                groupRestriction.Roles = s;//user.GetRoles();
                                //groupRestriction.PopulateClassList();
                                groupRestriction.CloseClicked += RestrictionType_CloseClicked;
                                groupRestriction.ID = resClass.Name + "_" + resClass.ParentId + "_" + resClass.AbsoluteId + "_" +
                                                     resClass.RelativeId;
                                this.AddControl(groupRestriction);
                                break;
                            case 4:
                                resClass = GetRestriction(relativeId.ToString(), "userprofile"
                                    , thisId.ToString(), relativeId + "_" + thisId
                                    , "", new List<RestrictionIdName>());
                                var userProfileRestriction = (UserProfileRestriction)
                                    Page.LoadControl("~/Views/RestrictionAccess/UserProfileRestriction.ascx");
                                userProfileRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId,
                                    resClass.RelativeId, resClass.Name);
                                pnlRestrictions.Controls.Add(userProfileRestriction);
                                userProfileRestriction.ID = resClass.Name + "_" + resClass.ParentId + "_" + resClass.AbsoluteId + "_" +
                                                     resClass.RelativeId;
                                this.AddControl(userProfileRestriction);
                                break;
                            case 5:
                                resClass = GetRestriction(relativeId.ToString(), "main"
                                    , thisId.ToString(), relativeId + "_" + thisId
                                    , "", new List<RestrictionIdName>());

                                var restrictionSetUc = (EachRestriction)
                                    Page.LoadControl("~/Views/RestrictionAccess/Custom/EachRestriction.ascx");
                                restrictionSetUc.SetIds(resClass.ParentId, resClass.AbsoluteId,
                                    resClass.RelativeId, resClass.Name);
                                //restrictionSetUc.RestrictionParentId = resClass.RestrictionTypeId;
                                //restrictionSetUc.RestrictionId = resClass.RestrictionTypeId;
                                restrictionSetUc.PageKeyForUniqueSession = PageKeyForUniqueSession;
                                restrictionSetUc.Chilren = new List<RestrictionIdName>();
                                restrictionSetUc.SubjectId = subjectId;
                                this.AddControl(restrictionSetUc);
                                break;
                        }
                        if (resClass != null)
                            list.Add(resClass);
                        dialog.CloseDialog();
                        //LoadFromType();

                    }
                }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="name"></param>
        /// <param name="absoluteId"></param>
        /// <param name="relativeId"></param>
        /// <param name="otherId"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public RestrictionIdName GetRestriction(string parentId, string name
           , string absoluteId, string relativeId
           , string otherId, List<RestrictionIdName> children)
        {
            return new RestrictionIdName()
            {
                ParentId = parentId,
                Name = name,
                AbsoluteId = absoluteId,
                RelativeId = relativeId,
                OtherId = otherId,
                Children = children
            };
        }

        void RestrictionType_CloseClicked(object sender, RestrictionEventArgs e)
        {
            _deleted = false;
            var restList = Session["ControlList_" + PageKeyForUniqueSession] as RestrictionIdName;
            if (restList != null)
            {
                var split = e.RelativeId.Split('_');
                // Panel pnlRestrictions = EachRestriction1.GetPanel();
                switch (e.Type)
                {
                    case "activity":
                        var acntrl = sender as ActivityCompleteRestrictionUC;
                        if (acntrl != null)
                        {
                            DeleteRestriction(restList, split);
                            if (_deleted)
                                acntrl.Visible = false;
                            //pnlRestrictions.Controls.Remove(acntrl);
                        }

                        break;
                    case "date":
                        var dcntrl = sender as DateRestrictionUC;
                        if (dcntrl != null)
                        {
                            DeleteRestriction(restList, split);
                            if (_deleted)
                                dcntrl.Visible = false;
                            //pnlRestrictions.Controls.Remove(dcntrl);
                        }
                        break;
                    case "grade":
                        var gradecntrl = sender as GradeRestrictionUC;
                        if (gradecntrl != null)
                        {
                            DeleteRestriction(restList, split);
                            if (_deleted)
                                gradecntrl.Visible = false;
                            //pnlRestrictions.Controls.Remove(gradecntrl);
                        }
                        break;
                    case "class":
                        var groupcntrl = sender as GroupRestrictionUC;
                        if (groupcntrl != null)
                        {
                            DeleteRestriction(restList, split);
                            if (_deleted)
                                groupcntrl.Visible = false;
                            //pnlRestrictions.Controls.Remove(groupcntrl);
                        }
                        break;
                    case "userprofile":
                        var ucntrl = sender as UserProfileRestriction;
                        if (ucntrl != null)
                        {
                            DeleteRestriction(restList, split);
                            if (_deleted)
                                ucntrl.Visible = false;
                            //pnlRestrictions.Controls.Remove(ucntrl);
                        }
                        break;
                }
                _deleted = false;
            }

        }



        protected void lnkAddActOrRes_Click(object sender, EventArgs e)
        {
            //var restriction = Session["ControlList_" + hidPageKeyForUniqueSession.Value] as RestrictionIdName;
            dialog.OpenDialog();
        }


        #endregion

        #region Properties

        public bool IsFirstRestriction
        {
            get { return Convert.ToBoolean(hidFirstRestriction.Value); }
            set { hidFirstRestriction.Value = value.ToString(); }
        }


        /// <summary>
        /// RelativeId contain ids in the format (1_2_3) where 
        /// preceeding ids are of parent and last id is current Control's id
        /// </summary>
        public string RelativeId
        {
            get { return hidRelativeId.Value; }
            set { hidRelativeId.Value = value; }
        }

        /// <summary>
        /// The specifice id of this control.
        /// </summary>
        public string AbsoluteId
        {
            get { return hidAbsoluteId.Value; }
            set { hidAbsoluteId.Value = value; }
        }

        public string ParentId
        {
            get { return hidParentId.Value; }
            set { hidParentId.Value = value; }
        }

        public string Type
        {
            get { return hidType.Value; }
            set { hidType.Value = value; }
        }

        public int NoOfChildRestrictionSets
        {
            get { return Convert.ToInt32(hidNoOfChildRestrictionSets.Value); }
            set { hidNoOfChildRestrictionSets.Value = value.ToString(); }
        }

        public int MultiViewActiveViewIndex
        {
            set { multiViewRestrict.ActiveViewIndex = value; }
        }

        public string PageKeyForUniqueSession
        {
            get { return hidPageKeyForUniqueSession.Value; }
            set { hidPageKeyForUniqueSession.Value = value; }
        }

        public int RestrictionId
        {
            get { return Convert.ToInt32(hidRestrictionId.Value); }
            set { hidRestrictionId.Value = value.ToString(); }
        }

        public int RestrictionParentId
        {
            get { return Convert.ToInt32(hidRestrictionParentId.Value); }
            set { hidRestrictionParentId.Value = value.ToString(); }
        }


        #endregion

        //EachRestriction _foundMain;

        #region  functions

        public void LoadFromType(List<Academic.ViewModel.RestrictionIdName> list)
        {
            if (list != null)
            {
                if (list.Count > 0)
                    multiViewRestrict.ActiveViewIndex = 1;

                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    var restrictionId = RestrictionId;
                    string s = "";
                    user.GetRoles().ForEach(x =>
                    {
                        s += (x + ",");
                    });
                    foreach (var resClass in list)
                    {
                        switch (resClass.Name)
                        {
                            //case "activity":
                            //    var activityCompleteRestriction = (ActivityCompleteRestrictionUC)
                            //        Page.LoadControl("~/Views/RestrictionAccess/ActivityCompleteRestrictionUC.ascx");
                            //    activityCompleteRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId, resClass.RelativeId, resClass.Name);
                            //    activityCompleteRestriction.CloseClicked += RestrictionType_CloseClicked;
                            //    activityCompleteRestriction.Visible = !resClass.Void;
                            //    pnlRestrictions.Controls.Add(activityCompleteRestriction);

                            //    break;
                            case "date":
                                var dateRestriction = (DateRestrictionUC)
                                    Page.LoadControl("~/Views/RestrictionAccess/DateRestrictionUC.ascx");
                                dateRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId, resClass.RelativeId
                                    , resClass.Name);
                                dateRestriction.ID = resClass.Name+"_" + resClass.ParentId + "_" + resClass.AbsoluteId + "_" +
                                                     resClass.RelativeId;
                                dateRestriction.CloseClicked += RestrictionType_CloseClicked;
                                dateRestriction.Visible = !resClass.Void;
                                dateRestriction.RestrictionId = restrictionId;

                                dateRestriction.DateRestrictionId = resClass.RestrictionTypeId;
                                dateRestriction.RestrictionId = resClass.RestrictionTypeParentId;

                                dateRestriction.SetValues(resClass.Constraints);
                                pnlRestrictions.Controls.Add(dateRestriction);

                                break;

                            case "grade":
                                var gradeRestriction = (GradeRestrictionUC)
                                    Page.LoadControl("~/Views/RestrictionAccess/GradeRestrictionUC.ascx");
                                gradeRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId
                                    , resClass.RelativeId, resClass.Name,SubjectId);
                                gradeRestriction.CloseClicked += RestrictionType_CloseClicked;
                                gradeRestriction.Visible = !resClass.Void;
                                gradeRestriction.ID = resClass.Name + "_" + resClass.ParentId + "_" + resClass.AbsoluteId + "_" +
                                                     resClass.RelativeId;
                                //pnlRestrictions.Controls.Add(gradeRestriction);
                                gradeRestriction.SetValues(resClass.Constraints);
                                //gradeRestriction.SetData();
                                gradeRestriction.RestrictionId = restrictionId;
                                gradeRestriction.GradeRestrictionId = resClass.RestrictionTypeId;
                              
                                pnlRestrictions.Controls.Add(gradeRestriction);
                                break;

                            case "class":
                                var groupRestriction = (GroupRestrictionUC)
                                    Page.LoadControl("~/Views/RestrictionAccess/GroupRestrictionUC.ascx");
                                groupRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId, resClass.RelativeId
                                    , resClass.Name, SubjectId);
                                groupRestriction.ID = resClass.Name + "_" + resClass.ParentId + "_" + resClass.AbsoluteId + "_" +
                                                     resClass.RelativeId;
                                groupRestriction.CloseClicked += RestrictionType_CloseClicked;
                                groupRestriction.Roles = s;//user.GetRoles();
                                groupRestriction.Visible = !resClass.Void;

                                groupRestriction.SetValues(resClass.Constraints);
                                pnlRestrictions.Controls.Add(groupRestriction);

                                break;

                            case "userprofile":
                                var userProfileRestriction = (UserProfileRestriction)
                                    Page.LoadControl("~/Views/RestrictionAccess/UserProfileRestriction.ascx");
                                userProfileRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId, resClass.RelativeId, resClass.Name);
                                userProfileRestriction.CloseClicked += RestrictionType_CloseClicked;
                                userProfileRestriction.Visible = !resClass.Void;
                                userProfileRestriction.RestrictionId = restrictionId;
                                userProfileRestriction.UserProfileRestrictionId = resClass.RestrictionTypeId;
                                userProfileRestriction.SetConstraints(resClass.Constraints);
                                pnlRestrictions.Controls.Add(userProfileRestriction);
                                userProfileRestriction.ID = resClass.Name + "_" + resClass.ParentId + "_" + resClass.AbsoluteId + "_" +
                                                     resClass.RelativeId;
                                break;
                            case "main":

                                var restrictionSet = (EachRestriction)
                                    Page.LoadControl("~/Views/RestrictionAccess/Custom/EachRestriction.ascx");
                                // here add the ids ::: seriously and also in webform
                                restrictionSet.SetIds(resClass.ParentId, resClass.AbsoluteId, resClass.RelativeId
                                    , resClass.Name);
                                //restrictionSet.AddRestrictionClicked += AddRestrictionClicked_Clicked;
                                restrictionSet.SubjectId = SubjectId;
                                restrictionSet.Visible = !resClass.Void;
                                pnlRestrictions.Controls.Add(restrictionSet);
                                restrictionSet.RestrictionParentId = resClass.RestrictionTypeParentId;
                                restrictionSet.RestrictionId = resClass.RestrictionTypeId;
                                restrictionSet.SetConstraints(resClass.Constraints);
                                //restrictionSet.AbsoluteId = 
                                restrictionSet.PageKeyForUniqueSession = PageKeyForUniqueSession;
                                if (resClass.Children != null)
                                {
                                    restrictionSet.Chilren = resClass.Children;
                                    //restrictionSet.LoadFromType(resClass.Children);
                                }
                                break;
                            //restrictionSet.ParentId = restrictionId.ToString();
                        }
                    }}
            }
        }

        /// <summary>
        /// [0]-  must, [1]- allany
        /// </summary>
        /// <param name="constraints"></param>
        public void SetConstraints(params object[] constraints)
        {
            if (constraints != null)
            {
                if (constraints.Length == 2)
                {
                    ddlMustMatch.SelectedIndex = Convert.ToBoolean(constraints[0]) ? 0 : 1;
                    ddlAllAny.SelectedIndex = Convert.ToBoolean(constraints[1]) ? 0 : 1;
                }
            }
        }

        private bool _deleted = false;
        bool DeleteRestriction(RestrictionIdName restrictionMain, string[] ids)
        {
            if (restrictionMain.AbsoluteId == ids[0])
            {
                if (ids.Count() == 1)
                {
                    return true;
                }
                var childRestrictionMain = restrictionMain.Children;//new
                var remainIds = ids.ToList();
                remainIds.RemoveAt(0);

                int i = 0;
                foreach (var rm in childRestrictionMain)
                {

                    var returned = DeleteRestriction(rm, remainIds.ToArray());
                    if (returned)
                    {
                        rm.Void = false;
                        //childRestrictionMain.Remove(rm);
                        _deleted = true;
                        return false;
                    }
                    i++;
                }
            }
            return false;
        }

        RestrictionIdName GetParentRestriction(RestrictionIdName restrictionMain, string[] ids)
        {
            if (restrictionMain.AbsoluteId == ids[0])
            {
                if (ids.Count() == 1)
                {
                    return restrictionMain;
                }
                var childRestrictionMain = restrictionMain.Children.Where(x => x.Name == "main");//new
                var remainIds = ids.ToList();
                remainIds.RemoveAt(0);

                int i = 0;
                foreach (var rm in childRestrictionMain)
                {
                    var returned = GetParentRestriction(rm, remainIds.ToArray());
                    if (returned != null)
                    {
                        return returned;
                    }
                    i++;
                }
            }


            return null;
        }

        public void SetIds(string parentId, string absoluteId, string relativeId, string type)
        {
            ParentId = parentId;
            AbsoluteId = absoluteId;
            RelativeId = relativeId;
            Type = type;
        }




        public bool IsValid = true;
        public Restriction GetData()
        {
            var restriction = new Academic.DbEntities.AccessPermission.Restriction()
            {
                Id = RestrictionId
                ,

                MatchMust = ddlMustMatch.SelectedIndex == 0
                ,
                MatchAllAny = ddlAllAny.SelectedIndex == 0
                ,
                Visibility = false
                ,
            };
            if (RestrictionParentId > 0)
            {
                restriction.ParentId = RestrictionParentId;
            }
            //grade
            restriction.GradeRestrictions = new List<GradeRestriction>();

            if (IsValid)
                GetAllGradeRestrictionControls().ForEach(g =>
               {
                   if (g.Visible)
                   {
                       restriction.GradeRestrictions.Add(g.GetGradeRestriction());
                       if (IsValid)
                           IsValid = g.IsValid;
                   }
               });

            restriction.DateRestrictions = new List<DateRestriction>();


            //date
            if (IsValid)
                GetAllDateRestrictionControls().ForEach(g =>
                {
                    if (g.Visible)
                    {
                        restriction.DateRestrictions.Add(g.GetDateRestriction());
                        if (IsValid)
                            IsValid = g.IsValid;
                    }
                });

            //class
            restriction.GroupRestrictions = new List<GroupRestriction>();
            if (IsValid)
                GetAllGroupRestrictionControls().ForEach(g =>
                {
                    if (g.Visible)
                    {
                        restriction.GroupRestrictions.Add(g.GetGroupRestriction());
                        if (IsValid)
                            IsValid = g.IsValid;
                    }
                });

            //userprofile
            restriction.UserProfileRestrictions = new List<Academic.DbEntities.AccessPermission.UserProfileRestriction>();
            if (IsValid)
                GetAllUserProfileRestrictionControls().ForEach(g =>
                {
                    if (g.Visible)
                    {
                        restriction.UserProfileRestrictions.Add(g.GetUserProfileRestriction());
                        if (IsValid)
                            IsValid = g.IsValid;
                    }
                });

            restriction.Restrictions = new List<Restriction>();
            if (IsValid)
            {
                GetAllSubRestrictionControls().ForEach(r =>
                {
                    if (r.Visible)
                    {
                        restriction.Restrictions.Add(r.GetData());
                        if (IsValid)
                            IsValid = r.IsValid;
                    }
                });
            }

            return restriction;

        }

        #endregion

        #region Controls Get, Add and List functions

        #region Add functions

        public void AddControls(List<UserControl> ucList, List<Control> childlist)
        {
            foreach (var uc in ucList)
            {

                multiViewRestrict.ActiveViewIndex = 1;
                NoOfChildRestrictionSets = NoOfChildRestrictionSets + 1;
                pnlRestrictions.Controls.Add(uc);
            }
        }
        public void AddControl(UserControl uc, List<Control> childlist)
        {

            multiViewRestrict.ActiveViewIndex = 1;
            NoOfChildRestrictionSets = NoOfChildRestrictionSets + 1;
            pnlRestrictions.Controls.Add(uc);
        }

        public void AddControls(List<Control> ucList, List<Control> childlist)
        {
            foreach (var uc in ucList)
            {

                multiViewRestrict.ActiveViewIndex = 1;
                NoOfChildRestrictionSets = NoOfChildRestrictionSets + 1;
                pnlRestrictions.Controls.Add(uc);
            }
        }

        //used
        public void AddControl(Control uc, List<Control> childlist = null)
        {
            //if (ChildControls != null)
            //    ChildControls.Add(uc);
            //else ChildControls = new List<Control>() { uc };

            multiViewRestrict.ActiveViewIndex = 1;

            lnkAddActOrRes.Attributes.Add("name", hidRelativeId.Value + "-" + NoOfChildRestrictionSets);

            NoOfChildRestrictionSets = NoOfChildRestrictionSets + 1;
            pnlRestrictions.Controls.Add(uc);
        }


        #endregion

        #region Get functions

        public Panel GetPanel()
        {
            return pnlRestrictions;
        }

        public Control GetControl(string id)
        {
            return pnlRestrictions.FindControl(id);
        }
        public ActivityCompleteRestrictionUC GetControlAsActivityCompleteRestrictionUc(string id)
        {
            var cntrl = pnlRestrictions.FindControl(id) as ActivityCompleteRestrictionUC;
            return cntrl;
        }
        public DateRestrictionUC GetControlAsDateRestrictionUc(string id)
        {
            var cntrl = pnlRestrictions.FindControl(id) as DateRestrictionUC;
            return cntrl;
        }
        public GradeRestrictionUC GetControlAsGradeRestrictionUc(string id)
        {
            var cntrl = pnlRestrictions.FindControl(id) as GradeRestrictionUC;
            return cntrl;
        }
        public GroupRestrictionUC GetControlAsGroupRestrictionUc(string id)
        {
            var cntrl = pnlRestrictions.FindControl(id) as GroupRestrictionUC;
            return cntrl;
        }
        public UserProfileRestriction GetControlAsUserProfileRestrictionUc(string id)
        {
            var cntrl = pnlRestrictions.FindControl(id) as UserProfileRestriction;
            return cntrl;
        }


        #endregion

        #region Listing

        public List<Control> GetAllControls()
        {
            var list = new List<Control>();
            foreach (Control control in pnlRestrictions.Controls)
            {
                if (control.GetType() != typeof(LiteralControl))
                    list.Add(control);
            }
            return list;
        }
        public List<ActivityCompleteRestrictionUC> GetAllActivityCompleteControls()
        {
            var list = new List<ActivityCompleteRestrictionUC>();
            foreach (var control in pnlRestrictions.Controls)
            {
                var act = control as ActivityCompleteRestrictionUC;
                if (act != null)
                    list.Add(act);
            }
            return list;
        }
        public List<DateRestrictionUC> GetAllDateRestrictionControls()
        {
            var list = new List<DateRestrictionUC>();
            foreach (var control in pnlRestrictions.Controls)
            {
                var act = control as DateRestrictionUC;

                if (act != null)
                    if (act.Visible)
                        list.Add(act);
            }
            return list;
        }
        public List<GradeRestrictionUC> GetAllGradeRestrictionControls()
        {
            var list = new List<GradeRestrictionUC>();
            foreach (var control in pnlRestrictions.Controls)
            {
                var act = control as GradeRestrictionUC;
                if (act != null)
                    list.Add(act);
            }
            return list;
        }
        public List<GroupRestrictionUC> GetAllGroupRestrictionControls()
        {
            var list = new List<GroupRestrictionUC>();
            foreach (var control in pnlRestrictions.Controls)
            {
                var act = control as GroupRestrictionUC;
                if (act != null)
                    list.Add(act);
            }
            return list;
        }
        public List<UserProfileRestriction> GetAllUserProfileRestrictionControls()
        {
            var list = new List<UserProfileRestriction>();
            foreach (var control in pnlRestrictions.Controls)
            {
                var act = control as UserProfileRestriction;
                if (act != null)
                    list.Add(act);
            }
            return list;
        }

        public List<EachRestriction> GetAllSubRestrictionControls()
        {
            var list = new List<EachRestriction>();
            foreach (var control in pnlRestrictions.Controls)
            {
                var act = control as EachRestriction;
                if (act != null)
                    list.Add(act);
            }
            return list;
        }

        //public List<EachRestriction> GetAllRestrictionMainControls()
        //{
        //    var list = new List<EachRestriction>();
        //    foreach (var control in ChildControls)// pnlRestrictions.Controls)
        //    {
        //        var act = control as EachRestriction;
        //        if (act != null)
        //            list.Add(act);
        //    }
        //    return list;
        //}

        public List<EachRestriction> GetAllChildMainRestrictions()
        {
            var list = new List<EachRestriction>();
            foreach (var control in pnlRestrictions.Controls)// pnlRestrictions.Controls)
            {
                var act = control as EachRestriction;
                if (act != null)
                    list.Add(act);
            }
            return list;
        }

        #endregion Listing

        #endregion

        //below codes are unused for now
        //public void PopulateRestrictions(bool showView = false)
        //{
        //    var dict = Session["Restriction"] as Dictionary<string, ControlCollection>;
        //    if (dict != null)
        //    {
        //        var panel = dict[hidId.Value];
        //        if (panel != null)
        //        {
        //            var showView1 = false;
        //            //pnlRestrictions.Controls.Clear();
        //            for (var i = 0; i < panel.Count; i++)//Control p in panel)
        //            {
        //                var cntrl = panel[i];
        //                var type = panel[i].GetType();
        //                if (type != typeof(System.Web.UI.LiteralControl))
        //                {
        //                    if (type == this.GetType())
        //                    {
        //                        var restrictionset = panel[i] as RestrictionThird;
        //                        if (restrictionset != null)
        //                        {
        //                            restrictionset.PopulateRestrictions(true);
        //                        }
        //                    }

        //                    var firstCnt = pnlRestrictions.Controls.Count;

        //                    this.pnlRestrictions.Controls.Add(cntrl);
        //                    var split = hidId.Value.Split(new char[] { '_' });
        //                    pnlRestrictions.Controls.Add((split.Count() >= 2) ? cntrl : new LiteralControl());

        //                    var lastCnt = pnlRestrictions.Controls.Count;

        //                    if (firstCnt == lastCnt)
        //                    {
        //                        pnlRestrictions.Controls.Add(cntrl);
        //                    }

        //                    showView1 = true;
        //                }
        //            }
        //            if (showView1 && showView)
        //                multiViewRestrict.ActiveViewIndex = 1;
        //        }
        //        else
        //        {
        //            panel = pnlRestrictions.Controls;
        //        }
        //    }

        //}


    }
}