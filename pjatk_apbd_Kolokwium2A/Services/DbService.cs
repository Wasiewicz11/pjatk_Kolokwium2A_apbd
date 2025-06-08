using Microsoft.EntityFrameworkCore;
using pjatk_apbd_Kolokwium2A.Data;
using pjatk_apbd_Kolokwium2A.Dtos;

namespace pjatk_apbd_Kolokwium2A.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<CustomerDto> GetCustomerById(int customerId)
    {
        var customer = await _context.Customers.FindAsync(customerId);
        if (customer == null)
            throw new Exception("Customer not found");
        
        var customerInfo = await _context.Customers
            .Where(c => c.CustomerId == customerId)
            .Select(c => new CustomerDto()
            {
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                PurchaseHistories = c.PurchaseHistories.Select(ph => new PurchaseHistoryDto()
                {
                    Date = ph.PurchaseDate,
                    Price = ph.AvailableProgram.Price,
                    WashingMachine = new WashingMachineDto()
                    {
                        MaxWeight = ph.AvailableProgram.WashingMachine.MaxWeight,
                        Serial = ph.AvailableProgram.WashingMachine.SerialNumber
                    },
                    Program = new ProgramDto()
                    {
                        Duration = ph.AvailableProgram.Program.DurationMinutes,
                        Name = ph.AvailableProgram.Program.Name
                    }
                }).ToList()
            }).FirstOrDefaultAsync();
        return customerInfo;
    }
}