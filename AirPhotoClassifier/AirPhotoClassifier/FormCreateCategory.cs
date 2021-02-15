using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirPhotoClassifier
{
    public partial class FormCreateCategory : Form
    {
        public string NameCategory { get; set; }
        public Color ColorCategory { get; set; }
        public FormCreateCategory()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            NameCategory = textBox1.Text;
            if (textBox1.Text != "")
            {
                if(colorDialog.ShowDialog() == DialogResult.OK)
                {
                    ColorCategory = colorDialog.Color;
                }
                DialogResult = DialogResult.OK;
            }
        }
    }
}
