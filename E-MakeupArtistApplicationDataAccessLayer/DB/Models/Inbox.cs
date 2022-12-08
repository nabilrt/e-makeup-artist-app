using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.DB.Models
{
    public class Inbox
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual List<Conversation > Conversation { get; set; }

        public Inbox() { 

            Conversation = new List<Conversation>();
        
        }
    }
}
