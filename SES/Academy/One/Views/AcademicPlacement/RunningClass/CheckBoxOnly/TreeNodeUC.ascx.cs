using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using One.Values;

namespace One.Views.AcademicPlacement.RunningClass.CheckBoxOnly
{
    public partial class TreeNodeUC : System.Web.UI.UserControl
    {
        public event EventHandler<RunningClassEventArgs> StudentsButtonClick;


        //--------------------------------------------//
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

        public int ProgramId
        {
            get { return Convert.ToInt32(hidProgramId.Value); }
            set { this.hidProgramId.Value = value.ToString(); }
        }

        public int ProgramBatchId
        {
            get { return Convert.ToInt32(hidProgramBatchId.Value); }
            set { this.hidProgramBatchId.Value = value.ToString(); }
        }

        public string ProgramBatchName
        {
            get { return lblProgramBatch.Text; }
            set { this.lblProgramBatch.Text = value; }
        }

        public int YearId { get; set; }

        public int RunningClassId
        {
            get { return Convert.ToInt32(hidRunningClassId.Value); }
            set { this.hidRunningClassId.Value = value.ToString(); }
        }

        public List<Academic.DbEntities.AcacemicPlacements.StudentClass> StudentClasses { get; set; }

        public string Value { get; set; }
        public string Type { get; set; }

        public bool IsMessage { get; set; }

        #endregion


        //=============start of nodetree properties, functions and events================//

        #region Properties

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

        public TreeNodeUC ParentUC { get; set; }
        public List<TreeNodeUC> ChildNodes { get; set; }

        public bool CheckBoxVisibility
        {
            get { return chkBox.Visible; }
            set { chkBox.Visible = value; }
        }

        public bool CheckBoxPostback
        {
            get { return chkBox.AutoPostBack; }
            set { chkBox.AutoPostBack = value; }
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

        public BorderStyle TextBorderStyle
        {
            set { cmbTitle.BorderStyle = value; }
        }

        public Color TextForeColor
        {
            set { cmbTitle.ForeColor = value; }
        }

        private bool _forceCheck = false;
        public bool ForceCheck { get; set; }

        public void ClearBorder()
        {
            pnlItem.Style.Clear();
        }

        public bool StudentButtonVisibility
        {
            get { return imgGroup.Visible; }
            set { imgGroup.Visible = value; }
        }


        #endregion

        //Functions

        #region Functions

        public void AddNode(TreeNodeUC uc)
        {
            //NodeUC innerUc =
            //        (NodeUC)Page.LoadControl("~/Views/Academy/CurrentAcademicYear/NodeUC.ascx");
            //innerUc.Text.Text =  text;
            uc.ParentUC = this;
            IsLeafNode = false;
            this.phChildNodes.Controls.Add(uc);
            if (ChildNodes == null)
                ChildNodes = new List<TreeNodeUC>();
            this.ChildNodes.Add(uc);
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

        #endregion

        //events

        #region Events

        protected void imgGroup_Click(object sender, ImageClickEventArgs e)
        {
            if (StudentsButtonClick != null)
            {
                var eventArgs = new RunningClassEventArgs()
                {
                    RunningClassId = RunningClassId
                    ,
                    ProgramId = ProgramId
                    ,
                    ProgramBatchId = ProgramBatchId
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
            if (chek && IsLeafNode)
            {
                //StudentEntry entry =
                //    (StudentEntry)Page
                //        .LoadControl(
                //            "~/Views/AcademicPlacement/StudentClass/StudentEntry.ascx");

                //AddEntryForm(entry);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            var label = new Label();
            label.Text = "Hello";
            label.BorderStyle = BorderStyle.Double;
            //label.Style= ;
            Page.Controls.Add(label);
        }

        #endregion

        //=================end of node tree properties, functions and events===========//

        //private TreeNodeUC foundNode = null;
        private int _programBatchId = 0;
        private string _programBatchName = "";
        private TreeNodeUC searchNode;

        /// <summary>
        /// Set programbatch. it first searched for the required node and then populates data to it..
        /// </summary>
        /// <param name="root">the node to start search from</param>
        /// <param name="node"> the node to search</param>
        /// <param name="programBatchId">programbatch id to put in the searched node</param>
        /// <param name="programBatchName"> name to put in the searched node</param>
        public void SetProgramBatchIdInNode(TreeNodeUC root, TreeNodeUC node, string programBatchId,string programBatchName)
        {
            _programBatchId = Convert.ToInt32(String.IsNullOrEmpty(programBatchId)?"0":programBatchId);
            _programBatchName = programBatchName;
            searchNode = node;
            FindChildControl(root, node.ClientID);
        }

        public void FindChildControl(TreeNodeUC node, string id)
        {
            if (node.ChildNodes != null)
                foreach (TreeNodeUC child in node.ChildNodes)
                {
                    //child.Checked = node.Checked;
                    //CheckAllChildren(child);
                    if (child.ClientID == searchNode.ClientID)
                    {
                        child.ProgramBatchId = _programBatchId;
                        child.ProgramBatchName = _programBatchName;
                        return;
                    }
                    //foundNode = child;
                    FindChildControl(child, id);
                }
        }


    }
}