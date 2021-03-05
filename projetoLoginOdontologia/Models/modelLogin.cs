using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projetoLoginOdontologia.Models
{
    public class modelLogin
    {
        public string usuario { get; set; }
        public string senha { get; set; }
        public string confSenha { get; set; }
        public string tipo { get; set; }
    }
}