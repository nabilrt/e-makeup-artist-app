using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    internal class ConversationOperations : Operations, IBasicOperations<Conversation, int, bool>,IConversations<Conversation>
    {
        public Conversation Add(Conversation cls)
        {
            var conv=db.Conversations.Add(cls);

            if (db.SaveChanges() > 0)
            {
                return conv;
            }

            return null;
        }

        public bool Delete(int id)
        {
            var message=db.Conversations.Find(id);

            db.Conversations.Remove(message);

            if (db.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public bool deleteInboxConvos(int id)
        {
            var inboxes=(from inb in db.Conversations where inb.InboxId==id select inb).ToList();

            foreach(var inbox in inboxes)
            {
                db.Conversations.Remove(inbox);
            }

            var rs=db.SaveChanges();

            if (rs > 0)
            {
                return true;
            }

            return false;
        }

        public Conversation get(int id)
        {
            return db.Conversations.Find(id);
        }

        public List<Conversation> getALL()
        {
            return db.Conversations.ToList();
        }

        public List<Conversation> getAllConversations(int id)
        {
            return (from conv in db.Conversations where conv.InboxId== id select conv).ToList();
        }

        public Conversation Update(Conversation cls)
        {
            var conversation = get(cls.Id);

            if (conversation != null)
            {
                conversation.InboxId = cls.InboxId;
                conversation.Message = cls.Message;
                conversation.Reply = cls.Reply; 
                db.SaveChanges();

                return conversation;
            }

            return null;

        }
    }
}
