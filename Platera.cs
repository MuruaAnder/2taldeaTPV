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
        public virtual string Deskribapena { get; set; }  // Nueva propiedad
        public virtual string Kategoria { get; set; }
        public virtual int Kantitatea { get; set; }
        public virtual float Prezioa { get; set; }      // Corregí el nombre (Prezioa en lugar de Prezioa)
        public virtual byte Menu { get; set; }
        public virtual string Foto { get; set; }

    }

}
