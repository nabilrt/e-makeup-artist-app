using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationBussinessLogicLayer.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public int? ArtistId { get; set; }

        public double TotalPrice { get; set; }

        public string Status { get; set; }
    }
}
