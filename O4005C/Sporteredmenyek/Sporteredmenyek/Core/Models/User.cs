using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Core.Models
{
    public class User
    {
        private string _name { get; }
        private string _email { get;}
        private string _password { get;}

        public string Name => _name;
        public string Email => _email;
        public string Password => _password;

        public User(string name, string email, string password){
            this._name = name;
            this._email = email;
            this._password = password;
        }

        
    }


}
