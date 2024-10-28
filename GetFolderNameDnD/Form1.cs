using System;
using System.Windows.Forms;
using System.IO;

namespace GetFolderNameDnD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 起動時の初期化処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            lblFolder.Text = "";
            btnOK.Enabled = false;
            Clipboard.Clear();
        }

        /// <summary>
        /// ドラッグ&ドロップされた
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDnD_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (files.Length == 1)
            {
                if (Directory.Exists(files[0]))
                {
                    lblFolder.Text = files[0];
                    btnOK.Enabled = true;
                }
                else
                {
                    btnOK.Enabled = false;
                }
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        /// <summary>
        /// D&D しようとマウスカーソルが来た
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDnD_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        /// <summary>
        /// OK が押された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblFolder.Text);
            this.Close();
        }

        /// <summary>
        /// ×が押された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
