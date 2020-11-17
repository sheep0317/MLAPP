using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MLAPPML.Model;
namespace MLAPPML.ConsoleApp
{
    public partial class Form1 : Form
    {
        DrawNote drawnote;
        Bitmap bm;
        string source;

        public Form1()
        {
            InitializeComponent();
            drawnote = new DrawNote();
            pictureBox1.Image = new Bitmap(this.pictureBox1.ClientSize.Width, this.pictureBox1.ClientSize.Height);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
    
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
     
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            source = richTextBox2.Text.Trim();
            //bm = new Bitmap(this.pictureBox1.ClientSize.Width, this.pictureBox1.ClientSize.Height);

            //this.pictureBox1.DrawToBitmap(bm, this.pictureBox1.ClientRectangle);
            //pictureBox1.Image.Save(String.Format("check.jpg"));
            //this.pictureBox1.CreateGraphics().Clear(Color.White);
            //this.pictureBox1.Image = new Bitmap(this.pictureBox1.ClientSize.Width, this.pictureBox1.ClientSize.Height);
            //richTextBox1.Text = "";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModelInput sampleData = new ModelInput()
            {
                ImageSource = source,
            };
            //// Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);
            this.richTextBox1.Text = $"Predicted Label value {predictionResult.Prediction} \nPredicted Label scores: [{String.Join(",", predictionResult.Score)}]";

            Console.WriteLine("Using model to make single prediction -- Comparing actual Label with predicted Label from sample data...\n\n");
            Console.WriteLine($"ImageSource: {sampleData.ImageSource}");
            Console.WriteLine($"\n\nPredicted Label value {predictionResult.Prediction} \nPredicted Label scores: [{String.Join(",", predictionResult.Score)}]\n\n");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var t = new Thread((ThreadStart)(() =>
            {
                openFileDialog1.InitialDirectory = @"C:\";
                openFileDialog1.Title = "Browse Text Files";
                openFileDialog1.DefaultExt = "jpg";
                openFileDialog1.Filter = "img files (*.jpg)|*.jpg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.Text = openFileDialog1.FileName;
                }
            }));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
