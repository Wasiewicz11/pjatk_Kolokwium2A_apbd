using pjatk_apbd_Kolokwium2A.Models;

namespace pjatk_apbd_Kolokwium2A.Dtos;

public class CustomerDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; } = null!;
    public List<PurchaseHistoryDto> PurchaseHistories { get; set; } = null!;
}