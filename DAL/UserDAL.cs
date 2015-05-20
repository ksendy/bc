using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UserDAL
    {
        /// <summary>
        /// Function untuk mengambil List data Semua customer
        /// Yang status nya 1 atau aktif
        /// </summary>
        /// <returns>List dengan tipe data MsCustomer</returns>
        public List<MsCustomer> GetUserList()
        {
            dbDataContext db = new dbDataContext();
            var hasil = from baris in db.MsCustomers
                        where baris.status == '1'
                        select baris;
            return hasil.ToList();
        }
        /// <summary>
        /// Function mengambil 1 data user berdasarkan id, return bisa null
        /// </summary>
        /// <param name="id">id customer</param>
        /// <returns>MsCustomer</returns>
        public MsCustomer GetUserById(string id)
        {
            dbDataContext db = new dbDataContext();
            var hasil = (from baris in db.MsCustomers
                         where baris.idCustomer == id
                         select baris).SingleOrDefault();
            return hasil;
        }

        /// <summary>
        /// Ambil User Berdasarkan username
        /// </summary>
        /// <param name="username">username</param>
        /// <returns></returns>
        public MsCustomer GetUserByUsername(string username)
        {
            dbDataContext db = new dbDataContext();
            var hasil = (from baris in db.MsCustomers
                         where baris.username == username
                         select baris).SingleOrDefault();
            return hasil;
        }

        /// <summary>
        /// User Autentifikasi, Untuk Login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool UserAuth(string username, string pwd)
        {
            dbDataContext db = new dbDataContext();
            var hasil = (from baris in db.MsCustomers
                         where baris.username == username && baris.pwd == pwd
                         select baris).SingleOrDefault();

            return (hasil != null) ? true : false;
        }


        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="customerUpdate"></param>
        /// <returns></returns>
        public bool UpdateUser(MsCustomer customerUpdate)
        {
            dbDataContext db = new dbDataContext();
            var update = (from baris in db.MsCustomers
                          where baris.idCustomer == customerUpdate.idCustomer
                          select baris).SingleOrDefault();
            if (update != null)
            {
                update.idCustomer = customerUpdate.idCustomer;
                update.nama = customerUpdate.nama;
                update.alamat = customerUpdate.alamat;
                update.username = customerUpdate.username;
                update.pwd = customerUpdate.pwd;
                update.kodepos = customerUpdate.kodepos;
                update.email = customerUpdate.email;
                update.telp = customerUpdate.telp;
                update.provinsi = customerUpdate.provinsi;
                update.kota = customerUpdate.kota;
                update.img = customerUpdate.img;
                update.lvl = customerUpdate.lvl;
                update.status = customerUpdate.status;
                try
                { db.SubmitChanges(); return true; }
                catch
                { return false; }
            }
            else
            { return false; }
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="customerBaru">Data Customer Baru</param>
        /// <returns></returns>
        public bool AddUser(MsCustomer customerBaru)
        {
            dbDataContext db = new dbDataContext();
            MsCustomer baru = new MsCustomer();
            baru = customerBaru;
            db.MsCustomers.InsertOnSubmit(baru);
            try
            { db.SubmitChanges(); return true; }
            catch
            { return false; }
        }

        /// <summary>
        /// Delete user 
        /// </summary>
        /// <param name="userId">User Id CUstomer</param>
        /// <returns>true jika benar, false jika salah </returns>
        public bool DeleteUser(string userId)
        {
            dbDataContext db = new dbDataContext();
            var hapus = (from baris in db.MsCustomers
                         where baris.idCustomer == userId
                         select baris).SingleOrDefault();

            db.MsCustomers.DeleteOnSubmit(hapus);
            try
            { db.SubmitChanges(); return true; }
            catch
            { return false; }
        }

        /// <summary>
        /// Ambil ID terakhir dalam Database User
        /// return 1 jika tabel masih kosong
        /// </summary>
        /// <returns>1 atau Last id Customer</returns>
        public int GetLastId()
        {
            dbDataContext db = new dbDataContext();
            var hasil = (from baris in db.MsCustomers
                         orderby baris.idCustomer descending
                         select baris.idCustomer).FirstOrDefault();
            return (hasil == null) ? 1 : Convert.ToInt32(hasil);
        }
        /// <summary>
        /// Cek User apakah ada atau tidak
        /// return true jika ada, false jika tidak ada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CekUser(string id)
        {
            dbDataContext db = new dbDataContext();
            var hasil = (from baris in db.MsCustomers
                         where baris.idCustomer == id
                         select baris.idCustomer).SingleOrDefault();
            return (hasil != null) ? true : false;
        }
        /// <summary>
        /// Manipulasi Hasil Hapus User, ganti status jadi 0
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ChangeStatus(string id)
        {
            dbDataContext db = new dbDataContext();
            var hasil = (from baris in db.MsCustomers
                         where baris.idCustomer == id
                         select baris).SingleOrDefault();
            if (hasil != null && hasil.status != '0')
            { hasil.status = '0'; db.SubmitChanges(); return true; }
            else
            { return false; }
        }
    }
}
