using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using System.IO;
using System.Reflection;

namespace Pathology
{
    public partial class Frmword : Form
    {
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.Container components = null;
        
        public Frmword()
        {
            InitializeComponent();
        }

        Assembly _assembly;
        Stream _imageStream;
        StreamReader _textStreamReader;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.Run(new Form1());
        //}
        
        
        
        
        private void Frmword_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    _assembly = Assembly.GetExecutingAssembly();
            //   // _imageStream = _assembly.GetManifestResourceStream("Pathology.MyImage.bmp");
            //    _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream("D:\\Pathology_180416panda\\Pathology\bin\\Debug\\help.txt"));
            //}
            //catch
            //{
            //    MessageBox.Show("Error accessing resources!");
            //}		
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //pictureBox2.Image = new Bitmap(_imageStream);
            }
            catch
            {
                MessageBox.Show("page under construction!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (_textStreamReader.Peek() != -1)
                {
                  textBox2.Text = _textStreamReader.ReadLine();
                }
            }
            catch
            {
                MessageBox.Show("page under construction!");
            }	
        }
   
    
    
    
    
    }
}
