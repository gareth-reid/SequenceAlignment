using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SequenceAligner.Engine;
using SequenceAligner.Engine.SequenceGrid;

namespace Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //test data
            //var sequence1 = new[] { 'C', 'G', 'T', 'G', 'A', 'A', 'T', 'T', 'C', 'A', 'T' };
            //var sequence2 = new[] { 'G', 'A', 'C', 'T', 'T', 'A', 'C' };
            //var sequence1 = new[] {'G', 'A', 'C', 'T', 'A', 'C'};
            //var sequence2 = new[] {'A', 'C', 'G', 'C'};
            //var sequence1 = new[] { 'A', 'C', 'A', 'C', 'T'};
            //var sequence2 = new[] { 'A', 'C', 'T' };
            var sequence1 = new[] { 'c', 'c', 'a', 't', 'c', 'a', 'a', 'a', 'g', 'a', 'g', 'a', 'g', 'a', 'a', 'a', 'g', 'a', 'g' };
            var sequence2 = new[] { 'g','c','c','a','t','c','a','a','a','g','a','g','a','g','a','g' };

            //var sequence1 = new[] { 'G', 'A' };
            //var sequence2 = new[] {'G', 'C'};


            var sequenceGrid = new SequenceGridNucleotide(sequence1, sequence2);
            sequenceGrid.Initialize();
            sequenceGrid.FillMatrix();
            sequenceGrid.ExecuteTraceback();
            var alignedSequence = sequenceGrid.AlignedSequence();

            PrintMatrix(sequence1, sequence2, sequenceGrid);
            PrintSequenceAligned(alignedSequence.ToList());
            PrintPath(sequenceGrid);
        }

        public static void PrintSequenceAligned(IList<KeyValuePair<string, string>> alignedSequence)
        {
            Console.WriteLine("");
            for (int i = 0; i < alignedSequence.Count(); i++)
            {
                Console.Write(alignedSequence[i].Key + " ");
            }
            Console.WriteLine("");
            for (int i = 0; i < alignedSequence.Count(); i++)
            {
                Console.Write(alignedSequence[i].Value + " ");
            }
            Console.WriteLine("");
        }

        public static void PrintPath(SequenceGrid sequenceGrid)
        {
            Console.WriteLine("");
            foreach (var move in sequenceGrid.TracebackPath)
            {
                Console.WriteLine(move.ToString());
            }
        }

        private static void PrintMatrix(char[] sequence1, char[] sequence2, SequenceGrid sequenceGrid)
        {
            Console.Write("    ");
            foreach (char l in sequence1)
            {
                Console.Write(" " + l + " ");
            }
            Console.WriteLine("  ");
            Console.Write("  ");
            for (int y = 0; y < sequence2.Length + 1; y++)
            {
                Console.WriteLine("");
                if (y > 0)
                {
                    Console.Write(sequence2[y - 1] + " ");
                }
                for (int x = 0; x < sequence1.Length + 1; x++)
                {
                    Console.Write(sequenceGrid.Grid.GetValue(x, y) + " ");
                }

            }
            Console.WriteLine("");
        }



        //Console.Write(sequenceGrid.Grid.GetValue(0, 0) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(1, 0) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(2, 0) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(3, 0) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(4, 0) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(5, 0) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(6, 0) + " ");

        //Console.WriteLine("");
        //Console.Write(sequence2[0] + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(0, 1) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(1, 1) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(2, 1) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(3, 1) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(4, 1) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(5, 1) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(6, 1) + " ");

        //Console.WriteLine("");
        //Console.Write(sequence2[1] + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(0, 2) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(1, 2) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(2, 2) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(3, 2) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(4, 2) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(5, 2) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(6, 2) + " ");
        //Console.WriteLine("");
        //Console.Write(sequence2[2] + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(0, 3) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(1, 3) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(2, 3) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(3, 3) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(4, 3) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(5, 3) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(6, 3) + " ");
        //Console.WriteLine("");
        //Console.Write(sequence2[3] + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(0, 4) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(1, 4) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(2, 4) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(3, 4) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(4, 4) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(5, 4) + " ");
        //Console.Write(sequenceGrid.Grid.GetValue(6, 4) + " ");
    }
}