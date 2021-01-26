using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class ArticleDB
    {
        public static string PROVIDER = @"Microsoft.ACE.OLEDB.12.0";
        public static string SOURCE = @"E:\בית ספר\שירותי רשת\ShanisPro\WTDOSSolution\DAL\Database.accdb";

        public static int AddArticle(string writer, string picture, string article, DateTime publishDate, string visitDate, bool visible, bool family, bool romantic, bool pregnancy, bool disabled, bool nature, string title)
        {
            DBHelper db = new DBHelper(PROVIDER, SOURCE);
            string sqlString = $"INSERT INTO Article (Writer, Picture, Article, PublishDate, VisitDate, Visible, Family, Romantic, pregnancy, Disabled, nature, Title) VALUES ('{writer}','{picture}','{article}',{publishDate.ToOADate()},'{visitDate}',{visible},{family},{romantic},{pregnancy},{disabled},{nature},'{title}');";
            int newId = db.InsertWithAutoNumKey(sqlString);
            return newId;
        }
        public static DataRow GetArticle(int articleID)
        {
            DBHelper db = new DBHelper(PROVIDER, SOURCE);
            string sql = $"SELECT * FROM Article WHERE ArticleID={articleID}";
            DataRow row = db.GetDataTable(sql).Rows[0];
            return row;
        }
        public static DataTable GetArticels()
        {
            DBHelper db = new DBHelper(PROVIDER, SOURCE);
            string sqlString = $"SELECT * FROM Article";
            DataTable table = db.GetDataTable(sqlString);
            return table;
        }

        public static bool UpdatePicture(string picture, int articleId)
        {
            string sql = $"UPDATE Article SET  Picture='{picture}' WHERE ArticleID={articleId};";
            DBHelper db = new DBHelper(PROVIDER, SOURCE);
            int recsAffected = db.WriteData(sql);

            return (recsAffected == 1);
        }
    }
}

