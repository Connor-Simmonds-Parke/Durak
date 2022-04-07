/*
 * Program Name: About.cs
 * Program Desc: A form with some information about the program.
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
    public partial class frmAboutForm : Form
    {
        public frmAboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Close the About Form.
        /// </summary>
        /// <param name="sender">Close Button</param>
        /// <param name="e">Click</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
