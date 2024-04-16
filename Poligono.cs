using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
//using System.Drawing;
using System.Collections.Generic;
using System;

namespace Game2
{
    
    public class Poligono
    {
        
        protected Dictionary<String, Punto> vertices { get; set; }
        
        protected Color4 color { get; set; }
        
        protected PrimitiveType Tipo { get; set; }
        public Punto Translation { get; set; }

        public Matrix3 Rotation { get; set; }

        public Matrix3 Scaling { get; set; }
        public Punto Center { get; set; }

        public Poligono(Color4 color, PrimitiveType tipo, Punto origen)
        {
            vertices = new Dictionary<String, Punto>();
            this.color = color;
            this.Tipo = tipo;
            Center = origen;
            Translation = new Punto(0, 0, 0);
            Rotation = Matrix3.Identity;
            Scaling = Matrix3.Identity;
        }

        public void AddVertice(String descripcion, Punto vertex)
        {
            
            this.vertices.Add(descripcion, vertex);
            
        }

        public void CambiarColor(Color4 color)
        {
            this.color = color;
        }
        public void Draw(Punto centro)
        {

            GL.Begin(Tipo);
            GL.Color4(color);
            
            foreach (var vertex in this.vertices)
            {
                Punto vertexToRender = vertex.Value * Rotation * Scaling;
                vertexToRender += Center + Translation + centro;
                GL.Vertex3(vertexToRender);
            } 
                        
            GL.End();
            GL.Flush();
        }
        public void Rotate(float angleX, float angleY, float angleZ)
        {
            angleX = MathHelper.DegreesToRadians(angleX);
            angleY = MathHelper.DegreesToRadians(angleY);
            angleZ = MathHelper.DegreesToRadians(angleZ);

            Rotation *= Matrix3.CreateRotationX(angleX) * Matrix3.CreateRotationY(angleY) *
                        Matrix3.CreateRotationZ(angleZ);
        }
        public void SetRotation(float angleX, float angleY, float angleZ)
        {
            angleX = MathHelper.DegreesToRadians(angleX);
            angleY = MathHelper.DegreesToRadians(angleY);
            angleZ = MathHelper.DegreesToRadians(angleZ);
            Rotation = Matrix3.CreateRotationX(angleX) * Matrix3.CreateRotationY(angleY) *
                       Matrix3.CreateRotationZ(angleZ);
        }
        public void Traslate(float x, float y, float z)
        {
            Translation = Translation + new Punto(x, y, z);
        }
        public void Traslate(Punto position)
        {
            Translation = Translation + position;
        }
        public void SetTraslation(Punto position)
        {
            Translation = position;
        }
        public void Scale(float x, float y, float z)
        {
            Scaling *= Matrix3.CreateScale(x, y, z);
        }
        public void Scale(Punto scale)
        {
            Scaling *= Matrix3.CreateScale(scale);
        }
        public void SetScale(float x, float y, float z)
        {
            Scaling = Matrix3.CreateScale(x, y, z);
        }

        public void SetScale(Punto scale)
        {
            Scaling = Matrix3.CreateScale(scale);
        }

    }
}
