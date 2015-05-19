using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BAL
{
    public class SingleProgramBAL
    {
        public MsProgram p = new MsProgram();

        public SingleProgramBAL(string id)
        {
            ProgramDAL dal = new ProgramDAL();
            p = dal.GetProgramById(id);
        }

        public string getTitle(string id)
        {
            if (p != null)
            {
                return p.title;
            }
            else
            {
                return "error";
            }
        }

        public string getDesc(string id)
        {
            if (p != null)
            {
                return p.descr;
            }
            else
            {
                return "error";
            }
        }

        public string getSize(string id)
        {
            if (p != null)
            {
                return p.size.ToString();
            }
            else
            {
                return "error";
            }
        }

        public string getPic(string id)
        {
            if (p != null)
            {
                return p.img.ToString();
            }
            else
            {
                return "error";
            }
        }
    }
}
