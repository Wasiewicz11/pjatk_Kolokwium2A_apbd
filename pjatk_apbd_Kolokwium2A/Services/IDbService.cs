using pjatk_apbd_Kolokwium2A.Dtos;
using pjatk_apbd_Kolokwium2A.Models;

namespace pjatk_apbd_Kolokwium2A.Services;

public interface IDbService
{
    Task<CustomerDto> GetCustomerById(int customerId);
    
}