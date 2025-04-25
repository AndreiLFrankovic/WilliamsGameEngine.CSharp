using GameEngine;

using System;
using SFML.System;
namespace MyGame
{
    class MeteorSpawner : GameObject
    {
        // the number of milliseconds between meteor spans.
        private const int SpawnDelay = 1000;
        private int _timer;
        public override void Update(Time elapsed)
        {
            // Determine how much time has passed and adjust our timer.
            int msElapsed = elapsed.AsMilliseconds();
            _timer -= msElapsed;
            // If our timer has elapsed, reset it and spawn a meteor.
            if (_timer <= 0)
            {
                _timer = SpawnDelay;
                Vector2u size = Game.RenderWindow.Size;
                // Spawn the meteor off the right side of the screen.
                // We're assuming the meteor isn't more than 100 pixels wide.
                float minY = Math.Max(10, size.Y * 0.1f);
                float maxY = Math.Min(size.Y - 10, size.Y * .09f);
                if (minY >= maxY)
                {
                    minY = size.Y * 0.25f;
                    maxY = size.Y * 0.75f;
                }
                float meteorX = size.X + 100;
                // Spawn the meteor somewhere aloing the height of the window, randomly.
                float meteorY = Game.Random.Next((int)minY, (int)maxY);
               
                // Create a meteor and add it to the scene
                Meteor meteor = new Meteor(new Vector2f(meteorX, meteorY));
                Game.CurrentScene.AddGameObject(meteor);
            }
        }
    }
}