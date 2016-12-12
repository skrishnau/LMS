using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace One.TestingOnly
{
    public partial class AutoCompleteTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [System.Web.Script.Services.ScriptMethod]
        [System.Web.Services.WebMethod]
        public static List<string> SearchCustomers(string prefixText, int count)
        {
              var cnt = new List<string>
            {
                "Nepal", "Us","UK","Pakistan","Afganistan"
            ,"america","bhutan","India","Bangladesh","syria","Myanmar","Vatican city"
            };
            return cnt;
            return cnt.Where(x => x.StartsWith(prefixText)).ToList();
            //using (SqlConnection conn = new SqlConnection())
            //{
            //    conn.ConnectionString = ConfigurationManager
            //            .ConnectionStrings["constr"].ConnectionString;
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        cmd.CommandText = "select ContactName from Customers where " +
            //        "ContactName like @SearchText + '%'";
            //        cmd.Parameters.AddWithValue("@SearchText", prefixText);
            //        cmd.Connection = conn;
            //        conn.Open();
            //        List<string> customers = new List<string>();
            //        using (SqlDataReader sdr = cmd.ExecuteReader())
            //        {
            //            while (sdr.Read())
            //            {
            //                customers.Add(sdr["ContactName"].ToString());
            //            }
            //        }
            //        conn.Close();
            //        return customers;
            //    }
            //}
        }

    }
}