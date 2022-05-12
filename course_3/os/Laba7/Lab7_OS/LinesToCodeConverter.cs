using System;
using Laba7.Exceptions;
using Laba7.Core.Models;
using Laba7.Enums;

namespace Laba7.Core
{
    internal class LinesToCodeConverter
    {
        private string[] targetLines;

        private const int ComaCode = 1;
        private const int MovCode = 4;
        private const int ImulCode = 5;
        private const int PopCode = 6;

        public LinesToCodeConverter(string[] targetLines)
        {
            this.targetLines = targetLines;
        }

        public int[][] CalculateCodes()
        {
            int i = 0;
            try
            {
                int[][] codes = new int[targetLines.Length][];
                for (i = 0; i < targetLines.Length; i++)
                {
                    if (targetLines[i] == string.Empty) continue;

                    string[] words = targetLines[i].Split(new char[] { ' ' });
                    codes[i] = new int[words.Length];

                    for (int j = 0; j < words.Length; j++)
                    {
                        LexemToCodeConverter lexemConverter = new LexemToCodeConverter(words[j]);
                        codes[i][j] = lexemConverter.GetCode();
                        if (codes[i][j] == 12)
                        {
                            Variable variable = new Variable();
                            variable.Name = words[j];   
                            if (j == 0)
                            {
                                switch (words[j + 1])
                                {
                                    case "DB":
                                        variable.SizeType = SizeType.OneByteVariable;
                                        break;
                                    case "DW":
                                        variable.SizeType = SizeType.TwoBytesVariable;
                                        break;
                                    default:
                                        throw new SyntaxException($"Error in line № {i + 1}");
                                }
                            }
                            else
                            {
                                Variable current = DefinedList.GetVariableByName(words[j]);
                                switch (codes[i][j - 1])
                                {
                                    case MovCode:
                                        try
                                        {
                                            CheckVariableDefinition(i, j, words);
                                            switch (current.SizeType)
                                            {
                                                case SizeType.OneByteVariable:
                                                    if (lexemConverter.LexemIsTwoBytesRegister(words[j + 2]))
                                                        throw new SyntaxException($"Error in line № {i + 1}");
                                                    continue;
                                                case SizeType.TwoBytesVariable:
                                                    if (lexemConverter.LexemIsOneByteRegister(words[j + 2]))
                                                        throw new SyntaxException($"Error in line № {i + 1}");
                                                    continue;
                                            }
                                            break;
                                        }
                                        catch
                                        {
                                            throw new SyntaxException($"Error in line № {i + 1}");
                                        }
                                    case PopCode:
                                    case ImulCode:
                                        CheckVariableDefinition(i, j, words);
                                        continue;
                                    case ComaCode:
                                        CheckVariableDefinition(i, j, words);
                                        switch (codes[i][j - 2])
                                        {
                                            case 7:
                                                if (current.SizeType != SizeType.OneByteVariable)
                                                    throw new SyntaxException($"Error in line № {i + 1}");
                                                continue;
                                            case 8:
                                            case 9:
                                            case 10:
                                                if (current.SizeType != SizeType.TwoBytesVariable)
                                                    throw new SyntaxException($"Error in line № {i + 1}");
                                                continue;
                                        }
                                        Variable latest = DefinedList.GetVariableByName(words[j - 2]);
                                        if (latest.SizeType == current.SizeType)
                                            continue;
                                        throw new SyntaxException($"Error in line № {i + 1}");
                                    default:
                                        throw new SyntaxException($"Error in line № {i + 1}");
                                }
                            }
                            if (DefinedList.IsDefined(words[j]))
                                throw new SyntaxException($"Error in line № {i + 1}");
                            DefinedList.Add(variable);
                        }
                    }
                }
                return codes;
            }
            catch (ArgumentException)
            {           
                throw new SyntaxException($"Error in line № {i + 1}");
            }
        }
        private static void CheckVariableDefinition(int i, int j, string[] words)
        {
            if (!DefinedList.IsDefined(words[j]))
                throw new SyntaxException($"Error in line № {i + 1})");
        }
    }
}
