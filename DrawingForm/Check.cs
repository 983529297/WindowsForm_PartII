using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    public partial class Check : Form
    {
        public Check(string name)
        {
            InitializeComponent();
            _label1.Text = _label1.Text + name;
            _label1.Update();
        }

        //回傳
        private void ClickButton2(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }

        //回傳
        private void ClickButton1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
