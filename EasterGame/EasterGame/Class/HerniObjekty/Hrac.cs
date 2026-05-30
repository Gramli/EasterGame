using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace EasterGame.Class.HerniObjekty
{

    public enum Smer
    {
        Doprava, Doleva, Nahoru, Dolu
    }

    class Hrac : HerniObjekt
    {
        public int pocetMoznychSkoku;
        public int pocetSebranychPredmetu;
        public Smer SmerHrace; //pokud stiskne mezernik musim vedet jak je zajic natoceny
        public int pocetTahu;

        public Hrac(int poziceX,int poziceY)
            : base(poziceX,poziceY)
        {
            ObrazekObjektu = EasterGame.Properties.Resources.zajic_sedi_doprava;
            this.X = poziceX;
            this.Y = poziceY;
            pocetMoznychSkoku = 0;
            SmerHrace = Smer.Doprava;
            pocetTahu = 0;

        }
        public override int X
        {
            get
            {
                return base.X;
            }
            set
            {
                base.X = value;
                this.pocetTahu += 1;
            }
        } // potrebuju k pripisovani tahu
        public override int Y
        {
            get
            {
                return base.Y;
            }
            set
            {
                base.Y = value;
                this.pocetTahu += 1;
            }
        }
        public override void VstupHrace(Keys key)
        {
            switch (key)
            { 
                case Keys.Up:
                    ObrazekObjektu = EasterGame.Properties.Resources.zajic_sedi_nahoru;
                    SmerHrace = Smer.Nahoru;
                    break;
                case Keys.Down:
                    ObrazekObjektu = EasterGame.Properties.Resources.zajic_sedi_dolu;
                    SmerHrace = Smer.Dolu;
                    break;
                case Keys.Right:
                    ObrazekObjektu = EasterGame.Properties.Resources.zajic_sedi_doprava;
                    SmerHrace = Smer.Doprava;
                    break;
                case Keys.Left:
                    ObrazekObjektu = EasterGame.Properties.Resources.zajic_sedi_doleva;
                    SmerHrace = Smer.Doleva;
                    break;
            }
            base.VstupHrace(key);
        }
        public override void VykresliObjekt(System.Drawing.Graphics g)
        {
            g.DrawImage(ObrazekObjektu, new Rectangle(this.X * Class.Level.polickoSirka, this.Y * Class.Level.polickoVyska, Level.polickoSirka, Level.polickoVyska));
            base.VykresliObjekt(g);
        }
    }
}
