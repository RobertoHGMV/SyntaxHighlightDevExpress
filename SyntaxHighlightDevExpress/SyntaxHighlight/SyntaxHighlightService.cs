using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ContractOne.UI.FormHelpers.SyntaxHighlight;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Services;

namespace SyntaxHighlightDevExpress.SyntaxHighlight
{
    public class SyntaxHighlightService : ISyntaxHighlightService
    {
        #region #parsetokens
        Document document;
        readonly SyntaxHighlightProperties _defaultSettings;
        readonly SyntaxHighlightProperties _keywordSettings;
        readonly SyntaxHighlightProperties _stringSettings;
        private readonly string[] _keywords;

        public SyntaxHighlightService(Document document)
        {
            this.document = document;
            _defaultSettings = new SyntaxHighlightProperties { ForeColor = Color.Black };
            _keywordSettings = new SyntaxHighlightProperties { ForeColor = Color.Blue };
            _stringSettings = new SyntaxHighlightProperties { ForeColor = Color.Red };
            _keywords = DatabaseKeywords.KeywordsUpperSql.Union(DatabaseKeywords.KeywordsLowerSql).ToArray();
        }

        private List<SyntaxHighlightToken> ParseTokens()
        {
            List<SyntaxHighlightToken> tokens = new List<SyntaxHighlightToken>();
            DocumentRange[] ranges = null;
            // search for quotation marks
            ranges = document.FindAll("'", SearchOptions.None);
            for (var i = 0; i < ranges.Length / 2; i++)
            {
                tokens.Add(new SyntaxHighlightToken(ranges[i * 2].Start.ToInt(),
                    ranges[i * 2 + 1].Start.ToInt() - ranges[i * 2].Start.ToInt() + 1, _stringSettings));
            }
            // search for keywords
            for (var i = 0; i < _keywords.Length; i++)
            {
                ranges = document.FindAll(_keywords[i], SearchOptions.CaseSensitive | SearchOptions.WholeWord);

                for (var j = 0; j < ranges.Length; j++)
                {
                    if (!IsRangeInTokens(ranges[j], tokens))
                        tokens.Add(new SyntaxHighlightToken(ranges[j].Start.ToInt(), ranges[j].Length, _keywordSettings));
                }
            }
            // order tokens by their start position
            tokens.Sort(new SyntaxHighlightTokenComparer());
            // fill in gaps in document coverage
            AddPlainTextTokens(tokens);
            return tokens;
        }

        private void AddPlainTextTokens(List<SyntaxHighlightToken> tokens)
        {
            var count = tokens.Count;
            if (count == 0)
            {
                tokens.Add(new SyntaxHighlightToken(0, document.Range.End.ToInt(), _defaultSettings));
                return;
            }
            tokens.Insert(0, new SyntaxHighlightToken(0, tokens[0].Start, _defaultSettings));
            for (var i = 1; i < count; i++)
            {
                tokens.Insert(i * 2, new SyntaxHighlightToken(tokens[i * 2 - 1].End,
                    tokens[i * 2].Start - tokens[i * 2 - 1].End, _defaultSettings));
            }
            tokens.Add(new SyntaxHighlightToken(tokens[count * 2 - 1].End,
                document.Range.End.ToInt() - tokens[count * 2 - 1].End, _defaultSettings));
        }

        private bool IsRangeInTokens(DocumentRange range, List<SyntaxHighlightToken> tokens)
        {
            return tokens.Any(t => IsIntersect(range, t));
        }

        bool IsIntersect(DocumentRange range, SyntaxHighlightToken token)
        {
            var start = range.Start.ToInt();
            if (start >= token.Start && start < token.End)
                return true;

            var end = range.End.ToInt() - 1;
            if (end >= token.Start && end < token.End)
                return true;

            return false;
        }
        #endregion #parsetokens

        #region #ISyntaxHighlightServiceMembers
        public void ForceExecute()
        {
            Execute();
        }

        public void Execute()
        {
            document.ApplySyntaxHighlight(ParseTokens());
        }
        #endregion #ISyntaxHighlightServiceMembers
    }
}
