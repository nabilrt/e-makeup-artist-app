using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationBussinessLogicLayer.DTOs
{
    internal class UserAdminDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string User_Type { get; set; }

        public int Is_Approved { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }


    }
}
