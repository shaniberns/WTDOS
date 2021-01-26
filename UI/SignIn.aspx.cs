using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace UI
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string pass = UserPassTextBox.Text;
            if (pass.Length < 8)
            {
                args.IsValid = false;
                PassValidate.ErrorMessage = "הסיסמה צריכה להיות לפחות באורך 8 תווים!";
                //return;
            }

            bool numCheck = false;
            bool capitalCheck = false;
            char[] specialCheck = { '.', '!', '@', '#', '$', '%', '*' };
            if (!pass.Intersect(specialCheck).Any())
            {
                args.IsValid = false;
                PassValidate.ErrorMessage = "הסיסמה צריכה להיות לפחות עם תו אחד מיוחד ('.', '!', '@', '#', '$', '%', '*')";
                //return;
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
                args.IsValid = false;
                PassValidate.ErrorMessage = "הסיסמה צריכה להיות לפחות עם מספר אחד !";
                //return;
            }

            if (capitalCheck == false)
            {
                args.IsValid = false;
                PassValidate.ErrorMessage = "הסיסמה צריכה להיות לפחות עם אות אחת גדולה באנגלית !";
                //return;
            }
            else
                args.IsValid = true;

        }



        protected void IsBusinessRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (bool.Parse(IsBusinessRadioButtonList.SelectedValue))
            {
                DescriptionUserLabel.Visible = false;
                DescriptionBusinessLabel.Visible = true;
                BusinessNameLabel.Visible = true;
                BusinessNameTextBox.Visible = true;
                BusinessAdressLabel.Visible = true;
                BusinessAdressTextBox.Visible = true;
                PriceLabel.Visible = true;
                PriceTextBox.Visible = true;
                PanelUser.Visible = true;
                submit.Visible = true;
            }

            else
            {
                PanelUser.Visible = true;
                DescriptionUserLabel.Visible = true;
                DescriptionBusinessLabel.Visible = false;
                BusinessNameLabel.Visible = false;
                BusinessNameTextBox.Visible = false;
                BusinessAdressLabel.Visible = false;
                BusinessAdressTextBox.Visible = false;
                PriceLabel.Visible = false;
                PriceTextBox.Visible = false;
                submit.Visible = true;
            }

        }

        protected void Unnamed_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            string userName = UserNameTextBox.Text;
            if (BLL.Static.UserNameCheck(userName))
            {
                args.IsValid = false;
                UserNameValidator.ErrorMessage = "השם משתמש תפוס!";

            }
            else args.IsValid = true;

        }
        protected void submit_Click(object sender, EventArgs e)
        {


          //  Page.Validate();
            if (!Page.IsValid)
            {
                successLabel.Visible = false;
                ErrorLabel.Visible = true;
            }
            else
            {
                
                string fileName = null;
                if (PictureFileUpload.HasFile)
                {
                    string[] extensionList = { ".jpg", ".png", ".gif" };
                    string extention = PictureFileUpload.FileName.Substring(PictureFileUpload.FileName.LastIndexOf("."));
                    if (extensionList.Contains(extention))
                    {
                        fileName = "img/" + UserNameTextBox.Text.ToString() + extention;
                        PictureFileUpload.PostedFile.SaveAs(Server.MapPath("~/" + fileName));

                    }

                }

                User user = BLL.Static.SignIn(UserNameTextBox.Text, NameTextBox.Text, LastNameTextBox.Text, UserPassTextBox.Text, MailTextBox.Text, false, bool.Parse(IsBusinessRadioButtonList.SelectedValue), DescriptionTextBox.Text, fileName ?? "img/profiledefult.png");
                if (user == null)
                {
                    ErrorLabel.Visible = true;
                    successLabel.Visible = false;
                }
                else
                {
                    Session["User"] = user;
                    if (!bool.Parse(IsBusinessRadioButtonList.SelectedValue))
                    {
                        Response.Redirect("main.aspx");
                    }
                    if (bool.Parse(IsBusinessRadioButtonList.SelectedValue))
                    {
                        //if business fields are filled
                        if (BusinessNameTextBox.Text == "" || BusinessAdressTextBox.Text == "" || PriceTextBox.Text == "")
                        {
                            //else show error messages
                            ErrorBusinessLabel.Visible = true;


                            successLabel.Visible = false;
                        }

                        else
                        {
                            BLL.Business business = BLL.Business.SignIn(BusinessNameTextBox.Text, BusinessAdressTextBox.Text, PriceTextBox.Text, UserNameTextBox.Text);
                            if (business == null)
                            {
                                ErrorLabel.Visible = true;
                                successLabel.Visible = false;
                            }

                            else
                            {

                                Session["business"] = business;
                                Response.Redirect("main.aspx");
                            }
                        }

                    }
                }
            } 
          } 
        }
    }
