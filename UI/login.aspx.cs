using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace UI
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           


        }
        protected void submit_Click(object sender, EventArgs e)
        {
            BLL.User user = BLL.Static.LogIn(userNameTextBox.Text, passTextBox.Text);
           
            if (user == null)
            {
                check.Visible = true;
                Session["admin"] = null;
                Session["user"] = null;
                return;
            }
            if (user.IsAdmin)
            {
                Session["admin"] = user;
                Session.Timeout = 20;
            }
            if (user.IsBusiness)
            {
                Session["bussiness"] = user;
                Session.Timeout = 20;
            }
            else
            {
                Session["user"] = user;
                Session.Timeout = 20;
            }
            check.Visible = false;
            Response.Redirect("main.aspx");
        }
    }
}