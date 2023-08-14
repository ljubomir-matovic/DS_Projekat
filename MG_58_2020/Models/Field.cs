using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_58_2020.Models
{
    public class Field:ICloneable
    {
        public bool Opened;
        public int ImageIndex;
        public Field() { }
        public Field(int ImageIndex)
        {
            this.ImageIndex = ImageIndex;
            Opened = false;
        }

        public virtual object Clone()
        {
            Field field = new Field(this.ImageIndex);
            field.Opened = this.Opened;
            return field;
        }
    }
}
