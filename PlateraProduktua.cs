using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2taldea
{
    public class PlateraProduktua
    {
        public virtual int Id { get; set; }
        public virtual int PlateraId { get; set; }
        public virtual int ProduktuaId { get; set; }
        public virtual int Kantitatea { get; set; }

        // Relaciones
        public virtual Produktua Produktua { get; set; }
        public virtual Platera Platera { get; set; }
    }
}
