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
            //GL.Rotate(20, 1, 1, 0);
            GL.Rotate(rotationX, 1, 0, 0);
            GL.Rotate(rotationY, 0, 1, 0);
            PrimitiveType primitiveType = PrimitiveType.Quads;
            GL.Begin(primitiveType);
            //GL.Color4(Color4.Aqua);
            GL.Color3(0, 0.0, 0.0);//black DERECHA
            GL.Vertex3(10, 10, -2);
            GL.Vertex3(10, 10, 2);
            GL.Vertex3(10, -10, 2);
            GL.Vertex3(10, -10, -2);
            GL.Color3(0, 0.0, 0.0);//black IZQUIERDA
            GL.Vertex3(-10, -10, -2);
            GL.Vertex3(-10, 10, -2);
            GL.Vertex3(-10, 10, 2);
            GL.Vertex3(-10, -10, 2);
            GL.Color3(1, 1.0, 0.0);//amarillo ABAJO
            GL.Vertex3(10, -10, -2);
            GL.Vertex3(-10, -10, -2);
            GL.Vertex3(-10, -10, 2);
            GL.Vertex3(10, -10, 2);
            GL.Color3(1, 1.0, 0.0);//amarillo ARRIBA
            GL.Vertex3(10, 10, -2);
            GL.Vertex3(-10, 10, -2);
            GL.Vertex3(-10, 10, 2);
            GL.Vertex3(10, 10, 2);
            GL.Color3(0, 0, 1f);//blue frente
            GL.Vertex3(10, 10, 2);
            GL.Vertex3(-10, 10, 2);
            GL.Vertex3(-10, -10, 2);
            GL.Color3(0, 0.0, 0.0);
            GL.Vertex3(10, -10, 2);
            GL.Color3(0, 0, 1.0);//blue atras
            GL.Vertex3(10, 10, -2);
            GL.Vertex3(-10, 10, -2);
            GL.Vertex3(-10,-10, -2);
            GL.Vertex3(10, -10, -2);
            GL.Color3(0, 1.0, 0.0);//verde PARLANTE IZQUIERDO FRENTE
            GL.Vertex3(-10, -10, 2);
            GL.Vertex3(-10, -12, 2);
            GL.Vertex3(-1, -12, 2);            
            GL.Vertex3(-1, -10, 2);
            GL.Color3(0, 1.0, 0.0);//verde PARLANTE IZQUIERDO DERECHA
            GL.Vertex3(-10, -10, 2);
            GL.Vertex3(-10, -12, 2);
            GL.Vertex3(-10, -12, -2);
            GL.Vertex3(-10, -10, -2);
            GL.Color3(0, 1.0, 0.0);//verde PARLANTE IZQUIERDO ATRAS
            GL.Vertex3(-10, -10, -2);
            GL.Vertex3(-10, -12, -2);
            GL.Vertex3(-1, -12, -2);
            GL.Vertex3(-1, -10, -2);
            GL.Color3(0, 1.0, 0.0);//verde PARLANTE DERECHA FRENTE
            GL.Vertex3(10, -10, 2);
            GL.Vertex3(10, -12, 2);
            GL.Vertex3(1, -12, 2);
            GL.Vertex3(1, -10, 2);
            GL.Color3(0, 1.0, 0.0);//verde PARLANTE DERECHA DERECHA
            GL.Vertex3(10, -10, 2);
            GL.Vertex3(10, -12, 2);
            GL.Vertex3(10, -12, -2);
            GL.Vertex3(10, -10, -2);
            GL.Color3(0, 1.0, 0.0);//verde PARLANTE DERECHA ATRAS
            GL.Vertex3(10, -10, -2);
            GL.Vertex3(10, -12, -2);
            GL.Vertex3(1, -12, -2);
            GL.Vertex3(1, -10, -2);
            GL.Color3(0, 0.0, 0.0);//BLACK SOPORTE FRENTE
            GL.Vertex3(-0.5f, -10, 2);
            GL.Vertex3(-2, -18, 2);
            GL.Vertex3(2, -18, 2);
            GL.Vertex3(0.5, -10, 2);
            GL.Color3(0, 0.0, 0.0);//BLACK SOPORTE DERECHA
            GL.Vertex3(-0.5f, -10, 2);
            GL.Vertex3(-2, -18, 2);
            GL.Vertex3(-2, -18, -2);
            GL.Vertex3(-0.5, -10, -2);
            GL.Color3(0, 0.0, 0.0);//BLACK SOPORTE izquierda
            GL.Vertex3(0.5f, -10, 2);
            GL.Vertex3(2, -18, 2);
            GL.Vertex3(2, -18, -2);
            GL.Vertex3(0.5, -10, -2);
            GL.Color3(0, 0.0, 0.0);//BLACK SOPORTE ATRAS
            GL.Vertex3(-0.5f, -10, -2);
            GL.Vertex3(-2, -18, -2);
            GL.Vertex3(2, -18, -2);
            GL.Vertex3(0.5, -10, -2);
            GL.End();

            //-------------------------------------------------------------
            
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Key.Escape))
            {
                Exit();
                return;
            }
            //if (keyboardState.IsKeyDown(Keys.S))
            //{
            //    Escena.Scale(new Punto(sx+1, sy+1, sz+1));
            //}
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
            //GL.Frustum(-80, 80, -80, 80, 4, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            base.OnResize(e);
        }



    }
}

