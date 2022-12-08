using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.DB.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Package")]
        public int PackageId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Package Package { get; set; }

        public virtual Order Order { get; set; }
    }
}
