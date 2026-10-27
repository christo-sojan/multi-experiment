using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace multi_experiment
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        Connection_class ob = new Connection_class();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string se = "select count(Reg_Id) from t_l where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
            string id = ob.fn_exescalar(se);
            int id1 = Convert.ToInt32(id);
            if (id1 == 1)
            {
                string sel = "select Log_Type from t_l where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
                string logtype = ob.fn_exescalar(sel);
                if (logtype == "admin")
                {
                    Response.Redirect("WebForm4.aspx");
                }
                else if(logtype == "user")
                {
                    Response.Redirect("WebForm5.aspx");
                }
                else
                {
                    Label1.Text = "invalid entry";
                }
            }

        }
    }

}