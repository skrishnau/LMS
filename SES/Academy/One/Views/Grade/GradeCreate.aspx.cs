using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Grades;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Grade
{
    public partial class GradeCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divValues.Visible = false;
                var key = Guid.NewGuid().ToString();
                hidPageKey.Value = key;
                // Session["cntrl" + key] = new List<GradeValuesDataType>();
                ViewState["values"] = new List<int>();
            }
            //else
            //{
            //   // var list = Session["cntrl" + hidPageKey.Value] as List<GradeValuesDataType>;

            //}
            LoadValues();
            //var eqRepList = new List<ListItem>();
            //var per = new ListItem("Percentage", "0", true);
            //per.Attributes.Add("title", "In Percentage: Values are between 0 and 100");
            //eqRepList.Add(per);
            //var pos = new ListItem("Position", "1", false);
            //pos.Attributes.Add("title", "In Position: '1' is highest ranked, '2' is ranked lower than '1', and so on.");
            //eqRepList.Add(pos);

            //rdbtnlistEquivalentRepresentation.DataSource = eqRepList;
            //rdbtnlistEquivalentRepresentation.DataBind();

        }

        void LoadValues()
        {
            //FROM VIEWSTATE
            var list = ViewState["values"] as List<int>;
            if (list != null)
            {
                foreach (var i in list)
                {
                    var valuesUc = (GradeValuesUC)Page.LoadControl
                       ("~/Views/Grade/GradeValuesUC.ascx");
                    valuesUc.LocalId = i;
                    valuesUc.TextMode = GetMode();
                    //        //valuesUc.GradeValueId = l.Id;
                    valuesUc.RemoveClicked += valuesUc_RemoveClicked;
                    pnlGradeValues.Controls.Add(valuesUc);
                }
            }
            //FROM SESSION
            //var list = Session["cntrl" + hidPageKey.Value] as List<GradeValuesDataType>;
            //if (list != null)
            //{
            //    foreach (var l in list)
            //    {
            //        var valuesUc = (GradeValuesUC)Page.LoadControl
            //            ("~/Views/Grade/GradeValuesUC.ascx");

            //        //valuesUc.Fail = l.Fail;
            //        valuesUc.TextMode = GetMode();
            //        //valuesUc.GradeValueId = l.Id;

            //        valuesUc.RemoveClicked += valuesUc_RemoveClicked;
            //        //valuesUc.EquivalentValue = l.Equivalent;
            //        //valuesUc.Value = l.Value;

            //        pnlGradeValues.Controls.Add(valuesUc);
            //    }
            //}
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbtnlistType.SelectedIndex == 1)
            {
                divValues.Visible = true;
                divRange.Visible = false;
            }
            else
            {
                divRange.Visible = true;
                divValues.Visible = false;
            }
        }

        public void btnSave_OnClick(object sender, EventArgs args)
        {
            try
            {
                var user = Page.User as CustomPrincipal;
                var selectedType = rdbtnlistType.SelectedIndex;
                var grade = new Academic.DbEntities.Grades.GradeType()
                {
                    Description = txtDescription.Text
                    ,
                    Name = txtName.Text
                    ,
                    Type = (selectedType == 0) ? "Range" : "Values"
                    ,
                    SchoolId = user.SchoolId
                };
                if (selectedType == 0)
                {
                    grade.TotalMaxValue = (float)Convert.ToDecimal(txtMaxValue.Text);
                    grade.TotalMinValue = (float)Convert.ToDecimal(txtMinValue.Text);
                    grade.MinimumPassValue = (float)Convert.ToDecimal(txtMinValueToPass.Text);
                }
                else
                {
                    grade.GradeValueIsInPercentOrPostition = rdbtnlistEquivalentRepresentation.SelectedIndex == 0;

                }
                var listOfValues = new List<Academic.DbEntities.Grades.GradeValues>();
                foreach (var cntrl in pnlGradeValues.Controls)
                {
                    var valuesCntrl = cntrl as GradeValuesUC;
                    if (valuesCntrl != null)
                    {
                        listOfValues.Add(new GradeValues()
                        {
                            Value = valuesCntrl.Value
                            ,
                            Id = valuesCntrl.GradeValueId
                            ,
                            EquivalentPercentOrPostition = valuesCntrl.EquivalentValue
                            ,
                            IsFailGrade = valuesCntrl.Fail
                            ,
                            GradeTypeId = GradeId
                            ,
                        });
                    }

                }
                using (var helper = new DbHelper.Grade())
                {

                    var saved = helper.AddOrUpdateGrade(grade, listOfValues);
                    if (saved != null)
                    {
                        Response.Redirect("~/Views/Grade/GradeListing.aspx");
                    }
                }
            }
            catch {  }
        }
        public int GradeId
        {
            get { return Convert.ToInt32(hidId.Value); }
            set { hidId.Value = value.ToString(); }
        }
        protected void btnAddValue_Click(object sender, EventArgs e)
        {
            //FROMM VIEWSTATE
            var list = ViewState["values"] as List<int>;
            if (list != null)
            {
                var id = 1;
                if (list.Any())
                    id = list.Max() + 1;
                list.Add(id);

                var valuesUc = (GradeValuesUC)Page.LoadControl
                   ("~/Views/Grade/GradeValuesUC.ascx");
                valuesUc.LocalId = id;
                valuesUc.TextMode = GetMode();
                //        //valuesUc.GradeValueId = l.Id;
                valuesUc.RemoveClicked += valuesUc_RemoveClicked;
                pnlGradeValues.Controls.Add(valuesUc);
            }


            //var list = Session["cntrl" + hidPageKey.Value] as List<GradeValuesDataType>;


            //if (list != null)
            //{
            //    var id = 0;
            //    if (list.Any())
            //        id = list.Max(x => x.Id);


            //    var valuesUc = (GradeValuesUC)Page.LoadControl(
            //        "~/Views/Grade/GradeValuesUC.ascx");

            //    valuesUc.TextMode = GetMode();
            //    valuesUc.RemoveClicked += valuesUc_RemoveClicked;

            //    valuesUc.LocalId = id + 1;

            //    var newval = new GradeValuesDataType() { Id = id + 1 };
            //    //if (rdbtnlistEquivalentRepresentation.SelectedIndex == 1)
            //    //{
            //    //    //valuesUc.EquivalentValue = minVal;
            //    //    newval.Equivalent = minVal;
            //    //}
            //    list.Add(newval);
            //    pnlGradeValues.Controls.Add(valuesUc);
            //}

        }

        //void GetValues(List<GradeValuesDataType> list, out int id, out int minVal)
        //{
        //    id = 0;
        //    if (list.Any())
        //        id = list.Max(x => x.Id);
        //    minVal = 0;

        //    //var sorted = list.Select(x => (int)x.Equivalent).Distinct().ToList();
        //    var inList = new List<int>();
        //    foreach (var cntrl in pnlGradeValues.Controls)
        //    {
        //        var valuesCntrl = cntrl as GradeValuesUC;
        //        if (valuesCntrl != null)
        //        {
        //            inList.Add((int)valuesCntrl.EquivalentValue);
        //        }
        //    }
        //    inList = inList.Distinct().ToList();
        //    inList.Sort();

        //    inList.Sort();
        //    if (inList.Any())
        //        minVal = inList[0];
        //    for (int i = 1; i < inList.Count; i++)
        //    {
        //        if (inList[i] > minVal && inList[i] != minVal + 1)
        //        {
        //            //minVal++;
        //            break;
        //        }
        //        minVal = inList[i];
        //    }
        //    minVal++;
        //}

        void valuesUc_RemoveClicked(object sender, IdAndNameEventArgs e)
        {

            //FROM VIEWSTATE
            var cntrl = sender as GradeValuesUC;
            var list = ViewState["values"] as List<int>;
            if (cntrl != null && list != null)//
            {
                var val = list.Find(X => X == e.Id);
                pnlGradeValues.Controls.Remove(cntrl);
                list.Remove(val);
            }



            //FROM SESSION
            //var cntrl = sender as GradeValuesUC;
            ////var list = Session["cntrl" + hidPageKey.Value] as List<GradeValuesDataType>;
            //if (cntrl != null)//&& list != null
            //{
            //    // var val = list.Find(x => x.Id == e.Id);
            //    // if (val != null)
            //    {
            //        pnlGradeValues.Controls.Remove(cntrl);
            //        // list.Remove(val);
            //    }
            //}

        }

        private TextBoxMode GetMode()
        {
            var mode = rdbtnlistEquivalentRepresentation.SelectedIndex == 1
               ? TextBoxMode.Number :
               TextBoxMode.SingleLine;
            return mode;
        }

        protected void rdbtnlistEquivalentRepresentation_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var cntrl in pnlGradeValues.Controls)
            {
                var valuesCntrl = cntrl as GradeValuesUC;
                if (valuesCntrl != null)
                {
                    valuesCntrl.TextMode = GetMode();
                }
            }
        }
    }
}