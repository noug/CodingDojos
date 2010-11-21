namespace LineCounter
{
    public class CodeChecker
    {
        private bool hasCode;
        private bool inComment;

        public bool IsCodeLine(string line)
        {
            if (string.IsNullOrEmpty(line))
                return false;
            if (line.Trim().Length == 0)
                return false;

            if (!IsCommentLine(line))
                return false;

            return true;
        }

        private bool IsCommentLine(string line)
        {
            string trimedLine = line.Trim();
            if (trimedLine.StartsWith("//"))
                return false;
            if (trimedLine.StartsWith("/*") && trimedLine.EndsWith("*/"))
                return false;
            return true;
        }

//        "  if () {  // Hihih"
        public int GetCodeLines(string text)
        {
            int lines = 0;

            hasCode = false;
            inComment = false;

            foreach (char zeichen in text)
            {
                if (IsNewLineWithCode(zeichen))
                {
                    lines++;
                    hasCode = false;
                }

                if (zeichen == '/')
                {
                    inComment = true;
                }

                if (IsCodeChar(zeichen))
                {
                    hasCode = true;
                }
            }
            if (hasCode)
                lines++;

            return lines;
        }

        private bool IsCodeChar(char zeichen)
        {
            return new string(new[] {zeichen}).Trim().Length != 0 && !inComment;
        }

        private bool IsNewLineWithCode(char zeichen)
        {
            return hasCode && zeichen == '\n';
        }
    }
}