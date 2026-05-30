using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasterGame.Forms
{
    public partial class MujMessageBox : Form
    {
        public MujMessageBox()
        {
            InitializeComponent();
        }

        static MujMessageBox Msg;
        static DialogResult result = DialogResult.No;
        public static DialogResult Show(string mlvlUp, string mlblDown, string Caption, bool finish)
        {
            Msg = new MujMessageBox();
            Msg.Text = Caption;
            Msg.lblUp.Text = mlvlUp;
            Msg.lblDown.Text = mlblDown;
            if (finish)
                Msg.btnDalsiLevel.Enabled = true;
            else
                Msg.btnDalsiLevel.Enabled = false;
            Msg.ShowDialog();
            return result;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            result = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            result = System.Windows.Forms.DialogResult.Retry;
            this.Close();
        }

        private void btnDalsiLevel_Click(object sender, EventArgs e)
        {
            result = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

    }
}
