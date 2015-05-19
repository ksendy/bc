using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI
{
    public class Pass
    {
        public string AddZero(string id)
        {
            id = id.Trim();
            int qty = 10 - id.Length;
            string zero = "";
            for (int i = 1; i <= qty; i++)
            { zero += "0"; }
            zero += id;
            return zero;
        }     
    }
}