using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BAL
{
    public class UserBAL
    {
        /// <summary>Cek User untuk Login</summary>
        /// <param name="username">username</param>
        /// <param name="pwd">Pass</param>
        /// <returns>true = ADA USER, False = TIDAK ADA USER</returns>
        public bool CekLogin(string username, string pwd)
        { UserDAL dal = new UserDAL(); return dal.UserAuth(username, pwd); }
        /// <summary> Ambil Level dari USER</summary>
        /// <param name="username">username</param>
        /// <returns>LEVEL user</returns>
        public int getLevel(string username)
        {
            UserDAL dal = new UserDAL();
            MsCustomer c = new MsCustomer();
            c = dal.GetUserByUsername(username);
            return c.lvl;
        }
        /// <summary> Ambil 1 data Berdasarkan username</summary>
        /// <param name="username">username</param>
        /// <returns>Ms User BAL</returns>
        public MsUserBAL getUserByUsername(string username)
        {
            UserDAL dal = new UserDAL();
            MsUserBAL bal = new MsUserBAL();
            MsCustomer c = new MsCustomer();
            c = dal.GetUserByUsername(username);
            return bal.ConvertToMsMsUserBAL(c);
        }
        /// <summary>tambah User Baru</summary>
        /// <param name="b">Ms User BAL Baru</param>
        /// <returns>true = BERHASIL, False = GAGAL</returns>
        public bool AddUser(MsUserBAL b)
        {
            UserDAL dal = new UserDAL();
            //cek user double
            if (dal.GetUserByUsername(b.username) == null)
            {
                //input user id
                int newId = dal.GetLastId() + 1;
                b.idCustomer = newId.ToString();
                return dal.AddUser(b.ConvertToMsMsCustomer(b));
            }
            return false;
        }
        /// <summary>Hapus / DELETE USER </summary>
        /// <param name="id">id User</param>
        /// <returns>true = BERHASIL, False = GAGAL</returns>
        public bool DeleteUser(string id)
        { UserDAL dal = new UserDAL(); return dal.DeleteUser(id); }
        /// <summary>Update User</summary>
        /// <param name="baru">MS USER BAL BARU</param>
        /// <returns>true = BERHASIL, False = GAGAL</returns>
        public bool UpdateUser(MsUserBAL baru)
        {
            MsCustomer cust = new MsCustomer();
            UserDAL dal = new UserDAL();
            cust = baru.ConvertToMsMsCustomer(baru);
            return dal.UpdateUser(cust);
        }
        /// <summary>
        /// Ambil ID Terakhir di DB
        /// Untuk keperluan Custom ID
        /// </summary>
        /// <returns></returns>
        public string GetLastId()
        { UserDAL dal = new UserDAL(); return dal.GetLastId().ToString(); }
        /// <summary>Ambil SEMUA List User </summary>
        /// <returns>List MS User BAL</returns>
        public List<MsUserBAL> GetUserList()
        {
            UserDAL dal = new UserDAL();
            List<MsCustomer> mc = new List<MsCustomer>();
            List<MsUserBAL> mu = new List<MsUserBAL>();
            mc = dal.GetUserList();
            foreach (MsCustomer cus in mc)
            {
                MsUserBAL ub = new MsUserBAL();
                ub = ub.ConvertToMsMsUserBAL(cus);
                mu.Add(ub);
            }
            return mu;
        }
        /// <summary> Ambil User Berdasarkan ID </summary>
        /// <param name="id">USER ID</param>
        /// <returns>1 MS USER DAL</returns>
        public MsUserBAL GetUserById(string id)
        {
            UserDAL dal = new UserDAL();
            MsUserBAL mu = new MsUserBAL();
            mu = mu.ConvertToMsMsUserBAL(dal.GetUserById(id));
            return mu;
        }
        /// <summary>Cek User apakah ada di DB atau tidak</summary>
        /// <param name="id">ID User</param>
        /// <returns>true = ADA, False = TIDAK ADA</returns>
        public bool CekUser(string id)
        { UserDAL dal = new UserDAL(); return dal.CekUser(id); }
        /// <summary>
        /// Manipulasi DELETE USER
        /// </summary>
        /// <param name="id">USER ID</param>
        /// <returns>true = BERHASIL, False = GAGAL</returns>
        public bool ChangeStatus(string id)
        { UserDAL dal = new UserDAL(); return dal.ChangeStatus(id); }
    }
}
