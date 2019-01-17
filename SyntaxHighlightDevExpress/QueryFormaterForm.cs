using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContractOne.UI.FormHelpers.SyntaxHighlight;
using DevExpress.Office.Utils;
using DevExpress.XtraRichEdit.Services;
using SyntaxHighlightDevExpress.SyntaxHighlight;

namespace SyntaxHighlightDevExpress
{
    public partial class QueryFormaterForm : Form
    {
        public QueryFormaterForm()
        {
            InitializeComponent();
            FormatRicheEdit();
        }

        private void FormatRicheEdit()
        {
            richEditQuery.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            richEditQuery.ReplaceService<ISyntaxHighlightService>(new SyntaxHighlightService(richEditQuery.Document));
            richEditQuery.Document.Sections[0].Page.Width = Units.InchesToDocumentsF(80f);
            richEditQuery.TextChanged += RichEditQuery_TextChanged;
        }

        private void RichEditQuery_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FormatLabelCaracters();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensagem do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatLabelCaracters()
        {
            var qtdCaracters = richEditQuery.Text.Length;
            lbCaracters.Text = $@"{qtdCaracters}/4000";
            lbCaracters.ForeColor = qtdCaracters > 4000 ? Color.Red : Color.Black;
        }
    }
}
