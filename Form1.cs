using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BoiteDialogue_notes_cours
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult resultat;
            resultat = MessageBox.Show("Voulez-vous quitter le programme ?",
                "Quitter le programme",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if(resultat == DialogResult.Yes)
            {
                //Application.Exit();
                label1.Text = "Vous avez choisi 'Oui'";       
            }
            else
            {
                label1.Text = "Vous avez choisi'Non'";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                label2.Font = FontDialog1.Font;

                string maFont = "size : " + FontDialog1.Font.Size +
                    "\nbold : " + FontDialog1.Font.Bold +
                    "\nItalic : " + FontDialog1.Font.Italic +
                    "\nName : " + FontDialog1.Font.Name;

                MessageBox.Show(maFont);
                MessageBox.Show(FontDialog1.Color.ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                //Label2.ForeColor = colorDialog1.Color;
                label2.BackColor = colorDialog1.Color;
                button1.ForeColor = colorDialog1.Color;
                MessageBox.Show(colorDialog1.Color.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            openFileDialog1.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|all files(*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "Choisir un fichier en format txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                textBox2.Text = filePath;
            }

            var fileStream = openFileDialog1.OpenFile();
            
            using(StreamReader reader = new StreamReader(fileStream))
            {
                fileContent = reader.ReadToEnd();
            }

            textBox1.Text = fileContent;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            openFileDialog1.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            openFileDialog1.Filter = "png files (*.pg)|*.png|all files(*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "Choisir une image en format png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                textBox3.Text = filePath;
            }

            pictureBox1.Load(filePath);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Enregistrer un fichier texte sur le bureau
            saveFileDialog1.Filter = "Fichier texte (*.txt)|*.txt|Tous les fichiers (*.*)|*.*";
            saveFileDialog1.Title = "Enregistrer un fichier texte";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName !="")
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.Write(textBox4.Text);
                sw.Close();
            }

            /*saveFileDialog1.Filter = "Fichier texte (*.txt)|*.txt|Fichier pdf (*.pdf)|*.pdf";
            saveFileDialog1.Title = "Enregistrer un fichier texte";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        MessageBox.Show("Vous avez choisi le format txt");
                        break;

                    case 2:
                        MessageBox.Show("Vous avez choisi le format pdf");
                        break;
                }
                
            }*/
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //folderBrowserDialog1.ShowDialog();
            folderBrowserDialog1.Description = "Ceci est une description";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowNewFolderButton = false;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                
                label3.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Impression du texte en pdf
            Font myFont = new Font("Arail", 14, FontStyle.Bold);
            e.Graphics.DrawString(textBox5.Text, 
                myFont, 
                Brushes.Aquamarine,
                new PointF(100, 100));
            //Impression d'image
            // Image n'est pas centrée
            //e.Graphics.DrawImage(pictureBox2.Image, new PointF(100, 300));
            //une autre façon de faire
            e.Graphics.DrawImage(pictureBox2.Image, 100, 300, 517, 272);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
                printPreviewDialog1.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
