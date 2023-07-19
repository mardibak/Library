﻿using AppFramework.Domain;
using AppFramework.Application;

namespace LMS.Domain.LendAgg;

public class Borrow : BaseEntity
{
    public Guid BookId { get; set; }
    public string MemberID { get; set; }
    public string EmployeeId { get; set; }
    public string LendDate { get; set; }
    public DateTime IdealReturnDate { get; set; }
    public string ReturnEmployeeID { get; set; }
    public string ReturnDate { get; set; }
    public string Description { get; set; }


    public Borrow(Guid bookId,string memberID, string employeeId, string lendDate, string idealReturnDate, string returnEmployeeID, string returnDate, string description)
    {
        BookId = bookId;
        MemberID = memberID;
        EmployeeId = employeeId;
        LendDate = lendDate;
        IdealReturnDate = idealReturnDate.ToGeorgianDateTime();
        ReturnEmployeeID = returnEmployeeID;
        ReturnDate = returnDate;
        Description = description;
    }
    public void Edit(Guid bookId,string memberID, string employeeId, string lendDate, string idealReturnDate, string returnEmployeeID, string returnDate, string description)
    {
        BookId = bookId;
        MemberID = memberID;
        EmployeeId = employeeId;
        LendDate = lendDate;
        IdealReturnDate = idealReturnDate.ToGeorgianDateTime();
        ReturnEmployeeID = returnEmployeeID;
        ReturnDate = returnDate;
        Description = description;
    }
}
