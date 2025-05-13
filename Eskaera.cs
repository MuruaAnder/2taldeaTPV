namespace _2taldea
{
    public class Eskaera
    {
        public virtual int Id { get; set; }
        public virtual int EskaeraZenb { get; set; }  
        public virtual string Izena { get; set; }
        public virtual float Prezioa { get; set; }
        public virtual int MesaId { get; set; }
        public virtual byte Activo { get; set; }
    }
}