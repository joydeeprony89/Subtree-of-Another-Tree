using System;
using System.Collections.Generic;

namespace Subtree_of_Another_Tree
{
  class Program
  {
    static void Main(string[] args)
    {
      TreeNode root = new TreeNode(3);
      root.left = new TreeNode(4);
      root.right = new TreeNode(5);
      root.left.left = new TreeNode(1);
      root.left.right = new TreeNode(2);
      root.left.right.left = new TreeNode(0);
      root.left.right.right = new TreeNode(8);

            TreeNode subRoot = new TreeNode(2);
      subRoot.left = new TreeNode(0);
      subRoot.right = new TreeNode(8);

      Program p = new Program();
      var answer = p.IsSubtree(root, subRoot);
            Console.WriteLine(answer);
    }
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val)
      {
        this.val = val;
        left = right = null;
      }
    }

    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
      if (root == null) return false;
      if (IsSame(root, subRoot)) return true;
      return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    private bool IsSame(TreeNode root, TreeNode subRoot)
    {
      Queue<(TreeNode, TreeNode)> q = new Queue<(TreeNode, TreeNode)>();
      q.Enqueue((root, subRoot));
      while (q.Count > 0)
      {
        var (node1, node2) = q.Dequeue();
        if (node1 == null && node2 == null) continue;
        if (node1 == null || node2 == null) return false;
        if (node1?.val != node2?.val) return false;
        q.Enqueue((node1.left, node2.left));
        q.Enqueue((node1.right, node2.right));
      }
      return true;
    }
  }
}
