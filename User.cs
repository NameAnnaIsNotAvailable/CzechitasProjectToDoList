using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace úkolovník
{
    public class User
    {
        public string UserResponse { get; set; }
        public int ChoseNumberUserResponse { get; set; }

        public User(string userResponse)
        {
            UserResponse = userResponse;         


        }
    }

}
