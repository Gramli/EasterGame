using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterGame.Class.Levels
{
    class Level_2 : Level
    {
        public Level_2() : base()
        {
            NazevLevlu = "Level 2";
        }
        public override void NastavMapu()
        {
            NastavPredmetHorizontalne(1, 0, 12,Policka.Prekazka);
            NastavPredmetHorizontalne(5, 0, 15, Policka.Prekazka);
            NastavPredmetHorizontalne(3, 4, 3, Policka.Prekazka);
            NastavPredmetHorizontalne(3, 9, 6, Policka.Prekazka);
            NastavPredmetVertikalne(4, 4, 17, Policka.Prekazka);
            NastavPredmetHorizontalne(11, 0, 6, Policka.Prekazka);
            NastavPredmetSikmo(8, 5, true, 10, Policka.Prekazka);
            PridejHerniObjekty();
            NastavTeleport();
            mapa[mapaSirka - 1, mapaVyska - 1] = Policka.Dvere;
            base.NastavMapu();
        }
        protected override void PridejHerniObjekty()
        {
            Class.HerniObjekty.Vajicko v1 = new HerniObjekty.Vajicko(2, 13,"modra");
            HerniObjektyMapy.Add(v1);
            Class.HerniObjekty.Vajicko v2 = new HerniObjekty.Vajicko(4, 1, "cervena");
            HerniObjektyMapy.Add(v2);
            Class.HerniObjekty.Vajicko v3 = new HerniObjekty.Vajicko(4, 11, "oranzova");
            HerniObjektyMapy.Add(v3);
            Class.HerniObjekty.Vajicko v4 = new HerniObjekty.Vajicko(8, 12, "modra");
            HerniObjektyMapy.Add(v4);
            Class.HerniObjekty.Vajicko v5 = new HerniObjekty.Vajicko(9, 1, "modra");
            HerniObjektyMapy.Add(v5);
            Class.HerniObjekty.Vajicko v6 = new HerniObjekty.Vajicko(19, 2, "cervena");
            HerniObjektyMapy.Add(v6);
            Class.HerniObjekty.Vajicko v7 = new HerniObjekty.Vajicko(15, 8, "oranzova");
            HerniObjektyMapy.Add(v7);
            Class.HerniObjekty.Vajicko v8 = new HerniObjekty.Vajicko(19, 12, "modra");
            HerniObjektyMapy.Add(v8);

            PocetVajec = 8;

            

            HerniObjekt m = new HerniObjekty.Mrkev(2, 0);
            HerniObjekt m1 = new HerniObjekty.Mrkev(4, 12);
            HerniObjekt m2 = new HerniObjekty.Mrkev(6, 0);
            HerniObjekt m3 = new HerniObjekty.Mrkev(12, 10);

            HerniObjektyMapy.Add(m);
            HerniObjektyMapy.Add(m1);
            HerniObjektyMapy.Add(m2);
            HerniObjektyMapy.Add(m3);

            base.PridejHerniObjekty();
        }
        protected override void NastavTeleport()
        {
            //nastavuju pozice
            PoziceTeleportu = new int[4];
            PoziceTeleportu[0] = 17;
            PoziceTeleportu[1] = 1;
            PoziceTeleportu[2] = 16;
            PoziceTeleportu[3] = 6;

            MapaPoziceTeleportu();

            base.NastavTeleport();
        }
    }
}
