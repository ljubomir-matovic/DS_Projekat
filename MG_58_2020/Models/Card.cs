using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_58_2020.Models
{
    public class Card:Field,ICloneable
    {
        public int x;
        public int y;

        public Card(int x, int y):base()
        {
            this.x = x;
            this.y = y;
        }

        public Card(Field field, int x, int y):base()
        {
            this.Opened = field.Opened;
            this.ImageIndex = field.ImageIndex;
            this.x = x;
            this.y = y;
        }

        public override object Clone()
        {
            Card c=new Card(x, y);
            c.Opened = this.Opened;
            c.ImageIndex = this.ImageIndex;
            return c;
        }
    }
}
