using System;
using System.Collections.Generic;
using TalosSoccer.Core.enumeration;

namespace TalosSoccer.SoccerUtil
{
    public class TeamInfo
    {
        public string TexturePath { get; private set; }
        public string DataFile { get; private set; }

        private readonly string TEXTURE_PATH_TEMPLATE = "Flags/{}-flag";
        
        public TeamInfo(string teamName)
        {
            TexturePath = TEXTURE_PATH_TEMPLATE.Replace("{}", teamName);
            DataFile = teamName + ".dat";
        }
    }

    public static class TeamInfoMap
    {
        private static readonly Dictionary<TeamEnum, TeamInfo> Map = new Dictionary<TeamEnum, TeamInfo>(32);

        static TeamInfoMap()
        {
            Map = new Dictionary<TeamEnum, TeamInfo>(32);
            foreach (TeamEnum team in Enum.GetValues(typeof(TeamEnum)))
            {
                Map[team] = new TeamInfo(team.ToString().Replace('_', '-').ToLower());
            }
        }
    }
}
