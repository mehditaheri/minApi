namespace BasicInformation.Core.Entities.Base
{
    public class BaseEntity<T> : IPersistentObject<T>
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        //[Column("id")]
        public T Id { get; set; }

        //public DateTime Created { get; set; }
        //public DateTime Modified { get; set; }

        //[ConcurrencyCheck]
        //[Timestamp]
        //public byte[]? RowVersion { get; set; }
    }
}
