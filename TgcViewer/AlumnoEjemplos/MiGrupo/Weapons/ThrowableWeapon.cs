using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TgcViewer;

namespace AlumnoEjemplos.MiGrupo.Weapons
{
    class ThrowableWeapon:Weapon
    {
        private int animationTime = 0;

        public override void update()
        {
            //ACA DEBERIA IR LA ANIMACION DEL lanzamiento, POR LO QUE DEBERIA DE TENER UN INDICADOR DEL TIEMPO EN EL Q ESTA DE LA ANIMACION
            //return new Colisionable();
        }
        public override List<Colisionable> doAction()
        {
            List<Colisionable> tmpList = new List<Colisionable>();
            RealColisionable tmpColisionable = new RealColisionable(GuiController.Instance.CurrentCamera.getPosition(), this.weaponDrawing.clone());
            tmpColisionable.setSpeed((float)GuiController.Instance.Modifiers["speed"]);
            tmpColisionable.direction = (GuiController.Instance.CurrentCamera.getLookAt() - GuiController.Instance.CurrentCamera.getPosition());
            tmpColisionable.direction.Normalize();//Si se quita la normalizacion al movernos sin cambiar a donde mira la camara surgue un bug en el cual las bolas se mueven a super velocidad.
            tmpColisionable.direction.Multiply(tmpColisionable.getSpeed());
            tmpList.Add(tmpColisionable);
            return tmpList;
        }
    }
}
