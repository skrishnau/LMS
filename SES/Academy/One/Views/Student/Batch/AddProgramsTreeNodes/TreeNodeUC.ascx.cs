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

namespace One.Views.Student.Batch.AddProgramsTreeNodes
{
    public partial class TreeNodeUC : System.Web.UI.UserControl
    {
        public event EventHandler<ProgramBatchEventArgs> StudentsButtonClick;
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

            //imgGroup.Attributes.Add("onclick", "GetCordinates(this)");

            if (!IsPostBack)
            {
                //imgGroup.Attributes["onmousemove"] = "getPanelMouseCoOrds(event)";
                //imgGroup.Attributes["onclick"] = "handlePanelClick()";
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
                    imgGroup_Click(this, new ImageClickEventArgs(0, 0));
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

        public TreeNodeUC ParentUC { get; set; }
        public List<TreeNodeUC> ChildNodes { get; set; }

        public bool CheckBoxVisibility
        {
            get { return chkBox.Visible; }
            set { chkBox.Visible = value; }
        }

        public int Level
        {
            get { return Convert.ToInt32(hidLevel.Value); }
            set
            {
                if (value >= 4)
                {
                    imgGroup.Visible = true;
                }
                hidLevel.Value = value.ToString();
            }
        }

        public bool StudentButtonVisibility
        {
            get { return imgGroup.Visible; }
            set { imgGroup.Visible = value; }
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

        //public int YearId { get; set; }

        //private bool _isLeafNode = true;
        public bool IsLeafNode
        {
            get
            {
                return imgGroup.Visible;
                //if (ChildNodes.Count > 0)
                //    return false;
                //return true;
            }
            set
            {
                if (Level >= 4)
                    imgGroup.Visible = value;
                else
                {
                    imgGroup.Visible = false;
                }
                //_isLeafNode = value;
            }
        }

        public FontInfo Font
        {
            set
            {
                cmbTitle.Font.Bold = value.Bold;
                cmbTitle.Font.Size = value.Size;
                cmbTitle.Font.Underline = value.Underline;
            }
        }

        public BorderStyle TextBorderStyle { set { cmbTitle.BorderStyle = value; } }

        //public Color BorderColor
        //{
        //    set
        //    {
        //        //pnlItem. = BorderStyle.Solid;
        //        this.chkBox.BorderColor = value;
        //    }

        //}

        public void ClearBorder()
        {
            pnlItem.Style.Clear();
        }

        public Color TextForeColor { set { cmbTitle.ForeColor = value; } }

        // private bool? _checked;
        public bool Checked
        {
            get { return chkBox.Checked; }
            set
            {
                chkBox.Checked = value;
                //_checked = value;
                //chkBox_CheckedChanged(new object(), new EventArgs());
            }
        }

        public int ProgramBatchId
        {
            get { return Convert.ToInt32(hidProgramBatchId.Value); }
            set { this.hidProgramBatchId.Value = value.ToString(); }
        }
        public int BatchId
        {
            get { return Convert.ToInt32(hidBatchId.Value); }
            set { this.hidBatchId.Value = value.ToString(); }
        }

        public int ProgramId { get; set; }
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

        public int NumberOfChildren
        {
            get { return Convert.ToInt32(hidNumberOfChildren.Value); }
            set { hidNumberOfChildren.Value = value.ToString(); }
        }

        public int StructureId
        {
            get { return Convert.ToInt32(hidStructureId.Value); }
            set { this.hidStructureId.Value = value.ToString(); }
        }

        public bool CheckBoxPostback
        {
            get { return chkBox.AutoPostBack; }
            set { chkBox.AutoPostBack = value; }
        }

        public bool IsMessage { get; set; }

        public List<string> StudentList
        {
            get
            {
                var s = hidStudentList.Value.Split(new char[] { ',' });
                return s.ToList();
            }
            set
            {
                string result = "";
                foreach (var s in value)
                {
                    result += s + ",";
                }
                result = result.TrimEnd(new char[] { ',' });
                hidStudentList.Value = result;
            }
        }

        public string ProgramBatchName { get; set; }

        #endregion

        #region Functions

        public void AddNode(TreeNodeUC uc)
        {
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
        public void SetParameters(string text, string value, int position, int totalSiblingsIncludingItself)
        {
            Text = text;
            Value = value;
            Position = position;
            TotalCountOfSiblingsIncludingItself = totalSiblingsIncludingItself;
        }


        #endregion

        protected void imgGroup_Click(object sender, ImageClickEventArgs e)
        {
            if (StudentsButtonClick != null)
            {
                var eventArgs = new ProgramBatchEventArgs()
                {
                    ProgramBatchId = ProgramBatchId
                  ,
                    StudentList = StudentList
                   ,
                    Type = Type
                   ,
                    ProgramBatchName = ProgramBatchName
                };
                StudentsButtonClick(this, eventArgs);
            }
        }

        protected void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            var chek = chkBox.Checked;
            CheckAllChildren(this);
            if (ParentUC != null)
                if (ParentUC.ChildNodes.Count(x => x.Checked) == 0)
                {
                    ParentUC.Checked = false;
                }

            //if (chek && IsLeafNode)
            //{

            //}

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

        public void ClearChildNodes()
        {
            ClearChildViewState();
            ClearChildState();
            ClearChildControlState();
            IsLeafNode = true;
            this.phChildNodes.Controls.Clear();
            if (ChildNodes == null)
                ChildNodes = new List<TreeNodeUC>();
            else ChildNodes.Clear();
        }


    }
}