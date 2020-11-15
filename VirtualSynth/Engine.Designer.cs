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
            this.SuspendLayout();
            // 
            // osc3
            // 
            this.osc3.Location = new System.Drawing.Point(12, 230);
            this.osc3.Name = "osc3";
            this.osc3.Size = new System.Drawing.Size(776, 100);
            this.osc3.TabIndex = 2;
            this.osc3.TabStop = false;
            this.osc3.Text = "osc3";
            // 
            // osc2
            // 
            this.osc2.Location = new System.Drawing.Point(12, 119);
            this.osc2.Name = "osc2";
            this.osc2.Size = new System.Drawing.Size(776, 105);
            this.osc2.TabIndex = 1;
            this.osc2.TabStop = false;
            this.osc2.Text = "osc2";
            // 
            // osc1
            // 
            this.osc1.Location = new System.Drawing.Point(12, 12);
            this.osc1.Name = "osc1";
            this.osc1.Size = new System.Drawing.Size(776, 101);
            this.osc1.TabIndex = 0;
            this.osc1.TabStop = false;
            this.osc1.Text = "osc1";
            this.osc1.Enter += new System.EventHandler(this.osc1_Enter);
            // 
            // Engine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

