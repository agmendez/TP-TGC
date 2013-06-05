using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TgcViewer;
using Microsoft.DirectX;

namespace AlumnoEjemplos.MiGrupo
{
    class ShootgunShoot : ShootTechnique
    {
        public int bulletsAmount = 15;
        public override List<Colisionable> getShoot()
        {
            List<Colisionable> tmpList = new List<Colisionable>();
            Random rand = new Random();
            for (int i = 0; i < bulletsAmount; i++) {
                RealColisionable tmpBullet = new RealColisionable(GuiController.Instance.CurrentCamera.getPosition(), bulletDrawing.clone());
                tmpBullet.setSpeed((float)GuiController.Instance.Modifiers["speed"]);
                tmpBullet.direction = (GuiController.Instance.CurrentCamera.getLookAt() - GuiController.Instance.CurrentCamera.getPosition());
                tmpBullet.direction.Add(new Vector3((-1 + (float)rand.NextDouble() * 2) / 5, (-1 + (float)rand.NextDouble() * 2) / 5, (-1 + (float)rand.NextDouble() * 2) / 5));
                tmpBullet.direction.Normalize();//Si se quita la normalizacion al movernos sin cambiar a donde mira la camara surgue un bug en el cual las bolas se mueven a super velocidad.
                tmpBullet.direction.Multiply(tmpBullet.getSpeed());
                tmpList.Add(tmpBullet);
            }
            return tmpList;
        }

        public override string ToString() {
            return "Shotgun Shoot";
        }
    }
}
