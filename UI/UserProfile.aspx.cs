using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;


namespace UI
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            NameLabel.Text = user.Name;
            LastNameLabel.Text = user.LastName;
            MailLabel.Text = user.Mail;
            DescriptionUserLabel.Text = user.Description;
            Image.ImageUrl = user.Picture;
        }

        

        protected void SetButton_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
           if(SetTextBox.Text=="")
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Startup", "<script>javascript:alert(' שגיאה')</script>");
                return;
            }
            switch (DropDownList1.SelectedValue)
            {
                case "SetName":
                    string oldName = user.Name;
                    user.SetName(SetTextBox.Text);
                    string newName = user.Name;
                    user = BLL.Static.UpdateUser(user.UserName, user.Name, user.LastName, user.UserPass, user.Mail, user.IsAdmin, user.IsBusiness, user.Description, user.Picture);
                    if (user == null)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Startup", "<script>javascript:alert(' שגיאה')</script>");
                        return;
                    }
                    break;

                case "SetLastName":
                    string oldLN = user.LastName;
                    user.SetLastName(SetTextBox.Text);
                    string newLN = user.LastName;
                    user = BLL.Static.UpdateUser(user.UserName, user.Name, user.LastName, user.UserPass, user.Mail, user.IsAdmin, user.IsBusiness, user.Description, user.Picture);
                    if (user == null)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Startup", "<script>javascript:alert(' שגיאה')</script>");
                        return;
                    }
                    break;

                case "SetMail":
                    string oldMail = user.Mail;
                    user.SetMail(SetTextBox.Text);
                    string newMail = user.Mail;
                    user = BLL.Static.UpdateUser(user.UserName, user.Name, user.LastName, user.UserPass, user.Mail, user.IsAdmin, user.IsBusiness, user.Description, user.Picture);
                    if (user == null)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Startup", "<script>javascript:alert(' שגיאה')</script>");
                        return;
                    }
                    break;

                case "SetPassword":
                    string oldPassword = user.UserPass;
                    string pass = SetTextBox.Text;
                    if (pass.Length < 8)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Startup", "<script>javascript:alert(' הסיסמה צריכה להיות לפחות באורך 8 תווים!')</script>");
                        return;
                    }

                    bool numCheck = false;
                    bool capitalCheck = false;
                    char[] specialCheck = { '.', '!', '@', '#', '$', '%', '*' };
                    if (!pass.Intersect(specialCheck).Any())
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Startup", "<script>javascript:alert(' הסיסמה צריכה להיות לפחות עם תו אחד מיוחד ('.', '!', '@', '#', '$', '%', '*')')</script>");
                        return;
                    }

                    for (int i = 0; i < pass.Length; i++)
                    {
                        if (pass[i] <= '9' && pass[i] >= '0')
                        {
                            numCheck = true;
                        }
                        if (pass[i] <= 'Z' && pass[i] >= 'A')
                        {
                            capitalCheck = true;
                        }

                    }

                    if (numCheck == false)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Startup", "<script>javascript:alert(' הסיסמה צריכה להיות לפחות עם מספר אחד !')</script>");
                        return;
                    }

                    if (capitalCheck == false)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Startup", "<script>javascript:alert(' הסיסמה צריכה להיות לפחות עם אות אחת גדולה באנגלית !')</script>");
                        return;
                    }
                    user.SetUserPass(SetTextBox.Text);
                    string newPassword = user.UserPass;
                    user = BLL.Static.UpdateUser(user.UserName, user.Name, user.LastName, user.UserPass, user.Mail, user.IsAdmin, user.IsBusiness, user.Description, user.Picture);
                    if (user == null)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Startup", "<script>javascript:alert(' שגיאה')</script>");
                        return;
                    }
                    break;
                default:
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Startup", "<script>javascript:alert('שגיאה!')</script>");
                    break;
            }
            //Response.Redirect("UserProfile.aspx");
        }

       
    }
}