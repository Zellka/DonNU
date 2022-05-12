using System;
using System.Collections.Generic;
using System.Linq;
using Laba7.Core.Models;

namespace Laba7.Core
{
    static class DefinedList
    {
        private static List<Variable> variables;

        static DefinedList()
        {
            variables = new List<Variable>();
        }

        public static void Add(Variable addition)
        {
            variables.Add(addition);
        }

        public static void Clear()
        {
            variables.Clear();
        }

        public static bool IsDefined(string name)
        {
            return variables.Any(variable => variable.Name == name);
        }

        public static Variable GetVariableByName(string name)
        {
            return variables.FirstOrDefault(variable => variable.Name == name);
        }
    }
}
