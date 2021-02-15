using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPhotoClassifier.Components
{
    class Category
    {
        public Color Color { get; set; }
        public String Name { get; set; }

        public Category(String name, Color сolor)
        {
            Name = name;
            Color = сolor;
        }

        public override String ToString()
        {
            return Name;
        }
    }
}
