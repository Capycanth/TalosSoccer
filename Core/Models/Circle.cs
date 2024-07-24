using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TalosSoccer.Core.Models
{
    public abstract class Circle
    {
        public Texture2D Texture { get; private set; }
        public Rectangle Rectangle { get; protected set; }
        public int Radius { get; private set; }
        public Point CenterPoint
        {
            get
            {
                return new Point(this.Rectangle.X + Radius, this.Rectangle.Y + Radius);
            }
        }
        public Vector2 Velocity { get; set; }

        public Circle(Texture2D texture, Rectangle rectangle)
        {
            this.Texture = texture;
            this.Rectangle = rectangle;
            this.Radius = rectangle.Width >> 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, Color.White);
        }

        public abstract void Update(float elapsedMs);
    }
}
