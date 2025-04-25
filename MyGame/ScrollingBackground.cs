using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    class ScrollingBackground : GameObject
    {
        private Sprite _sprite;
        private Texture _texture;
        private float _scrollSpeed = 0.1f; // pixels per millisecond

        public ScrollingBackground()
        {
            _texture = Game.GetTexture("Resources/background.png");
            _sprite = new Sprite(_texture);
            _sprite.Position = new Vector2f(0, 0);
        }

        public override void Update(Time elapsed)
        {
            float moveX = _scrollSpeed * elapsed.AsMilliseconds();
            _sprite.Position = new Vector2f(_sprite.Position.X - moveX, _sprite.Position.Y);

            // Reset to 0 when background fully scrolled off-screen
            if (_sprite.Position.X <= -_texture.Size.X)
            {
                _sprite.Position = new Vector2f(0, _sprite.Position.Y);
            }
        }

        public override void Draw()
        {
            // Draw main background
            Game.RenderWindow.Draw(_sprite);

            // Draw second background next to it for smooth looping
            if (_sprite.Position.X < 0)
            {
                Sprite secondSprite = new Sprite(_texture);
                secondSprite.Position = new Vector2f(_sprite.Position.X + _texture.Size.X, _sprite.Position.Y);
                Game.RenderWindow.Draw(secondSprite);
            }
        }
    }
}
