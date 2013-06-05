using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TgcViewer.Utils.TgcSceneLoader;

namespace AlumnoEjemplos.MiGrupo
{
    class Gun : Drawable
    {
        TgcScene currentScene;
        public Gun(String path){
            //Aca se carga el arma !
        }

        public override float getRadiusSize() {
            return 0;
        }
        public override Drawable clone() {
            return new Gun(currentScene.FilePath);
        }
        public override void renderReal() {
            currentScene.renderAll();
        }

    }
}
