using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class MergeSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            List<Order> orderListCopy = new List<Order>(unsortedOrderList);
            return MergeSortRecursive(orderListCopy);
        }

        private List<Order> MergeSortRecursive(List<Order> orders)
        {
            if (orders.Count <= 1) return orders;

            int mid = orders.Count / 2;
            var left = MergeSortRecursive(orders.GetRange(0, mid));
            var right = MergeSortRecursive(orders.GetRange(mid, orders.Count - mid));

            return Merge(left, right);
        }

        private List<Order> Merge(List<Order> left, List<Order> right)
        {
            List<Order> result = new();
            int i = 0, j = 0;

            while (i < left.Count && j < right.Count)
            {
                if (left[i].placedOn > right[j].placedOn)
                    result.Add(left[i++]);
                else
                    result.Add(right[j++]);
            }

            while (i < left.Count) result.Add(left[i++]);
            while (j < right.Count) result.Add(right[j++]);

            return result;
        }
    }
}
