using System.ComponentModel.DataAnnotations;

namespace PaySpace.Calculator.Domain.Entites
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
