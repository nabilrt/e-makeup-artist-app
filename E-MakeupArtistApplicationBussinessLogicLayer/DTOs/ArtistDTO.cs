using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationBussinessLogicLayer.DTOs
{
    public class ArtistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public int AreaId { get; set; }
      
        public string Portfolio_Link { get; set; }
    }
}
