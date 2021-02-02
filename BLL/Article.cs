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
    public class Article
    {
        private string writer; 
        private string picture;
        private string article;
        private DateTime publishDate;
        private string visitDate;
        private bool visible;
        private bool family;
        private bool romantic;
        private bool pregnancy;
        private bool disabled;
        private bool nature;
        private string title;
        private int articleId;

        public Article(int articleID)
        {
           DataRow row = DAL.ArticleDB.GetArticle(articleID);
            this.writer = (string)row["writer"];
            this.picture = (string)row["Picture"];
            this.article = (string)row["Article"];
            this.publishDate = DateTime.FromOADate((double)row["PublishDate"]);
            this.visitDate = (string)row["VisitDate"];
            this.visible = (bool)row["Visible"];
            this.family = (bool)row["Family"];
            this.romantic = (bool)row["Romantic"];
            this.pregnancy = (bool)row["pregnancy"];
            this.disabled = (bool)row["Disabled"];
            this.nature = (bool)row["nature"];
            this.title = (string)row["title"];
            this.articleId = articleID;
    }
        public Article(DataRow row)
        {
            this.writer = (string)row["writer"];
            this.picture = (string)row["Picture"];
            this.article = (string)row["Article"];
            this.publishDate = (DateTime)row["PublishDate"];
            this.visitDate = (string)row["VisitDate"];
            this.visible = (bool)row["Visible"];
            this.family = (bool)row["Family"];
            this.romantic = (bool)row["Romantic"];
            this.pregnancy = (bool)row["pregnancy"];
            this.disabled = (bool)row["Disabled"];
            this.nature = (bool)row["nature"];
            this.title = (string)row["title"];
            this.articleId = (int)row["ArticleID"];
        }
        public Article(string writer, string picture, string article, DateTime publishDate, string visitDate, bool visible, bool family, bool romantic, bool pregnancy, bool disabled, bool nature, string title)
        {
            this.writer = writer;
            this.picture = picture;
            this.article = article;
            this.publishDate = publishDate;
            this.visitDate = visitDate;
            this.visible = visible;
            this.family = family;
            this.romantic = romantic;
            this.pregnancy = pregnancy;
            this.disabled = disabled;
            this.nature = nature;
            this.title = title;
           
        }

        public string Writer
        {
            get { return writer; }
            set { writer = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public string Article_getset
        {
            get { return article; }
            set { article = value; }
        }

        public string VisitDate
        {
            get { return visitDate; }
            set { visitDate = value; }
        }

        public bool Family { get => family; set => family = value; }
        public bool Visible { get => visible; set => visible = value; }
        public bool Romantic { get => romantic; set => romantic = value; }
        public bool Pregnancy { get => pregnancy; set => pregnancy = value; }
        public bool Disabled { get => disabled; set => disabled = value; }
        public bool Nature { get => nature; set => nature = value; }
        public DateTime PublishDate { get => publishDate; set => publishDate = value; }

        public void UpdatePicture(string picture)
        {
            ArticleDB.UpdatePicture(picture, this.articleId);

        }
    }
}
