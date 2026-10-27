using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace multi_experiment
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Connection_class ob = new Connection_class();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ins = "select count(Reg_Id) from t_l";
            string maxreg = ob.fn_exescalar(ins).ToString();
            int regid = 0;
            if(maxreg == "")
            {
                regid = 1;
            }
            else
            {
                int regnew = Convert.ToInt32(maxreg);
                regid = regnew +regid;
            }
            string ins1="insert into t_u values("+regid+",'"+TextBox1.Text+"','"+TextBox2.Text+"')";
            int i = ob.fn_exenonquery(ins1);
            if (i == 1)
            {
                string ins2= "insert into t_l values(" + regid + ",'" + TextBox3.Text + "','" + TextBox4.Text +"','user')";
                int j = ob.fn_exenonquery(ins2);
                if (i == 1 & j == 1)
                {
                    Label1.Text = "succesful";
                }
                else
                {
                    Label2.Text = "something went wrong";
                }

            }

        }
    }
}