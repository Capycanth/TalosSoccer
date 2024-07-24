using ChekhovsUtil.serialization;
using System;
using System.IO;
using TalosSoccer.Core.Models;

namespace TalosSoccer.Core.Containers
{
    public class Team : IBinary
    {
        public string Name { get; private set; }
        public Player[] Players { get; private set; }

        public void Deserialize(BinaryReader reader)
        {
            this.Name = reader.ReadString();
            this.Players = new Player[11];
            foreach (Player player in this.Players) player.Deserialize(reader);
        }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(this.Name);
            foreach (Player player in this.Players) player.Serialize(writer);
        }
    }
}
