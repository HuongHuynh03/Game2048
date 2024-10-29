using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Media;
namespace game2048
{
    public partial class Game2048 : Form
    {
       
        SoundPlayer sound = new SoundPlayer(Application.StartupPath+"/andiem.wav");
        SoundPlayer sound2 = new SoundPlayer(Application.StartupPath+"/blip.wav");
                Random Rd = new Random();
        bool replay = true;
        static ArrayList array1 = new ArrayList();//DİZİ1
        public Game2048()
        {           
            InitializeComponent();            
        }
      
        //Tạo màu cho số
        public void paint()
        {
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if(Game[i,j].Text==""){
                        Game[i, j].BackColor = System.Drawing.Color.DarkMagenta;
                    }
                    if (Game[i, j].Text == "2")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.LightGray;
                        Game[i, j].ForeColor = System.Drawing.Color.White;

                    }
                    if (Game[i, j].Text == "4")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Gray;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "8")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Orange;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "16")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.OrangeRed;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "32")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.DarkOrange;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "64")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.LightPink;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "128")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Red;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "256")
                    {
                        Game[i, j].BackColor = Color.DarkRed;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "512")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.LightBlue;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "1024")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Blue;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "2048")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Green;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                }
            }
            
        }
        
        //Tạo số ngẫu nhiên
        public void randomNumber() {
            array1.Clear();

            Label[,] Game = {
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++)
                {
                    if(Game[i,j].Text==""){
                        array1.Add(i*4+j+1);
                    }
                }
            }
            
            if(array1.Count>0){
               
                int rdNumber = int.Parse(array1[Rd.Next(0,array1.Count-1)].ToString());
                int i0 = (rdNumber - 1) / 4;
                int j0 = (rdNumber - 1) - i0 *4;
                int array2 = Rd.Next(1,10);
                if (array2 == 1 || array2 == 2 || array2 == 3 || array2 == 4 || array2 == 5||array2==6 )
                {
                    Game[i0, j0].Text = "2";
                }
                else { 
                    Game[i0,j0].Text="4";
                }

            }
            paint();
        } 
        //Di chuyển lên trên
        public void moveUp() {
            bool checkUp = true;
            bool checkWin = false;
            bool newNumber = false;
            Label[,] Game = {
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                int sum = 0;
                for (int j = 0; j < 4;j++ )
                {
                    for (int k = j+1; k < 4;k++ )
                    {
                        if(Game[k,i].Text!=""){
                            if(Game[k,i].Text==Game[j,i].Text){
                                checkWin = true;
                            }
                            break;
                        }
                    }
                    if (Game[j, i].Text == "")
                    {
                        sum++;
                    }
                    else {
                        for (int m = j; m >= 0;m-- )
                        {
                            if(Game[m,i].Text==""){
                                newNumber = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool extraNumber = true;
                            
                            for (int k = j + 1; k < 4; k++)
                            {
                                if (Game[k, i].Text != "")
                                {
                                    if (Game[j, i].Text == Game[k, i].Text)
                                    {
                                        checkUp = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[ j,i].Text) * 2).ToString();//score ekle
                                      
                                        newNumber = true;
                                        extraNumber = false;
                                        Game[j, i].Text = (int.Parse(Game[j, i].Text) * 2).ToString();
                                        if(sum!=0){
                                            Game[j - sum, i].Text = Game[j, i].Text;
                                            Game[j, i].Text = "";
                                            
                                        }
                                        Game[k, i].Text = "";
                                       
                                        break;
                                        
                                    }
                                    break;
                                }
                            }
                            if(extraNumber==true && sum!=0){
                                checkUp = false;
                                Game[j - sum, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        else {
                            if(sum!=0){
                                checkUp = false;
                                Game[j - sum, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        
                       
                    }
                }
            }
            if(checkUp==false && checkWin==true){
                sound.Play();
            }
            if (checkUp == false && checkWin == false)
            {
                sound2.Play();
            }
            if(newNumber==true){
                randomNumber();
            }
            
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            randomNumber();
            randomNumber();
            randomNumber();
        }
        //Di chuyển xuống
        public void moveDown()
        {
            bool checkDown = true;
            bool checkWin = false;
            bool newNumber = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int sum = 0;
                for (int j = 3; j >=0; j--)
                {
                    for (int k = j - 1; k >= 0;k-- )
                    {
                        if(Game[k,i].Text!=""){
                            if(Game[k,i].Text==Game[j,i].Text){
                                checkWin = true;
                            }
                            break;
                        }
                    }
                    if (Game[j, i].Text == "")
                    {
                        sum++;
                    }
                    else
                    {
                        for (int m = j+1; m <= 3; m++)
                        {
                            if (Game[m, i].Text == "")
                            {
                                newNumber = true;
                                break;
                            }
                        }
                        if (j-1>=0)
                        {
                            bool extraNumber = true;
                            
                            for (int k = j -1 ; k >= 0; k--)
                            {
                                if (Game[k, i].Text != "")
                                {
                                    if (Game[j, i].Text == Game[k, i].Text)
                                    {
                                        checkDown = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[ j,i].Text) * 2).ToString();
                                       
                                        newNumber = true;
                                        extraNumber = false;
                                        Game[j, i].Text = (int.Parse(Game[j, i].Text) * 2).ToString();
                                        if (sum != 0)
                                        {
                                            Game[j + sum, i].Text = Game[j, i].Text;
                                            Game[j, i].Text = "";
                                            
                                        }
                                        Game[k, i].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (extraNumber == true && sum != 0)
                            {
                                checkDown = false;
                                Game[j + sum, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        else
                        {
                            if (sum != 0)
                            {
                                checkDown = false;
                                Game[j + sum, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }


                    }
                }
            }
            if (checkDown == false && checkWin == true)
            {
                sound.Play();
            }
            if (checkDown == false && checkWin == false)
            {
                sound2.Play();
            }
            if (newNumber == true)
            {
                randomNumber();
            }
        }
        //
        public void moveLeft()
        {
            bool checkLeft=true;
            bool checkWin = false;
            bool newNumber = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int sum = 0;
                for (int j =0; j <4; j++)
                {

                    for (int k = j + 1; k < 4;k++ )
                    {
                        if(Game[i,k].Text!=""){
                            if(Game[i,j].Text==Game[i,k].Text){
                                checkWin = true;
                            }
                            break;
                        }
                    }
                    if (Game[i,j].Text == "")
                    {
                        sum++;
                    }
                    else
                    {
                        for (int m = j-1; m >= 0; m--)
                        {
                            if (Game[i, m].Text == "")
                            {
                                newNumber = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool extraNumber = true;
                            
                            for (int k = j + 1; k <4; k++)
                            {
                                if (Game[i,k].Text != "")
                                {
                                    
                                    if (Game[i,j].Text == Game[i,k].Text)
                                    {
                                        checkLeft = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[i, j].Text) * 2).ToString();
                                       
                                        newNumber = true;
                                        extraNumber = false;
                                        Game[i,j].Text = (int.Parse(Game[i,j].Text) * 2).ToString();
                                        if (sum != 0)
                                        {
                                            Game[i,j - sum].Text = Game[i,j].Text;
                                            Game[i,j].Text = "";
                                            
                                        }
                                        Game[i,k].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (extraNumber == true && sum != 0)
                            {
                                checkLeft = false;
                                Game[i,j - sum].Text = Game[i,j].Text;
                                Game[i,j].Text = "";
                               
                            }
                        }
                        else
                        {
                            if (sum != 0)
                            {
                                checkLeft = false;
                                Game[i,j - sum].Text = Game[i, j].Text;
                                Game[i,j].Text = "";
                                
                            }
                        }


                    }
                }
            }
            if (checkLeft == false && checkWin == true)
            {
                sound.Play();
            }
            if (checkLeft == false && checkWin == false)
            {
                sound2.Play();
            }
            if (newNumber == true)
            {
                randomNumber();
            }
        }
        //Di chuyển sang phải
        public void moveRight()
        {
            bool checkRight = true;
            bool checkWin=false;
            bool newNumber = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int sum = 0;
                for (int j = 3; j >= 0; j--)
                {
                    for (int k = j - 1; k >= 0;k-- )
                    {
                        if(Game[i,k].Text!=""){
                            if(Game[i,k].Text==Game[i,j].Text){
                                checkWin = true;
                            }
                            break;
                        }
                    }
                    if (Game[i,j].Text == "")
                    {
                        sum++;
                    }
                    else
                    {
                        for (int m = j + 1; m < 4; m++)
                        {
                            if (Game[i,m].Text == "")
                            {
                                newNumber = true;
                                break;
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            bool extraNumber = true;
                            
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (Game[i,k].Text != "")
                                {
                                    
                                    
                                    if (Game[i,j].Text == Game[i,k].Text)
                                    {
                                        checkRight = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[i, j].Text) * 2).ToString();
                                       
                                        newNumber = true;
                                        extraNumber = false;
                                        Game[i,j].Text = (int.Parse(Game[i,j].Text) * 2).ToString();
                                        if (sum != 0)
                                        {
                                            Game[i, j+sum].Text = Game[ i,j].Text;
                                            Game[i,j].Text = "";
                                            
                                        }
                                        Game[i,k].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (extraNumber == true && sum != 0)
                            {
                                checkRight = false;
                                Game[i,j+ sum].Text = Game[i,j].Text;
                                Game[ i,j].Text = "";
                                
                            }
                        }
                        else
                        {
                            if (sum != 0)
                            {
                                checkRight = false;
                                Game[ i,j + sum].Text = Game[ i,j].Text;
                                Game[ i,j].Text = "";
                                
                            }
                        }
                    }
                }
            }
            if (checkRight == false && checkWin == true)
            {
                sound.Play();
            }
            if (checkRight == false && checkWin == false)
            {
                sound2.Play();
            }
            if (newNumber == true)
            {
                randomNumber();
            }
        }
        //cập nhật giao diện
        public bool Number() {
            Label[,] Game = {
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++ )
                {
                    if(Game[i,j].Text==""){
                        return false;
                    }
                    for (int k = j+1; k < 4;k++ )
                    {
                        if(Game[i,j].Text!=""){
                            if(Game[i,j].Text==Game[i,k].Text){
                                return false;
                            }
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Game[j, i].Text == "")
                    {
                        return false;
                    }
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (Game[k,i].Text != "")
                        {
                            if (Game[j,i].Text == Game[k,i].Text)
                            {
                                return false;
                            }
                            break;
                        }
                    }
                }
            }
            return true;
        }
        //Kết nối với bàn phím
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Number() == false)
            {
                if (e.KeyCode == Keys.Up)
                {
                    moveUp();

                }
                if (e.KeyCode == Keys.Down)
                {
                    moveDown();
                }
                if (e.KeyCode == Keys.Left)
                {
                    moveLeft();
                }
                if (e.KeyCode == Keys.Right)
                {
                    moveRight();
                }
               

            }
            else {
                replay = false;
                lblGameOver.Visible = true;
                btnNewGame.Visible = true;
                btnExit.Visible = true;
                btnExit.Enabled = true;
                btnNewGame.Enabled = true;
                this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
           
        }
        // Hàm khởi động lại trò chơi sau khi kết thúc game over. 
        // Hàm "new game" sẽ được sử dụng để khởi động lại trò chơi trong khi trò chơi vẫn đang diễn ra.
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            lblScore.Text = "0";
            Label[,] Game = {
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            lblGameOver.Visible = false;
            btnExit.Visible = false;
            replay = true;
            btnNewGame.Visible = false;
            btnNewGame.Enabled = false;
            btnExit.Enabled = false;
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++ )
                {
                    Game[i, j].Text = "";
                }
            }
            randomNumber();
            randomNumber();
            randomNumber();            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblAbout.Visible = false;
            label2.Visible = true;
            lblScore.Visible = true;

            if(replay==false){
                this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
            replay = true;
            lblScore.Text = "0";
            Label[,] Game = {
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            lblGameOver.Visible = false;
            btnExit.Visible = false;
            btnNewGame.Visible = false;
            btnNewGame.Enabled = false;
            btnExit.Enabled = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Game[i, j].Visible = true;
                    Game[i, j].Text = "";
                }
            }
            randomNumber();
            randomNumber();
            randomNumber();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNewGame_MouseHover(object sender, EventArgs e)
        {
            btnNewGame.BackColor = System.Drawing.Color.Green;
        }

        private void btnNewGame_MouseLeave(object sender, EventArgs e)
        {
            btnNewGame.BackColor = System.Drawing.Color.Orange;
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackColor = System.Drawing.Color.Green;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = System.Drawing.Color.Orange;
        }

        private void ptbImage_Click(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lbl3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }

        private void lblGameOver_Click(object sender, EventArgs e)
        {

        }

        private void gamePlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
          MessageBox.Show("This game a single player sliding block puzzle game. Use arrow keys to move the tiles.When two tiles with the same number touch, they merge into one. The game's objective is to slide numbered tiles on a grid to combine them to create a tile with the number 2048. 2048 was originally written in JavaScript and CSS by  Italian web developer Gabriele Cirulli.","How To Play",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
