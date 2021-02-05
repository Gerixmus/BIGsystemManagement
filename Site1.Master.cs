using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIGsystemManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check if user or admin logs in
            try
            {
                if (string.IsNullOrEmpty((string)Session["role"]))
                {
                    //user login button
                    LinkButton2.Visible = true;
                    //sign out button
                    LinkButton3.Visible = true;
                    //logout button
                    LinkButton4.Visible = false;
                    //hello user
                    LinkButton5.Visible = false;
                    //admin login button
                    LinkButton6.Visible = true;
                    //service management button
                    LinkButton7.Visible = false;
                    //order management button
                    LinkButton10.Visible = false;
                    //user management button
                    LinkButton11.Visible = false;
                }
                else if (Session["role"].Equals("user"))
                {
                    //user login button
                    LinkButton2.Visible = false;
                    //sign out button
                    LinkButton3.Visible = false;
                    //logout button
                    LinkButton4.Visible = true;
                    //hello user
                    LinkButton5.Visible = true;
                    LinkButton5.Text = "Hello " + Session["username"].ToString();
                    //admin login button
                    LinkButton6.Visible = false;
                    //service management button
                    LinkButton7.Visible = false;
                    //order management button
                    LinkButton10.Visible = false;
                    //user management button
                    LinkButton11.Visible = false;
                }
                else if (Session["role"].Equals("admin"))
                {
                    //user login button
                    LinkButton2.Visible = false;
                    //sign out button
                    LinkButton3.Visible = false;
                    //logout button
                    LinkButton4.Visible = true;
                    //hello user
                    LinkButton5.Visible = true;
                    LinkButton5.Text = "Hello Admin";
                    //admin login button
                    LinkButton6.Visible = false;
                    //service management button
                    LinkButton7.Visible = true;
                    //order management button
                    LinkButton10.Visible = true;
                    //user management button
                    LinkButton11.Visible = true;
                }
            }
            catch(Exception x)
            {
                Response.Write("<script>alert(" + x.Message + "');</script>");
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminservicemanagement.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminordermanagement.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminusermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }
        //logout
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["status"] = "";
            Session["role"] = "";
            //user login button
            LinkButton2.Visible = true;
            //sign out button
            LinkButton3.Visible = true;
            //logout button
            LinkButton4.Visible = false;
            //hello user
            LinkButton5.Visible = false;
            //admin login button
            LinkButton6.Visible = true;
            //service management button
            LinkButton7.Visible = false;
            //order management button
            LinkButton10.Visible = false;
            //user management button
            LinkButton11.Visible = false;
            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}