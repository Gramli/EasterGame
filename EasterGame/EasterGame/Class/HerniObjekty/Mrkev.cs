using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EasterGame.Class.HerniObjekty
{
    class Mrkev : HerniObjekt
    {
        public Mrkev(int poziceX, int poziceY)
            : base(poziceX,poziceY)
        {
            this.X = poziceX;
            this.Y = poziceY;
            ObrazekObjektu = EasterGame.Properties.Resources.mrkev;
        }
        public override void VykresliObjekt(System.Drawing.Graphics g)
        {
            g.DrawImage(ObrazekObjektu, new Rectangle(this.X * Class.Level.polickoSirka, this.Y * Class.Level.polickoVyska, Level.polickoSirka, Level.polickoVyska));
            base.VykresliObjekt(g);
        }
    }
}
