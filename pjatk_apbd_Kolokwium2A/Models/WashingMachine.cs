using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pjatk_apbd_Kolokwium2A.Models;

[Table("WashingMachine")]
public class WashingMachine
{
    [Key]
    public int WashingMachineId { get; set; }
    [Column(TypeName = "decimal")]
    [Precision(10, 2)]
    public double MaxWeight { get; set; }

    public string SerialNumber { get; set; } = null!;

    public ICollection<AvailableProgram> AvaliblePrograms { get; set; } = null!;
}