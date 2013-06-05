using System;
using System.Collections.Generic;
using System.Text;
using TgcViewer.Example;
using TgcViewer;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using Microsoft.DirectX;
using TgcViewer.Utils.Modifiers;
using TgcViewer.Utils.TgcSceneLoader;
using TgcViewer.Utils.TgcGeometry;
using TgcViewer.Utils.Input;
using Microsoft.DirectX.DirectInput;
using TgcViewer.Utils.TgcSkeletalAnimation;
using TgcViewer.Utils.Terrain;
using System.Windows.Forms;
using AlumnoEjemplos.MiGrupo.Weapons;

namespace AlumnoEjemplos.MiGrupo
{
    /// <summary>
    /// Ejemplo del alumno
    /// </summary>
    public class EjemploAlumno : TgcExample
    {
        /// <summary>
        /// Categoría a la que pertenece el ejemplo.
        /// Influye en donde se va a haber en el árbol de la derecha de la pantalla.
        /// </summary>
        Wall wall;
        FireGunWeapon weapon;
        List<Colisionable> collisionableList = new List<Colisionable>();
        protected Point mouseCenter;

        public override string getCategory()
        {
            return "AlumnoEjemplos";
        }

        /// <summary>
        /// Completar nombre del grupo en formato Grupo NN
        /// </summary>
        public override string getName()
        {
            return "Grupo 99";
        }

        /// <summary>
        /// Completar con la descripción del TP
        /// </summary>
        public override string getDescription()
        {
            return "MiIdea - Descripcion de la idea";
        }

        /// <summary>
        /// Método que se llama una sola vez,  al principio cuando se ejecuta el ejemplo.
        /// Escribir aquí todo el código de inicialización: cargar modelos, texturas, modifiers, uservars, etc.
        /// Borrar todo lo que no haga falta
        /// </summary>
        /// 
        public override void init()
        {
            Control focusWindows = GuiController.Instance.D3dDevice.CreationParameters.FocusWindow;
            mouseCenter = focusWindows.PointToScreen(new Point(focusWindows.Width / 2, focusWindows.Height / 2));

            //GuiController.Instance: acceso principal a todas las herramientas del Framework

            //Device de DirectX para crear primitivas
            Microsoft.DirectX.Direct3D.Device d3dDevice = GuiController.Instance.D3dDevice;

            //Carpeta de archivos Media del alumno
            string alumnoMediaFolder = GuiController.Instance.AlumnoEjemplosMediaDir;


            ///////////////USER VARS//////////////////

            //Crear una UserVar
            GuiController.Instance.UserVars.addVar("variablePrueba");

            //Cargar valor en UserVar
            GuiController.Instance.UserVars.setValue("variablePrueba", 5451);



            ///////////////MODIFIERS//////////////////

            //Crear un modifier para un valor FLOAT
            GuiController.Instance.Modifiers.addFloat("speed", 1f, 100f, 25f);

            //Crear un modifier para un ComboBox con opciones
            //string[] opciones = new string[]{"SimpleShoot", "ShotgunShoot"};
            ShootTechnique[] opciones = new ShootTechnique[] { new SimpleShoot(), new ShootgunShoot() };
            GuiController.Instance.Modifiers.addInterval("valorIntervalo", opciones, 0);

            //Crear un modifier para modificar un vértice
            GuiController.Instance.Modifiers.addVertex3f("valorVertice", new Vector3(-100, -100, -100), new Vector3(50, 50, 50), new Vector3(0, 0, 0));


            ///////////////CONFIGURAR CAMARA PRIMERA PERSONA//////////////////
            //Camara en primera persona, tipo videojuego FPS
            TgcFpsCameraReloaded cam = new TgcFpsCameraReloaded();
            cam.setCamera(new Vector3(0, 0, -20), new Vector3(0, 0, 0));
            GuiController.Instance.CurrentCamera = cam;

            wall = new Wall(100, 100);
            weapon = new FireGunWeapon(new Ball(0.1f, 15));//Las bolas disparadas no tienen porq tener gran detalle
            //weapon = new Weapon(new Gun("C:\\Users\\martin\\Downloads\\3D Models\\Pistol\\Pistol.obj"),new Ball(10,10));
        }



        public override void render(float elapsedTime)
        {
            //Device de DirectX para renderizar
            Microsoft.DirectX.Direct3D.Device d3dDevice = GuiController.Instance.D3dDevice;


            //Obtener valor de UserVar (hay que castear)
            int valor = (int)GuiController.Instance.UserVars.getValue("variablePrueba");


            //Obtener valores de Modifiers
            weapon.technique = (ShootTechnique)GuiController.Instance.Modifiers["valorIntervalo"];
            Vector3 valorVertice = (Vector3)GuiController.Instance.Modifiers["valorVertice"];



            //Capturar Input Mouse
            if (GuiController.Instance.D3dInput.buttonPressed(TgcViewer.Utils.Input.TgcD3dInput.MouseButtons.BUTTON_LEFT))
            {
                collisionableList.AddRange(weapon.doAction());
            }

            List<Colisionable> deleteCollisionable = new List<Colisionable>();

            foreach (Colisionable collisionable in collisionableList)
            {
                if (collisionable.update(elapsedTime))
                {
                    deleteCollisionable.Add(collisionable);
                }
                //GuiController.Instance.Logger.log("Pos de Pelota Nueva: " + collisionable.position.ToString());
            }

            foreach (Colisionable pelota in deleteCollisionable)
            {
                collisionableList.Remove(pelota);
                //GuiController.Instance.Logger.log("Pos de Pelota Nueva: " + pelota.boundingPelota.Center.ToString());
            }

            wall.render();

            foreach (Colisionable collisionable in collisionableList)
            {
                collisionable.render();
            }

            weapon.update();
            weapon.render();
        }

        /// <summary>
        /// Método que se llama cuando termina la ejecución del ejemplo.
        /// Hacer dispose() de todos los objetos creados.
        /// </summary>
        public override void close()
        {

        }

    }
}
