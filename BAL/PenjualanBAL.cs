using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;


namespace BAL
{
    public class PenjualanBAL
    {

        public MsPenjualanBAL GetPenjualanById(string id)
        {
            PenjualanDAL jual = new PenjualanDAL();
            MsPenjualanBAL bal = new MsPenjualanBAL();
            bal = bal.ConvertToMsPenjualanBAL(jual.GetPenjualanById(id));
            return bal;
        }

        public bool UpdatePenjualan(MsPenjualanBAL bal)
        {
            PenjualanDAL jual = new PenjualanDAL();
            return jual.UpdatePenjualan(bal.ConvertToMsPenjualan(bal));
        }

        public bool DeletePenjualan(string id)
        {
            PenjualanDAL dal = new PenjualanDAL();
            return dal.DeletePenjualan(id);
        }

        public bool AddPenjualan(MsPenjualanBAL b)
        {
            PenjualanDAL jual = new PenjualanDAL();
            MsPenjualanBAL bal = new MsPenjualanBAL();
            return jual.AddPenjualan(b.ConvertToMsPenjualan(b));
        }

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

        public int GetNextId()
        {
            PenjualanDAL dal = new PenjualanDAL();
            return dal.GetNextId();
        }


    }
}
