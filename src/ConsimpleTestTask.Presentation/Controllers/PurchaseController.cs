using System.Net;
using ConsimpleTestTask.Application.Dto.Dtos;
using ConsimpleTestTask.Contracts.ServiceAbstractions;
using ConsimpleTestTask.Domain.Model.ResultItems;
using ConsimpleTestTask.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace ConsimpleTestTask.Presentation.Controllers;

public class PurchaseController(IPurchaseService purchaseService) : BaseController
{
    /// <summary>
    /// Returns a list of customers who have purchased in the last N days. For each customer, print the date of their last purchase.
    /// </summary>
    /// <param name="days">Days</param>
    /// <returns></returns>
    [HttpGet("lastBuyers")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> LastBuyers(int days) // /api/purchase/lastBuyers?days={days}
    {
        DomainResult<IEnumerable<ClientLastPurchaseDto>> clientsResult =
            await purchaseService.GetRecentBuyersAsync(days);

        return Ok(clientsResult.Value);
    }
}