using ConsimpleTestTask.Application.Dto.Dtos;
using ConsimpleTestTask.Domain.Model.ResultItems;

namespace ConsimpleTestTask.Contracts.ServiceAbstractions;

public interface IClientService
{
    Task<DomainResult<IEnumerable<ClientDto>>> GetClientsByBirthDateAsync(int year, int month, int day);

    Task<DomainResult<IEnumerable<CategoryPurchaseDto>>> GetCategoriesWithPurchaseCountAsync(
        int clientId);
}