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
    public partial class Engine : Form
    {
        public const int  sampleRate = 41000;
        public const short bitsPerSample = 16;

        public Engine()
        {
            InitializeComponent();
        }

        private void MainInterface_KeyDown(object sender, KeyEventArgs e)
        {
            IEnumerable<OSC> oscillators = this.Controls.OfType<OSC>().Where(o => o.On);
            Random rnd = new Random();
            short[] wave = new short[sampleRate];
            byte[] binaryWave = new byte[sampleRate * sizeof(short) ];
            float freq;
            int OscCount = oscillators.Count();
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
            foreach (OSC oscillator in oscillators)
            {
                short tempSample;
                int samplesPerWaveLength = (int)(sampleRate / freq);
                short ampStep = (short)((short.MaxValue * 2) / samplesPerWaveLength);
                switch (oscillator.WaveForm)
                {
                    case WaveForm.Sine:
                        for (int i = 0; i < sampleRate; i++)
                        {
                            wave[i] += Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i) / OscCount);
                        }
                        break;

                    case WaveForm.Square:
                        for (int i = 0; i < sampleRate; i++)
                        {
                            wave[i] += Convert.ToInt16((short.MaxValue * Math.Sign(Math.Sin((Math.PI * 2 * freq) / sampleRate * i))) / OscCount);
                        }
                        break;
                    case WaveForm.Saw:

                        for (int j = 0; j < sampleRate; j++)
                        {
                            tempSample = -short.MaxValue;
                            for (int i = 0; i < samplesPerWaveLength && j < sampleRate; i++)
                            {
                                tempSample += ampStep;
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }
                        }
                        break;
                    case WaveForm.Triangle:

                        tempSample = -short.MaxValue;
                        for (int i = 0; i < sampleRate; i++)
                        {
                            if (Math.Abs(tempSample + ampStep) > short.MaxValue)
                            {
                                ampStep = (short)-ampStep;
                            }
                            tempSample += ampStep;
                            wave[i] += Convert.ToInt16(tempSample / OscCount);

                        }
                        break;
                    case WaveForm.Noise:
                        for (int i = 0; i < sampleRate; i++)
                        {
                            wave[i] += Convert.ToInt16((short)rnd.Next(-short.MaxValue, short.MaxValue) / OscCount);
                        }
                        break;

                    case WaveForm.BudX:

                        for (int j = 0; j < sampleRate; j++)
                        {
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength /2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength /2  && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStep / 2);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }

                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength / 2 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength / 2 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStep / 2);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }

                        }
                        break;
                    case WaveForm.BudX2:

                        for (int j = 0; j < sampleRate; j++)
                        {
                            tempSample = -short.MaxValue;
                            for (int i = 0; i < samplesPerWaveLength / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }
                            for (int i = 0; i < samplesPerWaveLength / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStep / 2);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }

                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength / 2 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }
                            for (int i = 0; i < samplesPerWaveLength / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStep / 2);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }

                        }
                        break;
                    case WaveForm.BudX3:

                        for (int j = 0; j < sampleRate; j++)
                        {
                            tempSample = -short.MaxValue;
                            for (int i = 0; i < samplesPerWaveLength / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }
                            for (int i = 0; i < samplesPerWaveLength / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStep / 2);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }

                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength / 2 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStep / 2);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }

                        }
                        break;

                        case WaveForm.BudX4:

                        for (int j = 0; j < sampleRate; j++)
                        {
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength / 4 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength / 4 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStep / 2);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }

                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength / 4 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength / 4 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStep / 2);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }

                        }
                        break;

                        case WaveForm.BudX5:

                        for (int i = 0; i < sampleRate; i++)
                        {
                            if (Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i)) > 0)
                            {
                                wave[i] += Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 4 * freq) / sampleRate * i) / OscCount);
                            }
                            wave[i] += Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i) / OscCount);
                        }
                        break;


                    case WaveForm.BudX6:

                        for (int i = 0; i < sampleRate; i++)
                        {
                            if (Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i)) > short.MaxValue/2)
                            {
                                wave[i] -= Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i) / OscCount);
                            }
                            if (Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i)) < -short.MaxValue / 2)
                            {
                                wave[i] -= Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i) / OscCount);
                            }
                            wave[i] += Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i) / OscCount);
                        }
                        break;

                    case WaveForm.BudX7:

                        for (int j = 0; j < sampleRate; j++)
                        {
                            tempSample = short.MaxValue;
                            for (int i = 0; i < samplesPerWaveLength / 4 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(4*ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }
                            tempSample = -short.MaxValue;
                            for (int i = 0; i < samplesPerWaveLength / 4 && j < sampleRate; i++)
                            {
                                tempSample += (short)(3*ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }

                            //tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength / 4 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(2*ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }
                            //tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength / 4 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void osc1_Enter(object sender, EventArgs e)
        {

        }
    }
    public enum WaveForm
    {
        Sine, Square, Saw, Triangle, Noise, BudX, BudX2, BudX3, BudX4, BudX5, BudX6, BudX7
    }
}
