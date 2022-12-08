using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Interfaces
{
    public interface IBasicOperations<CLASS,Id,RET>
    {
        List<CLASS> getALL();

        CLASS get(Id id);

        CLASS Add(CLASS cls);

        CLASS Update(CLASS cls);

        RET Delete(Id id);
    }
}
