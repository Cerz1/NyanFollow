using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace NyanFollow
{
    class Player
    {
        private Sprite sprite;
        private Texture texture;

        private float speed = 550;
        private Vector2 velocity;

        private Target target;

        public Target Target
        {
            get { return target; }
            set { SetTarget(value); }
        }

        public Vector2 Position
        {
            get { return sprite.position; }
            set { sprite.position = value; }
        }

        private void SetTarget(Target target)
        {
            this.target = target;
            //change color
            sprite.SetAdditiveTint(200, 0, 0, -80);
        }

        public Player(string texturePath)
        {
            texture = new Texture(texturePath);
            sprite = new Sprite(texture.Width, texture.Height);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);
        }

        public void Update()
        {
            if (target != null)
            {
                Vector2 targetDist = target.Position - sprite.position;

                if (targetDist.Length <= 8)
                {//near
                    velocity = Vector2.Zero;
                    sprite.position = target.Position;
                    target = null;
                    //sprite.SetMultiplyTint(1f, 1f, 1f, 1f);
                    sprite.SetAdditiveTint(0, 0, 0, 0);

                }
                else
                {//follow
                    //Velocity = targetDist * 10;
                    velocity = targetDist.Normalized() * speed;
                }
            }

            sprite.position += velocity * Program.win.DeltaTime;
        }

        public void Draw()
        {
            sprite.DrawTexture(texture);
        }
        

             
    }
}
