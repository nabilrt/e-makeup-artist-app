using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationBussinessLogicLayer.DTOs
{
    public class PaymentInfoDTO
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public int Discount { get; set; }
    }
}
