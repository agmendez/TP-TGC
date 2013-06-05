using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlumnoEjemplos.MiGrupo;
using Microsoft.DirectX;

namespace AlumnoEjemplos.MiGrupo.BulletsAdons
{
    abstract class BulletAddon: Colisionable
    {
        private Colisionable decoratedBullet;

        public void addonForBullet(Colisionable bullet)
        {
            decoratedBullet = bullet;
        }

        override public Colisionable setSpeed(float speed){
            return this.decoratedBullet.setSpeed(speed);
        }

        override public float getSpeed(){
            return this.decoratedBullet.getSpeed();
        }

        override public void moverPelota(Vector3 newPosition)
        {
            this.decoratedBullet.moverPelota(newPosition);
        }

        override public void tirarPelota(Vector3 newPosition)
        {
            this.decoratedBullet.tirarPelota(newPosition);
        }

        override public bool update(float time)
        {
            return this.decoratedBullet.update(time);
        }

        override public Colisionable setDrawing(Drawable drawing) {
            return this.decoratedBullet.setDrawing(drawing);
        }

        override public void render()
        {
            this.decoratedBullet.render();
        }
    }
}
