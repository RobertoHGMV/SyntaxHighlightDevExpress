namespace SyntaxHighlightDevExpress
{
    partial class QueryFormaterForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.richEditQuery = new DevExpress.XtraRichEdit.RichEditControl();
            this.lbCaracters = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richEditQuery
            // 
            this.richEditQuery.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
            this.richEditQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richEditQuery.Location = new System.Drawing.Point(-2, -1);
            this.richEditQuery.Margin = new System.Windows.Forms.Padding(2);
            this.richEditQuery.Name = "richEditQuery";
            this.richEditQuery.Options.Fields.UseCurrentCultureDateTimeFormat = false;
            this.richEditQuery.Options.HorizontalRuler.Visibility = DevExpress.XtraRichEdit.RichEditRulerVisibility.Hidden;
            this.richEditQuery.Options.MailMerge.KeepLastParagraph = false;
            this.richEditQuery.Size = new System.Drawing.Size(803, 417);
            this.richEditQuery.TabIndex = 9;
            // 
            // lbCaracters
            // 
            this.lbCaracters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCaracters.AutoSize = true;
            this.lbCaracters.Location = new System.Drawing.Point(741, 428);
            this.lbCaracters.Name = "lbCaracters";
            this.lbCaracters.Size = new System.Drawing.Size(60, 13);
            this.lbCaracters.TabIndex = 10;
            this.lbCaracters.Text = "0000/4000";
            this.lbCaracters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // QueryFormaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbCaracters);
            this.Controls.Add(this.richEditQuery);
            this.Name = "QueryFormaterForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditQuery;
        private System.Windows.Forms.Label lbCaracters;
    }
}

