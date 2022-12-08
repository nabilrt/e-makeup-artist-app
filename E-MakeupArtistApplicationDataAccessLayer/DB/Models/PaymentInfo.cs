using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.DB.Models
{
    public class PaymentInfo
    {
        [Key]
        public int Id { get; set; }

        public double Price { get; set; }

        public int Discount { get; set; }
    }
}
