using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BAL
{
    public class CommentBAL
    {
        /// <summary>  Menambahakan Comment ke DB  </summary>
        /// <param name="cb">MS Comment BAL</param>
        /// <returns>Status Hasil input</returns>
        public bool AddComment(MsCommentBAL cb)
        {
            CommentDAL dal = new CommentDAL();
            MsComment c = new MsComment();
            c = cb.ConvertToMsComment(cb);
            return dal.AddComment(c);
        }

        /// <summary>  Mengambil Comment Berdasarkan ID PRogram </summary>
        /// <param name="idPro">id Program</param>
        /// <returns>List Comment</returns>
        public List<MsCommentBAL> GetCommentsByProduct(string idPro)
        {
            CommentDAL dal = new CommentDAL();
            List<MsCommentBAL> c = new List<MsCommentBAL>();
            foreach (MsComment mc in dal.GetCommentsByProduct(idPro))
            {
                MsCommentBAL b = new MsCommentBAL();
                b = b.ConvertToMsCommentBAL(mc);
                c.Add(b);
            }
            return c;
        }

        /// <summary> Hapus Comment yang ada </summary>
        /// <param name="idC">id Comment</param>
        /// <returns></returns>
        public bool DeleteComment(string idC)
        { CommentDAL dal = new CommentDAL(); return dal.DeleteComment(idC); }

        /// <summary>
        /// Menentukan di Berikutnya untuk keperluan Input 
        /// dan Custom ID input
        /// </summary>
        /// <returns>ID Berikutnnya</returns>
        public string GetNextId()
        { CommentDAL dal = new CommentDAL(); return dal.GetNextId(); }
    }
}
