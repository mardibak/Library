﻿using AppFramework.Application;

namespace LibBook.DomainContracts.Borrow;

public interface ILoanService
{
    Task<List<LoanDto>> GetAll();
    Task<List<LoanDto>> GetAllLoans();
    List<LoanDto> GetApprovedLoans();
    List<LoanDto> GetReturnedLoans();
    List<LoanDto> GetDeletedLoans();

    Task<LoanDto> GetLoanById(int borrowId);
    Task<List<LoanDto>> GetBorrowsByMemberId(string memberId);
    Task<List<LoanDto>> GetBorrowsByEmployeeId(string EmployeeId);

    Task<List<LoanDto>> GetOverdueLones();

    OperationResult Update(LoanDto dto);
    Task Delete(int borrowId);
    void SoftDelete(LoanDto entity);

    Task<OperationResult> Lending(LoanDto dto);
    Task<OperationResult> SubmitLend(int borrowId);

    OperationResult Returning(LoanDto dto);
}
