using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//input output

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "WMV|*.wmv|WAV|*.wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv" })
            { 
            
                if(ofd.ShowDialog() == DialogResult.OK) { //the dialog opend succssefully
                  
                    List<MediaFile> files = new List<MediaFile>(); // media player list take two values like in the class we made
                    
                    foreach(String fileName in ofd.FileNames) {
                        FileInfo fi = new FileInfo(fileName); // foreach file name store it in thf file info object
                        files.Add(new MediaFile() {fileName = Path.GetFileNameWithoutExtension(fi.FullName),path = fi.FullName});
                    }

                    listBox1.DataSource = files;
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile file = listBox1.SelectedItem as MediaFile;
            if(file != null) // is list box empty ?
            {
                axWindowsMediaPlayer1.URL = file.path; // axWindowsMediaPlayer1 this is the name of mediaPlayer

                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.ValueMember = "Path"; // used on back side
            listBox1.DisplayMember = "FileName"; // the name showed in the list box, you can just show the name or the path 
        }
    }
}
 