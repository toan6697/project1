using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
   

    {
    string fileName = "No Name";
        private SpeechSynthesizer _SS = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
            foreach (object obj in _SS.GetInstalledVoices())

            {

                var voice = (InstalledVoice)obj;

                listBox1.Items.Add(voice.VoiceInfo.Name);
            }
            _SS.Volume = 80;
            _SS.Rate = 5;
     
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = vanban.Font;
            if (fontDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                vanban.Font = fontDialog1.Font;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                System.IO.File.WriteAllText(fileName, vanban.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                fileName = openFileDialog1.FileName;
                vanban.Text = System.IO.File.ReadAllText(fileName);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileName = "No Name";
            vanban.Text = ""; 
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fileName=="No Name")
            {
                saveAsToolStripMenuItem_Click(null, null);
            }
            else
            {
                System.IO.File.WriteAllText(fileName, vanban.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _SS.SpeakAsync("my name is toan ");
        }
    }
}
