using System;
using System.Collections.Generic;
using System.Text;
using TgcViewer.Example;
using TgcViewer;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using Microsoft.DirectX;
using TgcViewer.Utils.Modifiers;

namespace AlumnoEjemplos.MiGrupo
{
    class Wall
    {
        List<CustomVertex.PositionColored> pared = new List<CustomVertex.PositionColored>();        

    private void updateWall()
    {
    }

    public Wall(int cantPuntosX, int cantPuntosY)
    {
        //agregar elementos
        float step = 0.1F;
        int x, y;
        Random rand = new Random();
        for (y = 0; y < cantPuntosY; y++) 
        {
            for (x = 0; x < cantPuntosX; x++)
            {
                pared.Add(new CustomVertex.PositionColored(x * step, y * step, 0, x+y));
                pared.Add(new CustomVertex.PositionColored(x * step, (y * step) + step, 0, x+y+1));
            }
            y++;
            for (x = cantPuntosX-1; x >= 0; x--)
            {
                pared.Add(new CustomVertex.PositionColored(x * step, y * step, 0, x+y));
                pared.Add(new CustomVertex.PositionColored(x * step, (y * step) + step, 0, x+y+1));
            }       
        }
    }

    public void render()
    {
        Device d3dDevice = GuiController.Instance.D3dDevice;
        d3dDevice.DrawUserPrimitives(PrimitiveType.TriangleStrip, getTriangleCount(), pared.ToArray());
    }

    private int getTriangleCount()
    {       
        return pared.Count - 2;        
    }



    public void close()
    {
        //pelota.dispose();
    }


    }
}

