using System.Collections.Generic;
using SequenceAligner.Engine.Enums;
using SequenceAligner.Engine.Grid;

namespace SequenceAligner.Engine.SequenceGrid
{
    public abstract class SequenceGrid : ISequenceGrid
    {
        protected const int GapPenalty = -1;
        protected const int Difference = 1;
        public Grid<int> Grid { get; internal set; }
        protected char[] Sequence1;
        protected char[] Sequence2;
        public List<Move> TracebackPath { get; internal set; }

        protected SequenceGrid(char[] sequence1, char[] sequence2)
        {
            Sequence1 = sequence1;
            Sequence2 = sequence2;
            Grid = new Grid<int>(sequence1.Length + 1, sequence2.Length + 1);
            TracebackPath = new List<Move>();
        }

        public int VerticalMoveValue(int x, int y)
        {
            return Grid.GetValue(x, y - 1);
        }

        public Coordinates VerticalMoveCoordinates(int x, int y)
        {
            return new Coordinates(x, y - 1);
        }

        public int HorizontalMoveValue(int x, int y)
        {
            return Grid.GetValue(x - 1, y);
        }
        public Coordinates HorizontalMoveCoordinates(int x, int y)
        {
            return new Coordinates(x - 1, y);
        }

        public int DiagonalMoveValue(int x, int y)
        {
            return Grid.GetValue(x - 1, y - 1);
        }
        public Coordinates DiagonalMoveCoordinates(int x, int y)
        {
            return new Coordinates(x - 1, y - 1);
        }

        public int OptimalScore
        {
            get { return Grid.GetRightBottomMostCell(); }
        }

        public Coordinates OptimalScoreCoordinates
        {
            get { return Grid.GetRightBottomMostCellCoordinates(); }
        }

        public void ExecuteTraceback()
        {
            Traceback(OptimalScoreCoordinates);
        }

        public IEnumerable<KeyValuePair<string, string>> AlignedSequence()
        {
            var rmIncr = 0;
            var seq1Incr = 0;
            var seq2Incr = 0;
            var resultMatrix = new List<KeyValuePair<string, string>>();
            TracebackPath.Reverse();
            foreach (var tracebackItem in TracebackPath)
            {
                if (tracebackItem == Move.DiagonalMove) // match
                {
                    resultMatrix.Add(new KeyValuePair<string, string>(
                        Sequence1[seq1Incr].ToString(),
                        Sequence2[seq2Incr].ToString()));
                    seq1Incr++;
                    seq2Incr++;
                }
                else if (tracebackItem == Move.VerticalMove)
                {
                    resultMatrix.Add(new KeyValuePair<string, string>(
                        "-", Sequence2[seq2Incr].ToString()));
                    seq2Incr++;
                }
                else
                {
                    resultMatrix.Add(new KeyValuePair<string, string>(
                        Sequence1[seq1Incr].ToString(), "-"));
                    seq1Incr++;
                }

                rmIncr++;
            }
            return resultMatrix;
        }

        public Coordinates Traceback(Coordinates coordinates)
        {
            if (coordinates.X > 0 || coordinates.Y > 0)
            {
                if (coordinates.Y == 0) // must be horizontal as we are on the top row
                {
                    TracebackPath.Add(Move.HorizontalMove);
                    return Traceback(HorizontalMoveCoordinates(coordinates.X, coordinates.Y));
                }
                if (coordinates.X == 0) // must be vertical as we are on left most column
                {
                    TracebackPath.Add(Move.VerticalMove);
                    return Traceback(VerticalMoveCoordinates(coordinates.X, coordinates.Y));
                }
                var verticalValue = VerticalMoveValue(coordinates.X, coordinates.Y);
                var diagonalValue = DiagonalMoveValue(coordinates.X, coordinates.Y);
                var horizontalValue = HorizontalMoveValue(coordinates.X, coordinates.Y);
                var currentValue = Grid.GetValue(coordinates.X, coordinates.Y);

                if (currentValue == diagonalValue)
                {
                    TracebackPath.Add(Move.DiagonalMove);
                    return Traceback(DiagonalMoveCoordinates(coordinates.X, coordinates.Y));
                }

                //get rid of ones that do not differ by one
                verticalValue = FindDifference(verticalValue, currentValue);
                diagonalValue = FindDifference(diagonalValue, currentValue);
                horizontalValue = FindDifference(horizontalValue, currentValue);

                if (diagonalValue >= horizontalValue && diagonalValue >= verticalValue)
                {
                    TracebackPath.Add(Move.DiagonalMove);
                    return Traceback(DiagonalMoveCoordinates(coordinates.X, coordinates.Y));
                }
                if (verticalValue >= horizontalValue && verticalValue >= diagonalValue)
                {
                    TracebackPath.Add(Move.VerticalMove);
                    return Traceback(VerticalMoveCoordinates(coordinates.X, coordinates.Y));
                }
                else
                {
                    TracebackPath.Add(Move.HorizontalMove);
                    return Traceback(HorizontalMoveCoordinates(coordinates.X, coordinates.Y));
                }
            }
            return new Coordinates(0, 0);
        }

        /// <summary>
        /// If is only one difference from current return it otherwise return -1000000
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        public int FindDifference(int newValue, int currentValue)
        {
            return (newValue == currentValue + Difference || newValue == currentValue - Difference)
                                    ? newValue
                                    : -1000000;
        }

        public abstract void FillMatrix();
        public abstract void Initialize();
    }


}