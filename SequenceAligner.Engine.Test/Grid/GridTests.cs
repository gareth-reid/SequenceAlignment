using NUnit.Framework;
using Ploeh.AutoFixture;
using SequenceAligner.Engine.Grid;

namespace SequenceAligner.Engine.Test.Grid
{
    [TestFixture]
    public class GridTests //: AutoSpecFor<Grid<int>>
    {
        private readonly Fixture _fixture = new Fixture();
        private int _value = 0; 
        private Grid<int> _grid;
        [SetUp]
        public void When()
        {
            _value = _fixture.Create<int>();
            _grid = new Grid<int>(10, 20);
            _grid.SetValue(5, 5, _value);
            _grid.SetValue(9, 19, _value);
        }

        [Test]
        public void ThenGetCorrectValue()
        {
            Assert.AreEqual(_value, _grid.GetValue(5, 5));
        }
        [Test]
        public void ThenGetRightBottomMostCell()
        {
            Assert.AreEqual(_value, _grid.GetRightBottomMostCell());
        }

        [Test]
        public void ThenGetLeftBottomMostCellCoordinates()
        {
            var coordinates = _grid.GetRightBottomMostCellCoordinates();
            Assert.AreEqual(9, coordinates.X);
            Assert.AreEqual(19, coordinates.Y);
        }

        [Test]
        public void ThenGetLengths()
        {
            var coordinates = _grid.GetLengths();
            Assert.AreEqual(10, coordinates.X);
            Assert.AreEqual(20, coordinates.Y);
        }

        
    }
}
