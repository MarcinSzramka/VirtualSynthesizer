﻿using System;
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
            });

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

            this.Controls.Add(new Button()
            {
                Name = "BudX",
                Location = new Point(260, 15),
                Text = "BudX",
                Size = new Size(40, 30),
            });
            this.Controls.Add(new Button()
            {
                Name = "BudX2",
                Location = new Point(310, 15),
                Text = "BudX2",
                Size = new Size(40, 30),
            });
            this.Controls.Add(new Button()
            {
                Name = "BudX3",
                Location = new Point(360, 15),
                Text = "BudX3",
                Size = new Size(40, 30),
            });
            this.Controls.Add(new Button()
            {
                Name = "BudX4",
                Location = new Point(410, 15),
                Text = "BudX4",
                Size = new Size(40, 30),
            });

            this.Controls.Add(new Button()
            {
                Name = "BudX5",
                Location = new Point(460, 15),
                Text = "BudX5",
                Size = new Size(40, 30),
            });

            this.Controls.Add(new Button()
            {
                Name = "BudX6",
                Location = new Point(510, 15),
                Text = "BudX6",
                Size = new Size(40, 30),
            });
            this.Controls.Add(new Button()
            {
                Name = "BudX7",
                Location = new Point(560, 15),
                Text = "BudX7",
                Size = new Size(40, 30),
            });

            foreach (Control control in this.Controls)
            {
                control.Size = new Size(50, 30);
                control.Font = new Font("Arial", 6);
                control.Click += WaveButton_Click;
            }


            this.Controls.Add(new CheckBox()
            {
                Name = "OscOn",
                Location = new Point(625, 15),
                Size = new Size(40, 30),
                Text = "On",
                Checked = true,
            });
            this.Controls.Add(new TrackBar()
            {
                Name = "Volume",
                Location = new Point(660, 15),
                Size = new Size(110, 50),

            });
            this.Controls.Add(new ListBox()
            {
                Name = "Octave",
                Location = new Point(15,30),

            });
        }
        public WaveForm WaveForm { get ;private set; }
        public bool On => ((CheckBox)this.Controls["OscOn"]).Checked;

        private void WaveButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.WaveForm = (WaveForm)Enum.Parse(typeof(WaveForm), button.Text);
            
            foreach (Button otherButtons in this.Controls.OfType<Button>())
            {
                otherButtons.BackColor = Color.Black;
            }
            button.BackColor = Color.Yellow;
        }

        }

}