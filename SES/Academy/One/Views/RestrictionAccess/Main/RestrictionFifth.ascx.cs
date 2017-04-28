using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.Views.RestrictionAccess.Main
{
    public partial class RestrictionFifth : System.Web.UI.UserControl
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            //btnAddRestriction.Attributes.Add("name", hidRelativeId.Value);// = "btnAddRestriction" + hidId.Value;
            lnkAddActOrRes.Attributes.Add("name", hidRelativeId.Value + "-" + NoOfChildRestrictionSets);
           
        }

        RestrictionFifth _foundMain;
        RestrictionIdName GetParentRestriction(RestrictionIdName restrictionMain, string[] ids, RestrictionFifth uiMaiin)
        {
            if (restrictionMain.AbsoluteId == ids[0])
            {
                if (ids.Count() == 1)
                {
                    _foundMain = uiMaiin;
                    return restrictionMain;
                }
                var childRestrictionMainUi = uiMaiin.GetAllChildMainRestrictions();//old
                //var childrens = foundMain.GetAllControls();

                var childRestrictionMain = restrictionMain.Children.Where(x => x.Name == "main");//new
                var remainIds = ids.ToList();
                remainIds.RemoveAt(0);

                int i = 0;
                foreach (var rm in childRestrictionMain)
                {
                    //var returned = GetParentRestriction(rm, remainIds.ToArray());//old
                    var temp = childRestrictionMainUi[i];

                    var returned = GetParentRestriction(rm, remainIds.ToArray(), temp);
                    if (returned != null)
                    {
                        //return foundMain
                        return returned;
                    }
                    i++;
                }
            }


            return null;
        }
        void Choose_RestrictionChoosenNew(object sender, Academic.ViewModel.IdAndNameEventArgs e)
        {
            //var restrictionId = Session["CurrentRestrictionId"];
            //var restriction = Session["ControlList"] as RestrictionIdName;
            ////if (list == null) list = new List<RestrictionIdName>();
            //if (restrictionId != null)
            //{
            //    var split = restrictionId.ToString().Split(new char[] { '_' });

            //    var parent = GetParentRestriction(restriction, split, RestrictionFifth1);


            //    if (parent != null && _foundMain != null) //new
            //    {
            //        var list = parent.Children; //[restrictionId.ToString()];

            //        var noOfChildRestrictions = parent.Children.Count;
            //        var thisId = (noOfChildRestrictions + 1);
            //        RestrictionIdName resClass = null;
            //        switch (e.Id)
            //        {
            //            case 0:
            //                resClass = GetRestriction(restrictionId.ToString(), "activity"
            //                    , thisId.ToString(), restrictionId + "_" + thisId
            //                    , "", new List<RestrictionIdName>());

            //                var activityCompleteRestriction = (ActivityCompleteRestrictionUC)
            //                    Page.LoadControl("~/Views/RestrictionAccess/ActivityCompleteRestrictionUC.ascx");
            //                activityCompleteRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId,
            //                    resClass.RelativeId, resClass.Name);

            //                _foundMain.AddControl(activityCompleteRestriction);
            //                break;
            //            case 1:
            //                resClass = GetRestriction(restrictionId.ToString(), "date"
            //                    , thisId.ToString(), restrictionId + "_" + thisId
            //                    , "", new List<RestrictionIdName>());
            //                var dateRestriction = (DateRestrictionUC)
            //                    Page.LoadControl("~/Views/RestrictionAccess/DateRestrictionUC.ascx");
            //                dateRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId,
            //                    resClass.RelativeId, resClass.Name);
            //                _foundMain.AddControl(dateRestriction);
            //                break;
            //            case 2:
            //                resClass = GetRestriction(restrictionId.ToString(), "grade"
            //                    , thisId.ToString(), restrictionId + "_" + thisId
            //                    , "", new List<RestrictionIdName>());
            //                var gradeRestriction = (GradeRestrictionUC)
            //                    Page.LoadControl("~/Views/RestrictionAccess/GradeRestrictionUC.ascx");
            //                gradeRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId,
            //                    resClass.RelativeId, resClass.Name);
            //                _foundMain.AddControl(gradeRestriction);
            //                break;
            //            case 3:
            //                resClass = GetRestriction(restrictionId.ToString(), "group"
            //                    , thisId.ToString(), restrictionId + "_" + thisId
            //                    , "", new List<RestrictionIdName>());
            //                var groupRestriction = (GroupRestrictionUC)
            //                    Page.LoadControl("~/Views/RestrictionAccess/GroupRestrictionUC.ascx");
            //                groupRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId,
            //                    resClass.RelativeId, resClass.Name);
            //                _foundMain.AddControl(groupRestriction);
            //                break;
            //            case 4:
            //                resClass = GetRestriction(restrictionId.ToString(), "userprofile"
            //                    , thisId.ToString(), restrictionId + "_" + thisId
            //                    , "", new List<RestrictionIdName>());
            //                var userProfileRestriction = (UserProfileRestriction)
            //                    Page.LoadControl("~/Views/RestrictionAccess/UserProfileRestriction.ascx");
            //                userProfileRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId,
            //                    resClass.RelativeId, resClass.Name);
            //                _foundMain.AddControl(userProfileRestriction);
            //                break;
            //            case 5:
            //                resClass = GetRestriction(restrictionId.ToString(), "main"
            //                    , thisId.ToString(), restrictionId + "_" + thisId
            //                    , "", new List<RestrictionIdName>());

            //                var restrictionSetUc = (RestrictionFifth)
            //                    Page.LoadControl("~/Views/RestrictionAccess/Main/RestrictionFifth.ascx");
            //                restrictionSetUc.SetIds(resClass.ParentId, resClass.AbsoluteId,
            //                    resClass.RelativeId, resClass.Name);
            //                _foundMain.AddControl(restrictionSetUc);

            //                break;
            //        }
            //        if (resClass != null)
            //            list.Add(resClass);

            //        //LoadFromType();

            //    }
            //}
        }

        public List<Control> ChildControls { get; set; }

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



        public void LoadFromType(List<Academic.ViewModel.RestrictionIdName> list)
        {
            if (list != null)
            {
                if (list.Count > 0)
                    multiViewRestrict.ActiveViewIndex = 1;

                foreach (var resClass in list)
                {
                    switch (resClass.Name)
                    {
                        case "activity":
                            var activityCompleteRestriction = (ActivityCompleteRestrictionUC)
                                Page.LoadControl("~/Views/RestrictionAccess/ActivityCompleteRestrictionUC.ascx");
                            activityCompleteRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId, resClass.RelativeId, resClass.Name);
                            activityCompleteRestriction.CloseClicked += RestrictionType_CloseClicked;

                            pnlRestrictions.Controls.Add(activityCompleteRestriction);
                            break;
                        case "date":
                            var dateRestriction = (DateRestrictionUC)
                                Page.LoadControl("~/Views/RestrictionAccess/DateRestrictionUC.ascx");
                            dateRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId, resClass.RelativeId, resClass.Name);
                            dateRestriction.CloseClicked += RestrictionType_CloseClicked;

                            pnlRestrictions.Controls.Add(dateRestriction);
                            break;

                        case "grade":
                            var gradeRestriction = (GradeRestrictionUC)
                                Page.LoadControl("~/Views/RestrictionAccess/GradeRestrictionUC.ascx");
                            gradeRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId, resClass.RelativeId
                                , resClass.Name,0);
                            gradeRestriction.CloseClicked += RestrictionType_CloseClicked;

                            //pnlRestrictions.Controls.Add(gradeRestriction);
                            pnlRestrictions.Controls.Add(gradeRestriction);
                            break;

                        case "group":
                            var groupRestriction = (GroupRestrictionUC)
                                Page.LoadControl("~/Views/RestrictionAccess/GroupRestrictionUC.ascx");
                            groupRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId, resClass.RelativeId
                                , resClass.Name,0);
                            groupRestriction.CloseClicked += RestrictionType_CloseClicked;

                            pnlRestrictions.Controls.Add(groupRestriction);
                            break;

                        case "userprofile":
                            var userProfileRestriction = (UserProfileRestriction)
                                Page.LoadControl("~/Views/RestrictionAccess/UserProfileRestriction.ascx");
                            userProfileRestriction.SetIds(resClass.ParentId, resClass.AbsoluteId, resClass.RelativeId, resClass.Name);
                            userProfileRestriction.CloseClicked += RestrictionType_CloseClicked;

                            pnlRestrictions.Controls.Add(userProfileRestriction);
                            break;
                        case "main":

                            var restrictionSet = (RestrictionFifth)
                                Page.LoadControl("~/Views/RestrictionAccess/Main/RestrictionFifth.ascx");
                            // here add the ids ::: seriously and also in webform
                            restrictionSet.SetIds(resClass.ParentId, resClass.AbsoluteId, resClass.RelativeId, resClass.Name);
                            pnlRestrictions.Controls.Add(restrictionSet);
                            if (resClass.Children != null)
                            {
                                restrictionSet.LoadFromType(resClass.Children);
                            }
                            break;
                    }
                }
            }
        }
        
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
                        childRestrictionMain.Remove(rm);
                        return true;
                    }
                    i++;
                }
            }
            return false;
        }


        void RestrictionType_CloseClicked(object sender, RestrictionEventArgs e)
        {
            var restList = Session["ControlList"] as RestrictionIdName;
            if (restList != null)
            {
                var split = e.RelativeId.Split('_');
                // Panel pnlRestrictions = RestrictionFifth1.GetPanel();
                switch (e.Type)
                {
                    case "activity":
                        var acntrl = sender as ActivityCompleteRestrictionUC;
                        if (acntrl != null)
                        {
                            if (DeleteRestriction(restList, split))
                                pnlRestrictions.Controls.Remove(acntrl);
                        }

                        break;
                    case "date":
                        var dcntrl = sender as DateRestrictionUC;
                        if (dcntrl != null)
                        {
                            if (DeleteRestriction(restList, split))
                                pnlRestrictions.Controls.Remove(dcntrl);
                        }
                        break;
                    case "grade":
                        var gradecntrl = sender as GradeRestrictionUC;
                        if (gradecntrl != null)
                        {
                            if (DeleteRestriction(restList, split))
                                pnlRestrictions.Controls.Remove(gradecntrl);
                        }
                        break;
                    case "group":
                        var groupcntrl = sender as GroupRestrictionUC;
                        if (groupcntrl != null)
                        {
                            if (DeleteRestriction(restList, split))
                                pnlRestrictions.Controls.Remove(groupcntrl);
                        }
                        break;
                    case "userprofile":
                        var ucntrl = sender as UserProfileRestriction;
                        if (ucntrl != null)
                        {
                            if (DeleteRestriction(restList, split))
                                pnlRestrictions.Controls.Remove(ucntrl);
                        }
                        break;
                }
            }

        }


        public void SetIds(string parentId, string absoluteId, string relativeId, string type)
        {
            ParentId = parentId;
            AbsoluteId = absoluteId;
            RelativeId = relativeId;
            Type = type;
        }

        #region Controls Get, Add and List functions

        #region Add functions

        public void AddControls(List<UserControl> ucList, List<Control> childlist)
        {
            foreach (var uc in ucList)
            {
                if (ChildControls != null)
                    ChildControls.Add(uc);
                else ChildControls = new List<Control>() { uc };

                multiViewRestrict.ActiveViewIndex = 1;
                NoOfChildRestrictionSets = NoOfChildRestrictionSets + 1;
                pnlRestrictions.Controls.Add(uc);
            }
        }
        public void AddControl(UserControl uc, List<Control> childlist)
        {
            if (ChildControls != null)
                ChildControls.Add(uc);
            else ChildControls = new List<Control>() { uc };

            multiViewRestrict.ActiveViewIndex = 1;
            NoOfChildRestrictionSets = NoOfChildRestrictionSets + 1;
            pnlRestrictions.Controls.Add(uc);
        }

        public void AddControls(List<Control> ucList, List<Control> childlist)
        {
            foreach (var uc in ucList)
            {
                if (ChildControls != null)
                    ChildControls.Add(uc);
                else ChildControls = new List<Control>() { uc };

                multiViewRestrict.ActiveViewIndex = 1;
                NoOfChildRestrictionSets = NoOfChildRestrictionSets + 1;
                pnlRestrictions.Controls.Add(uc);
            }
        }

        //used
        public void AddControl(Control uc, List<Control> childlist = null)
        {
            if (ChildControls != null)
                ChildControls.Add(uc);
            else ChildControls = new List<Control>() { uc };

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

        public List<RestrictionFifth> GetAllRestrictionMainControls()
        {
            var list = new List<RestrictionFifth>();
            foreach (var control in ChildControls)// pnlRestrictions.Controls)
            {
                var act = control as RestrictionFifth;
                if (act != null)
                    list.Add(act);
            }
            return list;
        }

        public List<RestrictionFifth> GetAllChildMainRestrictions()
        {
            var list = new List<RestrictionFifth>();
            foreach (var control in pnlRestrictions.Controls)// pnlRestrictions.Controls)
            {
                var act = control as RestrictionFifth;
                if (act != null)
                    list.Add(act);
            }
            return list;
        }

        #endregion Listing

        #endregion

        public int MultiViewActiveViewIndex
        {
            set { multiViewRestrict.ActiveViewIndex = value; }
        }

        
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