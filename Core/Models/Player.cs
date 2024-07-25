using ChekhovsUtil.serialization;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using TalosSoccer.Core.enumeration;

namespace TalosSoccer.Core.Models
{
    public class Player : Circle, IBinary
    {
        public PlayerPosition PlayerPosition { get; private set; }
        public Player(Texture2D circleTexture, PlayerPosition playerPosition) : base(32, circleTexture)
        {
            PlayerPosition = playerPosition;
        }

        public override void Update(float elapsedMs)
        {
            base.Update(elapsedMs);
        }

        public void Deserialize(BinaryReader reader)
        {
            PlayerPosition = (PlayerPosition)reader.ReadByte();
        }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write((byte)PlayerPosition);
        }
    }
}
