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
        public const int sampleRate = 44100;
        public const short bitsPerSample = 16;
        public int sineVolume = 80;
        int sinePitch = 50;
        public int squareVolume = 80;
        int squarePitch = 50;
        public int sawVolume = 80;
        int sawPitch = 50;
        public int triangleVolume = 80;
        int trianglePitch = 50;
        public int noiseVolume = 80;
        public int budXVolume = 80;
        int budXPitch = 50;
        public int budX2Volume = 80;
        int budX2Pitch = 50;
        public int budX3Volume = 80;
        int budX3Pitch = 50;
        public int budX4Volume = 80;
        int budX4Pitch = 50;
        public int budX5Volume = 80;
        int budX5Pitch = 50;
        public int budX6Volume = 80;
        int budX6Pitch = 50;
        public int budX7Volume = 80;
        int budX7Pitch = 50;
        public int budX8Volume = 80;
        int budX8Pitch = 50;
        public int budX9Volume = 80;
        int budX9Pitch = 50;
        public int budX10Volume = 80;
        int budX10Pitch = 50;
        public int sineAtt = 80;
        public int sineModul = 0;
        public int budx5Modul = 0;
        public int budx6Modul = 0;
        public int budx8Modul = 0;
        public int budx9Modul = 0;
        public int atk = 100;
        public int dcy = 100;


        public Engine()
        {
            InitializeComponent();
        }

        private void MainInterface_KeyDown(object sender, KeyEventArgs e)
        {
            IEnumerable<OSC> oscillators = this.Controls.OfType<OSC>().Where(o => o.On);
            
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

               

                int samplesPerWaveLengthsaw = (int)(sampleRate / (freq + ((sawPitch - 50) * 10.5946309436) / 100) );
                short ampStepsaw = (short)((short.MaxValue * 2) / samplesPerWaveLengthsaw);

                int samplesPerWaveLengthtri = (int)(sampleRate / (freq + ((trianglePitch - 50) * 10.5946309436) / 100));
                short ampSteptri = (short)((short.MaxValue * 2) / samplesPerWaveLengthtri);

                int samplesPerWaveLengthbudX = (int)(sampleRate / (freq + ((budXPitch - 50) * 10.5946309436) / 100));
                short ampStepbudX = (short)((short.MaxValue * 2) / samplesPerWaveLengthbudX);

                int samplesPerWaveLengthbudX2 = (int)(sampleRate / (freq + ((budX2Pitch - 50) * 10.5946309436) / 100));
                short ampStepbudX2 = (short)((short.MaxValue * 2) / samplesPerWaveLengthbudX2);

                int samplesPerWaveLengthbudX3 = (int)(sampleRate / (freq + ((budX3Pitch - 50) * 10.5946309436) / 100));
                short ampStepbudX3 = (short)((short.MaxValue * 2) / samplesPerWaveLengthbudX3);

                int samplesPerWaveLengthbudX4 = (int)(sampleRate / (freq + ((budX4Pitch - 50) * 10.5946309436) / 100));
                short ampStepbudX4 = (short)((short.MaxValue * 2) / samplesPerWaveLengthbudX4);

                int samplesPerWaveLengthbudX7 = (int)(sampleRate / (freq + ((budX7Pitch - 50) * 10.5946309436) / 100));
                short ampStepbudX7 = (short)((short.MaxValue * 2) / samplesPerWaveLengthbudX7);

                int samplesPerWaveLengthbudX10 = (int)(sampleRate / (freq + ((budX10Pitch - 50) * 10.5946309436) / 100));
                short ampStepbudX10 = (short)((short.MaxValue * 2) / samplesPerWaveLengthbudX10);

                
               
                


                switch (oscillator.WaveForm)
                {

                    case WaveForm.Sine:


                        
                        for (int i = 0; i < sampleRate; i++)
                       
                        {

                            wave[i] += Convert.ToInt16(9 * ((short.MaxValue * Math.Sin((Math.PI * 2 * (freq + ((sinePitch - 50) *10.5946309436)/100)) / sampleRate * i) * sineVolume) / (100 * (OscCount) ))/12);

                            wave[i] += Convert.ToInt16((short.MaxValue)* Math.Sin(Math.PI * 2 * (freq + (sineModul* 2)) /  sampleRate * i)/10 );
                            //(sineModul/100)))
                        }
                        break;

                    case WaveForm.Square:
                        for (int i = 0; i < sampleRate; i++)
                        {
                            wave[i] += Convert.ToInt16((short.MaxValue * Math.Sign(Math.Sin((Math.PI * 2 * (freq +((squarePitch-50) * 10.5946309436) / 100)) / sampleRate * i) ) * squareVolume) / (100 * (OscCount)));
                        }
                        break;
                    case WaveForm.Saw:

                        for (int j = 0; j < sampleRate; j++)
                        {
                            tempSample = -short.MaxValue;
                            for (int i = 0; i < samplesPerWaveLengthsaw && j < sampleRate; i++)
                            {
                                tempSample += ampStepsaw;
                                wave[j++] += Convert.ToInt16((tempSample * sawVolume) / (100 * OscCount));
                            }
                        }
                        break;
                    case WaveForm.Triangle:

                        tempSample = -short.MaxValue;
                        for (int i = 0; i < sampleRate; i++)
                        {
                            if (Math.Abs(tempSample + ampSteptri) > short.MaxValue)
                            {
                                ampSteptri = (short)-ampSteptri;
                            }
                            tempSample += ampSteptri;
                            wave[i] += Convert.ToInt16((tempSample*triangleVolume) /(100* OscCount));

                        }
                        break;
                    case WaveForm.Noise:
                        for (int i = 0; i < sampleRate; i++)
                        {
                            wave[i] += Convert.ToInt16((short)rnd.Next(-short.MaxValue, short.MaxValue) * noiseVolume /(100* OscCount));
                        }
                        break;

                    case WaveForm.BudX:

                        for (int j = 0; j < sampleRate; j++)
                        {
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLengthbudX / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStepbudX);
                                wave[j++] += Convert.ToInt16(tempSample* budXVolume /(100* OscCount));
                            }
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLengthbudX / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStepbudX / 2);
                                wave[j++] += Convert.ToInt16(tempSample * budXVolume /(100* OscCount));
                            }

                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLengthbudX / 2 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStepbudX);
                                wave[j++] += Convert.ToInt16(tempSample * budXVolume /(100* OscCount));
                            }
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLengthbudX / 2 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStepbudX / 2);
                                wave[j++] += Convert.ToInt16(tempSample * budXVolume /(100* OscCount));
                            }

                        }
                        break;
                    case WaveForm.BudX2:

                        for (int j = 0; j < sampleRate; j++)
                        {
                            tempSample = -short.MaxValue;
                            for (int i = 0; i < samplesPerWaveLengthbudX2 / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStepbudX2);
                                wave[j++] += Convert.ToInt16((tempSample*budX2Volume) /(100* OscCount));
                            }
                            for (int i = 0; i < samplesPerWaveLengthbudX2 / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStepbudX2 / 2);
                                wave[j++] += Convert.ToInt16((tempSample*budX2Volume) /(100* OscCount));
                            }

                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLengthbudX2 / 2 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStepbudX2);
                                wave[j++] += Convert.ToInt16((tempSample* budX2Volume) /(100* OscCount));
                            }
                            for (int i = 0; i < samplesPerWaveLengthbudX2 / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStepbudX2 / 2);
                                wave[j++] += Convert.ToInt16((tempSample* budX2Volume) /(100* OscCount));
                            }

                        }
                        break;
                    case WaveForm.BudX3:

                        for (int j = 0; j < sampleRate; j++)
                        {
                            tempSample = -short.MaxValue;
                            for (int i = 0; i < samplesPerWaveLengthbudX3 / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStepbudX3);
                                wave[j++] += Convert.ToInt16((tempSample*budX3Volume ) /(100* OscCount));
                            }
                            for (int i = 0; i < samplesPerWaveLengthbudX3 / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStepbudX3 / 2);
                                wave[j++] += Convert.ToInt16((tempSample * budX3Volume) / (100 * OscCount));
                            }

                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLengthbudX3 / 2 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStepbudX3);
                                wave[j++] += Convert.ToInt16((tempSample * budX3Volume) / (100 * OscCount));
                            }
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLengthbudX3 / 2 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStepbudX3 / 2);
                                wave[j++] += Convert.ToInt16((tempSample * budX3Volume) / (100 * OscCount));
                            }

                        }
                        break;

                    case WaveForm.BudX4:

                        for (int j = 0; j < sampleRate; j++)
                        {
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLengthbudX4 / 4 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStepbudX4);
                                wave[j++] += Convert.ToInt16((tempSample * budX4Volume) / (100 * OscCount));
                            }
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLengthbudX4 / 4 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStepbudX4 / 2);
                                wave[j++] += Convert.ToInt16((tempSample * budX4Volume) / (100 * OscCount));
                            }

                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLengthbudX4 / 4 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStepbudX4);
                                wave[j++] += Convert.ToInt16((tempSample * budX4Volume) / (100 * OscCount));
                            }
                            tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLengthbudX4 / 4 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStepbudX4 / 2);
                                wave[j++] += Convert.ToInt16((tempSample * budX4Volume) / (100 * OscCount));
                            }

                        }
                        break;

                    case WaveForm.BudX5:

                        for (int i = 0; i < sampleRate; i++)
                        {

                            if (Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * (freq + ((budX5Pitch - 50) * 10.5946309436) / 100)) / sampleRate * i)) > 0)
                            {
                                wave[i] += Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 4 * (freq + ((budX5Pitch - 50) * 10.5946309436) / 100)) / sampleRate * i) * budX5Volume / (100 * OscCount));
                            }
                            else
                            {
                                wave[i] += Convert.ToInt16(9 * short.MaxValue * Math.Sin((Math.PI * 2 * (((budX5Pitch - 50) * 10.5946309436) + freq) / 100) / sampleRate * i) * budX5Volume / (100 * OscCount) / 12);
                                wave[i] += Convert.ToInt16((short.MaxValue) * Math.Sin(Math.PI * 2 * (freq + (budx5Modul * 2)) / sampleRate * i) * budX5Volume / (100 * 10));
                            }

                        }
                        break;


                    case WaveForm.BudX6:

                        for (int i = 0; i < sampleRate; i++)
                        //{
                            //(freq + ((budX6Pitch - 50) * 10.5946309436))
                            //    if (Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i)) > short.MaxValue / 2)
                            //    {
                            //        wave[i] -= Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * (freq + ((budX6Pitch - 50) * 10.5946309436)) / 100) / sampleRate * i) * budX6Volume / (100 * OscCount));
                            //    }
                            //    if (Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i)) < -short.MaxValue / 2)
                            //    {
                            //        wave[i] -= Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * (freq + ((budX6Pitch - 50) * 10.5946309436)) / 100) / sampleRate * i) * budX6Volume / (100 * OscCount));
                            //    }
                            //    else
                            //    {
                            //        wave[i] += Convert.ToInt16(9 * short.MaxValue * Math.Sin((Math.PI * 2 * (freq + ((budX6Pitch - 50) * 10.5946309436)) / 100) / sampleRate * i) * budX6Volume / (100 * OscCount) / 12);
                            //        wave[i] += Convert.ToInt16((short.MaxValue) * Math.Sin(Math.PI * 2 * (freq + (budx6Modul * 2)) / sampleRate * i) / 10);
                            //    }
                            //}

                            {

                                if (Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i)) > short.MaxValue / 2)
                                {
                                    wave[i] -= Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * (freq + ((budX6Pitch - 50) * 10.5946309436)) / 100) / sampleRate * i) * budX6Volume / (100 * OscCount));
                                     wave[i] -= Convert.ToInt16((short.MaxValue) * Math.Sin(Math.PI * 2 * (freq + (budx6Modul * 12)) / sampleRate * i)* budX6Volume / 1000);
                                }
                                if (Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i)) < -short.MaxValue / 2)
                                {
                                    wave[i] -= Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * (freq + ((budX6Pitch - 50) * 10.5946309436)) / 100) / sampleRate * i) * budX6Volume / (100 * OscCount));
                                    wave[i] -= Convert.ToInt16((short.MaxValue) * Math.Sin(Math.PI * 2 * (freq + (budx6Modul * 12)) / sampleRate * i) * budX6Volume / 1000);
                                }
                                else
                                {
                                    wave[i] += Convert.ToInt16(9 * short.MaxValue * Math.Sin((Math.PI * 2 * (freq + ((budX6Pitch - 50) * 10.5946309436)) / 100) / sampleRate * i) * budX6Volume / (100 * OscCount) / 12);
                                    wave[i] += Convert.ToInt16((short.MaxValue) * Math.Sin(Math.PI * 2 * (freq + (budx6Modul * 12))  / sampleRate * i) * budX6Volume / 1000);
                                }
                            }
                            break;

                    case WaveForm.BudX7:

                        for (int j = 0; j < sampleRate; j++)
                        {
                            tempSample = short.MaxValue;
                            for (int i = 0; i < samplesPerWaveLengthbudX7 / 4 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(4 * ampStepbudX7);
                                wave[j++] += Convert.ToInt16(tempSample *budX7Volume /(100* OscCount));
                            }
                            tempSample = -short.MaxValue;
                            for (int i = 0; i < samplesPerWaveLengthbudX7 / 4 && j < sampleRate; i++)
                            {
                                tempSample += (short)(3 * ampStepbudX7);
                                wave[j++] += Convert.ToInt16(tempSample * budX7Volume / (100 * OscCount));
                            }

                            //tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLengthbudX7 / 4 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(2 * ampStepbudX7);
                                wave[j++] += Convert.ToInt16(tempSample * budX7Volume / (100 * OscCount));
                            }
                            //tempSample = 0;
                            for (int i = 0; i < samplesPerWaveLengthbudX7 / 4 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStepbudX7);
                                wave[j++] += Convert.ToInt16(tempSample * budX7Volume / (100 * OscCount));
                            }

                        }
                        break;

                    case WaveForm.BudX8:


                        for (int i = 0; i < sampleRate; i++)
                        {

                            if (Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * (freq + ((budX8Pitch - 50) * 10.5946309436) / 100)) / sampleRate * i)) < 0)
                            {
                                wave[i] += Convert.ToInt16(9*short.MaxValue * Math.Sin(1.5 * (Math.PI * 2 * (freq + ((budX8Pitch - 50) * 10.5946309436) / 100)) / sampleRate * i) * budX8Volume / (100 * OscCount)/12);
                                wave[i] += Convert.ToInt16((short.MaxValue) * Math.Sin(1.5 * Math.PI * 2 * (freq + (budx8Modul * 2)) / sampleRate * i) *budX8Volume / (1000));
                            }
                            else
                            {
                                wave[i] += Convert.ToInt16(9*short.MaxValue * Math.Sin(0.5 * (Math.PI * 2 * (freq + ((budX8Pitch - 50) * 10.5946309436) / 100)) / sampleRate * i) * budX8Volume / (100 * OscCount)/12);
                                wave[i] += Convert.ToInt16((short.MaxValue) * Math.Sin(0.5 * Math.PI * 2 * (freq + (budx8Modul * 2)) / sampleRate * i) * budX8Volume / 1000);
                            }
                            }
                       
                        break;

                    case WaveForm.BudX9:


                        for (int i = 0; i < sampleRate; i++)
                        {
                            if (Convert.ToInt16(short.MaxValue * Math.Sin((Math.PI * 2 * freq) / sampleRate * i)) >= 0)
                            {
                                wave[i] += Convert.ToInt16(9*short.MaxValue * Math.Sin(1.5 * (Math.PI * 2 * (freq + ((budX9Pitch - 50) * 10.5946309436)/100)) / sampleRate * i)* (budX9Volume) /(100* OscCount)/12);
                                wave[i] += Convert.ToInt16((short.MaxValue) * Math.Sin(1.5 * Math.PI * 2 * (freq + (budx9Modul * 2)) / sampleRate * i) * budX9Volume / 1000);
                            }
                            wave[i] -= Convert.ToInt16(9*short.MaxValue * Math.Sin(0.5 * (Math.PI * 2 * (freq + ((budX9Pitch - 50) * 10.5946309436)/100)) / sampleRate * i) * (budX9Volume) /(100* OscCount)/12);
                            wave[i] -= Convert.ToInt16((short.MaxValue) * Math.Sin(0.5 * Math.PI * 2 * (freq + (budx9Modul * 2)) / sampleRate * i) * budX9Volume / 1000);
                        }
                        
                        break;

                    case WaveForm.BudX10:


                        for (int j = 0; j < sampleRate; j++)
                        {
                            tempSample = short.MaxValue;
                            for (int i = 0; i < samplesPerWaveLengthbudX10 / 6 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStepbudX10*3);
                                wave[j++] += Convert.ToInt16(tempSample *budX10Volume /(100* OscCount));
                            }

                            for (int i = 0; i < samplesPerWaveLengthbudX10 / 6 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStepbudX10);
                                wave[j++] += Convert.ToInt16(tempSample * budX10Volume / (100 * OscCount));
                            }
                           
                            for (int i = 0; i < samplesPerWaveLengthbudX10 / 6 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(ampStepbudX10);
                                wave[j++] += Convert.ToInt16(tempSample * budX10Volume / (100 * OscCount));
                            }
                            
                            for (int i = 0; i < samplesPerWaveLengthbudX10 / 6 && j < sampleRate; i++)
                            {
                                tempSample += (short)(ampStepbudX10 * 3);
                                wave[j++] += Convert.ToInt16(tempSample * budX10Volume / (100 * OscCount));
                            }

                            for (int i = 0; i < samplesPerWaveLengthbudX10 / 6 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(3 * ampStepbudX10);
                                wave[j++] += Convert.ToInt16(tempSample * budX10Volume / (100 * OscCount));
                            }

                            for (int i = 0; i < samplesPerWaveLengthbudX10 / 18 && j < sampleRate; i++)
                            {
                                tempSample += (short)(2 * ampStepbudX10);
                                wave[j++] += Convert.ToInt16(tempSample * budX10Volume / (100 * OscCount));
                            }
                            for (int i = 0; i < samplesPerWaveLengthbudX10 / 18 && j < sampleRate; i++)
                            {
                                tempSample -= (short)(2 * ampStepbudX10);
                                wave[j++] += Convert.ToInt16(tempSample * budX10Volume / (100 * OscCount));
                            }
                            for (int i = 0; i < samplesPerWaveLengthbudX10 / 18 && j < sampleRate; i++)
                            {
                                tempSample += (short)(3 * ampStepbudX10);
                                wave[j++] += Convert.ToInt16(tempSample * budX10Volume / (100 * OscCount));
                            }
                        }
                        break;

                }

                for (int j = 0; j < (sampleRate); j++)
                {
                    wave[j] = Convert.ToInt16(Convert.ToInt32(wave[j] * sineAtt) / 100);
                }


                if (atk >= 50)
                {
                    for (int j = 0; j < sampleRate ; j++)
                    {

                        wave[j] = Convert.ToInt16(Convert.ToInt32((wave[j] * j) / sampleRate));

                    }
                }


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

            
            new SoundPlayer(f).Play();

        }

        private void MainInterface_Load(object sender, EventArgs e)
        {
            
        }
       

        private void osc1_Enter(object sender, EventArgs e)
        {
           



        }

        private void osc2_Enter(object sender, EventArgs e)
        {
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
             sineVolume = SineVolume.Value;
        }
        private void sinePitch_Scroll(object sender, EventArgs e)
        {
            sinePitch = SinePitch.Value;
        }
        private void squareVolume_Scroll(object sender, EventArgs e)
        {
            squareVolume = SquareVolume.Value;
        }
        private void sqrePitch_Scroll(object sender, EventArgs e)
        {
            squarePitch = SqrePitch.Value;
        }
        private void sawVolume_Scroll(object sender, EventArgs e)
        {
            sawVolume = SawVolume.Value;
        }
        private void sawPitch_Scroll(object sender, EventArgs e)
        {
            sawPitch = SawPitch1.Value;
        }
        private void triangleVolume_Scroll(object sender, EventArgs e)
        {
            triangleVolume = TriangleVolume.Value;
        }
        private void trianglePitch_Scroll(object sender, EventArgs e)
        {
            trianglePitch = TrianglePitch1.Value;
        }
        private void noiseVolume_Scroll(object sender, EventArgs e)
        {
            noiseVolume = NoiseVolume.Value;
        }
        private void BudXVolume_Scroll(object sender, EventArgs e)
        {
            budXVolume = BudXVolume.Value;
        }
        private void budXPitch_Scroll(object sender, EventArgs e)
        {
            budXPitch = BudXPitch.Value;
        }
        private void BudX2Volume_Scroll(object sender, EventArgs e)
        {
            budX2Volume = BudX2Volume.Value;
        }
        private void budX2Pitch_Scroll(object sender, EventArgs e)
        {
            budX2Pitch = BudX2Pitch.Value;
        }
        private void BudX3Volume_Scroll(object sender, EventArgs e)
        {
            budX3Volume = BudX3Volume.Value;
        }
        private void budX3Pitch_Scroll(object sender, EventArgs e)
        {
            budX3Pitch = BudX31Pitch.Value;
        }
        private void BudX4Volume_Scroll(object sender, EventArgs e)
        {
            budX4Volume = BudX4Volume.Value;
        }
        private void budX4Pitch_Scroll(object sender, EventArgs e)
        {
            budX4Pitch = BudX4Pitch.Value;
        }
        private void BudX5Volume_Scroll(object sender, EventArgs e)
        {
            budX5Volume = BudX5Volume.Value;
        }
        private void budX5Pitch_Scroll(object sender, EventArgs e)
        {
            budX5Pitch = BudX5Pitch.Value;
        }
        private void BudX6Volume_Scroll(object sender, EventArgs e)
        {
            budX6Volume = BudX6Volume.Value;
        }
        private void budX6Pitch_Scroll(object sender, EventArgs e)
        {
            budX6Pitch = BudX6Pitch.Value;
        }
        private void BudX7Volume_Scroll(object sender, EventArgs e)
        {
            budX7Volume = BudX7Volume.Value;
        }
        private void budX7Pitch_Scroll(object sender, EventArgs e)
        {
            budX7Pitch = BudX7Pitch.Value;
        }
        private void BudX8Volume_Scroll(object sender, EventArgs e)
        {
            budX8Volume = BudX8Volume.Value;
        }
        private void budX8Pitch_Scroll(object sender, EventArgs e)
        {
            budX8Pitch = BudX8Pitch.Value;
        }
        private void BudX9Volume_Scroll(object sender, EventArgs e)
        {
            budX9Volume = BudX9Volume.Value;
        }
        private void budX9Pitch_Scroll(object sender, EventArgs e)
        {
            budX9Pitch = BudX9Pitch.Value;
        }
        private void BudX10Volume_Scroll(object sender, EventArgs e)
        {
            budX10Volume = BudX10Volume.Value;
        }
        private void budX10Pitch_Scroll(object sender, EventArgs e)
        {
            budX10Pitch = BudX10Pitch.Value;
        }
        private void sineAttack_Scroll(object sender, EventArgs e)
        {
            sineAtt = sineAttack.Value;
        }
        private void sineMod_Scroll(object sender, EventArgs e)
        {
            sineModul = sineMod.Value;
        }
        private void budx5Mod_Scroll(object sender, EventArgs e)
        {
            budx5Modul = budx5Module.Value;
        }
        private void budx6Mod_Scroll(object sender, EventArgs e)
        {
            budx6Modul = budx6Module.Value;
        }
        private void budx8Mod_Scroll(object sender, EventArgs e)
        {
            budx8Modul = budx8Module.Value;
        }
        private void budx9Mod_Scroll(object sender, EventArgs e)
        {
            budx9Modul = budx9Module.Value;
        }

        private void Attack_Scroll(object sender, EventArgs e)
        {
            atk = (short)attack.Value;
        }

        private void Decay_Scroll(object sender, EventArgs e)
        {
            dcy = (short)decay.Value;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
    public enum WaveForm
    {
        Sine, Square, Saw, Triangle, Noise, BudX, BudX2, BudX3, BudX4, BudX5, BudX6, BudX7, BudX8, BudX9, BudX10
    }
    public enum TrackBars
    {
        Volume, Semitones
    }
}
