using NUnit.Framework;
using Ploeh.AutoFixture;
using SequenceAligner.Engine;
using SequenceAligner.Engine.SequenceGrid;

namespace SequenceAligner.Engine.Test.SequenceGrid
{
    [TestFixture]
    public class SequenceGridNucleotideInitializeTests //: AutoSpecFor<Grid<int>>
    {
        private readonly char[] _seq1 = new[] { 'G', 'A', 'C', 'T', 'A', 'C' };
        private readonly char[] _seq2 = new[] { 'G', 'A', 'C', 'T', 'A', 'C' };
        private SequenceGridNucleotide _sequenceGridNucleotide;

        [SetUp]
        public void When()
        {
            _sequenceGridNucleotide = new SequenceGridNucleotide(_seq1, _seq2);
            _sequenceGridNucleotide.Initialize();
        }

        [Test]
        public void ThenCorrectCount()
        {
            var coordinates = _sequenceGridNucleotide.Grid.GetLengths();
            Assert.AreEqual(_seq1.Length + 1, coordinates.X);
            Assert.AreEqual(_seq2.Length + 1, coordinates.Y);
        }

        [Test]
        public void ThenZeroZeroPositionIs0()
        {
            var zeroValue = _sequenceGridNucleotide.Grid.GetValue(0, 0);
            Assert.AreEqual(0, zeroValue);
        }

        [Test]
        public void ThenOneOnXIsMinus1()
        {
            var value = _sequenceGridNucleotide.Grid.GetValue(0, 1);
            Assert.AreEqual(-1, value);
        }
        
    }
}
