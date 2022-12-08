using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class TokenOperations : Operations, IBasicOperations<Token, string, bool>
    {
        public Token Add(Token cls)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Token get(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token> getALL()
        {
            throw new NotImplementedException();
        }

        public Token Update(Token cls)
        {
            throw new NotImplementedException();
        }
    }
}
