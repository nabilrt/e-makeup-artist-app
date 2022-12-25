using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    public class InboxOperations : Operations, IBasicOperations<Inbox, int, bool>,IPersonalMessages<Inbox>
    {
        public Inbox Add(Inbox cls)
        {
            var inb=db.Inboxes.Add(cls);

            if (db.SaveChanges() > 0)
            {
                return inb;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var inbox=(from inb in db.Inboxes where inb.Id==id select inb).FirstOrDefault();

            db.Inboxes.Remove(inbox);

            if (db.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Inbox get(int id)
        {
            return db.Inboxes.Find(id);
        }

        public List<Inbox> getALL()
        {
            return db.Inboxes.ToList();
        }

        public List<Inbox> getArtistOnlyInbox(int id)
        {
            var inboxes=(from inb in db.Inboxes where inb.ArtistId==id select inb).ToList();

            return inboxes;
        }

        public List<Inbox> getCustomerOnlyInbox(int id)
        {
            var inboxes = (from inb in db.Inboxes where inb.CustomerId == id select inb).ToList();

            return inboxes;
        }

        public Inbox Update(Inbox cls)
        {
            throw new NotImplementedException();
        }
    }
}
