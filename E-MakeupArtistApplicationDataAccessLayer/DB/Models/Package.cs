using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.DB.Models
{
    public class Package
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        [ForeignKey("Artist")]
        public int? Offered_By { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual List<OrderDetail> OrderDetail { get; set; }

        public Package()
        {
            OrderDetail = new List<OrderDetail>();
        }
    }
}
