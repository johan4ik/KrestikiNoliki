using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KrestikiNoliki
{
    public partial class Form1 : Form
    {
        int[,] mass = { { 0,0,0},{0,0,0 },{0,0,0 } };
        int count = 1;
        public Form1()
        {
            InitializeComponent();
        }

        int Redwin = 0;
        int Bluewin = 0;
         
        private void Form1_Paint(object sender, PaintEventArgs e)
        { Pen p = new Pen(Color.Black, 1.8f);
            Pen x = new Pen(Color.Red, 2.0f);
            Pen o = new Pen(Color.Blue, 2.0f);
            Graphics g = e.Graphics;
            int xx = 10;
            int y = 10;
            
            for(int i = 0; i < 4; i++)       // отрисовка поля
            {
                g.DrawLine(p, xx, 10, xx, 220);
                xx += 70;
                g.DrawLine(p,10,y,220,y);
                y += 70;
                
            }
            
            
                    int x1 = 15, x2 = 75, y1 = 15, y2 = 75;
                    for (int i = 0; i < 3; i++)        //авто отрисовка всех нулей и крестиков
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (mass[i, j] == 1)
                            {
                                g.DrawLine(x, x1, y1, x2, y2);
                                g.DrawLine(x, x1, y2, x2, y1);
                            }
                            else if (mass[i, j] == 2)
                            {
                                g.DrawEllipse(o, x1, y1, 62, 62);
                            }
                            x1 += 70;
                            x2 += 70;
                        }
                        x1 = 15;
                        x2 = 75;
                        y1 += 70;
                        y2 += 70;
                    }
                
               
            
        }
       private void Obnull(int[,] array) //обнуление массива после раунда
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = 0;
                }
            }
        }
   async     private void Vertikal(int[,] array) //проверка на победу по вертикали
        {  int X1 = 45; 
            Graphics g = CreateGraphics();
            for (int i = 0; i < 3; i++)
            {

                if (array[0, i] == 1 && array[1, i] == 1 && array[2, i] == 1)
                {

                    
                    MessageBox.Show("Победил игрок №2", "Победа!", MessageBoxButtons.OK);
                    g.DrawLine(new Pen(Color.Red, 3.0f), X1, 10, X1, 220);
                    Redwin++;
                    label3.Text = $"Счет {Bluewin} : {Redwin}";
                    
                    Obnull(mass);
                    await Task.Delay(250);
                    Invalidate();




                }
                else if (array[0, i] == 2 && array[1, i] == 2 && array[2, i] == 2)
                {

                    
                    MessageBox.Show("Победил игрок №1", "Победа!", MessageBoxButtons.OK);
                    g.DrawLine(new Pen(Color.Blue, 3.0f), X1, 10, X1, 220);
                    Bluewin++;
                    label3.Text = $"Счет {Bluewin} : {Redwin}";
                   
                    Obnull(mass);
                    await Task.Delay(250);
                    Invalidate();

                }
                else
                {
                    X1 += 70;
                }
               
            }
            
        }
     
    async private void Horizontal(int[,] array) //проверка на победу по горизонтали
        {
            Graphics g = CreateGraphics();
            int Y = 45;
            for(int i =0; i < 3; i++)
            {
                
                    if (array[i, 0] == 1 && array[i,1 ] == 1 && array[i, 2] == 1)
                    {
                        MessageBox.Show("Победил игрок №2", "Победа!", MessageBoxButtons.OK);
                    g.DrawLine(new Pen(Color.Red, 3.0f), 10, Y, 220, Y);
                    Redwin++;
                    label3.Text = $"Счет {Bluewin} : {Redwin}";
                    Obnull(mass);
                    await Task.Delay(250);
                    Invalidate();

                }
                else if (array[i, 0] == 2 && array[i, 1] == 2 && array[i, 2] == 2)
                {
                    MessageBox.Show("Победил игрок №1", "Победа!", MessageBoxButtons.OK);
                    g.DrawLine(new Pen(Color.Blue, 3.0f), 10, Y, 220, Y);
                    Bluewin++;
                    label3.Text = $"Счет {Bluewin} : {Redwin}";
                    Obnull(mass);
                    await Task.Delay(250);
                    Invalidate();
                }
                else
                {
                    Y += 70;
                }

            }
        }
        private void Draw(int[,] array) //ничья
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum += array[i, j];
                }
            }
            if (sum ==14 || sum==13)
            {
                MessageBox.Show("Никто не одержал победу", "Ничья", MessageBoxButtons.OK);
                label3.Text = $"Счет {Bluewin} : {Redwin}";
                Obnull(mass);
                Invalidate();
            }
        }
    async    private void LeftDiagonal(int[,] array) //левая диагональ
        {
            Graphics g = CreateGraphics();

            if (array[0, 0] == 1 && array[1, 1] == 1 && array[2, 2] == 1)
            {
                MessageBox.Show("Победил игрок №2", "Победа!", MessageBoxButtons.OK);
                g.DrawLine(new Pen(Color.Red, 3.0f), 10, 10, 220, 220);
                Redwin++;
                label3.Text = $"Счет {Bluewin} : {Redwin}";
                Obnull(mass);
                await Task.Delay(250);
                Invalidate();
                
            }
            else if (array[0, 0] == 2 && array[1, 1] == 2 && array[2, 2] == 2)
            {
                MessageBox.Show("Победил игрок №1", "Победа!", MessageBoxButtons.OK);
                g.DrawLine(new Pen(Color.Blue, 3.0f), 10, 10, 220, 220);
                Bluewin++;
                label3.Text = $"Счет {Bluewin} : {Redwin}";
                Obnull(mass);
                await Task.Delay(250);
                Invalidate();

            }
           
       
        }
    async    private void RightDiagonal(int[,] array) //правая диагональ
        {
            Graphics g = CreateGraphics();
            if (array[0, 2] == 1 && array[1, 1] == 1 && array[2, 0] == 1)
            {
                MessageBox.Show("Победил игрок №2", "Победа!", MessageBoxButtons.OK);
                g.DrawLine(new Pen(Color.Red, 3.0f), 220, 10, 10, 220);
                Redwin++;
                label3.Text = $"Счет {Bluewin} : {Redwin}";
                Obnull(mass);
                await Task.Delay(250);
                Invalidate();
            }
            else if (array[0, 2] == 2 && array[1, 1] == 2 && array[2, 0] == 2)
            {   
                MessageBox.Show("Победил игрок №1", "Победа!", MessageBoxButtons.OK);
                g.DrawLine(new Pen(Color.Blue, 3.0f), 220, 10, 10, 220);
                Bluewin++;
                label3.Text = $"Счет {Bluewin} : {Redwin}";
                Obnull(mass);
                await Task.Delay(250);
                Invalidate();
            }
           
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int X1 = 10, X2 = 80, Y1 = 10, Y2 = 80;
            
            
         
          for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (e.X > X1 && e.X < X2 && e.Y > Y1 && e.Y < Y2)   //иф проверяет соответствие координаты и то куда нажала мышь.
                    {
                        if (mass[i, j] == 0) //Блокировка клетки
                        {
                            if (count % 2 == 0) //если четная ставится ноль
                            {
                                mass[i, j] = 1;
                                label1.ForeColor = Color.Blue;
                                label2.ForeColor = Color.Black;

                            }
                            else             //если нечетная ставится крестик
                            {
                                mass[i, j] = 2; 
                                label1.ForeColor = Color.Black;
                                label2.ForeColor = Color.Red;

                            }
                            count++;
                            Invalidate();
                        }
                    }
                    X1 += 70;
                    X2 += 70;
                }
                X1 = 10;
                X2 = 80;
                Y1 += 70;
                Y2 += 70;
            }
            Horizontal(mass);
            Vertikal(mass);
            LeftDiagonal(mass);
            RightDiagonal(mass);
            Draw(mass);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bluewin = 0;
            Redwin = 0;
            label3.Text = "Счет 0 : 0";
            Obnull(mass);
            Invalidate();
        }
    }
}
