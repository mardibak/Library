﻿using LMS.Domain.RentAgg;

namespace LMS.Domain.Services;

public interface ILibraryInventoryAcl
{
    bool ReduceFromInventory(List<RentItem> items);
}