using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class CDDAL
    {
        public bool AddCD(MsCD baru)
        {
            dbDataContext db = new dbDataContext();
            db.MsCDs.InsertOnSubmit(baru);

            try
            {
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<MsCD> GetCDList()
        {
            dbDataContext db = new dbDataContext();

            var hasil = from baris in db.MsCDs
                        select baris;

            return hasil.ToList();
        }


        public MsCD GetCDById(string id)
        {
            dbDataContext db = new dbDataContext();

            var hasil = (from baris in db.MsCDs
                         where baris.idCD == id
                         select baris).SingleOrDefault();

            return hasil;
        }


        public bool UpdateCD(MsCD cd)
        {
            dbDataContext db = new dbDataContext();

            var hasil = (from baris in db.MsCDs
                         where baris.idCD == cd.idCD
                         select baris).SingleOrDefault();

            if (hasil != null)
            {
                hasil.idCD = cd.idCD;
                hasil.status = cd.status;
                hasil.ukuran = cd.ukuran;
                hasil.biaya = cd.biaya;
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }


        public bool DeleteCD(string id)
        {
            dbDataContext db = new dbDataContext();
            var hapus = (from baris in db.MsCDs
                         where baris.idCD == id
                         select baris).SingleOrDefault();

            if (hapus != null)
            {
                db.MsCDs.DeleteOnSubmit(hapus);
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
