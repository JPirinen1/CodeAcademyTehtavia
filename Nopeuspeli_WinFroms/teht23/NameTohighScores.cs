using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace teht23
{
    public partial class NameTohighScores : Form
    {
        private Player player;

        private int score;

        public NameTohighScores(int score)
        {
            InitializeComponent();

            this.score = score; //tähän formille tuodaan pelissä saadut pisteet

            labelTotalPoints.Text = $"You got {score} points";
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //jos ei haluta lisätä tulosta listaan
            this.Close();
        }

        public Player GetPlayer()
        {
            //tätä kutsutaan pelistä kun halutaan tuoda syötetty pelaaja highscores listviewille
            return player;
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            //asetetaan textboxissa annettu nimi ja pelissä saadut pisteet Player luokan instanssiksi
            string name = textBoxName.Text;

            this.player = new Player(name, score);
        }
    }
}
