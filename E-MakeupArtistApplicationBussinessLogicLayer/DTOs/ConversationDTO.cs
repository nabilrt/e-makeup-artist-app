using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationBussinessLogicLayer.DTOs
{
    public class ConversationDTO
    {
        public int Id { get; set; }

        public int InboxId { get; set; }

        public string Message { get; set; }

        public string Reply { get; set; }
    }
}
