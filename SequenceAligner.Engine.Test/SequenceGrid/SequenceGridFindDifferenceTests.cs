using NUnit.Framework;
using Ploeh.AutoFixture;
using SequenceAligner.Engine;
using SequenceAligner.Engine.SequenceGrid;

namespace SequenceAligner.Engine.Test.SequenceGrid
{
    [TestFixture]
    public class SequenceGridFindDifferenceTests
    {
        private readonly char[] _seq1 = new[] { 'G', 'A'};
        private readonly char[] _seq2 = new[] { 'G', 'C'};
        private SequenceGridNucleotide _sequenceGridNucleotide;

        [SetUp]
        public void When()
        {
            _sequenceGridNucleotide = new SequenceGridNucleotide(_seq1, _seq2);
        }
       
        [Test]
        public void ThenNewZeroCurrentOneReturnZero()
        {
            var value = _sequenceGridNucleotide.FindDifference(0, 1);
            Assert.AreEqual(0, value);
        }

        [Test]
        public void ThenNewOneCurrentZeroReturnOne()
        {
            var value = _sequenceGridNucleotide.FindDifference(1, 0);
            Assert.AreEqual(1, value);
        }

        [Test]
        public void ThenNewMinusOneCurrentMinusTwoReturnMinusOne()
        {
            var value = _sequenceGridNucleotide.FindDifference(-1, -2);
            Assert.AreEqual(-1, value);
        }

        [Test]
        public void ThenNewOneCurrentFiveReturnFail()
        {
            var value = _sequenceGridNucleotide.FindDifference(1, 5);
            Assert.AreEqual(-1000000, value, "The gap is more then one");
        }
    }
}
