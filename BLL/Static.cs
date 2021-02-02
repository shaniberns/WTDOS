using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.OleDb;

namespace BLL
{
    public class Static
    {
        public static User SignIn(string userName, string name, string lastName, string userPass, string mail, bool isAdmin, bool isBusiness, string description, string Picture)
        {
            if (UsersDB.SignIn(userName, name, lastName, userPass, mail, isAdmin, isBusiness, description, Picture))
            {
                return new User(userName, name, lastName, userPass, mail, isAdmin, isBusiness, description, Picture);
            }

            else
            {
                return null;
            }
        }


        public static bool UserNameCheck(string userName)
        {
            return UsersDB.UserNameCheck(userName);

        }

        public static User LogIn(string userName, string userPass)
        {
            DataRow dr = UsersDB.LogIn(userName, userPass);

            User user = null;
            if (dr != null)
            {

                user = new User(userName, (string)dr["name"], (string)dr["LastName"], userPass, (string)dr["Mail"], (bool)dr["IsBusiness"], (bool)dr["isAdmin"], (string)dr["Description"], (string)dr["Picture"]);
            }
            return user;
        }

        public static User UpdateUser(string userName, string name, string lastName, string userPass, string mail, bool isAdmin, bool isBussiness, string description, string picture)
        {

            if (UsersDB.UpdateUser(userName, name, lastName, userPass, mail, isAdmin, isBussiness, description, picture))
            {
                return new User(userName, name, lastName, userPass, mail, isAdmin, isBussiness, description, picture);
            }

            else
            {
                return null;
            }
        }
        public static int AddArticle(string writer, string picture, string article, DateTime publishDate, string visitDate, bool visible, bool family, bool romantic, bool pregnancy, bool disabled, bool nature, string title)
        {
            int res = ArticleDB.AddArticle(writer, picture, article, publishDate, visitDate, visible, family, romantic, pregnancy, disabled, nature, title);
           
                return res;
        }
        

        public static List<Article> GetArticles()
        {
           DataTable dataTable = ArticleDB.GetArticles();
            List<Article> Article = new List<Article>();
            foreach (DataRow article in dataTable.Rows)
            {
                Article artcl = new Article(article);
                Article.Add(artcl);
            }

            return Article;
        }

        public static List<Article> ArticlesFilter(List<Article> lst, string search, bool family, bool romantic, bool pregnancy, bool disabled, bool nature)
        {
            List<Article> Articles = new List<Article>();    
            
            foreach(Article a in lst)
            {
                bool found = false;

                if (search != "")
                {
                    found = a.Title.Contains(search);
                }

                if (family)
                {
                    found = a.Family;
                }

                ////////
                
                if (found)
                {
                    Articles.Add(a);
                }

             }

            return Articles;



        }
    }
}
