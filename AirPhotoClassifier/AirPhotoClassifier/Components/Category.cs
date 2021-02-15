using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirPhotoClassifier.Components
{
    class Category : ListViewItem
    {
        private List<SuperPixel> _listSuperPixel = new List<SuperPixel>();
        public List<SuperPixel> SuperPixels { get { return _listSuperPixel; } set { _listSuperPixel = value; } }
        public new string Name
        {
            get { return Text; }
            set { Text = value; }
        }
        public Category(String name, Color сolor)
        {
            Name = name;
            BackColor = сolor;
        }
    }
}
