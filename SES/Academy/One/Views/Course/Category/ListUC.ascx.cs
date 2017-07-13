using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
//using One.Values;
using Image = System.Web.UI.WebControls.Image;

namespace One.Views.Course.Category
{
    public partial class ListUC : System.Web.UI.UserControl
    {
        public event EventHandler<DataEventArgs> NameClicked;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int CategoryId
        {
            get { return Convert.ToInt32(this.hidCategoryId.Value); }
            set { this.hidCategoryId.Value = value.ToString(); }
        }

        public string CategoryName
        {
            get { return this.lblName.Text; }
            set { this.lblName.Text = value; }
        }

        public void Select()
        {

            //pnlName.BackColor = Color.LightBlue;
            pnlName.BackColor = Color.FromArgb(216,216,216);



            //lblName.BackColor = Color.DarkBlue;
            //lblName.ForeColor = Color.White;
            //.CssClass = "selected";
        }

        public void Deselect()
        {
            pnlName.BackColor = Color.White;
            
            //lblName.BackColor = Color.White;
            //lblName.ForeColor = Color.Black;
        }

        public void AddControl(UserControl conrol)
        {

        }

        public void SetNameAndIdOfCategory(int categoryId, string name, int paddingCount, bool edit)
        {
            CategoryId = categoryId;
            if (paddingCount % 2 == 0)
            {
                //this.lblName.Text = DbHelper.StaticValues.IndentationImageFull[1]+name;
                this.lblName.Text = name;
            }
            else
            {
                //this.lblName.Text = DbHelper.StaticValues.IndentationImageFull[2] + name;
                this.lblName.Text =  name;
            }
            this.pnlName.Style.Add("padding-left", (paddingCount * 15) + "px");

            if (!edit)
            {
                //lnkName.CssClass = "category-list-item";
                pnlName.CssClass = "category-list-editModeOff";
            }
            else
            {
                //lnkName.CssClass
                pnlName.CssClass = "category-list-editModeOn";
                lnkEdit.NavigateUrl = "~/Views/Course/CategoryCreate.aspx?catId="+categoryId;
                lnkDelete.NavigateUrl = "~/Views/All_Resusable_Codes/Delete/DeleteForm.aspx?task="+
                     DbHelper.StaticValues.Encode("courseCategory") +
                    "&catId="+categoryId;
            }
            lnkEdit.Visible = edit;
            lnkDelete.Visible = edit;
        }

        public void AddSubCategories(ListUC uc)
        {
            this.pnlSubCategories.Controls.Add(uc);
        }

        protected void lblName_Click(object sender, EventArgs e)
        {
            if (NameClicked != null)
            {
                NameClicked(this, new DataEventArgs()
                {
                    Id = Convert.ToInt32(hidCategoryId.Value)
                    ,
                    Name = lblName.Text.Replace("♦","").Replace("●","")
                });
                Select();
            }
        }


        #region Unused for now.. but some unused call to the below functiions.. check later Commented codes (view later)

        public void SetNameAndIdOfCategoryWithImage(int id, string name, bool edit, List<int> treeLinkImages = null)
        {
            this.hidCategoryId.Value = id.ToString();
            this.lblName.Text = name;
            if (treeLinkImages != null)
            {
                var pos = 0;
                foreach (var i in treeLinkImages)
                {
                    if (pos == 0)
                    {
                        if (i == 0)
                        {

                            PlaceHolder1.Controls.Add(new Label() { Width = 18 });
                        }
                        else
                        {
                            PlaceHolder1.Controls.Add(new Label() { Width = 4 });
                            PlaceHolder1.Controls.Add(new Image()
                            {
                                Width = 14,
                                ImageUrl = DbHelper.StaticValues.TreeLinkImageFull[i]
                            });
                        }
                        pos = 1;
                    }
                    else
                    {
                        if (i == 0)
                        {

                            PlaceHolder1.Controls.Add(new Label() { Width = 30 });
                        }
                        else
                        {
                            PlaceHolder1.Controls.Add(new Label() { Width = 14 });
                            PlaceHolder1.Controls.Add(new Image()
                            {
                                Width = 16,
                                ImageUrl = DbHelper.StaticValues.TreeLinkImageFull[i]
                            });
                        }
                    }

                    if (edit)
                    {
                        lnkName.CssClass = "list-item";
                        pnlName.CssClass = "";
                    }
                    //not used
                    //if (i == 0)
                    //{

                    //    PlaceHolder1.Controls.Add(new Label() { Width = 40 });
                    //}
                    //else
                    //{
                    //    PlaceHolder1.Controls.Add(new Label() { Width = 22 });
                    //    PlaceHolder1.Controls.Add(new Image()
                    //    {
                    //        Width = 18,
                    //        ImageUrl = Values.StaticValues.TreeLinkImage[i]
                    //    });
                    //}
                }
            }
        }

        /// <summary>
        /// when treelinkImages =null then structureType is not used, else 
        /// {    When structureType= True then tree form else indentation form    }
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="treeLinkImages"></param>
        /// <param name="structureType">False: indentation , True: Tree form</param>
        public void SetNameAndIdOfCategory(int id, string name, List<int> treeLinkImages = null, bool structureType = true)
        {
            this.hidCategoryId.Value = id.ToString();
            this.lblName.Text = name;


            if (treeLinkImages != null)
            {
                if (structureType)
                {
                    #region Tree structure

                    var pos = 0;
                    foreach (var i in treeLinkImages)
                    {
                        if (pos == 0)
                        {
                            if (i == 0)
                            {

                                PlaceHolder1.Controls.Add(new Label() { Width = 20 });
                            }
                            else
                            {
                                PlaceHolder1.Controls.Add(new Label() { Width = 4 });
                                PlaceHolder1.Controls.Add(new Image()
                                {
                                    Width = 16,
                                    ImageUrl = DbHelper.StaticValues.TreeLinkImageFull[i]
                                });
                            }
                            pos = 1;
                        }
                        else
                        {
                            if (i == 0)
                            {

                                PlaceHolder1.Controls.Add(new Label() { Width = 30 });
                            }
                            else
                            {
                                PlaceHolder1.Controls.Add(new Label() { Width = 14 });
                                PlaceHolder1.Controls.Add(new Image()
                                {
                                    Width = 16,
                                    ImageUrl = DbHelper.StaticValues.TreeLinkImageFull[i]
                                });
                            }
                        }
                    }

                    #endregion
                }
                else
                {
                    #region indentation structure

                    var pos = 0;
                    foreach (var i in treeLinkImages)
                    {
                        if (pos == 0)
                        {
                            if (i == 0)
                            {

                                PlaceHolder1.Controls.Add(new Label() { Width = 20 });
                            }
                            else
                            {
                                PlaceHolder1.Controls.Add(new Label() { Width = 4 });
                                PlaceHolder1.Controls.Add(new Label()
                                {
                                    Width = 16,
                                    Text = DbHelper.StaticValues.IndentationImageFull[i]
                                });
                            }
                            pos = 1;
                        }
                        else
                        {
                            if (i == 0)
                            {

                                PlaceHolder1.Controls.Add(new Label() { Width = 30 });
                            }
                            else
                            {
                                PlaceHolder1.Controls.Add(new Label() { Width = 14 });
                                PlaceHolder1.Controls.Add(new Label()
                                {
                                    Width = 16,
                                    Text = DbHelper.StaticValues.IndentationImageFull[i]
                                    //ImageUrl = DbHelper.StaticValues.TreeLinkImageFull[i]
                                });
                            }
                        }
                    }

                    #endregion
                }

            }
        }


        #endregion

    }
}