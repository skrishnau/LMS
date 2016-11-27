using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbEntities.Grades;
using Academic.ViewModel;

namespace One.Views.Grade
{
    public partial class GradeTypeUc : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlValues.Visible = false;
                ViewState["values"] = new List<GradeViewModel>();
            }
            LoadValues();
        }

        #region Properties

        public float TotalMaxValue
        {
            get { return (float)Convert.ToDecimal(txtMaxValue.Text); }
        }

        public float TotalMinValue
        {
            get { return (float)Convert.ToDecimal(txtMinValue.Text); }
        }

        public float MinimumPassValue
        {
            get { return (float)Convert.ToDecimal(txtMinValueToPass.Text); }
        }

        public int SelectedType
        {
            get { return rdbtnlistType.SelectedIndex; }
        }

        public bool GradeValueIsInPercentOrPostition
        {
            get { return rdbtnlistEquivalentRepresentation.SelectedIndex == 0; }
        }
        public ControlCollection ListControls
        {
            get { return pnlGradeValues.Controls; }
        }
        public int GradeId
        {
            get { return Convert.ToInt32(hidId.Value); }
            set { hidId.Value = value.ToString(); }
        }

        #endregion


        #region Events Callback

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbtnlistType.SelectedIndex == 1)
            {
                pnlValues.Visible = true;
                pnlRange.Visible = false;
            }
            else
            {
                pnlRange.Visible = true;
                pnlValues.Visible = false;
            }
        }
        protected void rdbtnlistEquivalentRepresentation_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var cntrl in pnlGradeValues.Controls)
            {
                var valuesCntrl = cntrl as GradeValuesUC;
                if (valuesCntrl != null && valuesCntrl.Visible)
                {
                    valuesCntrl.TextMode = GetMode();
                }
            }
        }

        protected void btnAddValue_Click(object sender, EventArgs e)
        {
            //FROMM VIEWSTATE
            var list = ViewState["values"] as List<GradeViewModel>;
            if (list != null)
            {
                var id = 1;
                if (list.Any())
                    id = list.Max(x => x.Id) + 1;
                list.Add(new GradeViewModel()
                {
                    Id = id,
                    Void = false
                });

                var valuesUc = (GradeValuesUC)Page.LoadControl
                    ("~/Views/Grade/GradeValuesUC.ascx");
                valuesUc.ID = "value_" + id;
                valuesUc.LocalId = id;
                valuesUc.TextMode = GetMode();
                //valuesUc.GradeValueId = l.Id;
                valuesUc.RemoveClicked += valuesUc_RemoveClicked;
                pnlGradeValues.Controls.Add(valuesUc);
            }
        }
        void valuesUc_RemoveClicked(object sender, IdAndNameEventArgs e)
        {
            var cntrl = sender as GradeValuesUC;
            var list = ViewState["values"] as List<GradeViewModel>;
            if (cntrl != null && list != null)//
            {
                var val = list.FirstOrDefault(X => X.Id == e.Id);
                if (val != null)
                {
                    cntrl.Visible = false;
                    val.Void = true;
                }
            }
        }

        #endregion


        #region Functions

        void LoadValues()
        {
            var list = ViewState["values"] as List<GradeViewModel>;
            if (list != null)
            {
                foreach (var grd in list)
                {
                    var valuesUc = (GradeValuesUC)Page.LoadControl
                       ("~/Views/Grade/GradeValuesUC.ascx");
                    valuesUc.SetValues(grd.Id, grd.Value, grd.Equivalent, grd.Fail);
                    valuesUc.ID = "value_" + grd.Id;
                    valuesUc.Visible = !grd.Void;
                    valuesUc.TextMode = GetMode();
                    valuesUc.RemoveClicked += valuesUc_RemoveClicked;
                    pnlGradeValues.Controls.Add(valuesUc);
                }
            }
        }

        //public void AddControl(GradeValuesUC valuesUc)
        //{
        //    pnlGradeValues.Controls.Add(valuesUc);
        //}

        private TextBoxMode GetMode()
        {
            var mode = rdbtnlistEquivalentRepresentation.SelectedIndex == 1
               ? TextBoxMode.Number :
               TextBoxMode.SingleLine;
            return mode;
            //return TextBoxMode.Color;

        }

        public List<Academic.DbEntities.Grades.GradeValue> GetGradeValues()
        {
            var listOfValues = new List<Academic.DbEntities.Grades.GradeValue>();
            var nullFound = false;
            foreach (var cntrl in pnlGradeValues.Controls)
            {
                var valuesCntrl = cntrl as GradeValuesUC;
                if (valuesCntrl != null && valuesCntrl.Visible)
                {
                    var eqVal = valuesCntrl.EquivalentValue;
                    if (eqVal == null)
                        nullFound = true;
                    listOfValues.Add(new GradeValue()
                    {
                        Value = valuesCntrl.Value
                        ,
                        Id = valuesCntrl.GradeValueId
                        ,
                        EquivalentPercentOrPostition = eqVal
                        ,
                        IsFailGrade = valuesCntrl.Fail
                        ,
                        GradeId = GradeId
                        ,
                    });
                }
            }
            return (nullFound) ? null : listOfValues;
        }

        #endregion

    }

}