using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BAL
{
    public class MsPenjualanBAL
    {
        public string idPenjualan
        { get; set; }
        public string idCustomer
        { get; set; }
        public string tglTrans
        { get; set; }
        public string detail
        { get; set; }


        public MsPenjualan ConvertToMsPenjualan(MsPenjualanBAL b)
        { 
            MsPenjualan jual = new MsPenjualan();
            jual.idPenjualan = b.idPenjualan;
            jual.idCustomer = b.idCustomer;
            jual.tglTrans = Convert.ToDateTime(b.tglTrans);
            jual.detail = b.detail;
            return jual;
        }

        public MsPenjualanBAL ConvertToMsPenjualanBAL(MsPenjualan jual)
        {
            MsPenjualanBAL b = new MsPenjualanBAL();
            
            b.idPenjualan = jual.idPenjualan;
            b.idCustomer = jual.idCustomer;   
            b.tglTrans = Convert.ToString(jual.tglTrans);
            b.detail = jual.detail;
            return b;
        }
    }
}
