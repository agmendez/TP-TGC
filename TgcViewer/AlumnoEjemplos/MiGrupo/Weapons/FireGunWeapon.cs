using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlumnoEjemplos.MiGrupo;


namespace AlumnoEjemplos.MiGrupo.Weapons
{
    class FireGunWeapon:Weapon
    {
        public ShootTechnique technique = new SimpleShoot();//Por default dispara una sola bala por vez

        public FireGunWeapon(Drawable weaponDrawing)
        {
            this.weaponDrawing = weaponDrawing;
        }

        public FireGunWeapon setShootTechnique(ShootTechnique technique)
        {
            this.technique = technique;
            return this;
        }

        public override List<Colisionable> doAction() {
            return technique.getShoot();
        }
    }
}