﻿namespace Warehouse.Application.DTOs;

public class InventoryOperationViewModel
{
    public long Id { get; set; }
    public bool Operation { get; set; }
    public long Count { get; set; }
    public Guid OperatorId { get; set; }
    public string Operator { get; set; }
    public string OperationDate { get; set; }
    public long CurrentCount { get; set; }
    public string Description { get; set; }
    public long LendId { get; set; }
    public int InventoryId { get; set; }
}
