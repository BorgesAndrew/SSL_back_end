using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Contatos
    {
        public int cdContato { get; set; }
        public string nmRazaoSocial { get; set; }
        public string nmFantasia { get; set; }
        public string dsCnpjCpf { get; set; }
        public string dsEmail { get; set; }
        public string dsFone { get; set; }
    }
}
