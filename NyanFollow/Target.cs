using Aiv.Fast2D;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyanFollow
{
    class Target
    {
        private Sprite sprite;
        private Texture texture;

        public bool IsVisible;

        public Vector2 Position
        {
            get { return sprite.position; }
            set { sprite.position = value; }
        }

        public Target(string texturePath)
        {
            texture = new Texture(texturePath);
            sprite = new Sprite(texture.Width, texture.Height);
            sprite.scale = new Vector2(0.2f);
            sprite.pivot = new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f);
        }

        public void Draw()
        {
            if (IsVisible)
            {
                sprite.DrawTexture(texture);
            }
        }
    }
}
