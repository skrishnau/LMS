using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.ViewModel;

namespace One.Views.RestrictionAccess.Main
{
    public partial class WebFormFifth : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    //var con = RestrictionFourth1.GetAllControls();
                    //var grade = RestrictionFourth1.GetAllGradeRestrictionControls();
                    string parameter = Request["__EVENTARGUMENT"]; // parameter
                    // Request["__EVENTTARGET"]; // btnSave
                    if (!string.IsNullOrEmpty(parameter))
                    {
                        //after dash(-) there is NoOfChildRestrictions
                        var split = parameter.Split(new char[] { '-' });
                        if (split.Count() >= 2)
                        {
                            Session["NoOfChildRestrictions"] = split[1];
                            Session["CurrentRestrictionId"] = split[0];
                        }
                    }
                }
                else
                {
                    //Session["RestrictionControl"] = this.RestrictionFourth1;
                    //<Main Restriction Id, Dict< child Id, 
                    Session["ControlList"] = new RestrictionIdName()
                    {
                        AbsoluteId = RestrictionFifth1.AbsoluteId,
                        ParentId = "0",
                        Name = "Main",
                        Children = new List<RestrictionIdName>()

                    };
                }

                //ChooseRestrictionTypeUC1.RestrictionChoosen += Choose_RestrictionChoosen;//old
                ChooseRestrictionTypeUC1.RestrictionChoosen += Choose_RestrictionChoosenNew;
                //PopulateControls();//old
                LoadFromType();
            }
            catch { }

        }

        //ok
        public void LoadFromType()
        {
            Panel parent = RestrictionFifth1.GetPanel();
            var restriction = Session["ControlList"] as RestrictionIdName;
            if (restriction != null)
            {
                var list = restriction.Children;
                if (list != null)
                {
                    if (list.Count > 0) if (list.Count > 0)
                            RestrictionFifth1.MultiViewActiveViewIndex = 1;
                    foreach (var resClass in list)
                    {
                        switch (resClass.Name)
                        {
                            case "activity":
                                var activityCompleteRestriction = (ActivityCompleteRestrictionUC)
                                    Page.LoadControl("~/Views/RestrictionAccess/ActivityCompleteRestrictionUC.ascx");
                                parent.Controls.Add(activityCompleteRestriction);
                                break;
                            case "date":
                                var dateRestriction = (DateRestrictionUC)
                                    Page.LoadControl("~/Views/RestrictionAccess/DateRestrictionUC.ascx");
                                parent.Controls.Add(dateRestriction);
                                break;

                            case "grade":
                                var gradeRestriction = (GradeRestrictionUC)
                                    Page.LoadControl("~/Views/RestrictionAccess/GradeRestrictionUC.ascx");
                                //pnlRestrictions.Controls.Add(gradeRestriction);
                                parent.Controls.Add(gradeRestriction);
                                break;

                            case "group":
                                var groupRestriction = (GroupRestrictionUC)
                                    Page.LoadControl("~/Views/RestrictionAccess/GroupRestrictionUC.ascx");
                                //pnlRestrictions.Controls.Add(groupRestriction);
                                parent.Controls.Add(groupRestriction);
                                break;

                            case "userprofile":
                                var userProfileRestriction = (UserProfileRestriction)
                                    Page.LoadControl("~/Views/RestrictionAccess/UserProfileRestriction.ascx");
                                //pnlRestrictions.Controls.Add(userProfileRestriction);
                                parent.Controls.Add(userProfileRestriction);
                                break;
                            case "main":

                                var restrictionSet = (RestrictionFifth)
                                    Page.LoadControl("~/Views/RestrictionAccess/Main/RestrictionFifth.ascx");
                                parent.Controls.Add(restrictionSet);
                                restrictionSet.AbsoluteId = resClass.AbsoluteId;
                                restrictionSet.RelativeId = resClass.RelativeId;
                                restrictionSet.ChildControls = new List<Control>();
                                restrictionSet.ParentId = resClass.ParentId;
                                if (resClass.Children != null)
                                {
                                    restrictionSet.LoadFromType(resClass.Children);
                                }
                                break;
                            //restrictionSet.ParentId = restrictionId.ToString();

                        }

                    }
                }
            }
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
            var restrictionId = Session["CurrentRestrictionId"];
            var restriction = Session["ControlList"] as RestrictionIdName;
            //if (list == null) list = new List<RestrictionIdName>();
            if (restrictionId != null)
            {
                var split = restrictionId.ToString().Split(new char[] { '_' });

                var parent = GetParentRestriction(restriction, split, RestrictionFifth1);


                if (parent != null && _foundMain != null) //new
                {
                    var list = parent.Children; //[restrictionId.ToString()];
                    switch (e.Id)
                    {
                        case 0:
                            list.Add(new RestrictionIdName() { Name = "activity" });
                            var activityCompleteRestriction = (ActivityCompleteRestrictionUC)
                                Page.LoadControl("~/Views/RestrictionAccess/ActivityCompleteRestrictionUC.ascx");
                            _foundMain.AddControl(activityCompleteRestriction);
                            break;
                        case 1:
                            list.Add(new RestrictionIdName() { Name = "date" });
                            var dateRestriction = (DateRestrictionUC)
                                Page.LoadControl("~/Views/RestrictionAccess/DateRestrictionUC.ascx");
                            _foundMain.AddControl(dateRestriction);
                            break;
                        case 2:
                            list.Add(new RestrictionIdName() { Name = "grade" });
                            var gradeRestriction = (GradeRestrictionUC)
                                Page.LoadControl("~/Views/RestrictionAccess/GradeRestrictionUC.ascx");
                            //pnlRestrictions.Controls.Add(gradeRestriction);
                            _foundMain.AddControl(gradeRestriction);
                            break;
                        case 3:
                            list.Add(new RestrictionIdName() { Name = "group" });
                            var groupRestriction = (GroupRestrictionUC)
                                Page.LoadControl("~/Views/RestrictionAccess/GroupRestrictionUC.ascx");
                            //pnlRestrictions.Controls.Add(groupRestriction);
                            _foundMain.AddControl(groupRestriction);
                            break;
                        case 4:
                            list.Add(new RestrictionIdName() { Name = "userprofile" });
                            var userProfileRestriction = (UserProfileRestriction)
                                Page.LoadControl("~/Views/RestrictionAccess/UserProfileRestriction.ascx");
                            //pnlRestrictions.Controls.Add(userProfileRestriction);
                            _foundMain.AddControl(userProfileRestriction);
                            break;
                        case 5:
                            //pnlRestrictions.Controls.Add(restrictionSet);

                            var noOfChildRestrictions = parent.Children.Count;
                            var thisId = (noOfChildRestrictions + 1);

                            var resClass = new RestrictionIdName();

                            resClass.SetData(restrictionId.ToString(), "main"
                                , thisId.ToString(), restrictionId + "_" + thisId
                                , "", new List<RestrictionIdName>());

                            //these assignments are done through function above
                            //restrictionSet.ParentId = restrictionId.ToString();
                            //restrictionSet.AbsoluteId = thisId.ToString();
                            //restrictionSet.RelativeId = restrictionId + "_" + thisId;
                            //restrictionSet.Children = new List<RestrictionIdName>();

                            list.Add(resClass);

                            //NEEDED TO ADD CONTROL FIND CONTROL HERE AND ADD HERE

                            var restrictionSetUc = (RestrictionFifth)
                                Page.LoadControl("~/Views/RestrictionAccess/Main/RestrictionFifth.ascx");
                            restrictionSetUc.AbsoluteId = resClass.AbsoluteId;
                            restrictionSetUc.RelativeId = resClass.RelativeId;
                            restrictionSetUc.ChildControls = new List<Control>();
                            restrictionSetUc.ParentId = resClass.ParentId;
                            _foundMain.AddControl(restrictionSetUc);

                            break;
                    }
                    //LoadFromType();

                }
            }
        }


        //public void PopulateControls()
        //{
        //    var restrictionControl = Session["RestrictionControl"] as RestrictionFourth;
        //    if (restrictionControl != null)
        //    {
        //        var panel = RestrictionFourth1.GetPanel();
        //        if (restrictionControl.ChildControls != null)
        //            foreach (var cntrl in restrictionControl.ChildControls)
        //            {
        //                RestrictionFourth1.AddControl(cntrl);
        //                //LoadControl(panel, cntrl);
        //            }
        //    }
        //}

        //public void LoadControl(RestrictionFourth parent, Control child)
        //{
        //    parent.Controls.Add(child);
        //    var resCntrl = child as RestrictionFourth;
        //    if (resCntrl != null)
        //    {
        //        foreach (var cntrl in resCntrl.ChildControls)
        //        {
        //            LoadControl(resCntrl, cntrl);
        //        }
        //    }
        //}

        //here ids hold ids of parent in sequenc order

        private RestrictionFourth GetParentRestriction(RestrictionFourth restrictionMain, string[] ids)
        {
            if (restrictionMain.AbsoluteId == ids[0])
            {
                if (ids.Count() == 1)
                {
                    return restrictionMain;
                }
                var childRestrictionMain = restrictionMain.GetAllRestrictionMainControls();
                var remainIds = ids.ToList();
                remainIds.RemoveAt(0);

                foreach (var rm in childRestrictionMain)
                {
                    var returned = GetParentRestriction(rm, remainIds.ToArray());
                    if (returned != null)
                        return returned;
                }
            }


            return null;
        }


        //void Choose_RestrictionChoosen(object sender, Academic.ViewModel.IdAndNameEventArgs e)
        //{
        //    var restrictionId = Session["CurrentRestrictionId"];
        //    var dictList = Session["ControlList"] as Dictionary<string, List<IdAndName>>;

        //    if (restrictionId != null)
        //    {
        //        var split = restrictionId.ToString().Split(new char[] { '_' });
        //        var restrictionMain = Session["RestrictionControl"] as RestrictionFourth;
        //        if (restrictionMain != null)
        //        {
        //            var parent = GetParentRestriction(restrictionMain, split);
        //            if (parent != null)
        //            {
        //                if (parent.ChildControls == null)
        //                {
        //                    parent.ChildControls = new List<Control>();
        //                }

        //                switch (e.Id)
        //                {
        //                    case 0:
        //                        var activityCompleteRestriction = (ActivityCompleteRestrictionUC)
        //                            Page.LoadControl("~/Views/RestrictionAccess/ActivityCompleteRestrictionUC.ascx");
        //                        //pnlRestrictions.Controls.Add(activityCompleteRestriction);
        //                        parent.AddControl(activityCompleteRestriction);

        //                        break;
        //                    case 1:
        //                        var dateRestriction = (DateRestrictionUC)
        //                            Page.LoadControl("~/Views/RestrictionAccess/DateRestrictionUC.ascx");
        //                        //pnlRestrictions.Controls.Add(dateRestriction);
        //                        parent.AddControl(dateRestriction);
        //                        break;

        //                    case 2:
        //                        var gradeRestriction = (GradeRestrictionUC)
        //                            Page.LoadControl("~/Views/RestrictionAccess/GradeRestrictionUC.ascx");
        //                        //pnlRestrictions.Controls.Add(gradeRestriction);
        //                        parent.AddControl(gradeRestriction);
        //                        break;

        //                    case 3:
        //                        var groupRestriction = (GroupRestrictionUC)
        //                            Page.LoadControl("~/Views/RestrictionAccess/GroupRestrictionUC.ascx");
        //                        //pnlRestrictions.Controls.Add(groupRestriction);
        //                        parent.AddControl(groupRestriction);
        //                        break;

        //                    case 4:
        //                        var userProfileRestriction = (UserProfileRestriction)
        //                            Page.LoadControl("~/Views/RestrictionAccess/UserProfileRestriction.ascx");
        //                        //pnlRestrictions.Controls.Add(userProfileRestriction);
        //                        parent.AddControl(userProfileRestriction);
        //                        break;
        //                    case 5:
        //                        var restrictionSet = (RestrictionFourth)
        //                            Page.LoadControl("~/Views/RestrictionAccess/RestrictionFourth.ascx");
        //                        //pnlRestrictions.Controls.Add(restrictionSet);
        //                        restrictionSet.ParentId = restrictionId.ToString();
        //                        //var ids = hidId.Value.Split(new char[] {'_'});
        //                        //NoOfChildRestrictionSets = NoOfChildRestrictionSets + 1;
        //                        var noOfChildRestrictions = Session["NoOfChildRestrictions"];
        //                        if (noOfChildRestrictions != null)
        //                        {
        //                            var thisId = (Convert.ToInt32(noOfChildRestrictions) + 1);
        //                            restrictionSet.RelativeId = restrictionId + "_" + thisId;
        //                            restrictionSet.AbsoluteId = thisId.ToString();
        //                        }
        //                        // restrictionSet.ID = "restrictionUc_" + restrictionSet.ThisId;
        //                        parent.AddControl(restrictionSet);
        //                        break;
        //                }
        //            }

        //        }
        //    }

        //    PopulateControls();
        //    //PopulateRestrictions();
        //}


        //Below this are unused codes



        //public void LoadAllControls()
        //{
        //    var dict = Session["Restriction"] as Dictionary<string, ControlCollection>;
        //    if (dict != null)
        //    {
        //        var keys = dict.Keys;
        //        foreach (var key in keys)
        //        {
        //            var controls = dict[key];
        //            if (controls != null)
        //            {
        //                foreach (Control control in controls)
        //                {
        //                    var type = dict[key].GetType();
        //                    if (type == typeof(RestrictionFourth))
        //                    {
        //                        RestrictionFourth1.AddControl(control);
        //                    }
        //                }
        //            }


        //        }

        //    }
        //}

        //void ChooseRestrictionTypeUC1_RestrictionChoosen(object sender, Academic.ViewModel.IdAndNameEventArgs e)
        //{
        //    //new IdAndName(){Id = 0, Name = "Activity completion"},
        //    //     new IdAndName(){Id = 1, Name = "Date"},
        //    //     new IdAndName(){Id = 2, Name = "Grade"},
        //    //     new IdAndName(){Id = 3, Name = "Group"},
        //    //     new IdAndName(){Id = 4, Name = "User profile"},
        //    //     new IdAndName(){Id = 5, Name = "Restriction set"},
        //    //custom_dialog_div.Visible = false;
        //    //var sentby = sender as ChooseRestrictionTypeUC;
        //    //var restrictionIdSent = e.RefIdString;
        //    //uncomment this
        //    //multiViewRestrict.ActiveViewIndex = 1;
        //    var restrictionId = Session["CurrentRestrictionId"];
        //    if (restrictionId != null)
        //    {
        //        var dict = Session["Restriction"] as Dictionary<string, ControlCollection>;
        //        if (dict != null)
        //        {
        //            var panel = dict[restrictionId.ToString()];
        //            if (panel != null)
        //            {
        //                switch (e.Id)
        //                {

        //                    case 0:
        //                        var activityCompleteRestriction = (ActivityCompleteRestrictionUC)
        //                            Page.LoadControl("~/Views/RestrictionAccess/ActivityCompleteRestrictionUC.ascx");
        //                        //pnlRestrictions.Controls.Add(activityCompleteRestriction);

        //                        //if (panel != null)
        //                        {
        //                            panel.Add(activityCompleteRestriction);
        //                        }
        //                        break;
        //                    case 1:
        //                        var dateRestriction = (DateRestrictionUC)
        //                            Page.LoadControl("~/Views/RestrictionAccess/DateRestrictionUC.ascx");
        //                        //pnlRestrictions.Controls.Add(dateRestriction);
        //                        //if (panel != null)
        //                        {
        //                            panel.Add(dateRestriction);
        //                        }
        //                        break;

        //                    case 2:
        //                        var gradeRestriction = (GradeRestrictionUC)
        //                            Page.LoadControl("~/Views/RestrictionAccess/GradeRestrictionUC.ascx");
        //                        //pnlRestrictions.Controls.Add(gradeRestriction);
        //                        //if (panel != null)
        //                        {
        //                            panel.Add(gradeRestriction);
        //                        }
        //                        break;

        //                    case 3:
        //                        var groupRestriction = (GroupRestrictionUC)
        //                            Page.LoadControl("~/Views/RestrictionAccess/GroupRestrictionUC.ascx");
        //                        //pnlRestrictions.Controls.Add(groupRestriction);
        //                        //if (panel != null)
        //                        {
        //                            panel.Add(groupRestriction);
        //                        }
        //                        break;

        //                    case 4:
        //                        var userProfileRestriction = (UserProfileRestriction)
        //                            Page.LoadControl("~/Views/RestrictionAccess/UserProfileRestriction.ascx");
        //                        //pnlRestrictions.Controls.Add(userProfileRestriction);

        //                        //if (panel != null)
        //                        {
        //                            panel.Add(userProfileRestriction);
        //                        }
        //                        break;
        //                    case 5:
        //                        var restrictionSet = (RestrictionFourth)
        //                            Page.LoadControl("~/Views/RestrictionAccess/RestrictionFourth.ascx");
        //                        //pnlRestrictions.Controls.Add(restrictionSet);
        //                        restrictionSet.ParentId = restrictionId.ToString();
        //                        //var ids = hidId.Value.Split(new char[] {'_'});
        //                        //NoOfChildRestrictionSets = NoOfChildRestrictionSets + 1;
        //                        var noOfChildRestrictions = Session["NoOfChildRestrictions"];
        //                        if (noOfChildRestrictions != null)
        //                        {
        //                            restrictionSet.ThisId = restrictionId + "_" + (Convert.ToInt32(noOfChildRestrictions) + 1);
        //                        }
        //                        // restrictionSet.ID = "restrictionUc_" + restrictionSet.ThisId;
        //                        //if (panel != null)
        //                        {
        //                            panel.Add(restrictionSet);
        //                        }
        //                        break;

        //                }
        //            }
        //        }
        //    }

        //    //PopulateRestrictions();

        //    //Session["Restriction" ] = pnlRestrictions.Controls;
        //    //var restrictions =  Session["Restriction"] as Dictionary<string,ControlCollection>;// = pnlRestrictions.Controls;
        //    // if (restrictions != null)
        //    // {
        //    //     restrictions[hidParentId.Value]= pnlRestrictions.Controls;
        //    // }
        //}

        //void PopulateRestrictions()
        //{

        //    var dict = Session["Restriction"] as Dictionary<string, ControlCollection>;
        //    if (dict != null)
        //    {
        //        //restrictionfourth1.PopulateRestrictions(true);
        //    }
        //}

    }
}