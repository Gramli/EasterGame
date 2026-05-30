using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EasterGame.Class.Levels
{
    class Level_1 : Level
    {

        public Level_1()
            : base()
        {
            NazevLevlu = "Level 1";
        }
        public override void NastavMapu()
        {
            NastavTeleport();
            NastavPredmetSikmo(1, 1, true, mapaVyska,Policka.Prekazka);
            NastavPredmetSikmo(mapaSirka - 3, 2, false, mapaVyska,Policka.Prekazka);
            NastavPredmetSikmo(2,1,true,mapaVyska-3,Policka.Prekazka);
            NastavPredmetVertikalne(7, 2, 5,Policka.Prekazka);
            mapa[0, 2] = Policka.Prekazka;
            PridejHerniObjekty();
            mapa[mapaSirka - 1, mapaVyska - 1] = Policka.Dvere;
                base.NastavMapu();
        }
        protected override void PridejHerniObjekty()
        {
            //pridavam vajica
            HerniObjekt vajickoM = new HerniObjekty.Vajicko(2, 11, "modra");
            HerniObjekt vajickoC = new HerniObjekty.Vajicko(18, 4, "cervena");
            HerniObjekt vajickoO = new HerniObjekty.Vajicko(10, 8, "oranzova");
            HerniObjekt vajickoM1 = new HerniObjekty.Vajicko(14, 4, "modra");
            HerniObjekt vajickoC1 = new HerniObjekty.Vajicko(14, 11, "cervena");

            HerniObjektyMapy.Add(vajickoC);
            HerniObjektyMapy.Add(vajickoM);
            HerniObjektyMapy.Add(vajickoM1);
            HerniObjektyMapy.Add(vajickoO);
            HerniObjektyMapy.Add(vajickoC1);

            //musim definovat pocet vajec
            PocetVajec = 5;

            //pridavam Mrkve
            HerniObjekt mrkev = new HerniObjekty.Mrkev(0, 1);
            HerniObjekt mrkev1 = new HerniObjekty.Mrkev(9, 7);

            HerniObjektyMapy.Add(mrkev);
            HerniObjektyMapy.Add(mrkev1);


                base.PridejHerniObjekty();
        }//nastavuju si mapu
        protected override void NastavTeleport()
        {
            //nastavuju pozice
            PoziceTeleportu = new int[4];
            PoziceTeleportu[0] = 4;
            PoziceTeleportu[1] = 10;
            PoziceTeleportu[2] = 16;
            PoziceTeleportu[3] = 5;

            //ukazuju mape kde jsou
            MapaPoziceTeleportu();
            base.NastavTeleport();
        } // nastavuju teleport
    }
}
