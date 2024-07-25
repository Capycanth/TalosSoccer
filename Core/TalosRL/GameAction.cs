using ChekhovsUtil.serialization;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TalosSoccer.Core.Containers;
using TalosSoccer.Core.Models;

namespace TalosSoccer.Core.TalosRL
{
    public abstract class GameAction : IBinary
    {
        public Dictionary<string, float> ActionMap { get; private set; }
        private StateKey _stateKey;

        public virtual bool MeetsCriteria(Match match, Player player)
        {
            _stateKey.UpdateStateKey(match);
            return true;
        }

        public void Deserialize(BinaryReader reader)
        {
            int length = reader.ReadInt32();
            byte[] data = reader.ReadBytes(length);
            ActionMap = JsonSerializer.Deserialize<Dictionary<string, float>>(data);
        }
        public void Serialize(BinaryWriter writer)
        {
            byte[] data = JsonSerializer.SerializeToUtf8Bytes(ActionMap);
            writer.Write(data.Length);
            writer.Write(data);
        }
    }
}
