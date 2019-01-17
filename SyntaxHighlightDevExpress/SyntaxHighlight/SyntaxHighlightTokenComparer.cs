using DevExpress.XtraRichEdit.API.Native;
using System.Collections.Generic;

namespace ContractOne.UI.FormHelpers.SyntaxHighlight
{
    public class SyntaxHighlightTokenComparer : IComparer<SyntaxHighlightToken>
    {
        public int Compare(SyntaxHighlightToken x, SyntaxHighlightToken y)
        {
            return x.Start - y.Start;
        }
    }
}
