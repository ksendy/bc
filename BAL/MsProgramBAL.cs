using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BAL
{
    public class MsProgramBAL
    {
        public string idProgram
        { get; set; }
        public string title
        { get; set; }
        public string descr
        { get; set; }
        public int size
        { get; set; }
        public double rating
        { get; set; }
        public string img
        { get; set; }
        public string date
        { get; set; }
        public string os
        { get; set; }
        public string license
        { get; set; }
        public string technology
        { get; set; }
        public string status
        { get; set; }


        public MsProgramBAL ConvertToMsProgramBAL(MsProgram pro)
        {
            MsProgramBAL baru = new MsProgramBAL()
            {
                idProgram = pro.idProgram,
                title = pro.title,
                descr = pro.descr,
                size = pro.size,
                rating = pro.rating.GetValueOrDefault(),
                img = pro.img,
                date = pro.date.ToString(),
                os = pro.os,
                license = pro.license,
                technology = pro.technology,
                status = pro.status.ToString(),
            };
            return baru;
        }

        public MsProgram ConvertToMsProgram(MsProgramBAL pro)
        {
            MsProgram baru = new MsProgram()
            {
                idProgram = pro.idProgram,
                title = pro.title,
                descr = pro.descr,
                size = pro.size,
                rating = pro.rating,
                img = pro.img,
                date = Convert.ToDateTime(pro.date),
                os = pro.os,
                license = pro.license,
                technology = pro.technology,
                status = Convert.ToChar(pro.status),
            };
            return baru;
        }

    }
}
