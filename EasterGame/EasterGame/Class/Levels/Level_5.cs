using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterGame.Class.Levels
{
    class Level_5 :Level
    {
        public Level_5() : base()
        {
            NazevLevlu = "Level 5";
        }
        public override void NastavMapu()
        {

            NastavPredmetHorizontalne(3, 1, 14, Policka.Prekazka);
            NastavPredmetVertikalne(0, 12, mapaSirka, Policka.Prekazka);
            NastavPredmetSikmo(4, 2,true, 10,Policka.Prekazka);
            NastavPredmetSikmo(19, 5, false, 6, Policka.Prekazka);
            NastavPredmetHorizontalne(9, 13, 2, Policka.Prekazka);
            NastavPredmetHorizontalne(14, 13, 2, Policka.Prekazka);

            
            PridejHerniObjekty();
            NastavTeleport();

            mapa[mapaSirka - 1, mapaVyska - 1] = Policka.Dvere;
            mapa[0, mapaVyska - 1] = Policka.Dvere;

            base.NastavMapu();
        }
        protected override void PridejHerniObjekty()
        {
            PocetVajec = 5;

            Class.HerniObjekty.Vajicko v1 = new HerniObjekty.Vajicko(6, 8, "modra");
            HerniObjektyMapy.Add(v1);
            Class.HerniObjekty.Vajicko v2 = new HerniObjekty.Vajicko(10, 2, "cervena");
            HerniObjektyMapy.Add(v2);
            Class.HerniObjekty.Vajicko v3 = new HerniObjekty.Vajicko(14, 5, "oranzova");
            HerniObjektyMapy.Add(v3);
            Class.HerniObjekty.Vajicko v4 = new HerniObjekty.Vajicko(11, 13, "modra");
            HerniObjektyMapy.Add(v4);
            Class.HerniObjekty.Vajicko v5 = new HerniObjekty.Vajicko(18, 9, "cervena");
            HerniObjektyMapy.Add(v5);

            HerniObjekt m = new HerniObjekty.Mrkev(1, 3);
            HerniObjekt m1 = new HerniObjekty.Mrkev(4, 14);
            HerniObjekt m2 = new HerniObjekty.Mrkev(8, 11);
            HerniObjekt m3 = new HerniObjekty.Mrkev(17, 11);

            HerniObjektyMapy.Add(m);
            HerniObjektyMapy.Add(m1);
            HerniObjektyMapy.Add(m2);
            HerniObjektyMapy.Add(m3);

            base.PridejHerniObjekty();
        }
        protected override void NastavTeleport()
        {
            //nastavuju pozice
            PoziceTeleportu = new int[8];
            PoziceTeleportu[0] = 6;
            PoziceTeleportu[1] = 14;
            PoziceTeleportu[2] = 19;
            PoziceTeleportu[3] = 9;

            PoziceTeleportu[4] = 12;
            PoziceTeleportu[5] = 14;
            PoziceTeleportu[6] = 17;
            PoziceTeleportu[7] = 14;
            MapaPoziceTeleportu();

            base.NastavTeleport();
        }
    }
}
