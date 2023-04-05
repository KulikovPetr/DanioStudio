using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows.Forms;
using System.IO;

namespace DanioRecorder
{
    public class Camera
    {
        bool m_isConnected;
        int m_Length, m_fps, m_FrameCount, m_Height, m_Width;
        string m_FileName, m_CurrTime;
        Capture m_Cam;
        VideoWriter m_Writer;
        Mat m_Frame;
        List<Mat> m_ListFrames;
        //SavesCounter savesCounter;
        Image<Gray, byte> imggrey;

        public Camera(int cid, int length, string sSelectedPath, int texbox0Value, int texbox1Value, int texbox2Value, int texbox3Value, int texbox4Value, int texbox5Value, int texbox6Value, int texbox7Value)
        {
            m_Length = length;
            m_fps = 1;
            m_FrameCount = 0;
            m_Writer = null;
            m_Cam = new Capture(cid);
            m_Width = m_Cam.Width;
            m_Height = m_Cam.Height;
            switch (cid)
            {

                case 0:
                    cid = texbox0Value;
                    break;
                case 1:
                    cid = texbox1Value;
                    break;
                case 2:
                    cid = texbox2Value;
                    break;
                case 3:
                    cid = texbox3Value;
                    break;
                case 4:
                    cid = texbox4Value;
                    break;
                case 5:
                    cid = texbox5Value;
                    break;
                case 6:
                    cid = texbox6Value;
                    break;
                case 7:
                    cid = texbox7Value;
                    break;
            }
                    m_CurrTime = DateTime.Now.ToString("yyyy-MM-dd");
            sSelectedPath = sSelectedPath + "/cam" + cid.ToString() + '/' + m_CurrTime;
            Directory.CreateDirectory(sSelectedPath);
            Console.WriteLine("\n" + sSelectedPath);
            m_CurrTime = ' ' + DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
            m_FileName = sSelectedPath + "/cam" + cid.ToString() + m_CurrTime + ".avi";
            if (m_Height > 0 & m_Width > 0)
            {
                m_ListFrames = new List<Mat>();
                m_isConnected = true;
                Console.WriteLine(m_CurrTime + " cam" + cid.ToString() + " is connected");
            }
            else
            {
                m_Cam.Dispose();
                m_Frame.Dispose();
                m_FileName = "";
                m_isConnected = false;
                Console.WriteLine(m_CurrTime + " cam" + cid.ToString() + " is not connected");
                GC.Collect();
            }
        }
        public void Run()
        {
            while (m_isConnected)
            {
                try
                {
                    //m_Frame = m_Cam.QueryFrame();
                    if (m_FrameCount <= m_Length)
                    {
                        m_Frame = m_Cam.QueryFrame();
                        imggrey = m_Frame.ToImage<Gray, byte>();
                        imggrey.Mat.CopyTo(m_Frame);
                        m_ListFrames.Add(m_Frame);
                        m_FrameCount++;
                        Thread.Sleep(1000 / m_fps);
                    }
                    if (m_FrameCount > m_Length)
                    {
                        m_Writer = new VideoWriter(m_FileName, VideoWriter.Fourcc('X', 'V', 'I', 'D'), m_fps, new Size(m_Width, m_Height), true);
                        for (int i = 0; i < m_FrameCount; i++)
                            m_Writer.Write(m_ListFrames[i]);
                        Console.WriteLine(m_CurrTime + " file " + m_FileName + " is written");
                        m_isConnected = false;
                    }
                }
                catch (Exception e)
                {
                    m_isConnected = false;
                    if (m_FrameCount > 0)
                    {
                        m_Writer = new VideoWriter(m_FileName, VideoWriter.Fourcc('X', 'V', 'I', 'D'), m_fps, new Size(m_Width, m_Height), false);
                        for (int i = 0; i < m_FrameCount; i++)
                            m_Writer.Write(m_ListFrames[i]);
                        Console.WriteLine(m_CurrTime + " file " + m_FileName + " is truncated");
                     }
                    else
                    {
                        Console.WriteLine(m_CurrTime + " file " + m_FileName + " is not written");
                    }
                }
            }
            m_Writer.Dispose();
            m_Cam.Dispose();
            m_ListFrames.Clear();
            m_FrameCount = 0;
            GC.Collect();
        }
    }
}
