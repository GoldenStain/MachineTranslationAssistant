using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Translate2.AssistantDictionary;

namespace Translate2.SubViews
{
    public partial class DictionaryView : UserControl
    {
        private MyDictionary termDictionary;
        public DictionaryView()
        {
            InitializeComponent();
            termDictionary = new MyDictionary();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queryString = textBox1.Text;
            textBox2.Text = termDictionary.UseTheDictionary(queryString);
        }
    }
}
