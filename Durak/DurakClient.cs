/*
 * Program Name: DurakClient.cs
 * Program Desc: Two player traditional Durak card game with one computer player and one human player.
 * 
 * @author       
 * Connor Simmonds-Parke
 * @author       Emeka Okoisama
 * @author       David Osagiede
 * @since        April 11, 2021
 * @version      1.0
 * 
 */

using System;
using System.IO; //For StreamWriter.
using System.Text; //For StringBuilder.
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using DurakCardBox; //For CardBox (PictureBox of a playing Card).
using CardLibrary; //Card and Deck classes.


namespace Durak
{
    public partial class frmMainForm : Form
    {
        #region Fields And Properties       
        /// <summary>
        /// A default Deck.
        /// </summary>
        private Deck aDeck = new Deck();

        /// <summary>
        /// The last Attack Card that was placed.
        /// </summary>
        private CardBox lastAttackCard = new CardBox();

        /// <summary>
        /// The last River Panel the Card was placed in.
        /// </summary>
        private Panel lastPanel;

        /// <summary>
        /// The amount, in points, that CardBox controls are enlarged when hovered over. 
        /// </summary>
        const int POP = 25;

        /// <summary>
        /// The regular size of a CardBox control.
        /// </summary>
        static private Size regularSize = new Size(75, 107);

        /// <summary>
        /// Refers to the card being dragged from one panel to another.
        /// </summary>
        private CardBox dragCard;

        /// <summary>
        /// Whether the player is Attacking or Defending.
        /// </summary>
        private bool playerAttacking = true;

        /// <summary>
        /// The Trump Suit.
        /// </summary>
        private Suit trumpSuit;

        /// <summary>
        /// The Attack Turn Number (Five maximum for a round).
        /// </summary>
        private int attackTurn = 0;

        /// <summary>
        /// The Round number
        /// </summary>
        private int turn = 0;

        /// <summary>
        /// Value to hold whether certain functions for debugging/testing are on/off.
        /// </summary>
        private bool debug = false;

        /// <summary>
        /// The player's name. Also used to get their stats.
        /// </summary>
        public static string playerName = "Player";
        /// <summary>
        /// Sets the player's Name.
        /// </summary>
        /// <param name="name">Player Name</param>
        public static void SetPlayerName(string name)
        {
            frmMainForm.playerName = name;
        }
        /// <summary>
        /// Gets the player's Name.
        /// </summary>
        /// <returns>String of Player's Name</returns>
        public static string GetPlayerName()
        {
            return frmMainForm.playerName;
        }

        /// <summary>
        /// The Size of the deck. 20, 36, or 52.
        /// </summary>
        public static int deckSize;
        /// <summary>
        /// Set's the deck size.
        /// </summary>
        /// <param name="size">Size of the deck</param>
        public static void SetDeckSize(int size)
        {
            frmMainForm.deckSize = size;
        }

        /// <summary>
        /// Holds all the game actions to later write to a logs file.
        /// </summary>
        private StringBuilder gameActions = new StringBuilder();

        /// <summary>
        /// Number of Games played for the current player. 
        /// </summary>
        public static int gamesPlayed;
        public int GetGamesPlayed()
        {
            return frmMainForm.gamesPlayed;
        }

        /// <summary>
        /// Number of Games Won for the current Player.
        /// </summary>
        public static int gamesWon;
        public int GetGamesWon()
        {
            return frmMainForm.gamesWon;
        }
        /// <summary>
        /// Number of Games Lost for the current player.
        /// </summary>
        public static int gamesLost;
        public int GetGamesLost()
        {
            return frmMainForm.gamesLost;
        }
        #endregion

        #region Human Player Game Logic & Panel Functions
        /// <summary>
        /// This is the main game logic for the Human Player.
        /// Move a card/control when it is dropped from one Panel to another. 
        /// Effect changes slightly based on if the player is attacking or defending.
        /// </summary>
        /// <param name="sender">Panel the Card is being dropped into</param>
        /// <param name="e">DragDrop</param>
        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            //If the Player is Attacking.
            if (playerAttacking == true)
            {
                //If there is a CardBox to move.
                if (dragCard != null)
                {
                    //Determine which Panel is which.
                    Panel thisPanel = sender as Panel;
                    Panel fromPanel = dragCard.Parent as Panel;

                    //If neither panel is null (no conversion issue).
                    if (thisPanel != null && fromPanel != null)
                    {
                        //If the CardBox is from the Player's Hand and is going into the correct River Panel.
                        if (fromPanel == pnlPlayer && thisPanel == pnlRiver.Controls[attackTurn])
                        {
                            bool validAttack = false; //If the player has dragged a valid attack card.

                            //6 Attacks in a round. 
                            //If not the first attack in the round then the dragged card has to match one that has already been played.
                            if (attackTurn > 0)
                            {
                                foreach (Panel riverPanelCards in pnlRiver.Controls)
                                {
                                    //If there is a valid card this stops some of the additional checks.
                                    if (validAttack == false)
                                    {
                                        foreach (CardBox riverCards in riverPanelCards.Controls)
                                        {
                                            //If the dragged card matches the rank.
                                            if (riverCards.Rank == dragCard.Rank)
                                            {
                                                validAttack = true;
                                            }
                                            else //If not, inform the player why.
                                            {
                                                //Update Player Actions Label.
                                                lblPlayerText.Text = dragCard.ToString() + " doesn't match the Rank of any previously played cards\nTry again";
                                            }
                                        }
                                    }
                                }
                            }
                            else //This is the first attack, no additional attack requirements.
                            {
                                validAttack = true;
                            }

                            //If there is a card that is valid to attack.
                            if (validAttack == true)
                            {
                                dragCard.Top = 0;

                                //Remove the card from the Panel it started in + add the card to the Panel it was dropped in.
                                fromPanel.Controls.Remove(dragCard);
                                thisPanel.Controls.Add(dragCard);

                                // Realign cards in Player's Hand.
                                RealignCards(fromPanel);

                                //Save the drag card and the river panel it was dragged onto.
                                lastAttackCard = dragCard;
                                lastPanel = thisPanel;

                                //Log the Attack for the Player.
                                gameActions.AppendLine(playerName + " Attacked with " + dragCard.ToString());

                                //Increase the attack turn count.
                                attackTurn++;
                               
                                if (pnlPlayer.Controls.Count < 1 && aDeck.GetCardsLeft() < 1)
                                {
                                    GameOver();
                                }
                                else if (ComputerDefend() == true) //Computer succesfully defended.
                                {
                                    if (pnlCPU.Controls.Count < 1 && aDeck.GetCardsLeft() < 1)
                                    {
                                        GameOver();
                                    }
                                }
                                else //Computer failed defense.
                                {
                                    RoundEndDraw();
                                    ClearRiver();
                                    attackTurn = 0;
                                }

                                if (attackTurn > 6)
                                {
                                    playerAttacking = false;
                                    ClearRiver();
                                    attackTurn = 0;
                                    UpdateLabels();
                                    UpdatePanels();

                                    //Player Actions Label.
                                    lblPlayerText.Text = "Opponent Defended against all your Attacks to end the Turn";

                                    //Log the CPU successful full defense.
                                    gameActions.AppendLine("Opponent Defended against all of " + playerName + "'s Attacks. End of turn " + turn);
                                }

                                //Update Attack/Defend Labels and Panels.
                                UpdateLabels();
                                UpdatePanels();
                            }
                        }
                    }
                }
            }
            else //Player is defending.
            {
                if (dragCard != null)
                {
                    // Determine which Panel is which.
                    Panel thisPanel = sender as Panel;
                    Panel fromPanel = dragCard.Parent as Panel;

                    // If neither panel is null (no conversion issue).
                    if (thisPanel != null && fromPanel != null)
                    {
                        // if the Panels are not the same.
                        if (fromPanel == pnlPlayer && thisPanel == lastPanel)
                        {
                            bool playerDefended = false;

                            if (lastAttackCard.Suit == trumpSuit)
                            {
                                if (dragCard.Suit == trumpSuit)
                                {
                                    if (dragCard.Rank > lastAttackCard.Rank)
                                    {
                                        playerDefended = true;
                                    }
                                    else
                                    {
                                        //Player Actions Label.
                                        lblPlayerText.Text = dragCard.ToString() + " is not a higher Rank than " + lastAttackCard.ToString() +
                                            "\nTry again";
                                    }
                                }
                                else
                                {
                                    //Player Actions Label.
                                    lblPlayerText.Text = lastAttackCard.ToString() + " is a Trump Suit while " + dragCard.ToString() +
                                        " is not\nTry again";
                                }
                            }
                            else if (dragCard.Suit == trumpSuit && lastAttackCard.Suit != trumpSuit)
                            {
                                playerDefended = true;
                            }
                            else if (dragCard.Rank > lastAttackCard.Rank)
                            {
                                playerDefended = true;
                            }
                            else //Card isn't a valid Defend card.
                            {
                                //Player Actions Label.
                                lblPlayerText.Text = dragCard.ToString() + " is not a higher Rank than " + lastAttackCard.ToString() +
                                    "\nTry again";
                            }

                            if (playerDefended == true)
                            {

                                lastPanel.Controls.Add(dragCard);
                                pnlPlayer.Controls.Remove(dragCard);

                                //Log Player Defend.
                                gameActions.AppendLine(playerName + " defended against " + lastAttackCard.ToString() + " with " +
                                    dragCard.ToString());

                                RealignCards(pnlPlayer);
                                RealignRiver(lastPanel);

                                attackTurn++;
                                UpdateLabels();
                                UpdatePanels();


                                if (pnlPlayer.Controls.Count < 1 && pnlDeck.Controls.Count < 1)
                                {
                                    GameOver();
                                }
                                else if (pnlCPU.Controls.Count < 1 && pnlDeck.Controls.Count < 1)
                                {
                                    GameOver();
                                }

                                if (attackTurn > 6)
                                {
                                    ClearRiver();
                                    playerAttacking = true;

                                    //Log Player complete Defend successful.
                                    gameActions.AppendLine(playerName + " Defended against all Attacks. End of turn " + turn);
                                }
                                else
                                {
                                    ComputerAttack();
                                    UpdateLabels();
                                    UpdatePanels();
                                }


                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Make the mouse pointer a "move" pointer when a drag enters an allowed Panel.
        /// </summary>
        /// <param name="sender">Panel the Card is being dragged over</param>
        /// <param name="e">DragEnter</param>
        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            Panel thisPanel = sender as Panel;

            if (thisPanel != null) //Make sure there is a Panel.
            {
                if (thisPanel == pnlRiver.Controls[attackTurn]) //Checks the panel to make sure it is the active river panel.
                {
                    // Make the mouse pointer a "move" pointer
                    e.Effect = DragDropEffects.Move;
                }
            }
        }
        #endregion

        #region CPU Attack/Defend Logic
        /// <summary>
        /// Computer logic for Attacking. Keeps higher rank or Trump cards unless needed.
        /// </summary>
        private void ComputerAttack()
        {
            if (pnlCPU.Controls.Count > 0)
            {
                CardBox validAttackCard = new CardBox(Rank.Ace, Suit.Club);
                CardBox tempTrumpAttack = new CardBox(Rank.Ace, trumpSuit);
                List<CardBox> validAttackCards = new List<CardBox>();

                bool nonTrumpAttack = false;
                bool trumpAttack = false;
                bool validAttack = false;

                if (attackTurn > 0)
                {
                    foreach (CardBox card in pnlCPU.Controls)
                    {
                        foreach (Control riverCardPanels in pnlRiver.Controls)
                        {
                            foreach (CardBox riverCards in riverCardPanels.Controls)
                            {
                                if (card.Rank == riverCards.Rank)
                                {
                                    validAttackCards.Add(card);
                                    validAttack = true;
                                }
                            }
                        }
                    }

                    if (validAttack == true)
                    {
                        foreach (CardBox card in validAttackCards)
                        {
                            if (card.Rank <= validAttackCard.Rank && card.Suit != trumpSuit)
                            {
                                validAttackCard = card;
                                nonTrumpAttack = true;
                                validAttack = true;
                            }
                            else if (card.Suit == trumpSuit && card.Rank <= tempTrumpAttack.Rank)
                            {
                                tempTrumpAttack = card;
                                trumpAttack = true;
                            }

                            if (nonTrumpAttack == false && trumpAttack == true)
                            {
                                validAttackCard = tempTrumpAttack;
                                validAttack = true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (CardBox card in pnlCPU.Controls)
                    {
                        if (card.Rank <= validAttackCard.Rank && card.Suit != trumpSuit)
                        {
                            validAttackCard = card;
                            nonTrumpAttack = true;
                            validAttack = true;
                        }
                        else if (card.Suit == trumpSuit && card.Rank <= tempTrumpAttack.Rank)
                        {
                            tempTrumpAttack = card;
                            trumpAttack = true;
                        }

                        if (nonTrumpAttack == false && trumpAttack == true)
                        {
                            validAttackCard = tempTrumpAttack;
                            validAttack = true;
                        }
                    }
                }

                //If the CPU has a valid card to attack with.
                if (validAttack == true)
                {
                    validAttackCard.FaceUp = true; //Turn the attack card face up.
                    pnlRiver.Controls[attackTurn].Controls.Add(validAttackCard); //Move the attack card to the correct river panel.

                    //Realign the computer's hand and the river panel.
                    RealignCards(pnlCPU);
                    validAttackCard.Top = 0;
                    validAttackCard.Left = 0;

                    //Set the last panel attacked and the last attack card. (Quick n' dirty, might change later).
                    lastPanel = pnlRiver.Controls[attackTurn] as Panel;
                    lastAttackCard = validAttackCard;

                    //CPU Actions Label.
                    lblCPUText.Text = "I'll attack with " + validAttackCard.ToString();

                    //Player Actions Label.
                    lblPlayerText.Text = "";

                    //Log the CPU Attack.
                    gameActions.AppendLine("Opponent Attacked with " + validAttackCard.ToString()); 
                }
                else //CPU can't attack, end of CPU attack turn.
                {
                    //Draw Cards for both CPU and Player
                    RoundEndDraw();

                    //Clear River.
                    ClearRiver();

                    //Reset attack turn and make player the Attacker.
                    attackTurn = 0;
                    playerAttacking = true;

                    //CPU Actions Label
                    lblCPUText.Text = "I have no cards to Attack with\nI'll Pass";

                    //Player Actions Label
                    lblPlayerText.Text = "Opponent couldn't Attack and Passed to end the Turn\nStart a new Attack";

                    //Log the CPU Pass
                    gameActions.AppendLine("Opponent Passed their Attack. End of turn " + turn);
                }
            }

            //If there are no more cards in the deck nor the Computer's Hand then calls then the Human Player has lost (game over).
            if (pnlCPU.Controls.Count < 1 && pnlDeck.Controls.Count < 1)
            {
                GameOver();
            }
        }

        /// <summary>
        /// Computer logic for defending. Checks for the lowest possible rank for defending. If the attacking card is a trump
        /// checks for lowest valid rank of a trump card.
        /// </summary>
        /// <returns>If the computer could defend against the attack or not</returns>
        private bool ComputerDefend()
        {
            CardBox validDefendCard = new CardBox();              //A valid card from the CPU hand (if there is, this will then used later).
            List<CardBox> validDefendCards = new List<CardBox>(); //A list of valid cards to defend with (if any).

            bool attackCardIsTrump = false; //If the attacking card is a trump Suit.
            bool validDefend = false;       //If the CPU Hand has any valid cards to defend with.

            //Check if the attack card's Suit was the Trump suit.
            if (lastAttackCard.Suit == trumpSuit)
            {
                attackCardIsTrump = true;
            }

            //Collect a list of all the valid defend cards for the CPU.
            foreach (CardBox card in pnlCPU.Controls)
            {
                //If both the attacking and defending card are Trump suits, checks to see if the defending is higher rank.
                if (attackCardIsTrump == true)
                {
                    if (card.Suit == trumpSuit)
                    {
                        if (card.Rank > lastAttackCard.Rank)
                        {
                            //The defending card is a trump and higher rank than the attacking trump card, add it to the list of valid cards.
                            validDefendCards.Add(card);
                        }
                    }
                }
                else if (card.Suit == trumpSuit && attackCardIsTrump == false)
                {
                    validDefendCards.Add(card);
                }
                else if (card.Rank > lastAttackCard.Rank)
                {
                    validDefendCards.Add(card);
                }
            }

            //If the attack card is a Trump Suit, checks each of the valid cards to see which is the lowest (best) to use.
            if (attackCardIsTrump == true)
            {
                Card tempCard = new Card(trumpSuit, Rank.Ace); //Create a highest rank (Ace) trump card.
                CardBox bestCard = new CardBox(tempCard); //Create a CardBox of that card to test against the ones in the list (if any).
                bool cardChanged = false; //In the case of a card possibly being the same as the temp, this needs to be changed to true.

                foreach (CardBox card in validDefendCards)
                {
                    //Checks to find the lowest rank it can use in the list. 
                    if (card.Rank <= bestCard.Rank)
                    {
                        bestCard = card;
                        cardChanged = true;
                    }

                    //If the temporary best card was changed at any point.
                    if (cardChanged == true)
                    {
                        validDefend = true;
                        validDefendCard = bestCard;
                    }

                }
            }
            else //The attack card is not a Trump, so it doesn't require a Defending Trump Card.
            {
                Card tempCard = new Card(Suit.Club, Rank.Ace); //Create a highest rank (Ace) card (Suit doesn't matter).
                CardBox bestCard = new CardBox(tempCard); //Create a CardBox of that card to test against the ones in the list (if any).
                bool cardChanged = false; //In the case of a card possibly being the same as the temp, this needs to be changed to true.

                foreach (CardBox card in validDefendCards)
                {
                    //Checks to find the lowest rank it can use in the list. 
                    if (card.Suit != trumpSuit && card.Rank <= bestCard.Rank)
                    {
                        bestCard = card;
                        cardChanged = true;
                    }
                }

                //If there were no non-Trump Cards in the list, can simply take the lowest rank.
                if (cardChanged == false)
                {
                    foreach (CardBox card in validDefendCards)
                    {
                        if (card.Rank <= bestCard.Rank)
                        {
                            bestCard = card;
                            cardChanged = true;
                        }
                    }
                }

                //If the temporary best card was changed at any point.
                if (cardChanged == true)
                {
                    validDefend = true;
                    validDefendCard = bestCard;
                }
            }

            //If the computer has a card that can defend against the attacking card.
            if (validDefend == true)
            {
                validDefendCard.FaceUp = true;           //Turn the Card Face up. 
                lastPanel.Controls.Add(validDefendCard); //Move that card to the correct River panel.

                //Realign the CPU hand and River.
                RealignRiver(lastPanel);
                RealignCards(pnlCPU);

                //CPU Actions Label.
                lblCPUText.Text = "I'll defend with " + validDefendCard.ToString();

                //Player Actions Label.
                lblPlayerText.Text = "Opponent successfully Defended\nStart a new Attack";

                //Log the CPU Defense.
                gameActions.AppendLine("Opponent successfully Defended with " + validDefendCard.ToString());
            }
            else //Computer couldn't defend
            {
                //CPU Actions Label.
                lblCPUText.Text = "I can't defend against " + lastAttackCard.ToString() + "\nI'll Pick Up";

                //Player Actions Label.
                lblPlayerText.Text = "Opponent couldn't Defend and picked up all the River cards to end the Turn\nStart a new Attack";

                //Log the CPU Pick Up (failed Defense).
                gameActions.AppendLine("Opponent couldn't Defend and Picked Up. End of turn" + turn);

                //Add River Cards to CPU hand.
                foreach (Control riverPanels in pnlRiver.Controls)
                {
                    if (riverPanels.Controls != null)
                    {
                        foreach (CardBox riverPanelCard in riverPanels.Controls)
                        {
                            //Log the drawn Card(s) for the CPU.
                            gameActions.AppendLine("Opponent Picked Up " + riverPanelCard.ToString() + " from the River");

                            //If debug is not on, turn the card face down.
                            if (debug == false)
                            {
                                riverPanelCard.FaceUp = false;
                            }
                            
                            //Add the Card to the CPU's Hand.
                            pnlCPU.Controls.Add(riverPanelCard);

                            
                        }
                    }
                }

                //Draw a card from the Deck and put it into Computer's Hand if there is any left in the deck.
                if (pnlDeck.Controls.Count > 0)
                {
                    //Create and assign a temp CardBox.
                    CardBox tempCard = new CardBox();
                    tempCard = pnlDeck.Controls[0] as CardBox;

                    //Log the drawn card for the CPU.
                    tempCard.FaceUp = true;
                    gameActions.AppendLine("Because the Opponent couldn't Defend they also drew " + tempCard.ToString());
                    tempCard.FaceUp = false;

                    WireCardBox(tempCard);            //Wire the card.                   
                    pnlCPU.Controls.Add(tempCard);    //Add it to the computer's hand.                    
                }

                //Realign CPU hand.
                RealignCards(pnlCPU);

                //Reset the attack turn and clear the River.
                attackTurn = 0;
                ClearRiver();              
            }

            return validDefend; //Return whether the computer could or couldn't defend.
        }
        #endregion

        #region Form Buttons (Click)
        /// <summary>
        /// End's the round/bout and makes the CPU the attacker. If the player was defending on click, picks up the river
        /// cards and adds them to the player's hand.
        /// </summary>
        /// <param name="sender">Pass Button</param>
        /// <param name="e">Clicked</param>
        private void btnPass_Click(object sender, EventArgs e)
        {
            if (playerAttacking == false) //Pass button was pressed while player is defending.
            {
                //Log the Player Pick Up.
                gameActions.AppendLine(playerName + " doesn't Defend and has Picked Up to end the turn. End of turn " + turn);

                //Moves River Cards into player's hand.
                foreach (Control riverPanels in pnlRiver.Controls)
                {
                    if (riverPanels.Controls != null) //If the panel contains a Card/Cardbox.
                    {
                        foreach (CardBox riverPanelCard in riverPanels.Controls)
                        {
                            //Add the card to the player's hand.
                            pnlPlayer.Controls.Add(riverPanelCard);

                            //Log the picked up card for the Player.
                            gameActions.AppendLine(playerName + " has Picked Up the " + riverPanelCard.ToString() + " from the River");
                        }
                    }
                }

                //Draw a card from the Deck and put it into Player's Hand if there is any left in the deck.
                if (pnlDeck.Controls.Count > 0)
                {
                    //Create and assign a temp CardBox.
                    CardBox tempCard = new CardBox();
                    tempCard = pnlDeck.Controls[0] as CardBox;

                    WireCardBox(tempCard); //Wire the Card from the deck.
                    pnlPlayer.Controls.Add(tempCard); //Add it to the player's hand.

                    //Log the drawn card for player.
                    gameActions.AppendLine("Because " + playerName + " didn't Defend they also draw the " + tempCard.ToString());
                }

                //Align player's hand.
                RealignCards(pnlPlayer);

                //Reset the attack turn and clear the River.
                attackTurn = 0;
                ClearRiver();

                //Update Attack/Defend labels and Panels.
                UpdateLabels();
                UpdatePanels();

                //Draw cards for both Player and CPU.
                RoundEndDraw();
             
                //Computer starts attacking again.
                ComputerAttack();

                //Player Actions Label
                lblPlayerText.Text = "You decided to Pick Up the River Cards to end the Turn\nOpponent Attacks again";
            }
            else //Pass was pressed during player attack.
            {
                //Log Pass Action for Player.
                gameActions.AppendLine(playerName + " has Passed their Attack to end the turn. End of turn " + turn);

                //Clear River.
                ClearRiver();

                //Draw cards for both Player and CPU.
                RoundEndDraw();

                //CPU is now attacking.
                playerAttacking = false;
                attackTurn = 0;
                ComputerAttack();

                //Update Attack/Defend labels and Panels.
                UpdateLabels();
                UpdatePanels();

                //Player Actions Label
                lblPlayerText.Text = "You Passed and ended your Attack Turn\nOpponent Attacks";              
            }
        }
        #endregion

        #region Game Functions
        /// <summary>
        /// Starts a new game.
        /// </summary>
        public void NewGame()
        {
            //Reset the game (Controls + variables).
            ResetGame();

            //Open the New Game Form and hold focus.
            frmNewGame newGameForm = new frmNewGame();
            newGameForm.ShowDialog();

            //Re-Create the deck and Shuffle it.
            aDeck = new Deck(deckSize);
            aDeck.Shuffle(deckSize);
            gameActions.AppendLine("New game with a deck size of " + deckSize); //Log the Deck Size.

            //CardBox to hold the Trump Card.
            CardBox trumpCard = new CardBox();

            //Places all the cards in the deck onto the deck panel.
            for (int i = 0; i < deckSize; i++)
            {
                CardBox testCardBox = new CardBox(aDeck.Draw()); //Temporary CardBox drawn from the deck.

                //If it's the first card, it's the Trump Card.
                if (i == 1)
                {
                    trumpCard = testCardBox;
                    trumpSuit = trumpCard.Suit; //Set the Global trumpSuit variable to the Trump card's Suit.
                    gameActions.AppendLine("The Trump Card is " + trumpCard.ToString()); //Log the Trump Card.
                }
                else //It's not the first/trump card, add the cards to the deck panel.
                {
                    //If debug is on, set the cards to face up.
                    if (debug == true)
                    {
                        testCardBox.FaceUp = true;
                    }
                    else
                    {
                        testCardBox.FaceUp = false;
                    }

                    pnlDeck.Controls.Add(testCardBox);
                }

                //The last card in the deck is the Trump Card.
                if (i == deckSize - 1)
                {
                    pnlDeck.Controls.Add(trumpCard);
                    trumpCard.Left = 15; //Add the Trump Card to the right so the player can see it.
                    trumpCard.Top = 20; //Put it roughly in the middle.
                    trumpCard.CardOrientation = Orientation.Horizontal; //Change it so it sticks out sideways.
                    trumpCard.UpdateCardImage(); //Update the card image.
                }
            }

            //Display the Trump Card Label.
            lblTrump.Text = trumpCard.Suit.ToString() + "s is Trump";
            lblTrump.Visible = true;

            //Draw Cards for both Human Player and CPU.           
            RoundEndDraw();

            //Pick which Player attacks first.
            FirstAttack(pnlPlayer, pnlCPU);

            //Realign cards in Player and CPU Hand.
            RealignCards(pnlCPU);
            RealignCards(pnlPlayer);

            //Update the River Panel Visuals and the Attack/Defend Labels.
            UpdatePanels();
            UpdateLabels();

            //Update the Label showing how many Cards in the Deck are left and make it visible.
            updateCards();
            if (debug == false)
            {
                lblDeck.Visible = false;
            }
            else
            {
                lblDeck.Visible = true;
            }

            //Update Player Name
            lblPlayerName.Text = playerName;

            //Action Labels
            lblCPUText.Visible = true;
            lblPlayerText.Visible = true;

            if (playerAttacking == true)
            {
                lblPlayerText.Text = "You have the first Attack\nDrag a Card to Attack";
            }
            else
            {
                lblPlayerText.Text = "Computer has the first Attack\nDrag a Card to Defend";
            }

            //Read Stats if they exist and assign global variables.
            ReadStats();
            
        }

        /// <summary>
        /// Reads the player's stats.
        /// </summary>
        private void ReadStats()
        {
            string fileLocation = "../../../Stats/" + playerName + ".txt";
            string line = ""; //Holds the ReadLine.
            
            int[] statValues = new int[] { gamesPlayed, gamesWon, gamesLost };
            int counter = 0;
           // int lineCount = 0;

            if (File.Exists(fileLocation))
            {
                using (StreamReader sr = new StreamReader(fileLocation))
                {

                    for (counter = 0; counter < 3; counter++)
                    {
                        line = sr.ReadLine();

                        string statValue = ""; //Holds the Value of the current line.

                        //Check for numbers which = the stat value.
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (Char.IsDigit(line[i]))
                            {
                                statValue += line[i];
                            }
                        }

                        //Save the values.
                        statValues[counter] = int.Parse(statValue);
                    }
                    
                }

                //Assign the values to the global values.
                gamesPlayed = statValues[0];
                gamesWon = statValues[1];
                gamesLost = statValues[2];
            }
        }

        /// <summary>
        /// Resets the player's stats.
        /// </summary>
        public static void ResetStats()
        {
            //Reset Global variables.
            gamesPlayed = 0;
            gamesWon = 0;
            gamesLost = 0;

            //Write the Stats.
            string fileLocation = "../../../Stats/";
            string fileName = playerName + ".txt";
            StringBuilder stats = new StringBuilder();

            stats.AppendLine("Games Played : " + gamesPlayed);
            stats.AppendLine("Games Won    : " + gamesWon);
            stats.AppendLine("Games Lost   : " + gamesLost);

            using (StreamWriter sw = File.CreateText(fileLocation + fileName))
            {
                sw.WriteLine(stats.ToString());
            }
        }

        /// <summary>
        /// Clears the cards in the River panels.
        /// </summary>
        private void ClearRiver()
        {
            foreach (Panel riverPanels in pnlRiver.Controls)
            {
                riverPanels.Visible = false; //Make the river panels invisible.

                if (riverPanels.Controls != null) //If there is any Cardbox/Card in the river panels.
                {
                    riverPanels.Controls.Clear(); //Clear them.
                }
            }
        }

        /// <summary>
        /// When there are no cards left in the deck and a player empties their hand, that player wins. Generates a decision window
        /// asking if the player wants to play again or not. If yes, resets the game (player still has to click new game).
        /// </summary>
        private void GameOver()
        {           
            //Log the end of the game + Stats.
            if (pnlPlayer.Controls.Count < 1)
            {
                gameActions.AppendLine(playerName + " has Won the Game!");
                gamesWon++;
            }
            else if (pnlCPU.Controls.Count < 1)
            {
                gameActions.AppendLine(playerName + " has Lost the Game!");
                gamesLost++;
            }

            gamesPlayed++; //Either way, add a game played.

            //Write the logs.
            DateTime date = DateTime.Now; //Holds the current time.
            string fileLocation = "../../../Logs/"; //Holds the relative directory.
            string fileName = date.ToString("dd-MM-yyyy h;mmtt") + ".txt"; //Holds the file Name.

            using (StreamWriter sw = File.CreateText(fileLocation + fileName))
            {
                sw.WriteLine(gameActions.ToString());
            }

            //Write the Stats.
            fileLocation = "../../../Stats/";
            fileName = playerName + ".txt";
            StringBuilder stats = new StringBuilder();

            stats.AppendLine("Games Played : " + gamesPlayed);
            stats.AppendLine("Games Won    : " + gamesWon);
            stats.AppendLine("Games Lost   : " + gamesLost);

            using (StreamWriter sw = File.CreateText(fileLocation + fileName))
            {
                sw.WriteLine(stats.ToString());
            }

            //Create a Message Box.
            string title = "\t\t\tYOU WIN!";
            string message = "Would you like to play again?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            //If the CPU is out of Cards, Player lost.
            if (pnlCPU.Controls.Count < 1)
            {
                title = "\t\t\tYOU LOSE!";
            }

            //Show the Message Box.
            DialogResult result = MessageBox.Show(message, title, buttons);

            if (result == DialogResult.Yes) //Player wants to play again.
            {
                NewGame();
            }
            else //Player wants to quit the game.
            {
                this.Close();
            }

        }

        /// <summary>
        /// Updates the label that shows the number of cards left in the deck during Debug.
        /// Updates the deck panel when empty.
        /// </summary>
        private void updateCards()
        {
            lblDeck.Text = "Cards left: " + pnlDeck.Controls.Count;

            //If there are no cards left in the deck, display an empty image.
            if (pnlDeck.Controls.Count < 1)
            {
                pnlDeck.BackgroundImage = Properties.Resources.Empty;
            }

        }

        /// <summary>
        /// At the end of the round, ensures both players have the minimum cards in their hand; remaining deck cards permitting.
        /// </summary>
        private void RoundEndDraw()
        {
            const int MIN_CARDS = 6; //Minumum cards required after a round ends (if there are any left in the deck).
            int counter = 0; //Easy way to check to draw 6 times (if it was longer, probably more effecient to check hands/deck).

            do
            {
                CardBox tempCard; //Temporary CardBox to help deal out the Cards.

                //If the deck only has 1 card left, it's the trump card. Reset it's image.
                if (pnlDeck.Controls.Count == 1)
                {
                    tempCard = pnlDeck.Controls[0] as CardBox;       //Temp holds the Trump Card.
                    tempCard.CardOrientation = Orientation.Vertical; //Reset the Trump card's orientation.
                    tempCard.Top = 0;                                //Reset the Trump card's top property.
                    tempCard.Left = 0;                               //Reset the Trump card's left property.
                    tempCard.UpdateCardImage();                      //Update the Trump card's image.
                }

                //If the player has less than the minmum cards in their hand and there are more in the deck, draw a card from the deck.
                if (pnlPlayer.Controls.Count < MIN_CARDS && pnlDeck.Controls.Count > 0)
                {
                    //Player Draws a card.
                    tempCard = pnlDeck.Controls[0] as CardBox;    //Asign the card the first value in the deck.
                    tempCard.FaceUp = true;                       //Going to the player's hand, so make it face up.
                    WireCardBox(tempCard);                        //Wire the CardBox.               
                    pnlPlayer.Controls.Add(tempCard);             //Add it to the player's Hand.
                    gameActions.AppendLine(playerName + " drew the " + tempCard.ToString()); //Log the drawn card for Player.
                }

                //If the deck only has 1 card left, it's the trump card. Reset it's image.
                if (pnlDeck.Controls.Count == 1)
                {
                    tempCard = pnlDeck.Controls[0] as CardBox;       //Temp holds the Trump Card.
                    tempCard.CardOrientation = Orientation.Vertical; //Reset the Trump card's orientation.
                    tempCard.Top = 0;                                //Reset the Trump card's top property.
                    tempCard.Left = 0;                               //Reset the Trump card's left property.
                    tempCard.UpdateCardImage();                      //Update the Trump card's image.
                }

                //If the CPU has less than the minmum cards in their hand and there are more in the deck, draw a card from the deck.
                if (pnlCPU.Controls.Count < MIN_CARDS && pnlDeck.Controls.Count > 0)
                {
                    //CPU Draws a card.
                    tempCard = pnlDeck.Controls[0] as CardBox;    //Asign the card the first value in the deck.                                        
                    WireCardBox(tempCard);                        //Wire the CardBox.

                    //Log the drawn card for CPU.
                    tempCard.FaceUp = true;
                    gameActions.AppendLine("Opponent drew the " + tempCard.ToString());

                    //If debug is on set card face up.
                    if (debug == true)
                    {
                        tempCard.FaceUp = true;
                    }
                    else //Make card face down.
                    {
                        tempCard.FaceUp = false;
                    }

                    pnlCPU.Controls.Add(tempCard);                //Add it to the computers's Hand.                   
                }

                counter++;

            } while (counter < 6); //Draw 6 times.

            //Realign Player and CPU Hand.
            RealignCards(pnlPlayer);
            RealignCards(pnlCPU);

            //Update the cards left in deck label.
            updateCards();

            //Update the turn label.
            turn++;
            lblTurnNum.Text = turn.ToString();
        }

        /// <summary>
        /// Clears all the panels and resets all the global variables and controls.
        /// </summary>
        private void ResetGame()
        {
            //Clear all the Panels.
            ClearAll();

            //Clear last Card and Panel members.
            lastAttackCard = new CardBox();
            lastPanel = pnlRiverCard1;

            //Reset Player Attacking and Attack Turn.
            playerAttacking = true;
            attackTurn = 0;
            turn = 0;

            //Reset Labels.
            lblDeck.Visible = false;
            lblTrump.Visible = false;
            lblCPUText.Visible = false;
            lblCPUText.Text = "";
            lblPlayerText.Text = "Press New Game to start a new game";
            UpdateLabels();
            UpdatePanels();

            //Reset Logs.
            gameActions.Clear();
        }

        /// <summary>
        /// Determines who attacks first on new game.
        /// </summary>
        /// <param name="playerPanel">The player's Hand Panel</param>
        /// <param name="compPanel">The CPU's Hand Panel</param>
        private void FirstAttack(Panel playerPanel, Panel compPanel)
        {

            CardBox playerCard = new CardBox(); //Holds a card from the player's hand, used to determine lowest Rank.
            CardBox compCard = new CardBox(); //Holds a card from the CPU's hand, used to determine lowest Rank.

            bool playerTrump = false; //Whether the player has a trump card or not.
            bool compTrump = false; //Whether the CPU has a trump card or not.

            //Check the Player's Hand.
            foreach (CardBox card in playerPanel.Controls)
            {
                if (card.Suit == trumpSuit) //The card is a Trump suit.
                {
                    //If there has been another card picked for the Player(not the first, and not the first Trump).
                    if (playerCard != null)
                    {
                        //Checks to see if it's a lower rank (lower the better).
                        if (card.Rank <= playerCard.Rank)
                        {
                            playerCard = card;
                        }
                    }
                    else //It is the first card checked, automatically pick it to set a baseline.
                    {
                        playerCard = card;
                    }

                    playerTrump = true; //Either way, there was is a Trump Suit in Player Hand
                }
                else //Player Card isn't Trump suit.
                {
                    if (playerTrump == false)
                    {
                        //Make sure it's not the first card checked.
                        if (playerCard != null)
                        {
                            //Checks to see if it's a lower rank (lower the better).
                            if (card.Rank <= playerCard.Rank)
                            {
                                playerCard = card;
                            }
                        }
                        else //It is the first card checked, automatically pick it to set a baseline.
                        {
                            playerCard = card;
                        }
                    }
                }
            }

            //Check the CPU's Hand.
            foreach (CardBox card in compPanel.Controls)
            {
                if (card.Suit == trumpSuit)
                {
                    //If there has been another card picked for the CPU (not the first, and not the first Trump).
                    if (compCard != null)
                    {
                        //Checks to see if it's a lower rank (lower the better).
                        if (card.Rank <= compCard.Rank)
                        {
                            compCard = card;
                        }
                    }
                    else //It is the first card checked, automatically pick it to set a baseline.
                    {
                        compCard = card;
                    }

                    compTrump = true; //Either way, there was is a Trump Suit in Player Hand
                }
                else //CPU Card isn't Trump suit.
                {
                    //Make sure a trump card isn't replaced by a non-trump card.
                    if (compTrump == false)
                    {
                        //Make sure this isn't the first card checked.
                        if (compCard != null)
                        {
                            //Checks to see if it's a lower rank (lower the better).
                            if (card.Rank <= compCard.Rank)
                            {
                                compCard = card;
                            }
                        }
                        else //It is the first card checked, automatically pick it to set a baseline.
                        {
                            compCard = card;
                        }
                    }
                }
            }

            if (playerTrump == true && compTrump == false) //Player has trump, CPU does not.
            {
                playerAttacking = true; //Player Attacks first.
            }
            else if (playerTrump == false && compTrump == true) //CPU has trump, Player does not.
            {
                playerAttacking = false; //CPU Attacks first.
                ComputerAttack();
            }
            else //Neither have a trump card.
            {
                if (playerCard.Rank < compCard.Rank) //Player has lowest Rank.
                {
                    playerAttacking = true; //Player Attacks first.
                }
                else if (playerCard.Rank > compCard.Rank) //CPU has lowest Rank.
                {
                    playerAttacking = false; //CPU Attacks first.
                    ComputerAttack();
                }
                else //Both have the same Rank and no trump card.
                {
                    var randomGenerator = new Random(); //Temporary Random Generator.
                    int randomNumber;                   //Holds the random number.

                    randomNumber = randomGenerator.Next(0, 100); //Get a random number 0-100.

                    if (randomNumber >= 51) //51-100 Player attacks first.
                    {
                        playerAttacking = true;
                    }
                    else //0-50 CPU attacks first.
                    {
                        playerAttacking = false;
                        ComputerAttack();
                    }
                }
            }

            //Update Attack/Defend labels and Panels.
            UpdateLabels();
            UpdatePanels();
        }

        /// <summary>
        /// Clears all the Panels (Player Hand, CPU Hand, All Rivers, Deck)
        /// </summary>
        private void ClearAll()
        {
            ClearRiver();
            pnlCPU.Controls.Clear();
            pnlPlayer.Controls.Clear();
            pnlDeck.Controls.Clear();
        }

        /// <summary>
        /// Repositions the cards in a panel so that they are evenly distributed in the area available.
        /// </summary>
        /// <param name="panelHand">The panel to be realigned</param>
        private void RealignCards(Panel panelHand)
        {
            // Determine the number of cards/controls in the panel.
            int myCount = panelHand.Controls.Count;

            // If there are any cards in the panel
            if (myCount > 0)
            {
                // Determine how wide one card/control is.
                int cardWidth = panelHand.Controls[0].Width;

                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int startPoint = (panelHand.Width - cardWidth) / 2;

                // An offset for the remaining cards
                int offset = 0;

                // If there are more than one cards/controls in the panel
                if (myCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    offset = ((panelHand.Width - cardWidth) - (2 * POP)) / (myCount - 1);

                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (offset > cardWidth)
                    {
                        offset = cardWidth;
                    }

                    // Determine width of all the cards/controls 
                    int allCardsWidth = (myCount - 1) * offset + cardWidth;

                    // Set the start point to where the left-hand edge of the "first" card should be.
                    startPoint = (panelHand.Width - allCardsWidth) / 2;
                }

                // Aligning the cards: Note that I align them in reserve order from how they
                // are stored in the controls collection. This is so that cards on the left 
                // appear underneath cards to the right. This allows the user to see the rank
                // and suit more easily.                

                // Align the "first" card (which is the last control in the collection)
                panelHand.Controls[myCount - 1].Top = POP;
                panelHand.Controls[myCount - 1].Left = startPoint;

                //If the panel is a river panel or player hand, set the first card as face up.
                if (panelHand != pnlCPU && panelHand != pnlDeck && debug == false)
                {
                    CardBox tempCard;
                    tempCard = panelHand.Controls[myCount - 1] as CardBox;
                    tempCard.FaceUp = true;
                }

                // for each of the remaining controls, in reverse order.
                for (int index = myCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    panelHand.Controls[index].Top = POP;
                    panelHand.Controls[index].Left = panelHand.Controls[index + 1].Left + offset;

                    //If the panel is a river panel or player hand, set the card as face up.
                    if (panelHand != pnlCPU && panelHand != pnlDeck && debug == false)
                    {
                        CardBox tempCard;
                        tempCard = panelHand.Controls[index + 1] as CardBox;
                        tempCard.FaceUp = true;
                    }
                }
            }
        }

        /// <summary>
        /// Adds the cards back in opposite order, so the defending card overlaps the attacking for the panel.
        /// </summary>
        /// <param name="riverPanel">Current River Panel</param>
        private void RealignRiver(Panel riverPanel)
        {
            CardBox firstCard = riverPanel.Controls[0] as CardBox;  //Holds the first card in the river panel.
            CardBox secondCard = riverPanel.Controls[1] as CardBox; //Holds the second card in the river panel.

            //Reset the CardBox horizontal position.
            firstCard.Left = 0;
            secondCard.Left = 0;

            //Reset the CardBox Vertical position, and lower the second card so it overlaps.
            firstCard.Top = 0;
            secondCard.Top = 25;

            //Remove all the cards from the river.
            riverPanel.Controls.Clear();

            //Add the cards back in opposite order, so the defending card overlaps the attacking.
            riverPanel.Controls.Add(secondCard);
            riverPanel.Controls.Add(firstCard);
        }

        /// <summary>
        /// Updates the visibility of River panels. Turns them on if they are of the attack turn.
        /// </summary>
        private void UpdatePanels()
        {
            foreach (Panel riverPanel in pnlRiver.Controls)
            {
                if (riverPanel == pnlRiver.Controls[attackTurn])
                {
                    riverPanel.Visible = true;

                    //Attack/Defend background images.
                    if (playerAttacking == false)
                    {
                        riverPanel.BackgroundImage = Properties.Resources.Defend;
                    }
                    else
                    {
                        riverPanel.BackgroundImage = Properties.Resources.Attack;
                    }
                }
            }
        }

        /// <summary>
        /// Changes the Attack and Defend Labels based on the attack turn and whether the player is Attacking or Defending.
        /// Also changes the Pass/Pick Up button text.
        /// </summary>
        private void UpdateLabels()
        {
            //Arrays to hold the attack state labels.
            Label[] attackLabelArray = new Label[] { lblAttack1, lblAttack2, lblAttack3, lblAttack4, lblAttack5, lblAttack6 };
            Label[] defendLabelArray = new Label[] { lblDefend1, lblDefend2, lblDefend3, lblDefend4, lblDefend5, lblDefend6 };

            if (playerAttacking == true) //When the player is attacking.
            {
                for (int counter = 0; counter < 6; counter++)
                {
                    //Matches the label to the river panel that is open (determined by attack turn), and turns off the previous (or all).
                    if (counter == attackTurn)
                    {
                        attackLabelArray[counter].Visible = true;
                    }
                    else
                    {
                        attackLabelArray[counter].Visible = false;
                    }
                }

                //Since player is attacking, makes sure all the defend labels are off.
                for (int counter = 0; counter < 6; counter++)
                {
                    defendLabelArray[counter].Visible = false;
                }

                //Update the Pass/Pick Up button text to Pass
                btnPass.Text = "Pass";
            }
            else //Player is Defending.
            {
                for (int counter = 0; counter < 6; counter++)
                {
                    //Matches the label to the river panel that is open (determined by defend turn), and turns off the previous (or all).
                    if (counter == attackTurn)
                    {
                        defendLabelArray[counter].Visible = true;
                    }
                    else
                    {
                        defendLabelArray[counter].Visible = false;
                    }
                }

                //Since player is defending, makes sure all the attacking labels are off.
                for (int counter = 0; counter < 6; counter++)
                {
                    attackLabelArray[counter].Visible = false;
                }

                //Update the Pass/Pick Up button text to Pick Up
                btnPass.Text = "Pick Up";
            }
        }
        #endregion

        #region CardBox Functions
        /// <summary>
        /// Initiate a card move on the start of a drag.
        /// </summary>
        private void CardBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Set dragCard
            dragCard = sender as CardBox;

            // If the conversion worked
            if (dragCard != null)
            {
                // Set the data to be dragged and the allowed effect dragging will have.
                DoDragDrop(dragCard, DragDropEffects.Move);
            }
        }

        /// <summary>
        /// When a drag is enters a card, enter the parent panel instead.
        /// </summary>
        private void CardBox_DragEnter(object sender, DragEventArgs e)
        {
            // Convert sender to a CardBox
            CardBox aCardBox = sender as CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                // Do the operation on the parent panel instead
                Panel_DragEnter(aCardBox.Parent, e);
            }
        }

        /// <summary>
        /// When a drag is dropped on a card, drop on the parent panel instead.
        /// </summary>
        private void CardBox_DragDrop(object sender, DragEventArgs e)
        {
            // Convert sender to a CardBox
            CardBox aCardBox = sender as CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                // Do the operation on the parent panel instead
                Panel_DragDrop(aCardBox.Parent, e);
            }
        }

        /// <summary>
        /// CardBox controls grow in size when the mouse is over it if the CardBox is in the player's hand.
        /// </summary>
        /// <param name="sender">CardBox moused over</param>
        /// <param name="e">MouseEnter</param>
        private void CardBox_MouseEnter(object sender, EventArgs e)
        {
            // Convert sender to a CardBox and a Control.
            Control aControl = sender as Control;
            CardBox aCardBox = sender as CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                //If the panel is the player's hand.
                if (aControl.Parent == pnlPlayer)
                {
                    // Enlarge the card for visual effect
                    aCardBox.Size = new Size(regularSize.Width + POP, regularSize.Height + POP);
                    // move the card to the top edge of the panel.
                    aCardBox.Top = 0;
                }
            }
        }

        /// <summary>
        /// CardBox control shrinks to regular size when the mouse leaves.
        /// </summary>
        private void CardBox_MouseLeave(object sender, EventArgs e)
        {
            // Convert sender to a CardBox and a Control.
            Control aControl = sender as Control;
            CardBox aCardBox = sender as CardBox;

            // If the conversion worked
            if (aCardBox != null)
            {
                //If the panel is the player's hand.
                if (aControl.Parent == pnlPlayer)
                {
                    // resize the card back to regular size
                    aCardBox.Size = regularSize;
                    // move the card down to accommodate for the smaller size.
                    aCardBox.Top = POP;
                }
            }
        }

        /// <summary>
        /// Wires all the CardBox Functions/effects at once.
        /// </summary>
        /// <param name="theCardBox">CardBox to be wired</param>
        private void WireCardBox(CardBox theCardBox)
        {
            // wire CardBox_MouseEnter for the "POP" visual effect
            theCardBox.MouseEnter += CardBox_MouseEnter;

            // wire CardBox_MouseLeave for the regular visual effect
            theCardBox.MouseLeave += CardBox_MouseLeave;

            // wire CardBox_MouseDown, CardBox_DragEnter, and CardBox_DragDrop
            theCardBox.MouseDown += CardBox_MouseDown;
            theCardBox.DragEnter += CardBox_DragEnter;
            theCardBox.DragDrop += CardBox_DragDrop;
        }
        #endregion

        #region Basic Form Functions
        /// <summary>
        /// Initialize's the form, do not touch.
        /// </summary>
        public frmMainForm()
        {
            InitializeComponent();
            NewGame();
            ReadStats();
        }

        /// <summary>
        /// When the Durak Client first loads do... 
        /// </summary>
        /// <param name="sender">Durak Client Main Form</param>
        /// <param name="e">Load</param>
        private void frmMainForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Main Menu Items
        /// <summary>
        /// Loads the About form.
        /// </summary>
        /// <param name="sender">The about button in the main menu</param>
        /// <param name="e">Menu Item About Clicked</param>
        private void miAbout_Click(object sender, EventArgs e)
        {
            frmAboutForm aboutForm = new frmAboutForm(); //Holds the about form.

            aboutForm.Show(); //Opens the about form.
        }
        
        /// <summary>
        /// Changes a few of the game's functions to better test/debug.
        /// </summary>
        /// <param name="sender">Debug button in the main menu</param>
        /// <param name="e">Menu Item Debug Clicked</param>
        private void miDebug_Click(object sender, EventArgs e)
        {
            //If the debug is off, turn it on.
            if (debug == false)
            {
                debug = true;
                miDebug.Text = "Turn Debug &Off (Resets the game)";
            }
            else //It is on, turn it off.
            {
                debug = false;
                miDebug.Text = "Turn Debug &On (Resets the game)";
            }

            //Either way, reset the game
            NewGame();
        }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        /// <param name="sender">New game menu item button</param>
        /// <param name="e">Menu Item New Game Click</param>
        private void miNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        /// <summary>
        /// Shows the players stats in a new form.
        /// </summary>
        /// <param name="sender">Stats menu item button</param>
        /// <param name="e">Menu Item Stats Click</param>
        private void miStats_Click(object sender, EventArgs e)
        {
            frmStats statsForm = new frmStats();

            statsForm.Show();
        }

        /// <summary>
        /// Closes the game.
        /// </summary>
        /// <param name="sender">Exit menu item button</param>
        /// <param name="e">Menu Item Exit Click</param>
        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}


