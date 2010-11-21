using System;
using System.IO;

namespace LineCounter
{
    public static class LOC
    {
        public static int CountLines(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var codeChecker = new CodeChecker();
            return codeChecker.GetCodeLines(string.Join("\n",lines));
        }
    }
}