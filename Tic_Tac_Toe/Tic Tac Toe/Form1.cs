using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Tic_Tac_Toe_Game : Form
    {
        public Tic_Tac_Toe_Game()
        {
            InitializeComponent();
        }

        private void Tic_Tac_Toe_Game_Load(object sender, EventArgs e)
        {
            foreach (Control c in panel2.Controls)
            {
                if (c is Button)
                {
                    c.Click += new System.EventHandler(btn_click);
                }
            }
        }

        int XorO = 0;
        int score1 = 0;
        int score2 = 0;

        public void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.Text.Equals(""))
            {
                if (XorO % 2 == 0)
                {
                    btn.Text = "X";
                    btn.ForeColor = Color.Blue;
                    lbl_player1.Font = new Font(lbl_player1.Font, FontStyle.Regular);
                    lbl_player2.Font = new Font(lbl_player2.Font, FontStyle.Bold);
                    label1.Text = "O turn now";
                    getTheWinner();
                }
                else
                {
                    btn.Text = "O";
                    btn.ForeColor = Color.Red;
                    lbl_player1.Font = new Font(lbl_player1.Font, FontStyle.Bold);
                    lbl_player2.Font = new Font(lbl_player2.Font, FontStyle.Regular);
                    label1.Text = "X turn now";
                    getTheWinner();
                }
                XorO++;
            }
        }

        bool win = false;

        public void getTheWinner()
        {
            if (!button1.Text.Equals("") && button1.Text.Equals(button2.Text) && button1.Text.Equals(button3.Text))
            {
                winEffect(button1, button2, button3);
                win = true;
            }
            if (!button6.Text.Equals("") && button6.Text.Equals(button5.Text) && button6.Text.Equals(button4.Text))
            {
                winEffect(button6, button5, button4);
                win = true;
            }
            if (!button9.Text.Equals("") && button9.Text.Equals(button8.Text) && button9.Text.Equals(button7.Text))
            {
                winEffect(button9, button8, button7);
                win = true;
            }
            if (!button1.Text.Equals("") && button1.Text.Equals(button4.Text) && button1.Text.Equals(button7.Text))
            {
                winEffect(button1, button4, button7);
                win = true;
            }
            if (!button2.Text.Equals("") && button2.Text.Equals(button5.Text) && button2.Text.Equals(button8.Text))
            {
                winEffect(button2, button5, button8);
                win = true;
            }
            if (!button3.Text.Equals("") && button3.Text.Equals(button6.Text) && button3.Text.Equals(button9.Text))
            {
                winEffect(button3, button6, button9);
                win = true;
            }
            if (!button1.Text.Equals("") && button1.Text.Equals(button5.Text) && button1.Text.Equals(button9.Text))
            {
                winEffect(button1, button5, button9);
                win = true;
            }
            if (!button3.Text.Equals("") && button3.Text.Equals(button5.Text) && button3.Text.Equals(button7.Text))
            {
                winEffect(button3, button5, button7);
                win = true;
            }
            if (AllBtnLength() == 9 && win == false)
            {
                label1.Text = "No Winner";
            }
        }

        public int AllBtnLength()
        {
            int allTextButtonsLength = 0;

            foreach (Control c in panel2.Controls)
            {
                if (c is Button)
                {
                    allTextButtonsLength += c.Text.Length;
                }
            }
            return allTextButtonsLength;
        }

        public void winEffect(Button b1, Button b2, Button b3)
        {
            b1.BackColor = Color.Green;
            b2.BackColor = Color.Green;
            b3.BackColor = Color.Green;

            b1.ForeColor = Color.White;
            b2.ForeColor = Color.White;
            b3.ForeColor = Color.White;

            foreach (Control c in panel2.Controls)
            {
                if (c is Button)
                {
                    c.Enabled = false;
                }
            }

            label1.Text = b1.Text + " Win";

            if (b1.Text == "X")
            {
                lbl_score1.Text = (++score1).ToString();
            }
            else if (b1.Text == "O")
            {
                lbl_score2.Text = (++score2).ToString();
            }
        }

        private void ButtonPartie_Click(object sender, EventArgs e)
        {
            XorO = 0;
            win = false;
            label1.Text = "Play";

            foreach (Control c in panel2.Controls)
            {
                if (c is Button)
                {
                    c.Enabled = true;
                    c.Text = "";
                    c.BackColor = Color.White;
                }
            }
        }
    }
}
