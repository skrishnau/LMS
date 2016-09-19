using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academic.ViewModel
{
    public class RestrictionIdName
    {
        public string ParentId { get; set; }

        public string Name { get; set; }

        public string AbsoluteId { get; set; }
        public string RelativeId { get; set; }

        public string OtherId { get; set; }

        //public bool Visible { get; set; }

        public bool Void { get; set; }
        //public int NoOfChildren { get; set; }

        public List<RestrictionIdName> Children { get; set; }

        public void SetData(string parentId, string name
            , string absoluteId, string relativeId
            , string otherId, List<RestrictionIdName> children)
        {
            ParentId = parentId;
            this.Name = name;
            AbsoluteId = absoluteId;
            RelativeId = relativeId;
            OtherId = otherId;
            Children = children;

        }


    }

    public class RestrictionEventArgs : EventArgs
    {
        public string ParentId { get; set; }
        
        public string Type { get; set; }

        public string AbsoluteId { get; set; }
        public string RelativeId { get; set; }

    }
}
