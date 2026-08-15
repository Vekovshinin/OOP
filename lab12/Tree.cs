using System;
using System.Collections;
using System.Collections.Generic;

namespace lab12
{
    [Serializable]
    public class Tree<T> : IEnumerable<T>, ICollection<T> where T : IComparable<T>, ICloneable
    {
        private Point<T> root;
        private int count;
        public int Count => count;

        public bool IsReadOnly => false;
        public Point<T> Root { get { return root; } }
        public Tree()
        {
            root = null;
        }
        public Tree(Tree<T> tr)
        {
            if (tr != null && tr.root != null)
            {
                this.root = Clone(tr.root);
            }
        }

        public void AddPoint(T data)
        {
            Point<T> newPoint = new Point<T>(data);
            if (root == null)
            {
                root = newPoint;
                count++;
                return;
            }

            Point<T> curr = root;
            Point<T> parent = null;

            while (curr != null)
            {
                parent = curr;
                if (Comparer<T>.Default.Compare(data, curr.Data) < 0)
                {
                    curr = curr.Left;
                }
                else if (Comparer<T>.Default.Compare(data, curr.Data) > 0)
                {
                    curr = curr.Right;
                }
                else
                {
                    return;
                }
            }

            if (Comparer<T>.Default.Compare(data, parent.Data) < 0)
            {
                parent.Left = newPoint;
            }
            else
            {
                parent.Right = newPoint;
            }
            count++;
        }
        public void RemovePoint(T data)
        {
            if (root == null) { return; }
            Point<T> curr = root;
            Point<T> parent = null;
            while (curr != null)
            {
                if (Comparer<T>.Default.Compare(data,curr.Data) == 0)
                {
                    break;
                }
                parent = curr;
                if (Comparer<T>.Default.Compare(data, curr.Data) < 0)
                {
                    curr = curr.Left;
                }
                if (Comparer<T>.Default.Compare(data, curr.Data) > 0)
                {
                    curr = curr.Right;
                }
            }
            if (curr == null) { return; }
            if (curr.Right == null && curr.Left == null)
            {
                if (parent !=  null)
                {
                    if (parent.Left == curr)
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                }
                else
                {
                    root = null;
                }
            }
            else if (curr.Right != null && curr.Left == null)
            {
                if (parent != null)
                {
                    if (parent.Left == curr)
                    {
                        parent.Left = curr.Right;
                    }
                    else
                    {
                        parent.Right = curr.Right;
                    }
                }
                else
                {
                    root = parent.Right;
                }
                curr.Right = null;
            }
            else if (curr.Right == null && curr.Left != null)
            {
                if (parent != null)
                {
                    if (parent.Left == curr)
                    {
                        parent.Left = curr.Left;
                    }
                    else
                    {
                        parent.Right = curr.Left;
                    }
                }
                else
                {
                    root = curr.Left;
                }
                curr.Left = null;
            }
            else
            {
                Point<T> succ = FindSuccessor(curr);
                T succData = succ.Data;
                RemovePoint(succData);
                curr.Data = succData;
            }
            count--;
        }

        private Point<T> FindSuccessor(Point<T> point)
        {
            Point<T> curr = point.Right;
            while (curr.Left != null)
            {
                curr = curr.Left;
            }
            return curr;
        }
        public Point<T> Search(T data)
        {
            Point<T> curr = root;
            while (curr != null)
            {
                if (Comparer<T>.Default.Compare(data, curr.Data) == 0)
                {
                    return curr;
                }
                else if (Comparer<T>.Default.Compare(data,curr.Data) < 0)
                {
                    curr = curr.Left;
                }
                else
                {
                    curr = curr.Right;
                }
            }
            return null;
        }
        public void PrintTree()
        {
            if (root == null)
            {
                Console.WriteLine("Дерево пустое!");
                return;
            }
            PrintTree(root, 0);
            
        }
        private void PrintTree(Point<T> point, int depth)
        {
            if (point == null)
            {
                return;
            }

            PrintTree(point.Right, depth + 1);

            Console.WriteLine($"{new string(' ', depth * 4)}-> {point.Data}");

            PrintTree(point.Left, depth + 1);
        }

        private Point<T> Clone(Point<T> point)
        {
            if (point == null)
            {
                return null;
            }

            T clonedData = (T)point.Data.Clone();

            Point<T> newPoint = new Point<T>(clonedData);

            newPoint.Left = Clone(point.Left);
            newPoint.Right = Clone(point.Right);

            return newPoint;
        }

        public Tree<T> ShallowCopy()
        {
            return (Tree<T>)this.MemberwiseClone();
        }
        public virtual T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException("Индекс находится вне диапазона.");

                int currentIndex = 0;
                foreach (var item in InOrder(root))
                {
                    if (currentIndex == index)
                        return item;
                    currentIndex++;
                }

                throw new InvalidOperationException("Не удалось получить элемент по индексу.");
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException("Индекс находится вне диапазона.");

                Remove(this[index]);
                Add(value);
            }
        }

        public void DeleteTree()
        {
            Clear(root);
            root = null;
            count = 0;
        }
        private void Clear(Point<T> point)
        {
            if (point == null)
            {
                return;
            }
            Clear(point.Left);
            Clear(point.Right);
            point.Left = null;
            point.Right = null;
        }


        public virtual void Add(T item)
        {
            AddPoint(item);
        }

        public void Clear()
        {
            DeleteTree();
        }

        public bool Contains(T item)
        {
            return Search(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach(var  item in this)
            {
                array[arrayIndex++] = item;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrder(root).GetEnumerator();
        }

        public virtual bool Remove(T item)
        {
            if (Contains(item))
            {
                RemovePoint(item);
                return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<T> InOrder(Point<T> point)
        {
            if (point != null)
            {
                foreach(T data in InOrder(point.Left))
                    yield return data;
                yield return point.Data;
                foreach(T data in InOrder(point.Right))
                    yield return data;
            }
        }
    }
}
