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
        public const int sampleRate = 41000;
        public const short bitsPerSample = 16;
        //TODO
      // public int volume => ((TrackBar)this.Controls["Volume"]).Value;
       
        public int semitones => ((TrackBar)this.Controls["semiTones"]).Value;
        public Engine()
        {
            InitializeComponent();
        }

        private void MainInterface_KeyDown(object sender, KeyEventArgs e)
        {

            IEnumerable<OSC> oscillators = this.Controls.OfType<OSC>().Where(o => o.On);
            // int volume = this.Controls.OfType<TrackBar>();

            Random rnd = new Random();
            short[] wave = new short[sampleRate];
            byte[] binaryWave = new byte[sampleRate * sizeof(short)];
            float freq;
            int OscCount = oscillators.Count();


            //Keys
            switch (e.KeyCode)
            {
            // Octave1
                case Keys.Z:
                    freq = 64f;
                    break;
                case Keys.X:
                    freq = 72f;
                    break;
                case Keys.C:
                    freq = 81f;
                    break;
                case Keys.V:
                    freq = 88f;
                    break;
                case Keys.B:
                    freq = 96f;
                    break;
                case Keys.N:
                    freq = 108f;
                    break;
                case Keys.M:
                    freq = 121.5f;
                    break;
            // Octave2
                case Keys.A:
                    freq = 128f;
                    break;
                case Keys.S:
                    freq = 144;
                    break;
                case Keys.D:
                    freq = 162f;
                    break;
                case Keys.F:
                    freq = 176f;
                    break;
                case Keys.G:
                    freq = 192f;
                    break;
                case Keys.H:
                    freq = 216f;
                    break;
                case Keys.J:
                    freq = 243f;
                    break;
            // Octave3
                case Keys.Q:
                    freq = 256f;
                    break;
                case Keys.W:
                    freq = 288f;
                    break;
                case Keys.E:
                    freq = 324f;
                    break;
                case Keys.R:
                    freq = 352f;
                    break;
                case Keys.T:
                    freq = 384f;
                    break;
                case Keys.Y:
                    freq = 432f;
                    break;
                case Keys.U:
                    freq = 486f;
                    break;
            // Octave4
                case Keys.D1:
                    freq = 512f;
                    break;
                case Keys.D2:
                    freq = 576f;
                    break;
                case Keys.D3:
                    freq = 648f;
                    break;
                case Keys.D4:
                    freq = 704f;
                    break;
                case Keys.D5:
                    freq = 768f;
                    break;
                case Keys.D6:
                    freq = 864f;
                    break;
                case Keys.D7:
                    freq = 972f;
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
                            wave[i] += Convert.ToInt16((short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i) / OscCount) );
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
                            for (int i = 0; i < samplesPerWaveLength / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }
                            tempSample = 0;
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
                            if (Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i)) > short.MaxValue / 2)
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
                                tempSample -= (short)(4 * ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }
                            tempSample = -short.MaxValue;
                            for (int i = 0; i < samplesPerWaveLength / 4 && j < sampleRate; i++)
                            {
                                tempSample += (short)(3 * ampStep);
                                wave[j++] += Convert.ToInt16(tempSample / OscCount);
                            }

                            //tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLength / 4 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(2 * ampStep);
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
        //TODO możliwość zrobienia obwiedni na masterze

                Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));
            }
            // wave format standard
            short blockAlign = bitsPerSample / 8;
            int subChunkTwoSize = sampleRate * blockAlign;
            MemoryStream f = new MemoryStream();
            BinaryWriter wr = new BinaryWriter(f);
            wr.Write(new[] { 'R', 'I', 'F', 'F' });
            wr.Write(36 + subChunkTwoSize);
            wr.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
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

      

        private void osc1_Enter(object sender, EventArgs e)
        {

        }
    }
    public enum WaveForm
    {
        Sine, Square, Saw, Triangle, Noise, BudX, BudX2, BudX3, BudX4, BudX5, BudX6, BudX7
    }
    public enum TrackBars
    {
        Volume, Semitones
    }
}
