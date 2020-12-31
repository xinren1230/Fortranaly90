using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
namespace Fortranaly90
{
    public partial class Fortranaly90 : Form
    {
        public Fortranaly90()
        {
            InitializeComponent();
        }


        private void btn_Browse_Click(object sender, EventArgs e)
        {
            //#选择文件夹路径
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "Select folder";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    textBox_address.Text = dialog.SelectedPath;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            //#选择文件路径
            //using (OpenFileDialog dialog = new OpenFileDialog())
            //{
            //    dialog.Multiselect = true;
            //    if (dialog.ShowDialog() == DialogResult.OK)
            //    {
            //        try
            //        {
            //            textBox_address.Text = dialog.FileName;
            //        }
            //        catch (Exception ex)
            //        {
            //            throw (ex);
            //        }
            //    }
            //}
        }

        //#打开资源管理器
        //private void btn_open2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Process proc = new Process();
        //        proc.StartInfo.FileName = "explorer";
        //        //打开资源管理器
        //        proc.StartInfo.Arguments = @"/select," + "C:";
        //        //选中"notepad.exe"这个程序,即记事本
        //        proc.Start();
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Unexpected error");
        //    }
        //}

        private void Tree_Click(object sender, EventArgs e)
        {
            Tree tree_form = new Tree(textBox_address.Text); 
            tree_form.ShowDialog();
        }

        private void Fortranaly90_Load(object sender, EventArgs e)
        {
            textBox_address.Text = Properties.Settings.Default.Setting;
        }

        private void Fortranaly90_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Setting = textBox_address.Text;
            Properties.Settings.Default.Save();
        }

        private void btn_author_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xinren Chen Email: cxr1230@foxmail.com");
        }
    }
}
