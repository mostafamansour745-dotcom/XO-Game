using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XO_Project.Properties;


namespace XO_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        stGameStatue GameStatue;
        enPlayer PlayerTurn = enPlayer.Player1;
       enum enPlayer { Player1 , Player2}

       enum enWinner {  Player1 , Player2 , Draw , GameInProgress}

       struct stGameStatue
       {
            public enWinner Winner;
            public bool GameOver;
            public int PlayCount;

       }
        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString()) 
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatue.Winner = enWinner.Player1;
                    GameStatue.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {

                    GameStatue.Winner = enWinner.Player2;
                    GameStatue.GameOver = true;
                    EndGame();
                    return true;
                }
            }
        
          GameStatue.GameOver = false;
          return false;
        }
        void EndGame()
        {

            lblTurn.Text = "Game Over";
            switch (GameStatue.Winner)
            {

                case enWinner.Player1:

                    lblWinner.Text = "Player1";
                    break;

                case enWinner.Player2:

                    lblWinner.Text = "Player2";
                    break;

                default:

                    lblWinner.Text = "Draw";
                    break;

            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        void CheckWinner()
        {
            if (CheckValues(button1, button2, button3))
                return;

            //check Row2
            if (CheckValues(button4, button5, button6))
                return;

            //check Row3
            if (CheckValues(button7, button8, button9))
                return;

            //checked cols
            //check col1
            if (CheckValues(button1, button4, button7))
                return;

            //check col2
            if (CheckValues(button2, button5, button8))
                return;

            //check col3
            if (CheckValues(button3, button6, button9))
                return;

            //check Diagonal

            //check Diagonal1
            if (CheckValues(button1, button5, button9))
                return;

            //check Diagonal2
            if (CheckValues(button3, button5, button7))
                return;


        }
        public void ChangeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.NewX;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatue.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Resources.NewY;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatue.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }
            }

            else

            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatue.PlayCount == 9)
            {
                GameStatue.GameOver = true;
                GameStatue.Winner = enWinner.Draw;
                EndGame();
            }

        }

        private void button_Click(object sender, EventArgs e)
        {
            ChangeImage( (Button) sender);
        }
        
        private void RestButton(Button btn)
        {
            btn.Image = Resources.QMark;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }
        private void RestartGame()
        {

            RestButton(button1);
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            GameStatue.PlayCount = 0;
            GameStatue.GameOver = false;
            GameStatue.Winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";



        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 1; i <= 6; i++)
            {
                int alpha = 40 / i;
                int width = 5 + (i * 4);

                using (Pen glowPen = new Pen(Color.FromArgb(alpha, 255, 0, 0), width))
                {
                    glowPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    glowPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                    e.Graphics.DrawLine(glowPen, 400, 300, 1050, 300);
                    e.Graphics.DrawLine(glowPen, 400, 460, 1050, 460);
                    e.Graphics.DrawLine(glowPen, 610, 140, 610, 620);
                    e.Graphics.DrawLine(glowPen, 840, 140, 840, 620);
                }
            }

            using (Pen corePen = new Pen(Color.FromArgb(255, 255, 80, 80), 4))
            {
                corePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                corePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                e.Graphics.DrawLine(corePen, 400, 300, 1050, 300);
                e.Graphics.DrawLine(corePen, 400, 460, 1050, 460);
                e.Graphics.DrawLine(corePen, 610, 140, 610, 620);
                e.Graphics.DrawLine(corePen, 840, 140, 840, 620);
            }
        }



        private void btnRestartGame_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
      
        private void btnRestart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Pen neonPen = new Pen(Color.FromArgb(50, 255, 50, 50), 4))
            {
                g.DrawRectangle(neonPen, 2, 2, btnRestart.Width - 5, btnRestart.Height - 5);
            }

            using (Pen corePen = new Pen(Color.FromArgb(255, 200, 50, 50), 2))
            {
                g.DrawRectangle(corePen, 2, 2, btnRestart.Width - 5, btnRestart.Height - 5);
            }
        }

       
    }
}
