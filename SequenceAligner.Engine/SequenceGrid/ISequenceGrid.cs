using System.Collections.Generic;

namespace SequenceAligner.Engine.SequenceGrid
{
    public interface ISequenceGrid
    {
        int VerticalMoveValue(int x, int y);
        int HorizontalMoveValue(int x, int y);
        int DiagonalMoveValue(int x, int y);
        void FillMatrix();
        void Initialize();
        IEnumerable<KeyValuePair<string, string>> AlignedSequence();
    }
}