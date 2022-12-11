using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.DB.Models
{
    public class Admin
    {
        [Key]
        [ForeignKey("User")]

        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public virtual User User { get; set; }

    }
}
