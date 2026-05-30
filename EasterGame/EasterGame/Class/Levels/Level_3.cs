using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterGame.Class.Levels
{
    class Level_3 : Level
    {
        public Level_3()
            : base()
        {
            NazevLevlu = "Level 3";
        }
        public override void NastavMapu()
        {
            NastavPredmetHorizontalne(1, 1, 11, Policka.Prekazka);
            NastavPredmetSikmo(2, 1, true, 4, Policka.Prekazka);
            NastavPredmetSikmo(7, 6, true, 2, Policka.Prekazka);
            NastavPredmetHorizontalne(9, 2, 13, Policka.Prekazka);
            NastavPredmetHorizontalne(13, 3, 12, Policka.Prekazka);
            NastavPredmetHorizontalne(15, 5, 10, Policka.Prekazka);
            NastavPredmetHorizontalne(17, 7, 8, Policka.Prekazka);
            NastavPredmetVertikalne(14, 3, 6, Policka.Prekazka);
            NastavPredmetVertikalne(16, 5, 4, Policka.Prekazka);
            NastavPredmetVertikalne(18, 7, 2, Policka.Prekazka);
            NastavPredmetHorizontalne(18, 0, 3, Policka.Prekazka);

            PridejHerniObjekty();
            NastavTeleport();

            mapa[mapaSirka - 1, mapaVyska - 1] = Policka.Dvere;

            base.NastavMapu();
        }
        protected override void PridejHerniObjekty()
        {
            PocetVajec = 5;

            Class.HerniObjekty.Vajicko v1 = new HerniObjekty.Vajicko(4, 0, "modra");
            HerniObjektyMapy.Add(v1);
            Class.HerniObjekty.Vajicko v2 = new HerniObjekty.Vajicko(10, 12, "cervena");
            HerniObjektyMapy.Add(v2);
            Class.HerniObjekty.Vajicko v3 = new HerniObjekty.Vajicko(14, 5, "oranzova");
            HerniObjektyMapy.Add(v3);
            Class.HerniObjekty.Vajicko v4 = new HerniObjekty.Vajicko(16, 7, "modra");
            HerniObjektyMapy.Add(v4);
            Class.HerniObjekty.Vajicko v5 = new HerniObjekty.Vajicko(16, 1, "cervena");
            HerniObjektyMapy.Add(v5);

            HerniObjekt m = new HerniObjekty.Mrkev(0, 2);
            HerniObjekt m1 = new HerniObjekty.Mrkev(2, 3);
            HerniObjekt m2 = new HerniObjekty.Mrkev(11, 7);

            HerniObjektyMapy.Add(m);
            HerniObjektyMapy.Add(m1);
            HerniObjektyMapy.Add(m2);

            base.PridejHerniObjekty();
        }
        protected override void NastavTeleport()
        {
            //nastavuju pozice
            PoziceTeleportu = new int[4];
            PoziceTeleportu[0] = 5;
            PoziceTeleportu[1] = 12;
            PoziceTeleportu[2] = 19;
            PoziceTeleportu[3] = 2;

            MapaPoziceTeleportu();

            base.NastavTeleport();
        }
    }
}
