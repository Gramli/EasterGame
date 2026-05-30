using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterGame.Class.Levels
{
    class Level_4 : Level
    {
        public Level_4() : base()
        {
            NazevLevlu = "Level 4";
        }
        public override void NastavMapu()
        {

            NastavPredmetHorizontalne(1, 3, 12, Policka.Prekazka);
            NastavPredmetVertikalne(1, 3, 19, Policka.Prekazka);
            NastavPredmetHorizontalne(7, 4, 3, Policka.Prekazka);
            NastavPredmetHorizontalne(9, 4, 6, Policka.Prekazka);
            NastavPredmetHorizontalne(12, 4, 2, Policka.Prekazka);
            NastavPredmetVertikalne(10, 1, 10, Policka.Prekazka);
            NastavPredmetHorizontalne(15, 4, 11, Policka.Prekazka);
            NastavPredmetSikmo(14, 5, false, 10, Policka.Prekazka);
            PridejHerniObjekty();
            NastavTeleport();

            mapa[mapaSirka - 1, mapaVyska - 1] = Policka.Dvere;

            base.NastavMapu();
        }
        protected override void PridejHerniObjekty()
        {
            PocetVajec = 51;
            NastavPredmetVertikalne(1, 0, 19, Policka.Vajicko);
            NastavPredmetVertikalne(1, 1, 9, Policka.Vajicko);
            NastavPredmetVertikalne(0, 2, 19, Policka.Vajicko);
            NastavPredmetHorizontalne(8, 7, 3, Policka.Vajicko);

            for (int x = 0; x < mapaSirka; x++)
                for (int y = 0; y < mapaVyska; y++)
                {
                    if (mapa[x, y] == Policka.Vajicko)
                    {
                        Class.HerniObjekty.Vajicko v1 = new HerniObjekty.Vajicko(x,y, "modra");
                        HerniObjektyMapy.Add(v1);
                    }
                }

            Class.HerniObjekty.Vajicko v2 = new HerniObjekty.Vajicko(13, 4, "cervena");
            HerniObjektyMapy.Add(v2);
            HerniObjekt m = new HerniObjekty.Mrkev(0, 1);
            HerniObjekt m1 = new HerniObjekty.Mrkev(8, 5);
            HerniObjekt m2 = new HerniObjekty.Mrkev(19, 2);

            HerniObjektyMapy.Add(m);
            HerniObjektyMapy.Add(m1);
            HerniObjektyMapy.Add(m2);

            base.PridejHerniObjekty();
        }
        protected override void NastavTeleport()
        {
            //nastavuju pozice
            PoziceTeleportu = new int[8];
            PoziceTeleportu[0] = 0;
            PoziceTeleportu[1] = 8;
            PoziceTeleportu[2] = 8;
            PoziceTeleportu[3] = 6;

            PoziceTeleportu[4] = 13;
            PoziceTeleportu[5] = 5;
            PoziceTeleportu[6] = 18;
            PoziceTeleportu[7] = 8;
            MapaPoziceTeleportu();

            base.NastavTeleport();
        }
    }
}
