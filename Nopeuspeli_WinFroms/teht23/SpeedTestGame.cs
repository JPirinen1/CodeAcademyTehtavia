using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teht23
{
    public partial class FormSpeedTestGame : Form
    {
        private List<Player> playerscores = new List<Player>(); //tähän listaan laitetaan pelaajien tulokset
        private Random rnd = new Random();
        Game game;


        public FormSpeedTestGame()
        {
            InitializeComponent();
            InitializeColors();
            DisableButtons(); //estetään että pelaaja ei voi painaa nappeja ennen pelin alkua
            ShowHighScores();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = false; //estetään että pelaaja ei voi pelin aikana painaa start nappia
            InitializeColors(); //alustetaan nappien värit pelin alkaessa
            EnableButtons(); //tällä asetetaan nappien enable = true
            game = new Game(); //tässä luokassa alustetaan pelissä käytettävät apumuuttujat
            labelP.Visible = true;
            labelPoints.Visible = true; //laitetaan piste laskuri näkyviin
            UpdatePoints();
            timerLight.Enabled = true;
            timerSeconds.Enabled = true;
            labelTime.Visible = true; //näytetään kulunut aika
        }

        private void LightButton()
        {

            do
            {
                game.Drafted = rnd.Next(1, 5); //arvotaan numero 1-4 väliltä
            } while (game.Drafted == game.PreviousDraft);
            //jos arvottu numero oli sama kun edellisellä kierroksella niin arvotaan uusi
            game.PreviousDraft = game.Drafted;
            //asetetaan arvottu numero PreviousDraftin arvoksi johon verrataan seuraavalla kierroksella arvottavaa numeroa
            switch (game.Drafted) //määritetään nappien aktivoituminen arvotun numeron perusteella
            {
                case 1:
                    buttonRed.BackColor = ButtonProperties.RedOn;
                    break;
                case 2:
                    buttonYellow.BackColor = ButtonProperties.YellowOn;
                    break;
                case 3:
                    buttonGreen.BackColor = ButtonProperties.GreenOn;
                    break;
                case 4:
                    buttonBlue.BackColor = ButtonProperties.BlueOn;
                    break;
            }


        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = ButtonProperties.CheckWhichButton(b);
            //palauttaa painetun napin alkuperäisen värin ja asettaa sen takaisin

            if (b.BackColor == Color.White)
             /* jos painettiin väärää nappia niin CheckWhichButton palauttaa valkoisen värin
              * ja peli lopetetaan
              */
            {
                EndGame();
                return;
            }

            game.Points++; //lisätään piste napin painalluksen jälkeen

           
            UpdatePoints(); //päivitetään pisteet labeliin

            timerLight.Interval -= 100; //nopeutetaan värin vaihtumista 100 ms joka kierroksella

        }

        private void timerLight_Tick(object sender, EventArgs e)
        {
            CheckIfLightIsOn(); // tarkistaa onko edellinen nappi päällä kun uusi syttyy
            LightButton(); //arvotaan nappi jonka väriä muutetaan
        }
        private void UpdatePoints()
        {
            labelPoints.Text = game.Points.ToString();
        }


        private void timerSeconds_Tick(object sender, EventArgs e)
        {
            game.Seconds += 1; //lisätään ajanotto timeriin sekuntti
            if(game.Seconds == 60)
            {
                //kun sekunnit on 60 nollataan se ja lisätään minuutteihin 1
                game.Seconds = 0;
                game.Minutes += 1;
            }
            labelTime.Text = string.Format("{0}:{1}", game.Minutes.ToString().PadLeft(2,'0'), game.Seconds.ToString().PadLeft(2,'0'));
            //tulostetaan laskuri näytölle
        }

        private void CheckIfLightIsOn()
        {
            if(buttonRed.BackColor == ButtonProperties.RedOn || buttonYellow.BackColor == ButtonProperties.YellowOn
             || buttonGreen.BackColor == ButtonProperties.GreenOn || buttonBlue.BackColor == ButtonProperties.BlueOn)
            {
                //lopetetaan peli jos joku nappi on päällä kun uusi syttyy
                EndGame();
            }
        }



        private void InitializeColors()
        {
            //laitetaan napeille oletusvärit
            buttonRed.BackColor = ButtonProperties.RedOff;
            buttonYellow.BackColor = ButtonProperties.YellowOff;
            buttonGreen.BackColor = ButtonProperties.GreenOff;
            buttonBlue.BackColor = ButtonProperties.BlueOff;
        }

        private void DisableButtons()
        {
            //estetään nappien painaminen
            buttonRed.Enabled = false;
            buttonYellow.Enabled = false;
            buttonGreen.Enabled = false;
            buttonBlue.Enabled = false;
        }

        private void EnableButtons()
        {
            //sallitaan nappien painaminen
            buttonRed.Enabled = true;
            buttonYellow.Enabled = true;
            buttonGreen.Enabled = true;
            buttonBlue.Enabled = true;
        }

        private void ShowHighScores()
        {
            //tulostetaan listalta tulokset listviewille

            this.listViewHighScores.Items.Clear();

            foreach (var item in playerscores.OrderByDescending(c => c.Points))
            {                
                this.listViewHighScores.Items.Add(new ListViewItem(new string[] { item.Name, item.Points.ToString()}));
            }
        }

        private void EndGame()
        {
            
            buttonStart.Enabled = true;
            timerLight.Enabled = false;
            timerLight.Interval = 3000; //asetetaan ajastin takaisin alkuperäiseen arvoon ennen seuraavan pelin alkua
            timerSeconds.Enabled = false;
            DisableButtons();
            NameTohighScores sendscore = new NameTohighScores(game.Points);
            DialogResult result = sendscore.ShowDialog();

            if (result == DialogResult.OK)// jos käyttäjä painoi Add to highscores nappia
            {
                //lisätään pelaaja listaan ja näytetään highscores listviewillä
                Player playeradded = sendscore.GetPlayer();
                playerscores.Add(playeradded);
                ShowHighScores();

            }

        }
    }
}
