using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class TopLinksDAL
    {
        public List<TopLink> GetLink(int level)
        {
            dbDataContext db = new dbDataContext();
            var hasil = from baris in db.TopLinks
                        where baris.level <= level && baris.level >= 1 
                        && baris.status != 0
                        select baris;
            return hasil.ToList();
        }

        public List<TopLink> GetLinkNoLogin()
        {
            dbDataContext db = new dbDataContext();
            var hasil = from baris in db.TopLinks
                        where baris.level >= 0 && baris.level <= 1 
                        && baris.status != 0
                        select baris;
            return hasil.ToList();
        }

        public List<TopLink> GetLinkList()
        {
            dbDataContext db = new dbDataContext();  
            var hasil = from baris in db.TopLinks
                        select baris;
            return hasil.ToList();
        }

        public TopLink GetSingleLink(int id)
        {
            dbDataContext db = new dbDataContext();
            var hasil = (from baris in db.TopLinks
                         where baris.idLink == id
                         select baris).SingleOrDefault();
            return hasil;
        }

        public bool AddLink(TopLink top)
        {
            dbDataContext db = new dbDataContext();
            db.TopLinks.InsertOnSubmit(top);
            try
            { db.SubmitChanges(); return true; }
            catch
            { return false; }
        }

        public bool DeleteLink(int id)
        {
            dbDataContext db = new dbDataContext();
            var hapus = (from baris in db.TopLinks
                         where baris.idLink == id
                         select baris).SingleOrDefault();
            db.TopLinks.DeleteOnSubmit(hapus);

            try
            { db.SubmitChanges(); return true; }
            catch
            { return false; }
        }

        public bool UpdateLink(TopLink top)
        {
            dbDataContext db = new dbDataContext();
            var update = (from baris in db.TopLinks
                          where baris.idLink == top.idLink
                          select baris).SingleOrDefault();
            if (update != null)
            {
                update.idLink = top.idLink;
                update.name = top.name;
                update.links = top.links;
                update.status = top.status;
                update.level = top.level;
                try
                { db.SubmitChanges(); return true; }
                catch
                { return false; }
            }
            else
            { return false; }
        }
    }
}
