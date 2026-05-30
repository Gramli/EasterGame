using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasterGame
{
    public partial class HlavniOkno : Form
    {
        Class.Level level; //level
        Class.HerniObjekty.Hrac hrac; // hrac
        List<Class.HerniObjekt> SeznamHernichObjektu; //HerniObjekty ve hre, mrkev, vajica..
        DialogResult result;// potrebuju po konci kola, abych vedel na co reagovat z MujMessageBox
        Forms.MojeMenu menu;// HlavniMenu
        Timer casovac; // timer nastaveny na 1 sekundu
        int cas;// promena se zvusyje, kdyz timer tikne
        public static System.Media.SoundPlayer player;

        public HlavniOkno()
        {
            InitializeComponent();
            menu = new Forms.MojeMenu();
            UkazMenu();
            NastavPrehravani();
        }//konstruktor
        private void NastavPrehravani()
        {
            player = new System.Media.SoundPlayer();
            player.Stream = EasterGame.Properties.Resources.Mellowtron;
            player.PlayLooping();
            player.Tag = "Play";
        }//Nastavi hudbu
        private void UkazMenu()
        {
            this.ClientSize = new Size(menu.Width, menu.Height);//50 je pro spodni menu s textem

            menu = new Forms.MojeMenu();
            menu.Dock = DockStyle.Fill;
            menu.Parent = this;
            menu.Show();
            menu.btnStart.Click += new EventHandler(Start); 

        }//Zobrazi hlavni menu
        private void Start(object sender, EventArgs e) // Start hry pomoci tlacitka z hlavniho menu
        {
            menu.Hide();
            menu.Enabled = false;
            this.ClientSize = new Size(Class.Level.mapaSirka * Class.Level.polickoSirka,
                Class.Level.mapaVyska * Class.Level.polickoVyska + 40);//40 je pro spodni menu s textem
            level = new Class.Levels.Level_1();
            level.NastavMapu();
            hrac = new Class.HerniObjekty.Hrac(0, 0);
            SeznamHernichObjektu = new List<Class.HerniObjekt>();
            SeznamHernichObjektu.Add(hrac);
            SeznamHernichObjektu.AddRange(level.HerniObjektyMapy);
            nastavCasovac();
            
        }
        private void Start()
        {
            level.NastavMapu();
            hrac = new Class.HerniObjekty.Hrac(0, 0);
            SeznamHernichObjektu = new List<Class.HerniObjekt>();
            SeznamHernichObjektu.Add(hrac);
            SeznamHernichObjektu.AddRange(level.HerniObjektyMapy);
            nastavCasovac();
            this.Refresh();
        }//start z tehle tridy
        private void PocitejCas(object sender, EventArgs e)
        {
            cas += 1;
            this.Refresh();
        }
        private void HlavniOkno_Paint(object sender, PaintEventArgs e)
        {
            level.VykresliMapu(e.Graphics);
            VykresliStringy(e.Graphics);
            foreach (Class.HerniObjekt o in SeznamHernichObjektu)
            {
                o.VykresliObjekt(e.Graphics);
            }
        } //Vykresluju
        private void HlavniOkno_KeyDown(object sender, KeyEventArgs e)
        {   
            hrac.VstupHrace(e.KeyCode);
            ZmenPozici(e.KeyCode);
            ZkontrolujKolize();
            this.Refresh();

            //vyhodnocuju konec hry
            if (level.mapa[hrac.X, hrac.Y] == Class.Policka.Dvere && (level.PocetVajec - hrac.pocetSebranychPredmetu == 0))
            {
                OdstranitObjekt(hrac);
                casovac.Stop();

                if (!(level is Class.Levels.Level_7))
                    result = Forms.MujMessageBox.Show("Dokončil si level!", "Čas: " + TimeSpan.FromSeconds(cas).ToString() + "s" + " | " + "Počet tahů: " + hrac.pocetTahu, "EasterGame", true);
                else
                    result = Forms.MujMessageBox.Show("Dokončil si hru!", "Čas: " + TimeSpan.FromSeconds(cas).ToString() + "s" + " | " + "Počet tahů: " + hrac.pocetTahu, "EasterGame", false);
               
                ObsluhaDialogResultu();
            }
            else if (!KontrolaKonceHry())
            {
                OdstranitObjekt(hrac);
                casovac.Stop();
                result = Forms.MujMessageBox.Show("Prohrál si!", "Čas: " + TimeSpan.FromSeconds(cas).ToString() + "s" + " | " + "Počet tahů: " + hrac.pocetTahu, "EasterGame", false);
                ObsluhaDialogResultu();
            }

            if (e.KeyCode == Keys.S)
            {
                if (player.Tag == "Play")
                {
                    player.Stop();
                    player.Tag = "Stop";
                }
                else
                {
                    player.PlayLooping();
                    player.Tag = "Play";
                }
            }

        }//Hlavni Smycka, pri stisku se vse odehrava
        private void ZmenPozici(Keys key)
        {
            switch (key) // skok o jedno pole
            {
                case Keys.Up:
                    if(hrac.Y >0)
                        if (level.mapa[hrac.X, hrac.Y - 1] != Class.Policka.Prekazka && level.mapa[hrac.X, hrac.Y - 1] != Class.Policka.MrtvePole)
                        {
                            if (level.mapa[hrac.X, hrac.Y] != Class.Policka.Teleport && level.mapa[hrac.X, hrac.Y] != Class.Policka.Dvere)
                                level.mapa[hrac.X, hrac.Y] = Class.Policka.MrtvePole;
                            hrac.Y -= 1;
                        }
                    break;
                case Keys.Down:
                    if (hrac.Y < Class.Level.mapaVyska-1)
                        if (level.mapa[hrac.X, hrac.Y + 1] != Class.Policka.Prekazka && level.mapa[hrac.X, hrac.Y + 1] != Class.Policka.MrtvePole)
                        {
                            if (level.mapa[hrac.X, hrac.Y] != Class.Policka.Teleport && level.mapa[hrac.X, hrac.Y] != Class.Policka.Dvere)
                                level.mapa[hrac.X, hrac.Y] = Class.Policka.MrtvePole;
                            hrac.Y += 1;
                        }
                    break;
                case Keys.Right:
                    if (hrac.X < Class.Level.mapaSirka-1)
                        if (level.mapa[hrac.X + 1, hrac.Y] != Class.Policka.Prekazka && level.mapa[hrac.X + 1, hrac.Y] != Class.Policka.MrtvePole)
                        {
                            if (level.mapa[hrac.X, hrac.Y] != Class.Policka.Teleport && level.mapa[hrac.X, hrac.Y] != Class.Policka.Dvere)
                                level.mapa[hrac.X, hrac.Y] = Class.Policka.MrtvePole;
                            hrac.X += 1;
                        }
                    break;
                case Keys.Left:
                    if (hrac.X > 0)
                        if (level.mapa[hrac.X - 1, hrac.Y] != Class.Policka.Prekazka && level.mapa[hrac.X - 1, hrac.Y] != Class.Policka.MrtvePole)
                        {
                            if (level.mapa[hrac.X, hrac.Y] != Class.Policka.Teleport && level.mapa[hrac.X, hrac.Y] != Class.Policka.Dvere)
                                level.mapa[hrac.X, hrac.Y] = Class.Policka.MrtvePole;
                            hrac.X -= 1;
                        }
                    break;
                case Keys.Space://tady skacu o 2 pole
                    if (hrac.pocetMoznychSkoku > 0) // muze skakat pokud vzal mrkev
                    {
                        switch (hrac.SmerHrace)
                        {
                            case Class.HerniObjekty.Smer.Doprava:
                                if (hrac.X < Class.Level.mapaSirka - 2)
                                    if (level.mapa[hrac.X + 2, hrac.Y] != Class.Policka.Prekazka && level.mapa[hrac.X + 2, hrac.Y] != Class.Policka.MrtvePole)
                                    {
                                        if (level.mapa[hrac.X, hrac.Y] != Class.Policka.Teleport)
                                            level.mapa[hrac.X, hrac.Y] = Class.Policka.MrtvePole;
                                        hrac.X += 2;
                                        hrac.pocetMoznychSkoku -= 1;
                                    }
                                break;
                            case Class.HerniObjekty.Smer.Doleva:
                                if (hrac.X > 1)
                                    if (level.mapa[hrac.X - 2, hrac.Y] != Class.Policka.Prekazka && level.mapa[hrac.X - 2, hrac.Y] != Class.Policka.MrtvePole)
                                    {
                                        if (level.mapa[hrac.X, hrac.Y] != Class.Policka.Teleport)
                                            level.mapa[hrac.X, hrac.Y] = Class.Policka.MrtvePole;
                                        hrac.X -= 2;
                                        hrac.pocetMoznychSkoku -= 1;
                                    }
                                break;
                            case Class.HerniObjekty.Smer.Nahoru:
                                if (hrac.Y > 1)
                                    if (level.mapa[hrac.X, hrac.Y - 2] != Class.Policka.Prekazka && level.mapa[hrac.X, hrac.Y - 2] != Class.Policka.MrtvePole)
                                    {
                                        if (level.mapa[hrac.X, hrac.Y] != Class.Policka.Teleport)
                                            level.mapa[hrac.X, hrac.Y] = Class.Policka.MrtvePole;
                                        hrac.Y -= 2;
                                        hrac.pocetMoznychSkoku -= 1;
                                    }
                                break;
                            case Class.HerniObjekty.Smer.Dolu:
                                if (hrac.Y < Class.Level.mapaVyska - 2)
                                    if (level.mapa[hrac.X, hrac.Y + 2] != Class.Policka.Prekazka && level.mapa[hrac.X, hrac.Y + 2] != Class.Policka.MrtvePole)
                                    {
                                        if (level.mapa[hrac.X, hrac.Y] != Class.Policka.Teleport)
                                            level.mapa[hrac.X, hrac.Y] = Class.Policka.MrtvePole;
                                        hrac.Y += 2;
                                        hrac.pocetMoznychSkoku -= 1;
                                    }
                                break;
                        }
                    }
                    break;
            }
            if (level.mapa[hrac.X, hrac.Y] == Class.Policka.Teleport) // pokud je na teleportu, teleportuj
            {
                int x = Teleportuj(hrac.X, true);
                int y = Teleportuj(hrac.X, false);
                if (x != int.MaxValue && y != int.MaxValue)
                {
                    hrac.X = x;
                    hrac.Y = y;
                }
            }
        } // meni pozici hrace, pokud tam neni prekazka nebo mrtve pole, teleportuje hrace, + dvojskok po sebrani mrkve
        private int Teleportuj(int pozice,bool x) //bool znamena x jestlize chci pozcici X
        {
            int y = 0;
            for (int i = 0; i < level.PoziceTeleportu.Length; i++)
            {
                if (pozice == level.PoziceTeleportu[i])
                {
                    if (!x)
                        y = 1;
                    if (i == 0)
                        return level.PoziceTeleportu[i + 2+y];
                    else if (i % 4 == 0)
                    {
                        return level.PoziceTeleportu[i+2+y];
                    }
                    else
                    {   
                        if(i%2 == 0)
                        return level.PoziceTeleportu[i - 2 + y];
                    }
                }
            }
            return int.MaxValue;
        }
        private void ZkontrolujKolize()
        {
            for (int i = 0; i < SeznamHernichObjektu.Count; i++)
            {
                if (SeznamHernichObjektu[i].X == SeznamHernichObjektu[0].X && SeznamHernichObjektu[i].Y == SeznamHernichObjektu[0].Y)
                {
                    if (SeznamHernichObjektu[i] is Class.HerniObjekty.Mrkev)
                    {
                        OdstranitObjekt(SeznamHernichObjektu[i]);
                        hrac.pocetMoznychSkoku += 1;
                    }
                    else if (SeznamHernichObjektu[i] is Class.HerniObjekty.Vajicko)
                    {
                        OdstranitObjekt(SeznamHernichObjektu[i]);
                        hrac.pocetSebranychPredmetu += 1;
                    }
                }
            }
        }//kontroluje pozice hrace a ostatnich predmetu
        private void OdstranitObjekt(Class.HerniObjekt o)
        {
            SeznamHernichObjektu.Remove(o);
        }// Odstraneni objektu ze SeznamuHernichObjektu
        private void VykresliStringy(Graphics g)
        {
            Font pismoStringu = new Font("Arial", 20, FontStyle.Bold);
            int poziceY = 605;

            g.DrawString(level.NazevLevlu + " | " + "Počet tahů: " + hrac.pocetTahu + " | " + "Počet skoků: " + hrac.pocetMoznychSkoku + " | " + "Čas:" + TimeSpan.FromSeconds(cas).ToString() + "s",
                pismoStringu, Brushes.Black, new Point(40, poziceY));
            
        }
        private bool KontrolaKonceHry()//Tady kontroluju, zda ma hrac jeste nejaky mozny tah, pokud ano vrati true
        {
            bool jevolne = CheckniPolicka(1);
            if (jevolne)
            {
                return true;
            }
            else if (hrac.pocetMoznychSkoku > 0)
            {
                jevolne = CheckniPolicka(2);

                if (jevolne)
                    return true;
            }

            return false;
        }
        private bool CheckniPolicka(int posun) //kontroluje policka, kam by hrac teoreticky mohl
        {
            int x = hrac.X;
            int y = hrac.Y;

            if (x+posun <= Class.Level.mapaSirka-1)
            {
                if (level.mapa[x + posun, y] != Class.Policka.MrtvePole &&
                    level.mapa[x + posun, y] != Class.Policka.Prekazka /*&& x < Class.Level.mapaSirka - posun*/) // doprava
                {
                    return true;
                }
            }
            if (x- posun >=0 )
            {
                if (level.mapa[x - posun, y] != Class.Policka.MrtvePole &&
                    level.mapa[x - posun, y] != Class.Policka.Prekazka/* && x > posun - 1*/)// doleva
                {
                    return true;
                }
            }
            if (y + posun <= Class.Level.mapaVyska - 1)
            {
                if (level.mapa[x, y + posun] != Class.Policka.MrtvePole &&
                    level.mapa[x, y + posun] != Class.Policka.Prekazka/* && y < Class.Level.mapaVyska - posun*/)// dolu
                {
                    return true;
                }
            }
            if (y -posun>= 0)
            {
                if (level.mapa[x, y - posun] != Class.Policka.MrtvePole &&
                    level.mapa[x, y - posun] != Class.Policka.Prekazka/* && y > posun - 1*/)//nahoru
                {
                    return true;
                }
            }

            return false;
        }
        private void ObsluhaDialogResultu()//podle toho co si hrac vybere
        {
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                NastavLevel(false);
            }
            else if (result == System.Windows.Forms.DialogResult.Retry)
            {
                NastavLevel(true);
            }
            else if (result == System.Windows.Forms.DialogResult.No)
            {   
                VynulujPromene();
                UkazMenu();
            }
        }
        private void VynulujPromene()
        {
            casovac.Tick -= PocitejCas;
            casovac = null;
            cas = 0;
            level = null;
            SeznamHernichObjektu = null;
            hrac = null;
        }//vynuluje promene pro restart
        private void nastavCasovac()
        {
            casovac = new Timer();
            casovac.Tick += new EventHandler(PocitejCas);
            casovac.Interval = 1000;
            casovac.Start();
        }//nastavi casovac pri nove hre
        private void  NastavLevel(bool restart)
        {
            Class.Level Mlevel = level;
            VynulujPromene();

            if (Mlevel is Class.Levels.Level_1)
            {   if(restart)
                    level = new Class.Levels.Level_1();
                else
                    level = new Class.Levels.Level_2();
            } 
            if (Mlevel is Class.Levels.Level_2)
            {
                if (restart)
                    level = new Class.Levels.Level_2();
                else
                    level = new Class.Levels.Level_3();
            }
            if (Mlevel is Class.Levels.Level_3)
            {
                if (restart)
                    level = new Class.Levels.Level_3();
                else
                    level = new Class.Levels.Level_4();
            }
            if (Mlevel is Class.Levels.Level_4)
            {
                if (restart)
                    level = new Class.Levels.Level_4();
                else
                    level = new Class.Levels.Level_5();
            }
            if (Mlevel is Class.Levels.Level_5)
            {
                if (restart)
                    level = new Class.Levels.Level_5();
                else
                    level = new Class.Levels.Level_6();
            }
            if (Mlevel is Class.Levels.Level_6)
            {
                if (restart)
                    level = new Class.Levels.Level_6();
                else
                    level = new Class.Levels.Level_7();
            }
            if (Mlevel is Class.Levels.Level_7)
            {
                if (restart)
                    level = new Class.Levels.Level_7();
            }
            Start();
        }//nastavi dany level podle stisknu uzivatele(tlacitka restart nebo DalsiLevel)
    }
}
