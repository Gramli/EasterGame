using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace EasterGame.Class
{
    public enum Policka // pole ktera jsou ve hre
    { 
        Nic,Prekazka, MrtvePole, Teleport, Dvere, Vajicko//Vajicko je tu proto, abych pokud je jich hodne nemusel psat tolik foru -> setri misto napr. lvl 4
    }

    class Level
    {
        public const int polickoSirka = 40;
        public const int polickoVyska = 40;

        public const int mapaSirka = 20;
        public const int mapaVyska = 15;

        List<HerniObjekt> herniObjektyMapy; // herni objekty ktere budu vkladat do mapy

        int pocetVajec;
        public int PocetVajec
        {
            get{return pocetVajec;}
            protected set{ pocetVajec = value;}
        } // pocet vajec, ktere budou v levlu

        public List<HerniObjekt> HerniObjektyMapy
        {
            get{return herniObjektyMapy;}
            protected set { herniObjektyMapy = value; }
        }
        
        protected int[] poziceTeleportu; //ukladam pozice teleportu indexy: 0=x, 1=y, 2=x, 3=y atd.. svazane jsou vzdy 4prvky

        public int[] PoziceTeleportu
        {
            get{ return poziceTeleportu;}
            protected set { poziceTeleportu = value; }
        }
        
        public string NazevLevlu; // string pro nazev do spodniho panelu

        public Policka[,] mapa = new Policka[mapaSirka, mapaVyska]; // herni mapa

        public Level() //konstruktor 
        {
            herniObjektyMapy = new List<HerniObjekt>();
        }
        public virtual void NastavMapu()
        { 
            
        }
        protected virtual void NastavTeleport()
        {
        
        }
        protected virtual void PridejHerniObjekty()// prida herniObjektz -> vajicka, mrkve
        { 
        
        }
        public void VykresliMapu(Graphics g)
        {
            for (int x = 0; x < mapaSirka; x ++)
            {
                for (int y = 0; y < mapaVyska; y ++)
                {   
                        switch (mapa[x, y])
                        {   
                            case  Policka.Nic:
                                g.DrawImage(EasterGame.Properties.Resources.trava, new Rectangle(x * polickoSirka, y * polickoVyska, polickoSirka, polickoVyska));
                                break;
                            case Policka.Vajicko:
                                g.DrawImage(EasterGame.Properties.Resources.trava, new Rectangle(x * polickoSirka, y * polickoVyska, polickoSirka, polickoVyska));
                                break;
                            case Policka.Prekazka:
                                g.DrawImage(EasterGame.Properties.Resources.trava, new Rectangle(x * polickoSirka, y * polickoVyska, polickoSirka, polickoVyska));
                                g.DrawImage(EasterGame.Properties.Resources.kamen_hnedy_2, new Rectangle(x * polickoSirka, y * polickoVyska, polickoSirka, polickoVyska));
                                break;
                            case Policka.MrtvePole:
                                g.DrawImage(EasterGame.Properties.Resources.mrtvePole, new Rectangle(x * polickoSirka, y * polickoVyska, polickoSirka, polickoVyska));
                                break;
                            case Policka.Teleport:
                                g.DrawImage(EasterGame.Properties.Resources.teleport, new Rectangle(x * polickoSirka, y * polickoVyska, polickoSirka, polickoVyska));
                                break;
                            case Policka.Dvere:
                                g.DrawImage(EasterGame.Properties.Resources.dvere, new Rectangle(x * polickoSirka, y * polickoVyska, polickoSirka, polickoVyska));
                                break;

                        }
                }
            }
        }//vykresluje mapu podle nastaveni
        protected void NastavPredmetSikmo(int pocatekX, int pocatekY, bool ZpravaDolu,int pocet,Policka predmet)
        {
            int x = pocatekX;
            int y = pocatekY;

            if (ZpravaDolu)
            {
                for (; y < mapaVyska && pocet != 0; y++)
                {
                        if (mapa[x, y] != Policka.Prekazka && x <mapaSirka && mapa[x, y] != Policka.Teleport)
                        {
                            mapa[x, y] = predmet;
                        }
                        x++;
                        pocet--;
                }
            }
            else
            {
                for (; y < mapaVyska && pocet != 0; y++)
                {
                    if (mapa[x, y] != Policka.Prekazka && mapa[x, y] != Policka.Teleport)
                            mapa[x, y] = predmet;

                        x--;
                        pocet--;
                }
            }
        } // nastavuje prekazky sikmo
        protected void NastavPredmetHorizontalne(int pocatekX, int pocatekY, int pocet, Policka predmet)
        {
            for (int y = pocatekY; y < mapaVyska && pocet!=0; y++)
            {
                if (mapa[pocatekX, y] != Policka.Prekazka && mapa[pocatekX, y] != Policka.Teleport)
                {
                    mapa[pocatekX, y] = predmet;
                }
                pocet--;
            }
        } // nastavuje prekazky horizontalne
        protected void NastavPredmetVertikalne(int pocatekX, int pocatekY, int pocet, Policka predmet)
        {

            for (int x = pocatekX; x < mapaSirka && pocet != 0; x++)
            {
                if (mapa[x, pocatekY] != Policka.Prekazka && mapa[x, pocatekY] != Policka.Teleport)
                {
                    mapa[x, pocatekY] = predmet;
                }
                pocet--;
            }
        } // nastavuje prekazky vertikalne
        protected void MapaPoziceTeleportu()
        {
            int o = 0;
            for (int i = 0; i < poziceTeleportu.Length; i+=2)
            {
                o = i + 1;
                mapa[poziceTeleportu[i], poziceTeleportu[o]] = Policka.Teleport;
            }
        } //podle nastaveni z daneho levlu nastavuju mape pozice teleportu
    }
}
