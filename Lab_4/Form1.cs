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

namespace Lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "X", "Y", "Z" });
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
            radioButton1.Select();
            create_osxy();
            drow_figures();
        }

        List<Osxy> osxy_rhombus = new List<Osxy>();
        List<Osxy> kub = new List<Osxy>();
        private void create_osxy()
        {
            osxy_rhombus.Add(new Osxy(0f, 6f, 0f));
            osxy_rhombus.Add(new Osxy(3f, 0f, 0f));
            osxy_rhombus.Add(new Osxy(0f, -6f, 0f));
            osxy_rhombus.Add(new Osxy(-3f, 0f, 0f));

            kub.Add(new Osxy(2f, 2f, 0f));
            kub.Add(new Osxy(2f, -2f, 0f));
            kub.Add(new Osxy(-2f, -2f, 0f));
            kub.Add(new Osxy(-2f, 2f, 0f));
        }
        Single angle_x = 0, angle_y = 0, angle_z = 0;

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1 = (RadioButton)sender;
            if (radioButton1.Checked)
            {
                MessageBox.Show("Вы выбрали " + radioButton1.Text);
            }
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1 = (RadioButton)sender;
            if (radioButton1.Checked)
            {
                MessageBox.Show("Вы выбрали " + radioButton1.Text);
            }
        }
        Single matrix_x = 0, matrix_y = 0, matrix_z = 0;
        private void drow_figures()
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            // Очистка экрана и буфера глубин
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            // Сбрасываем модельно-видовую матрицу
            gl.PushMatrix();
            gl.Translate(matrix_x, matrix_y, matrix_z - 20.0f);
            gl.Rotate(angle_x, 1, 0, 0);
            gl.Rotate(angle_y, 0, 1, 0);
            gl.Rotate(angle_z, 0, 0, 1);
            gl.Translate(0.0f, 0.0f, 2.5f);
            if (radioButton2.Checked)
            {
                gl.Enable(OpenGL.GL_DEPTH_TEST);
                gl.Enable(OpenGL.GL_POLYGON_OFFSET_LINE);
                gl.PolygonOffset(-1.0f, -1.0f);
                gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_FILL);
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(0f, 0f, 0f);
                foreach (Osxy figures in osxy_rhombus)
                {
                    gl.Vertex(figures.x, figures.y, figures.z);
                }
                gl.End();
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(0f, 0f, 0f);
                foreach (Osxy figures in osxy_rhombus)
                {
                    gl.Vertex(figures.x, figures.y, figures.z - 5);
                }
                gl.End();
                for (int i1 = 0; i1 < osxy_rhombus.Count - 1; i1++)
                {
                    gl.Begin(OpenGL.GL_POLYGON);
                    gl.Color(0f, 0f, 0f);
                    gl.Vertex(osxy_rhombus[i1].x, osxy_rhombus[i1].y, osxy_rhombus[i1].z);
                    gl.Vertex(osxy_rhombus[i1 + 1].x, osxy_rhombus[i1 + 1].y, osxy_rhombus[i1 + 1].z);
                    gl.Vertex(osxy_rhombus[i1 + 1].x, osxy_rhombus[i1 + 1].y, osxy_rhombus[i1 + 1].z - 5);
                    gl.Vertex(osxy_rhombus[i1].x, osxy_rhombus[i1].y, osxy_rhombus[i1].z - 5);
                    gl.End();
                }
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(0f, 0f, 0f);
                gl.Vertex(osxy_rhombus[0].x, osxy_rhombus[0].y, osxy_rhombus[0].z);
                gl.Vertex(osxy_rhombus[3].x, osxy_rhombus[3].y, osxy_rhombus[3].z);
                gl.Vertex(osxy_rhombus[3].x, osxy_rhombus[3].y, osxy_rhombus[3].z - 5);
                gl.Vertex(osxy_rhombus[0].x, osxy_rhombus[0].y, osxy_rhombus[0].z - 5);
                gl.End();
            }
            ///включение граней
            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
            gl.Begin(OpenGL.GL_POLYGON);

            gl.Color(1f, 1f, 0f);
            foreach (Osxy figures in osxy_rhombus)
            {
                gl.Vertex(figures.x, figures.y, figures.z);
            }
            gl.End();
            gl.Color(1f, 0f, 0f);
            foreach (Osxy figures in osxy_rhombus)
            {
                gl.Vertex(figures.x, figures.y, figures.z - 5);
            }
            gl.End();
            for (int i1 = 0; i1 < osxy_rhombus.Count - 1; i1++)
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(1f, 0f, 0f);     // красный цвет
                gl.Vertex(osxy_rhombus[i1].x, osxy_rhombus[i1].y, osxy_rhombus[i1].z);
                gl.Vertex(osxy_rhombus[i1 + 1].x, osxy_rhombus[i1 + 1].y, osxy_rhombus[i1 + 1].z);

                gl.Vertex(osxy_rhombus[i1 + 1].x, osxy_rhombus[i1 + 1].y, osxy_rhombus[i1 + 1].z - 5);
                gl.Vertex(osxy_rhombus[i1].x, osxy_rhombus[i1].y, osxy_rhombus[i1].z - 5);
                gl.End();
            }
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1f, 0f, 0f);     // красный цвет
            gl.Vertex(osxy_rhombus[0].x, osxy_rhombus[0].y, osxy_rhombus[0].z);
            gl.Vertex(osxy_rhombus[3].x, osxy_rhombus[3].y, osxy_rhombus[3].z);
            gl.Vertex(osxy_rhombus[3].x, osxy_rhombus[3].y, osxy_rhombus[3].z - 5);
            gl.Vertex(osxy_rhombus[0].x, osxy_rhombus[0].y, osxy_rhombus[0].z - 5);
            gl.End();
            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1f, 0f, 0f);
            foreach (Osxy figures in kub)
            {
                gl.Vertex(figures.x, figures.y, figures.z);
            }
            gl.End();
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1f, 0f, 0f);
            foreach (Osxy figures in kub)
            {
                gl.Vertex(figures.x, figures.y, figures.z - 5);
            }
            gl.End();
            for (int i1 = 0; i1 < kub.Count - 1; i1++)
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(1f, 0f, 0f);     // красный цвет
                gl.Vertex(kub[i1].x, kub[i1].y, kub[i1].z);
                gl.Vertex(kub[i1 + 1].x, kub[i1 + 1].y, kub[i1 + 1].z);

                gl.Vertex(kub[i1 + 1].x, kub[i1 + 1].y, kub[i1 + 1].z - 5);
                gl.Vertex(kub[i1].x, kub[i1].y, kub[i1].z - 5);
                gl.End();
            }
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1f, 0f, 0f);     // красный цвет
            gl.Vertex(kub[0].x, kub[0].y, kub[0].z - 5);
            gl.Vertex(kub[3].x, kub[3].y, kub[3].z - 5);
            gl.Vertex(kub[3].x, kub[3].y, kub[3].z - 5);
            gl.Vertex(kub[0].x, kub[0].y, kub[0].z - 5);
            gl.End();
            gl.PopMatrix();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            drow_figures();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            drow_figures();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                matrix_x++;
            if (comboBox1.SelectedIndex == 1)
                matrix_y++;
            if (comboBox1.SelectedIndex == 2)
                matrix_z++;
            drow_figures();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
                angle_x += 10;
            if (comboBox1.SelectedIndex == 1)
                angle_y += 10;
            if (comboBox1.SelectedIndex == 2)
                angle_z += 10;
            drow_figures();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                matrix_x--;
            if (comboBox1.SelectedIndex == 1)
                matrix_y--;
            if (comboBox1.SelectedIndex == 2)
                matrix_z--;
            drow_figures();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            drow_figures();
        }

        private double degrees(int degrees)
        {
            return Math.PI * degrees / 180.0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                angle_x -= 10;
            if (comboBox1.SelectedIndex == 1)
                angle_y -= 10;
            if (comboBox1.SelectedIndex == 2)
                angle_z -= 10;
            drow_figures();
        }
    }
}
