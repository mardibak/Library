﻿using AppFramework.Application;

namespace LMS.Contracts.Loan;

public interface ILoanService
{
    Task<List<LoanDto>> GetAllLoans();
    Task<LoanDto> GetLoanById(Guid id);
    Task<IEnumerable<LoanDto>> GetLoansByMemberId(string memberId);
    Task<IEnumerable<LoanDto>> GetLoansByEmployeeId(string employeeId);
    Task<IEnumerable<LoanDto>> GetOverdueLoans();
    Task<LoanDto> CreateLoan(LoanDto loan);
    Task<OperationResult> UpdateLoan(LoanDto loan);
    Task DeleteLoan(Guid id);
}
