using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoiteDialogue_notes_cours
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult resultat;
            resultat = MessageBox.Show("Voulez-vous quitter le programme ?",
                "Quitter le programme",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if(resultat == DialogResult.Yes)
            {
                //Application.Exit();
                Label1.Text = "Vous avez choisi 'Oui'";       
            }
            else
            {
                Label1.Text = "Vous avez choisi'Non'";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (FontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Label2.Font = FontDialog1.Font;

                string maFont = "size : " + FontDialog1.Font.Size +
                    "\nbold : " + FontDialog1.Font.Bold +
                    "\nItalic : " + FontDialog1.Font.Italic +
                    "\nName : " + FontDialog1.Font.Name;

                MessageBox.Show(maFont);
                MessageBox.Show(FontDialog1.Color.ToString());

            }
        }
    }
}
