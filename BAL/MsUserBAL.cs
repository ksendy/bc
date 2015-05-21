using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BAL
{
    public class MsUserBAL
    {
        public string idCustomer
        { get; set; }
        public string nama
        { get; set; }
        public string alamat 
        { get; set; }
        public string username 
        { get; set; }
        public string pwd 
        { get; set; }
        public string kodepos 
        { get; set; }
        public string email 
        { get; set; }
        public string telp 
        { get; set; }
        public string provinsi 
        { get; set; }
        public string kota 
        { get; set; }
        public string img 
        { get; set; }
        public int lvl 
        { get; set; }
        public char status
        { get; set; }

        public MsCustomer ConvertToMsMsCustomer(MsUserBAL b)
        {
            MsCustomer c = new MsCustomer();
            c.idCustomer = b.idCustomer;
            c.nama = b.nama;
            c.alamat = b.alamat;
            c.username = b.username;
            c.pwd = b.pwd;
            c.kodepos = b.kodepos;
            c.email = b.email;
            c.telp = b.telp;
            c.provinsi = b.provinsi;
            c.kota = b.kota;
            c.img = b.img;
            c.lvl = b.lvl;
            c.status = b.status;
            return c;
        }
        public MsUserBAL ConvertToMsMsUserBAL(MsCustomer baru)
        {
            MsUserBAL b = new MsUserBAL();          
            b.idCustomer = baru.idCustomer;
            b.nama = baru.nama;
            b.alamat = baru.alamat;
            b.username = baru.username;
            b.pwd = baru.pwd;
            b.kodepos = baru.kodepos;
            b.email = baru.email;
            b.telp = baru.telp;
            b.provinsi = baru.provinsi;
            b.kota = baru.kota;
            b.img = baru.img;
            b.lvl = baru.lvl;
            b.status = Convert.ToChar(baru.status);
            return b;
        }
    }
}
