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
    public class User
    {
        private string userName;
        private string name;
        private string lastName;
        private string userPass;
        private string mail;
        private bool isAdmin;
        private bool isBusiness;
        private string description;
        private string picture;


        public User(string userName, string name, string lastName, string userPass, string mail, bool isAdmin, bool isBusiness, string description, string picture)
        {
            this.userName = userName;
            this.name = name;
            this.lastName = lastName;
            this.userPass = userPass;
            this.mail = mail;
            this.isAdmin = false;
            this.isBusiness = isBusiness;
            this.description = description;
            this.picture = picture;
        }
        public bool IsAdmin
        {
            get
            {
                return isAdmin;
            }
        }

       

        public bool IsBusiness
        {
            get
            {
                return isBusiness;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

        }
        public string UserPass
        {
            get
            {
                return userPass;
            }

        }
        public void SetUserPass(string userPass)
        {
            this.userName = UserPass;

        }

        public void SetUserName(string userName)
        {
            this.userName = UserName;

        }

        public string Name
        {
            get
            {
                return name;
            }

        }

        public void SetName(string name)
        {
            this.name = name;

        }
        public string LastName
        {
            get
            {
                return lastName;
            }

        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;

        }
        public string FullName
        {
            get
            {
                return name+""+lastName;
            }

        }
        public string Mail
        {
            get
            {
                return mail;
            }

        }
        
        public void SetMail(string mail)
        {
            this.mail = mail;

        }

        public string Description
        {
            get
            {
                return description;
            }

        }

        public void SetDescription(string description)
        {
            this.mail = description;

        }
        public string Picture
        {
            get
            {
                return picture;
            }

        }

        public void SetPicture(string picture)
        {
            
            this.picture = picture;

        }

    }
}
