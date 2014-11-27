namespace CompatibleSoftware.SolutionMetrics.Analyser
{
    public class CodeLine
    {
        /// <summary>
        /// Is this a single line comment
        /// </summary>
        private readonly bool _isSingleLineComment;

        /// <summary>
        /// Is this part of a multline comment
        /// </summary>
        private readonly bool _isMultiLineComment;

        /// <summary>
        /// The actual text of this line
        /// </summary>
        public string Text
        {
            get { return _text; }
        }
        private readonly string _text;

        /// <summary>
        /// Is this line whitespace
        /// </summary>
        public bool IsWhitespace
        {
            get { return _isWhitespace; }
        }
        private readonly bool _isWhitespace;

        /// <summary>
        /// Is this a comment
        /// </summary>
        public bool IsComment
        {
            get { return _isSingleLineComment || _isMultiLineComment; }
        }

        /// <summary>
        /// Constructs a new line of code 
        /// </summary>
        /// <param name="text">The text of this line</param>
        /// <param name="inCommentBlock">Is this line inside a comment block</param>
        public CodeLine(string text, bool inCommentBlock)
        {
            _text = text;

            if (string.IsNullOrWhiteSpace(_text))
                _isWhitespace = true;
            
            if (_text.Trim().StartsWith("//") || _text.Trim().StartsWith("///") || _text.Trim().StartsWith("'"))
                _isSingleLineComment = true;

            if (inCommentBlock)
                _isMultiLineComment = true;
        }
    }
}
