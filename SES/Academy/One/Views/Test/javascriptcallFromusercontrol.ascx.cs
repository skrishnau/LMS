using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.Views.Test
{
    public partial class javascriptcallFromusercontrol : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDisplayDate1.Text = DateTime.Now.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script language='javascript'>function ChangeColor() {");
            sb.Append("var lbl = document.getElementById('lblDisplayDate1');");
            //sb.Append("$('#lblDisplayDate1').style.color='green'");
            //sb.Append("$('#lblDisplayDate1').style.backgroundColor='red';");
            sb.Append("lbl.style.color='green';");
            sb.Append("lbl.style.backgroundColor='red';");
            sb.Append("}</script>");

            //Render the function definition. 
            if (!Page.ClientScript.IsClientScriptBlockRegistered("JSScriptBlock"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "JSScriptBlock", sb.ToString());
            }

            //Render the function invocation. 
            string funcCall = "<script language='javascript'>ChangeColor();</script>";

            if (!Page.ClientScript.IsStartupScriptRegistered("JSScript"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "JSScript", funcCall);
            }
        }
    }
}