using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BAL
{
    public class MsCommentBAL
    {
        public string idComment
        { get; set; }
        public string idProgram
        { get; set; }
        public string idCustomer
        { get; set; }
        public string Comment
        { get; set; }

        public MsComment ConvertToMsComment(MsCommentBAL cb)
        {
            MsComment c = new MsComment()
            {
                idComment = cb.idComment,
                idProgram = cb.idProgram,
                idCustomer = cb.idCustomer,
                Comment = cb.Comment
            };
            return c;
        }

        public MsCommentBAL ConvertToMsCommentBAL(MsComment cb)
        {
            MsCommentBAL c = new MsCommentBAL()
            {
                idComment = cb.idComment,
                idProgram = cb.idProgram,
                idCustomer = cb.idCustomer,
                Comment = cb.Comment
            };
            return c;
        }
    }

}
