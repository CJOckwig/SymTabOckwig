using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymTabOckwig
{
    internal class BST
    {
        public BST()
        {
            Root = null;
        }
        public Node Root { get; set; }

        public bool AddNode(String symbol, int value, bool rFlag)
        {
          
            Node leaf = this.Root;
            Node TargetNode = leaf;
            while (leaf != null)
            {
                TargetNode = leaf;
                if(string.Compare(leaf.Symbol,symbol) > 0)
                {
                    leaf = leaf.Left;
                }
                else if(string.Compare(leaf.Symbol, symbol) < 0)
                {
                    leaf = leaf.Right;
                }
                else
                {
                    //this would mean that the symbol is the same
                    //set MFlag to true and exit with false
                    leaf.MFlag = true;
                    return false;
                }
            }

            Node newNode = new Node(symbol, rFlag,value);

            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                if (string.Compare(TargetNode.Symbol, symbol) > 0)
                {
                    TargetNode.Left = newNode;
                }
                else if (string.Compare(TargetNode.Symbol, symbol) < 0)
                {
                    TargetNode.Right = newNode;
                }
            }
            return true;
        }
       
        public static void LeftTraverse(Node root)
        {
            if(root!=null)
            {
                LeftTraverse(root.Left);
                root.ToString();
                LeftTraverse(root.Right);
            }
        }


    }
}
