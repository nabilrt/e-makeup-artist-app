using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.DB.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }

        [ForeignKey("Artist")]
        public int? ArtistId { get; set; }

        public double TotalPrice { get; set; }

        public string Status { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Artist Artist { get;set; }

        public virtual List<OrderDetail> OrderDetail { get; set; }

        public Order()
        {
            OrderDetail = new List<OrderDetail>();
        }
    }
}
