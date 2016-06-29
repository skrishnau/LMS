using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Academic.ViewModel.AcademicPlacement
{

    public class MyTreeView : TreeView
    {
        protected override TreeNode CreateNode()
        {
            return new MyTreeNode();
        }
       
        //public My Type { get; set; }

    }

    public class MyTreeNode : TreeNode
    {
        string _type = "";
        private int _yearId = 0;
        private int _runningClassId = 0;

        public MyTreeNode()
            : base()
        {

        }

        public MyTreeNode(string text, string value)
            : base(text, value)
        {

        }

        public MyTreeNode(string text, string value, string imageUrl)
            : base(text, value, imageUrl)
        {

        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public int yearId
        {
            get { return _yearId; }
            set { _yearId = value; }
        }

        public int RunningClassId
        {
            get { return _runningClassId; }
            set { _runningClassId = value; }
        }

        protected override object SaveViewState()
        {
            object[] arrstate = new object[1];
            arrstate[0] = base.SaveViewState();
            //object stt = base.SaveViewState();
            return arrstate;

            //return base.SaveViewState();
        }

        protected override void LoadViewState(object state)
        {
            if (state != null)
            {
                var arrstate = state as object[];
                //arrstate[0];
                if (arrstate != null)
                    base.LoadViewState(arrstate[0]);
            }
            //base.LoadViewState(state);
            //base.LoadViewState(state);
        }

        //protected override object SaveViewState()
        //{
        //    object[] arrState = new object[1];
        //    arrState[0] = base.SaveViewState();

        //    //arrState[1] = this.Checked;
        //    //arrState[2] = this.Text;
        //    //arrState[3] = this.Value;

        //    //arrState[4] = _type;
        //    //arrState[5] = _yearId;
        //    //arrState[6] = _runningClassId;
        //    return arrState;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] arrState = savedState as object[];


        //        //this.Checked = (bool)arrState[1];
        //        //this.Text = (string)arrState[2];
        //        //this.Value = (string)arrState[3];

        //        //_type = (string)arrState[4];
        //        //_yearId = (int)arrState[5];
        //        //_runningClassId = (int)arrState[6];

        //        base.LoadViewState(arrState[0]);
        //    }
        //}
    }
}
