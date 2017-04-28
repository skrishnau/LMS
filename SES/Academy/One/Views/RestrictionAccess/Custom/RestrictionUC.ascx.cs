using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.AccessPermission;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Views.RestrictionAccess.Main;
using WebGrease.Css.Extensions;
using One.Values.MemberShip;

namespace One.Views.RestrictionAccess.Custom
{
    public partial class RestrictionUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    var cntrl = Session["ControlList_" + hidPageKeyForUniqueSession.Value] as RestrictionIdName;
                    if (cntrl == null)
                    {
                        //var key = Guid.NewGuid().ToString();
                        //hidPageKeyForUniqueSession.Value = key;
                        //EachRestriction1.PageKeyForUniqueSession = key;
                        //Session["ControlList_" + key] = new RestrictionIdName()
                        //{
                        //    AbsoluteId = EachRestriction1.AbsoluteId,
                        //    ParentId = "0",
                        //    Name = "Main",
                        //    Children = new List<RestrictionIdName>(),
                        //    RelativeId = "1"
                        //};
                        Response.Redirect("~/Views/All_Resusable_Codes/Error/ErrorPage.aspx?returl=" + Page.Request.Url.PathAndQuery);
                    }
                }
                else
                {
                    EachRestriction1.IsFirstRestriction = true;
                    //Session["RestrictionControl"] = this.RestrictionFourth1;
                    //<Main Restriction Id, Dict< child Id, 
                    //if (hidPageKeyForUniqueSession.Value == "")
                    //{
                    var key = Guid.NewGuid().ToString();
                    hidPageKeyForUniqueSession.Value = key;
                    EachRestriction1.PageKeyForUniqueSession = key;

                    Session["ControlList_" + key] = new RestrictionIdName()
                    {
                        AbsoluteId = EachRestriction1.AbsoluteId,
                        ParentId = "0",
                        Name = "Main",
                        Children = new List<RestrictionIdName>(),
                        RelativeId = "1"
                    };
                    SetRestriction();

                }
                //ChooseRestrictionTypeUC1.RestrictionChoosen += Choose_RestrictionChoosen;//old
                //ChooseRestrictionTypeUC1.RestrictionChoosen += Choose_RestrictionChoosenNew;
                //PopulateControls();//old
                //LoadFromType();
            }
            catch { }

        }

        //ok--but commented for now

        public int SubjectId
        {
            get { return EachRestriction1.SubjectId; }
            set { EachRestriction1.SubjectId = value; }
        }
        public bool IsValid = true;

        public Restriction GetRestriction()
        {
            var data = EachRestriction1.GetData();
            IsValid = EachRestriction1.IsValid;
            return data;
        }

        public bool ActivityOrResource
        {
            get { return Convert.ToBoolean(hidActivityOrResource.Value); }
            set { hidActivityOrResource.Value = value.ToString(); }
        }

        public byte ActivityOrResourceType
        {
            get { return Convert.ToByte(hidActivityResourceType.Value); }
            set { hidActivityResourceType.Value = value.ToString(); }
        }

        public int ActivityOrResourceId
        {
            get { return Convert.ToInt32(hidActivityOrResourceId.Value); }
            set { hidActivityOrResourceId.Value = value.ToString(); }
        }
        /// <summary>
        /// ONly used in restriction of section
        /// </summary>
        public int SectionId
        {
            get { return Convert.ToInt32(hidSectionId.Value); }
            set { hidSectionId.Value = value.ToString(); }
        }

        //public Academic.DbEntities.Subjects.SubjectSection Section;


        /// <summary>
        /// Iniital call...
        /// </summary>
        void SetRestriction()
        {
            using (var helper = new DbHelper.ActAndRes())
            {
                var sectionId = SectionId;
                if (sectionId > 0) //then its section
                {
                    using (var secHelper = new DbHelper.SubjectSection())
                    {
                        var section = secHelper.GetSection(sectionId);
                        if (section != null && section.Restriction != null)
                        {
                            EachRestriction1.RestrictionId = section.RestrictionId ?? 0;
                            EachRestriction1.SetConstraints(section.Restriction.MatchMust, section.Restriction.MatchAllAny);
                            var rSession = Session["ControlList_" + hidPageKeyForUniqueSession.Value] as RestrictionIdName;
                            var user = Page.User as CustomPrincipal;

                            if (user != null)
                            {
                                if (rSession != null)
                                {
                                    var parent = rSession;
                                    SetRestriction(section.Restriction, parent);
                                }
                                else
                                {
                                    Session["ControlList_" + hidPageKeyForUniqueSession.Value] = new RestrictionIdName()
                                    {
                                        AbsoluteId = EachRestriction1.AbsoluteId,
                                        ParentId = "0",
                                        Name = "Main",
                                        Children = new List<RestrictionIdName>(),
                                        RelativeId = "1"
                                    };
                                }
                            }
                        }

                    }
                }
                else//else its activity or resource
                {
                    var restriction = helper.GetRestriction(
                        ActivityOrResource
                        , (byte)(((int)ActivityOrResourceType))
                        , ActivityOrResourceId);
                    if (restriction != null)
                    {
                        EachRestriction1.RestrictionId = restriction.Id;
                        EachRestriction1.SetConstraints(restriction.MatchMust, restriction.MatchAllAny);
                        // populate session..
                        var relativeId = EachRestriction1.RelativeId;
                        var rSession = Session["ControlList_" + hidPageKeyForUniqueSession.Value] as RestrictionIdName;
                        var user = Page.User as CustomPrincipal;

                        if (user != null)
                        {
                            if (rSession != null)
                            {
                                var parent = rSession;
                                SetRestriction(restriction, parent);
                            }
                            else
                            {
                                Session["ControlList_" + hidPageKeyForUniqueSession.Value] = new RestrictionIdName()
                                {
                                    AbsoluteId = EachRestriction1.AbsoluteId,
                                    ParentId = "0",
                                    Name = "Main",
                                    Children = new List<RestrictionIdName>(),
                                    RelativeId = "1"
                                };
                            }
                        }
                    }
                }
            }
        }

        void SetRestriction(Restriction res, RestrictionIdName parent)
        {
            var list = parent.Children;
            var i = parent.Children.Count + 1;
            parent.Constraints = new object[] { res.MatchMust, res.MatchAllAny };

            #region Date Restriction

            foreach (var dr in res.DateRestrictions)
            {
                var resClass = GetRestriction(parent.RelativeId, "date"
                    , i.ToString(), parent.RelativeId + "_" + i
                    , "", new List<RestrictionIdName>()
                     , res.Id, dr.Id, dr.Constraint, dr.Date, dr.Time);

                list.Add(resClass);
                i++;
            }



            #endregion

            #region Grade Restriction

            foreach (var gr in res.GradeRestrictions)
            {
                list.Add(GetRestriction(parent.RelativeId.ToString(), "grade"
                    , i.ToString(), parent.RelativeId + "_" + i
                    , "", new List<RestrictionIdName>()
                    , res.Id, gr.Id
                    , gr.ActivityResourceId, gr.MustBeGreaterThanOrEqualTo, gr.GreaterThanOrEqualToValue
                    , gr.MustBeLessThan, gr.LessThanValue
                    ));
                i++;
            }

            #endregion

            #region Group/Class Restriction

            foreach (var gpr in res.GroupRestrictions)
            {
                list.Add(GetRestriction(parent.RelativeId.ToString(), "class"
                    , i.ToString(), parent.RelativeId + "_" + i
                    , "", new List<RestrictionIdName>()
                     , res.Id, gpr.Id
                     , gpr.RestrictionId, gpr.Id, gpr.SubjectClassId, gpr.GroupId
                     ));
                i++;
            }

            #endregion

            #region User profile Restriction

            foreach (var gr in res.UserProfileRestrictions)
            {
                list.Add(GetRestriction(parent.RelativeId.ToString(), "userprofile"
                    , i.ToString(), parent.RelativeId + "_" + i
                    , "", new List<RestrictionIdName>()
                    , res.Id, gr.Id
                    , gr.FieldName, gr.Constraint, gr.Value
                    ));
                i++;
            }

            #endregion

            #region Child Restricions

            foreach (var r in res.Restrictions)
            {
                //                AbsoluteId = EachRestriction1.AbsoluteId,
                //                ParentId = "0",
                //                Name = "Main",
                //                Children = new List<RestrictionIdName>(),
                //                RelativeId = "1"

                var newParent = GetRestriction(parent.RelativeId.ToString(), "main"
                    , i.ToString(), parent.RelativeId + "_" + i.ToString()
                    , "", new List<RestrictionIdName>()
                    , res.Id, r.Id
                    );
                list.Add(newParent);
                i++;
                SetRestriction(r, newParent);
            }

            #endregion
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
        /// <param name="restrictionTypeParentId">id from db of parent restriction (actual restrciton).</param>
        /// <param name="restrictionTypeId">id from db of graderestriction, daterestriction, etc.</param>
        /// <param name="constraints"></param>
        /// <returns></returns>
        public RestrictionIdName GetRestriction(string parentId, string name
           , string absoluteId, string relativeId
           , string otherId, List<RestrictionIdName> children
            , int restrictionTypeParentId, int restrictionTypeId
            , params object[] constraints
            )
        {
            return new RestrictionIdName()
            {
                ParentId = parentId,
                Name = name,
                AbsoluteId = absoluteId,
                RelativeId = relativeId,
                OtherId = otherId,
                Children = children,
                RestrictionTypeParentId = restrictionTypeParentId,
                RestrictionTypeId = restrictionTypeId,
                Constraints = constraints,
            };
        }

        /// <summary>
        /// Must be assigned or called from every page where there are restrictions
        /// </summary>
        /// <param name="actOrRes">T:activity , F:resource</param>
        /// <param name="actOrResType">type of assignment or book etc.</param>
        /// <param name="actOrResId">id of assignment or book etc.</param>
        public void SetActivityResource(bool actOrRes, byte actOrResType, int actOrResId = 0)
        {
            ActivityOrResource = actOrRes;
            ActivityOrResourceType = actOrResType;
            ActivityOrResourceId = actOrResId;
        }

        //public void SetRestriction(Restriction res)
        //{
        //    EachRestriction1.RestrictionId = res.Id;

        //    //EachRestriction1.SetData(res);
        //    //Session["ControlList_" + hidPageKeyForUniqueSession.Value] as RestrictionIdName;

        //}



    }
}