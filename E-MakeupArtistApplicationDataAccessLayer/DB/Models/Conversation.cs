using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.DB.Models
{
    public class Conversation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Inbox")]
        public int InboxId { get; set; }

        public string Message { get; set; }

        public string Reply { get; set; }

        public virtual Inbox Inbox { get; set; }
    }
}
