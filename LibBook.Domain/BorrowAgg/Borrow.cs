﻿using AppFramework.Domain;
using System.Diagnostics.CodeAnalysis;

namespace LibBook.Domain.BorrowAgg;

public class Borrow : BaseEntity
{
    public int BookId { get; set; }
    public Guid MemberID { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime IdealReturnDate { get; set; }

    public string? ReturnEmployeeID { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string? Description { get; set; }

    public bool IsApproved { get; set; }
    public bool IsReturned { get; set; }


    public Borrow(int bookId, Guid memberID, Guid employeeId, DateTime idealReturnDate, string? returnEmployeeID, DateTime? returnDate, string? description)
    {
        BookId = bookId;
        MemberID = memberID;
        EmployeeId = employeeId;
        IdealReturnDate = idealReturnDate;
        ReturnEmployeeID = returnEmployeeID;
        ReturnDate = returnDate;
        Description = description;
        IsApproved = false; 
        IsReturned = false;
    }
    public void Edit(int bookId, Guid memberID, Guid employeeId, DateTime idealReturnDate, string? returnEmployeeID, DateTime? returnDate, string? description)
    {
        BookId = bookId;
        MemberID = memberID;
        EmployeeId = employeeId;
        IdealReturnDate = idealReturnDate;
        ReturnEmployeeID = returnEmployeeID;
        ReturnDate = returnDate;
        Description = description;
    }
}
