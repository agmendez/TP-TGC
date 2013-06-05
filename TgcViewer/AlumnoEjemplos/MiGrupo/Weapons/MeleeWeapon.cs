using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;

namespace AlumnoEjemplos.MiGrupo.Weapons
{
    class MeleeWeapon:Weapon
    {
        public override void update()
        {
            //ACA DEBERIA IR LA ANIMACION DEL GOLPE, POR LO QUE DEBERIA DE TENER UN INDICADOR DEL TIEMPO EN EL Q ESTA DE LA ANIMACION
            //return new Colisionable();
        }
        public override List<Colisionable> doAction()
        {
            return new List<Colisionable>();
        }
    }
}
