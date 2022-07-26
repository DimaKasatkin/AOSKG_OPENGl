using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_5
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            inti_figuries();
            drow_figures();
            radioButton1.Select();
        }
        List<Osxy> osxy_triangle_up_down = new List<Osxy>();
        List<Osxy> osxy_triangle_left_rigth = new List<Osxy>();
        public void inti_figuries()
        {
            osxy_triangle_up_down.Add(new Osxy(0.0f, 6.0f, 0.0f));
            osxy_triangle_up_down.Add(new Osxy(2.0f, 2.0f, 0.0f));
            osxy_triangle_up_down.Add(new Osxy(-2.0f, 2.0f, 0.0f));

            osxy_triangle_left_rigth.Add(new Osxy(2.0f, 2.0f, 0.0f));
            osxy_triangle_left_rigth.Add(new Osxy(3.0f, 0.0f, 0.0f));
            osxy_triangle_left_rigth.Add(new Osxy(2.0f, -2.0f, 0.0f));
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            angle_x = trackBar1.Value;
            drow_figures();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            angle_y = trackBar2.Value;
            drow_figures();
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            angle_z = trackBar3.Value;
            drow_figures();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            OpenGL gl = openGLControl1.OpenGL;
            gl.LoadIdentity();
            gl.Enable(OpenGL.GL_DEPTH_TEST);

            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            float[] light0pos = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] light0ambient = new float[] { 1.0f, 1.0f, 0.0f, 1.0f };
            float[] light0difuse = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] light0specular = new float[] { 0.8f, 0.8f, 0.8f, 1.0f };

            float[] lmodel_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);

            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0difuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);

            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);

            gl.ShadeModel(OpenGL.GL_SMOOTH);
            drow_figures();
     
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl1.OpenGL;
            gl.LoadIdentity();
            gl.Enable(OpenGL.GL_DEPTH_TEST);

            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            float[] light0pos = new float[] { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] light0ambient = new float[] { 1.0f, 1.0f, 0.0f, 1.0f };
            float[] light0difuse = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] light0specular = new float[] { 0.8f, 0.8f, 0.8f, 1.0f };

            float[] lmodel_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);

            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0difuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);

            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);

            gl.ShadeModel(OpenGL.GL_SMOOTH);
          
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_LIGHT0); drow_figures();
        }

        Single angle_x = 0, angle_y = 0, angle_z = 0;

        int matrix=0;
        private void button1_Click(object sender, EventArgs e)
        {
            matrix++;
            drow_figures();
        }
        

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            matrix--;
            drow_figures();
        }

        private void drow_figures()
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            gl.PushMatrix();
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Translate(matrix, 0, -200.0f);
            gl.Rotate(angle_x, 1, 0, 0);
            gl.Rotate(angle_y, 0, 1, 0);
            gl.Rotate(angle_z, 0, 0, 1);
            gl.Translate(0.0f, 0.0f, 2.5f);
            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_FILL);
            gl.Begin(OpenGL.GL_QUADS);



            for (int j = 0; j < 5; j++)
            {

                for (int i = 0; i < 40; i++)
                {
                    float x = (float)(Math.Sin(1) * 2);
                    double angle = Math.PI * 20 / 180.0;

                    int temp_i = i;

                    gl.Vertex((float)(Math.Sin(angle * i) * 20) * j, ((float)(Math.Cos(angle * i)) * 20) * j, 10 * j);
                    i++;
                    gl.Vertex((float)(Math.Sin(angle * i) * 20) * j, ((float)(Math.Cos(angle * i)) * 20) * j, 10 * j);

                    j++;
                    gl.Vertex((float)(Math.Sin(angle * i) * 20) * j, ((float)(Math.Cos(angle * i)) * 20) * j, 10 * j);
                    i--;
                    gl.Vertex((float)(Math.Sin(angle * i) * 20) * j, ((float)(Math.Cos(angle * i)) * 20) * j, 10 * j);
                    j--;
                }
            }


            gl.End();

            gl.End();
            gl.PopMatrix();
        }

    }
}
   