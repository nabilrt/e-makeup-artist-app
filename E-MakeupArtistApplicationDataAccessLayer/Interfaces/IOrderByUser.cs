using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Interfaces
{
    public interface IOrderByUser<CLASS>
    {
        List<CLASS> GetOrderByArtist(int id);

        List<CLASS> GetOrderByCustomer(int id);
    }
}
