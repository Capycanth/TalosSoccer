using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TalosSoccer.Core.Containers
{
    public class Match
    {
        private Team HomeTeam { get; set; }
        private Team AwayTeam { get; set; }
        private float ElapsedTime { get; set; }

        private float HALFTIME = 2_700_000f;
        private Texture2D Field { get; set; }
        private Rectangle Rectangle { get; set; }

        public Match(Team awayTeam, Team homeTeam)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Field = Game1.ResourceCache.GetTexture("field");
            Rectangle = new Rectangle(0, 0, Game1.ScreenWidth, Game1.ScreenHeight);
        }

        public void Update(float elapsedMS)
        {
            ElapsedTime += elapsedMS;
            if (ElapsedTime > HALFTIME) ExecuteHalftime();

            HomeTeam.Update(elapsedMS);
            AwayTeam.Update(elapsedMS);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Field, Rectangle, Color.White);
            HomeTeam.Draw(spriteBatch);
            AwayTeam.Draw(spriteBatch);
        }

        private void ExecuteHalftime()
        {

        }

    }
}
