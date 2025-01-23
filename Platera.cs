using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2taldea
{
    public class Platera
    {
        public virtual int Id { get; set; }
        public virtual string Izena { get; set; }
        public virtual string Kategoria { get; set; }
        public virtual int Kantitatea { get; set; }
        public virtual float Prezioa { get; set; }
    }

}
