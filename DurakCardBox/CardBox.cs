/*
 * Program Name: CardBox.cs
 * Program Desc: A PictureBox control of a regular playing Card
 * 
 * @author       Connor Simmonds-Parke
 * @author       Emeka Okoisama
 * @author       David Osagiede
 * @since        April 11, 2021
 * @version      1.0
 * 
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using CardLibrary;

namespace DurakCardBox
{
    public partial class CardBox : UserControl
    {
        /// <summary>
        /// A playing Card object
        /// </summary>
        private Card myCard;
        /// <summary>
        /// Get and Set the CardBox's Card and image
        /// </summary>
        public Card CardsBox
        {
            set
            {
                myCard = value;
                UpdateCardImage();
            }
            get
            {
                return myCard;
            }
        }

        /// <summary>
        /// Get and Set the CardBox's Suit
        /// </summary>
        public Suit Suit
        {
            set
            {
                CardsBox.suit = value;
                UpdateCardImage();
            }
            get
            {
                return CardsBox.suit;
            }
        }

        /// <summary>
        /// Get and Set the CardBox's Rank
        /// </summary>
        public Rank Rank
        {
            set
            {
                CardsBox.rank = value;
                UpdateCardImage();
            }
            get
            {
                return CardsBox.rank;
            }
        }

        /// <summary>
        /// Updates the card to show the back or face up
        /// </summary>
        public bool FaceUp
        {
            set
            {
                if (myCard.faceUp != value)
                {
                    myCard.faceUp = value;

                    UpdateCardImage();

                    if (CardFlipped != null)
                    {
                        CardFlipped(this, new EventArgs());
                    }
                }
            }
            get
            {
                return CardsBox.faceUp;
            }
        }

        /// <summary>
        /// Orientation of the CardBox
        /// </summary>
        private Orientation myOrientation;
        /// <summary>
        /// Get and Set the CardBox orientation
        /// </summary>
        public Orientation CardOrientation
        {
            set
            {
                if (myOrientation != value)
                {
                    myOrientation = value;
                    this.Size = new Size(Size.Height, Size.Width);
                }
            }
            get
            {
                return myOrientation;
            }
        }

        /// <summary>
        /// Updates the CardBox image (rotates Horizontal or Vertical)
        /// </summary>
        public void UpdateCardImage()
        {
            pbMyPictureBox.Image = myCard.GetCardImage();

            if (myOrientation == Orientation.Horizontal)
            {
                pbMyPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
        }

        /// <summary>
        /// Defaul Constructor. Construct a CardBox with a new Card
        /// </summary>
        public CardBox()
        {
            InitializeComponent();
            myOrientation = Orientation.Vertical;
            myCard = new Card();
        }

        /// <summary>
        /// Construct a CardBox with a specific Card
        /// </summary>
        /// <param name="aCard">Playing Card</param>
        public CardBox(Card aCard)
        {
            InitializeComponent();
            myOrientation = Orientation.Vertical;
            myCard = aCard;
            this.UpdateCardImage();
        }

        /// <summary>
        /// Construct a CardBox with specific Rank + Suit
        /// </summary>
        /// <param name="rank">Card Rank</param>
        /// <param name="suit">Card Suit</param>
        public CardBox(Rank rank, Suit suit)
        {
            InitializeComponent();
            myOrientation = Orientation.Vertical;
            myCard = new Card(suit, rank);
            this.UpdateCardImage();
        }

        /// <summary>
        /// Returns the card name (Suit + Rank)
        /// </summary>
        /// <returns>The card name as a String</returns>
        public override string ToString()
        {
            return myCard.ToString();
        }

        /// <summary>
        /// When the CardBox is first loaded, update the card image
        /// </summary>
        /// <param name="sender">CardBox</param>
        /// <param name="e">Load</param>
        private void CardBox_Load(object sender, EventArgs e)
        {
            UpdateCardImage();
        }

        /// <summary>
        /// Picture Box Custome Click Event
        /// </summary>
        new public event EventHandler Click;
        private void pbMyPictureBox_Click(object sender, EventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
                UpdateCardImage();
            }
        }

        /// <summary>
        /// Custome CardFlipped Event
        /// </summary>
        public event EventHandler CardFlipped;

        /// <summary>
        /// MouseEnter Event
        /// </summary>
        new public event EventHandler MouseEnter;      
        private void pbMyPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (MouseEnter != null)
            {
                MouseEnter(this, e);
            }
        }

        /// <summary>
        /// MouseLeave Event
        /// </summary>
        new public event EventHandler MouseLeave;
        private void pbMyPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (MouseLeave != null)
            {
                MouseLeave(this, e);
            }
        }

        /// <summary>
        /// DragDrop Event
        /// </summary>
        new public event DragEventHandler DragDrop;
        private void pbMyPictureBox_DragDrop(object sender, DragEventArgs e)
        {
            if (DragDrop != null)
            {
                DragDrop(this, e);
            }
        }

        /// <summary>
        /// MouseDown Event
        /// </summary>
        new public event MouseEventHandler MouseDown;
        private void pbMyPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseDown != null)
            {
                MouseDown(this, e);
            }
        }

        /// <summary>
        /// DragEnter Event
        /// </summary>
        new public event DragEventHandler DragEnter;
        private void pbMyPictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (DragEnter != null)
            {
                DragEnter(this, e);
            }
        }
    }
}
