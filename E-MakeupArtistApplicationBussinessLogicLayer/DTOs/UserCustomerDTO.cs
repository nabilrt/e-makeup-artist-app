using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationBussinessLogicLayer.DTOs
{
    public class UserCustomerDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string User_Type { get; set; }

        public int Is_Approved { get; set; }

        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public int AreaId { get; set; }

        public string Address { get; set; }

        public int Is_Premium { get; set; }
    }
}
