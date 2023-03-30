using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;

public class BaseEntity<T>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    private T Id { get; set; }
}