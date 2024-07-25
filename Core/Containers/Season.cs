using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TalosSoccer.Core.enumeration;

namespace TalosSoccer.Core.Containers
{
    public class Season
    {
        private readonly Random random = new Random();
        private Queue<Tuple<TeamEnum, TeamEnum>> matches;
        private Match currentMatch;

        public Season() { }

        public void InitializeRandom(int length = 64)
        {
            TeamEnum[] teams = Enum.GetValues<TeamEnum>();
            int numOfTeams = teams.Length;
            matches = new Queue<Tuple<TeamEnum, TeamEnum>>(length);

            for (int i = 0; i < length; i++)
            {
                TeamEnum home = teams[random.Next(numOfTeams)];
                TeamEnum away = teams[random.Next(numOfTeams)];
                while (home == away)
                {
                    home = teams[random.Next(numOfTeams)];
                    away = teams[random.Next(numOfTeams)];
                }
                matches.Enqueue(new Tuple<TeamEnum, TeamEnum>(home,away));
            }
        }

        public void Update(float elapsedMs)
        {
            if (currentMatch != null)
            {
                currentMatch.Update(elapsedMs);
                if (currentMatch.IsMatchOver)
                {
                    Tuple<TeamEnum, TeamEnum> newMatch = matches.Dequeue();
                    //currentMatch = new Match();
                }
            }
            else
            {
                Tuple<TeamEnum, TeamEnum> newMatch = matches.Dequeue();
                //currentMatch = new Match();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentMatch?.Draw(spriteBatch);
        }
    }
}
