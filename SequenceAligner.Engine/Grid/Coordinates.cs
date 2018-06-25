namespace SequenceAligner.Engine.Grid
{
    public class Coordinates
    {
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; internal set; }
        public int Y { get; internal set; }
    }
}