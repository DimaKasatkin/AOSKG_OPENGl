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

namespace Lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            create_osxy();
        }
        List<Osxy> osxy_rhombus = new List<Osxy>();

        List<Osxy> kub = new List<Osxy>();
        List<Osxy> line = new List<Osxy>();

        List<Osxy> down_buffer = new List<Osxy>();
        List<Osxy> down_buffer_kub = new List<Osxy>();
        private void create_osxy()
        {
            osxy_rhombus.Add(new Osxy(0f, 6f));
            osxy_rhombus.Add(new Osxy(3f, 0f));
            osxy_rhombus.Add(new Osxy(0f, -6f));
            osxy_rhombus.Add(new Osxy(-3f, 0f));

            kub.Add(new Osxy(2f, 2f));
            kub.Add(new Osxy(2f, -2f));
            kub.Add(new Osxy(-2f, -2f));
            kub.Add(new Osxy(-2f, 2f));

      
            line.Add(new Osxy(5, -4));
            line.Add(new Osxy(-5, 3));
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            drow_figures(true);
            float a, b, c, t, d;
            int x1, x2, x3, y1, y2, y3;
        }
        private void drow_figures(bool up)
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            // Очистка экрана и буфера глубин
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            // Сбрасываем модельно-видовую матрицу
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -20.0f);
            if (up)
            {
                gl.Begin(OpenGL.GL_LINE_LOOP);

                gl.Color(0f, 1f, 0f);
                foreach (Osxy figures in osxy_rhombus)
                {
                    gl.Vertex(figures.x, figures.y);
                }
                gl.End();

                gl.Begin(OpenGL.GL_LINE_LOOP);
                gl.Color(0f, 1f, 0f);
                foreach (Osxy figures in kub)
                {
                    gl.Vertex(figures.x, figures.y);
                }
                gl.End();
            }
            bool bolean_f = false; Osxy temp = new Osxy(0, 0);
            foreach (Osxy figures in osxy_rhombus)
            {
                if (bolean_f)
                {
                    are_crossing1(figures.x, figures.y, temp.x, temp.y);
                    temp = new Osxy(figures.x, figures.y);
                }
                else
                {
                    bolean_f = true;
                    temp = new Osxy(figures.x, figures.y);
                }
            }
            are_crossing1(osxy_rhombus[0].x, osxy_rhombus[0].y, temp.x, temp.y);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            // Указываем цвет вершин
            if (up)
                gl.Color(0f, 0f, 0f);
            else
                gl.Color(1f, 0f, 0f);
            foreach (Osxy figures in down_buffer)
            {
                gl.Vertex(figures.x, figures.y);
            }
            gl.End();
            temp_b_fl = false;

            bolean_f = false;

            foreach (Osxy figures in kub)
            {
                if (bolean_f)
                {
                    are_crossing2(figures.x, figures.y, temp.x, temp.y);
                    temp = new Osxy(figures.x, figures.y);
                }
                else
                {
                    bolean_f = true;
                    temp = new Osxy(figures.x, figures.y);
                }
            }
            are_crossing2(kub[0].x, kub[0].y, temp.x, temp.y);

            gl.Begin(OpenGL.GL_LINE_LOOP);
            if (up)
                gl.Color(0f, 0f, 0f);
            else
                gl.Color(1f, 0f, 0f);
            foreach (Osxy figures in down_buffer_kub)
            { 
                gl.Vertex(figures.x, figures.y);
            }
            gl.End();
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0f, 1f, 1f);
            foreach (Osxy figures in line)
            {
                gl.Vertex(figures.x, figures.y);
            }
            gl.End();
            down_buffer_kub.Clear();
            down_buffer.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            drow_figures(false);
        }
        bool temp_b_fl = false;
        public void are_crossing1(double x1, double y1, double x_temp, double y_temp)
        {
            double a1, b1, c1, a2, b2, c2;
            a2 = line[1].y - line[0].y;
            b2 = line[0].x - line[1].x;
            c2 = -line[0].x * (line[1].y - line[0].y) + line[0].y * (line[1].x - line[0].x);
            double znak = a2 * x1 + b2 * y1 + c2;
            if (znak < 0)
            {
                if (temp_b_fl != true)
                {
                    a1 = y_temp - y1;
                    b1 = x1 - x_temp;
                    c1 = -x1 * (y_temp - y1) + y1 * (x_temp - x1);
                    double x_new = -(c1 * b2 - c2 * b1) / (a1 * b2 - a2 * b1);
                    double y_new = -(a1 * c2 - a2 * c1) / (a1 * b2 - a2 * b1);
                    down_buffer.Add(new Osxy(x_new, y_new));
                    down_buffer.Add(new Osxy(x1, y1));
                    temp_b_fl = true;
                }
                else
                {
                    down_buffer.Add(new Osxy(x1, y1));
                }
            }
            else
            {
                if (temp_b_fl)
                {
                    a1 = y_temp - y1;
                    b1 = x1 - x_temp;
                    c1 = -x1 * (y_temp - y1) + y1 * (x_temp - x1);
                    double x_new = -(c1 * b2 - c2 * b1) / (a1 * b2 - a2 * b1);
                    double y_new = -(a1 * c2 - a2 * c1) / (a1 * b2 - a2 * b1);
                    down_buffer.Add(new Osxy(x_new, y_new));
                    temp_b_fl = false;
                }
            }
        }
        public void are_crossing2(double x1, double y1, double x_temp, double y_temp)
        {
            double a1, b1, c1, a2, b2, c2;
            a2 = line[1].y - line[0].y;
            b2 = line[0].x - line[1].x;
            c2 = -line[0].x * (line[1].y - line[0].y) + line[0].y * (line[1].x - line[0].x);
            double znak = a2 * x1 + b2 * y1 + c2;
            if (znak < 0)
            {
                if (temp_b_fl != true)
                {
                    a1 = y_temp - y1;
                    b1 = x1 - x_temp;
                    c1 = -x1 * (y_temp - y1) + y1 * (x_temp - x1);
                    double x_new = -(c1 * b2 - c2 * b1) / (a1 * b2 - a2 * b1);
                    double y_new = -(a1 * c2 - a2 * c1) / (a1 * b2 - a2 * b1);
                    down_buffer_kub.Add(new Osxy(x_new, y_new));
                    down_buffer_kub.Add(new Osxy(x1, y1));
                    temp_b_fl = true;
                }
                else
                {
                    down_buffer.Add(new Osxy(x1, y1));
                }
            }
            else
            {
                if (temp_b_fl)
                {
                    a1 = y_temp - y1;
                    b1 = x1 - x_temp;
                    c1 = -x1 * (y_temp - y1) + y1 * (x_temp - x1);
                    double x_new = -(c1 * b2 - c2 * b1) / (a1 * b2 - a2 * b1);
                    double y_new = -(a1 * c2 - a2 * c1) / (a1 * b2 - a2 * b1);
                    down_buffer_kub.Add(new Osxy(x_temp, y_temp));
                    down_buffer_kub.Add(new Osxy(x_new, y_new));
                    temp_b_fl = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -20.0f);
            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Color(1f, 1f, 1f);
            foreach (Osxy figures in osxy_rhombus)
            {
                gl.Vertex(figures.x, figures.y);
            }
            gl.End();

            gl.Begin(OpenGL.GL_LINE_LOOP);
            gl.Color(1f, 1f, 1f);
            foreach (Osxy figures in kub)
            {
                gl.Vertex(figures.x, figures.y);
            }
            gl.End();

            down_buffer_kub.Clear();
            down_buffer.Clear();
        }
    }
}
