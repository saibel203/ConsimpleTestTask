using ConsimpleTestTask.Application.Dto.Dtos;
using ConsimpleTestTask.Contracts.RepositoryAbstractions.Base;
using ConsimpleTestTask.Contracts.ServiceAbstractions;
using ConsimpleTestTask.Domain.Model.Entities;
using ConsimpleTestTask.Domain.Model.ResultItems;
using ConsimpleTestTask.Domain.Model.ResultItems.ErrorsDocumentations;
using MapsterMapper;

namespace ConsimpleTestTask.Services.Services;

public class ClientService(IUnitOfWork unitOfWork, IMapper mapper) : IClientService
{
    public async Task<DomainResult<IEnumerable<ClientDto>>> GetClientsByBirthDateAsync(
        int year, int month, int day)
    {
        string validationDateTime = $"{year}-{month}-{day}";

        if (!DateTime.TryParse(validationDateTime, out DateTime resultDateTime))
            return DomainResult<IEnumerable<ClientDto>>.Failure(ClientErrors.BirthDateFormatingError);

        IEnumerable<Client> users = await unitOfWork.GetRepository<Client>()
            .FindListAsync(e => e.BirthDate == resultDateTime);

        IEnumerable<ClientDto> result = mapper.Map<IEnumerable<ClientDto>>(users);

        return DomainResult<IEnumerable<ClientDto>>.Success(result);
    }

    public async Task<DomainResult<IEnumerable<CategoryPurchaseDto>>> GetCategoriesWithPurchaseCountAsync(
        int clientId)
    {
        IEnumerable<int> usersIds = (await unitOfWork.GetRepository<Client>().GetAll()).Select(u => u.Id);

        if (!usersIds.Contains(clientId))
            return DomainResult<IEnumerable<CategoryPurchaseDto>>.Failure(ClientErrors.NonExistingUserError);

        IEnumerable<PurchaseItem> purchaseItems = await unitOfWork.PurchaseItemRepository
            .GetPurchaseItemsByClientId(clientId);

        IEnumerable<CategoryPurchaseDto> categoryPurchaseCounts = purchaseItems
            .GroupBy(pi => pi.Product.CategoryId)
            .Select(group => new CategoryPurchaseDto
            {
                CategoryId = group.Key,
                UserName = $"{group.First().Purchase.Client.LastName} {group.First().Purchase.Client.FirstName} {group.First().Purchase.Client.FatherName}",
                CategoryName = group.First().Product.ProductCategory.Name,
                TotalUnitsPurchased = group.Sum(pi => pi.Quantity)
            })
            .ToList();

        return DomainResult<IEnumerable<CategoryPurchaseDto>>.Success(categoryPurchaseCounts);
    }
}