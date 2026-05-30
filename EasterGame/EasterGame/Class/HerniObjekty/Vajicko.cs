using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EasterGame.Class.HerniObjekty
{
    class Vajicko : HerniObjekt
    {
        public Vajicko(int poziceX, int poziceY,string barva)
            : base(poziceX, poziceY)
        {
            this.X = poziceX;
            this.Y = poziceY;
            switch(barva)
            {
                case "modra":
                    ObrazekObjektu = EasterGame.Properties.Resources.vajicko_modre;
                    break;
                case "cervena":
                    ObrazekObjektu = EasterGame.Properties.Resources.vajicko_cervene;
                    break;
                case "oranzova":
                    ObrazekObjektu = EasterGame.Properties.Resources.vajicko_oranzove;
                    break;
            }
        }
        public override void VykresliObjekt(System.Drawing.Graphics g)
        {
            g.DrawImage(ObrazekObjektu, new Rectangle(this.X * Class.Level.polickoSirka, this.Y * Class.Level.polickoVyska, Level.polickoSirka, Level.polickoVyska));
            base.VykresliObjekt(g);
        }
    }
}
