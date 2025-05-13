using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2taldea
{
    internal class Fichaje
    {
        public virtual int Id { get; set; }
        public virtual Langilea Langilea { get; set; }
        public virtual DateTime HasieraOrdua { get; set; }
        public virtual DateTime BukaraOrdua { get; set; }
    }
}