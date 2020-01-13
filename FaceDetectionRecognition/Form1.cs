using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace FaceDetectionRecognition
{
    public partial class Form1 : Form
    {
        public VideoCapture webCam { get; set; }
        //public EigenFaceRecognizer faceRecognition { get; set; }

        public FaceRecognizer faceRecognition { get; set; }

        public CascadeClassifier faceDetection { get; set; }
        public CascadeClassifier eyeDetection { get; set; }

        public Mat frame;

        public List<Image<Gray,byte>> Faces { get; set; }
        public List<int> IDs { get; set; }

        public int ProcessedImageWidth { get; set; } = 128;
        public int ProcessedImageHeight { get; set; } = 150;

        public int TimerCounter { get; set; } = 0;
        public int TimeLimit { get; set; } = 30;
        public int ScanCounter { get; set; } = 0;

        public string YMLPath { get; set; } = @"../../data/yml/ymldata.yml";
        
        public Timer timer { get; set; }

        public bool faceSquare { get; set; } = false;
        public bool eyeSquare { get; set; } = false;


        public Form1()
        {
            InitializeComponent();

            faceRecognition = new LBPHFaceRecognizer(2, 10, 8, 8, 85);

            if (File.Exists(YMLPath))
                faceRecognition.Read(YMLPath);
            else
                PredictButton.Enabled = false;


            faceDetection = new CascadeClassifier(Path.GetFullPath(@"../../data/haarcascades/haarcascade_frontalface_default.xml"));
            eyeDetection = new CascadeClassifier(Path.GetFullPath(@"../../data/haarcascades/haarcascade_eye.xml"));
            frame = new Mat();
            Faces = new List<Image<Gray, byte>>();
            IDs = new List<int>();
            BeginWebCam();
        }

        private void BeginWebCam()
        {
            if (webCam == null)
                webCam = new VideoCapture();

            webCam.ImageGrabbed += webCam_ImageGrabbed;
            webCam.Start();
            OutPutBox.AppendText($"WebCam Started...{Environment.NewLine}");


        }

        private void webCam_ImageGrabbed(object sender, EventArgs e)
        {
            webCam.Retrieve(frame);
            var imageFrame = frame.ToImage<Bgr, byte>();

            if(imageFrame != null)
            {
                var grayFrame = imageFrame.Convert<Gray, byte>();

                var faces = faceDetection.DetectMultiScale(grayFrame, 1.3, 5);
                var eyes = eyeDetection.DetectMultiScale(grayFrame, 1.3, 5);

                if (faceSquare)
                    foreach (var face in faces)
                    {
                        var processedImage = grayFrame.Copy(face).Resize(ProcessedImageWidth, ProcessedImageHeight, Emgu.CV.CvEnum.Inter.Cubic);
                        var result = faceRecognition.Predict(processedImage);
                        if (result.Label != -1)
                            imageFrame.Draw(face, new Bgr(Color.Green), 3);
                        else
                            imageFrame.Draw(face, new Bgr(Color.Red), 3);
                    }

                if (eyeSquare)
                    foreach (var eye in eyes)
                        imageFrame.Draw(eye, new Bgr(Color.Yellow), 3);

                webCamImageBox.Image = imageFrame;
            }

        }

        private void Trainbottom_Click(object sender, EventArgs e)
        {
            if(IdBox.Text != string.Empty)
            {
                IdBox.Enabled = !IdBox.Enabled;

                timer = new Timer();
                timer.Interval = 500;
                timer.Tick += Timer_Tick;
                timer.Start();
                Trainbottom.Enabled = !Trainbottom.Enabled;
            }
                       
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            webCam.Retrieve(frame);
            var imageFrame = frame.ToImage<Gray, byte>();

            if(TimerCounter < TimeLimit)
            {
                TimerCounter++;

                if(imageFrame != null)
                {

                    var faces = faceDetection.DetectMultiScale(imageFrame, 1.3, 5);

                    if(faces.Count() > 0)
                    {
                        var processedImage = imageFrame.Copy(faces[0]).Resize(ProcessedImageWidth, ProcessedImageHeight, Emgu.CV.CvEnum.Inter.Cubic);
                        Faces.Add(processedImage);
                        IDs.Add(Convert.ToInt32(IdBox.Text));
                        ScanCounter++;
                        OutPutBox.AppendText($"{ScanCounter} Success Scan Taken... {Environment.NewLine}");
                        OutPutBox.ScrollToCaret();
                    }
                }
            }
            else
            {
                Mat[] faceImages = new Mat[Faces.Count];
                
                faceImages = Faces.Select(c=> c.Mat).ToArray();

                faceRecognition.Train(faceImages, IDs.ToArray());
                faceRecognition.Write(YMLPath);
                timer.Stop();
                Trainbottom.Enabled = !Trainbottom.Enabled;
                IdBox.Enabled = !IdBox.Enabled;

                OutPutBox.AppendText($"Training Complete!{Environment.NewLine}");
                MessageBox.Show("Training Completed!");

                PredictButton.Enabled = true;
            }
        }

        private void FaceButton_Click(object sender, EventArgs e)
        {
            if(faceSquare)
                FaceButton.Text = "Face Square: Off";
            else
                FaceButton.Text = "Face Square: On";

            faceSquare = !faceSquare;

        }

        private void EyeButton_Click(object sender, EventArgs e)
        {
            if (eyeSquare)
                EyeButton.Text = "Eye Square: Off";
            else
                EyeButton.Text = "Eye Square: On";

            eyeSquare = !eyeSquare;
        }

        private void PredictButton_Click(object sender, EventArgs e)
        {
            webCam.Retrieve(frame);
            var imageFrame = frame.ToImage<Gray, byte>();
            
            if(imageFrame != null)
            {
                var faces = faceDetection.DetectMultiScale(imageFrame, 1.3, 5);

                if (faces.Count() != 0)
                {
                    
                    var processedImage = imageFrame.Copy(faces[0]).Resize(ProcessedImageWidth, ProcessedImageHeight, Emgu.CV.CvEnum.Inter.Cubic);
                    var result = faceRecognition.Predict(processedImage);

                    if (result.Label.ToString() == "-1")
                        MessageBox.Show("Nao Conheco. Desce a lenha!");

                        else if (result.Label.ToString() == "15")
                        MessageBox.Show("Your Name");
                    else
                        MessageBox.Show("Your Friend");
                }
                else
                    MessageBox.Show("Face was not found - Try Again");
            }
        }
    }
}
