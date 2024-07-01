namespace Translate2
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.EditorTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.RightUpTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.upComboBox = new System.Windows.Forms.ComboBox();
            this.MachineTranslateView = new Translate2.SubViews.MachineTranslate();
            this.RightDownTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.downComboBox = new System.Windows.Forms.ComboBox();
            this.dictionaryView = new Translate2.SubViews.DictionaryView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入术语库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.RightUpTableLayout.SuspendLayout();
            this.RightDownTableLayout.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 32);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1448, 847);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.EditorTableLayout, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 99.99999F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(718, 841);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "编辑器";
            // 
            // EditorTableLayout
            // 
            this.EditorTableLayout.AutoScroll = true;
            this.EditorTableLayout.AutoSize = true;
            this.EditorTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.EditorTableLayout.ColumnCount = 1;
            this.EditorTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.EditorTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditorTableLayout.Font = new System.Drawing.Font("HarmonyOS Sans SC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditorTableLayout.Location = new System.Drawing.Point(5, 41);
            this.EditorTableLayout.Name = "EditorTableLayout";
            this.EditorTableLayout.RowCount = 1;
            this.EditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.EditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 795F));
            this.EditorTableLayout.Size = new System.Drawing.Size(708, 795);
            this.EditorTableLayout.TabIndex = 3;
            this.EditorTableLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.EditorTableLayout_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.RightUpTableLayout, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.RightDownTableLayout, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(727, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(718, 841);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // RightUpTableLayout
            // 
            this.RightUpTableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.RightUpTableLayout.ColumnCount = 1;
            this.RightUpTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightUpTableLayout.Controls.Add(this.upComboBox, 0, 0);
            this.RightUpTableLayout.Controls.Add(this.MachineTranslateView, 0, 1);
            this.RightUpTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightUpTableLayout.Location = new System.Drawing.Point(3, 3);
            this.RightUpTableLayout.Name = "RightUpTableLayout";
            this.RightUpTableLayout.RowCount = 2;
            this.RightUpTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.RightUpTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightUpTableLayout.Size = new System.Drawing.Size(712, 414);
            this.RightUpTableLayout.TabIndex = 0;
            // 
            // upComboBox
            // 
            this.upComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.upComboBox.FormattingEnabled = true;
            this.upComboBox.Location = new System.Drawing.Point(5, 5);
            this.upComboBox.Name = "upComboBox";
            this.upComboBox.Size = new System.Drawing.Size(254, 26);
            this.upComboBox.TabIndex = 1;
            // 
            // MachineTranslateView
            // 
            this.MachineTranslateView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MachineTranslateView.Location = new System.Drawing.Point(4, 40);
            this.MachineTranslateView.Margin = new System.Windows.Forms.Padding(2);
            this.MachineTranslateView.Name = "MachineTranslateView";
            this.MachineTranslateView.Size = new System.Drawing.Size(704, 370);
            this.MachineTranslateView.TabIndex = 2;
            // 
            // RightDownTableLayout
            // 
            this.RightDownTableLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.RightDownTableLayout.ColumnCount = 1;
            this.RightDownTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightDownTableLayout.Controls.Add(this.downComboBox, 0, 0);
            this.RightDownTableLayout.Controls.Add(this.dictionaryView, 0, 1);
            this.RightDownTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightDownTableLayout.Location = new System.Drawing.Point(3, 423);
            this.RightDownTableLayout.Name = "RightDownTableLayout";
            this.RightDownTableLayout.RowCount = 2;
            this.RightDownTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.RightDownTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightDownTableLayout.Size = new System.Drawing.Size(712, 415);
            this.RightDownTableLayout.TabIndex = 1;
            // 
            // downComboBox
            // 
            this.downComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.downComboBox.FormattingEnabled = true;
            this.downComboBox.Location = new System.Drawing.Point(5, 5);
            this.downComboBox.Name = "downComboBox";
            this.downComboBox.Size = new System.Drawing.Size(254, 26);
            this.downComboBox.TabIndex = 1;
            // 
            // dictionaryView
            // 
            this.dictionaryView.AutoSize = true;
            this.dictionaryView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dictionaryView.Location = new System.Drawing.Point(8, 44);
            this.dictionaryView.Margin = new System.Windows.Forms.Padding(6);
            this.dictionaryView.Name = "dictionaryView";
            this.dictionaryView.Size = new System.Drawing.Size(696, 363);
            this.dictionaryView.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.项目ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.测试ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1448, 32);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 项目ToolStripMenuItem
            // 
            this.项目ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建项目ToolStripMenuItem,
            this.打开项目ToolStripMenuItem,
            this.保存项目ToolStripMenuItem,
            this.导入文件ToolStripMenuItem,
            this.导出文件ToolStripMenuItem,
            this.测试ToolStripMenuItem1});
            this.项目ToolStripMenuItem.Name = "项目ToolStripMenuItem";
            this.项目ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.项目ToolStripMenuItem.Text = "文件";
            // 
            // 新建项目ToolStripMenuItem
            // 
            this.新建项目ToolStripMenuItem.Name = "新建项目ToolStripMenuItem";
            this.新建项目ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.新建项目ToolStripMenuItem.Text = "新建项目";
            this.新建项目ToolStripMenuItem.Click += new System.EventHandler(this.onCreateNewProject);
            // 
            // 打开项目ToolStripMenuItem
            // 
            this.打开项目ToolStripMenuItem.Name = "打开项目ToolStripMenuItem";
            this.打开项目ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.打开项目ToolStripMenuItem.Text = "打开项目";
            this.打开项目ToolStripMenuItem.Click += new System.EventHandler(this.onClickOpenProject);
            // 
            // 保存项目ToolStripMenuItem
            // 
            this.保存项目ToolStripMenuItem.Name = "保存项目ToolStripMenuItem";
            this.保存项目ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.保存项目ToolStripMenuItem.Text = "保存项目";
            this.保存项目ToolStripMenuItem.Click += new System.EventHandler(this.OnClickSaveProj);
            // 
            // 导入文件ToolStripMenuItem
            // 
            this.导入文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.docToolStripMenuItem});
            this.导入文件ToolStripMenuItem.Name = "导入文件ToolStripMenuItem";
            this.导入文件ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.导入文件ToolStripMenuItem.Text = "导入文件";
            // 
            // docToolStripMenuItem
            // 
            this.docToolStripMenuItem.Name = "docToolStripMenuItem";
            this.docToolStripMenuItem.Size = new System.Drawing.Size(144, 34);
            this.docToolStripMenuItem.Text = "Doc";
            this.docToolStripMenuItem.Click += new System.EventHandler(this.onClickImportDoc);
            // 
            // 导出文件ToolStripMenuItem
            // 
            this.导出文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tXTToolStripMenuItem,
            this.markdownToolStripMenuItem});
            this.导出文件ToolStripMenuItem.Name = "导出文件ToolStripMenuItem";
            this.导出文件ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.导出文件ToolStripMenuItem.Text = "导出文件";
            // 
            // tXTToolStripMenuItem
            // 
            this.tXTToolStripMenuItem.Name = "tXTToolStripMenuItem";
            this.tXTToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.tXTToolStripMenuItem.Text = "TXT";
            this.tXTToolStripMenuItem.Click += new System.EventHandler(this.onClickExportTxt);
            // 
            // markdownToolStripMenuItem
            // 
            this.markdownToolStripMenuItem.Name = "markdownToolStripMenuItem";
            this.markdownToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.markdownToolStripMenuItem.Text = "Markdown";
            this.markdownToolStripMenuItem.Click += new System.EventHandler(this.onClickExportMarkdown);
            // 
            // 测试ToolStripMenuItem1
            // 
            this.测试ToolStripMenuItem1.Name = "测试ToolStripMenuItem1";
            this.测试ToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.测试ToolStripMenuItem1.Text = "测试";
            this.测试ToolStripMenuItem1.Click += new System.EventHandler(this.测试ToolStripMenuItem1_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入术语库ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 导入术语库ToolStripMenuItem
            // 
            this.导入术语库ToolStripMenuItem.Name = "导入术语库ToolStripMenuItem";
            this.导入术语库ToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.导入术语库ToolStripMenuItem.Text = "导入术语库";
            this.导入术语库ToolStripMenuItem.Click += new System.EventHandler(this.导入术语库ToolStripMenuItem_Click);
            // 
            // 测试ToolStripMenuItem
            // 
            this.测试ToolStripMenuItem.Name = "测试ToolStripMenuItem";
            this.测试ToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.测试ToolStripMenuItem.Text = "测试";
            this.测试ToolStripMenuItem.Click += new System.EventHandler(this.onClickTestButton);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 879);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "翻译";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.RightUpTableLayout.ResumeLayout(false);
            this.RightDownTableLayout.ResumeLayout(false);
            this.RightDownTableLayout.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel RightUpTableLayout;
        private System.Windows.Forms.TableLayoutPanel RightDownTableLayout;
        private System.Windows.Forms.ToolStripMenuItem 新建项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开项目ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox upComboBox;
        private System.Windows.Forms.ComboBox downComboBox;
        private SubViews.MachineTranslate MachineTranslateView;
        private System.Windows.Forms.TableLayoutPanel EditorTableLayout;
        private System.Windows.Forms.ToolStripMenuItem 测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存项目ToolStripMenuItem;
        private SubViews.DictionaryView dictionaryView;
        private System.Windows.Forms.ToolStripMenuItem 导入文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem docToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tXTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 导入术语库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markdownToolStripMenuItem;
    }
}

