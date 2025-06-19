using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class CustomSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            return new List<Order>(unsortedOrderList.OrderByDescending(o => o.deliverOn));
        }
    }
}
