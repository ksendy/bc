using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;


namespace BAL
{
    public class PenjualanBAL
    {
        /// <summary>Ambil 1 Data Penjualan Berdasarkan ID</summary>
        /// <param name="id">id Penjualan</param>
        /// <returns>1 Data Penjualan</returns>
        public MsPenjualanBAL GetPenjualanById(string id)
        {
            PenjualanDAL jual = new PenjualanDAL();
            MsPenjualanBAL bal = new MsPenjualanBAL();
            bal = bal.ConvertToMsPenjualanBAL(jual.GetPenjualanById(id));
            return bal;
        }

        /// <summary>Update Penjualan</summary>
        /// <param name="bal">Data MsPenjualan BAL</param>
        /// <returns>true = BERHASIL, False = GAGAL</returns>
        public bool UpdatePenjualan(MsPenjualanBAL bal)
        {
            PenjualanDAL jual = new PenjualanDAL();
            return jual.UpdatePenjualan(bal.ConvertToMsPenjualan(bal));
        }

        /// <summary>Hapus / Delete Penjualan</summary>
        /// <param name="id">ID Penjualan</param>
        /// <returns>true = BERHASIL, False = GAGAL</returns>
        public bool DeletePenjualan(string id)
        { PenjualanDAL dal = new PenjualanDAL(); return dal.DeletePenjualan(id); }

        /// <summary>Tambah data Penjualan Baru</summary>
        /// <param name="b">Ms Penjualan BAL</param>
        /// <returns>true = BERHASIL, False = GAGAL</returns>
        public bool AddPenjualan(MsPenjualanBAL b)
        {
            PenjualanDAL jual = new PenjualanDAL();
            MsPenjualanBAL bal = new MsPenjualanBAL();
            return jual.AddPenjualan(b.ConvertToMsPenjualan(b));
        }

        /// <summary>Ambil List SEMUA Data Penjualan</summary>
        /// <returns>List Data Penjualan</returns>
        public List<MsPenjualanBAL> GetPenjualanList()
        {
            PenjualanDAL dal = new PenjualanDAL();
            List<MsPenjualanBAL> baru = new List<MsPenjualanBAL>();
            foreach (MsPenjualan jual in dal.GetPenjualanList())
            {
                MsPenjualanBAL b = new MsPenjualanBAL();
                baru.Add(b.ConvertToMsPenjualanBAL(jual));
            }
            return baru;
        }

        /// <summary>
        /// Ambil ID Berikutnya, untuk keperluan input
        /// atau keperluan Custom ID Input
        /// </summary>
        /// <returns>int ID, tanpa 0 di depan</returns>
        public int GetNextId()
        { PenjualanDAL dal = new PenjualanDAL(); return dal.GetNextId(); }


    }
}
