using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TreeSearch
{
    public enum SidPetal
    {
        Right,Left
    }

    class BinarySearchTree
    {
        public int Data { get; set; } //данные 
        public BinarySearchTree Left { get; set; } //левая ветка 
        public BinarySearchTree Rihgt { get; set; } // правая ветка
        public BinarySearchTree Parent { get; set; } //сам родитель, верхний лепесток

        //в какой ветки лежит узел
        public SidPetal? SideNode(BinarySearchTree node)
        {
            if (node.Parent.Rihgt == node)
                return SidPetal.Right;
            if (node.Parent.Left == node)
                return SidPetal.Left;

            return null;

        }

        //вставляет значение в дерево
        public void Insert(int value)
        {
            if (Data == null || Data == value)
            {
                Data = value;
                return;
            }
            if (Data > value)
            {
                if (Left == null) Left = new BinarySearchTree();
                Insert(value, Left, this);
            }
            else
            {
                if (Rihgt == null) Rihgt = new BinarySearchTree();
                Insert(value, Rihgt, this);
            }
        }

        //Метод для вставки значений, и вставки поддерева 
        public void Insert(int value, BinarySearchTree node, BinarySearchTree parent)
        {
            if (node.Data == null || node.Data == value)
            {
                Data = value;
                return;
            }

            if (node.Data > value)
            {
                if (node.Left == null)
                    node.Left = new BinarySearchTree();
                Insert(value, node.Left, node);
            }
            else
            {
                if(node.Rihgt == null)
                    node.Rihgt = new BinarySearchTree();
                Insert(value, node.Rihgt, node);
            }
        }

        //удаляет узел

        public void RemoveNode(BinarySearchTree node)
        {
            var currentNode = SideNode(node);

            if (node.Left == null && node.Rihgt == null)
            {
                if (currentNode == SidPetal.Left)
                {
                    node.Left = null;
                }

                else
                {
                    node.Rihgt = null;
                }
                return;
            }

            if (node.Left == null)
            {
                if (currentNode == SidPetal.Left)
                {
                    node.Parent.Left = node.Rihgt;
                }
                else
                {
                    node.Parent.Rihgt = node.Rihgt;
                }
                node.Rihgt.Parent = node.Parent;
                return;
            }

            if (node.Rihgt == null)
            {
                if (currentNode == SidPetal.Right)
                {
                    node.Parent.Rihgt = node.Left;
                }
                else
                {
                    node.Parent.Left = node.Left;
                }
                node.Left.Parent = node.Parent;
                return;
            }

            //если есть оба поддерева(правое и левое)
            //то правое ставим не место удаляемого, а левое на место правого

            if (currentNode == SidPetal.Left)
                node.Parent.Left = node.Rihgt;

            if (currentNode == SidPetal.Right)
                node.Parent.Rihgt = node.Rihgt;

        }

        //удаляеть значение элемента
        public void RemoveNode(int value)
        {
            var removeCurrentNode = Find(value);

            if (removeCurrentNode != null)
            {
                RemoveNode(removeCurrentNode);
            }
        }

        //поиск значения
        public BinarySearchTree Find(int value)
        {
            if (Data == value)
                return this;

            if (Data > value)
                return Find(value, Left);

            return Find(value, Rihgt);

        }

        public BinarySearchTree Find(int value, BinarySearchTree node)
        {
            if (node == null)
                return null;

            if (node.Data == value)
                return node;

            if (node.Data > value)
            {
                return Find(value, Rihgt);
            }

            return Find(value, node.Rihgt);
        } 
     

        


    }
}
