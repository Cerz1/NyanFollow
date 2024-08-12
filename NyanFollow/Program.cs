using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;


namespace NyanFollow
{
    class Program
    {
        public static Window win;
        static void Main(string[] args)
        {
            win = new Window(1280, 720, "Nyan follow");
            //win.SetVSync(false);

            Target target = new Target("Assets/cross.png");

            Player player = new Player("Assets/nyancat.png");
            player.Position = new Vector2(300, 500);





            //sprite.scale = new Vector2(0.5f, 0.5f);


            while (win.IsOpened)
            {
                win.SetTitle($"FPS {1f / win.DeltaTime}");
                //INPUT
                if (win.GetKey(KeyCode.Esc))
                    return;

                if(win.MouseLeft)
                {
                    target.Position = win.MousePosition;
                    target.IsVisible = true;
                    player.Target = target;
                }




                //UPDATE
                player.Update();
                //DRAW
                //sprite.DrawColor(255, 0, 0);
                //sprite.DrawWireframe(0, 255, 0);
                target.Draw();
                player.Draw();



                win.Update();
            }
        }
    }
}
