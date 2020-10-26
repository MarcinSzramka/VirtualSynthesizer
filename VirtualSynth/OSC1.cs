using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
namespace VirtualSynth
{
    public class OSC : GroupBox
        {
        public OSC()
        {
            this.Controls.Add(new Button()
            {
                Name = "Sine",
                Location = new Point(10, 15),
                Text = "Sine",
                Size = new Size(40, 30),
                BackColor = Color.Yellow,
            }) ;

            this.Controls.Add(new Button()
            {
                Name = "Square",
                Location = new Point(60, 15),
                Text = "Square",
                Size = new Size(40, 30),
            });

            this.Controls.Add(new Button()
            {
                Name = "Saw",
                Location = new Point(110, 15),
                Text = "Saw",
                Size = new Size(40, 30),
            });

            this.Controls.Add(new Button()
            {
                Name = "Triangle",
                Location = new Point(160, 15),
                Text = "Triangle",
                Size = new Size(40, 30),
            });

            this.Controls.Add(new Button()
            {
                Name = "Noise",
                Location = new Point(210, 15),
                Text = "Noise",
                Size = new Size(40, 30),
            });
            foreach (Control control in this.Controls)
            {
                control.Size = new Size(50, 30);
                control.Font = new Font("Arial", 6);
                control.Click += WaveButton_Click;
                //control.BackColor = Color.Black;

            }

        }
        public WaveForm WaveForm { get ;private set; }

        private void WaveButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.WaveForm = (WaveForm)Enum.Parse(typeof(WaveForm), button.Text);
            //MessageBox.Show($"chuj" + this.WaveForm);
            foreach (Button otherButtons in this.Controls.OfType<Button>())
            {
                otherButtons.BackColor = Color.Black;
            }
            button.BackColor = Color.Yellow;
        }

        }

}