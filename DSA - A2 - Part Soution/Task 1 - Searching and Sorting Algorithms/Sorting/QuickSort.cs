using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class QuickSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            List<Order> orderListCopy = new List<Order>(unsortedOrderList);
            QuickSortRecursive(orderListCopy, 0, orderListCopy.Count - 1);
            return orderListCopy;
        }

        private void QuickSortRecursive(List<Order> orders, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(orders, low, high);
                QuickSortRecursive(orders, low, pivotIndex - 1);
                QuickSortRecursive(orders, pivotIndex + 1, high);
            }
        }

        private int Partition(List<Order> orders, int low, int high)
        {
            Order pivot = orders[low];
            int left = low + 1, right = high;

            while (true)
            {
                while (left <= right && orders[left].ID.CompareTo(pivot.ID) <= 0) left++;
                while (left <= right && orders[right].ID.CompareTo(pivot.ID) > 0) right--;
                if (left > right) break;
                Swap(orders, left, right);
            }

            Swap(orders, low, right);
            return right;
        }

        private void Swap(List<Order> orders, int i, int j)
        {
            Order temp = orders[i];
            orders[i] = orders[j];
            orders[j] = temp;
        }
    }
}
