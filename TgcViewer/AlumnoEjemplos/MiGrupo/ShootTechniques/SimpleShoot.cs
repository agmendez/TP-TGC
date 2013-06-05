using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TgcViewer;

namespace AlumnoEjemplos.MiGrupo
{
    class SimpleShoot : ShootTechnique
    {
        public override List<Colisionable> getShoot()
        {
            List<Colisionable> tmpList = new List<Colisionable>();
            RealColisionable tmpColisionable = new RealColisionable(GuiController.Instance.CurrentCamera.getPosition(), bulletDrawing.clone());
            tmpColisionable.setSpeed((float)GuiController.Instance.Modifiers["speed"]);
            tmpColisionable.direction = (GuiController.Instance.CurrentCamera.getLookAt() - GuiController.Instance.CurrentCamera.getPosition());
            tmpColisionable.direction.Normalize();//Si se quita la normalizacion al movernos sin cambiar a donde mira la camara surgue un bug en el cual las bolas se mueven a super velocidad.
            tmpColisionable.direction.Multiply(tmpColisionable.getSpeed());
            tmpList.Add(tmpColisionable);
            return tmpList;
        }
        public override string ToString()
        {
            return "Simple Shoot";
        }
    }
}
