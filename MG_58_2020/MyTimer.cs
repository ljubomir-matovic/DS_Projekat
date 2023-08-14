using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MG_58_2020
{
    public class MyTimer : Timer
    {
        private int counter = 0;
        private Label label;
        public MyTimer(Label label)
        {
            this.counter = 0;
            this.Interval = 1000; // 1 second
            this.label = label;
            this.Tick += Timer_Tick;
            Stop();
        }
        public void Restart()
        {
            Stop();
            counter = -1;
            Timer_Tick(null,null);
            Start();
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            int sekunde = counter % 60;
            string s = (int)(counter / 60) + ":";
            if (sekunde < 10)
                s += "0";
            s += sekunde;
            label.Text = s;
        }
    }
}

