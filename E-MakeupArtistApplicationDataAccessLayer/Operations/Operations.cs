using E_MakeupArtistApplicationDataAccessLayer.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MakeupArtistApplicationDataAccessLayer.Operations
{
    public class Operations
    {
        protected EMakeupContext db;

        public Operations()
        {
            db = new EMakeupContext();
        }
    }
}
