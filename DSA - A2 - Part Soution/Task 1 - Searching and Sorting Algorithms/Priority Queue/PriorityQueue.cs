using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class PriorityQueue
    {
        private Heap priorityQueue;

        private void Build(List<Order> orders)
        {
            priorityQueue = new Heap(orders.Count);
            foreach (var order in orders)
                priorityQueue.Insert(order);
        }

        public List<Order> GetMostUrgentOrders(List<Order> orders)
        {
            Build(orders);

            List<Order> urgentOrders = new();
            for (int i = 0; i < 5 && i < orders.Count; i++)
                urgentOrders.Add(priorityQueue.Remove());

            return urgentOrders.OrderBy(o => o.deliverOn).ToList();
        }
    }
}
