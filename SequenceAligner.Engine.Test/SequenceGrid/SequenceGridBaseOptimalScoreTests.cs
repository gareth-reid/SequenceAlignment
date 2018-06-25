using NUnit.Framework;
using Ploeh.AutoFixture;
using SequenceAligner.Engine;
using SequenceAligner.Engine.SequenceGrid;

namespace SequenceAligner.Engine.Test.SequenceGrid
{
    [TestFixture]
    public class SequenceGridBaseOptimalScoreTests
    {
        private readonly char[] _seq1 = new[] { 'G', 'A'};
        private readonly char[] _seq2 = new[] { 'G', 'C'};
        private SequenceGridNucleotide _sequenceGridNucleotide;

        //1,0
        //0,1
        [SetUp]
        public void When()
        {
            _sequenceGridNucleotide = new SequenceGridNucleotide(_seq1, _seq2);
            _sequenceGridNucleotide.Initialize();
            _sequenceGridNucleotide.FillMatrix();
        }

        [Test]
        public void ThenOptimalScoreFromPostionTwoTwo()
        {
            var value = _sequenceGridNucleotide.OptimalScore;
            Assert.AreEqual(1, value);
        }

        [Test]
        public void ThenOptimalScoreCoordinatesFromPostionTwoTwo()
        {
            var coordinates = _sequenceGridNucleotide.OptimalScoreCoordinates;
            Assert.AreEqual(2, coordinates.X);
            Assert.AreEqual(2, coordinates.Y);
        }
    }
}
