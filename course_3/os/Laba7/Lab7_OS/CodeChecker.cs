using System;
using System.Linq;
using Laba7.Exceptions;

namespace Laba7.Core
{
    internal class CodeChecker
    {
        private int[][] codes;

        private int[][] correctSequences =
        {
            new int[] { 12, 2, 11},
            new int[] { 12, 3, 11},
            new int[] { 4, 7, 1, 7},
            new int[] { 4, 7, 1, 11},
            new int[] { 4, 7, 1, 12},
            new int[] { 4, 8, 1, 8},
            new int[] { 4, 8, 1, 9},
            new int[] { 4, 8, 1, 10},
            new int[] { 4, 8, 1, 11},
            new int[] { 4, 8, 1, 12},
            new int[] { 4, 12, 1, 12},
            new int[] { 4, 12, 1, 7},
            new int[] { 4, 12, 1, 8},
            new int[] { 4, 12, 1, 11},
            new int[] { 4, 12, 1, 9},
            new int[] { 4, 12, 1, 10},
            new int[] { 4, 9, 1, 8},
            new int[] { 4, 9, 1, 9},
            new int[] { 4, 9, 1, 11},
            new int[] { 4, 9, 1, 12},
            new int[] { 4, 9, 1, 10},
            new int[] { 4, 10, 1, 8},
            new int[] { 4, 10, 1, 9},
            new int[] { 4, 10, 1, 11},
            new int[] { 4, 10, 1, 12},
            new int[] { 4, 10, 1, 10},
            new int[] { 6, 7},
            new int[] { 6, 8},
            new int[] { 6, 9},
            new int[] { 6, 10},
            new int[] { 6, 12},
            new int[] { 5, 7},
            new int[] { 5, 8},
            new int[] { 5, 12}
        };
        public CodeChecker(int[][] codes)
        {
            this.codes = codes;
        }
        public void CheckSyntaxCorrection()
        {
            for (int i = 0; i < codes.Length; i++)
            {
                if (!ArrayInCorrectSequences(codes[i]))
                    throw new SyntaxException($"Error in line № {i + 1}");
            }
        }
        private bool ArrayInCorrectSequences(int[] symbols)
        {
            if (symbols == null)
                return true;
            for (int i = 0; i < correctSequences.Length; i++)
            {
                if (correctSequences[i].SequenceEqual(symbols))
                    return true;
            }
            return false;
        }
    }
}
