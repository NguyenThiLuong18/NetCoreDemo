using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetCoreDemo.Models;
using System.Text.RegularExpressions;
namespace NetCoreDemo.Models
{
    public class Process{
    public string GenerateKey (string id){
        string strkey = "";
        string numPart = "", strPart = "";
        numPart = Regex.Match(id, @"\d+").Value;
        strPart = Regex.Match (id, @"\D+").Value;
        int intPart = (Convert.ToInt32(numPart) + 1);
        for (int i = 0; i < numPart.Length - intPart.ToString().Length; i++){
            strPart += "0";
        }
        strkey= strPart + intPart;
        return strkey;
    }
    }
}