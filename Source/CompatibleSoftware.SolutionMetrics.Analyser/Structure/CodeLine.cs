using System.Collections.Generic;
using CompatibleSoftware.SolutionMetrics.Analyser.Comments;
using System.Linq;

namespace CompatibleSoftware.SolutionMetrics.Analyser.Structure
{
    public class CodeLine
    {
        /// <summary>
        /// A list of objects that will check if the line is a recognised comment format
        /// </summary>
        private readonly IList<IComment> _commentIdentifiers = new List<IComment>
            {
                new XmlComment(),
                new CSharpComment(),
                new VbComment()
            };

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
        public string Text { get; }

        /// <summary>
        /// Is this line whitespace
        /// </summary>
        public bool IsWhitespace { get; }

        /// <summary>
        /// Is this a comment
        /// </summary>
        public bool IsComment => _isSingleLineComment || _isMultiLineComment;

        /// <summary>
        /// Constructs a new line of code 
        /// </summary>
        /// <param name="text">The text of this line</param>
        /// <param name="inCommentBlock">Is this line inside a comment block</param>
        public CodeLine(string text, bool inCommentBlock)
        {
            Text = text;

            if (string.IsNullOrWhiteSpace(Text))
                IsWhitespace = true;

            if(_commentIdentifiers.Any(c => c.IsMatching(Text)))
                _isSingleLineComment = true;

            if (inCommentBlock)
                _isMultiLineComment = true;
        }
    }
}
