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
    public partial class MainInterface : Form
    {
        public const int  sampleRate = 41000;
        public const short bitsPerSample = 16;

        public MainInterface()
        {
            InitializeComponent();
        }

        private void MainInterface_KeyDown(object sender, KeyEventArgs e)
        {
            Random rnd = new Random();
            short[] wave = new short[sampleRate];
            byte[] binaryWave = new byte[sampleRate * sizeof(short) ];
            float freq;
        //Keys
            switch(e.KeyCode)
            {
                case Keys.Z:
                    freq = 65.4f;
                    break;
                case Keys.X:
                    freq = 138.59f;
                    break;
                case Keys.C:
                    freq = 261.62f;
                    break;
                case Keys.V:
                    freq = 523.25f;
                    break;
                case Keys.B:
                    freq = 1046.5f;
                    break;
                case Keys.N:
                    freq = 2093f;
                    break;
                case Keys.M:
                    freq = 4186.01f;
                    break;
                default:
                    return;
            }

         // WaveForms
            foreach (OSC oscillator in this.Controls.OfType<OSC>())
            {
                short tempSample;
                int samplesPerWaveLength = (int)(sampleRate / freq);
                short ampStep = (short)((short.MaxValue * 2) / samplesPerWaveLength);
                switch (oscillator.WaveForm)
                {
                    case WaveForm.Sine:
                      for (int i = 0; i < sampleRate; i++)
                      {
                            wave[i] = Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i));
                      }
                      break;

                    case WaveForm.Square:
                      for (int i = 0; i < sampleRate; i++)
                      {
                          wave[i] = Convert.ToInt16(short.MaxValue * Math.Sign(Math.Sin((Math.PI * 2 * freq) / sampleRate * i)));
                      }
                      break;
                    case WaveForm.Saw:

                        for (int j = 0; j < sampleRate; j++)
                        {
                            
                            
                            tempSample = -short.MaxValue;
                            for (int i = 0; i < samplesPerWaveLength && j<sampleRate; i++)
                            {
                                tempSample += ampStep;
                                wave[j++] = Convert.ToInt16(tempSample);
                            }
                        }
                        break;
                    case WaveForm.Triangle:

                        tempSample = -short.MaxValue;
                        for (int i=0;i< sampleRate;i++)
                        {
                            if (Math.Abs(tempSample + ampStep) > short.MaxValue)
                            {
                                ampStep = (short)-ampStep;
                            }
                            tempSample += ampStep;
                            wave[i] = Convert.ToInt16(tempSample);

                        }
                        break;
                    case WaveForm.Noise:
                        for (int i = 0; i < sampleRate; i++)
                        {
                            wave[i] = (short)rnd.Next(-short.MaxValue, short.MaxValue);
                        }
                        break;

                }

                Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));
            }
        // wave format standard
            short blockAlign = bitsPerSample / 8;
            int subChunkTwoSize = sampleRate * blockAlign;
            MemoryStream f = new MemoryStream();
            BinaryWriter wr = new BinaryWriter(f);
            wr.Write(new[] {'R','I','F','F'});
            wr.Write(36 + subChunkTwoSize);
            wr.Write(new[] {'W','A','V','E','f','m','t',' ' });
            wr.Write(16);
            wr.Write((ushort)1);
            wr.Write((ushort)1);
            wr.Write(sampleRate);
            wr.Write(sampleRate * blockAlign);
            wr.Write(blockAlign);
            wr.Write(bitsPerSample);
            wr.Write(new[] { 'd', 'a', 't', 'a' });
            wr.Write(subChunkTwoSize);
            wr.Write(binaryWave);
            f.Position = 0;

        // wave player
            new SoundPlayer(f).Play();


        }

        private void MainInterface_Load(object sender, EventArgs e)
        {

        }
 
    }
    public enum WaveForm
    {
        Sine, Square, Saw, Triangle, Noise
    }
}
