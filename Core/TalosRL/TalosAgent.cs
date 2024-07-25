using ChekhovsUtil.serialization;
using System;
using System.Collections.Generic;
using System.IO;
using TalosSoccer.Core.Containers;
using TalosSoccer.Core.Models;

namespace TalosSoccer.Core.TalosRL
{
    public class TalosAgent : IBinary
    {
        List<Tuple<GameAction, bool>> Actions = new List<Tuple<GameAction, bool>>();


        public void ValidateActions(Match match, Player player)
        {
            for (int i = 0; i < Actions.Count; i++)
            {
                Tuple<GameAction, bool> action = Actions[i];
                Actions[i] = new(action.Item1, action.Item1.MeetsCriteria(match, player));
            }
        }

        public void Deserialize(BinaryReader reader)
        {
            foreach(Tuple<GameAction, bool> action in Actions)
            {
                action.Item1.Deserialize(reader);
            }
        }

        public void Serialize(BinaryWriter writer)
        {
            foreach(Tuple<GameAction, bool> action in Actions)
            {
                action.Item1.Serialize(writer);
            }
        }
    }
}
