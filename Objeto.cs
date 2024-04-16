using System;
using System.Collections.Generic;
using System.IO;

namespace Game2
{
    
    public class Objeto
    {
        
        Dictionary<string, Partes> parte { get; set; }
        
        public Punto center { get; set; }

        public Objeto(Dictionary<string, Partes> parte, Punto centro)
        {
            this.parte = parte;
            this.center = centro;
            SetCenter(this.center);
        }
        public Objeto(float x, float y, float z)
        {
            this.parte = new Dictionary<string, Partes>();
            this.center = new Punto(x, y, z);
            SetCenter(this.center);
        }
        public void addParte(String descripcion, Partes parte)
        {
            this.parte.Add(descripcion, parte);
        }
        public void draw()
        {
            if (this.parte.Count != 0)
            {
                foreach (var parte in this.parte)
                {
                    parte.Value.draw(center);
                }
            }

        }
        public void SetCenter(Punto newCenter)
        {
            center = newCenter;
            foreach (var face in parte)
                face.Value.Center = center;
        }
        //public static Objeto LoadFromJson(string path)
        //{
        //    string outputString = File.ReadAllText(path);
        //    return dt = (Objeto)JsonConvert.DeserializeObject<Objeto>(outputString);
        //}

        //public void LoadFromJson(string path)
        //{
        //    string outputString = File.ReadAllText(@path);
        //    Objeto dt = (Objeto)JsonConvert.DeserializeObject(outputString, typeof(Objeto));
        //    parte = dt.parte;
        //    center = dt.center;
        //    SetCenter(center);
        //}
        //public static Objeto LoadFromJson(string path)
        //{
        //    string outputString = File.ReadAllText(path);
        //    return JsonSerializer.Deserialize<Objeto>(outputString);
        //}

        //public void SaveFile(string path)
        //{
        //    var options = new JsonSerializerOptions
        //    {
        //        WriteIndented = true
        //    };

        //    string jsonOutput = JsonSerializer.Serialize(this, options);

        //    File.WriteAllText(path, jsonOutput);
        //}
        public Punto GetCenter()
        {
            return center;
        }
        public void Rotate(float angleX, float angleY, float angleZ)
        {
            foreach (var face in parte)
                face.Value.Rotate(angleX, angleY, angleZ);
        }
        public void SetRotation(float angleX, float angleY, float angleZ)
        {
            foreach (var face in parte)
                face.Value.SetRotation(angleX, angleY, angleZ);
        }
        public void Traslate(Punto position)
        {
            foreach (var partes in parte)
                partes.Value.Traslate(position);
        }
        public void SetTraslation(Punto position)
        {
            foreach (var face in parte)
                face.Value.SetTraslation(position);
        }
        public void Scale(float x, float y, float z)
        {
            foreach (var face in parte)
                face.Value.Scale(x, y, z);
        }

        public void Scale(Punto position)
        {
            foreach (var face in parte)
                face.Value.Scale(position);
        }

        public void SetScale(float x, float y, float z)
        {
            foreach (var face in parte)
                face.Value.SetScale(x, y, z);
        }

        public void SetScale(Punto position)
        {
            foreach (var face in parte)
                face.Value.SetScale(position);
        }

    }
}
