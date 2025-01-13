using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2taldea
{
    public class Produktua
    {
        public virtual int Id { get; set; }
        public virtual string Izena { get; set; }
        public virtual int Stock { get; set; }
        public virtual int Max { get; set; }
        public virtual int Min { get; set; }
        public virtual float Prezioa { get; set; }
    }
}

