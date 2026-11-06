using Enhanzer.Application.Service.PurchaseBill;
using Enhanzer.Core.Dtos.PurchaseBill;
using Microsoft.AspNetCore.Mvc;
using HttpResponse = Enhanzer.Core.Dtos.Response.HttpResponse;

namespace Enhanzer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PurchaseBillController(IPurchaseBillService service): ControllerBase
{
  [HttpPost]
  public async Task<IActionResult> CreatePurchaseBill([FromBody] CreatePurchaseBillRequestDto createPurchaseBillRequestDto)
  {
    return Ok(new HttpResponse
    {
      Data = await service.CreatePurchaseBillAsync(createPurchaseBillRequestDto),
      Success = true,
      Message = "Purchase bill saved successfully."
    });
  }


  [HttpGet]
  public async Task<IActionResult> GetOrders()
  {
    return Ok(new HttpResponse
    {
      Data = await service.FetchPurchaseBills(),
      Success = true,
      Message = "Purchase bills retrieved successfully."
    });
  }
}
