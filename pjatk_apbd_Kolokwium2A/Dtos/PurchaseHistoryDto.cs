namespace pjatk_apbd_Kolokwium2A.Dtos;

public class PurchaseHistoryDto
{
    public DateTime Date { get; set; }
    public int? Rating { get; set; }
    public double Price { get; set; }
    public WashingMachineDto WashingMachine { get; set; }
    public ProgramDto Program { get; set; }
}