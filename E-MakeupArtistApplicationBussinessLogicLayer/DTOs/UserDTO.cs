using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationBussinessLogicLayer.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string User_Type { get; set; }

        public int Is_Approved { get; set; }
    }
}
