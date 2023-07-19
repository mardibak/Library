﻿using AppFramework.Domain;
using AppFramework.Application;

namespace LMS.Domain.LendAgg;

public class Lend : BaseEntity
{
    public string MemberID { get; set; }
    public string EmployeeId { get; set; }
    public string LendDate { get; set; }
    public DateTime IdealReturnDate { get; set; }
    public string ReturnEmployeeID { get; set; }
    public string ReturnDate { get; set; }
    public string Description { get; set; }
    public List<LendItem> Items { get; set; }


    public Lend(string memberID, string employeeId, string lendDate, string idealReturnDate, string returnEmployeeID, string returnDate, string description)
    {
        MemberID = memberID;
        EmployeeId = employeeId;
        LendDate = lendDate;
        IdealReturnDate = idealReturnDate.ToGeorgianDateTime();
        ReturnEmployeeID = returnEmployeeID;
        ReturnDate = returnDate;
        Description = description;
        Items = new List<LendItem>();
    }
    public void Edit(string memberID, string employeeId, string lendDate, string idealReturnDate, string returnEmployeeID, string returnDate, string description)
    {
        MemberID = memberID;
        EmployeeId = employeeId;
        LendDate = lendDate;
        IdealReturnDate = idealReturnDate.ToGeorgianDateTime();
        ReturnEmployeeID = returnEmployeeID;
        ReturnDate = returnDate;
        Description = description;
        Items = new List<LendItem>();
    }
    public void AddItem(LendItem item)
    {
        Items.Add(item);
    }
}
