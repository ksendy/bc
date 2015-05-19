using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BAL
{
    public class CommentBAL
    {
        public bool AddComment(MsCommentBAL cb)
        {
            CommentDAL dal = new CommentDAL();
            MsComment c = new MsComment();
            c = cb.ConvertToMsComment(cb);
            return dal.AddComment(c);
        }
        public List<MsCommentBAL> GetCommentsByProduct(string idPro)
        {
            CommentDAL dal = new CommentDAL();
            List<MsCommentBAL> c = new List<MsCommentBAL>();
            foreach(MsComment mc in dal.GetCommentsByProduct(idPro))
            {
                MsCommentBAL b = new MsCommentBAL();
                b = b.ConvertToMsCommentBAL(mc);
                c.Add(b);
            }
            return c;
        }
        public bool DeleteComment(string idC)
        {
            CommentDAL dal = new CommentDAL();
            return dal.DeleteComment(idC);
        }
        public string GetNextId()
        { 
            CommentDAL dal = new CommentDAL();
            return dal.GetNextId();
        }

    }
}
