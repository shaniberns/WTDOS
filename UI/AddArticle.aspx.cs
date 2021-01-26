using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Threading;

namespace UI
{
    public partial class AddArticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SubButton_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            string writer = user.UserName;
            string title = TextBoxTitle.Text;
            string article = TextBoxArticle.Text;
            DateTime publishDate = DateTime.Today;
            bool visible = true;
            string picture;
            string visitDate = TextBoxDate.Text;
            bool family = CheckBoxCategories.Items[0].Selected;
            bool romantic = CheckBoxCategories.Items[1].Selected;
            bool pregnancy = CheckBoxCategories.Items[2].Selected;
            bool disabled = CheckBoxCategories.Items[3].Selected;
            bool nature = CheckBoxCategories.Items[4].Selected;
            int articleId = BLL.Static.AddArticle(writer, "img/profiledefult.png", article, publishDate, visitDate, visible, family, romantic, pregnancy, disabled, nature, title);
            if (Picture.HasFile)
            {
                string[] extensionList = { ".jpg", ".png", ".gif" };
                string extention = Picture.FileName.Substring(Picture.FileName.LastIndexOf("."));
                if (extensionList.Contains(extention))
                {
                    picture = "img/" + articleId.ToString() + extention;
                    Picture.PostedFile.SaveAs(Server.MapPath("~/" + picture));
                    BLL.Static.UpdatePicture(picture, articleId);
                }

            }

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Startup", "<script>javascript:alert(' הוספת כתבה בהצלחה!')</script>");
            
           
        }
    }
}