using System;

namespace SequenceAligner.Engine.SequenceGrid
{
    public class SequenceGridNucleotide : SequenceGrid
    {
        //private Func<int> _InitIncrement = () => 0;
        
        public SequenceGridNucleotide(char[] sequence1, char[] sequence2)
            : base(sequence1, sequence2)
        {
        }
        
        public override void FillMatrix()
        {
            for (int y = 1; y < Grid.GetLengths().Y; y++)
            {
                for (int x = 1; x < Grid.GetLengths().X; x++)
                {
                    var vertical = VerticalMoveValue(x, y) + GapPenalty;
                    var dmv = DiagonalMoveValue(x, y);
                    var match = Sequence1[x - 1] == Sequence2[y - 1] ? 1 : 0;
                    var diagonal = dmv + match;
                    var horizontal = HorizontalMoveValue(x, y) + GapPenalty;
                    
                    Grid.SetValue(x, y, Math.Max(vertical, Math.Max(diagonal, horizontal)));
                }
            }
        }
        
        public override void Initialize()
        {
            Grid.SetValue(0, 0, 0);
            for (int i = 1; i < Grid.GetLengths().X; i++)
            {
                Grid.SetValue(i, 0, -(i));
            }
            for (int i = 1; i < Grid.GetLengths().Y; i++)
            {
                Grid.SetValue(0, i, -(i));
            }
        }
    }
}
