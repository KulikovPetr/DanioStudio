using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using System.Diagnostics;

namespace DanioRecorder
{
    
    public partial class MainForm : Form
    {
        

        [DllImport("kernel32.dll")] static extern bool AllocConsole();
        [DllImport("kernel32.dll")] static extern bool FreeConsole();
        int m_Cams = 4, m_Length = 840, m_Interval = 900;
        int m_CurrTime, m_NextTime, m_StartTime = 32400, m_StopTime = 75600;
        int Relay_1_ON_Time, Relay_2_ON_Time, Relay_1_OFF_Time, Relay_2_OFF_Time;
        bool m_isSet;
        bool m_Pause;
        string sSelectedPath;
        Capture previev_capture;
        Mat previev_Frame;
        Image imggrey;
        FolderBrowserDialog result_out = new FolderBrowserDialog();
        //SavesCounter m_Counter = new SavesCounter();
        public MainForm()
        {
            InitializeComponent();
            //============================== загрузка порядка камер
            //string CamerasConfigLine = "";
            using (StreamReader sr = new StreamReader("CamerasConfig.txt"))
            {
                textBox0.Text = sr.ReadLine();
                textBox1.Text = sr.ReadLine();
                textBox2.Text = sr.ReadLine();
                textBox3.Text = sr.ReadLine();
                textBox4.Text = sr.ReadLine();
                textBox5.Text = sr.ReadLine();
                textBox6.Text = sr.ReadLine();
                textBox7.Text = sr.ReadLine();
            }
            //================================
            m_isSet = false;
            m_Pause = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FreeConsole();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            string[] s = txtSet.Text.Split(' ');

            string Relay_1_ON = Relay_1_on_txtbox.Text;
            string Relay_2_ON = Relay_2_on_txtbox.Text;
            string Relay_1_OFF = Relay_1_off_txtbox.Text;
            string Relay_2_OFF = Relay_1_off_txtbox.Text;

            Relay_1_ON_Time = Converter(Relay_1_ON);
            Relay_2_ON_Time = Converter(Relay_2_ON);
            Relay_1_OFF_Time = Converter(Relay_1_OFF);
            Relay_2_OFF_Time = Converter(Relay_2_OFF);

            if (s.Length == 5)
            {
                m_StartTime = Converter(s[0]);
                m_StopTime = Converter(s[1]);
                m_Cams = int.Parse(s[2]);
                m_Length = int.Parse(s[3]);
                m_Interval = int.Parse(s[4]);
                m_NextTime = m_StartTime;
                m_isSet = true;
                btnSet.BackColor = Color.LightPink;

                //Console.WriteLine("start time: " + m_StartTime.ToString() + "\nEnd time: " + m_StopTime.ToString());
                btnStart.Enabled = true;
            }
            else
            {
                txtTime.Text = "error please retape";
                m_isSet = false;
            }
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
        
        txtTime.Text = DateTime.Now.ToLongTimeString();
            m_CurrTime = Converter(DateTime.Now.ToShortTimeString());
            //=============================================== Таймеры для реле
            if ((m_CurrTime == Relay_1_ON_Time) && (Relay_checkbox.Checked == true))
            {
                string cmd = "RelayCmd ON=1";

                var proc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @Relay_path_textbox.Text,
                    FileName = @Relay_path_textbox.Text+"RelayCmd.exe",
                    Arguments = "/c " + cmd,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc);
            }
            if ((m_CurrTime == Relay_2_ON_Time) && (Relay_checkbox.Checked == true))
            {
                string cmd = "RelayCmd ON=2";

                var proc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @Relay_path_textbox.Text,
                    FileName = @Relay_path_textbox.Text+"RelayCmd.exe",
                    Arguments = "/c " + cmd,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc);
            }
            if ((m_CurrTime == Relay_1_OFF_Time) && (Relay_checkbox.Checked == true))
            {
                string cmd = "RelayCmd OFF=1";

                var proc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @Relay_path_textbox.Text,
                    FileName = @Relay_path_textbox.Text+"RelayCmd.exe",
                    Arguments = "/c " + cmd,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc);
            }
            if ((m_CurrTime == Relay_2_OFF_Time) && (Relay_checkbox.Checked == true))
            {
                string cmd = "RelayCmd OFF=2";

                var proc = new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    WorkingDirectory = @Relay_path_textbox.Text,
                    FileName = @Relay_path_textbox.Text+"RelayCmd.exe",
                    Arguments = "/c " + cmd,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process.Start(proc);
            }
            //======================================================
            if (m_CurrTime == m_StopTime)
                m_NextTime = m_StartTime;
            if(m_CurrTime == m_NextTime)
            {
                if (!m_Pause)
                {
                    //if (m_Counter.saves == 7)
                    for (int i = 0; i < m_Cams; i++)
                    {
                       
                        Camera cam = new Camera(i, m_Interval, sSelectedPath, Convert.ToInt32(textBox0.Text), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text));
                        Thread th = new Thread(new ThreadStart(cam.Run));
                        th.Start();
                        //Task.Delay(100);


                    }
                }
                else
                {
                    Console.WriteLine("The time interval was skipped. The program is on pause. Are aquariums being serviced now?");
                }
                m_NextTime += m_Length;
                if (m_NextTime >= 86400)
                    m_NextTime = m_NextTime - 86400;
                Console.WriteLine("start time: " + m_StartTime.ToString() + "\nNext time: " + m_NextTime.ToString() + "\nStop time: " + m_StopTime.ToString());
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            m_Pause = true;
            btnPause.BackColor = Color.LightPink;
            btnResume.BackColor = Color.LightGray;
            if ((m_NextTime - m_CurrTime) >= 59)
                Console.WriteLine("Pause set. Please wait until the end of recording files. \n");
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            m_Pause = false;
            btnPause.BackColor = Color.LightGray;
            btnResume.BackColor = Color.LightPink;
        }

        private void ChooseFolderButton_Click(object sender, EventArgs e)
        {
            if (result_out.ShowDialog() == DialogResult.OK)
            {
                ChooseFolderButton.Enabled = false;
                btnSet.Enabled = true;
                sSelectedPath = result_out.SelectedPath;
                //Console.WriteLine('\n' + sSelectedPath);
                sSelectedPath = sSelectedPath.Replace(@"\", "/");
                //Console.WriteLine('\n' + sSelectedPath);
            }
        }

        private void Textbox_0_click(object sender, EventArgs e)
        {
           // previev_capture.Dispose();
            previev_capture = new Capture(0);
            previev_Frame = new Mat();
            previev_capture.Retrieve(previev_Frame);
            pictureBox1.Image = previev_Frame.ToImage<Bgr, byte>().Bitmap;
            previev_capture.Dispose();
            previev_Frame.Dispose();
  
            //imggrey = previev_Frame.ToImage<Bgr, bool>();
            //pictureBox1.Image = previev_Frame.ToImage<Gray, bool>().Bitmap;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            previev_capture = new Capture(1);
            previev_Frame = new Mat();
            previev_capture.Retrieve(previev_Frame);
            pictureBox1.Image = previev_Frame.ToImage<Bgr, byte>().Bitmap;
            previev_capture.Dispose();
            previev_Frame.Dispose();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            previev_capture = new Capture(2);
            previev_Frame = new Mat();
            previev_capture.Retrieve(previev_Frame);
            pictureBox1.Image = previev_Frame.ToImage<Bgr, byte>().Bitmap;
            previev_capture.Dispose();
            previev_Frame.Dispose();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            previev_capture = new Capture(3);
            previev_Frame = new Mat();
            previev_capture.Retrieve(previev_Frame);
            pictureBox1.Image = previev_Frame.ToImage<Bgr, byte>().Bitmap;
            previev_capture.Dispose();
            previev_Frame.Dispose();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            previev_capture = new Capture(4);
            previev_Frame = new Mat();
            previev_capture.Retrieve(previev_Frame);
            pictureBox1.Image = previev_Frame.ToImage<Bgr, byte>().Bitmap;
            previev_capture.Dispose();
            previev_Frame.Dispose();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            previev_capture = new Capture(5);
            previev_Frame = new Mat();
            previev_capture.Retrieve(previev_Frame);
            pictureBox1.Image = previev_Frame.ToImage<Bgr, byte>().Bitmap;
            previev_capture.Dispose();
            previev_Frame.Dispose();
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            previev_capture = new Capture(6);
            previev_Frame = new Mat();
            previev_capture.Retrieve(previev_Frame);
            pictureBox1.Image = previev_Frame.ToImage<Bgr, byte>().Bitmap;
            previev_capture.Dispose();
            previev_Frame.Dispose();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            previev_capture = new Capture(7);
            previev_Frame = new Mat();
            previev_capture.Retrieve(previev_Frame);
            pictureBox1.Image = previev_Frame.ToImage<Bgr, byte>().Bitmap;
            previev_capture.Dispose();
            previev_Frame.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("CamerasConfig.txt"))
            {
                sw.WriteLine(textBox0.Text);
                sw.WriteLine(textBox1.Text);
                sw.WriteLine(textBox2.Text);
                sw.WriteLine(textBox3.Text);
                sw.WriteLine(textBox4.Text);
                sw.WriteLine(textBox5.Text);
                sw.WriteLine(textBox6.Text);
                sw.WriteLine(textBox7.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cmd = "RelayCmd ON=2";

            var proc = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @Relay_path_textbox.Text,
                FileName = @Relay_path_textbox.Text+"RelayCmd.exe",
                Arguments = "/c " + cmd,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(proc);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cmd = "RelayCmd OFF=2";

            var proc = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @Relay_path_textbox.Text,
                FileName = @Relay_path_textbox.Text+"RelayCmd.exe",
                Arguments = "/c " + cmd,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(proc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cmd = "RelayCmd ON=1";

            var proc = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @Relay_path_textbox.Text,
                FileName = @Relay_path_textbox.Text+"RelayCmd.exe",
                Arguments = "/c " + cmd,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(proc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cmd = "RelayCmd OFF=1";

            var proc = new ProcessStartInfo()
            {
                UseShellExecute = true,
                WorkingDirectory = @Relay_path_textbox.Text,
                FileName = @Relay_path_textbox.Text+"RelayCmd.exe",
                Arguments = "/c " + cmd,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(proc);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            mainTimer.Start();
        }

        private void btnForcedStart_Click(object sender, EventArgs e)
        {
            m_NextTime = Converter(DateTime.Now.ToShortTimeString());
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            mainTimer.Stop();
            this.Close();
        }

        private int Converter(string time)
        {
            string[] s = time.Split(':');
            return 3600 * int.Parse(s[0]) + 60 * int.Parse(s[1]);
        }
    }
}
