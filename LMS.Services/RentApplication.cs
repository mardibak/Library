﻿using AppFramework.Application;
using LI.ApplicationContracts.Auth;
using LMS.Contracts.Rent;
using LMS.Domain.RentAgg;
using LMS.Domain.Services;
using Microsoft.Extensions.Configuration;

namespace LMS.Services;

public class RentApplication : IRentApplication
{
    private readonly IAuthHelper _authHelper;
    private readonly IConfiguration _configuration;
    private readonly IRentRepository _rentRepository;

    private readonly ILibraryInventoryAcl _libraryInventoryAcl;
    private readonly ILibraryAccountAcl _libraryAccountAcl;

    public RentApplication(IAuthHelper authHelper,
        IConfiguration configuration,
        IRentRepository rentRepository,

        ILibraryInventoryAcl libraryInventoryAcl,
        ILibraryAccountAcl libraryAccountAcl)
    {
        _authHelper = authHelper;
        _configuration = configuration;
        _rentRepository = rentRepository;

        _libraryInventoryAcl = libraryInventoryAcl;
        _libraryAccountAcl = libraryAccountAcl;
    }

    public Guid PlaceRent(Cart cart)
    {
        var currentAccountId = _authHelper.CurrentAccountId();
        var rent = new Rent(currentAccountId, cart.PaymentMethod, cart.TotalAmount, cart.DiscountAmount,
            cart.PayAmount);

        foreach (var cartItem in cart.Items)
        {
            var rentItem = new RentItem(cartItem.Id, cartItem.Count, cartItem.UnitPrice, cartItem.DiscountRate);
            rent.AddItem(rentItem);
        }

        _rentRepository.CreateAsync(rent);
        //_rentRepository.SaveChanges();
        return rent.Id;
    }

    public double GetAmountBy(Guid id)
    {
        return _rentRepository.GetAmountBy(id);
    }

    public async Task Cancel(Guid id)
    {
        var rent = await _rentRepository.GetByIdAsync(id);
        rent.Cancel();
        _rentRepository.SaveChanges();
    }

    public async Task<string> PaymentSucceeded(Guid rentId, long refId)
    {
        var rent = await _rentRepository.GetByIdAsync(rentId);
        rent.PaymentSucceeded(refId);
        var symbol =  _configuration.GetValue<string>("Symbol");
        var issueTrackingNo =  CodeGenerator.Generate(symbol);
        rent.SetIssueTrackingNo(issueTrackingNo);
        if (!_libraryInventoryAcl.DecreaseFromInventory(rent.Items))
            throw new Exception("");

        _rentRepository.SaveChanges();

        var (name, email) = _libraryAccountAcl.GetAccountBy(rent.AccountId);


        return issueTrackingNo;
    }

    public List<RentItemViewModel> GetItems(Guid rentId)
    {
        return _rentRepository.GetItems(rentId);
    }

    public List<RentViewModel> Search(RentSearchModel searchModel)
    {
        return _rentRepository.Search(searchModel);
    }

}