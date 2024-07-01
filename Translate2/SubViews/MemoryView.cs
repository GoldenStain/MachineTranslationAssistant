using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Translate2.MemBase;

namespace Translate2.SubViews
{
    public partial class MemoryView : UserControl
    {
        private MemoryBase memory;
        public string now_trans = null;
        public TextBox TextBox;
        public MemoryView()
        {
            InitializeComponent();
            memory = new MemoryBase();
        }

        private void fillBtn_Click(object sender, EventArgs e)
        {
            if (now_trans != null)
            {
                var result = memory.getMostSimilarEntry(now_trans);
                int ratio = result.Value;
                if(ratio < 100)
                {
                    DialogResult messageResult = MessageBox.Show("Do you want to fill in?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(messageResult == DialogResult.Yes)
                    {
                        TextBox.Text = result.Key.Value.ToString();
                    }
                    else
                    {
                        ;
                    }
                }
                else
                    TextBox.Text = result.Key.Value.ToString() ;
            }
            else
                MessageBox.Show("无可翻译文本！");
        }

        public string showContent(string target)
        {
            return memory.UseTheDictionary(target);
        }

        private void queryBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = memory.UseTheDictionary(now_trans);
        }
    }
}
