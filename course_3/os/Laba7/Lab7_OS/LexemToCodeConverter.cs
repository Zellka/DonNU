using System;
using System.Linq;

namespace Laba7.Core
{
    internal class LexemToCodeConverter
    {
        private readonly string lexem;

        private readonly string[] oneByteRegisters = { "AL", "AH", "BL", "BH", "CL", "CH", "DL", "DH" };
        private readonly string[] twoByteRegisters = { "AX", "BX", "CX", "DX" };
        private readonly string[] segmentRegisters = { "DS", "SS", "ES" };

        private readonly char[] restrictedVariableSymbols = { '.', '!', '*', '?', ':'};
        private readonly char[] validSymbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        public LexemToCodeConverter(string lexem)
        {
            this.lexem = lexem;
        }

        public int GetCode()
        {
            if (IsDigit())
                return 11;
            if (oneByteRegisters.Contains(lexem))
                return 7;
            if (twoByteRegisters.Contains(lexem))
                return 8;
            if (segmentRegisters.Contains(lexem))
                return 9;
            switch (lexem)
            {
                case "CS":
                    return 10;
                case ",":
                    return 1;
                case "DB":
                    return 2;
                case "DW":
                    return 3;
                case "MOV":
                    return 4;
                case "IMUL":
                    return 5;
                case "POP":
                    return 6;
                default:
                    if (!StartWithDigit() && !lexem.Any(symbol => restrictedVariableSymbols.Contains(symbol)))
                        return 12;
                    throw new ArgumentException();

            }
        }

        private bool StartWithDigit()
        {
            if (lexem == string.Empty) return false;
            return int.TryParse(lexem[0].ToString(), out int value);
        }
        private bool IsDigit()
        {
            ushort outValue = 0;
            bool hexNumberCondition = lexem.EndsWith("H") && StartWithDigit() && lexem.Substring(0, lexem.Length - 1).All(letter => validSymbols.Contains(letter));
            bool binaryNumberCondition = lexem.EndsWith("B") && HasOnlyBinaryDigits();
            bool decimalNumberCondition = ushort.TryParse(lexem, out outValue);
            return hexNumberCondition || binaryNumberCondition || decimalNumberCondition;
        }
        private bool HasOnlyBinaryDigits()
        {
            foreach (char letter in lexem) 
                if (letter != '0' || letter != '1')  return false;
            return true;
        }

        public bool LexemIsOneByteRegister(string lexem)
        {
            return oneByteRegisters.Contains(lexem);
        }

        public bool LexemIsTwoBytesRegister(string lexem)
        {
            return this.lexem == "CS" || twoByteRegisters.Contains(lexem);
        }
    }
}
