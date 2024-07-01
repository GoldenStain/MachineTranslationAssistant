using MachineTranslation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Translate2.SubViews
{
    public partial class MachineTranslate : UserControl
    {
        public TextBox TextBox;

        private Translator translator;
        public MachineTranslate()
        {
            InitializeComponent();
            outputBox.ReadOnly = true;
            translateBtn.Click += OnClickTranslate;

            translator = new Translator();
        }
        private async void OnClickTranslate(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputBox.Text))
                return;
            string s = await translator.TranslateText(inputBox.Text, "zh");
            outputBox.Text = s;
        }

        private void OnCickFill(object sender, EventArgs e)
        {
            if(TextBox!=null)
                TextBox.Text=outputBox.Text;
        }

        private void translateBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
