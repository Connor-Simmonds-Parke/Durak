using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Durak
{
    public partial class frmStats : Form
    {
        public frmStats()
        {
            InitializeComponent();
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            string player = frmMainForm.GetPlayerName();
            int played = frmMainForm.gamesPlayed;
            int won = frmMainForm.gamesWon;
            int lost = frmMainForm.gamesLost;

            lblPlayer.Text = player;
            lblPlayed.Text = "Games Played : " + played;
            lblWon.Text = "Games Won    : " + won;
            lblLost.Text = "Games Lost   : " + lost;
        }

        /// <summary>
        /// Resets the player's stats.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            frmMainForm.ResetStats();

            string player = frmMainForm.GetPlayerName();
            int played = frmMainForm.gamesPlayed;
            int won = frmMainForm.gamesWon;
            int lost = frmMainForm.gamesLost;

            lblPlayer.Text = player;
            lblPlayed.Text = "Games Played : " + played;
            lblWon.Text = "Games Won    : " + won;
            lblLost.Text = "Games Lost   : " + lost;
        }
    }
}
