using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.DB.Models
{
    public class Customer
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; } 
        public string Name { get; set; }

        public DateTime DOB { get; set; }

        [ForeignKey("Area")]
        public int AreaId { get; set; }

        public string Address { get; set; }

        public int Is_Premium { get; set; }

        public virtual User User { get; set; }

        public virtual Area Area { get; set; }

        public virtual List<Inbox> Inbox { get; set; }

        public virtual List<Order> Order { get; set; }

        public Customer() { 

            Inbox = new List<Inbox>();
            Order = new List<Order>();

        }
    }
}
