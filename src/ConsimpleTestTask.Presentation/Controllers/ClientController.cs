using System.Net;
using ConsimpleTestTask.Application.Dto.Dtos;
using ConsimpleTestTask.Contracts.ServiceAbstractions;
using ConsimpleTestTask.Domain.Model.ResultItems;
using ConsimpleTestTask.Domain.Model.ResultItems.Extensions;
using ConsimpleTestTask.Presentation.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace ConsimpleTestTask.Presentation.Controllers;

public class ClientController(IClientService clientService) : BaseController
{
    /// <summary>
    /// List of birthdays by the specified date
    /// </summary>
    /// <param name="year">Birth year</param>
    /// <param name="month">Birth month</param>
    /// <param name="day">Birth day</param>
    /// <returns>Returns a list of birthdays by the specified date</returns>
    /// <response code="200">Successful receive customers by the specified date of birth</response>
    /// <response code="400">An error while trying to format a date or unknown error when trying to retrieve users by a given date of birth</response>
    [HttpGet("birthdayList")] // /api/client/birthdayList?year={year}&month={month}&day={day}
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> BirthdayList(int year = 2004, int month = 1, int day = 21)
    {
        DomainResult<IEnumerable<ClientDto>> getClientsResult =
            await clientService.GetClientsByBirthDateAsync(year, month, day);

        return getClientsResult.Match<IEnumerable<ClientDto>, IActionResult>(
            onSuccess: () => Ok(getClientsResult.Value),
            onError: BadRequest);
    }

    /// <summary>
    /// List of categories purchased by the respective customer and the number of products in the respective category
    /// </summary>
    /// <param name="userId">Client id</param>
    /// <returns>Returns a list of categories that the corresponding customer has purchased and the number of products in the corresponding category</returns>
    /// <response code="200">Successfully received a list of categories and quantity of goods</response>
    /// <response code="400">User with Id not found</response>
    [HttpGet("categoriesWithPurchaseCount/{userId}")]
    [Produces("application/json")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult>
        ClientCategoriesWithPurchaseCount(int userId) // /api/client/categoriesWithPurchaseCount
    {
        DomainResult<IEnumerable<CategoryPurchaseDto>> result =
            await clientService.GetCategoriesWithPurchaseCountAsync(userId);

        return result.Match<IEnumerable<CategoryPurchaseDto>, IActionResult>(
            onSuccess: () => Ok(result.Value),
            onError: NotFound);
    }
}