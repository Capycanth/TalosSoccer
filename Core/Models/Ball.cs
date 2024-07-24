using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TalosSoccer.Core.Models
{
    public enum BallState : byte
    {
        FREE = 0,
        HELD = 1,
    }

    public class Ball : Circle
    {
        public BallState CurrentState { get; set; }
        private readonly float FRICTION = 0.97f;

        public Ball(Texture2D texture, Rectangle rectangle) : base(texture, rectangle)
        {
            this.CurrentState = BallState.FREE;
        }

        public override void Update(float elapsedMs)
        {
            Rectangle rectangle = this.Rectangle;
            this.Velocity *= this.FRICTION;
            rectangle.X *= (int)(this.Velocity.X * elapsedMs);
            rectangle.Y *= (int)(this.Velocity.Y * elapsedMs);
            this.Rectangle = rectangle;
        }
    }
}
