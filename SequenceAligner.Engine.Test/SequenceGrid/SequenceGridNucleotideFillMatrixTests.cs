using NUnit.Framework;
using Ploeh.AutoFixture;
using SequenceAligner.Engine;
using SequenceAligner.Engine.SequenceGrid;

namespace SequenceAligner.Engine.Test.SequenceGrid
{
    [TestFixture]
    public class SequenceGridNucleotideFillMatrixTests
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
        public void ThenOneOneEqualsOne()
        {
            var value = _sequenceGridNucleotide.Grid.GetValue(1, 1);
            Assert.AreEqual(1, value);
        }

        [Test]
        public void ThenOneTwoEqualsZero()
        {
            var value = _sequenceGridNucleotide.Grid.GetValue(1, 2);
            Assert.AreEqual(0, value);
        }

        [Test]
        public void ThenTwoOneEqualsZero()
        {
            var value = _sequenceGridNucleotide.Grid.GetValue(2, 1);
            Assert.AreEqual(0, value);
        }

        [Test]
        public void ThenTwoTwoEqualsOne()
        {
            var value = _sequenceGridNucleotide.Grid.GetValue(2, 2);
            Assert.AreEqual(1, value);
        }
    }
}
