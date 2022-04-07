using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace teht23
{
    static public class ButtonProperties
    {
        //täällä on alustettu jokaiselle napille oma On ja Off arvo joita kutsutaan formilla
        public static Color RedOff { get; set; } = Color.Maroon;
        public static Color RedOn { get; set; } = Color.Red;
        public static Color YellowOff { get; set; } = Color.DarkGoldenrod;
        public static Color YellowOn { get; set; } = Color.Yellow;
        public static Color GreenOff { get; set; } = Color.DarkGreen;
        public static Color GreenOn { get; set; } = Color.Lime;
        public static Color BlueOff { get; set; } = Color.Navy;
        public static Color BlueOn { get; set; } = Color.DeepSkyBlue;


        public static Color CheckWhichButton(Button b)
        {
            //nappia painettaessa palauttaa samaa nappia vastaavan Off arvon joka asetetaan napin väriksi
            //painamisen jälkeen

            Color ret;

            if (b.BackColor == RedOn)
            {
                ret = RedOff;
            }
            else if(b.BackColor == YellowOn)
            {
                ret = YellowOff;
            }
            else if (b.BackColor == GreenOn)
            {
                ret = GreenOff;
            }
            else if (b.BackColor == BlueOn)
            {
                ret = BlueOff;
            }
            else
            {
                ret = Color.White;
            }

            return ret;
        }
    }

    
}
