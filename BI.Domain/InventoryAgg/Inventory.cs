﻿using AppFramework.Domain;

namespace BI.Domain.InventoryAgg
{
    public class Inventory : BaseEntity
    {
        public Guid BookId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; private set; }

        public Inventory(Guid bookId, double unitPrice)
        {
            BookId = bookId;
            UnitPrice = unitPrice;
            InStock = false;
        }
        public void Edit(Guid bookId, double unitPrice)
        {
            BookId = bookId;
            UnitPrice = unitPrice;
        }
        public long CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }
        public void Increase(long count, string operatorId, string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(true, count, operatorId, currentCount, description, 0, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }
        public void Decrease(long count, string operatorId, string description, long lendId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(false, count, operatorId, currentCount, description, lendId, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }

        public void Lend(long count, string operatorId, string description, long lendId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(false, count, operatorId, currentCount, description, lendId, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }
        public void Return(long count, string operatorId, string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(true, count, operatorId, currentCount, description, 0, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }
    }
}