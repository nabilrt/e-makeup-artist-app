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
        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime DOB { get; set; }

        [ForeignKey("User")]
        public int User_Id { get; set; }

        public virtual User User { get; set; }

    }
}
