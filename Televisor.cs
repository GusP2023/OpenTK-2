using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Game2
{
    public class Televisor
    {
        private float ancho;
        private float alto;
        private float profundidad;
        public Vector3 origen;
        public Televisor(Vector3 p, float escala)
        {
            origen = p;
            this.ancho = escala;
            this.alto = escala;
            this.profundidad = escala;
        }
        public void dibujar()
        {
            //GL.Rotate(20, 1, 1, 0);
            PrimitiveType primitiveType = PrimitiveType.Polygon;

            //GL.Color4(Color4.Aqua);
            pantalla(primitiveType);
            parlanteizq(primitiveType);
            parlanteder(primitiveType);
            soporte(primitiveType);

        }
        public void rotar(float rotarX,float rotarY)
        {
            GL.Rotate(rotarX, 1, 0, 0);
            GL.Rotate(rotarY, 0, 1, 0);
        }
        public void pantalla(PrimitiveType primitiveType)
        {            
            GL.Begin(primitiveType);
            GL.Color4(Color4.Black);//black DERECHA
            GL.Vertex3(origen.X + ancho, origen.Y + alto, origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X + ancho, origen.Y + alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.Color3(0, 0.0, 0.0);//black IZQUIERDA
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y + alto, origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y + alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Color3(1, 1.0, 0.0);//amarillo ABAJO
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Color3(1, 1.0, 0.0);//amarillo ARRIBA
            GL.Vertex3(origen.X + ancho, origen.Y + alto, origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y + alto, origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y + alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X + ancho, origen.Y + alto, origen.Z + profundidad * 0.2);
            GL.Color3(0, 0, 1f);//blue frente
            GL.Vertex3(origen.X + ancho, origen.Y + alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y + alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Color3(0, 0.0, 0.0);
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Color3(0, 0, 1.0);//blue atras
            GL.Vertex3(origen.X + ancho, origen.Y + alto, origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y + alto, origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.End();
        }
        public void parlanteizq(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(0, 1.0, 0.0);//verde PARLANTE IZQUIERDO FRENTE
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y - alto - (alto * 0.2), origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X - ancho / 10, origen.Y - alto - (alto * 0.2), origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X - ancho / 10, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Color3(0, 1.0, 0.0);//verde PARLANTE IZQUIERDO IZQUIERDA
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y - alto - (alto * 0.2), origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y - alto - (alto * 0.2), origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.Color3(0, 1.0, 0.0);//verde PARLANTE IZQUIERDO ATRAS
            GL.Vertex3(origen.X - ancho, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho, origen.Y - alto - (alto * 0.2), origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho / 10, origen.Y - alto - (alto * 0.2), origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho / 10, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.End();
        }
        public void parlanteder(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(0, 1.0, 0.0);//verde PARLANTE DERECHA FRENTE
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X + ancho, origen.Y - alto - (alto * 0.2), origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X + ancho / 10, origen.Y - alto - (alto * 0.2), origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X + ancho / 10, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Color3(0, 1.0, 0.0);//verde PARLANTE DERECHA DERECHA
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X + ancho, origen.Y - alto - (alto * 0.2), origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X + ancho, origen.Y - alto - (alto * 0.2), origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.Color3(0, 1.0, 0.0);//verde PARLANTE DERECHA ATRAS
            GL.Vertex3(origen.X + ancho, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X + ancho, origen.Y - alto - (alto * 0.2), origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X + ancho / 10, origen.Y - alto - (alto * 0.2), origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X + ancho / 10, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.End();
        }

        public void soporte(PrimitiveType primitiveType)
        {
            GL.Begin(primitiveType);
            GL.Color3(0, 0.0, 0.0);//BLACK SOPORTE FRENTE
            GL.Vertex3(origen.X - ancho * 0.05, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X - ancho * 0.2, origen.Y - alto * 2 + (alto * 0.2), origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X + ancho * 0.2, origen.Y - alto * 2 + (alto * 0.2), origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X + ancho * 0.05, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Color3(0, 0.0, 0.0);//BLACK SOPORTE DERECHA
            GL.Vertex3(origen.X - ancho * 0.05, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X - ancho * 0.2, origen.Y - alto * 2 + (alto * 0.2), origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X - ancho * 0.2, origen.Y - alto * 2 + (alto * 0.2), origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho * 0.05, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.Color3(0, 0.0, 0.0);//BLACK SOPORTE izquierda
            GL.Vertex3(origen.X + ancho * 0.05, origen.Y - alto, origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X + ancho * 0.2, origen.Y - alto * 2 + (alto * 0.2), origen.Z + profundidad * 0.2);
            GL.Vertex3(origen.X + ancho * 0.2, origen.Y - alto * 2 + (alto * 0.2), origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X + ancho * 0.05, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.Color3(0, 0.0, 0.0);//BLACK SOPORTE ATRAS
            GL.Vertex3(origen.X - ancho * 0.05, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X - ancho * 0.2, origen.Y - alto * 2 + (alto * 0.2), origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X + ancho * 0.2, origen.Y - alto * 2 + (alto * 0.2), origen.Z - profundidad * 0.2);
            GL.Vertex3(origen.X + ancho * 0.05, origen.Y - alto, origen.Z - profundidad * 0.2);
            GL.End();
        }
    }
}
