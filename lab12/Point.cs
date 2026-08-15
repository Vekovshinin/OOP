using System;

namespace lab12
{
    [Serializable]
    public class Point<T> where T : IComparable<T>
    {
        private T data;
        private Point<T> right;
        private Point<T> left;

        public T Data { get; set; }
        public Point<T> Right { get; set; }
        public Point<T> Left { get; set; }
        public Point()
        {
            Data = default(T);
            Left = null;
            Right = null;
        }
        public Point(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }
}
