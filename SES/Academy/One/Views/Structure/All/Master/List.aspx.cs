﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using One.Values.MemberShip;

namespace One.Views.Structure.All.Master
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var user = User as CustomPrincipal;
                if (user != null)
                {
                    if (user.SchoolId > 0)
                    {
                        using (var helper = new DbHelper.Structure())
                        {
                            var node = helper.ListStructure(user.SchoolId);
                            foreach (var n in node)
                            {
                                TreeView1.Nodes.Add(n);
                            }
                        }
                    }
                }

            }
        }
    }
}