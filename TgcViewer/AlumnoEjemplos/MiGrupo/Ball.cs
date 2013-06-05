using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TgcViewer.Utils.TgcGeometry;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using TgcViewer;

namespace AlumnoEjemplos.MiGrupo
{
    class Ball : Drawable
    {
        private float radio;
        List<CustomVertex.PositionColored> ballVertexs;
        private int triangleCount;

        public override Drawable clone() {
            return new Ball(ballVertexs);
        }

        public Ball(List<CustomVertex.PositionColored> ballVertexs)
        {
            this.ballVertexs = ballVertexs;
            triangleCount = ballVertexs.Count / 3;
        }

        public Ball(float radio, UInt32 detail) {
            ballVertexs = new List<CustomVertex.PositionColored>();
            this.radio = radio;
            float step = (float)Math.PI / detail;
            Random rand = new Random();
            for (float i = 0; i < Math.PI * 2; i += step)
            {

                ballVertexs.Add(new CustomVertex.PositionColored(getX(0, 0), getY(0, 0), getZ(0, 0), rand.Next(65000)));
                ballVertexs.Add(new CustomVertex.PositionColored(getX(i, step), getY(i, step), getZ(i, step), 0));
                ballVertexs.Add(new CustomVertex.PositionColored(getX(i + step, step), getY(i + step, step), getZ(i + step, step), 0));

                for (float e = step; e < Math.PI - step; e += step)
                {
                    ballVertexs.Add(new CustomVertex.PositionColored(getX(i, e), getY(i, e), getZ(i, e), rand.Next(65000)));
                    ballVertexs.Add(new CustomVertex.PositionColored(getX(i, e + step), getY(i, e + step), getZ(i, e + step), 0));
                    ballVertexs.Add(new CustomVertex.PositionColored(getX(i + step, e), getY(i + step, e), getZ(i + step, e), 0));

                    ballVertexs.Add(new CustomVertex.PositionColored(getX(i + step, e), getY(i + step, e), getZ(i + step, e), rand.Next(65000)));
                    ballVertexs.Add(new CustomVertex.PositionColored(getX(i + step, e + step), getY(i + step, e + step), getZ(i + step, e + step), 0));
                    ballVertexs.Add(new CustomVertex.PositionColored(getX(i, e + step), getY(i, e + step), getZ(i, e + step), 0));
                }

                float aux = (float)Math.PI - step;

                ballVertexs.Add(new CustomVertex.PositionColored(getX(i, aux), getY(i, aux), getZ(i, aux), 0));
                ballVertexs.Add(new CustomVertex.PositionColored(getX(i + step, aux), getY(i + step, aux), getZ(i + step, aux), 0));
                ballVertexs.Add(new CustomVertex.PositionColored(getX(0, (float)Math.PI), getY(0, (float)Math.PI), getZ(0, (float)Math.PI), rand.Next(65000)));
            }
            triangleCount = ballVertexs.Count / 3;
        }

        private float getX(float i, float e){ return (float)(radio * Math.Cos(i) * Math.Sin(e)); }
        private float getY(float i, float e) { return (float)(radio * Math.Sin(i) * Math.Sin(e)); }
        private float getZ(float i, float e){ return (float)(radio * Math.Cos(e)); }

        public override void renderReal()
        {
            Device d3dDevice = GuiController.Instance.D3dDevice;
            d3dDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleCount, ballVertexs.ToArray());
        }

        public override float getRadiusSize() {
            return radio;
        }
    }
}
