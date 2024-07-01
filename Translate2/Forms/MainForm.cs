using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Translate2.Data;
using Translate2.Data.DOCX;
using Translate2.MemBase;
using Translate2.SubViews;

namespace Translate2
{

    public partial class MainForm : Form
    {
        private MachineTranslate machineTranslate => (MachineTranslate)RightUpTableLayout.Controls[1];
        private MemoryView memoryView;
        private int testCnt = 0;
        private Dictionary<TextBox, Label> textBoxLabelPairs;

        private string upWindowName, downWindowName;
        private readonly List<string> windowNames = new List<string>() { "机器翻译", "词典",  "术语库","记忆库" };
        /// <summary>
        /// nooo
        /// </summary>
        private bool upUpdateManully, downUpdateManully;
        public  MainForm()
        {
    
            InitializeComponent();
            textBoxLabelPairs = new Dictionary<TextBox, Label>();
            EditorTableLayout.RowCount = 0;
            EditorTableLayout.RowStyles.RemoveAt(0);
            //cleanEditor();
            upWindowName = windowNames[0];
            downWindowName = windowNames[1];
            foreach(var s in windowNames)
            {
                upComboBox.Items.Add(s);
                downComboBox.Items.Add(s);
            }
            upComboBox.SelectedIndex = 0;
            downComboBox.SelectedIndex = 1;
            upComboBox.SelectedIndexChanged += onUpComboBoxChange;
            downComboBox.SelectedIndexChanged += onDownComboBoxChange;
            //InitBug();
            /*InitializeContextMenuStrip();

            // 关联ComboBox的SelectedIndexChanged事件到事件处理程序  
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);*/
        }
        private async void InitBug()
        {
            RowStyle style = new RowStyle(SizeType.AutoSize);
            EditorTableLayout.RowStyles.Add(style);
            EditorTableLayout.RowCount++;

            TextBox newBox = new TextBox();
            newBox.Dock = DockStyle.Fill;
            newBox.Multiline = true;
            newBox.WordWrap = true;
            newBox.TextChanged += SettxtHeight;
            newBox.Click += TransferText2MachineView;
            newBox.Click += TransferText2MemoryView;
            newBox.BackColor = System.Drawing.SystemColors.Menu;
            newBox.BorderStyle = BorderStyle.None;

            Label label = new Label();
            label.Text = "t";
            label.Dock = DockStyle.Fill;
            label.AutoSize = true;

            textBoxLabelPairs.Add(newBox, label);

            EditorTableLayout.Controls.Add(newBox, 0, testCnt);
            EditorTableLayout.Controls.Add(label, 0, testCnt++);
            await Task.Delay(50);
            cleanEditor();
        }

        private void onCreateNewProject(object sender, EventArgs e)
        {
            cleanEditor();
        }

        private void switchUpDownViews()
        {
            
            int upIndex, downIndex;
            upIndex=GetViewIndexByName(upWindowName);
            downIndex = GetViewIndexByName(downWindowName);
            upUpdateManully = true;
            downUpdateManully = true;
            upComboBox.SelectedIndex = downIndex;
            downComboBox.SelectedIndex = upIndex;
            upUpdateManully = false;
            downUpdateManully = false;
            Control upControl, downControl;
            upControl = RightUpTableLayout.GetControlFromPosition(0, 1);
            downControl = RightDownTableLayout.GetControlFromPosition(0, 1);
            RightUpTableLayout.Controls.Remove(upControl);
            RightDownTableLayout.Controls.Remove(downControl);
            RightUpTableLayout.Controls.Add(downControl, 0, 1);
            RightDownTableLayout.Controls.Add(upControl, 0, 1);
            string tmp = upWindowName;
            upWindowName = downWindowName;
            downWindowName = tmp;
            int al;

        }
        private int GetViewIndexByName(string name)
        {
            for(int i=0;i<windowNames.Count;i++)
            {
                if (string.CompareOrdinal(name, windowNames[i]) == 0)
                    return i;
            }
            return -1;
        }

        private void onUpComboBoxChange(object sender, EventArgs e)
        {
            if (upUpdateManully)
            {
                return;
            }
            string chooseWindowName = (sender as ComboBox).Text;
            if (string.CompareOrdinal(chooseWindowName, upWindowName) == 0)
                return;
            
            if (string.CompareOrdinal(chooseWindowName, downWindowName) == 0)
            {
                switchUpDownViews();
                return;
            }
            upWindowName = chooseWindowName;
            int index = GetViewIndexByName(upWindowName);
            
            Control oldControl = RightUpTableLayout.GetControlFromPosition(0, 1);
            RightUpTableLayout.Controls.Remove(oldControl);
            Control newControl=null;
            switch (index)
            {
                //机器翻译
                case 0:
                    newControl = new MachineTranslate();
                    MachineTranslateView = newControl as MachineTranslate;
                    break;
                case 1:
                    newControl = new DictionaryView();
                    break;
                case 2:
                    newControl =new TermDictionaryView();    
                    break;
                case 3:
                    newControl = new MemoryView();
                    memoryView= newControl as MemoryView;
                    break;
                case 4:
                    break;
            }
            newControl.Dock = DockStyle.Fill;
            
            RightUpTableLayout.Controls.Add(newControl,0,1);
            
        }

        private void onDownComboBoxChange(object sender, EventArgs e)
        {
            if (downUpdateManully)
            {
                return;
            }
            string chooseWindowName = (sender as ComboBox).Text;
            if (string.CompareOrdinal(chooseWindowName, downWindowName) == 0)
                return;
            
            if (string.CompareOrdinal(upWindowName, chooseWindowName) == 0)
            {
                switchUpDownViews();
                return;
            }
            downWindowName = chooseWindowName;
            int index = GetViewIndexByName(downWindowName);

            Control oldControl = RightDownTableLayout.GetControlFromPosition(0, 1);
            RightDownTableLayout.Controls.Remove(oldControl);
            Control newControl = null;
            switch (index)
            {
                //机器翻译
                case 0:
                    newControl = new MachineTranslate();
                    MachineTranslateView = newControl as MachineTranslate;
                    break;
                case 1:
                    newControl = new DictionaryView();
                    break;
                case 2:
                    newControl = new TermDictionaryView();
                    break;
                case 3:
                    newControl = new MemoryView();
                    memoryView = newControl as MemoryView;
                    break;
                case 4:
                    break;
            }
            newControl.Dock = DockStyle.Fill;
            
            RightDownTableLayout.Controls.Add(newControl, 0, 1);
            
        }

        private void onClickTestButton(object sender, EventArgs e)
        {
            RowStyle style = new RowStyle(SizeType.AutoSize);
            EditorTableLayout.RowStyles.Add(style);
            EditorTableLayout.RowCount++;
            
            
            
            TextBox newBox = new TextBox();
            newBox.Text = "testtesttesttest";
            newBox.Dock = DockStyle.Fill;
            newBox.Multiline = true;
            newBox.WordWrap = true;
            



            Label label = new Label();
            label.Text = "tets";
            label.Dock = DockStyle.Fill;
            label.AutoSize = true;

            
            EditorTableLayout.Controls.Add(newBox, 0, testCnt);
            EditorTableLayout.Controls.Add(label, 0, testCnt++);
            
        }
        private void SettxtHeight(object sender, EventArgs e)
        {
            TextBox txt1 = (TextBox)sender;
            int txtHeight = 16;//设置单行的行高
            Size size = TextRenderer.MeasureText(txt1.Text, txt1.Font);
            int itxtLine = size.Width / txt1.Width + txt1.Lines.Count() + 1;
            txt1.Height = txtHeight * itxtLine;
        }
        private void SetLabelHeight(object sender, EventArgs e)
        {
            Label txt1 = (Label)sender;
            int txtHeight = 9;//设置单行的行高
            Size size = TextRenderer.MeasureText(txt1.Text, txt1.Font);
            int itxtLine = size.Width / txt1.Width  + 1;
            txt1.Height = txtHeight * itxtLine;
        }
        private void TransferText2MachineView(object sender, EventArgs e)
        {
            if (MachineTranslateView is null) return;
            MachineTranslateView.inputBox.Text = textBoxLabelPairs[(TextBox)(sender)].Text;
            MachineTranslateView.outputBox.Text = string.Empty;
            MachineTranslateView.TextBox = (TextBox)(sender);

        }

        private void TransferText2MemoryView(object sender, EventArgs e)
        {
            if (memoryView is null) return;
            memoryView.now_trans = textBoxLabelPairs[(TextBox)(sender)].Text;
            // MessageBox.Show(memoryView.now_trans);
            // memoryView.textBox1.Text = memoryView.showContent(memoryView.now_trans);
            memoryView.textBox1.Text = memoryView.showContent(memoryView.now_trans);
            memoryView.TextBox = (TextBox)(sender);
        }

        private void OnClickSaveProj(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存文件";
            saveFileDialog.InitialDirectory = @"C:\";
            saveFileDialog.Filter = "Json 文件 (*.json)|*.json";
            DialogResult result = saveFileDialog.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }
            string path = saveFileDialog.FileName;
            ProjectSaveData data = new ProjectSaveData(path);
            
            string newFileName = "dictionary.txt"; // 新文件名
            string destinationDirectory = "../../memoryDictionary/";
            string destinationPath = Path.Combine(destinationDirectory, newFileName);

            using (StreamWriter writer = new StreamWriter(destinationPath))
            {
                foreach (var pair in textBoxLabelPairs)
                {
                    if(pair.Key.Text.Trim().Length > 0)
                    {
                        writer.WriteLine(pair.Value.Text);
                        writer.WriteLine(pair.Key.Text);
                    }
                }
            }

            foreach (var pair in textBoxLabelPairs)
            {
                // !!!!!!!!!!!
                data.OriginTexts.Add(pair.Value.Text);
                data.TranslateTexts.Add(pair.Key.Text);
            }

            data.Save();
        }


        private async void onClickImportDoc(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件";
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "Word 文档 (*.docx, *.doc)|*.docx;*.doc";
            DialogResult result = openFileDialog.ShowDialog();
            Docx d = null;
            if (result == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                d = new Docx(selectedFilePath);
            }
            if (d != null)
            {
                List<TextBox> newboxes=new List<TextBox>();
                cleanEditor();
                for (int i = 0; i < d.ParaCount; i++)
                {
                    if (i > 0)
                    {
                        RowStyle style = new RowStyle(SizeType.AutoSize);
                        EditorTableLayout.RowStyles.Add(style);
                        EditorTableLayout.RowCount++;
                    }
                    else
                    {
                        EditorTableLayout.RowStyles[0] = new RowStyle(SizeType.AutoSize);
                    }

                    TextBox newBox = new TextBox();
                    newBox.Dock = DockStyle.Fill;
                    newBox.Multiline = true;
                    newBox.WordWrap = true;
                    newBox.TextChanged += SettxtHeight;
                    newBox.Click += TransferText2MachineView;
                    newBox.Click += TransferText2MemoryView;
                    newBox.BackColor = System.Drawing.SystemColors.Menu;
                    newBox.BorderStyle = BorderStyle.None;
                    newboxes.Add(newBox);

                    Label label = new Label();
                    label.Text = d.GetParaByIndex(i);
                    label.Dock = DockStyle.Fill;
                    label.AutoSize = true;

                    textBoxLabelPairs.Add(newBox, label);

                    EditorTableLayout.Controls.Add(newBox, 0, testCnt);
                    EditorTableLayout.Controls.Add(label, 0, testCnt++);
                }
                await Task.Delay(50);
                for (int i = 0; i < d.ParaCount; i++)
                {
                    newboxes[i].Height = 16;
                }
            }
        }
        private void cleanEditor()
        {
            testCnt = 0;
            textBoxLabelPairs.Clear();
            EditorTableLayout.Controls.Clear();
        }

        private void EditorTableLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 测试ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Label l=null;
            foreach(var label in textBoxLabelPairs.Values)
            {
                l = label;
                break;
            }
            l.Height = 16;
            l.Text = "test";
        }

        private void 导入术语库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    // 将文件重命名并保存到指定目录
                    string newFileName = "dictionary.txt"; // 新文件名
                    string destinationDirectory = "../../termDictionary/";
                    string destinationPath = Path.Combine(destinationDirectory, newFileName);

                    try
                    {
                        if (!Directory.Exists(destinationDirectory))
                        {
                            Directory.CreateDirectory(destinationDirectory);
                        }

                        File.Copy(selectedFilePath, destinationPath, true);
                        MessageBox.Show("已成功导入术语库", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void onClickExportMarkdown(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "导出文件";
            saveFileDialog.InitialDirectory = @"C:\";
            saveFileDialog.Filter = "md 文件 (*.md)|*.md";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            string path = saveFileDialog.FileName;
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var pair in textBoxLabelPairs)
                {
                    if (string.IsNullOrEmpty(pair.Key.Text))
                    {
                        writer.WriteLine($"*{pair.Value.Text}*  ");
                    }
                    else
                    {
                        writer.WriteLine($"__{pair.Key.Text}__  ");
                    }
                }
            }

            string newFileName = "dictionary.txt"; // 新文件名
            string destinationDirectory = "../../memoryDictionary/";
            string destinationPath = Path.Combine(destinationDirectory, newFileName);

            using (StreamWriter writer = new StreamWriter(destinationPath))
            {
                foreach (var pair in textBoxLabelPairs)
                {
                    if (pair.Key.Text.Trim().Length > 0)
                    {
                        writer.WriteLine(pair.Value.Text);
                        writer.WriteLine(pair.Key.Text);
                    }
                }
            }
    }

        private void onClickExportCsv(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "导出文件";
            saveFileDialog.InitialDirectory = @"C:\";
            saveFileDialog.Filter = "csv 文件 (*.csv)|*.csv";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            string path = saveFileDialog.FileName;
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var pair in textBoxLabelPairs)
                {
                    
                    writer.Write($"\"{pair.Value.Text}\"");
                    writer.Write(",");
                    
                }
                writer.WriteLine();
                foreach (var pair in textBoxLabelPairs)
                {

                    writer.Write($"\"{pair.Key.Text}\"");
                    writer.Write(",");

                }

            }

            string newFileName = "dictionary.txt"; // 新文件名
            string destinationDirectory = "../../memoryDictionary/";
            string destinationPath = Path.Combine(destinationDirectory, newFileName);

            using (StreamWriter writer = new StreamWriter(destinationPath))
            {
                foreach (var pair in textBoxLabelPairs)
                {
                    if (pair.Key.Text.Trim().Length > 0)
                    {
                        writer.WriteLine(pair.Value.Text);
                        writer.WriteLine(pair.Key.Text);
                    }
                }
            }
        }

        private async void  onClickOpenProject(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件";
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "Json 文件 (*.json)|*.json";
            DialogResult result = openFileDialog.ShowDialog();
            List<TextBox> newBoxs=new List<TextBox>();
            if (result != DialogResult.OK)
            {
                return;
            }
            string path = openFileDialog.FileName;
            ProjectSaveData data = new ProjectSaveData(path);
            data.Load();
            cleanEditor();
            for (int i = 0; i < data.OriginTexts.Count; i++)
            {
                if(i>0)
                {
                    RowStyle style = new RowStyle(SizeType.AutoSize);
                    EditorTableLayout.RowStyles.Add(style);
                    EditorTableLayout.RowCount++;
                }
                else
                {
                    EditorTableLayout.RowStyles[0]= new RowStyle(SizeType.AutoSize);
                }

                TextBox newBox = new TextBox();
                newBox.Dock = DockStyle.Fill;
                newBox.Multiline = true;
                newBox.WordWrap = true;
                newBox.Click += TransferText2MachineView;
                newBox.Click += TransferText2MemoryView;
                newBox.BackColor = System.Drawing.SystemColors.Menu;
                newBox.BorderStyle = BorderStyle.None;
                newBox.TextChanged += SettxtHeight;
                newBoxs.Add(newBox);
                //newBox.Text = i < data.TranslateTexts.Count ? data.TranslateTexts[i] : string.Empty;


                Label label = new Label();
                label.Dock = DockStyle.Fill;
                label.AutoSize = true;
                //await Task.Delay(50);  
                label.Text = data.OriginTexts[i];
                

                textBoxLabelPairs.Add(newBox, label);

                EditorTableLayout.Controls.Add(newBox, 0, testCnt);
                EditorTableLayout.Controls.Add(label, 0, testCnt++);
            }
            await Task.Delay(50);
            for (int i = 0; i < data.OriginTexts.Count; i++)
            {
                TextBox newBox = newBoxs[i];
                newBox.Text = i < data.TranslateTexts.Count ? data.TranslateTexts[i] : string.Empty;
            }
        }



        private void onClickExportTxt(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "导出文件";
            saveFileDialog.InitialDirectory = @"C:\";
            saveFileDialog.Filter = "txt 文件 (*.txt)|*.txt";
            DialogResult result = saveFileDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            string path = saveFileDialog.FileName;
            using (StreamWriter writer=new StreamWriter(path))
            {
                foreach (var pair in textBoxLabelPairs)
                {
                    if(string.IsNullOrEmpty(pair.Key.Text))
                    {
                        writer.WriteLine(pair.Value.Text);
                    }
                    else
                    {
                        writer.WriteLine(pair.Key.Text);
                    }
                }
            }

            string newFileName = "dictionary.txt"; // 新文件名
            string destinationDirectory = "../../memoryDictionary/";
            string destinationPath = Path.Combine(destinationDirectory, newFileName);

            using (StreamWriter writer = new StreamWriter(destinationPath))
            {
                foreach (var pair in textBoxLabelPairs)
                {
                    if (pair.Key.Text.Trim().Length > 0)
                    {
                        writer.WriteLine(pair.Value.Text);
                        writer.WriteLine(pair.Key.Text);
                    }
                }
            }
        }
    }
}
