using ConsimpleTestTask.Application.Dto.Dtos;
using ConsimpleTestTask.Contracts.RepositoryAbstractions.Base;
using ConsimpleTestTask.Contracts.ServiceAbstractions;
using ConsimpleTestTask.Domain.Model.Entities;
using ConsimpleTestTask.Domain.Model.ResultItems;

namespace ConsimpleTestTask.Services.Services;

public class PurchaseService(IUnitOfWork unitOfWork) : IPurchaseService
{
    public async Task<DomainResult<IEnumerable<ClientLastPurchaseDto>>> GetRecentBuyersAsync(int days)
    {
        IEnumerable<Purchase> purchases = await unitOfWork.PurchaseRepository.GetRecentPurchases(days);

        IEnumerable<ClientLastPurchaseDto> recentBuyers = purchases
            .GroupBy(purchase => new { purchase.ClientId })
            .Select(group => new ClientLastPurchaseDto
            {
                ClientId = group.Key.ClientId,
                FullName =
                    $"{group.FirstOrDefault()?.Client.LastName!} {group.FirstOrDefault()?.Client.FirstName!} {group.FirstOrDefault()?.Client.FatherName!}",
                LastPurchaseDate = group.Max(p => p.Date).ToShortDateString()
            })
            .ToList();

        return DomainResult<IEnumerable<ClientLastPurchaseDto>>.Success(recentBuyers);
    }
}