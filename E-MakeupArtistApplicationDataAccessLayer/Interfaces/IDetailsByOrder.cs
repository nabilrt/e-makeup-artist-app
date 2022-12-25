using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Interfaces
{
    public interface IDetailsByOrder<CLASS>
    {
        List<CLASS> GetDetailsByOrder(int id);

    }
}
