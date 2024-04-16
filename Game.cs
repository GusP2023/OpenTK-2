using Game2;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    public class Game : GameWindow
    {
        private float rotationX = 10;
        private float rotationY = 10;
        private float lastX;
        private float lastY;
        private bool mouseDown;
        private float ancho=10;
        private float alto=10;
        private float profundidad = 10;
        public Vector3 origen= new Vector3(0,0,0);
        public Escenario escenario;
        public Color4 c;
        //public Televisor TV,TV2;


        //-----------------------------------------------------------------------------------------------------------------
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.5f,0f,0f,0f);
            //TV = new Televisor(new Vector3(0,0,0), 10);
            //TV2 = new Televisor(new Vector3(-15, -15, 0), 7);
            escenario = new Escenario(new Punto(0,0,0));
            Poligono pantalla = new Poligono(Color4.Black, PrimitiveType.Polygon, new Punto(0, 0, 0));
            //c = Color4.Black;//black DERECHA
            pantalla.AddVertice("pantallav1",new Punto(origen.X + ancho, origen.Y + alto, origen.Z - profundidad * 0.2f));
            pantalla.AddVertice("pantallav2", new Punto(origen.X + ancho, origen.Y + alto, origen.Z + profundidad * 0.2f));
            pantalla.AddVertice("pantallav3", new Punto(origen.X + ancho, origen.Y - alto, origen.Z + profundidad * 0.2f));
            pantalla.AddVertice("pantallav4", new Punto(origen.X + ancho, origen.Y - alto, origen.Z - profundidad * 0.2f));
            //c = Color4.Blue;//blue frente
            pantalla.AddVertice("pantallav5", new Punto(origen.X + ancho, origen.Y + alto, origen.Z + profundidad * 0.2f));
            pantalla.AddVertice("pantallav6", new Punto(origen.X - ancho, origen.Y + alto, origen.Z + profundidad * 0.2f));
            pantalla.AddVertice("pantallav7", new Punto(origen.X - ancho, origen.Y - alto, origen.Z + profundidad * 0.2f));
            //c = Color4.Black;
            pantalla.AddVertice("pantallav8", new Punto(origen.X + ancho, origen.Y - alto, origen.Z + profundidad * 0.2f));
            //c = Color4.Black;//black IZQUIERDA
            pantalla.AddVertice("pantallav9", new Punto(origen.X - ancho, origen.Y - alto, origen.Z - profundidad * 0.2f));
            pantalla.AddVertice("pantallav10", new Punto(origen.X - ancho, origen.Y + alto, origen.Z - profundidad * 0.2f));
            pantalla.AddVertice("pantallav11", new Punto(origen.X - ancho, origen.Y + alto, origen.Z + profundidad * 0.2f));
            pantalla.AddVertice("pantallav12", new Punto(origen.X - ancho, origen.Y - alto, origen.Z + profundidad * 0.2f));
            //c = Color4.Yellow;//amarillo ABAJO
            pantalla.AddVertice("pantallav13", new Punto(origen.X + ancho, origen.Y - alto, origen.Z - profundidad * 0.2f));
            pantalla.AddVertice("pantallav14", new Punto(origen.X - ancho, origen.Y - alto, origen.Z - profundidad * 0.2f));
            pantalla.AddVertice("pantallav15", new Punto(origen.X - ancho, origen.Y - alto, origen.Z + profundidad * 0.2f));
            pantalla.AddVertice("pantallav16", new Punto(origen.X + ancho, origen.Y - alto, origen.Z + profundidad * 0.2f));
            //c = Color4.Blue;//blue atras
            pantalla.AddVertice("pantallav17", new Punto(origen.X + ancho, origen.Y + alto, origen.Z - profundidad * 0.2f));
            pantalla.AddVertice("pantallav18", new Punto(origen.X - ancho, origen.Y + alto, origen.Z - profundidad * 0.2f));
            pantalla.AddVertice("pantallav19", new Punto(origen.X - ancho, origen.Y - alto, origen.Z - profundidad * 0.2f));
            pantalla.AddVertice("pantallav20", new Punto(origen.X + ancho, origen.Y - alto, origen.Z - profundidad * 0.2f));
            //c=Color4.Yellow;//amarillo ARRIBA
            pantalla.AddVertice("pantallav21", new Punto(origen.X + ancho, origen.Y + alto, origen.Z - profundidad * 0.2f));
            pantalla.AddVertice("pantallav22", new Punto(origen.X - ancho, origen.Y + alto, origen.Z - profundidad * 0.2f));
            pantalla.AddVertice("pantallav23", new Punto(origen.X - ancho, origen.Y + alto, origen.Z + profundidad * 0.2f));
            pantalla.AddVertice("pantallav24", new Punto(origen.X + ancho, origen.Y + alto, origen.Z + profundidad * 0.2f));
            Partes pantallaP = new Partes(0,0,0);
            pantallaP.addPoligono("pantalla", pantalla);
            Objeto pantallaO = new Objeto(0, 0, 0);
            pantallaO.addParte("pantalla", pantallaP);
            escenario.addObjeto("Televisor", pantallaO);
            base.OnLoad(e); 
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(VertexBufferObject);
            base.OnUnload(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.LoadIdentity();
            //--------------------------------------------------------------            
            //TV.rotar(rotationX, rotationY);            
            //TV.dibujar();
            //TV2.dibujar();
            escenario.rotate(rotationX, rotationY);
            escenario.draw();
            //-------------------------------------------------------------

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Key.Escape))
            {
                Exit();
                return;
            }

            //------------------------------------------------------------------------------------
            MouseMove += (sender, args) =>
            {
                if (mouseDown)
                {
                    float deltaX = args.X - lastX;
                    float deltaY = args.Y - lastY;

                    rotationX += deltaY * 0.2f;
                    rotationY += deltaX * 0.2f;
                }
                lastX = args.X;
                lastY = args.Y;
            };

            MouseDown += (sender, args) =>
            {
                if (args.Button == MouseButton.Left)
                {
                    mouseDown = true;
                }
            };

            MouseUp += (sender, args) =>
            {
                if (args.Button == MouseButton.Left)
                {
                    mouseDown = false;
                }
            };
            //----------------------------------------------------------------------------------
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }
        //-----------------------------------------------------------------------------------------------------------------
        protected override void OnResize(EventArgs e)
        {
            float d = 30;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-d, d, -d, d, -d, d);
            //GL.Frustum(-d, d, -d, d,2, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            base.OnResize(e);
        }



    }
}

