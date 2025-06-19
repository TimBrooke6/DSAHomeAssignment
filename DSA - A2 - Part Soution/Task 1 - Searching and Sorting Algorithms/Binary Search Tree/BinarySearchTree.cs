using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class BinarySearchTree
    {
        public TreeNode Root { get; private set; }

        public void Build(List<Order> Orders)
        {
            if (Orders == null || Orders.Count == 0) return;

            Root = new TreeNode(Orders[0]);
            for (int i = 1; i < Orders.Count; i++)
                Insert(Root, Orders[i]);
        }

        private void Insert(TreeNode node, Order order)
        {
            if (order.ID.CompareTo(node.order.ID) < 0)
                if (node.Left == null) node.Left = new TreeNode(order);
                else Insert(node.Left, order);
            else
                if (node.Right == null) node.Right = new TreeNode(order);
            else Insert(node.Right, order);
        }

        public Order Get(Guid orderID)
        {
            TreeNode node = Search(Root, orderID);
            if (node == null) return null;

            return node.order;
        }

        private TreeNode Search(TreeNode node, Guid orderID)
        {
            if (node == null) return null;

            int cmp = orderID.CompareTo(node.order.ID);
            if (cmp == 0) return node;
            if (cmp < 0) return Search(node.Left, orderID);
            return Search(node.Right, orderID);
        }
    }
}
