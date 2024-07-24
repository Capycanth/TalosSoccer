using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TalosSoccer.Core.Models
{
    public abstract class Circle
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        protected float Radius { get; private set; }
        protected Texture2D Texture { get; private set; }
        protected Vector2 CenterPoint { get { return Position + CenterOffset; } }
        private Vector2 CenterOffset { get; set; }

        public Circle(float initialRadius, Texture2D circleTexture)
        {
            Radius = initialRadius;
            Texture = circleTexture;
            CenterOffset = new Vector2(initialRadius, initialRadius);
        }

        public virtual void Update(float elapsedMs)
        {
            Position += Velocity * elapsedMs;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }

}
