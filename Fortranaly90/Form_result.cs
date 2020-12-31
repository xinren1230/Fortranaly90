using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fortranaly90
{
    public partial class Form_result : Form
    {
        public Form_result(string text)
        {
            InitializeComponent();
            textBox1.Text = text;
        }
    }
}
