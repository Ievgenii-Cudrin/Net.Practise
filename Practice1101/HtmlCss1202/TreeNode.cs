using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice1101
{
    // definition of TreeNode<T>:
    public class TreeNode<T>
    {
        public T Data { get; }

        public List<TreeNode<T>> Child { get; set; }

        public TreeNode(T data)
        {
            this.Data = data;
            this.Child = new List<TreeNode<T>>();
        }

    }

    public static class Steps
    {
        static TreeNode<int> tree = new TreeNode<int>(0)
        {
            Child = new List<TreeNode<int>>
            {
                new TreeNode<int>(10)
                {
                    Child = new List<TreeNode<int>>
                    {
                        new TreeNode<int>(11),
                        new TreeNode<int>(12)
                    }
                },
                new TreeNode<int>(20)
                {
                    Child = new List<TreeNode<int>>
                    {
                        new TreeNode<int>(21),
                        new TreeNode<int>(22)
                    }
                },
                new TreeNode<int>(30)
                {
                    Child = new List<TreeNode<int>>
                    {
                        new TreeNode<int>(31)
                    }
                }
            }
        };

        // Depth
        public static IEnumerable<TreeNode<int>> DepthFirstTraversal()
        {
            yield return tree;
            foreach (var firstNode in tree.Child)
            {
                yield return firstNode;
                foreach (var secondNode in firstNode.Child)
                {
                    yield return secondNode;
                    foreach (var thirdNode in secondNode.Child)
                    {
                        yield return thirdNode;
                    }
                }
            }
        }

        //Breath
        public static IEnumerable<TreeNode<int>> BreadthFirstTraversal()
        {
            yield return tree;
            foreach (var firstNode in tree.Child)
            {
                yield return firstNode;
            }
            foreach (var firstNode in tree.Child)
            {
                foreach (var secondNode in firstNode.Child)
                {
                    yield return secondNode;
                    foreach (var thirdNode in secondNode.Child)
                    {
                        yield return thirdNode;
                    }
                }
            }
        }
    }

    public static class Show
    {
        public static void ShowDFT(IEnumerable<TreeNode<int>> nodes)
        {
            Console.WriteLine("DFT:");
            foreach (TreeNode<int> node in nodes)
            {
                Console.WriteLine(node.Data);
            }
        }

        public static void ShowBFT(IEnumerable<TreeNode<int>> nodes)
        {
            Console.WriteLine("{0}BFT:", Environment.NewLine);
            foreach (TreeNode<int> node in nodes)
            {
                Console.WriteLine(node.Data);
            }
        }
    }
}
    

    
    
