using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.DB.Models
{
    public class Area
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Customer> Customer { get; set; }

        public virtual List<Artist> Artist { get; set; }

        public Area() { 

            Customer = new List<Customer>();

            Artist = new List<Artist>();
        
        }
    }
}
