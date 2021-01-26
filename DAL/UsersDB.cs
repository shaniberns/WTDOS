using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class UsersDB
    {
        public static string PROVIDER = @"Microsoft.ACE.OLEDB.12.0"; 
        public static string SOURCE = @"E:\בית ספר\שירותי רשת\ShanisPro\WTDOSSolution\DAL\Database.accdb"; 
        public static DataRow LogIn(string userName, string userPass)

        {
            string sql = $"SELECT * FROM Users WHERE UserName = '{userName}' AND [Password] = '{userPass}';";
            DBHelper db = new DBHelper(PROVIDER, SOURCE);
            DataTable dt = db.GetDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            return dt.Rows[0];
        }

        public static bool SignIn(string userName, string name, string lastName, string userPass, string mail, bool isAdmin, bool isBussiness, string description, string Picture)

        {
            string sql = $"  INSERT INTO Users(UserName, Name, LastName, [Password], Mail, IsBusiness, IsAdmin, Description, Picture)VALUES ('{userName}', '{name}', '{lastName}', '{userPass}', '{mail}', {isAdmin}, {isBussiness}, '{description}', '{Picture}') ; ";
            DBHelper db = new DBHelper(PROVIDER, SOURCE);
            int recsAffected = db.WriteData(sql);

            return (recsAffected == 1);
        }


        public static int SignIn(string businessName, string businessAdress, string price, string userName)
        {
            string sql = $"INSERT INTO Business (BusinessName, BusinessAdress, Price, UserName) VALUES ('{businessName}','{businessAdress}','{price}','{userName}');";
            DBHelper db = new DBHelper(PROVIDER, SOURCE);
            int newID = db.InsertWithAutoNumKey(sql);
            return newID;
        }
        public static bool UpdateUser(string userName, string name, string lastName, string userPass, string mail, bool isAdmin, bool isBussiness, string description, string picture)
        {
            string sql = $"UPDATE Users SET Name='{name}', LastName='{lastName}', Mail='{mail}', [Password]='{userPass}', [IsAdmin]={isAdmin}, [IsBusiness]={isBussiness}, Description='{description}', Picture='{picture}' WHERE UserName='{userName}';";
            DBHelper db = new DBHelper(PROVIDER, SOURCE);
            int recsAffected = db.WriteData(sql);

            return (recsAffected == 1);
        }

            public static bool UserNameCheck (string check)
        {
            string sql = $"SELECT * FROM Users WHERE UserName = '{check}'";
            DBHelper db = new DBHelper(PROVIDER, SOURCE);
            DataTable dt = db.GetDataTable(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                //שם משתמש לא תפוס
                return false;
            }
            //שם משתמש תפוס
            return true;
        }
    }
}
