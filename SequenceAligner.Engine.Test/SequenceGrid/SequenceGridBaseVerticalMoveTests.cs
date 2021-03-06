﻿using NUnit.Framework;
using Ploeh.AutoFixture;
using SequenceAligner.Engine;
using SequenceAligner.Engine.SequenceGrid;

namespace SequenceAligner.Engine.Test.SequenceGrid
{
    [TestFixture]
    public class SequenceGridBaseVerticalMoveTests
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
        public void ThenUpOneGridPositionValue()
        {
            var value = _sequenceGridNucleotide.VerticalMoveValue(2, 2);
            Assert.AreEqual(0, value);
        }

        [Test]
        public void ThenUpOneGridPosition()
        {
            var coordinates = _sequenceGridNucleotide.VerticalMoveCoordinates(2, 2);
            Assert.AreEqual(2, coordinates.X);
            Assert.AreEqual(1, coordinates.Y);
        }
    }
}
