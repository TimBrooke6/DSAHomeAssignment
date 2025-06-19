using System;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class Heap
    {
        private Order[] orderHeap;
        private int size;

        public Heap(int maxSize)
        {
            orderHeap = new Order[maxSize];
            size = 0;
        }

        public void Insert(Order order)
        {
            if (size >= orderHeap.Length)
                throw new InvalidOperationException("Heap is full.");

            orderHeap[size] = order;
            HeapifyUp(size++);
        }

        public Order Remove()
        {
            if (size == 0)
                throw new InvalidOperationException("Heap is empty.");

            Order root = orderHeap[0];
            orderHeap[0] = orderHeap[--size];
            orderHeap[size] = null;
            HeapifyDown(0);
            return root;
        }

        private void HeapifyUp(int i)
        {
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (orderHeap[i].deliverOn < orderHeap[parent].deliverOn)
                    Swap(i, parent);
                else break;
                i = parent;
            }
        }

        private void HeapifyDown(int i)
        {
            while (i < size)
            {
                int left = 2 * i + 1, right = 2 * i + 2, smallest = i;

                if (left < size && orderHeap[left].deliverOn < orderHeap[smallest].deliverOn)
                    smallest = left;
                if (right < size && orderHeap[right].deliverOn < orderHeap[smallest].deliverOn)
                    smallest = right;

                if (smallest == i) break;

                Swap(i, smallest);
                i = smallest;
            }
        }

        private void Swap(int i, int j)
        {
            var temp = orderHeap[i];
            orderHeap[i] = orderHeap[j];
            orderHeap[j] = temp;
        }
    }
}
