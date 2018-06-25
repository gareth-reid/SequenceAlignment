namespace SequenceAligner.Engine.Grid
{
    public class Grid<T>// : IEnumerable<int[]>
    {
        private T[,] _Grid;
        private int _XLength;
        private int _YLength;
        public Grid(int x, int y)
        {
            _XLength = x;
            _YLength = y;
            _Grid = new T[x, y];
        }

        public void SetValue(int x, int y, T value)
        {
            _Grid[x, y] = value;
        }
        public T GetValue(int x, int y)
        {
            return _Grid[x, y];
        }

        public T GetRightBottomMostCell()
        {
            return _Grid[_XLength - 1, _YLength - 1];
        }

        public Coordinates GetRightBottomMostCellCoordinates()
        {
            return new Coordinates(_XLength - 1, _YLength - 1);
        }

        public Coordinates GetLengths()
        {
            return new Coordinates(_XLength, _YLength);
        }
    }

    //public class GridEnum<T> : IEnumerator
    //{
    //    public T[,] _Grid;
    //    int x = -1;
    //    int x = -1;

    //    public GridEnum(T[,] list)
    //    {
    //        _Grid = list;
    //    }

    //    public bool MoveNext()
    //    {
    //        position++;
    //        return (position < _Grid.Length);
    //    }

    //    public void Reset()
    //    {
    //        position = -1;
    //    }

    //    object IEnumerator.Current
    //    {
    //        get
    //        {
    //            return Current;
    //        }
    //    }

    //    public T Current
    //    {
    //        get
    //        {
    //            try
    //            {
    //                return _Grid[position];
    //            }
    //            catch (IndexOutOfRangeException)
    //            {
    //                throw new InvalidOperationException();
    //            }
    //        }
    //    }
    //}
}