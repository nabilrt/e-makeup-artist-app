using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationBussinessLogicLayer.DTOs
{
    public class InboxDTO
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public int ArtistId { get; set; }
    }
}
