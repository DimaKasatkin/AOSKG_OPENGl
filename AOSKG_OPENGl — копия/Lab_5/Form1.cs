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
        }
        List<Osxy> osxy_triangle_up_down = new List<Osxy>();
        List<Osxy> osxy_triangle_left_rigth = new List<Osxy>();
        // List<Osxy> osxy_triangle3 = new List<Osxy>();
        //   List<Osxy> osxy_triangle4 = new List<Osxy>();
        public void inti_figuries()
        {
            osxy_triangle_up_down.Add(new Osxy(0.0f, 6.0f, 0.0f));
            osxy_triangle_up_down.Add(new Osxy(2.0f, 2.0f, 0.0f));
            osxy_triangle_up_down.Add(new Osxy(-2.0f, 2.0f, 0.0f));

            osxy_triangle_left_rigth.Add(new Osxy(2.0f, 2.0f, 0.0f));
            osxy_triangle_left_rigth.Add(new Osxy(3.0f, 0.0f, 0.0f));
            osxy_triangle_left_rigth.Add(new Osxy(2.0f, -2.0f, 0.0f));
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           

            drow_figures();
        }
        Single matrix_x = 0, matrix_y = 0, matrix_z = 0;

        private void button2_Click(object sender, EventArgs e)
        {
           // angle_x += 10;
          //  angle_y += 10;
          //  angle_z += 10;
            drow_figures();
        }
     //   private static ShaderProgram program;
      /*  private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
          //  program["light_direction"].SetValue(new Vector3(0, 0, 1));
         //   program["enable_lighting"].SetValue(lighting);
            
            OpenGL gl = openGLControl1.OpenGL;
            gl.LoadIdentity();
            gl.Enable(OpenGL.GL_DEPTH_TEST);

            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            float[] light0pos = new float[] { 0.0f,5.0f,10.0f,1.0f}; 
            float[] light0ambient = new float[] { 0.2f,0.2f,0.2f,1.0f}; 
            float[] light0difuse = new float[]{0.3f,0.3f,0.3f,1.0f}; 
            float[] light0specular = new float[] { 0.8f,0.8f,0.8f,1.0f};

            float[] lmodel_ambient = new float[] {0.2f,0.2f,0.2f,1.0f };

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);

            gl.Light(OpenGL.GL_LIGHT0,OpenGL.GL_POSITION,light0pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0difuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);

           gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);

            gl.ShadeModel(OpenGL.GL_SMOOTH);
        }
        */
        private void button3_Click(object sender, EventArgs e)
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

        Single angle_x = 0, angle_y = 0, angle_z = 0;
        private void drow_figures()
        {
            OpenGL gl = this.openGLControl1.OpenGL;
            // Очистка экрана и буфера глубин
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            // Сбрасываем модельно-видовую матрицу
            gl.PushMatrix();
            gl.Enable(OpenGL.GL_LIGHT0);


            gl.Translate(matrix_x, matrix_y, matrix_z - 20.0f);
            // gl.glTranslatef(x, y, z);

            gl.Rotate(angle_x, 1, 0, 0);
            gl.Rotate(angle_y, 0, 1, 0);
            gl.Rotate(angle_z, 0, 0, 1);




            gl.Translate(0.0f, 0.0f, 2.5f);



            //  .. MessageBox.Show(radioButton1.Checked.ToString());



            
            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_FILL);
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1.0f,0.0f,0.0f);
            foreach (Osxy osxy in osxy_triangle_up_down)
            {
                gl.Vertex(osxy.x,osxy.y,osxy.z);
            }

            gl.End();

            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1.0f, 1.0f, 0.0f);
            foreach (Osxy osxy in osxy_triangle_up_down)
            {
                gl.Vertex(osxy.x, -osxy.y, osxy.z);
            }
            gl.End();

            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1.0f, 0.0f, 0.0f);
            foreach (Osxy osxy in osxy_triangle_up_down)
            {
                gl.Vertex(osxy.x, osxy.y, osxy.z-5);
            }

            gl.End();
            
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1.0f, 0.0f, 0.0f);
            foreach (Osxy osxy in osxy_triangle_up_down)
            {
                gl.Vertex(osxy.x, -osxy.y, osxy.z-5);
            }
            
            gl.End();
            
            gl.Color(0.0f, 1.0f, 1.0f);
            for (int i= osxy_triangle_up_down.Count-1;i>0; i--)
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Vertex(osxy_triangle_up_down[i].x, osxy_triangle_up_down[i].y, osxy_triangle_up_down[i].z );
                gl.Vertex(osxy_triangle_up_down[i].x, osxy_triangle_up_down[i].y, osxy_triangle_up_down[i].z - 5);
                gl.Vertex(osxy_triangle_up_down[i-1].x, osxy_triangle_up_down[i-1].y, osxy_triangle_up_down[i-1].z - 5);
                gl.Vertex(osxy_triangle_up_down[i - 1].x, osxy_triangle_up_down[i - 1].y, osxy_triangle_up_down[i - 1].z );
                gl.End();
            }
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Vertex(osxy_triangle_up_down[0].x, osxy_triangle_up_down[0].y, osxy_triangle_up_down[0].z);
            gl.Vertex(osxy_triangle_up_down[0].x, osxy_triangle_up_down[0].y, osxy_triangle_up_down[0].z - 5);
            gl.Vertex(osxy_triangle_up_down[2].x, osxy_triangle_up_down[2].y, osxy_triangle_up_down[2].z - 5);
            gl.Vertex(osxy_triangle_up_down[2].x, osxy_triangle_up_down[2].y, osxy_triangle_up_down[2].z);
            gl.End();



            gl.Color(0.0f, 1.0f, 1.0f);
            for (int i = osxy_triangle_up_down.Count - 1; i > 0; i--)
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Vertex(osxy_triangle_up_down[i].x, -osxy_triangle_up_down[i].y, osxy_triangle_up_down[i].z);
                gl.Vertex(osxy_triangle_up_down[i].x, -osxy_triangle_up_down[i].y, osxy_triangle_up_down[i].z - 5);
                gl.Vertex(osxy_triangle_up_down[i - 1].x, -osxy_triangle_up_down[i - 1].y, osxy_triangle_up_down[i - 1].z - 5);
                gl.Vertex(osxy_triangle_up_down[i - 1].x, -osxy_triangle_up_down[i - 1].y, osxy_triangle_up_down[i - 1].z);
                gl.End();
            }
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Vertex(osxy_triangle_up_down[0].x, -osxy_triangle_up_down[0].y, osxy_triangle_up_down[0].z);
            gl.Vertex(osxy_triangle_up_down[0].x, -osxy_triangle_up_down[0].y, osxy_triangle_up_down[0].z - 5);
            gl.Vertex(osxy_triangle_up_down[2].x, -osxy_triangle_up_down[2].y, osxy_triangle_up_down[2].z - 5);
            gl.Vertex(osxy_triangle_up_down[2].x, -osxy_triangle_up_down[2].y, osxy_triangle_up_down[2].z);
            gl.End();
            // gl.End();
            gl.Begin(OpenGL.GL_POLYGON);
            foreach (Osxy osxy in osxy_triangle_left_rigth)
            {
                gl.Vertex(osxy.x, osxy.y, osxy.z);
            }

            gl.End();

            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1.0f, 1.0f, 0.0f);
            foreach (Osxy osxy in osxy_triangle_left_rigth)
            {
               gl.Vertex(-osxy.x, osxy.y, osxy.z);
            }
            gl.End();

            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1.0f, 0.0f, 0.0f);
            foreach (Osxy osxy in osxy_triangle_left_rigth)
            {
                gl.Vertex(osxy.x, osxy.y, osxy.z - 5);
            }

            gl.End();

            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1.0f, 0.0f, 0.0f);
            foreach (Osxy osxy in osxy_triangle_left_rigth)
            {
                gl.Vertex(-osxy.x, osxy.y, osxy.z - 5);
            }

            gl.End();

            gl.Color(0.0f, 1.0f, 1.0f);
            for (int i = osxy_triangle_left_rigth.Count - 1; i > 0; i--)
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Vertex(-osxy_triangle_left_rigth[i].x, osxy_triangle_left_rigth[i].y, osxy_triangle_left_rigth[i].z);
                gl.Vertex(-osxy_triangle_left_rigth[i].x, osxy_triangle_left_rigth[i].y, osxy_triangle_left_rigth[i].z - 5);
                gl.Vertex(-osxy_triangle_left_rigth[i - 1].x, osxy_triangle_left_rigth[i - 1].y, osxy_triangle_left_rigth[i - 1].z - 5);
                gl.Vertex(-osxy_triangle_left_rigth[i - 1].x, osxy_triangle_left_rigth[i - 1].y, osxy_triangle_left_rigth[i - 1].z);
                gl.End();
            }
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Vertex(-osxy_triangle_left_rigth[0].x, osxy_triangle_left_rigth[0].y, osxy_triangle_left_rigth[0].z);
            gl.Vertex(-osxy_triangle_left_rigth[0].x, osxy_triangle_left_rigth[0].y, osxy_triangle_left_rigth[0].z - 5);
            gl.Vertex(-osxy_triangle_left_rigth[2].x, osxy_triangle_left_rigth[2].y, osxy_triangle_left_rigth[2].z - 5);
            gl.Vertex(-osxy_triangle_left_rigth[2].x, osxy_triangle_left_rigth[2].y, osxy_triangle_left_rigth[2].z);
            gl.End();



            gl.Color(0.0f, 1.0f, 1.0f);
            for (int i = osxy_triangle_left_rigth.Count - 1; i > 0; i--)
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Vertex(osxy_triangle_left_rigth[i].x, osxy_triangle_left_rigth[i].y, osxy_triangle_left_rigth[i].z);
                gl.Vertex(osxy_triangle_left_rigth[i].x, osxy_triangle_left_rigth[i].y, osxy_triangle_left_rigth[i].z - 5);
                gl.Vertex(osxy_triangle_left_rigth[i - 1].x, osxy_triangle_left_rigth[i - 1].y, osxy_triangle_left_rigth[i - 1].z - 5);
                gl.Vertex(osxy_triangle_left_rigth[i - 1].x, osxy_triangle_left_rigth[i - 1].y, osxy_triangle_left_rigth[i - 1].z);
                gl.End();
            }
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Vertex(osxy_triangle_left_rigth[0].x, osxy_triangle_left_rigth[0].y, osxy_triangle_left_rigth[0].z);
            gl.Vertex(osxy_triangle_left_rigth[0].x, osxy_triangle_left_rigth[0].y, osxy_triangle_left_rigth[0].z - 5);
            gl.Vertex(osxy_triangle_left_rigth[2].x, osxy_triangle_left_rigth[2].y, osxy_triangle_left_rigth[2].z - 5);
            gl.Vertex(osxy_triangle_left_rigth[2].x, osxy_triangle_left_rigth[2].y, osxy_triangle_left_rigth[2].z);
            gl.End();

            gl.PopMatrix();


             }

    }
}
   