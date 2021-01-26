using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.OleDb;
using System.Runtime.CompilerServices;


namespace BLL
{
    public class Business
    {
        private int businessID;
        private string businessName;
        private string businessAdress;
        private string price;
        private string userName;
       


        public Business(int businessID, string businessName, string businessAdress, string price, string userName)
        {
            this.businessID = businessID;
            this.businessName = businessName;
            this.businessAdress = businessAdress;
            this.price = price;
            this.userName = userName;
            

        }

        public static Business SignIn(string businessName, string businessAdress, string price, string userName)
        {
            
            int result = UsersDB.SignIn(businessName, businessAdress, price, userName);

            if (result != DBHelper.WRITEDATA_ERROR)
            {

                Business business = new Business(result, businessName, businessAdress, price, userName);

                return business;

            }
            else
                return null;
            
        }

    
    }
}
