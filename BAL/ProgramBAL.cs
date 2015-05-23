using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BAL
{
    public class ProgramBAL
    {
        /// <summary>Tambah Program Baru</summary>
        /// <param name="pro">Ms Program BAL</param>
        /// <returns>true = BERHASIL, False = GAGAL</returns>
        public bool AddProgram(MsProgramBAL pro)
        {
            ProgramDAL dal = new ProgramDAL();
            return dal.AddProgram(pro.ConvertToMsProgram(pro));
        }

        /// <summary> Hapus/Delete Program</summary>
        /// <param name="id">ID Program</param>
        /// <returns>true = BERHASIL, False = GAGAL</returns>
        public bool DeleteProgram(string id)
        {
            ProgramDAL dal = new ProgramDAL();
            return dal.DeleteProgram(id);
        }

        /// <summary>Update Program</summary>
        /// <param name="probal">Ms Program BAL</param>
        /// <returns>true = BERHASIL, False = GAGAL</returns>
        public bool UpdateProgram(MsProgramBAL probal)
        {
            ProgramDAL dal = new ProgramDAL();
            return dal.UpdateProgram(probal.ConvertToMsProgram(probal));
        }

        /// <summary>
        /// Ambil List Program berdasarkan halaman
        /// ketik "home" untuk sort by rating
        /// ketik string apapun untuk
        /// </summary>
        /// <param name="page">string halaman</param>
        /// <returns>List Ms Program BAL</returns>
        public List<MsProgramBAL> GetProgramList(string page)
        {
            ProgramDAL dal = new ProgramDAL();
            List<MsProgram> p = new List<MsProgram>();
            p = (page == "home") ? dal.GetProgramListByRating() : dal.GetProgramList();
            List<MsProgramBAL> liste = new List<MsProgramBAL>();
            foreach (MsProgram pro in p)
            {
                MsProgramBAL baru = new MsProgramBAL();
                liste.Add(baru.ConvertToMsProgramBAL(pro));
            }
            return liste;
        }

        /// <summary>
        /// Ambil id Terakhir
        /// untuk keperluan input id
        /// dan input custom id
        /// </summary>
        /// <returns>string id</returns>
        public string getLastId()
        { ProgramDAL dal = new ProgramDAL(); return dal.getLastID(); }

        /// <summary>Mengambil 1 Program berdasarkan ID Program</summary>
        /// <param name="id">ID Program</param>
        /// <returns>Ms Program BAL</returns>
        public MsProgramBAL getProgramById(string id)
        {
            ProgramDAL dal = new ProgramDAL();
            MsProgram pro = new MsProgram();
            MsProgramBAL probal = new MsProgramBAL();
            pro = dal.GetProgramById(id);
            probal = probal.ConvertToMsProgramBAL(pro);
            return probal;
        }

        /// <summary>Update Rating yang ada</summary>
        /// <param name="id">ID Program</param>
        /// <param name="InputRating">rating yang mau di input</param>
        /// <returns>true = BERHASIL, False = GAGAL</returns>
        public bool UpdateNewRating(string id, int InputRating)
        {
            double newRate = 0;
            ProgramDAL dal = new ProgramDAL();
            MsProgram probal = dal.GetProgramById(id);
            if (!probal.rating.HasValue || probal.rating == 0)
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

        /// <summary>Menambil list Technology yg pernah di input</summary>
        /// <returns>List Technology</returns>
        public List<string> GetTechList()
        { ProgramDAL dal = new ProgramDAL(); return dal.GetTechList(); }
        public List<MsProgramBAL> GetProgramListByTech(string tech)
        {
            ProgramDAL dal = new ProgramDAL();
            List<MsProgramBAL> lp = new List<MsProgramBAL>();
            foreach (MsProgram probal in dal.GetProgramListByTech(tech))
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
        /// <returns>True = ADA, False = TIDAK ADA</returns>
        public bool CekProgram(string id)
        { ProgramDAL dal = new ProgramDAL(); return dal.CekProgram(id); }

        /// <summary>Update Status untuk Manipulasi DELETE</summary>
        /// <param name="id">ID PROGRAM</param>
        /// <returns>true = BERHASIL, False = GAGAL</returns>
        public bool UpdateStatus(string id)
        { ProgramDAL dal = new ProgramDAL(); return dal.UpdateStatus(id); }

        /// <summary>
        /// Cari program berdasarkan judul
        /// </summary>
        /// <param name="words">sebagian kalimat dicari</param>
        /// <returns></returns>
        public List<MsProgramBAL> SearchProgram(string words)
        { 
            ProgramDAL dal = new ProgramDAL();
            List<MsProgramBAL> lb = new List<MsProgramBAL>();
            foreach(MsProgram pro in dal.SearchProgram(words))
            {
                MsProgramBAL pb = new MsProgramBAL();
                pb = pb.ConvertToMsProgramBAL(pro);
                lb.Add(pb);
            }
            return lb;
        }
    }
}
