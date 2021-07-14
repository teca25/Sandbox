using System;
using System.Collections.Generic;
using System.Text;

namespace sandbox
{
    class Users
    {
        public string username;
        public string password;
        public string userRole;
        public DateTime dateCreated;

        public Users(string username, string password, string userRole ,DateTime dateCreated)
        {
            this.username = username;
            this.password = password;
            this.userRole = userRole;
            this.dateCreated = dateCreated; 
        }
    }
}
