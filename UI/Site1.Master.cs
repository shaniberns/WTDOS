using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                logInCell.Visible = false;
                logOutCell.Visible = true;
                SigninCell.Visible = false;
                


            }
            else if (Session["bussiness"] != null)
            {
                logInCell.Visible = false;
                logOutCell.Visible = true;
                SigninCell.Visible = false;
                UserProfileCell.Visible = false;
                AddArticleCell.Visible = false;

            }

            else if (Session["user"] != null)
            {
                logInCell.Visible = false;
                logOutCell.Visible = true;
                SigninCell.Visible = false;
                UserProfileCell.Visible = true;
                AddArticleCell.Visible = true;

            }

            else
            {
                logInCell.Visible = true;
                logOutCell.Visible = false;
                SigninCell.Visible = true;
                UserProfileCell.Visible = false;
                AddArticleCell.Visible = false;


            }
        }
        protected void LogOutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            logInCell.Visible = true;
            logOutCell.Visible = false;
            SigninCell.Visible = true;
            UserProfileCell.Visible = false;
            AddArticleCell.Visible = false;
            Response.Redirect("main.aspx");




        }

      
    }
}
