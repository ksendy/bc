using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BAL
{
    public class ProgramBAL
    {

        public bool AddProgram(MsProgramBAL pro)
        {
            ProgramDAL dal = new ProgramDAL();
            return dal.AddProgram(pro.ConvertToMsProgram(pro));
        }

        public bool DeleteProgram(string id)
        {
            ProgramDAL dal = new ProgramDAL();
            return dal.DeleteProgram(id);
        }

        public bool UpdateProgram(MsProgramBAL probal)
        {
            ProgramDAL dal = new ProgramDAL();
            return dal.UpdateProgram(probal.ConvertToMsProgram(probal));
        }

        public List<MsProgramBAL> GetProgramList()
        {
            ProgramDAL dal = new ProgramDAL();
            List<MsProgramBAL> liste = new List<MsProgramBAL>();
            foreach (MsProgram pro in dal.GetProgramList())
            {
                MsProgramBAL baru = new MsProgramBAL();
                liste.Add(baru.ConvertToMsProgramBAL(pro));
            }

            return liste;
        }

        public string getLastId()
        {
            ProgramDAL dal = new ProgramDAL();
            return dal.getLastID();
        }

        public MsProgramBAL getProgramById(string id)
        {
            ProgramDAL dal = new ProgramDAL();
            MsProgram pro = new MsProgram();
            MsProgramBAL probal = new MsProgramBAL();
            pro = dal.GetProgramById(id);
            probal = probal.ConvertToMsProgramBAL(pro);
            return probal;
        }

        public bool UpdateNewRating(string id, int InputRating)
        {
            double newRate = 0;
            ProgramDAL dal = new ProgramDAL();
            MsProgram probal = dal.GetProgramById(id);
            if (!probal.rating.HasValue)
            { newRate = InputRating; }
            else
            {
                newRate = (probal.rating.GetValueOrDefault() + Convert.ToDouble(InputRating));
                newRate = newRate / 2;
            }
            string temp = newRate.ToString();
            int l = temp.Length;
            if (l >= 4)
            { newRate = Convert.ToDouble(temp.Substring(0, 4)); }
            probal.rating = newRate;
            return dal.UpdateProgram(probal);
        }

        public List<string> GetTechList()
        {
            ProgramDAL dal = new ProgramDAL();
            return dal.GetTechList();
        }
        public List<MsProgramBAL> GetProgramListByTech(string tech)
        {
            ProgramDAL dal = new ProgramDAL();
            List<MsProgramBAL> lp = new List<MsProgramBAL>();
            foreach(MsProgram probal in dal.GetProgramListByTech(tech))
            {
                MsProgramBAL mp = new MsProgramBAL();
                lp.Add(mp.ConvertToMsProgramBAL(probal));
            }
            return lp;
        }
        /// <summary>
        /// untuk cek Di DB,
        /// apakah program ada atau tidak.
        /// Return  false jika yang dicari tidak ada, true jika ada.
        /// </summary>
        /// <param name="id">id Program</param>
        /// <returns>return  false jika yang dicari tidak ada, true jika ada</returns>
        public bool CekProgram(string id)
        {
            ProgramDAL dal = new ProgramDAL();
            return dal.CekProgram(id);
        }

        public bool UpdateStatus(string id)
        {
            ProgramDAL dal = new ProgramDAL();
            return dal.UpdateStatus(id);
        }
    }
}
