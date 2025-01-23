using System;

namespace _2taldea
{
    public class Eskaera
    {
        public virtual int Id { get; set; } // ID del pedido
        public virtual int EskaeraZenb { get; set; } // Número del pedido
        public virtual string Izena { get; set; } // Nombre del pedido
        public virtual float Prezioa { get; set; } // Precio
        public virtual int MesaId { get; set; } // ID de la mesa asociada
        public virtual bool Activo { get; set; } // Indica si el pedido está activo o eliminado
    }
}
