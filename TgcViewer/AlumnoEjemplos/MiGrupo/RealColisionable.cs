using System;
using System.Collections.Generic;
using System.Text;
using TgcViewer.Example;
using TgcViewer;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using Microsoft.DirectX;
using TgcViewer.Utils.Modifiers;
using TgcViewer.Utils.TgcGeometry;


namespace AlumnoEjemplos.MiGrupo
{
    class RealColisionable:Colisionable
    {
        public TgcBoundingSphere boundingBall = new TgcBoundingSphere();
        public Vector3 direction, position;
        private Matrix tran = new Matrix();
        private float speed = 25;
        public bool renderBoundingSphere = false;
        public double lifeTime = 2000;
        private double creationTime;
        private Drawable drawing;

        override public Colisionable setSpeed(float speed){
            //Al setear la velocidad calculamos el tiempo que deberia de existir el objeto colisionable
            this.speed=speed;
            lifeTime = (25000 / speed);
            return this;
        }

        override public float getSpeed(){
            return speed;
        }

        override public void moverPelota(Vector3 newPosition)
        {
            boundingBall.setCenter(newPosition);
        }

        override public void tirarPelota(Vector3 newPosition)
        {
            newPosition.Multiply(0.01F);
            boundingBall.moveCenter(newPosition);
        }

        override public bool update(float time)
        {
            position+= direction * time;
            drawing.setPosition(position);
            boundingBall.moveCenter(position);
            if (System.DateTime.Now.TimeOfDay.TotalMilliseconds - creationTime > lifeTime)
            {
                return true;
            }
            return false;
        }

        public RealColisionable(Vector3 position, Drawable drawing)
        {
            tran = Matrix.Identity;
            this.position = position;
            this.drawing = drawing;
            creationTime = System.DateTime.Now.TimeOfDay.TotalMilliseconds;

            Random rand = new Random();

            boundingBall = new TgcBoundingSphere(new Vector3(0,0,0), drawing.getRadiusSize());
            speed += (float)(rand.NextDouble() * 0.2 * speed);//Cada pelota tendra una velocidad diferente, respecto de la velocidad original puede ser un 20% mas rapida
        }

        override public Colisionable setDrawing(Drawable drawing) {
            this.drawing = drawing;
            return this;
        }

        override public void render()
        {
            if (renderBoundingSphere) {
                boundingBall.render();
            }
            drawing.render();
        }
    }
}

