using OpenTK;
using System;

namespace Game2
{
    [Serializable]
    public class Punto
    {
        //atributos
        
        private float ejeX { get; set; }
        
        private float ejeY { get; set; }
        private float ejeZ { get; set; }
        //properties
        public float x { get { return ejeX; } set { ejeX = value; } }
        public float y { get { return ejeY; } set { ejeY = value; } }
        public float z { get { return ejeZ; } set { ejeZ = value; } }


        //contructor con parametros---------------------------------------------------------
        public Punto(float x, float y, float z)
        {
            this.ejeX = x;
            this.ejeY = y;
            this.ejeZ = z;
        }
        //-----------------------------------------------------------------------------------------------------------------
        public Punto() : this(0, 0, 0) { }

        //-----------------------------------------------------------------------------------------------------------------
        //Contructor copia
        public Punto(Punto p)
        {
            this.ejeX = p.ejeX;
            this.ejeY = p.ejeY;
            this.ejeZ = p.ejeZ;
        }
        //-----------------------------------------------------------------------------------------------------------------
        //Contructor con el mismo valor inicial 
        public Punto(float valor)
        {
            this.ejeX = this.ejeY = this.ejeZ = valor;
        }
        //-----------------------------------------------------------------------------------------------------------------
        public Vector3 ToVector3()
        {
            return new Vector3(this.ejeX, this.ejeY, this.ejeZ);
        }
        //-----------------------------------------------------------------------------------------------------------------
        public void acumular(Punto p)
        {
            this.ejeX += p.x;
            this.ejeY += p.y;
            this.ejeZ += p.z;
        }
        public void acumular(float x, float y, float z)
        {
            this.ejeX += x;
            this.ejeY += y;
            this.ejeZ += z;
        }
        public void multiplicar(float x, float y, float z)
        {
            this.ejeX *= x;
            this.ejeY *= y;
            this.ejeZ *= z;
        }
        public void setPunto(float valor)
        {
            this.ejeX = this.ejeY = this.ejeZ = valor;
        }
        //-----------------------------------------------------------------------------------------------------------------
        public bool compareTo(Punto a)
        {
            return (this.ejeX == a.ejeX && this.ejeY == a.ejeY && this.ejeZ == a.ejeZ);
        }
        public override string ToString() => $"({ejeX}|{ejeY}|{ejeZ})";

        public static Punto operator +(Punto a, Punto b)
        {
            Punto nuevo = new Punto();
            nuevo.x = a.x + b.x;
            nuevo.y = a.y + b.y;
            nuevo.z = a.z + b.z;
            return nuevo;
        }
        //public static Punto operator *(Punto a, Matrix3 b)
        //{
        //    Punto nuevo = new Punto();
        //    nuevo.x = a.ejeX * b.M11 + a.ejeY * b.M21 + a.ejeZ * b.M31;
        //    nuevo.y = a.ejeX * b.M12 + a.ejeY * b.M22 + a.ejeZ * b.M32;
        //    nuevo.z = a.ejeX * b.M13 + a.ejeY * b.M23 + a.ejeZ * b.M33;
        //    return nuevo;
        //}
        public static Punto operator *(Punto a, Matrix3 b) => new Punto(
            a.x * b.M11 + a.y * b.M21 + a.z * b.M31, a.x * b.M12 + a.y * b.M22 + a.z * b.M32,
            a.x * b.M13 + a.y * b.M23 + a.z * b.M33
        );
        public static implicit operator Vector3(Punto convert)
        {
            return new Vector3(convert.x, convert.y, convert.z);
        }
    }
}
