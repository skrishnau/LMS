using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;

namespace One.Views.Structure.All.UserControls
{
    public partial class SubYearCreateUC : System.Web.UI.UserControl
    {
        public event EventHandler<MessageEventArgs> OnSaveClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            AllValidatorVisibility = false;
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set
            {
                hidSchoolId.Value = value.ToString();
                //DbHelper.ComboLoader.LoadLevel(ref cmbLevel, Convert.ToInt32(hidSchoolId.Value), true);
            }
        }
        //public int LevelId
        //{
        //    get { return Convert.ToInt32(hidLevelId.Value); }
        //    set
        //    {
        //        hidLevelId.Value = value.ToString();
        //        cmbLevel.ClearSelection();
        //        cmbLevel.SelectedValue = value.ToString();
        //        cmbLevel.Enabled = false;
        //        //DbHelper.ComboLoader.LoadFaculty(ref cmbFaculty, Convert.ToInt32(hidLevelId.Value), true);
        //    }
        //}

        //public int FacultyId
        //{
        //    get { return Convert.ToInt32(hidFacultyId); }
        //    set
        //    {
        //        hidFacultyId.Value = value.ToString();
        //        cmbFaculty.ClearSelection();
        //        cmbFaculty.SelectedValue = value.ToString();
        //        cmbFaculty.Enabled = false;
        //        DbHelper.ComboLoader.LoadProgram(ref cmbProgram, Convert.ToInt32(hidFacultyId.Value), true);

        //    }
        //}

        public int ProgramId
        {
            get { return Convert.ToInt32(hidProgram); }
            set
            {
                hidProgram.Value = value.ToString();
                cmbProgram.ClearSelection();
                cmbProgram.SelectedValue = value.ToString();
                cmbProgram.Enabled = false;
                DbHelper.ComboLoader.LoadYear(ref cmbYear, Convert.ToInt32(hidProgram.Value), true);

            }
        }
        
        public int YearId
        {
            get { return Convert.ToInt32(hidYear); }
            set
            {
                hidYear.Value = value.ToString();
                cmbYear.ClearSelection();

                //error: cmbYear does not exist
                cmbYear.SelectedValue = value.ToString();
                cmbYear.Enabled = false;

               // DbHelper.ComboLoader.LoadSubYear(ref cmbParent, Convert.ToInt32(hidYear.Value), false, true);
                Grouping(Convert.ToInt32(hidYear.Value));
            }
        }

        public void Grouping(int yearId)
        {
            //protected void Page_Load(object sender, EventArgs e) 
            //{
            cmbParent.Items.Clear();
            
            using (var helper = new DbHelper.Structure())
            {
                var yea = helper.ListSubYears(yearId,true,true);
                var s = yea.GroupBy(x => x.ParentId);
                
                foreach (var v in s)
                {
                    //var x=v.GetEnumerator();

                    //x.Current.Name

                    var y = yea.Where(x => x.ParentId == v.Key);
                    foreach (var i in y)
                    {
                        ListItem item = new ListItem(i.Name, i.Id.ToString());
                        var grp = yea.FirstOrDefault(x => x.Id == i.ParentId);
                        if (grp != null)
                            item.Attributes["OptionGroup"] = grp.Name;
                        cmbParent.Items.Add(item);
                    }

                }
            }

            //ListItem item1 = new ListItem("Camel", "1");
            //  item1.Attributes["OptionGroup"] = "Mammals";

            //  ListItem item2 = new ListItem("Lion", "2");
            //  item2.Attributes["OptionGroup"] = "Mammals";

            //  ListItem item3 = new ListItem("Whale", "3");
            //  item3.Attributes["OptionGroup"] = "Mammals";

            //  ListItem item4 = new ListItem("Walrus", "4");
            //  item4.Attributes["OptionGroup"] = "Mammals";

            //  ListItem item5 = new ListItem("Velociraptor", "5");
            //  item5.Attributes["OptionGroup"] = "Dinosaurs";

            //  ListItem item6 = new ListItem("Allosaurus", "6");
            //  item6.Attributes["OptionGroup"] = "Dinosaurs";

            //  ListItem item7 = new ListItem("Triceratops", "7");
            //  item7.Attributes["OptionGroup"] = "Dinosaurs";

            //  ListItem item8 = new ListItem("Stegosaurus", "8");
            //  item8.Attributes["OptionGroup"] = "Dinosaurs";

            //  ListItem item9 = new ListItem("Tyrannosaurus", "9");
            //  item9.Attributes["OptionGroup"] = "Dinosaurs";


            //  ddlItems.Items.Add(item1);
            //  ddlItems.Items.Add(item2);
            //  ddlItems.Items.Add(item3);
            //  ddlItems.Items.Add(item4);
            //  ddlItems.Items.Add(item5);
            //  ddlItems.Items.Add(item6);
            //  ddlItems.Items.Add(item7);
            //  ddlItems.Items.Add(item8);
            //  ddlItems.Items.Add(item9);

            //}
        }

        public bool AllValidatorVisibility
        {
            set
            {
                valiTxtName.Visible = value;
                valiCmbYear.Visible = value;
                valiPostion.Visible = value;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                isValid = false;
                valiTxtName.Visible = true;
            }
            if (string.IsNullOrEmpty(txtPosition.Text))
            {
                isValid = false;
                valiPostion.Visible = true;
            }
            if (cmbYear.SelectedValue == "" || cmbYear.SelectedValue == "0")
            {
                isValid = false;
                valiCmbYear.Visible = true;
            }

            if (isValid)
            {
                var subYear = new Academic.DbEntities.Structure.SubYear()
                {
                    Name = txtName.Text
                    ,
                    Description = txtDescription.Text
                    ,
                    Position = Convert.ToInt32(txtPosition.Text)
                    ,
                    YearId = Convert.ToInt32(cmbYear.SelectedValue)
                };
                if (cmbParent.SelectedValue != "" && cmbParent.SelectedValue != "0")
                    subYear.ParentId = Convert.ToInt32(cmbParent.SelectedValue);

                using (var helper = new DbHelper.Structure())
                {
                    var saved = helper.AddOrUpdateSubYear(subYear);
                    if (saved != null)
                    {
                        if (OnSaveClicked != null)
                        {
                            OnSaveClicked(this, DbHelper.StaticValues.SuccessSaveMessageEventArgs);
                        }
                        ClearCreateTextBoxes();
                    }
                    else
                    {
                        if (OnSaveClicked != null)
                        {
                            OnSaveClicked(this, DbHelper.StaticValues.ErrorSaveMessageEventArgs);
                        }
                    }
                }
            }
        }
        void ClearCreateTextBoxes()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtPosition.Text = "";

        }
    }
}