using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CommentDAL
    {
        public bool AddComment(MsComment c)
        {
            dbDataContext db = new dbDataContext();
            db.MsComments.InsertOnSubmit(c);
            try
            { db.SubmitChanges(); return true; }
            catch
            {  return false; }
        }
        public List<MsComment> GetCommentsByProduct(string idPro)
        {
            dbDataContext db = new dbDataContext();
            var hasil = from baris in db.MsComments
                        where baris.idProgram == idPro
                        select baris;
            return hasil.ToList();
        }
        public bool DeleteComment(string id)
        {
            dbDataContext db = new dbDataContext();
            var hapus = (from baris in db.MsComments
                         where baris.idComment == id
                         select baris).SingleOrDefault();
            db.MsComments.DeleteOnSubmit(hapus);
            try
            { db.SubmitChanges(); return true; }
            catch
            { return false; }
        }

        public string GetNextId()
        {
            dbDataContext db = new dbDataContext();
            var hasil = (from baris in db.MsComments
                         orderby baris.idComment descending
                         select baris).FirstOrDefault();

            if (hasil == null)
            { return "0000000001"; }
            else
            { return Convert.ToString(Convert.ToInt32(hasil.idComment) + 1); }
        }
    }
}
