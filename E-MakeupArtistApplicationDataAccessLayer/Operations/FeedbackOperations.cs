using E_MakeupArtistApplicationDataAccessLayer.DB.Models;
using E_MakeupArtistApplicationDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    public class FeedbackOperations : Operations, IBasicOperations<Feedback, int, bool>
    {
        public Feedback Add(Feedback cls)
        {
            var feedback=db.Feedbacks.Add(cls);

            db.SaveChanges();

            return feedback;
        }

        public bool Delete(int id)
        {
            db.Feedbacks.Remove(get(id));

            return db.SaveChanges() > 0;
        }

        public Feedback get(int id)
        {
            return db.Feedbacks.Find(id);
        }

        public List<Feedback> getALL()
        {
            return db.Feedbacks.ToList();
        }

        public Feedback Update(Feedback cls)
        {
            var feedback = get(cls.Id);

            feedback.Description = cls.Description;

            db.SaveChanges();

            return feedback;
        }
    }
}
