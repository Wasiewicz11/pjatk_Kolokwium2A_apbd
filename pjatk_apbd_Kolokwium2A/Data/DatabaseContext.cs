using Microsoft.EntityFrameworkCore;
using pjatk_apbd_Kolokwium2A.Models;

namespace pjatk_apbd_Kolokwium2A.Data;

public class DatabaseContext : DbContext
{
    public DbSet<WashingMachine> WashingMachines { get; set; }
    public DbSet<pjatk_apbd_Kolokwium2A.Models.Program> Programs { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WashingMachine>().HasData(new List<WashingMachine>()
        {
            new WashingMachine() { WashingMachineId = 1, MaxWeight = 15, SerialNumber = "1234567890"},
            new WashingMachine() { WashingMachineId = 2, MaxWeight = 12, SerialNumber = "1234567891"},
            new WashingMachine() { WashingMachineId = 3, MaxWeight = 15, SerialNumber = "1234567895"}
        });
        modelBuilder.Entity<pjatk_apbd_Kolokwium2A.Models.Program>()
            .HasData(new List<pjatk_apbd_Kolokwium2A.Models.Program>()
            {
                new Models.Program(){ProgramId = 1, Name = "Szybkie", DurationMinutes = 30, TemperatureCelsius = 30},
                new Models.Program(){ProgramId = 2, Name = "Wirowanie", DurationMinutes = 15, TemperatureCelsius = 30},
                new Models.Program(){ProgramId = 3, Name = "Eco", DurationMinutes = 180, TemperatureCelsius = 40}
            });
        modelBuilder.Entity<Customer>().HasData(new List<Customer>()
        {
            new Customer(){ CustomerId = 1, FirstName = "Jan", LastName = "Motyl"},
            new Customer(){ CustomerId = 2, FirstName = "Marianna", LastName = "Motyl"},
            new Customer(){ CustomerId = 3, FirstName = "Kamil", LastName = "Woch", PhoneNumber = "123123123"}
        });
        modelBuilder.Entity<AvailableProgram>().HasData(new List<AvailableProgram>()
        {
            new AvailableProgram(){ AvailableProgramId = 1, WashingMachineId = 1, ProgramId = 1, Price = 12},
            new AvailableProgram(){ AvailableProgramId = 2, WashingMachineId = 1, ProgramId = 2, Price = 10},
            new AvailableProgram(){ AvailableProgramId = 3, WashingMachineId = 2, ProgramId = 3, Price = 6}
        });
        modelBuilder.Entity<PurchaseHistory>().HasData(new List<PurchaseHistory>()
        {
            new PurchaseHistory() { AvailableProgramId = 1, CustomerId = 1, PurchaseDate = DateTime.Parse("2025-05-01"), Rating = 5},
            new PurchaseHistory() { AvailableProgramId = 2, CustomerId = 3, PurchaseDate = DateTime.Parse("2025-06-01"), Rating = 5},
            new PurchaseHistory() { AvailableProgramId = 3, CustomerId = 2, PurchaseDate = DateTime.Parse("2025-05-11"), Rating = 5}
        });
    }
}