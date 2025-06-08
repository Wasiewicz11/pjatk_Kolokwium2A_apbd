using Microsoft.AspNetCore.Mvc;
using pjatk_apbd_Kolokwium2A.Services;

namespace pjatk_apbd_Kolokwium2A.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IDbService _dbService;

    public CustomersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{customerId}/purchases")]
    public async Task<IActionResult> GetPurchases(int customerId)
    {
        try
        {
            var customerInfo = await _dbService.GetCustomerById(customerId);
            return Ok(customerInfo);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
        
    }
}