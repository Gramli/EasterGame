using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterGame.Class.Levels
{
    class Level_6 : Level
    {
        public Level_6() : base()
        {
            NazevLevlu = "Level 6";
        }
        public override void NastavMapu()
        {

            NastavPredmetHorizontalne(1, 0, 13, Policka.Prekazka);
            NastavPredmetVertikalne(2, 4, 6, Policka.Prekazka);
            NastavPredmetHorizontalne(2, 5, 10, Policka.Prekazka);
            NastavPredmetHorizontalne(8, 0, mapaVyska, Policka.Prekazka);
            NastavPredmetHorizontalne(9, 3, 4, Policka.Prekazka);
            NastavPredmetHorizontalne(10, 6, 2, Policka.Prekazka);
            NastavPredmetSikmo(11, 8, true, 6, Policka.Prekazka);
            NastavPredmetSikmo(12, 8, true, 4, Policka.Prekazka);
            NastavPredmetHorizontalne(16, 10, 5, Policka.Prekazka);
            NastavPredmetVertikalne(17, 10, 3, Policka.Prekazka);

            
            PridejHerniObjekty();
            NastavTeleport();

            mapa[mapaSirka - 1, mapaVyska - 1] = Policka.Dvere;

            base.NastavMapu();
        }
        protected override void PridejHerniObjekty()
        {
            PocetVajec = 37;
            int yt = 7;
            int pocet = 8;
            for (int i = 9; i < 16; i++)
            {
                NastavPredmetHorizontalne(i, yt, pocet,Policka.Vajicko);
                yt++;
                pocet--;
            }
            mapa[9, 14] = Policka.Nic;
            mapa[10, 11] = Policka.Nic;

                for (int x = 0; x < mapaSirka; x++)
                    for (int y = 0; y < mapaVyska; y++)
                    {
                        if (mapa[x, y] == Policka.Vajicko)
                        {
                            Class.HerniObjekty.Vajicko v1 = new HerniObjekty.Vajicko(x, y, "cervena");
                            HerniObjektyMapy.Add(v1);
                        }
                    }

                Class.HerniObjekty.Vajicko v11 = new HerniObjekty.Vajicko(1, 13, "modra");
                HerniObjektyMapy.Add(v11);
                Class.HerniObjekty.Vajicko v2 = new HerniObjekty.Vajicko(4, 2, "cervena");
                HerniObjektyMapy.Add(v2);
                Class.HerniObjekty.Vajicko v3 = new HerniObjekty.Vajicko(14, 2, "oranzova");
                HerniObjektyMapy.Add(v3);
                Class.HerniObjekty.Vajicko v4 = new HerniObjekty.Vajicko(14, 9, "modra");
                HerniObjektyMapy.Add(v4);

            HerniObjekt m = new HerniObjekty.Mrkev(0, 3);
            HerniObjekt m1 = new HerniObjekty.Mrkev(5, 3);
            HerniObjekt m2 = new HerniObjekty.Mrkev(9, 14);
            HerniObjekt m3 = new HerniObjekty.Mrkev(4, 11);
            HerniObjekt m4 = new HerniObjekty.Mrkev(16, 9);
            HerniObjekt m5 = new HerniObjekty.Mrkev(17, 9);
            
            HerniObjektyMapy.Add(m);
            HerniObjektyMapy.Add(m1);
            HerniObjektyMapy.Add(m2);
            HerniObjektyMapy.Add(m3);
            HerniObjektyMapy.Add(m4);
            HerniObjektyMapy.Add(m5);

            base.PridejHerniObjekty();
        }
        protected override void NastavTeleport()
        {
            //nastavuju pozice
            PoziceTeleportu = new int[8];
            PoziceTeleportu[0] = 15;
            PoziceTeleportu[1] = 3;
            PoziceTeleportu[2] = 10;
            PoziceTeleportu[3] = 11;

            PoziceTeleportu[4] = 0;
            PoziceTeleportu[5] = 10;
            PoziceTeleportu[6] = 17;
            PoziceTeleportu[7] = 14;
            MapaPoziceTeleportu();

            base.NastavTeleport();
        }
    }
}
