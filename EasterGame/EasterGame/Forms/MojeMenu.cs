using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasterGame.Forms
{
    public partial class MojeMenu : UserControl
    {
        public MojeMenu()
        {
            InitializeComponent();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNavod_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dostaň se do cíle a posbírej včechny vajíčka za co nejkratší čas a co nejméně tahů. Nelze dvakrát stoupnout na stejné pole!!"+Environment.NewLine +
                "Zajíc se ovládá šipkami. Pokud vezmeš mrkev, můžeš přeskočit překážku nebo mrtvé pole pomocí mezerníku(Zajíc musí být natočený tam kam chceš skákat)." + Environment.NewLine +
                "Pokud vstoupíš na políčko teleport, oběvíš se na políčku druhého teleportu. Hudba se vypíná ve hře písmenkem S."+ Environment.NewLine +
                "Ukončil level můžeš zablokováním zajíčka!", "EasterGame - návod");
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game was designed and created by Gramli." +Environment.NewLine+Environment.NewLine+
            "Pictures are downloaded from http://opengameart.org and modified." +Environment.NewLine+Environment.NewLine+
            "Music: Mellowtron by Kevin MacLeod (incompetech.com) Licensed under Creative Commons: By Attribution 3.0 http://creativecommons.org/licenses/by/3.0/"
            , "EasterGame - Credits");
        }
    }
}
