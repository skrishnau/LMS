using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values;
using One.Views.AcademicPlacement.StudentClass;

namespace One.Views.Exam.Exam.Create.EachNodeOfAssign
{
    public partial class TreeNodeUC : System.Web.UI.UserControl
    {
        public event EventHandler<RunningClassEventArgs> StudentsButtonClick;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ChildNodes != null)
            {
                if (ChildNodes.Count == 0)
                {

                }
            }
            else
            {
                ChildNodes = new List<TreeNodeUC>();
            }
            imgStudent.Attributes.Add("onclick", "GetCordinates(this)");

            if (!IsPostBack)
            {
                //imgStudent.Attributes["onmousemove"] = "getPanelMouseCoOrds(event)";
                //imgStudent.Attributes["onclick"] = "handlePanelClick()";
            }
            else
            {

                /*  string passedArgument = Request.Params.Get("__EVENTARGUMENT");
                  string controlName = Request.Params.Get("__EVENTTARGET");
                  string[] values = passedArgument.Split(new char[] {','});
                  if (values.Length == 2 && controlName=="imgStdGrp")
                  {
                      //hidX.Value = values[0];
                      //hidY.Value = values[1];
                      lnlbtn123_Click(this,new EventArgs());
                  }*/
                /*
                if (Request.Form["__EVENTTARGET"] == "imgStdGrp")
                {
                    // Fire event
                    imgStudent_Click(this, new ImageClickEventArgs(0, 0));
                }


                if (StudentsButtonClick != null)
                {
                    int x, y;
                    bool isx = false, isy = false;
                    if (hidX.Value != "0")
                    {
                        isx = Int32.TryParse(hidX.Value, out x);
                    }
                    if (hidY.Value != "0")
                    {
                        isy = Int32.TryParse(hidY.Value, out y);
                    }
                    if (isx && isy)
                    {
                        //StudentsButtonClick(this,)
                        var eventArgs = new ClassStudentsEventArgs()
                        {
                            RunningClassId = RunningClassId
                        };
                        if (Type == "subyear")
                        {
                            eventArgs.YearId = YearId;
                            eventArgs.SubYearId = Convert.ToInt32(Value);
                            eventArgs.Type = Type;

                            //if (StudentsButtonClick != null)
                            StudentsButtonClick(this, eventArgs);
                        }
                        else if (Type == "year")
                        {
                            eventArgs.YearId = Convert.ToInt32(Value);
                            eventArgs.Type = Type;

                            //if (StudentsButtonClick != null)
                            StudentsButtonClick(this, eventArgs);
                        }
                    }

                }*/
                //int panelX = Int32.Parse(Request.Form["hidX"]);
                //int panelY = Int32.Parse(Request.Form["hidY"]);
                //int panY = Int32.Parse(sd.Value);
                //Label1.Text = "You clicked @ " + panelX + ", " + panelY;
            }
        }

        #region Properties

        public string XValue { get; set; }
        public string YValue { get; set; }

        public string unqId()
        {
            return YearId + "_" + Value;
        }

        public TreeNodeUC ParentUC { get; set; }
        public List<TreeNodeUC> ChildNodes { get; set; }

        public int NumberOfChildren
        {
            get { return Convert.ToInt32(hidNumberOfChildren.Value); }
            set { hidNumberOfChildren.Value = value.ToString(); }
        }

        public int Position
        {
            get { return Convert.ToInt32(hidPosition.Value); }
            set { hidPosition.Value = value.ToString(); }
        }

        /// <summary>
        /// It is the Count of adding entity. i.e. if you are adding a program to a faculty,
        ///  then its the toal count of programs in that faculty.
        /// </summary>
        public int TotalCountOfSiblingsIncludingItself { get; set; }

        //public TYPE C { get; set; }


        public int Level
        {
            get { return Convert.ToInt32(hidLevel.Value); }
            set
            {
                if (value >= 4)
                {
                    imgStudent.Visible = true;
                }
                hidLevel.Value = value.ToString();
            }
        }

        public bool StudentButtonVisibility
        {
            get { return imgStudent.Visible; }
            set { imgStudent.Visible = value; }
        }

        /// <summary>
        /// string with 1 or 0 separated with commas
        /// 1=display bar 0 = don't display bar
        /// </summary>
        public string NoOfVertBars
        {
            get { return hidVertBars.Value; }
            set { hidVertBars.Value = value; }
        }

        public string Text
        {
            get { return cmbTitle.Text; }
            set { this.cmbTitle.Text = value; }
        }

        public List<Academic.DbEntities.AcacemicPlacements.StudentClass> StudentClasses { get; set; }

        public string Value { get; set; }

        public string Type { get; set; }

        public int YearId { get; set; }

        //private bool _isLeafNode = true;
        public bool IsLeafNode
        {
            get
            {
                return imgStudent.Visible;
                //if (ChildNodes.Count > 0)
                //    return false;
                //return true;
            }
            set
            {
                if (Level >= 4)
                    imgStudent.Visible = value;
                else
                {
                    imgStudent.Visible = false;
                }
                //_isLeafNode = value;
            }
        }

        private bool? _checked;
        public bool Checked
        {
            get { return chkBox.Checked; }
            set
            {
                chkBox.Checked = value;
                _checked = value;
                //chkBox_CheckedChanged(new object(), new EventArgs());
            }
        }

        public int RunningClassId
        {
            get { return Convert.ToInt32(hidRunningClassId.Value); }
            set { this.hidRunningClassId.Value = value.ToString(); }
        }

        public bool CheckBoxPostback { get { return chkBox.AutoPostBack; } set { chkBox.AutoPostBack = value; } }

        public Color BorderColor
        {
            set
            {
                if (value == Color.LimeGreen)
                {
                    _checked = true;
                   // chkBox.Checked = true;
                }
                this.chkBox.BorderStyle = BorderStyle.Solid;
                this.chkBox.BorderColor = value;
            }
        }

        private bool _forceCheck = false;
        public bool ForceCheck { get; set; }

        #endregion

        /// <summary>
        /// Must be called before AddNode()
        /// </summary>
        /// <param name="text">Text to be displayed for this node... Its Name Propgerty of respective table</param>
        /// <param name="value">Value to be stored of this node.. its Id property of respective table.</param>
        /// <param name="uc">ChildNode to be Added</param>
        /// <param name="position">
        /// position among its siblings in the order of add().
        /// if this is faculty then its position among the faculties of the respective level.
        /// </param>
        /// <param name="totalSiblingsIncludingItself">
        /// total siblings count. i.e. if this is faculty then its the
        /// total count of faculties in the level. i.e. faculties.Count()
        /// </param>
        public void SetParameters(string text, string value,int position, int totalSiblingsIncludingItself)
        {
            Text = text;
            Value = value;
            Position = position;
            TotalCountOfSiblingsIncludingItself = totalSiblingsIncludingItself;
        }


        /// <summary>
        /// Call SetParameters() before this call
        /// </summary>
        /// <param name="uc"></param>
        public void AddNode(TreeNodeUC uc)
        {
            //NodeUC innerUc =
            //        (NodeUC)Page.LoadControl("~/Views/Academy/CurrentAcademicYear/NodeUC.ascx");
            //innerUc.Text.Text =  text;
            var s = NoOfVertBars;
            if (Position < TotalCountOfSiblingsIncludingItself - 1)
                s += "1,";
            else s += "0,";
            uc.NoOfVertBars = s;

            uc.ParentUC = this;
            uc.Level = this.Level + 1;
            NumberOfChildren = NumberOfChildren + 1;
            IsLeafNode = false;
            this.phChildNodes.Controls.Add(uc);
            if (ChildNodes == null)
                ChildNodes = new List<TreeNodeUC>();
            this.ChildNodes.Add(uc);
        }

        //public void AddEntryForm(StudentEntry entry)
        //{
        //    pnlStudentEntry.Controls.Add(entry);
        //}

        public void ClearEntryForm()
        {
            pnlStudentEntry.Controls.Clear();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            var label = new Label();
            label.Text = "Hello";
            label.BorderStyle = BorderStyle.Double;
            //label.Style= ;
            Page.Controls.Add(label);
        }

        public void SetXY(string s)
        {
            //string passedArgument = Request.Params.Get("__EVENTARGUMENT");
            //string controlName = Request.Params.Get("__EVENTTARGET");
            string[] values = s.Split(new char[] { ',' });
            if (values.Length == 2)//&& controlName == "imgStdGrp")
            {
                //hidX.Value = values[0];
                //hidY.Value = values[1];
                lnlbtn123_Click(this, new EventArgs());
            }
        }

        protected void imgStudent_Click(object sender, ImageClickEventArgs e)
        {
            if (StudentsButtonClick != null)
            {
                var eventArgs = new RunningClassEventArgs()
                {
                    RunningClassId = RunningClassId
                        //,X = Convert.ToInt32(hidX.Value)
                        //,Y=Convert.ToInt32(hidY.Value)
                    ,
                    //OtherValues = txt.Text
                };
                if (Type == "subyear")
                {
                    eventArgs.YearId = YearId;
                    eventArgs.SubYearId = Convert.ToInt32(Value);
                    eventArgs.Type = Type;

                    if (StudentsButtonClick != null)
                        StudentsButtonClick(this, eventArgs);
                }
                else if (Type == "year")
                {
                    eventArgs.YearId = Convert.ToInt32(Value);
                    eventArgs.Type = Type;

                    if (StudentsButtonClick != null)
                        StudentsButtonClick(this, eventArgs);
                }
            }
        }

        protected void lnlbtn123_Click(object sender, EventArgs e)
        {
            var send = sender.ToString();
            var eArg = e.ToString();
            imgStudent_Click(sender, new ImageClickEventArgs(0, 0));
        }

        protected void chkBox_CheckedChanged(object sender, EventArgs e)
        {

            if (_checked != null && ForceCheck)
                chkBox.Checked = _checked ?? false;
            var chek = chkBox.Checked;
            CheckAllChildren(this);
            if (ParentUC != null)
                if (ParentUC.ChildNodes.Count(x => x.Checked) == 0)
                {
                    ParentUC.Checked = false;
                }
            //else
            //{
            //    ParentUC.Checked = true;                
            //}
            if (chek && IsLeafNode)
            {
                //need to work out on this 
                //StudentEntry entry =
                //    (StudentEntry)Page
                //        .LoadControl(
                //            "~/Views/AcademicPlacement/StudentClass/StudentEntry.ascx");

                //AddEntryForm(entry);
            }
            else
            {
                ClearEntryForm();
            }
        }

        TreeNodeUC IsAnyChildrenChecked(TreeNodeUC node)
        {
            var c = node.Checked;

            foreach (TreeNodeUC child in node.ChildNodes)
            {
                if (child.Checked)
                {
                    return child;
                }

            }
            return node;
        }

        void CheckAllChildren(TreeNodeUC node)
        {
            if (node.ChildNodes != null)
                foreach (TreeNodeUC child in node.ChildNodes)
                {
                    child.Checked = node.Checked;
                    CheckAllChildren(child);
                }
        }
    }
}