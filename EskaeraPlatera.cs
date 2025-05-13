namespace _2taldea
{
    public class EskaeraPlatera
    {
        public virtual int Id { get; set; }
        public virtual Eskaera Eskaera { get; set; }  // Objeto relacionado (contiene eskaera_id)
        public virtual Platera Platera { get; set; }   // Objeto relacionado (contiene platera_id)
        public virtual string NotaGehigarriak { get; set; }
        public virtual byte Egoera { get; set; }
        public virtual byte Done { get; set; }
        public virtual DateTime EskaeraOrdua { get; set; }
        public virtual DateTime? AteratzeOrdua { get; set; }
    }
}