using ChekhovsUtil.serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace TalosSoccer.Core.Models
{
    public class Player : Circle, IBinary
    {
        public Player(Texture2D texture, Rectangle rectangle) : base(texture, rectangle)
        {
        }

        public override void Update(float elapsedMs)
        {
            throw new NotImplementedException();
        }

        public void Deserialize(BinaryReader reader)
        {
            throw new NotImplementedException();
        }

        public void Serialize(BinaryWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
