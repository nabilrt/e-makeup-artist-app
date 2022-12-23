using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationBussinessLogicLayer.DTOs
{
    public class TokenDTO
    {
        public int Id { get; set; }

        public string TokenDetails { get; set; }

        public DateTime Creation_Time { get; set; }

        public DateTime? Expired_At { get; set; }

        public int UserId { get; set; }
    }
}
