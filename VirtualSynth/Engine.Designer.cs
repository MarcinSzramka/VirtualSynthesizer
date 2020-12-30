namespace VirtualSynth
{
    partial class Engine
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.osc3 = new VirtualSynth.OSC();
            this.osc2 = new VirtualSynth.OSC();
            this.osc1 = new VirtualSynth.OSC();
            this.osc4 = new VirtualSynth.OSC();
            this.osc5 = new VirtualSynth.OSC();
            this.SuspendLayout();
            // 
            // osc3
            // 
            this.osc3.Location = new System.Drawing.Point(12, 200);
            this.osc3.Name = "osc3";
            this.osc3.Size = new System.Drawing.Size(1025, 87);
            this.osc3.TabIndex = 2;
            this.osc3.TabStop = false;
            this.osc3.Text = "osc3";
            this.osc3.TrackBars = VirtualSynth.TrackBars.Volume;
            // 
            // osc2
            // 
            this.osc2.Location = new System.Drawing.Point(12, 105);
            this.osc2.Name = "osc2";
            this.osc2.Size = new System.Drawing.Size(1025, 89);
            this.osc2.TabIndex = 1;
            this.osc2.TabStop = false;
            this.osc2.Text = "osc2";
            this.osc2.TrackBars = VirtualSynth.TrackBars.Volume;
            // 
            // osc1
            // 
            this.osc1.Location = new System.Drawing.Point(12, 12);
            this.osc1.Name = "osc1";
            this.osc1.Size = new System.Drawing.Size(1025, 87);
            this.osc1.TabIndex = 0;
            this.osc1.TabStop = false;
            this.osc1.Text = "osc1";
            this.osc1.TrackBars = VirtualSynth.TrackBars.Volume;
            this.osc1.Enter += new System.EventHandler(this.osc1_Enter);
            // 
            // osc4
            // 
            this.osc4.Location = new System.Drawing.Point(12, 293);
            this.osc4.Name = "osc4";
            this.osc4.Size = new System.Drawing.Size(1025, 86);
            this.osc4.TabIndex = 3;
            this.osc4.TabStop = false;
            this.osc4.Text = "osc4";
            this.osc4.TrackBars = VirtualSynth.TrackBars.Volume;
            // 
            // osc5
            // 
            this.osc5.Location = new System.Drawing.Point(12, 385);
            this.osc5.Name = "osc5";
            this.osc5.Size = new System.Drawing.Size(1025, 86);
            this.osc5.TabIndex = 4;
            this.osc5.TabStop = false;
            this.osc5.Text = "osc5";
            this.osc5.TrackBars = VirtualSynth.TrackBars.Volume;
            // 
            // Engine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 502);
            this.Controls.Add(this.osc5);
            this.Controls.Add(this.osc4);
            this.Controls.Add(this.osc3);
            this.Controls.Add(this.osc2);
            this.Controls.Add(this.osc1);
            this.KeyPreview = true;
            this.Name = "Engine";
            this.Text = "Virtual Synthesizer";
            this.Load += new System.EventHandler(this.MainInterface_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainInterface_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private OSC osc1;
        private OSC osc2;
        private OSC osc3;
        private OSC osc4;
        private OSC osc5;
    }
}

