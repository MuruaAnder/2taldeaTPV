namespace _2taldea
{
    public class EskaeraPlateraId
    {
        public virtual int Id { get; set; }
        public virtual int EskaeraId { get; set; }
        public virtual int PlateraId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (EskaeraPlateraId)obj;
            return Id == other.Id
                   && EskaeraId == other.EskaeraId
                   && PlateraId == other.PlateraId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + EskaeraId.GetHashCode();
                hash = hash * 23 + PlateraId.GetHashCode();
                return hash;
            }
        }
    }
}