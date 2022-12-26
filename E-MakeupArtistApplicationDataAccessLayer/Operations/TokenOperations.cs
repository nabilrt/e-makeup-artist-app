using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class TokenOperations : Operations, IBasicOperations<Token, string, bool>,ITokenExpire<Token>
    {
        public Token Add(Token cls)
        {
            var token=db.Tokens.Add(cls);

            if (db.SaveChanges() > 0)
            {
                return token;
            }

            return null;
           
        }

        public bool Delete(string id)
        {
            var token=(from tk in db.Tokens where tk.TokenDetails==id select tk).FirstOrDefault();


            db.Tokens.Remove(token);

            if (db.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public bool ExpireTokenByUser(Token tok)
        {
            var token=(from t in db.Tokens where t.TokenDetails==tok.TokenDetails && t.UserId==tok.UserId select t).FirstOrDefault();
            token.Expired_At= DateTime.Now;

            if (db.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Token get(string id)
        {
            var token = (from tk in db.Tokens where tk.TokenDetails == id select tk).FirstOrDefault();

            return token;

        }

        public List<Token> getALL()
        {
            return db.Tokens.ToList();
        }

        public Token Update(Token cls)
        {
            throw new NotImplementedException();
        }
    }
}
