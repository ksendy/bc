using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ProgramDAL
    {

        public bool AddProgram(MsProgram baru)
        {
            dbDataContext db = new dbDataContext();
            db.MsPrograms.InsertOnSubmit(baru);

            try
            { db.SubmitChanges(); return true; }
            catch
            { return false; }
        }

        public List<MsProgram> GetProgramList()
        {
            dbDataContext db = new dbDataContext();

            var hasil = from baris in db.MsPrograms
                        select baris;

            return hasil.ToList();
        }

        public MsProgram GetProgramById(string id)
        {
            dbDataContext db = new dbDataContext();

            var hasil = (from baris in db.MsPrograms
                         where baris.idProgram == id
                         select baris).SingleOrDefault();
            return hasil;
        }

        public bool UpdateProgram(MsProgram pro)
        {
            dbDataContext db = new dbDataContext();

            var hasil = (from baris in db.MsPrograms
                         where baris.idProgram == pro.idProgram
                         select baris).SingleOrDefault();

            if (hasil != null)
            {
                hasil.idProgram = pro.idProgram;
                hasil.title = pro.title;
                hasil.descr = pro.descr;
                hasil.size = pro.size;
                hasil.rating = pro.rating;
                hasil.img = pro.img;
                hasil.date = pro.date;
                hasil.os = pro.os;
                hasil.license = pro.license;
                hasil.technology = pro.technology;
                try
                { db.SubmitChanges(); return true; }
                catch
               { return false; }

            }
            else
            { return false; }
        }

        public bool DeleteProgram(string id)
        {
            dbDataContext db = new dbDataContext();
            var hapus = (from baris in db.MsPrograms
                         where baris.idProgram == id
                         select baris).SingleOrDefault();

            if (hapus != null)
            {
                db.MsPrograms.DeleteOnSubmit(hapus);
                try
                { db.SubmitChanges(); return true; }
                catch
                { return false; }
            }
            else
            { return false; }
        }

        public string getLastID()
        {
            dbDataContext db = new dbDataContext();
            var cari = (from baris in db.MsPrograms
                        orderby baris.idProgram descending
                        select baris).FirstOrDefault();
            return cari.idProgram;
        }

        public List<string> GetTechList()
        {
            dbDataContext db = new dbDataContext();
            var cari = (from baris in db.MsPrograms
                        orderby baris.technology
                        select baris.technology).Distinct();
            return cari.ToList();
        }
        public List<MsProgram> GetProgramListByTech(string tech)
        {
            dbDataContext db = new dbDataContext();
            var cari = from baris in db.MsPrograms
                       where baris.technology == tech
                       select baris;
            return cari.ToList();
        }
        /// <summary>
        /// untuk cek Di DB,
        /// apakah program ada atau tidak
        /// </summary>
        /// <param name="id">id Program</param>
        /// <returns>return  false jika yang dicari tidak ada, true jika ada</returns>
        public bool CekProgram(string id)
        {
            dbDataContext db = new dbDataContext();
            var cari = (from baris in db.MsPrograms
                       where baris.idProgram == id
                       select baris).SingleOrDefault();
            return (cari == null) ? false : true;
        }

    }
}
