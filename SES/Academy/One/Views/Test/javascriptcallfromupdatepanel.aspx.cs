using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Test
{
    public partial class javascriptcallfromupdatepanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblDisplayDate.Text = DateTime.Now.ToString();
            }
        }

        protected void btnPostBack2_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script language='javascript'>function ChangeColor() {");
            sb.Append("var lbl = document.getElementById('lblDisplayDate');");
            sb.Append("lbl.style.color='green';");
            sb.Append("lbl.style.backgroundColor='red';");
            sb.Append("}</script>");

            //Render the function definition. 
            if (!ClientScript.IsClientScriptBlockRegistered("JSScriptBlock"))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "JSScriptBlock", sb.ToString());
                
            }

            //Render the function invocation. 
            string funcCall = "<script language='javascript'>ChangeColor();</script>";

            if (!ClientScript.IsStartupScriptRegistered("JSScript"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "JSScript", funcCall);
            }
        }
    }
}