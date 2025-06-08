using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pjatk_apbd_Kolokwium2A.Models;

[Table("Program")]
public class Program
{
    [Key]
    public int ProgramId { get; set; }

    [MaxLength(50)] 
    public string Name { get; set; } = null!;
    public int DurationMinutes { get; set; }
    public int TemperatureCelsius { get; set; }

    public ICollection<AvailableProgram> AvaliblePrograms { get; set; } = null!;
}