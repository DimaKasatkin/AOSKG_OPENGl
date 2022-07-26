using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_new
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            create_osxy();
            drow_figures();
        }

        

        List<Osxy> osxy_rictangle = new List<Osxy>();
        List<Osxy> left_triangle = new List<Osxy>();
        List<Osxy> right_triangle = new List<Osxy>();
        private void create_osxy()
        {
            osxy_rictangle.Add(new Osxy(- 7f, 3.5f));
            osxy_rictangle.Add(new Osxy(7f, 3.5f));
            osxy_rictangle.Add(new Osxy(7f, -3f));
            osxy_rictangle.Add(new Osxy(-7f, -3f));

            left_triangle.Add(new Osxy(3.5f, 3f));
            left_triangle.Add(new Osxy(6f, -2f));
            left_triangle.Add(new Osxy(1f, -2f));

            right_triangle.Add(new Osxy(-3.5f, 3f));
            right_triangle.Add(new Osxy(-6f, -2f));
            right_triangle.Add(new Osxy(-1f, -2f));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (Osxy osxy in osxy_rictangle)
            {
                osxy.x -= 0.1f;
            }
            foreach (Osxy osxy in left_triangle)
            {
                osxy.x -= 0.1f;
            }
            foreach (Osxy osxy in right_triangle)
            {
                osxy.x -= 0.1f;
            }
            drow_figures();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            foreach (Osxy osxy in osxy_rictangle)
            {
                osxy.x += 0.1f;
            }
            foreach (Osxy osxy in left_triangle)
            {
                osxy.x += 0.1f;
            }
            foreach (Osxy osxy in right_triangle)
            {
                osxy.x += 0.1f;
            }
            drow_figures();
        }

        private void multyplie_matrix(float[][] A,int countrows)
        {
            foreach (Osxy osxy in osxy_rictangle)
            {
                
            }
        }
        Single angle = 0;
        private void drow_figures()
        {
           
            OpenGL gl = this.openGLControl1.OpenGL;
            // Очистка экрана и буфера глубин
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            // Сбрасываем модельно-видовую матрицу
            gl.LoadIdentity();
          //  l++;
            // Двигаем перо вглубь экрана
            gl.Rotate(angle, 0f, 0f, 1f);
            gl.Translate(0.0f, 0.0f, -20.0f);

            gl.Begin(OpenGL.GL_LINE_LOOP);

            // Указываем цвет вершин
            gl.Color(1f, 0f, 0f);
            //рисуем левый прямоугольник
            foreach (Osxy figures in osxy_rictangle)
            {
                gl.Vertex(figures.x, figures.y);
            }

            gl.End();

            gl.Begin(OpenGL.GL_LINE_LOOP);

            // Указываем цвет вершин
            gl.Color(1f, 0f, 0f);
            //рисуем левый треугольник
            foreach (Osxy figures in left_triangle)
            {
                gl.Vertex(figures.x, figures.y);
            }
            gl.End();

            gl.Begin(OpenGL.GL_LINE_LOOP);

            // Указываем цвет вершин
            gl.Color(1f, 0f, 0f);
            //рисуем правый треугольник
            foreach (Osxy figures in right_triangle)
            {
                gl.Vertex(figures.x, figures.y);
            }

            // Завершаем работу
            gl.End();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            foreach (Osxy osxy in osxy_rictangle)
            {
                osxy.y -= 0.1f;
            }
            foreach (Osxy osxy in left_triangle)
            {
                osxy.y -= 0.1f;
            }
            foreach (Osxy osxy in right_triangle)
            {
                osxy.y -= 0.1f;
            }
            drow_figures();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            foreach (Osxy osxy in osxy_rictangle)
            {
                osxy.y += 0.1f;
            }
            foreach (Osxy osxy in left_triangle)
            {
                osxy.y += 0.1f;
            }
            foreach (Osxy osxy in right_triangle)
            {
                osxy.y += 0.1f;
            }
            drow_figures();

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            foreach (Osxy osxy in osxy_rictangle)
            {
                osxy.x *= 1.1f;
                osxy.y *= 1.1f;
            }
            foreach (Osxy osxy in left_triangle)
            {
                osxy.x *= 1.1f;
                osxy.y *= 1.1f;
            }
            foreach (Osxy osxy in right_triangle)
            {
                osxy.x *= 1.1f;
                osxy.y *= 1.1f;
            }
            drow_figures();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            foreach (Osxy osxy in osxy_rictangle)
            {
                osxy.x /= 1.1f;
                osxy.y /= 1.1f;
            }
            foreach (Osxy osxy in left_triangle)
            {
                osxy.x /= 1.1f;
                osxy.y /= 1.1f;
            }
            foreach (Osxy osxy in right_triangle)
            {
                osxy.x /= 1.1f;
                osxy.y /= 1.1f;
            }
            drow_figures();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            angle+=10;

            /*
            foreach (Osxy osxy in osxy_rictangle)
            {
                osxy.x = Convert.ToSingle(osxy.x * Math.Cos(-10 * Math.PI / 180) - osxy.y * Math.Sin(-10 * Math.PI / 180));
                osxy.y =Convert.ToSingle( (osxy.x * Math.Sin(-10 * Math.PI / 180)) + (osxy.y * Math.Cos(-10 * Math.PI / 180)));
            }*/
            /* foreach (Osxy osxy in left_triangle)
             {
                 osxy.x /= 1.1f;
                 osxy.y /= 1.1f;
             }
             foreach (Osxy osxy in right_triangle)
             {
                 osxy.x /= 1.1f;
                 osxy.y /= 1.1f;
             }
             */
            drow_figures();

            //x[i] = x[i] * Math.Cos(-30 * Math.PI / 180) - y[i] * Math.Sin(30 * Math.PI / 180);
        //    y[i] = x[i] * Math.Sin(-30 * Math.PI / 180) + y[i] * Math.Cos(30 * Math.PI / 180);
//

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            angle-=10;
            drow_figures();
        }
    }
}
