using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterGame.Class.Levels
{
    class Level_7 : Level
    {
        public Level_7()
            : base()
        {
            NazevLevlu = "Level 7";
        }
        public override void NastavMapu()
        {

            NastavPredmetHorizontalne(4, 0, 15, Policka.Prekazka);
            NastavPredmetHorizontalne(11, 0, 15, Policka.Prekazka);
            NastavPredmetVertikalne(5, 2, 6, Policka.Prekazka);
            NastavPredmetVertikalne(0, 9, 4, Policka.Prekazka);
            NastavPredmetVertikalne(12, 12, 6, Policka.Prekazka);
            NastavPredmetVertikalne(9, 0, 2, Policka.Prekazka);


            PridejHerniObjekty();
            NastavTeleport();

            mapa[mapaSirka - 1, mapaVyska - 1] = Policka.Dvere;

            base.NastavMapu();
        }
        protected override void PridejHerniObjekty()
        {
            PocetVajec = 20;

            NastavPredmetVertikalne(12, 13, 7, Policka.Vajicko);
            NastavPredmetVertikalne(12, 14, 7, Policka.Vajicko);
    

            for (int x = 0; x < mapaSirka; x++)
                for (int y = 0; y < mapaVyska; y++)
                {
                    if (mapa[x, y] == Policka.Vajicko)
                    {
                        Class.HerniObjekty.Vajicko v1 = new HerniObjekty.Vajicko(x, y, "cervena");
                        HerniObjektyMapy.Add(v1);
                    }
                }

            Class.HerniObjekty.Vajicko v11 = new HerniObjekty.Vajicko(7, 1, "modra");
            HerniObjektyMapy.Add(v11);
            Class.HerniObjekty.Vajicko v2 = new HerniObjekty.Vajicko(6, 4, "cervena");
            HerniObjektyMapy.Add(v2);
            Class.HerniObjekty.Vajicko v3 = new HerniObjekty.Vajicko(10, 6, "oranzova");
            HerniObjektyMapy.Add(v3);
            Class.HerniObjekty.Vajicko v4 = new HerniObjekty.Vajicko(5, 11, "modra");
            HerniObjektyMapy.Add(v4);
            Class.HerniObjekty.Vajicko v5 = new HerniObjekty.Vajicko(9, 13, "cervena");
            HerniObjektyMapy.Add(v5);
            Class.HerniObjekty.Vajicko v6 = new HerniObjekty.Vajicko(15, 4, "oranzova");
            HerniObjektyMapy.Add(v6);

            HerniObjekt m = new HerniObjekty.Mrkev(10, 1);
            HerniObjekt m1 = new HerniObjekty.Mrkev(5, 7);

            HerniObjektyMapy.Add(m);
            HerniObjektyMapy.Add(m1);


            base.PridejHerniObjekty();
        }
        protected override void NastavTeleport()
        {
            //nastavuju pozice
            PoziceTeleportu = new int[12];
            PoziceTeleportu[0] = 1;
            PoziceTeleportu[1] = 2;
            PoziceTeleportu[2] = 9;
            PoziceTeleportu[3] = 1;

            PoziceTeleportu[4] = 2;
            PoziceTeleportu[5] = 4;
            PoziceTeleportu[6] = 8;
            PoziceTeleportu[7] = 7;

            PoziceTeleportu[8] = 0;
            PoziceTeleportu[9] = 12;
            PoziceTeleportu[10] = 19;
            PoziceTeleportu[11] = 13;
            MapaPoziceTeleportu();

            base.NastavTeleport();
        }
    }
}
