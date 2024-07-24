using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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

        public Ball(Texture2D circleTexture) : base(16, circleTexture)
        {
            CurrentState = BallState.FREE;
        }

        public override void Update(float elapsedMs)
        {
            // Apply friction to the velocity
            Velocity *= FRICTION;

            // Call the base update method to move the ball
            base.Update(elapsedMs);
        }
    }
}
