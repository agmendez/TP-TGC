using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlumnoEjemplos.MiGrupo
{
    abstract class ShootTechnique
    {
        public Drawable bulletDrawing= new Ball(0.1f,10);
        public abstract List<Colisionable> getShoot();
    }
}
