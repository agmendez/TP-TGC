using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX;
using TgcViewer;

namespace AlumnoEjemplos.MiGrupo.Weapons
{
    abstract class Weapon
    {
        public Drawable weaponDrawing;

        public virtual void render()
        {
            weaponDrawing.render();
        }

        //DEBE SEr IMPLEMETNADO, ONDA INTERFAZZZZ
        public virtual void update()
        {
            Vector3 lookAt = GuiController.Instance.CurrentCamera.getLookAt() - GuiController.Instance.CurrentCamera.getPosition();
            lookAt.Normalize();
            lookAt.Multiply(1.3f);
            //Dibuja ligeramente desplazado hacia abajo
            weaponDrawing.setPosition(GuiController.Instance.CurrentCamera.getPosition() + lookAt + new Vector3(0, -0.2f, 0));
        }

        public abstract List<Colisionable> doAction();
    }
}
