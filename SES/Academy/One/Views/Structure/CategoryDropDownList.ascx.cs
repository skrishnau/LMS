using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values.MemberShip;

namespace One.Views.Structure
{
    public partial class CategoryDropDownList : System.Web.UI.UserControl
    {
        public event EventHandler<IdAndNameEventArgs> CategorySelected;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = Page.User as CustomPrincipal;
                if (user != null)
                {
                    SchoolId = user.SchoolId;
                }
            }
            LoadCategories(SchoolId);
        }

        public int SchoolId
        {
            get { return Convert.ToInt32(hidSchoolId.Value); }
            set { hidSchoolId.Value = value.ToString(); }
        }

        private void LoadCategories(int schoolId)
        {


            using (var helper = new DbHelper.Subject())
            {
                var categories = helper.ListAllCategories(schoolId);
                var i = 0;

                var list = new List<int>();
                foreach (var cat in categories)
                {
                    list.Add(1);
                    var catLink = new LinkButton()
                    {
                        Text = cat.Name
                        ,
                        ID = "category_" + cat.Id
                    };
                    catLink.Click += catLink_Click;
                    //catUc.ID = "category" + cat.Id.ToString() + cat.Name;
                    //catUc.Deselect();
                    //catUc.SetNameAndIdOfCategory(cat.Id, cat.Name, list, false);

                    if (i == 0)
                    {
                        if (hidSelectedCategoryId.Value == "0")
                        {
                            //catUc.Select();
                            hidSelectedCategoryId.Value = cat.Id.ToString();
                            lblSelectedCategoryName.Text = cat.Name;
                            if (CategorySelected != null)
                            {
                                CategorySelected(catLink, new IdAndNameEventArgs() { Id = cat.Id });
                            }
                        }
                        //else if (hidSelectedCategoryId.Value == cat.Id.ToString())
                        //{
                        //    //InitialUpdateOfCourses(cat.Id, cat.Name);
                        //    //selectedAlready = true;
                        //}
                    }
                    //else if (!selectedAlready)
                    //{
                    //    if (hidSelectedCategory.Value == cat.Id.ToString())
                    //    {

                    //        InitialUpdateOfCourses(cat.Id, cat.Name);
                    //        selectedAlready = true;
                    //    }
                    //}
                    //catUc.NameClicked += catUc_NameClicked;
                    //pnlCategories.Controls.Add(catUc);
                    pnlCategories.Controls.Add(catLink);
                    GetSubCategory(helper, schoolId, cat.Id, 1);
                    list.RemoveAt(list.Count - 1);

                    //var spaces = "";
                    //for (int j = 0; j < list.Count * 4; j++)
                    //{
                    //    spaces += " ";
                    //}
                    //var litem = new ListItem() { Text = cat.Name };
                    //litem.Attributes.Add("style", "background-color:#41f111");//"padding-left:"+(list.Count*4)+"px");
                    //ddlCategories.Items.Add(litem);

                    i++;
                }
            }
        }



        void GetSubCategory(DbHelper.Subject helper, int schoolId, int categoryId
          , int paddingPosition)
        {
            paddingPosition++;
            var subCategories = helper.ListSubCategories(schoolId, categoryId);
            foreach (var cat in subCategories)
            {
                var spaces = " ";
                for (int j = 0; j < paddingPosition * 4; j++)
                {
                    spaces += " ";
                }
                var litem = new ListItem() { Text = spaces + cat.Name };
                litem.Attributes.Add("style", "padding-left:" + (paddingPosition * 4) + "px");

                var catLink = new LinkButton()
                {
                    Text = cat.Name
                    ,
                    ID = "category_" + cat.Id
                };
                catLink.Click += catLink_Click;
                catLink.Style.Add("padding-left", ((paddingPosition) * 16) + "px");
                pnlCategories.Controls.Add(catLink);
                GetSubCategory(helper, schoolId, cat.Id, paddingPosition);
            }
        }

        void catLink_Click(object sender, EventArgs e)
        {
            var sent = sender as LinkButton;
            if (sent != null)
            {
                lblSelectedCategoryName.Text = sent.Text;

                if (CategorySelected != null)
                {
                    var id = sent.ID.Split(new char[] { '_' });
                    if (id.Length == 2)
                    {
                        var idInInt = Convert.ToInt32(id[1]);
                        CategorySelected(sender, new IdAndNameEventArgs() { Id = idInInt });
                    }
                }
            }
        }


    }
}