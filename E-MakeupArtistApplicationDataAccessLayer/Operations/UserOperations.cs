using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class UserOperations : Operations, IBasicOperations<User, int, bool>,IAuth<User>
    {
        public User Add(User cls)
        {
            db.Users.Add(cls);

            if (db.SaveChanges() > 0)
            {
                return cls;
            }

            return null;
        }

        public User Authenticate(string username, string password)
        {
          //  var user = db.Users.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
            return db.Users.FirstOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password) && x.Is_Approved.Equals("Yes"));
        }

        public bool Delete(int id)
        {
            db.Users.Remove(get(id));

            return db.SaveChanges() > 0;
        }

        public User get(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> getALL()
        {
            return db.Users.ToList();
        }

        public User Update(User cls)
        {
            var user = get(cls.Id);
            user.Username = cls.Username;
            user.Password = cls.Password;
            user.Email = cls.Email;

            db.SaveChanges();

            return user;
        }
    }
}
