using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BT4.Models
{
    public class AutoGeneratekey
    {
        public string Generatekey(string ID)
        {
            string strkey = "";
            string numpPart = "", strPart = "", strPhanSo = "";
            numpPart = Regex.Match(ID, @"\d+").Value;
            int PhanSo = (Convert.ToInt32(numpPart) + 1);
            for(int i=0; i < numpPart.Length-PhanSo.ToString().Length;i++)
            {
                strPhanSo += "0";
            }
            strPhanSo += PhanSo;
            strkey = strPart + strPhanSo;
            return strkey;
        }

    }
}