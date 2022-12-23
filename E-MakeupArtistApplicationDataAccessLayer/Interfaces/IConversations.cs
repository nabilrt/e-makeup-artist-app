using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Interfaces
{
    public interface IConversations<CLASS>
    {
        List<CLASS> getAllConversations(int id);

        bool deleteInboxConvos(int id);
    }
}
