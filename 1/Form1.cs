using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Движение объекта по траектории";
            button1.Text = "Запуск";
            button2.Text = "Показать картинку";
            comboBox1.Text = "Выбор направления";
            comboBox1.SelectedIndex = 0;
            label1.Text = "Выбор цвета заливки фигуры производится в диалоговом окне после запуска";
            label3.Text = "Введите размер стороны квадрата";
            label2.Text = "Введите размер эллипса";
            label4.Text = "Введите скорость движения объекта";
            label5.Text = "Большая полуось (a)";
            label6.Text = "Малая полуось (b)";
            comboBox2.Text = "Сколько раз пройти по траектории?";
            comboBox2.SelectedIndex = 0;
            comboBox3.Text = "Шаг перемещения объекта";
            comboBox3.SelectedIndex = 0;
            comboBox4.Text = "Цвет траектории";
            comboBox4.SelectedIndex = 0;
            comboBox5.Text = "Цвет контура квадрата";
            comboBox5.SelectedIndex = 0;
            comboBox6.Text = "Толщина контура квадрата";
            comboBox6.SelectedIndex = 0;
            comboBox7.Text = "Толщина контура траектории";
            comboBox7.SelectedIndex = 0;
            comboBox8.Text = "Тип линии квадрата";
            comboBox8.SelectedIndex = 0;
            comboBox9.Text = "Тип линии траектории";
            comboBox9.SelectedIndex = 0;
            comboBox10.Text = "Прозрачность заливки";
            comboBox10.SelectedIndex = 0;
            comboBox11.Text = "Какую часть квадрата залить?";
            comboBox11.SelectedIndex = 0;
        }
        private void Paint_Ellipse(int cX, int cY, int a, int b)
        {
            Graphics Графика = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Графика.DrawEllipse(pen, cX-a, cY-b, a * 2, b * 2); 
        }

        private void Paint_rectangle(int cX, int cY, int x, int y)
        {
            int n = 0, k = 0;
            int c = Convert.ToInt32(textBox3.Text);
            Graphics Графика = pictureBox1.CreateGraphics();
            Pen Перо = new Pen(Color.White,n);
            switch (comboBox6.SelectedIndex)
            {
                case 0: n=1; break;
                case 1: n=2; break;
                case 2: n=3; break;
                case 3: n=4; break;
                case 4: n=5; break;
            }
            switch (comboBox5.SelectedIndex)
            {
                case 0: Перо = new Pen(Color.Orange,n); break;
                case 1: Перо = new Pen(Color.Blue,n); break;
                case 2: Перо = new Pen(Color.Red,n); break;
                case 3: Перо = new Pen(Color.Green,n); break;
                case 4: Перо = new Pen(Color.Purple,n); break;
                case 5: Перо = new Pen(Color.Pink,n); break;
            }
            switch (comboBox8.SelectedIndex)
            {
                case 0: Перо.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; ; break; 
                case 1: Перо.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot; break;
                case 2: Перо.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot; break;
                case 3: Перо.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot; break;
                case 4: Перо.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; break;
            }

            Графика.DrawRectangle(Перо, cX+x,cY + y , c , c);
            switch (comboBox10.SelectedIndex)
            {
                case 0: k = 255; break; //100
                case 1: k = 179; break; //70
                case 2: k = 128; break; //50
                case 3: k = 51; break;//20
                case 4: k = 13; break; //5
            }
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(k, (colorDialog1.Color))); //заливка в 50 процентов, и выбор цвета в диалоговом окне
            switch (comboBox11.SelectedIndex)
            {
                case 0: Графика.FillRectangle(solidBrush, cX + x, cY + y, c / 2, c); ; break; //слева
                case 1: Графика.FillRectangle(solidBrush, cX + x, cY + y, c, c/2); ; break; //сверху
                case 2: Графика.FillRectangle(solidBrush, cX + x+c/2, cY + y, c/2, c); ; break; //справа
                case 3: Графика.FillRectangle(solidBrush, cX + x, cY + y+c/2, c, c/2); ; break;//снизу  
            }
        }

        private void Paint_Graphic(int cX, int cY, int x, int y, Point[] p, int a, int b)
        {
            int k = 0;
            Graphics Графика = pictureBox1.CreateGraphics();
            Графика.FillRectangle(Brushes.Black, cX, cY, 10, 10);
            Графика.Clear(BackColor);
            Paint_Ellipse(cX, cY, a, b);
            Pen Перо = new Pen(Color.White, k);
            switch (comboBox7.SelectedIndex) 
            {
                case 0: k = 1; break;
                case 1: k = 2; break;
                case 2: k = 3; break;
                case 3: k = 4; break;
                case 4: k = 5; break;
            }
            switch (comboBox4.SelectedIndex)
            {
                case 0: Перо = new Pen(Color.Red,k); break;
                case 1: Перо = new Pen(Color.Blue,k); break;
                case 2: Перо = new Pen(Color.Green,k); break;
                case 3: Перо = new Pen(Color.Yellow,k); break;
                case 4: Перо = new Pen(Color.Black,k); break;
                case 5: Перо = new Pen(Color.Purple,k); break;
            }
            switch (comboBox9.SelectedIndex)
            {
                case 0: Перо.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; ; break; //штриховая
                case 1: Перо.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot; break; //штрихпунктирная
                case 2: Перо.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot; break;
                case 3: Перо.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot; break; //пунктирная
                case 4: Перо.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; break;//сплошная
            }
            Графика.DrawLines(Перо, p); // траектория
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double InitT = 0, LastT= 6.3; // оборот в 360 градусов (6,28 радиан)
            double Step = 0.1, angle = InitT;
            double x, y;
            int cX = 150, cY = 150; // центр 
            int i = 0; // количество точек прорисовки
            Point[] p = new Point[1000];
            if (colorDialog1.ShowDialog() == DialogResult.Cancel) return;
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            int V = Convert.ToInt32(textBox4.Text);

            switch (comboBox2.SelectedIndex)
            {
                case 0: LastT = 6.3; break;
                case 1: LastT = 6.3 * 2; break;
                case 2: LastT = 6.3 * 3; break;
            }
            switch (comboBox3.SelectedIndex)
            {
                case 0: Step = 0.1; break;
                case 1: Step = 0.3; break;
                case 2: Step = 0.5; break;
            }
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    while (angle <= LastT)
                    {
                        x = ((a * a - b * b) * Math.Cos(angle) * Math.Cos(angle) * Math.Cos(angle)) / a;
                        y = ((a * a - b * b) * Math.Sin(angle) * Math.Sin(angle) * Math.Sin(angle)) / b;
                        p[i] = new Point((int)(cX + (x)), (int)(cY + (y))); // расчет очередной точки траектории
                        Paint_Graphic(cX, cY, (int)x, (int)y, p, a, b);
                        Paint_rectangle(cX, cY, (int)x, (int)y);
                        angle += Step;
                        Thread.Sleep(V); 
                        i++;
                    }
                    break;
                case 1:
                    while (angle <= LastT)
                    {
                        x = ((a * a - b * b) * Math.Cos(-angle) * Math.Cos(-angle) * Math.Cos(-angle)) / a;
                        y = ((a * a - b * b) * Math.Sin(-angle) * Math.Sin(-angle) * Math.Sin(-angle)) / b;
                        p[i] = new Point((int)(cX + (x)), (int)(cY + (y))); // расчет очередной точки траектории
                        Paint_Graphic(cX, cY, (int)x, (int)y, p, a, b);
                        Paint_rectangle(cX, cY, (int)x, (int)y);
                        angle += Step;
                        Thread.Sleep(V); 
                        i++;
                    }
                    break;
            }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //pictureBox2.Image = Image.FromFile("C:\\Users\\User\\Desktop\\1.jpg");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



      
   