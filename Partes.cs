using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Game2;

namespace Game2
{
    
    public class Partes
    {
        
        private Dictionary<String, Poligono> poligonos { get; set; }
        public Punto Center { get; set; }
        public Partes(float x, float y, float z)
        {
            this.poligonos = new Dictionary<String, Poligono>();
            this.Center = new Punto(x, y, z);
            SetCenter(this.Center);
        }
        public void addPoligono(String descripcion, Poligono poligono) //Agrega Parte de Objeto
        {
            poligonos.Add(descripcion, poligono);
        }
        public void SetCenter(Punto newCenter)
        {
            Center = newCenter;
            foreach (var face in poligonos)
                face.Value.Center = Center;
        }
        public void draw(Punto centro)
        {
            if (this.poligonos.Count != 0)
            {
                foreach (var cara in this.poligonos)
                {
                    cara.Value.Draw(centro);
                }
            }
        }
        public void Rotate(float angleX, float angleY, float angleZ)
        {
            foreach (var face in poligonos)
                face.Value.Rotate(angleX, angleY, angleZ);
        }
        public void SetRotation(float angleX, float angleY, float angleZ)
        {
            foreach (var face in poligonos)
                face.Value.SetRotation(angleX, angleY, angleZ);
        }
        public void Traslate(Punto position)
        {
            foreach (var partes in poligonos)
                partes.Value.Traslate(position);
        }
        public void SetTraslation(Punto position)
        {
            foreach (var face in poligonos)
                face.Value.SetTraslation(position);
        }
        public void Scale(float x, float y, float z)
        {
            foreach (var face in poligonos)
                face.Value.Scale(x, y, z);
        }

        public void Scale(Punto position)
        {
            foreach (var face in poligonos)
                face.Value.Scale(position);
        }

        public void SetScale(float x, float y, float z)
        {
            foreach (var face in poligonos)
                face.Value.SetScale(x, y, z);
        }

        public void SetScale(Punto position)
        {
            foreach (var face in poligonos)
                face.Value.SetScale(position);
        }
    }
}
