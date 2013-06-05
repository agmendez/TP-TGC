using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using TgcViewer;

namespace AlumnoEjemplos.MiGrupo
{
    abstract class Drawable
    {
        public Vector3 position;
        public Matrix tran = new Matrix();

        public abstract float getRadiusSize();
        public abstract Drawable clone();
        public abstract void renderReal();
        public void render(){
            Device d3dDevice = GuiController.Instance.D3dDevice;
            d3dDevice.Transform.World = tran;
            this.renderReal();
        }
        public void setPosition(Vector3 position){
            this.position = position;
            tran.Translate(position);
        }
    }
}
