/*
 * Program Name: NewGame.cs
 * Program Desc: A form to set the Player Name and Deck Size and start a new Durak game.
 * 
 * @author       Connor Simmonds-Parke
 * @author       Emeka Okoisama
 * @author       David Osagiede
 * @since        April 11, 2021
 * @version      1.0
 * 
 */

using System;
using System.Windows.Forms;

namespace Durak
{
    public partial class frmNewGame : Form
    {
        /// <summary>
        /// When the New Game form loads.
        /// </summary>
        public frmNewGame()
        {
            InitializeComponent();
            txtName.Text = frmMainForm.GetPlayerName(); //Gets the player's name. Can be changed later.
        }

        /// <summary>
        /// Sets the Player Name and Deck Size and start a new Durak game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            int deckSize = 36;

            //Checks to see which deck size to make.
            if (optDeck20.Checked)
            {
                deckSize = 20; //10 to Ace.
            }
            else if (optDeck36.Checked)
            {
                deckSize = 36; //6 to Ace.
            }
            else if (optDeck52.Checked)
            {
                deckSize = 52; //2 to Ace.
            }

            //Set the main Durak form's deckSize and playerName.
            frmMainForm.SetPlayerName(txtName.Text);
            frmMainForm.SetDeckSize(deckSize);

            //Close this form.
            this.Close();
        }
    }
}
