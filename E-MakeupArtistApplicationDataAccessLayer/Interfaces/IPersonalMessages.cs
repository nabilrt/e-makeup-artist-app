using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Interfaces
{
    public interface IPersonalMessages<CLASS>
    {
        List<CLASS> getArtistOnlyInbox(int id); 
        List<CLASS> getCustomerOnlyInbox(int id);
    }
}
