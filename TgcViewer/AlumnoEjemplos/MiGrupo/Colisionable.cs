using System;
using System.Collections.Generic;
using System.Text;
using TgcViewer.Example;
using TgcViewer;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using Microsoft.DirectX;
using TgcViewer.Utils.Modifiers;
using TgcViewer.Utils.TgcGeometry;


namespace AlumnoEjemplos.MiGrupo
{
    abstract class Colisionable
    {
        abstract public Colisionable setSpeed(float speed);
        abstract public float getSpeed();
        abstract public void moverPelota(Vector3 newPosition);
        abstract public void tirarPelota(Vector3 newPosition);
        abstract public bool update(float time);
        abstract public Colisionable setDrawing(Drawable drawing);
        abstract public void render();
    }
}

