using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2taldea
{
    internal class Langilea
    {
        public virtual int Id { get; set; } // Clave primaria
        public virtual string Izena { get; set; }
        public virtual string Pasahitza { get; set; }
        public virtual string Postua { get; set; }
    }
}
