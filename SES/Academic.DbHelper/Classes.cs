using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Academic.DbHelper
{
    public class Classes
    {

    }

    public class TextAndLink
    {
        public string Text { get; set; }
        public string Link { get; set; }

    }

    public class DataEventArgs : EventArgs
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MessageEventArgs : EventArgs
    {
        public string Message { get; set; }
        public bool TrueFalse { get; set; }
        public string RaisedBy { get; set; }


        public bool SaveSuccess { get; set; }
        public bool CancelClicked { get; set; }

        public int SavedId { get; set; }
        public string SavedName { get; set; }

        public int RefId { get; set; }
    }

    public class SubjectEventArgs : EventArgs
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Checked { get; set; }
    }
    public class SubjectSectionEventArgs : EventArgs
    {
        public int SubjectId { get; set; }
        public int SectionId{ get; set; }

        public string SubjectName { get; set; }
        public string SectionName { get; set; }

        public bool Checked { get; set; }
    }


    /// <summary>
    /// Used for structure
    /// </summary>
    public class StructureEventArgs : EventArgs
    {
        public int ProgramId { get; set; }
        public int YearId { get; set; }
        public int SubYearId { get; set; }

        public int RefId { get; set; }
        //public string Type { get; set; }
    }

    public class RunningClassEventArgs : EventArgs
    {
        public int LevelId { get; set; }
        public int FacultyId { get; set; }

        public int ProgramId { get; set; }

        public int YearId { get; set; }
        public int SubYearId { get; set; }

        public int ProgramBatchId { get; set; }

        public int RunningClassId { get; set; }

        public string Type { get; set; }//year or subyear

        //public int X { get; set; }
        //public int Y { get; set; }
        //public string  OtherValues { get; set; }


        public string ProgramBatchName { get; set; }
        public string ProgrameName { get; set; }
        public string BatchName { get; set; }
        public string YearName { get; set; }
        public string SubYearName { get; set; }

        public int BatchId { get; set; }

    }


    public class BatchEventArgs : EventArgs
    {
        public int ProgramId { get; set; }
        public int ProgramBatchId { get; set; }
        public int BatchId { get; set; }

        public bool Checked { get; set; }
    }

    public class ProgramBatchEventArgs : EventArgs
    {
        public int ProgramBatchId { get; set; }
        public string ProgramBatchName { get; set; }

        //public int BatchId { get; set; }
        //public int ProgramId { get; set; }
        public List<string> StudentList { get; set; }

        public string Type { get; set; }//year or subyear

        //for passing the year/subyear Id which invoked the selection 
        //these will be used to backtrack the subcontrols (i.e. year and subyear controls)

    }
    //public class StudentEntryEventArgs : EventArgs
    //{
    //    public List<Academic.DbEntities.AcacemicPlacements.StudentClass> StudentClasses { get; set; }
    //}


    public class CustomTreeNode : TreeNode
    {
        public Label Text { get; set; }
        public ImageButton Add { get; set; }
        public ImageButton Edit { get; set; }
        public ImageButton Delete { get; set; }


    }
    public class DropDownTreeNode : TreeNode
    {
        // *snip* Constructors go here
        public DropDownTreeNode(string text)
            : base(text)
        {

        }

        private DropDownList m_ComboBox = new DropDownList();
        public DropDownList ComboBox
        {
            get
            {
                //this.m_ComboBox. = DropDownList.DropDownList;
                return this.m_ComboBox;
            }
            set
            {
                this.m_ComboBox = value;
                //this.m_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
    }

    public class DropDownTreeView : TreeView
    {
        public DropDownTreeView()
            : base()
        {
        }

        private DropDownTreeNode m_CurrentNode = null;
        protected override void OnTreeNodeExpanded(TreeNodeEventArgs e)
        {
            // Are we dealing with a dropdown node?
            if (e.Node is DropDownTreeNode)
            {
                this.m_CurrentNode = (DropDownTreeNode)e.Node;

                // Need to add the node's ComboBox to the
                // TreeView's list of controls for it to work
                this.Nodes.Add(this.m_CurrentNode);

                // Set the bounds of the ComboBox, with
                // a little adjustment to make it look right
                //this.m_CurrentNode.ComboBox.(
                //    this.m_CurrentNode.Bounds.X - 1,
                //    this.m_CurrentNode.Bounds.Y - 2,
                //    this.m_CurrentNode.Bounds.Width + 25,
                //    this.m_CurrentNode.Bounds.Height);

                // Listen to the SelectedValueChanged
                // event of the node's ComboBox
                this.m_CurrentNode.ComboBox.SelectedIndexChanged +=
                   new EventHandler(ComboBox_SelectedValueChanged);
                //this.m_CurrentNode.ComboBox.DropDownClosed +=
                //   new EventHandler(ComboBox_DropDownClosed);

                // Now show the ComboBox
                this.m_CurrentNode.ComboBox.Visible = true;
                //this.m_CurrentNode.ComboBox.DroppedDown = true;
            }
            base.OnTreeNodeExpanded(e);
        }

        //protected  void
        //          TreeNodeExpanded(TreeNodeEventArgs e)
        //{
        //    // Are we dealing with a dropdown node?
        //    if (e.Node is DropDownTreeNode)
        //    {
        //        this.m_CurrentNode = (DropDownTreeNode)e.Node;

        //        // Need to add the node's ComboBox to the
        //        // TreeView's list of controls for it to work
        //        this.Controls.Add(this.m_CurrentNode.ComboBox);

        //        // Set the bounds of the ComboBox, with
        //        // a little adjustment to make it look right
        //        this.m_CurrentNode.ComboBox.SetBounds(
        //            this.m_CurrentNode.Bounds.X - 1,
        //            this.m_CurrentNode.Bounds.Y - 2,
        //            this.m_CurrentNode.Bounds.Width + 25,
        //            this.m_CurrentNode.Bounds.Height);

        //        // Listen to the SelectedValueChanged
        //        // event of the node's ComboBox
        //        this.m_CurrentNode.ComboBox.SelectedValueChanged +=
        //           new EventHandler(ComboBox_SelectedValueChanged);
        //        this.m_CurrentNode.ComboBox.DropDownClosed +=
        //           new EventHandler(ComboBox_DropDownClosed);

        //        // Now show the ComboBox
        //        this.m_CurrentNode.ComboBox.Show();
        //        this.m_CurrentNode.ComboBox.DroppedDown = true;
        //    }
        //    base.OnNodeMouseClick(e);
        //}

        void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            HideComboBox();
        }

        void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            HideComboBox();
        }
        private void HideComboBox()
        {
            if (this.m_CurrentNode != null)
            {
                // Unregister the event listener
                this.m_CurrentNode.ComboBox.SelectedIndexChanged -=
                                     ComboBox_SelectedValueChanged;
                //this.m_CurrentNode.ComboBox.DropDownClosed -= 
                //                     ComboBox_DropDownClosed;

                // Copy the selected text from the ComboBox to the TreeNode
                this.m_CurrentNode.Text = this.m_CurrentNode.ComboBox.Text;

                // Hide the ComboBox
                this.m_CurrentNode.ComboBox.Visible = false;
                //this.m_CurrentNode.ComboBox.DroppedDown = false;

                // Remove the control from the TreeView's
                // list of currently-displayed controls
                this.Controls.Remove(this.m_CurrentNode.ComboBox);

                // And return to the default state (no ComboBox displayed)
                this.m_CurrentNode = null;
            }

        }

    }


    #region Activity and Resources

    public class ActivityClass
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImagePath { get; set; }
    }


    #endregion


}