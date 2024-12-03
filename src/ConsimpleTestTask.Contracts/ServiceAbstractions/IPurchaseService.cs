using ConsimpleTestTask.Application.Dto.Dtos;
using ConsimpleTestTask.Domain.Model.ResultItems;

namespace ConsimpleTestTask.Contracts.ServiceAbstractions;

public interface IPurchaseService
{
    Task<DomainResult<IEnumerable<ClientLastPurchaseDto>>> GetRecentBuyersAsync(int days);
}